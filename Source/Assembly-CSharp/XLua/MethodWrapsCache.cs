using System;
using System.Collections.Generic;
using System.Reflection;
using XLua.LuaDLL;

namespace XLua
{
	public class MethodWrapsCache
	{
		public MethodWrapsCache(ObjectTranslator translator, ObjectCheckers objCheckers, ObjectCasters objCasters)
		{
			this.translator = translator;
			this.objCheckers = objCheckers;
			this.objCasters = objCasters;
		}

		public lua_CSFunction GetConstructorWrap(Type type)
		{
			if (!this.constructorCache.ContainsKey(type))
			{
				ConstructorInfo[] constructors = type.GetConstructors();
				if (type.IsAbstract() || constructors == null || constructors.Length == 0)
				{
					if (!type.IsValueType())
					{
						return null;
					}
					this.constructorCache[type] = delegate(IntPtr L)
					{
						this.translator.PushAny(L, Activator.CreateInstance(type));
						return 1;
					};
				}
				else
				{
					lua_CSFunction ctor = new lua_CSFunction(this._GenMethodWrap(type, ".ctor", constructors, true).Call);
					if (type.IsValueType())
					{
						bool flag = false;
						for (int i = 0; i < constructors.Length; i++)
						{
							if (constructors[i].GetParameters().Length == 0)
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							this.constructorCache[type] = ctor;
						}
						else
						{
							this.constructorCache[type] = delegate(IntPtr L)
							{
								if (Lua.lua_gettop(L) == 1)
								{
									this.translator.PushAny(L, Activator.CreateInstance(type));
									return 1;
								}
								return ctor(L);
							};
						}
					}
					else
					{
						this.constructorCache[type] = ctor;
					}
				}
			}
			return this.constructorCache[type];
		}

