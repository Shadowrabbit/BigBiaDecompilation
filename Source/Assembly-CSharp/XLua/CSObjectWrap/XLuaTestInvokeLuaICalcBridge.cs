using System;
using XLua.LuaDLL;
using XLuaTest;

namespace XLua.CSObjectWrap
{
	public class XLuaTestInvokeLuaICalcBridge : LuaBase, InvokeLua.ICalc
	{
		public static LuaBase __Create(int reference, LuaEnv luaenv)
		{
			return new XLuaTestInvokeLuaICalcBridge(reference, luaenv);
		}

		public XLuaTestInvokeLuaICalcBridge(int reference, LuaEnv luaenv) : base(reference, luaenv)
		{
		}

		int InvokeLua.ICalc.Add(int a, int b)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			int result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "Add");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function Add");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				Lua.xlua_pushinteger(l, a);
				Lua.xlua_pushinteger(l, b);
				if (Lua.lua_pcall(l, 3, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				int num2 = Lua.xlua_tointeger(l, num + 1);
				Lua.lua_settop(l, num - 1);
				result = num2;
			}
			return result;
		}

		int InvokeLua.ICalc.Mult
		{
			get
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				int result;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int oldTop = Lua.lua_gettop(l);
					Lua.lua_getref(l, this.luaReference);
					Lua.xlua_pushasciistring(l, "Mult");
					if (Lua.xlua_pgettable(l, -2) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(oldTop);
					}
					int num = Lua.xlua_tointeger(l, -1);
					Lua.lua_pop(l, 2);
					result = num;
				}
				return result;
			}
			set
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int oldTop = Lua.lua_gettop(l);
					Lua.lua_getref(l, this.luaReference);
					Lua.xlua_pushasciistring(l, "Mult");
					Lua.xlua_pushinteger(l, value);
					if (Lua.xlua_psettable(l, -3) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(oldTop);
					}
					Lua.lua_pop(l, 1);
				}
			}
		}

		event EventHandler<PropertyChangedEventArgs> InvokeLua.ICalc.PropertyChanged
		{
			add
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
					ObjectTranslator translator = this.luaEnv.translator;
					Lua.lua_getref(l, this.luaReference);
					Lua.xlua_pushasciistring(l, "add_PropertyChanged");
					if (Lua.xlua_pgettable(l, -2) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(num - 1);
					}
					if (!Lua.lua_isfunction(l, -1))
					{
						Lua.xlua_pushasciistring(l, "no such function add_PropertyChanged");
						this.luaEnv.ThrowExceptionFromError(num - 1);
					}
					Lua.lua_pushvalue(l, -2);
					Lua.lua_remove(l, -3);
					translator.Push(l, value);
					if (Lua.lua_pcall(l, 2, 0, num) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(num - 1);
					}
					Lua.lua_settop(l, num - 1);
				}
			}
			remove
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
					ObjectTranslator translator = this.luaEnv.translator;
					Lua.lua_getref(l, this.luaReference);
					Lua.xlua_pushasciistring(l, "remove_PropertyChanged");
					if (Lua.xlua_pgettable(l, -2) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(num - 1);
					}
					if (!Lua.lua_isfunction(l, -1))
					{
						Lua.xlua_pushasciistring(l, "no such function remove_PropertyChanged");
						this.luaEnv.ThrowExceptionFromError(num - 1);
					}
					Lua.lua_pushvalue(l, -2);
					Lua.lua_remove(l, -3);
					translator.Push(l, value);
					if (Lua.lua_pcall(l, 2, 0, num) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(num - 1);
					}
					Lua.lua_settop(l, num - 1);
				}
			}
		}

		object InvokeLua.ICalc.this[int index]
		{
			get
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				object result;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
					ObjectTranslator translator = this.luaEnv.translator;
					Lua.lua_getref(l, this.luaReference);
					Lua.xlua_pushasciistring(l, "get_Item");
					if (Lua.xlua_pgettable(l, -2) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(num - 1);
					}
					if (!Lua.lua_isfunction(l, -1))
					{
						Lua.xlua_pushasciistring(l, "no such function get_Item");
						this.luaEnv.ThrowExceptionFromError(num - 1);
					}
					Lua.lua_pushvalue(l, -2);
					Lua.lua_remove(l, -3);
					Lua.xlua_pushinteger(l, index);
					if (Lua.lua_pcall(l, 2, 1, num) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(num - 1);
					}
					object @object = translator.GetObject(l, num + 1, typeof(object));
					Lua.lua_settop(l, num - 1);
					result = @object;
				}
				return result;
			}
			set
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
					ObjectTranslator translator = this.luaEnv.translator;
					Lua.lua_getref(l, this.luaReference);
					Lua.xlua_pushasciistring(l, "set_Item");
					if (Lua.xlua_pgettable(l, -2) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(num - 1);
					}
					if (!Lua.lua_isfunction(l, -1))
					{
						Lua.xlua_pushasciistring(l, "no such function set_Item");
						this.luaEnv.ThrowExceptionFromError(num - 1);
					}
					Lua.lua_pushvalue(l, -2);
					Lua.lua_remove(l, -3);
					Lua.xlua_pushinteger(l, index);
					translator.PushAny(l, value);
					if (Lua.lua_pcall(l, 3, 0, num) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(num - 1);
					}
					Lua.lua_settop(l, num - 1);
				}
			}
		}
	}
}
