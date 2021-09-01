using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using XLua.LuaDLL;

namespace XLua
{
	public class ObjectCasters
	{
		public ObjectCasters(ObjectTranslator translator)
		{
			this.translator = translator;
			this.castersMap[typeof(char)] = new ObjectCast(ObjectCasters.charCaster);
			this.castersMap[typeof(sbyte)] = new ObjectCast(ObjectCasters.sbyteCaster);
			this.castersMap[typeof(byte)] = new ObjectCast(ObjectCasters.byteCaster);
			this.castersMap[typeof(short)] = new ObjectCast(ObjectCasters.shortCaster);
			this.castersMap[typeof(ushort)] = new ObjectCast(ObjectCasters.ushortCaster);
			this.castersMap[typeof(int)] = new ObjectCast(ObjectCasters.intCaster);
			this.castersMap[typeof(uint)] = new ObjectCast(ObjectCasters.uintCaster);
			this.castersMap[typeof(long)] = new ObjectCast(ObjectCasters.longCaster);
			this.castersMap[typeof(ulong)] = new ObjectCast(ObjectCasters.ulongCaster);
			this.castersMap[typeof(double)] = new ObjectCast(ObjectCasters.getDouble);
			this.castersMap[typeof(float)] = new ObjectCast(ObjectCasters.floatCaster);
			this.castersMap[typeof(decimal)] = new ObjectCast(this.decimalCaster);
			this.castersMap[typeof(bool)] = new ObjectCast(ObjectCasters.getBoolean);
			this.castersMap[typeof(string)] = new ObjectCast(ObjectCasters.getString);
			this.castersMap[typeof(object)] = new ObjectCast(this.getObject);
			this.castersMap[typeof(byte[])] = new ObjectCast(this.getBytes);
			this.castersMap[typeof(IntPtr)] = new ObjectCast(this.getIntptr);
			this.castersMap[typeof(LuaTable)] = new ObjectCast(this.getLuaTable);
			this.castersMap[typeof(LuaFunction)] = new ObjectCast(this.getLuaFunction);
		}

		private static object charCaster(IntPtr L, int idx, object target)
		{
			return (char)Lua.xlua_tointeger(L, idx);
		}

		private static object sbyteCaster(IntPtr L, int idx, object target)
		{
			return (sbyte)Lua.xlua_tointeger(L, idx);
		}

		private static object byteCaster(IntPtr L, int idx, object target)
		{
			return (byte)Lua.xlua_tointeger(L, idx);
		}

		private static object shortCaster(IntPtr L, int idx, object target)
		{
			return (short)Lua.xlua_tointeger(L, idx);
		}

		private static object ushortCaster(IntPtr L, int idx, object target)
		{
			return (ushort)Lua.xlua_tointeger(L, idx);
		}

		private static object intCaster(IntPtr L, int idx, object target)
		{
			return Lua.xlua_tointeger(L, idx);
		}

		private static object uintCaster(IntPtr L, int idx, object target)
		{
			return Lua.xlua_touint(L, idx);
		}

		private static object longCaster(IntPtr L, int idx, object target)
		{
			return Lua.lua_toint64(L, idx);
		}

		private static object ulongCaster(IntPtr L, int idx, object target)
		{
			return Lua.lua_touint64(L, idx);
		}

		private static object getDouble(IntPtr L, int idx, object target)
		{
			return Lua.lua_tonumber(L, idx);
		}

		private static object floatCaster(IntPtr L, int idx, object target)
		{
			return (float)Lua.lua_tonumber(L, idx);
		}

		private object decimalCaster(IntPtr L, int idx, object target)
		{
			decimal num;
			this.translator.Get(L, idx, out num);
			return num;
		}

		private static object getBoolean(IntPtr L, int idx, object target)
		{
			return Lua.lua_toboolean(L, idx);
		}

		private static object getString(IntPtr L, int idx, object target)
		{
			return Lua.lua_tostring(L, idx);
		}

		private object getBytes(IntPtr L, int idx, object target)
		{
			if (Lua.lua_type(L, idx) != LuaTypes.LUA_TSTRING)
			{
				return this.translator.SafeGetCSObj(L, idx) as byte[];
			}
			return Lua.lua_tobytes(L, idx);
		}