		public lua_CSFunction GetMethodWrap(Type type, string methodName)
		{
			if (!this.methodsCache.ContainsKey(type))
			{
				this.methodsCache[type] = new Dictionary<string, lua_CSFunction>();
			}
			Dictionary<string, lua_CSFunction> dictionary = this.methodsCache[type];
			if (!dictionary.ContainsKey(methodName))
			{
				MemberInfo[] member = type.GetMember(methodName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
				if (member == null || member.Length == 0 || member[0].MemberType != MemberTypes.Method)
				{
					return null;
				}
				dictionary[methodName] = new lua_CSFunction(this._GenMethodWrap(type, methodName, member, false).Call);
			}
			return dictionary[methodName];
		}

		public lua_CSFunction GetMethodWrapInCache(Type type, string methodName)
		{
			if (!this.methodsCache.ContainsKey(type))
			{
				this.methodsCache[type] = new Dictionary<string, lua_CSFunction>();
			}
			Dictionary<string, lua_CSFunction> dictionary = this.methodsCache[type];
			if (!dictionary.ContainsKey(methodName))
			{
				return null;
			}
			return dictionary[methodName];
		}

		public lua_CSFunction GetDelegateWrap(Type type)
		{
			if (!typeof(Delegate).IsAssignableFrom(type))
			{
				return null;
			}
			if (!this.delegateCache.ContainsKey(type))
			{
				this.delegateCache[type] = new lua_CSFunction(this._GenMethodWrap(type, type.ToString(), new MethodBase[]
				{
					type.GetMethod("Invoke")
				}, false).Call);
			}
			return this.delegateCache[type];
		}

		public lua_CSFunction GetEventWrap(Type type, string eventName)
		{
			if (!this.methodsCache.ContainsKey(type))
			{
				this.methodsCache[type] = new Dictionary<string, lua_CSFunction>();
			}
			Dictionary<string, lua_CSFunction> dictionary = this.methodsCache[type];
			if (!dictionary.ContainsKey(eventName))
			{
				EventInfo eventInfo = type.GetEvent(eventName, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				if (eventInfo == null)
				{
					throw new Exception(type.Name + " has no event named: " + eventName);
				}
				int start_idx = 0;
				MethodInfo add = eventInfo.GetAddMethod(true);
				MethodInfo remove = eventInfo.GetRemoveMethod(true);
				if (add == null && remove == null)
				{
					throw new Exception(type.Name + "'s " + eventName + " has either add nor remove");
				}
				bool is_static = (add != null) ? add.IsStatic : remove.IsStatic;
				if (!is_static)
				{
					start_idx = 1;
				}
				dictionary[eventName] = delegate(IntPtr L)
				{
					object obj = null;
					if (!is_static)
					{
						obj = this.translator.GetObject(L, 1, type);
						if (obj == null)
						{
							string str = "invalid #1, needed:";
							Type type2 = type;
							return Lua.luaL_error(L, str + ((type2 != null) ? type2.ToString() : null));
						}
					}
					try
					{
						object obj2 = this.translator.CreateDelegateBridge(L, eventInfo.EventHandlerType, start_idx + 2);
						if (obj2 == null)
						{
							string str2 = "invalid #";
							string str3 = (start_idx + 2).ToString();
							string str4 = ", needed:";
							Type eventHandlerType = eventInfo.EventHandlerType;
							return Lua.luaL_error(L, str2 + str3 + str4 + ((eventHandlerType != null) ? eventHandlerType.ToString() : null));
						}
						string text = Lua.lua_tostring(L, start_idx + 1);
						if (text != null)
						{
							if (!(text == "+"))
							{
								if (!(text == "-"))
								{
									goto IL_171;
								}
								if (remove == null)
								{
									return Lua.luaL_error(L, "no remove for event " + eventName);
								}
								remove.Invoke(obj, new object[]
								{
									obj2
								});
							}
							else
							{
								if (add == null)
								{
									return Lua.luaL_error(L, "no add for event " + eventName);
								}
								add.Invoke(obj, new object[]
								{
									obj2
								});
							}
							return 0;
						}
						IL_171:
						string str5 = "invalid #";
						string str6 = (start_idx + 1).ToString();
						string str7 = ", needed: '+' or '-'";
						Type eventHandlerType2 = eventInfo.EventHandlerType;
						return Lua.luaL_error(L, str5 + str6 + str7 + ((eventHandlerType2 != null) ? eventHandlerType2.ToString() : null));
					}
					catch (Exception ex)
					{
						string str8 = "c# exception:";
						Exception ex2 = ex;
						return Lua.luaL_error(L, str8 + ((ex2 != null) ? ex2.ToString() : null) + ",stack:" + ex.StackTrace);
					}
					return 0;
				};
			}
			return dictionary[eventName];
		}

		public MethodWrap _GenMethodWrap(Type type, string methodName, IEnumerable<MemberInfo> methodBases, bool forceCheck = false)
		{
			List<OverloadMethodWrap> list = new List<OverloadMethodWrap>();
			foreach (MemberInfo memberInfo in methodBases)
			{
				MethodBase methodBase = memberInfo as MethodBase;
				if (!(methodBase == null) && (!methodBase.IsGenericMethodDefinition || MethodWrapsCache.tryMakeGenericMethod(ref methodBase)))
				{
					OverloadMethodWrap overloadMethodWrap = new OverloadMethodWrap(this.translator, type, methodBase);
					overloadMethodWrap.Init(this.objCheckers, this.objCasters);
					list.Add(overloadMethodWrap);
				}
			}
			return new MethodWrap(methodName, list, forceCheck);
		}

		private static bool tryMakeGenericMethod(ref MethodBase method)
		{
			bool result;
			try
			{
				if (!(method is MethodInfo) || !Utils.IsSupportedMethod(method as MethodInfo))
				{
					result = false;
				}
				else
				{
					Type[] genericArguments = method.GetGenericArguments();
					Type[] array = new Type[genericArguments.Length];
					for (int i = 0; i < genericArguments.Length; i++)
					{
						Type[] genericParameterConstraints = genericArguments[i].GetGenericParameterConstraints();
						array[i] = genericParameterConstraints[0];
					}
					method = ((MethodInfo)method).MakeGenericMethod(array);
					result = true;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		private ObjectTranslator translator;

		private ObjectCheckers objCheckers;

		private ObjectCasters objCasters;

		private Dictionary<Type, lua_CSFunction> constructorCache = new Dictionary<Type, lua_CSFunction>();

		private Dictionary<Type, Dictionary<string, lua_CSFunction>> methodsCache = new Dictionary<Type, Dictionary<string, lua_CSFunction>>();

		private Dictionary<Type, lua_CSFunction> delegateCache = new Dictionary<Type, lua_CSFunction>();
	}
}
