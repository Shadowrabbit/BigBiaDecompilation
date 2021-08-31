using System;
using System.Collections.Generic;
using System.Reflection;
using XLua.LuaDLL;

namespace XLua
{
	public class OverloadMethodWrap
	{
		public bool HasDefalutValue { get; private set; }

		public OverloadMethodWrap(ObjectTranslator translator, Type targetType, MethodBase method)
		{
			this.translator = translator;
			this.targetType = targetType;
			this.method = method;
			this.HasDefalutValue = false;
		}

		public void Init(ObjectCheckers objCheckers, ObjectCasters objCasters)
		{
			if ((typeof(Delegate) != this.targetType && typeof(Delegate).IsAssignableFrom(this.targetType)) || !this.method.IsStatic || this.method.IsConstructor)
			{
				this.luaStackPosStart = 2;
				if (!this.method.IsConstructor)
				{
					this.targetNeeded = true;
				}
			}
			ParameterInfo[] parameters = this.method.GetParameters();
			this.refPos = new int[parameters.Length];
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			List<ObjectCheck> list3 = new List<ObjectCheck>();
			List<ObjectCast> list4 = new List<ObjectCast>();
			List<bool> list5 = new List<bool>();
			List<object> list6 = new List<object>();
			for (int i = 0; i < parameters.Length; i++)
			{
				this.refPos[i] = -1;
				if (!parameters[i].IsIn && parameters[i].IsOut)
				{
					list2.Add(i);
				}
				else
				{
					if (parameters[i].ParameterType.IsByRef)
					{
						Type elementType = parameters[i].ParameterType.GetElementType();
						if (CopyByValue.IsStruct(elementType) && elementType != typeof(decimal))
						{
							this.refPos[i] = list.Count;
						}
						list2.Add(i);
					}
					list.Add(i);
					Type type = (parameters[i].IsDefined(typeof(ParamArrayAttribute), false) || (!parameters[i].ParameterType.IsArray && parameters[i].ParameterType.IsByRef)) ? parameters[i].ParameterType.GetElementType() : parameters[i].ParameterType;
					list3.Add(objCheckers.GetChecker(type));
					list4.Add(objCasters.GetCaster(type));
					list5.Add(parameters[i].IsOptional);
					object obj = parameters[i].DefaultValue;
					if (parameters[i].IsOptional)
					{
						if (obj != null && obj.GetType() != parameters[i].ParameterType)
						{
							obj = ((obj.GetType() == typeof(Missing)) ? (parameters[i].ParameterType.IsValueType() ? Activator.CreateInstance(parameters[i].ParameterType) : Missing.Value) : Convert.ChangeType(obj, parameters[i].ParameterType));
						}
						this.HasDefalutValue = true;
					}
					list6.Add(parameters[i].IsOptional ? obj : null);
				}
			}
			this.checkArray = list3.ToArray();
			this.castArray = list4.ToArray();
			this.inPosArray = list.ToArray();
			this.outPosArray = list2.ToArray();
			this.isOptionalArray = list5.ToArray();
			this.defaultValueArray = list6.ToArray();
			if (parameters.Length != 0 && parameters[parameters.Length - 1].IsDefined(typeof(ParamArrayAttribute), false))
			{
				this.paramsType = parameters[parameters.Length - 1].ParameterType.GetElementType();
			}
			this.args = new object[parameters.Length];
			if (this.method is MethodInfo)
			{
				this.isVoid = ((this.method as MethodInfo).ReturnType == typeof(void));
				return;
			}
			if (this.method is ConstructorInfo)
			{
				this.isVoid = false;
			}
		}

		public bool Check(IntPtr L)
		{
			int num = Lua.lua_gettop(L);
			int num2 = this.luaStackPosStart;
			int num3 = 0;
			while (num3 < this.checkArray.Length && (num3 != this.checkArray.Length - 1 || !(this.paramsType != null)))
			{
				if (num2 > num && !this.isOptionalArray[num3])
				{
					return false;
				}
				if (num2 <= num && !this.checkArray[num3](L, num2))
				{
					return false;
				}
				if (num2 <= num || !this.isOptionalArray[num3])
				{
					num2++;
				}
				num3++;
			}
			if (!(this.paramsType != null))
			{
				return num2 == num + 1;
			}
			return num2 >= num + 1 || this.checkArray[this.checkArray.Length - 1](L, num2);
		}

		public int Call(IntPtr L)
		{
			int result;
			try
			{
				object obj = null;
				MethodBase methodBase = this.method;
				if (this.luaStackPosStart > 1)
				{
					obj = this.translator.FastGetCSObj(L, 1);
					if (obj is Delegate)
					{
						methodBase = ((Delegate)obj).Method;
					}
				}
				int num = Lua.lua_gettop(L);
				int num2 = this.luaStackPosStart;
				for (int i = 0; i < this.castArray.Length; i++)
				{
					if (num2 > num)
					{
						if (this.paramsType != null && i == this.castArray.Length - 1)
						{
							this.args[this.inPosArray[i]] = Array.CreateInstance(this.paramsType, 0);
						}
						else
						{
							this.args[this.inPosArray[i]] = this.defaultValueArray[i];
						}
					}
					else
					{
						if (this.paramsType != null && i == this.castArray.Length - 1)
						{
							this.args[this.inPosArray[i]] = this.translator.GetParams(L, num2, this.paramsType);
						}
						else
						{
							this.args[this.inPosArray[i]] = this.castArray[i](L, num2, null);
						}
						num2++;
					}
				}
				object o = methodBase.IsConstructor ? ((ConstructorInfo)this.method).Invoke(this.args) : this.method.Invoke(this.targetNeeded ? obj : null, this.args);
				if (this.targetNeeded && this.targetType.IsValueType())
				{
					this.translator.Update(L, 1, obj);
				}
				int num3 = 0;
				if (!this.isVoid)
				{
					this.translator.PushAny(L, o);
					num3++;
				}
				for (int j = 0; j < this.outPosArray.Length; j++)
				{
					if (this.refPos[this.outPosArray[j]] != -1)
					{
						this.translator.Update(L, this.luaStackPosStart + this.refPos[this.outPosArray[j]], this.args[this.outPosArray[j]]);
					}
					this.translator.PushAny(L, this.args[this.outPosArray[j]]);
					num3++;
				}
				result = num3;
			}
			finally
			{
				for (int k = 0; k < this.args.Length; k++)
				{
					this.args[k] = null;
				}
			}
			return result;
		}

		private ObjectTranslator translator;

		private Type targetType;

		private MethodBase method;

		private ObjectCheck[] checkArray;

		private ObjectCast[] castArray;

		private int[] inPosArray;

		private int[] outPosArray;

		private bool[] isOptionalArray;

		private object[] defaultValueArray;

		private bool isVoid = true;

		private int luaStackPosStart = 1;

		private bool targetNeeded;

		private object[] args;

		private int[] refPos;

		private Type paramsType;
	}
}