		private object getIntptr(IntPtr L, int idx, object target)
		{
			return Lua.lua_touserdata(L, idx);
		}

		private object getObject(IntPtr L, int idx, object target)
		{
			switch (Lua.lua_type(L, idx))
			{
			case LuaTypes.LUA_TBOOLEAN:
				return Lua.lua_toboolean(L, idx);
			case LuaTypes.LUA_TNUMBER:
				if (Lua.lua_isint64(L, idx))
				{
					return Lua.lua_toint64(L, idx);
				}
				if (Lua.lua_isinteger(L, idx))
				{
					return Lua.xlua_tointeger(L, idx);
				}
				return Lua.lua_tonumber(L, idx);
			case LuaTypes.LUA_TSTRING:
				return Lua.lua_tostring(L, idx);
			case LuaTypes.LUA_TTABLE:
				return this.getLuaTable(L, idx, null);
			case LuaTypes.LUA_TFUNCTION:
				return this.getLuaFunction(L, idx, null);
			case LuaTypes.LUA_TUSERDATA:
			{
				if (Lua.lua_isint64(L, idx))
				{
					return Lua.lua_toint64(L, idx);
				}
				if (Lua.lua_isuint64(L, idx))
				{
					return Lua.lua_touint64(L, idx);
				}
				object obj = this.translator.SafeGetCSObj(L, idx);
				if (!(obj is RawObject))
				{
					return obj;
				}
				return (obj as RawObject).Target;
			}
			}
			return null;
		}

		private object getLuaTable(IntPtr L, int idx, object target)
		{
			if (Lua.lua_type(L, idx) == LuaTypes.LUA_TUSERDATA)
			{
				object obj = this.translator.SafeGetCSObj(L, idx);
				if (obj == null || !(obj is LuaTable))
				{
					return null;
				}
				return obj;
			}
			else
			{
				if (!Lua.lua_istable(L, idx))
				{
					return null;
				}
				Lua.lua_pushvalue(L, idx);
				return new LuaTable(Lua.luaL_ref(L), this.translator.luaEnv);
			}
		}

		private object getLuaFunction(IntPtr L, int idx, object target)
		{
			if (Lua.lua_type(L, idx) == LuaTypes.LUA_TUSERDATA)
			{
				object obj = this.translator.SafeGetCSObj(L, idx);
				if (obj == null || !(obj is LuaFunction))
				{
					return null;
				}
				return obj;
			}
			else
			{
				if (!Lua.lua_isfunction(L, idx))
				{
					return null;
				}
				Lua.lua_pushvalue(L, idx);
				return new LuaFunction(Lua.luaL_ref(L), this.translator.luaEnv);
			}
		}

		public void AddCaster(Type type, ObjectCast oc)
		{
			this.castersMap[type] = oc;
		}

