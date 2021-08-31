using System;
using System.Collections.Generic;

namespace XLua
{
	public abstract class DelegateBridgeBase : LuaBase
	{
		public DelegateBridgeBase(int reference, LuaEnv luaenv) : base(reference, luaenv)
		{
			this.errorFuncRef = luaenv.errorFuncRef;
		}

		public bool TryGetDelegate(Type key, out Delegate value)
		{
			if (key == this.firstKey)
			{
				value = this.firstValue;
				return true;
			}
			if (this.bindTo != null)
			{
				return this.bindTo.TryGetValue(key, out value);
			}
			value = null;
			return false;
		}

		public void AddDelegate(Type key, Delegate value)
		{
			if (key == this.firstKey)
			{
				throw new ArgumentException("An element with the same key already exists in the dictionary.");
			}
			if (this.firstKey == null && this.bindTo == null)
			{
				this.firstKey = key;
				this.firstValue = value;
				return;
			}
			if (this.firstKey != null && this.bindTo == null)
			{
				this.bindTo = new Dictionary<Type, Delegate>();
				this.bindTo.Add(this.firstKey, this.firstValue);
				this.firstKey = null;
				this.firstValue = null;
				this.bindTo.Add(key, value);
				return;
			}
			this.bindTo.Add(key, value);
		}

		public virtual Delegate GetDelegateByType(Type type)
		{
			return null;
		}

		private Type firstKey;

		private Delegate firstValue;

		private Dictionary<Type, Delegate> bindTo;

		protected int errorFuncRef;
	}
}
