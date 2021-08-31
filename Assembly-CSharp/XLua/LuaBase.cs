using System;
using XLua.LuaDLL;

namespace XLua
{
	public abstract class LuaBase : IDisposable
	{
		public LuaBase(int reference, LuaEnv luaenv)
		{
			this.luaReference = reference;
			this.luaEnv = luaenv;
		}

		~LuaBase()
		{
			this.Dispose(false);
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		public virtual void Dispose(bool disposeManagedResources)
		{
			if (!this.disposed)
			{
				if (this.luaReference != 0)
				{
					object luaEnvLock = this.luaEnv.luaEnvLock;
					lock (luaEnvLock)
					{
						bool flag2 = this is DelegateBridgeBase;
						if (disposeManagedResources)
						{
							this.luaEnv.translator.ReleaseLuaBase(this.luaEnv.L, this.luaReference, flag2);
						}
						else
						{
							this.luaEnv.equeueGCAction(new LuaEnv.GCAction
							{
								Reference = this.luaReference,
								IsDelegate = flag2
							});
						}
					}
				}
				this.disposed = true;
			}
		}

		public override bool Equals(object o)
		{
			if (o != null && base.GetType() == o.GetType())
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				lock (luaEnvLock)
				{
					LuaBase luaBase = (LuaBase)o;
					IntPtr l = this.luaEnv.L;
					if (l != luaBase.luaEnv.L)
					{
						return false;
					}
					int newTop = Lua.lua_gettop(l);
					Lua.lua_getref(l, luaBase.luaReference);
					Lua.lua_getref(l, this.luaReference);
					int num = Lua.lua_rawequal(l, -1, -2);
					Lua.lua_settop(l, newTop);
					return num != 0;
				}
				return false;
			}
			return false;
		}

		public override int GetHashCode()
		{
			Lua.lua_getref(this.luaEnv.L, this.luaReference);
			IntPtr intPtr = Lua.lua_topointer(this.luaEnv.L, -1);
			Lua.lua_pop(this.luaEnv.L, 1);
			return intPtr.ToInt32();
		}

		internal virtual void push(IntPtr L)
		{
			Lua.lua_getref(L, this.luaReference);
		}

		protected bool disposed;

		protected readonly int luaReference;

		protected readonly LuaEnv luaEnv;
	}
}
