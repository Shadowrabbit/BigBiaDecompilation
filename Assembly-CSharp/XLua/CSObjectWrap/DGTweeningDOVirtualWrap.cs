using System;
using DG.Tweening;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningDOVirtualWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(DOVirtual);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(DGTweeningDOVirtualWrap.__CreateInstance), 4, 0, 0);
			Utils.RegisterFunc(L, -4, "Float", new lua_CSFunction(DGTweeningDOVirtualWrap._m_Float_xlua_st_));
			Utils.RegisterFunc(L, -4, "EasedValue", new lua_CSFunction(DGTweeningDOVirtualWrap._m_EasedValue_xlua_st_));
			Utils.RegisterFunc(L, -4, "DelayedCall", new lua_CSFunction(DGTweeningDOVirtualWrap._m_DelayedCall_xlua_st_));
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			return Lua.luaL_error(L, "DG.Tweening.DOVirtual does not have a constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Float_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				float from = (float)Lua.lua_tonumber(L, 1);
				float to = (float)Lua.lua_tonumber(L, 2);
				float duration = (float)Lua.lua_tonumber(L, 3);
				TweenCallback<float> @delegate = objectTranslator.GetDelegate<TweenCallback<float>>(L, 4);
				Tweener o = DOVirtual.Float(from, to, duration, @delegate);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_EasedValue_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<Ease>(L, 4))
				{
					float from = (float)Lua.lua_tonumber(L, 1);
					float to = (float)Lua.lua_tonumber(L, 2);
					float lifetimePercentage = (float)Lua.lua_tonumber(L, 3);
					Ease easeType;
					objectTranslator.Get(L, 4, out easeType);
					float num2 = DOVirtual.EasedValue(from, to, lifetimePercentage, easeType);
					Lua.lua_pushnumber(L, (double)num2);
					return 1;
				}
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<AnimationCurve>(L, 4))
				{
					float from2 = (float)Lua.lua_tonumber(L, 1);
					float to2 = (float)Lua.lua_tonumber(L, 2);
					float lifetimePercentage2 = (float)Lua.lua_tonumber(L, 3);
					AnimationCurve easeCurve = (AnimationCurve)objectTranslator.GetObject(L, 4, typeof(AnimationCurve));
					float num3 = DOVirtual.EasedValue(from2, to2, lifetimePercentage2, easeCurve);
					Lua.lua_pushnumber(L, (double)num3);
					return 1;
				}
				if (num == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<Ease>(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					float from3 = (float)Lua.lua_tonumber(L, 1);
					float to3 = (float)Lua.lua_tonumber(L, 2);
					float lifetimePercentage3 = (float)Lua.lua_tonumber(L, 3);
					Ease easeType2;
					objectTranslator.Get(L, 4, out easeType2);
					float overshoot = (float)Lua.lua_tonumber(L, 5);
					float num4 = DOVirtual.EasedValue(from3, to3, lifetimePercentage3, easeType2, overshoot);
					Lua.lua_pushnumber(L, (double)num4);
					return 1;
				}
				if (num == 6 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<Ease>(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6))
				{
					float from4 = (float)Lua.lua_tonumber(L, 1);
					float to4 = (float)Lua.lua_tonumber(L, 2);
					float lifetimePercentage4 = (float)Lua.lua_tonumber(L, 3);
					Ease easeType3;
					objectTranslator.Get(L, 4, out easeType3);
					float amplitude = (float)Lua.lua_tonumber(L, 5);
					float period = (float)Lua.lua_tonumber(L, 6);
					float num5 = DOVirtual.EasedValue(from4, to4, lifetimePercentage4, easeType3, amplitude, period);
					Lua.lua_pushnumber(L, (double)num5);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOVirtual.EasedValue!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DelayedCall_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && objectTranslator.Assignable<TweenCallback>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					float delay = (float)Lua.lua_tonumber(L, 1);
					TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
					bool ignoreTimeScale = Lua.lua_toboolean(L, 3);
					Tween o = DOVirtual.DelayedCall(delay, @delegate, ignoreTimeScale);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && objectTranslator.Assignable<TweenCallback>(L, 2))
				{
					float delay2 = (float)Lua.lua_tonumber(L, 1);
					TweenCallback delegate2 = objectTranslator.GetDelegate<TweenCallback>(L, 2);
					Tween o2 = DOVirtual.DelayedCall(delay2, delegate2, true);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOVirtual.DelayedCall!");
		}
	}
}
