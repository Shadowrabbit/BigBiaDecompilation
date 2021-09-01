using System;
using System.Collections.Generic;
using XLua.LuaDLL;

namespace XLua
{
	public class ObjectTranslatorPool
	{
		public static ObjectTranslatorPool Instance
		{
			get
			{
				return InternalGlobals.objectTranslatorPool;
			}
		}

		public void Add(IntPtr L, ObjectTranslator translator)
		{
			lock (this)
			{
				this.lastTranslator = translator;
				IntPtr key = Lua.xlua_gl(L);
				this.lastPtr = key;
				this.translators.Add(key, new WeakReference(translator));
			}
		}

		public ObjectTranslator Find(IntPtr L)
		{
			ObjectTranslator result;
			lock (this)
			{
				IntPtr intPtr = Lua.xlua_gl(L);
				if (this.lastPtr == intPtr)
				{
					result = this.lastTranslator;
				}
				else if (this.translators.ContainsKey(intPtr))
				{
					this.lastPtr = intPtr;
					this.lastTranslator = (this.translators[intPtr].Target as ObjectTranslator);
					result = this.lastTranslator;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		public void Remove(IntPtr L)
		{
			lock (this)
			{
				IntPtr intPtr = Lua.xlua_gl(L);
				if (this.translators.ContainsKey(intPtr))
				{
					if (this.lastPtr == intPtr)
					{
						this.lastPtr = 0;
						this.lastTranslator = null;
					}
					this.translators.Remove(intPtr);
				}
			}
		}

		private Dictionary<IntPtr, WeakReference> translators = new Dictionary<IntPtr, WeakReference>();

		private IntPtr lastPtr;

		private ObjectTranslator lastTranslator;
	}
}
