using System;
using System.Collections.Generic;
using XLua.LuaDLL;

namespace XLua
{
	public class ObjectCheckers
	{
		public ObjectCheckers(ObjectTranslator translator)
		{
			this.translator = translator;
			this.checkersMap[typeof(sbyte)] = new ObjectCheck(this.numberCheck);
			this.checkersMap[typeof(byte)] = new ObjectCheck(this.numberCheck);
			this.checkersMap[typeof(short)] = new ObjectCheck(this.numberCheck);
			this.checkersMap[typeof(ushort)] = new ObjectCheck(this.numberCheck);
			this.checkersMap[typeof(int)] = new ObjectCheck(this.numberCheck);
			this.checkersMap[typeof(uint)] = new ObjectCheck(this.numberCheck);
			this.checkersMap[typeof(long)] = new ObjectCheck(this.int64Check);
			this.checkersMap[typeof(ulong)] = new ObjectCheck(this.uint64Check);
			this.checkersMap[typeof(double)] = new ObjectCheck(this.numberCheck);
			this.checkersMap[typeof(char)] = new ObjectCheck(this.numberCheck);
			this.checkersMap[typeof(float)] = new ObjectCheck(this.numberCheck);
			this.checkersMap[typeof(decimal)] = new ObjectCheck(this.decimalCheck);
			this.checkersMap[typeof(bool)] = new ObjectCheck(this.boolCheck);
			this.checkersMap[typeof(string)] = new ObjectCheck(this.strCheck);
			this.checkersMap[typeof(object)] = new ObjectCheck(ObjectCheckers.objectCheck);
			this.checkersMap[typeof(byte[])] = new ObjectCheck(this.bytesCheck);
			this.checkersMap[typeof(IntPtr)] = new ObjectCheck(this.intptrCheck);
			this.checkersMap[typeof(LuaTable)] = new ObjectCheck(this.luaTableCheck);
			this.checkersMap[typeof(LuaFunction)] = new ObjectCheck(this.luaFunctionCheck);
		}

		private static bool objectCheck(IntPtr L, int idx)
		{
			return true;
		}

		private bool luaTableCheck(IntPtr L, int idx)
		{
			return Lua.lua_isnil(L, idx) || Lua.lua_istable(L, idx) || (Lua.lua_type(L, idx) == LuaTypes.LUA_TUSERDATA && this.translator.SafeGetCSObj(L, idx) is LuaTable);
		}

		private bool numberCheck(IntPtr L, int idx)
		{
			return Lua.lua_type(L, idx) == LuaTypes.LUA_TNUMBER;
		}

		private bool decimalCheck(IntPtr L, int idx)
		{
			return Lua.lua_type(L, idx) == LuaTypes.LUA_TNUMBER || this.translator.IsDecimal(L, idx);
		}

		private bool strCheck(IntPtr L, int idx)
		{
			return Lua.lua_type(L, idx) == LuaTypes.LUA_TSTRING || Lua.lua_isnil(L, idx);
		}

		private bool bytesCheck(IntPtr L, int idx)
		{
			return Lua.lua_type(L, idx) == LuaTypes.LUA_TSTRING || Lua.lua_isnil(L, idx) || (Lua.lua_type(L, idx) == LuaTypes.LUA_TUSERDATA && this.translator.SafeGetCSObj(L, idx) is byte[]);
		}

		private bool boolCheck(IntPtr L, int idx)
		{
			return Lua.lua_type(L, idx) == LuaTypes.LUA_TBOOLEAN;
		}

		private bool int64Check(IntPtr L, int idx)
		{
			return Lua.lua_type(L, idx) == LuaTypes.LUA_TNUMBER || Lua.lua_isint64(L, idx);
		}

		private bool uint64Check(IntPtr L, int idx)
		{
			return Lua.lua_type(L, idx) == LuaTypes.LUA_TNUMBER || Lua.lua_isuint64(L, idx);
		}

		private bool luaFunctionCheck(IntPtr L, int idx)
		{
			return Lua.lua_isnil(L, idx) || Lua.lua_isfunction(L, idx) || (Lua.lua_type(L, idx) == LuaTypes.LUA_TUSERDATA && this.translator.SafeGetCSObj(L, idx) is LuaFunction);
		}

		private bool intptrCheck(IntPtr L, int idx)
		{
			return Lua.lua_type(L, idx) == LuaTypes.LUA_TLIGHTUSERDATA;
		}

		private ObjectCheck genChecker(Type type)
		{
			ObjectCheck fixTypeCheck = delegate(IntPtr L, int idx)
			{
				if (Lua.lua_type(L, idx) == LuaTypes.LUA_TUSERDATA)
				{
					object obj = this.translator.SafeGetCSObj(L, idx);
					if (obj != null)
					{
						return type.IsAssignableFrom(obj.GetType());
					}
					Type typeOf = this.translator.GetTypeOf(L, idx);
					if (typeOf != null)
					{
						return type.IsAssignableFrom(typeOf);
					}
				}
				return false;
			};
			if (!type.IsAbstract() && typeof(Delegate).IsAssignableFrom(type))
			{
				return (IntPtr L, int idx) => Lua.lua_isnil(L, idx) || Lua.lua_isfunction(L, idx) || fixTypeCheck(L, idx);
			}
			if (type.IsEnum())
			{
				return fixTypeCheck;
			}
			if (type.IsInterface())
			{
				return (IntPtr L, int idx) => Lua.lua_isnil(L, idx) || Lua.lua_istable(L, idx) || fixTypeCheck(L, idx);
			}
			if (type.IsClass() && type.GetConstructor(Type.EmptyTypes) != null)
			{
				return (IntPtr L, int idx) => Lua.lua_isnil(L, idx) || Lua.lua_istable(L, idx) || fixTypeCheck(L, idx);
			}
			if (type.IsValueType())
			{
				return (IntPtr L, int idx) => Lua.lua_istable(L, idx) || fixTypeCheck(L, idx);
			}
			if (type.IsArray)
			{
				return (IntPtr L, int idx) => Lua.lua_isnil(L, idx) || Lua.lua_istable(L, idx) || fixTypeCheck(L, idx);
			}
			return (IntPtr L, int idx) => Lua.lua_isnil(L, idx) || fixTypeCheck(L, idx);
		}

		public ObjectCheck genNullableChecker(ObjectCheck oc)
		{
			return (IntPtr L, int idx) => Lua.lua_isnil(L, idx) || oc(L, idx);
		}

		public ObjectCheck GetChecker(Type type)
		{
			if (type.IsByRef)
			{
				type = type.GetElementType();
			}
			Type underlyingType = Nullable.GetUnderlyingType(type);
			if (underlyingType != null)
			{
				return this.genNullableChecker(this.GetChecker(underlyingType));
			}
			ObjectCheck objectCheck;
			if (!this.checkersMap.TryGetValue(type, out objectCheck))
			{
				objectCheck = this.genChecker(type);
				this.checkersMap.Add(type, objectCheck);
			}
			return objectCheck;
		}

		private Dictionary<Type, ObjectCheck> checkersMap = new Dictionary<Type, ObjectCheck>();

		private ObjectTranslator translator;
	}
}
