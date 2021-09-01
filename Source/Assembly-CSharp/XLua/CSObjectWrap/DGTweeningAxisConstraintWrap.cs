using System;
using DG.Tweening;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningAxisConstraintWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(AxisConstraint), L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeof(AxisConstraint), L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeof(AxisConstraint), L, null, 6, 0, 0);
			Utils.RegisterObject(L, translator, -4, "None", AxisConstraint.None);
			Utils.RegisterObject(L, translator, -4, "X", AxisConstraint.X);
			Utils.RegisterObject(L, translator, -4, "Y", AxisConstraint.Y);
			Utils.RegisterObject(L, translator, -4, "Z", AxisConstraint.Z);
			Utils.RegisterObject(L, translator, -4, "W", AxisConstraint.W);
			Utils.RegisterFunc(L, -4, "__CastFrom", new lua_CSFunction(DGTweeningAxisConstraintWrap.__CastFrom));
			Utils.EndClassRegister(typeof(AxisConstraint), L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CastFrom(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes luaTypes = Lua.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TNUMBER)
			{
				objectTranslator.PushDGTweeningAxisConstraint(L, (AxisConstraint)Lua.xlua_tointeger(L, 1));
			}
			else
			{
				if (luaTypes != LuaTypes.LUA_TSTRING)
				{
					return Lua.luaL_error(L, "invalid lua type for DG.Tweening.AxisConstraint! Expect number or string, got + " + luaTypes.ToString());
				}
				if (Lua.xlua_is_eq_str(L, 1, "None"))
				{
					objectTranslator.PushDGTweeningAxisConstraint(L, AxisConstraint.None);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "X"))
				{
					objectTranslator.PushDGTweeningAxisConstraint(L, AxisConstraint.X);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "Y"))
				{
					objectTranslator.PushDGTweeningAxisConstraint(L, AxisConstraint.Y);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "Z"))
				{
					objectTranslator.PushDGTweeningAxisConstraint(L, AxisConstraint.Z);
				}
				else
				{
					if (!Lua.xlua_is_eq_str(L, 1, "W"))
					{
						return Lua.luaL_error(L, "invalid string for DG.Tweening.AxisConstraint!");
					}
					objectTranslator.PushDGTweeningAxisConstraint(L, AxisConstraint.W);
				}
			}
			return 1;
		}
	}
}
