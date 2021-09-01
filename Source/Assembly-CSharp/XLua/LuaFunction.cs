using System;
using XLua.LuaDLL;

namespace XLua
{
	public class LuaFunction : LuaBase
	{
		public LuaFunction(int reference, LuaEnv luaenv) : base(reference, luaenv)
		{
		}

		public void Action<T>(T a)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int num = Lua.lua_gettop(l);
				int errfunc = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				translator.PushByType<T>(l, a);
				if (Lua.lua_pcall(l, 1, 0, errfunc) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num);
				}
				Lua.lua_settop(l, num);
			}
		}

		public TResult Func<T, TResult>(T a)
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
				translator.PushByType<T>(l, a);
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

		public void Action<T1, T2>(T1 a1, T2 a2)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int num = Lua.lua_gettop(l);
				int errfunc = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				translator.PushByType<T1>(l, a1);
				translator.PushByType<T2>(l, a2);
				if (Lua.lua_pcall(l, 2, 0, errfunc) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num);
				}
				Lua.lua_settop(l, num);
			}
		}

		public TResult Func<T1, T2, TResult>(T1 a1, T2 a2)
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
				translator.PushByType<T1>(l, a1);
				translator.PushByType<T2>(l, a2);
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

		public object[] Call(object[] args, Type[] returnTypes)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			object[] result;
			lock (luaEnvLock)
			{
				int nArgs = 0;
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int oldTop = Lua.lua_gettop(l);
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				if (args != null)
				{
					nArgs = args.Length;
					for (int i = 0; i < args.Length; i++)
					{
						translator.PushAny(l, args[i]);
					}
				}
				if (Lua.lua_pcall(l, nArgs, -1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(oldTop);
				}
				Lua.lua_remove(l, num);
				if (returnTypes != null)
				{
					result = translator.popValues(l, oldTop, returnTypes);
				}
				else
				{
					result = translator.popValues(l, oldTop);
				}
			}
			return result;
		}

		public object[] Call(params object[] args)
		{
			return this.Call(args, null);
		}

		public T Cast<T>()
		{
			if (!typeof(T).IsSubclassOf(typeof(Delegate)))
			{
				throw new InvalidOperationException(typeof(T).Name + " is not a delegate type");
			}
			object luaEnvLock = this.luaEnv.luaEnvLock;
			T result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				this.push(l);
				T t = (T)((object)translator.GetObject(l, -1, typeof(T)));
				Lua.lua_pop(this.luaEnv.L, 1);
				result = t;
			}
			return result;
		}

		public void SetEnv(LuaTable env)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int newTop = Lua.lua_gettop(l);
				this.push(l);
				env.push(l);
				Lua.lua_setfenv(l, -2);
				Lua.lua_settop(l, newTop);
			}
		}

		internal override void push(IntPtr L)
		{
			Lua.lua_getref(L, this.luaReference);
		}

		public override string ToString()
		{
			return "function :" + this.luaReference.ToString();
		}
	}
}