		private ObjectCast genCaster(Type type)
		{
			ObjectCast fixTypeGetter = delegate(IntPtr L, int idx, object target)
			{
				if (Lua.lua_type(L, idx) != LuaTypes.LUA_TUSERDATA)
				{
					return null;
				}
				object obj = this.translator.SafeGetCSObj(L, idx);
				if (obj == null || !type.IsAssignableFrom(obj.GetType()))
				{
					return null;
				}
				return obj;
			};
			if (typeof(Delegate).IsAssignableFrom(type))
			{
				return delegate(IntPtr L, int idx, object target)
				{
					object obj = fixTypeGetter(L, idx, target);
					if (obj != null)
					{
						return obj;
					}
					if (!Lua.lua_isfunction(L, idx))
					{
						return null;
					}
					return this.translator.CreateDelegateBridge(L, type, idx);
				};
			}
			if (typeof(DelegateBridgeBase).IsAssignableFrom(type))
			{
				return delegate(IntPtr L, int idx, object target)
				{
					object obj = fixTypeGetter(L, idx, target);
					if (obj != null)
					{
						return obj;
					}
					if (!Lua.lua_isfunction(L, idx))
					{
						return null;
					}
					return this.translator.CreateDelegateBridge(L, null, idx);
				};
			}
			if (type.IsInterface())
			{
				return delegate(IntPtr L, int idx, object target)
				{
					object obj = fixTypeGetter(L, idx, target);
					if (obj != null)
					{
						return obj;
					}
					if (!Lua.lua_istable(L, idx))
					{
						return null;
					}
					return this.translator.CreateInterfaceBridge(L, type, idx);
				};
			}
			if (type.IsEnum())
			{
				return delegate(IntPtr L, int idx, object target)
				{
					object obj = fixTypeGetter(L, idx, target);
					if (obj != null)
					{
						return obj;
					}
					LuaTypes luaTypes = Lua.lua_type(L, idx);
					if (luaTypes == LuaTypes.LUA_TSTRING)
					{
						return Enum.Parse(type, Lua.lua_tostring(L, idx));
					}
					if (luaTypes == LuaTypes.LUA_TNUMBER)
					{
						return Enum.ToObject(type, Lua.xlua_tointeger(L, idx));
					}
					string str = "invalid value for enum ";
					Type type2 = type;
					throw new InvalidCastException(str + ((type2 != null) ? type2.ToString() : null));
				};
			}
			if (type.IsArray)
			{
				return delegate(IntPtr L, int idx, object target)
				{
					object obj = fixTypeGetter(L, idx, target);
					if (obj != null)
					{
						return obj;
					}
					if (!Lua.lua_istable(L, idx))
					{
						return null;
					}
					uint num = Lua.xlua_objlen(L, idx);
					int num2 = Lua.lua_gettop(L);
					idx = ((idx > 0) ? idx : (Lua.lua_gettop(L) + idx + 1));
					Type elementType = type.GetElementType();
					ObjectCast caster = this.GetCaster(elementType);
					Array array = (target == null) ? Array.CreateInstance(elementType, (int)num) : (target as Array);
					if (!Lua.lua_checkstack(L, 1))
					{
						throw new Exception("stack overflow while cast to Array");
					}
					int num3 = 0;
					while ((long)num3 < (long)((ulong)num))
					{
						Lua.lua_pushnumber(L, (double)(num3 + 1));
						Lua.lua_rawget(L, idx);
						if (elementType.IsPrimitive())
						{
							if (!StaticLuaCallbacks.TryPrimitiveArraySet(type, L, array, num3, num2 + 1))
							{
								array.SetValue(caster(L, num2 + 1, null), num3);
							}
						}
						else if (InternalGlobals.genTryArraySetPtr == null || !InternalGlobals.genTryArraySetPtr(type, L, this.translator, array, num3, num2 + 1))
						{
							array.SetValue(caster(L, num2 + 1, null), num3);
						}
						Lua.lua_pop(L, 1);
						num3++;
					}
					return array;
				};
			}
			if (typeof(IList).IsAssignableFrom(type) && type.IsGenericType())
			{
				Type elementType = type.GetGenericArguments()[0];
				ObjectCast elementCaster = this.GetCaster(elementType);
				return delegate(IntPtr L, int idx, object target)
				{
					object obj = fixTypeGetter(L, idx, target);
					if (obj != null)
					{
						return obj;
					}
					if (!Lua.lua_istable(L, idx))
					{
						return null;
					}
					obj = ((target == null) ? Activator.CreateInstance(type) : target);
					int num = Lua.lua_gettop(L);
					idx = ((idx > 0) ? idx : (Lua.lua_gettop(L) + idx + 1));
					IList list = obj as IList;
					uint num2 = Lua.xlua_objlen(L, idx);
					if (!Lua.lua_checkstack(L, 1))
					{
						throw new Exception("stack overflow while cast to IList");
					}
					int num3 = 0;
					while ((long)num3 < (long)((ulong)num2))
					{
						Lua.lua_pushnumber(L, (double)(num3 + 1));
						Lua.lua_rawget(L, idx);
						if (num3 < list.Count && target != null)
						{
							if (this.translator.Assignable(L, num + 1, elementType))
							{
								list[num3] = elementCaster(L, num + 1, list[num3]);
							}
						}
						else if (this.translator.Assignable(L, num + 1, elementType))
						{
							list.Add(elementCaster(L, num + 1, null));
						}
						Lua.lua_pop(L, 1);
						num3++;
					}
					return obj;
				};
			}
			if (typeof(IDictionary).IsAssignableFrom(type) && type.IsGenericType())
			{
				Type keyType = type.GetGenericArguments()[0];
				ObjectCast keyCaster = this.GetCaster(keyType);
				Type valueType = type.GetGenericArguments()[1];
				ObjectCast valueCaster = this.GetCaster(valueType);
				return delegate(IntPtr L, int idx, object target)
				{
					object obj = fixTypeGetter(L, idx, target);
					if (obj != null)
					{
						return obj;
					}
					if (!Lua.lua_istable(L, idx))
					{
						return null;
					}
					IDictionary dictionary = ((target == null) ? Activator.CreateInstance(type) : target) as IDictionary;
					int num = Lua.lua_gettop(L);
					idx = ((idx > 0) ? idx : (Lua.lua_gettop(L) + idx + 1));
					Lua.lua_pushnil(L);
					if (!Lua.lua_checkstack(L, 1))
					{
						throw new Exception("stack overflow while cast to IDictionary");
					}
					while (Lua.lua_next(L, idx) != 0)
					{
						if (this.translator.Assignable(L, num + 1, keyType) && this.translator.Assignable(L, num + 2, valueType))
						{
							object key = keyCaster(L, num + 1, null);
							dictionary[key] = valueCaster(L, num + 2, (!dictionary.Contains(key)) ? null : dictionary[key]);
						}
						Lua.lua_pop(L, 1);
					}
					return dictionary;
				};
			}
			if ((type.IsClass() && type.GetConstructor(Type.EmptyTypes) != null) || (type.IsValueType() && !type.IsEnum()))
			{
				return delegate(IntPtr L, int idx, object target)
				{
					object obj = fixTypeGetter(L, idx, target);
					if (obj != null)
					{
						return obj;
					}
					if (!Lua.lua_istable(L, idx))
					{
						return null;
					}
					obj = ((target == null) ? Activator.CreateInstance(type) : target);
					int num = Lua.lua_gettop(L);
					idx = ((idx > 0) ? idx : (Lua.lua_gettop(L) + idx + 1));
					if (!Lua.lua_checkstack(L, 1))
					{
						string str = "stack overflow while cast to ";
						Type type2 = type;
						throw new Exception(str + ((type2 != null) ? type2.ToString() : null));
					}
					foreach (FieldInfo fieldInfo in type.GetFields())
					{
						Lua.xlua_pushasciistring(L, fieldInfo.Name);
						Lua.lua_rawget(L, idx);
						if (!Lua.lua_isnil(L, -1))
						{
							try
							{
								fieldInfo.SetValue(obj, this.GetCaster(fieldInfo.FieldType)(L, num + 1, (target == null || fieldInfo.FieldType.IsPrimitive() || fieldInfo.FieldType == typeof(string)) ? null : fieldInfo.GetValue(obj)));
							}
							catch (Exception ex)
							{
								throw new Exception("exception in tran " + fieldInfo.Name + ", msg=" + ex.Message);
							}
						}
						Lua.lua_pop(L, 1);
					}
					return obj;
				};
			}
			return fixTypeGetter;
		}

		private ObjectCast genNullableCaster(ObjectCast oc)
		{
			return delegate(IntPtr L, int idx, object target)
			{
				if (Lua.lua_isnil(L, idx))
				{
					return null;
				}
				return oc(L, idx, target);
			};
		}

		public ObjectCast GetCaster(Type type)
		{
			if (type.IsByRef)
			{
				type = type.GetElementType();
			}
			Type underlyingType = Nullable.GetUnderlyingType(type);
			if (underlyingType != null)
			{
				return this.genNullableCaster(this.GetCaster(underlyingType));
			}
			ObjectCast objectCast;
			if (!this.castersMap.TryGetValue(type, out objectCast))
			{
				objectCast = this.genCaster(type);
				this.castersMap.Add(type, objectCast);
			}
			return objectCast;
		}

		private Dictionary<Type, ObjectCast> castersMap = new Dictionary<Type, ObjectCast>();

		private ObjectTranslator translator;
	}
}
