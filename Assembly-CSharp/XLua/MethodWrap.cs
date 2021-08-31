using System;
using System.Collections.Generic;
using System.Reflection;
using XLua.LuaDLL;

namespace XLua
{
	public class MethodWrap
	{
		public MethodWrap(string methodName, List<OverloadMethodWrap> overloads, bool forceCheck)
		{
			this.methodName = methodName;
			this.overloads = overloads;
			this.forceCheck = forceCheck;
		}

		public int Call(IntPtr L)
		{
			int result;
			try
			{
				if (this.overloads.Count == 1 && !this.overloads[0].HasDefalutValue && !this.forceCheck)
				{
					result = this.overloads[0].Call(L);
				}
				else
				{
					for (int i = 0; i < this.overloads.Count; i++)
					{
						OverloadMethodWrap overloadMethodWrap = this.overloads[i];
						if (overloadMethodWrap.Check(L))
						{
							return overloadMethodWrap.Call(L);
						}
					}
					result = Lua.luaL_error(L, "invalid arguments to " + this.methodName);
				}
			}
			catch (TargetInvocationException ex)
			{
				result = Lua.luaL_error(L, "c# exception:" + ex.InnerException.Message + ",stack:" + ex.InnerException.StackTrace);
			}
			catch (Exception ex2)
			{
				result = Lua.luaL_error(L, "c# exception:" + ex2.Message + ",stack:" + ex2.StackTrace);
			}
			return result;
		}

		private string methodName;

		private List<OverloadMethodWrap> overloads = new List<OverloadMethodWrap>();

		private bool forceCheck;
	}
}
