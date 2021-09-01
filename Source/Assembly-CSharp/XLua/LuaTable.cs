using System;
using System.Collections;
using System.Collections.Generic;
using XLua.LuaDLL;

namespace XLua
{
	public class LuaTable : LuaBase
	{
		public LuaTable(int reference, LuaEnv luaenv) : base(reference, luaenv)
		{
		}

		public void Get<TKey, TValue>(TKey key, out TValue value)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int newTop = Lua.lua_gettop(l);
				Lua.lua_getref(l, this.luaReference);
				translator.PushByType<TKey>(l, key);
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					string str = Lua.lua_tostring(l, -1);
					Lua.lua_settop(l, newTop);
					string str2 = "get field [";
					TKey tkey = key;
					throw new Exception(str2 + ((tkey != null) ? tkey.ToString() : null) + "] error:" + str);
				}
				bool flag2 = Lua.lua_type(l, -1) != LuaTypes.LUA_TNIL;
				Type typeFromHandle = typeof(TValue);
				if (!flag2 && typeFromHandle.IsValueType())
				{
					throw new InvalidCastException("can not assign nil to " + typeFromHandle.GetFriendlyName());
				}
				try
				{
					translator.Get<TValue>(l, -1, out value);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					Lua.lua_settop(l, newTop);
				}
			}
		}

		public bool ContainsKey<TKey>(TKey key)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			bool result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int newTop = Lua.lua_gettop(l);
				Lua.lua_getref(l, this.luaReference);
				translator.PushByType<TKey>(l, key);
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					string str = Lua.lua_tostring(l, -1);
					Lua.lua_settop(l, newTop);
					string str2 = "get field [";
					TKey tkey = key;
					throw new Exception(str2 + ((tkey != null) ? tkey.ToString() : null) + "] error:" + str);
				}
				bool flag2 = Lua.lua_type(l, -1) > LuaTypes.LUA_TNIL;
				Lua.lua_settop(l, newTop);
				result = flag2;
			}
			return result;
		}

		public void Set<TKey, TValue>(TKey key, TValue value)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.lua_gettop(l);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				translator.PushByType<TKey>(l, key);
				translator.PushByType<TValue>(l, value);
				if (Lua.xlua_psettable(l, -3) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num);
				}
				Lua.lua_settop(l, num);
			}
		}

		public T GetInPath<T>(string path)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			T result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int num = Lua.lua_gettop(l);
				Lua.lua_getref(l, this.luaReference);
				if (Lua.xlua_pgettable_bypath(l, -1, path) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num);
				}
				if (Lua.lua_type(l, -1) == LuaTypes.LUA_TNIL && typeof(T).IsValueType())
				{
					throw new InvalidCastException("can not assign nil to " + typeof(T).GetFriendlyName());
				}
				T t;
				try
				{
					translator.Get<T>(l, -1, out t);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					Lua.lua_settop(l, num);
				}
				result = t;
			}
			return result;
		}

		public void SetInPath<T>(string path, T val)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.lua_gettop(l);
				Lua.lua_getref(l, this.luaReference);
				this.luaEnv.translator.PushByType<T>(l, val);
				if (Lua.xlua_psettable_bypath(l, -2, path) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num);
				}
				Lua.lua_settop(l, num);
			}
		}

		[Obsolete("use no boxing version: GetInPath/SetInPath Get/Set instead!")]
		public object this[string field]
		{
			get
			{
				return this.GetInPath<object>(field);
			}
			set
			{
				this.SetInPath<object>(field, value);
			}
		}

		[Obsolete("use no boxing version: GetInPath/SetInPath Get/Set instead!")]
		public object this[object field]
		{
			get
			{
				return this.Get<object>(field);
			}
			set
			{
				this.Set<object, object>(field, value);
			}
		}

		public void ForEach<TKey, TValue>(Action<TKey, TValue> action)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				ObjectTranslator translator = this.luaEnv.translator;
				int newTop = Lua.lua_gettop(l);
				try
				{
					Lua.lua_getref(l, this.luaReference);
					Lua.lua_pushnil(l);
					while (Lua.lua_next(l, -2) != 0)
					{
						if (translator.Assignable<TKey>(l, -2))
						{
							TKey arg;
							translator.Get<TKey>(l, -2, out arg);
							TValue arg2;
							translator.Get<TValue>(l, -1, out arg2);
							action(arg, arg2);
						}
						Lua.lua_pop(l, 1);
					}
				}
				finally
				{
					Lua.lua_settop(l, newTop);
				}
			}
		}

		public int Length
		{
			get
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				int result;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int newTop = Lua.lua_gettop(l);
					Lua.lua_getref(l, this.luaReference);
					int num = (int)Lua.xlua_objlen(l, -1);
					Lua.lua_settop(l, newTop);
					result = num;
				}
				return result;
			}
		}

		[Obsolete("not thread safe!", true)]
		public IEnumerable GetKeys()
		{
			IntPtr L = this.luaEnv.L;
			ObjectTranslator translator = this.luaEnv.translator;
			int oldTop = Lua.lua_gettop(L);
			Lua.lua_getref(L, this.luaReference);
			Lua.lua_pushnil(L);
			while (Lua.lua_next(L, -2) != 0)
			{
				yield return translator.GetObject(L, -2);
				Lua.lua_pop(L, 1);
			}
			Lua.lua_settop(L, oldTop);
			yield break;
		}

		[Obsolete("not thread safe!", true)]
		public IEnumerable<T> GetKeys<T>()
		{
			IntPtr L = this.luaEnv.L;
			ObjectTranslator translator = this.luaEnv.translator;
			int oldTop = Lua.lua_gettop(L);
			Lua.lua_getref(L, this.luaReference);
			Lua.lua_pushnil(L);
			while (Lua.lua_next(L, -2) != 0)
			{
				if (translator.Assignable<T>(L, -2))
				{
					T t;
					translator.Get<T>(L, -2, out t);
					yield return t;
				}
				Lua.lua_pop(L, 1);
			}
			Lua.lua_settop(L, oldTop);
			yield break;
		}

		[Obsolete("use no boxing version: Get<TKey, TValue> !")]
		public T Get<T>(object key)
		{
			T result;
			this.Get<object, T>(key, out result);
			return result;
		}

		public TValue Get<TKey, TValue>(TKey key)
		{
			TValue result;
			this.Get<TKey, TValue>(key, out result);
			return result;
		}

		public TValue Get<TValue>(string key)
		{
			TValue result;
			this.Get<string, TValue>(key, out result);
			return result;
		}

		public void SetMetaTable(LuaTable metaTable)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				this.push(this.luaEnv.L);
				metaTable.push(this.luaEnv.L);
				Lua.lua_setmetatable(this.luaEnv.L, -2);
				Lua.lua_pop(this.luaEnv.L, 1);
			}
		}

		public T Cast<T>()
		{
			IntPtr l = this.luaEnv.L;
			ObjectTranslator translator = this.luaEnv.translator;
			object luaEnvLock = this.luaEnv.luaEnvLock;
			T result;
			lock (luaEnvLock)
			{
				this.push(l);
				T t = (T)((object)translator.GetObject(l, -1, typeof(T)));
				Lua.lua_pop(this.luaEnv.L, 1);
				result = t;
			}
			return result;
		}

		internal override void push(IntPtr L)
		{
			Lua.lua_getref(L, this.luaReference);
		}

		public override string ToString()
		{
			return "table :" + this.luaReference.ToString();
		}
	}
}
