using System;
using System.Collections.Generic;
using System.Threading;
using Tutorial;
using UnityEngine;
using UnityEngine.Events;
using XLua.LuaDLL;
using XLuaTest;

namespace XLua
{
	public class DelegateBridge : DelegateBridgeBase
	{
		public void __Gen_Delegate_Imp0()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				this.PCall(rawL, 0, 0, num);
				Lua.lua_settop(rawL, num - 1);
			}
		}

		public double __Gen_Delegate_Imp1(double p0, double p1)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			double result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				Lua.lua_pushnumber(rawL, p0);
				Lua.lua_pushnumber(rawL, p1);
				this.PCall(rawL, 2, 1, num);
				double num2 = Lua.lua_tonumber(rawL, num + 1);
				Lua.lua_settop(rawL, num - 1);
				result = num2;
			}
			return result;
		}

		public void __Gen_Delegate_Imp2(string p0)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				Lua.lua_pushstring(rawL, p0);
				this.PCall(rawL, 1, 0, num);
				Lua.lua_settop(rawL, num - 1);
			}
		}

		public void __Gen_Delegate_Imp3(double p0)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				Lua.lua_pushnumber(rawL, p0);
				this.PCall(rawL, 1, 0, num);
				Lua.lua_settop(rawL, num - 1);
			}
		}

		public int __Gen_Delegate_Imp4(int p0)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			int result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				Lua.xlua_pushinteger(rawL, p0);
				this.PCall(rawL, 1, 1, num);
				int num2 = Lua.xlua_tointeger(rawL, num + 1);
				Lua.lua_settop(rawL, num - 1);
				result = num2;
			}
			return result;
		}

		public Vector3 __Gen_Delegate_Imp5(Vector3 p0)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			Vector3 result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				ObjectTranslator translator = this.luaEnv.translator;
				translator.PushUnityEngineVector3(rawL, p0);
				this.PCall(rawL, 1, 1, num);
				Vector3 vector;
				translator.Get(rawL, num + 1, out vector);
				Lua.lua_settop(rawL, num - 1);
				result = vector;
			}
			return result;
		}

		public MyStruct __Gen_Delegate_Imp6(MyStruct p0)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			MyStruct result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				ObjectTranslator translator = this.luaEnv.translator;
				translator.PushXLuaTestMyStruct(rawL, p0);
				this.PCall(rawL, 1, 1, num);
				MyStruct myStruct;
				translator.Get(rawL, num + 1, out myStruct);
				Lua.lua_settop(rawL, num - 1);
				result = myStruct;
			}
			return result;
		}

		public MyEnum __Gen_Delegate_Imp7(MyEnum p0)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			MyEnum result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				ObjectTranslator translator = this.luaEnv.translator;
				translator.PushXLuaTestMyEnum(rawL, p0);
				this.PCall(rawL, 1, 1, num);
				MyEnum myEnum;
				translator.Get(rawL, num + 1, out myEnum);
				Lua.lua_settop(rawL, num - 1);
				result = myEnum;
			}
			return result;
		}

		public decimal __Gen_Delegate_Imp8(decimal p0)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			decimal result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				ObjectTranslator translator = this.luaEnv.translator;
				translator.PushDecimal(rawL, p0);
				this.PCall(rawL, 1, 1, num);
				decimal num2;
				translator.Get(rawL, num + 1, out num2);
				Lua.lua_settop(rawL, num - 1);
				result = num2;
			}
			return result;
		}

		public void __Gen_Delegate_Imp9(Array p0)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				this.luaEnv.translator.Push(rawL, p0);
				this.PCall(rawL, 1, 0, num);
				Lua.lua_settop(rawL, num - 1);
			}
		}

		public void __Gen_Delegate_Imp10(bool p0)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				Lua.lua_pushboolean(rawL, p0);
				this.PCall(rawL, 1, 0, num);
				Lua.lua_settop(rawL, num - 1);
			}
		}

		public int __Gen_Delegate_Imp11(int p0, string p1, out CSCallLua.DClass p2)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			int result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.xlua_pushinteger(rawL, p0);
				Lua.lua_pushstring(rawL, p1);
				this.PCall(rawL, 2, 2, num);
				p2 = (CSCallLua.DClass)translator.GetObject(rawL, num + 2, typeof(CSCallLua.DClass));
				int num2 = Lua.xlua_tointeger(rawL, num + 1);
				Lua.lua_settop(rawL, num - 1);
				result = num2;
			}
			return result;
		}

		public Action __Gen_Delegate_Imp12()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			Action result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				ObjectTranslator translator = this.luaEnv.translator;
				this.PCall(rawL, 0, 1, num);
				Action @delegate = translator.GetDelegate<Action>(rawL, num + 1);
				Lua.lua_settop(rawL, num - 1);
				result = @delegate;
			}
			return result;
		}

		public InvokeLua.ICalc __Gen_Delegate_Imp13(int p0, string[] p1)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			InvokeLua.ICalc result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.xlua_pushinteger(rawL, p0);
				if (p1 != null)
				{
					for (int i = 0; i < p1.Length; i++)
					{
						Lua.lua_pushstring(rawL, p1[i]);
					}
				}
				this.PCall(rawL, 1 + ((p1 == null) ? 0 : p1.Length), 1, num);
				InvokeLua.ICalc calc = (InvokeLua.ICalc)translator.GetObject(rawL, num + 1, typeof(InvokeLua.ICalc));
				Lua.lua_settop(rawL, num - 1);
				result = calc;
			}
			return result;
		}

		public void __Gen_Delegate_Imp14(object p0)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				this.luaEnv.translator.PushAny(rawL, p0);
				this.PCall(rawL, 1, 0, num);
				Lua.lua_settop(rawL, num - 1);
			}
		}

		public int __Gen_Delegate_Imp15(object p0, int p1, int p2)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			int result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				this.luaEnv.translator.PushAny(rawL, p0);
				Lua.xlua_pushinteger(rawL, p1);
				Lua.xlua_pushinteger(rawL, p2);
				this.PCall(rawL, 3, 1, num);
				int num2 = Lua.xlua_tointeger(rawL, num + 1);
				Lua.lua_settop(rawL, num - 1);
				result = num2;
			}
			return result;
		}

		public Vector3 __Gen_Delegate_Imp16(object p0, Vector3 p1, Vector3 p2)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			Vector3 result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				ObjectTranslator translator = this.luaEnv.translator;
				translator.PushAny(rawL, p0);
				translator.PushUnityEngineVector3(rawL, p1);
				translator.PushUnityEngineVector3(rawL, p2);
				this.PCall(rawL, 3, 1, num);
				Vector3 vector;
				translator.Get(rawL, num + 1, out vector);
				Lua.lua_settop(rawL, num - 1);
				result = vector;
			}
			return result;
		}

		public int __Gen_Delegate_Imp17(object p0, int p1, out double p2, ref string p3)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			int result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				this.luaEnv.translator.PushAny(rawL, p0);
				Lua.xlua_pushinteger(rawL, p1);
				Lua.lua_pushstring(rawL, p3);
				this.PCall(rawL, 3, 3, num);
				p2 = Lua.lua_tonumber(rawL, num + 2);
				p3 = Lua.lua_tostring(rawL, num + 3);
				int num2 = Lua.xlua_tointeger(rawL, num + 1);
				Lua.lua_settop(rawL, num - 1);
				result = num2;
			}
			return result;
		}

		public int __Gen_Delegate_Imp18(object p0, int p1, out double p2, ref string p3, object p4)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			int result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				ObjectTranslator translator = this.luaEnv.translator;
				translator.PushAny(rawL, p0);
				Lua.xlua_pushinteger(rawL, p1);
				Lua.lua_pushstring(rawL, p3);
				translator.PushAny(rawL, p4);
				this.PCall(rawL, 4, 3, num);
				p2 = Lua.lua_tonumber(rawL, num + 2);
				p3 = Lua.lua_tostring(rawL, num + 3);
				int num2 = Lua.xlua_tointeger(rawL, num + 1);
				Lua.lua_settop(rawL, num - 1);
				result = num2;
			}
			return result;
		}

		public void __Gen_Delegate_Imp19(object p0, int p1)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				this.luaEnv.translator.PushAny(rawL, p0);
				Lua.xlua_pushinteger(rawL, p1);
				this.PCall(rawL, 2, 0, num);
				Lua.lua_settop(rawL, num - 1);
			}
		}

		public string __Gen_Delegate_Imp20(object p0)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			string result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				this.luaEnv.translator.PushAny(rawL, p0);
				this.PCall(rawL, 1, 1, num);
				string text = Lua.lua_tostring(rawL, num + 1);
				Lua.lua_settop(rawL, num - 1);
				result = text;
			}
			return result;
		}

		public GameObject __Gen_Delegate_Imp21(StructTest p0, int p1, object p2)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			GameObject result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				ObjectTranslator translator = this.luaEnv.translator;
				translator.Push(rawL, p0);
				Lua.xlua_pushinteger(rawL, p1);
				translator.PushAny(rawL, p2);
				this.PCall(rawL, 3, 1, num);
				GameObject gameObject = (GameObject)translator.GetObject(rawL, num + 1, typeof(GameObject));
				Lua.lua_settop(rawL, num - 1);
				result = gameObject;
			}
			return result;
		}

		public string __Gen_Delegate_Imp22(StructTest p0)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			string result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				this.luaEnv.translator.Push(rawL, p0);
				this.PCall(rawL, 1, 1, num);
				string text = Lua.lua_tostring(rawL, num + 1);
				Lua.lua_settop(rawL, num - 1);
				result = text;
			}
			return result;
		}

		public void __Gen_Delegate_Imp23(StructTest p0, object p1)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				ObjectTranslator translator = this.luaEnv.translator;
				translator.Push(rawL, p0);
				translator.PushAny(rawL, p1);
				this.PCall(rawL, 2, 0, num);
				Lua.lua_settop(rawL, num - 1);
			}
		}

		public int __Gen_Delegate_Imp24(object p0)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			int result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				this.luaEnv.translator.PushAny(rawL, p0);
				this.PCall(rawL, 1, 1, num);
				int num2 = Lua.xlua_tointeger(rawL, num + 1);
				Lua.lua_settop(rawL, num - 1);
				result = num2;
			}
			return result;
		}

		public void __Gen_Delegate_Imp25(object p0, object p1)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				ObjectTranslator translator = this.luaEnv.translator;
				translator.PushAny(rawL, p0);
				translator.PushAny(rawL, p1);
				this.PCall(rawL, 2, 0, num);
				Lua.lua_settop(rawL, num - 1);
			}
		}

		public int __Gen_Delegate_Imp26(object p0, object p1)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			int result;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				ObjectTranslator translator = this.luaEnv.translator;
				translator.PushAny(rawL, p0);
				translator.PushAny(rawL, p1);
				this.PCall(rawL, 2, 1, num);
				int num2 = Lua.xlua_tointeger(rawL, num + 1);
				Lua.lua_settop(rawL, num - 1);
				result = num2;
			}
			return result;
		}

		public void __Gen_Delegate_Imp27(object p0, object p1, int p2)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				ObjectTranslator translator = this.luaEnv.translator;
				translator.PushAny(rawL, p0);
				translator.PushAny(rawL, p1);
				Lua.xlua_pushinteger(rawL, p2);
				this.PCall(rawL, 3, 0, num);
				Lua.lua_settop(rawL, num - 1);
			}
		}

		public void __Gen_Delegate_Imp28(int p0, int p1)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				Lua.xlua_pushinteger(rawL, p0);
				Lua.xlua_pushinteger(rawL, p1);
				this.PCall(rawL, 2, 0, num);
				Lua.lua_settop(rawL, num - 1);
			}
		}

		public void __Gen_Delegate_Imp29(object p0, int p1, int p2)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr rawL = this.luaEnv.rawL;
				int num = Lua.pcall_prepare(rawL, this.errorFuncRef, this.luaReference);
				this.luaEnv.translator.PushAny(rawL, p0);
				Lua.xlua_pushinteger(rawL, p1);
				Lua.xlua_pushinteger(rawL, p2);
				this.PCall(rawL, 3, 0, num);
				Lua.lua_settop(rawL, num - 1);
			}
		}

		static DelegateBridge()
		{
			DelegateBridge.Gen_Flag = true;
		}

		public override Delegate GetDelegateByType(Type type)
		{
			if (type == typeof(Action))
			{
				return new Action(this.__Gen_Delegate_Imp0);
			}
			if (type == typeof(UnityAction))
			{
				return new UnityAction(this.__Gen_Delegate_Imp0);
			}
			if (type == typeof(Func<double, double, double>))
			{
				return new Func<double, double, double>(this.__Gen_Delegate_Imp1);
			}
			if (type == typeof(Action<string>))
			{
				return new Action<string>(this.__Gen_Delegate_Imp2);
			}
			if (type == typeof(Action<double>))
			{
				return new Action<double>(this.__Gen_Delegate_Imp3);
			}
			if (type == typeof(IntParam))
			{
				return new IntParam(this.__Gen_Delegate_Imp4);
			}
			if (type == typeof(Vector3Param))
			{
				return new Vector3Param(this.__Gen_Delegate_Imp5);
			}
			if (type == typeof(CustomValueTypeParam))
			{
				return new CustomValueTypeParam(this.__Gen_Delegate_Imp6);
			}
			if (type == typeof(EnumParam))
			{
				return new EnumParam(this.__Gen_Delegate_Imp7);
			}
			if (type == typeof(DecimalParam))
			{
				return new DecimalParam(this.__Gen_Delegate_Imp8);
			}
			if (type == typeof(ArrayAccess))
			{
				return new ArrayAccess(this.__Gen_Delegate_Imp9);
			}
			if (type == typeof(Action<bool>))
			{
				return new Action<bool>(this.__Gen_Delegate_Imp10);
			}
			if (type == typeof(CSCallLua.FDelegate))
			{
				return new CSCallLua.FDelegate(this.__Gen_Delegate_Imp11);
			}
			if (type == typeof(CSCallLua.GetE))
			{
				return new CSCallLua.GetE(this.__Gen_Delegate_Imp12);
			}
			if (type == typeof(InvokeLua.CalcNew))
			{
				return new InvokeLua.CalcNew(this.__Gen_Delegate_Imp13);
			}
			return null;
		}

		public DelegateBridge(int reference, LuaEnv luaenv) : base(reference, luaenv)
		{
		}

		public void PCall(IntPtr L, int nArgs, int nResults, int errFunc)
		{
			if (Lua.lua_pcall(L, nArgs, nResults, errFunc) != 0)
			{
				this.luaEnv.ThrowExceptionFromError(errFunc - 1);
			}
		}

		public void InvokeSessionStart()
		{
			Monitor.Enter(this.luaEnv.luaEnvLock);
			IntPtr l = this.luaEnv.L;
			this._stack.Push(this._oldTop);
			this._oldTop = Lua.lua_gettop(l);
			Lua.load_error_func(l, this.luaEnv.errorFuncRef);
			Lua.lua_getref(l, this.luaReference);
		}

		public void Invoke(int nRet)
		{
			if (Lua.lua_pcall(this.luaEnv.L, Lua.lua_gettop(this.luaEnv.L) - this._oldTop - 2, nRet, this._oldTop + 1) != 0)
			{
				int oldTop = this._oldTop;
				this._oldTop = this._stack.Pop();
				Monitor.Exit(this.luaEnv.luaEnvLock);
				this.luaEnv.ThrowExceptionFromError(oldTop);
			}
		}

		public void InvokeSessionEnd()
		{
			Lua.lua_settop(this.luaEnv.L, this._oldTop);
			this._oldTop = this._stack.Pop();
			Monitor.Exit(this.luaEnv.luaEnvLock);
		}

		public TResult InvokeSessionEndWithResult<TResult>()
		{
			if (Lua.lua_gettop(this.luaEnv.L) < this._oldTop + 2)
			{
				this.InvokeSessionEnd();
				throw new InvalidOperationException("no result!");
			}
			TResult result;
			try
			{
				TResult tresult;
				this.luaEnv.translator.Get<TResult>(this.luaEnv.L, this._oldTop + 2, out tresult);
				result = tresult;
			}
			finally
			{
				this.InvokeSessionEnd();
			}
			return result;
		}

		public void InParam<T>(T p)
		{
			try
			{
				this.luaEnv.translator.PushByType<T>(this.luaEnv.L, p);
			}
			catch (Exception ex)
			{
				this.InvokeSessionEnd();
				throw ex;
			}
		}

		public void InParams<T>(T[] ps)
		{
			try
			{
				for (int i = 0; i < ps.Length; i++)
				{
					this.luaEnv.translator.PushByType<T>(this.luaEnv.L, ps[i]);
				}
			}
			catch (Exception ex)
			{
				this.InvokeSessionEnd();
				throw ex;
			}
		}

		public void OutParam<TResult>(int pos, out TResult ret)
		{
			if (Lua.lua_gettop(this.luaEnv.L) < this._oldTop + 2 + pos)
			{
				this.InvokeSessionEnd();
				throw new InvalidOperationException("no result in " + pos.ToString());
			}
			try
			{
				this.luaEnv.translator.Get<TResult>(this.luaEnv.L, this._oldTop + 2 + pos, out ret);
			}
			catch (Exception ex)
			{
				this.InvokeSessionEnd();
				throw ex;
			}
		}

		public void Action()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.lua_gettop(l);
				int errfunc = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				if (Lua.lua_pcall(l, 0, 0, errfunc) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num);
				}
				Lua.lua_settop(l, num);
			}
		}

		public void Action<T1>(T1 p1)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int num = Lua.lua_gettop(l);
				int errfunc = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				translator.PushByType<T1>(l, p1);
				if (Lua.lua_pcall(l, 1, 0, errfunc) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num);
				}
				Lua.lua_settop(l, num);
			}
		}

		public void Action<T1, T2>(T1 p1, T2 p2)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int num = Lua.lua_gettop(l);
				int errfunc = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				translator.PushByType<T1>(l, p1);
				translator.PushByType<T2>(l, p2);
				if (Lua.lua_pcall(l, 2, 0, errfunc) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num);
				}
				Lua.lua_settop(l, num);
			}
		}

		public void Action<T1, T2, T3>(T1 p1, T2 p2, T3 p3)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int num = Lua.lua_gettop(l);
				int errfunc = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				translator.PushByType<T1>(l, p1);
				translator.PushByType<T2>(l, p2);
				translator.PushByType<T3>(l, p3);
				if (Lua.lua_pcall(l, 3, 0, errfunc) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num);
				}
				Lua.lua_settop(l, num);
			}
		}

		public void Action<T1, T2, T3, T4>(T1 p1, T2 p2, T3 p3, T4 p4)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int num = Lua.lua_gettop(l);
				int errfunc = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				translator.PushByType<T1>(l, p1);
				translator.PushByType<T2>(l, p2);
				translator.PushByType<T3>(l, p3);
				translator.PushByType<T4>(l, p4);
				if (Lua.lua_pcall(l, 4, 0, errfunc) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num);
				}
				Lua.lua_settop(l, num);
			}
		}

		public TResult Func<TResult>()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			TResult result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int num = Lua.lua_gettop(l);
				int errfunc = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				if (Lua.lua_pcall(l, 0, 1, errfunc) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num);
				}
				TResult tresult;
				try
				{
					translator.Get<TResult>(l, -1, out tresult);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					Lua.lua_settop(l, num);
				}
				result = tresult;
			}
			return result;
		}

		public TResult Func<T1, TResult>(T1 p1)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			TResult result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int num = Lua.lua_gettop(l);
				int errfunc = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				translator.PushByType<T1>(l, p1);
				if (Lua.lua_pcall(l, 1, 1, errfunc) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num);
				}
				TResult tresult;
				try
				{
					translator.Get<TResult>(l, -1, out tresult);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					Lua.lua_settop(l, num);
				}
				result = tresult;
			}
			return result;
		}

		public TResult Func<T1, T2, TResult>(T1 p1, T2 p2)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			TResult result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int num = Lua.lua_gettop(l);
				int errfunc = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				translator.PushByType<T1>(l, p1);
				translator.PushByType<T2>(l, p2);
				if (Lua.lua_pcall(l, 2, 1, errfunc) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num);
				}
				TResult tresult;
				try
				{
					translator.Get<TResult>(l, -1, out tresult);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					Lua.lua_settop(l, num);
				}
				result = tresult;
			}
			return result;
		}

		public TResult Func<T1, T2, T3, TResult>(T1 p1, T2 p2, T3 p3)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			TResult result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int num = Lua.lua_gettop(l);
				int errfunc = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				translator.PushByType<T1>(l, p1);
				translator.PushByType<T2>(l, p2);
				translator.PushByType<T3>(l, p3);
				if (Lua.lua_pcall(l, 3, 1, errfunc) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num);
				}
				TResult tresult;
				try
				{
					translator.Get<TResult>(l, -1, out tresult);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					Lua.lua_settop(l, num);
				}
				result = tresult;
			}
			return result;
		}

		public TResult Func<T1, T2, T3, T4, TResult>(T1 p1, T2 p2, T3 p3, T4 p4)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			TResult result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int num = Lua.lua_gettop(l);
				int errfunc = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				translator.PushByType<T1>(l, p1);
				translator.PushByType<T2>(l, p2);
				translator.PushByType<T3>(l, p3);
				translator.PushByType<T4>(l, p4);
				if (Lua.lua_pcall(l, 4, 1, errfunc) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num);
				}
				TResult tresult;
				try
				{
					translator.Get<TResult>(l, -1, out tresult);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					Lua.lua_settop(l, num);
				}
				result = tresult;
			}
			return result;
		}

		internal static DelegateBridge[] DelegateBridgeList = new DelegateBridge[0];

		public static bool Gen_Flag = false;

		private int _oldTop;

		private Stack<int> _stack = new Stack<int>();
	}
}
