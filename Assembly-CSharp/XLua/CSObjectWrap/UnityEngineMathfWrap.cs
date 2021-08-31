using System;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineMathfWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Mathf);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineMathfWrap.__CreateInstance), 54, 0, 0);
			Utils.RegisterFunc(L, -4, "ClosestPowerOfTwo", new lua_CSFunction(UnityEngineMathfWrap._m_ClosestPowerOfTwo_xlua_st_));
			Utils.RegisterFunc(L, -4, "IsPowerOfTwo", new lua_CSFunction(UnityEngineMathfWrap._m_IsPowerOfTwo_xlua_st_));
			Utils.RegisterFunc(L, -4, "NextPowerOfTwo", new lua_CSFunction(UnityEngineMathfWrap._m_NextPowerOfTwo_xlua_st_));
			Utils.RegisterFunc(L, -4, "GammaToLinearSpace", new lua_CSFunction(UnityEngineMathfWrap._m_GammaToLinearSpace_xlua_st_));
			Utils.RegisterFunc(L, -4, "LinearToGammaSpace", new lua_CSFunction(UnityEngineMathfWrap._m_LinearToGammaSpace_xlua_st_));
			Utils.RegisterFunc(L, -4, "CorrelatedColorTemperatureToRGB", new lua_CSFunction(UnityEngineMathfWrap._m_CorrelatedColorTemperatureToRGB_xlua_st_));
			Utils.RegisterFunc(L, -4, "FloatToHalf", new lua_CSFunction(UnityEngineMathfWrap._m_FloatToHalf_xlua_st_));
			Utils.RegisterFunc(L, -4, "HalfToFloat", new lua_CSFunction(UnityEngineMathfWrap._m_HalfToFloat_xlua_st_));
			Utils.RegisterFunc(L, -4, "PerlinNoise", new lua_CSFunction(UnityEngineMathfWrap._m_PerlinNoise_xlua_st_));
			Utils.RegisterFunc(L, -4, "Sin", new lua_CSFunction(UnityEngineMathfWrap._m_Sin_xlua_st_));
			Utils.RegisterFunc(L, -4, "Cos", new lua_CSFunction(UnityEngineMathfWrap._m_Cos_xlua_st_));
			Utils.RegisterFunc(L, -4, "Tan", new lua_CSFunction(UnityEngineMathfWrap._m_Tan_xlua_st_));
			Utils.RegisterFunc(L, -4, "Asin", new lua_CSFunction(UnityEngineMathfWrap._m_Asin_xlua_st_));
			Utils.RegisterFunc(L, -4, "Acos", new lua_CSFunction(UnityEngineMathfWrap._m_Acos_xlua_st_));
			Utils.RegisterFunc(L, -4, "Atan", new lua_CSFunction(UnityEngineMathfWrap._m_Atan_xlua_st_));
			Utils.RegisterFunc(L, -4, "Atan2", new lua_CSFunction(UnityEngineMathfWrap._m_Atan2_xlua_st_));
			Utils.RegisterFunc(L, -4, "Sqrt", new lua_CSFunction(UnityEngineMathfWrap._m_Sqrt_xlua_st_));
			Utils.RegisterFunc(L, -4, "Abs", new lua_CSFunction(UnityEngineMathfWrap._m_Abs_xlua_st_));
			Utils.RegisterFunc(L, -4, "Min", new lua_CSFunction(UnityEngineMathfWrap._m_Min_xlua_st_));
			Utils.RegisterFunc(L, -4, "Max", new lua_CSFunction(UnityEngineMathfWrap._m_Max_xlua_st_));
			Utils.RegisterFunc(L, -4, "Pow", new lua_CSFunction(UnityEngineMathfWrap._m_Pow_xlua_st_));
			Utils.RegisterFunc(L, -4, "Exp", new lua_CSFunction(UnityEngineMathfWrap._m_Exp_xlua_st_));
			Utils.RegisterFunc(L, -4, "Log", new lua_CSFunction(UnityEngineMathfWrap._m_Log_xlua_st_));
			Utils.RegisterFunc(L, -4, "Log10", new lua_CSFunction(UnityEngineMathfWrap._m_Log10_xlua_st_));
			Utils.RegisterFunc(L, -4, "Ceil", new lua_CSFunction(UnityEngineMathfWrap._m_Ceil_xlua_st_));
			Utils.RegisterFunc(L, -4, "Floor", new lua_CSFunction(UnityEngineMathfWrap._m_Floor_xlua_st_));
			Utils.RegisterFunc(L, -4, "Round", new lua_CSFunction(UnityEngineMathfWrap._m_Round_xlua_st_));
			Utils.RegisterFunc(L, -4, "CeilToInt", new lua_CSFunction(UnityEngineMathfWrap._m_CeilToInt_xlua_st_));
			Utils.RegisterFunc(L, -4, "FloorToInt", new lua_CSFunction(UnityEngineMathfWrap._m_FloorToInt_xlua_st_));
			Utils.RegisterFunc(L, -4, "RoundToInt", new lua_CSFunction(UnityEngineMathfWrap._m_RoundToInt_xlua_st_));
			Utils.RegisterFunc(L, -4, "Sign", new lua_CSFunction(UnityEngineMathfWrap._m_Sign_xlua_st_));
			Utils.RegisterFunc(L, -4, "Clamp", new lua_CSFunction(UnityEngineMathfWrap._m_Clamp_xlua_st_));
			Utils.RegisterFunc(L, -4, "Clamp01", new lua_CSFunction(UnityEngineMathfWrap._m_Clamp01_xlua_st_));
			Utils.RegisterFunc(L, -4, "Lerp", new lua_CSFunction(UnityEngineMathfWrap._m_Lerp_xlua_st_));
			Utils.RegisterFunc(L, -4, "LerpUnclamped", new lua_CSFunction(UnityEngineMathfWrap._m_LerpUnclamped_xlua_st_));
			Utils.RegisterFunc(L, -4, "LerpAngle", new lua_CSFunction(UnityEngineMathfWrap._m_LerpAngle_xlua_st_));
			Utils.RegisterFunc(L, -4, "MoveTowards", new lua_CSFunction(UnityEngineMathfWrap._m_MoveTowards_xlua_st_));
			Utils.RegisterFunc(L, -4, "MoveTowardsAngle", new lua_CSFunction(UnityEngineMathfWrap._m_MoveTowardsAngle_xlua_st_));
			Utils.RegisterFunc(L, -4, "SmoothStep", new lua_CSFunction(UnityEngineMathfWrap._m_SmoothStep_xlua_st_));
			Utils.RegisterFunc(L, -4, "Gamma", new lua_CSFunction(UnityEngineMathfWrap._m_Gamma_xlua_st_));
			Utils.RegisterFunc(L, -4, "Approximately", new lua_CSFunction(UnityEngineMathfWrap._m_Approximately_xlua_st_));
			Utils.RegisterFunc(L, -4, "SmoothDamp", new lua_CSFunction(UnityEngineMathfWrap._m_SmoothDamp_xlua_st_));
			Utils.RegisterFunc(L, -4, "SmoothDampAngle", new lua_CSFunction(UnityEngineMathfWrap._m_SmoothDampAngle_xlua_st_));
			Utils.RegisterFunc(L, -4, "Repeat", new lua_CSFunction(UnityEngineMathfWrap._m_Repeat_xlua_st_));
			Utils.RegisterFunc(L, -4, "PingPong", new lua_CSFunction(UnityEngineMathfWrap._m_PingPong_xlua_st_));
			Utils.RegisterFunc(L, -4, "InverseLerp", new lua_CSFunction(UnityEngineMathfWrap._m_InverseLerp_xlua_st_));
			Utils.RegisterFunc(L, -4, "DeltaAngle", new lua_CSFunction(UnityEngineMathfWrap._m_DeltaAngle_xlua_st_));
			Utils.RegisterObject(L, translator, -4, "PI", 3.1415927f);
			Utils.RegisterObject(L, translator, -4, "Infinity", float.PositiveInfinity);
			Utils.RegisterObject(L, translator, -4, "NegativeInfinity", float.NegativeInfinity);
			Utils.RegisterObject(L, translator, -4, "Deg2Rad", 0.017453292f);
			Utils.RegisterObject(L, translator, -4, "Rad2Deg", 57.29578f);
			Utils.RegisterObject(L, translator, -4, "Epsilon", Mathf.Epsilon);
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (Lua.lua_gettop(L) == 1)
				{
					objectTranslator.Push(L, default(Mathf));
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Mathf constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ClosestPowerOfTwo_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = Mathf.ClosestPowerOfTwo(Lua.xlua_tointeger(L, 1));
				Lua.xlua_pushinteger(L, value);
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
		private static int _m_IsPowerOfTwo_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				bool value = Mathf.IsPowerOfTwo(Lua.xlua_tointeger(L, 1));
				Lua.lua_pushboolean(L, value);
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
		private static int _m_NextPowerOfTwo_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = Mathf.NextPowerOfTwo(Lua.xlua_tointeger(L, 1));
				Lua.xlua_pushinteger(L, value);
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
		private static int _m_GammaToLinearSpace_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.GammaToLinearSpace((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_LinearToGammaSpace_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.LinearToGammaSpace((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_CorrelatedColorTemperatureToRGB_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Color val = Mathf.CorrelatedColorTemperatureToRGB((float)Lua.lua_tonumber(L, 1));
				objectTranslator.PushUnityEngineColor(L, val);
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
		private static int _m_FloatToHalf_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ushort value = Mathf.FloatToHalf((float)Lua.lua_tonumber(L, 1));
				Lua.xlua_pushinteger(L, (int)value);
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
		private static int _m_HalfToFloat_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.HalfToFloat((ushort)Lua.xlua_tointeger(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_PerlinNoise_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float x = (float)Lua.lua_tonumber(L, 1);
				float y = (float)Lua.lua_tonumber(L, 2);
				float num = Mathf.PerlinNoise(x, y);
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Sin_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.Sin((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Cos_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.Cos((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Tan_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.Tan((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Asin_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.Asin((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Acos_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.Acos((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Atan_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.Atan((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Atan2_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float y = (float)Lua.lua_tonumber(L, 1);
				float x = (float)Lua.lua_tonumber(L, 2);
				float num = Mathf.Atan2(y, x);
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Sqrt_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.Sqrt((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Abs_xlua_st_(IntPtr L)
		{
			try
			{
				int num = Lua.lua_gettop(L);
				if (num == 1 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1))
				{
					float num2 = Mathf.Abs((float)Lua.lua_tonumber(L, 1));
					Lua.lua_pushnumber(L, (double)num2);
					return 1;
				}
				if (num == 1 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1))
				{
					int value = Mathf.Abs(Lua.xlua_tointeger(L, 1));
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Mathf.Abs!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Min_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					float a = (float)Lua.lua_tonumber(L, 1);
					float b = (float)Lua.lua_tonumber(L, 2);
					float num2 = Mathf.Min(a, b);
					Lua.lua_pushnumber(L, (double)num2);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int a2 = Lua.xlua_tointeger(L, 1);
					int b2 = Lua.xlua_tointeger(L, 2);
					int value = Mathf.Min(a2, b2);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num >= 0 && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 1) || LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1)))
				{
					float num3 = Mathf.Min(objectTranslator.GetParams<float>(L, 1));
					Lua.lua_pushnumber(L, (double)num3);
					return 1;
				}
				if (num >= 0 && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 1) || LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1)))
				{
					int value2 = Mathf.Min(objectTranslator.GetParams<int>(L, 1));
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Mathf.Min!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Max_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					float a = (float)Lua.lua_tonumber(L, 1);
					float b = (float)Lua.lua_tonumber(L, 2);
					float num2 = Mathf.Max(a, b);
					Lua.lua_pushnumber(L, (double)num2);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int a2 = Lua.xlua_tointeger(L, 1);
					int b2 = Lua.xlua_tointeger(L, 2);
					int value = Mathf.Max(a2, b2);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num >= 0 && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 1) || LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1)))
				{
					float num3 = Mathf.Max(objectTranslator.GetParams<float>(L, 1));
					Lua.lua_pushnumber(L, (double)num3);
					return 1;
				}
				if (num >= 0 && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 1) || LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1)))
				{
					int value2 = Mathf.Max(objectTranslator.GetParams<int>(L, 1));
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Mathf.Max!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Pow_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float f = (float)Lua.lua_tonumber(L, 1);
				float p = (float)Lua.lua_tonumber(L, 2);
				float num = Mathf.Pow(f, p);
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Exp_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.Exp((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Log_xlua_st_(IntPtr L)
		{
			try
			{
				int num = Lua.lua_gettop(L);
				if (num == 1 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1))
				{
					float num2 = Mathf.Log((float)Lua.lua_tonumber(L, 1));
					Lua.lua_pushnumber(L, (double)num2);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					float f = (float)Lua.lua_tonumber(L, 1);
					float p = (float)Lua.lua_tonumber(L, 2);
					float num3 = Mathf.Log(f, p);
					Lua.lua_pushnumber(L, (double)num3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Mathf.Log!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Log10_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.Log10((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Ceil_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.Ceil((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Floor_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.Floor((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Round_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.Round((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_CeilToInt_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = Mathf.CeilToInt((float)Lua.lua_tonumber(L, 1));
				Lua.xlua_pushinteger(L, value);
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
		private static int _m_FloorToInt_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = Mathf.FloorToInt((float)Lua.lua_tonumber(L, 1));
				Lua.xlua_pushinteger(L, value);
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
		private static int _m_RoundToInt_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = Mathf.RoundToInt((float)Lua.lua_tonumber(L, 1));
				Lua.xlua_pushinteger(L, value);
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
		private static int _m_Sign_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.Sign((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Clamp_xlua_st_(IntPtr L)
		{
			try
			{
				int num = Lua.lua_gettop(L);
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float value = (float)Lua.lua_tonumber(L, 1);
					float min = (float)Lua.lua_tonumber(L, 2);
					float max = (float)Lua.lua_tonumber(L, 3);
					float num2 = Mathf.Clamp(value, min, max);
					Lua.lua_pushnumber(L, (double)num2);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					int value2 = Lua.xlua_tointeger(L, 1);
					int min2 = Lua.xlua_tointeger(L, 2);
					int max2 = Lua.xlua_tointeger(L, 3);
					int value3 = Mathf.Clamp(value2, min2, max2);
					Lua.xlua_pushinteger(L, value3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Mathf.Clamp!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Clamp01_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float num = Mathf.Clamp01((float)Lua.lua_tonumber(L, 1));
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Lerp_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float a = (float)Lua.lua_tonumber(L, 1);
				float b = (float)Lua.lua_tonumber(L, 2);
				float t = (float)Lua.lua_tonumber(L, 3);
				float num = Mathf.Lerp(a, b, t);
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_LerpUnclamped_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float a = (float)Lua.lua_tonumber(L, 1);
				float b = (float)Lua.lua_tonumber(L, 2);
				float t = (float)Lua.lua_tonumber(L, 3);
				float num = Mathf.LerpUnclamped(a, b, t);
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_LerpAngle_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float a = (float)Lua.lua_tonumber(L, 1);
				float b = (float)Lua.lua_tonumber(L, 2);
				float t = (float)Lua.lua_tonumber(L, 3);
				float num = Mathf.LerpAngle(a, b, t);
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_MoveTowards_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float current = (float)Lua.lua_tonumber(L, 1);
				float target = (float)Lua.lua_tonumber(L, 2);
				float maxDelta = (float)Lua.lua_tonumber(L, 3);
				float num = Mathf.MoveTowards(current, target, maxDelta);
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_MoveTowardsAngle_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float current = (float)Lua.lua_tonumber(L, 1);
				float target = (float)Lua.lua_tonumber(L, 2);
				float maxDelta = (float)Lua.lua_tonumber(L, 3);
				float num = Mathf.MoveTowardsAngle(current, target, maxDelta);
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_SmoothStep_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float from = (float)Lua.lua_tonumber(L, 1);
				float to = (float)Lua.lua_tonumber(L, 2);
				float t = (float)Lua.lua_tonumber(L, 3);
				float num = Mathf.SmoothStep(from, to, t);
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Gamma_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float value = (float)Lua.lua_tonumber(L, 1);
				float absmax = (float)Lua.lua_tonumber(L, 2);
				float gamma = (float)Lua.lua_tonumber(L, 3);
				float num = Mathf.Gamma(value, absmax, gamma);
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_Approximately_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float a = (float)Lua.lua_tonumber(L, 1);
				float b = (float)Lua.lua_tonumber(L, 2);
				bool value = Mathf.Approximately(a, b);
				Lua.lua_pushboolean(L, value);
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
		private static int _m_SmoothDamp_xlua_st_(IntPtr L)
		{
			try
			{
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float current = (float)Lua.lua_tonumber(L, 1);
					float target = (float)Lua.lua_tonumber(L, 2);
					float num2 = (float)Lua.lua_tonumber(L, 3);
					float smoothTime = (float)Lua.lua_tonumber(L, 4);
					float num3 = Mathf.SmoothDamp(current, target, ref num2, smoothTime);
					Lua.lua_pushnumber(L, (double)num3);
					Lua.lua_pushnumber(L, (double)num2);
					return 2;
				}
				if (num == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					float current2 = (float)Lua.lua_tonumber(L, 1);
					float target2 = (float)Lua.lua_tonumber(L, 2);
					float num4 = (float)Lua.lua_tonumber(L, 3);
					float smoothTime2 = (float)Lua.lua_tonumber(L, 4);
					float maxSpeed = (float)Lua.lua_tonumber(L, 5);
					float num5 = Mathf.SmoothDamp(current2, target2, ref num4, smoothTime2, maxSpeed);
					Lua.lua_pushnumber(L, (double)num5);
					Lua.lua_pushnumber(L, (double)num4);
					return 2;
				}
				if (num == 6 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6))
				{
					float current3 = (float)Lua.lua_tonumber(L, 1);
					float target3 = (float)Lua.lua_tonumber(L, 2);
					float num6 = (float)Lua.lua_tonumber(L, 3);
					float smoothTime3 = (float)Lua.lua_tonumber(L, 4);
					float maxSpeed2 = (float)Lua.lua_tonumber(L, 5);
					float deltaTime = (float)Lua.lua_tonumber(L, 6);
					float num7 = Mathf.SmoothDamp(current3, target3, ref num6, smoothTime3, maxSpeed2, deltaTime);
					Lua.lua_pushnumber(L, (double)num7);
					Lua.lua_pushnumber(L, (double)num6);
					return 2;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Mathf.SmoothDamp!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SmoothDampAngle_xlua_st_(IntPtr L)
		{
			try
			{
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float current = (float)Lua.lua_tonumber(L, 1);
					float target = (float)Lua.lua_tonumber(L, 2);
					float num2 = (float)Lua.lua_tonumber(L, 3);
					float smoothTime = (float)Lua.lua_tonumber(L, 4);
					float num3 = Mathf.SmoothDampAngle(current, target, ref num2, smoothTime);
					Lua.lua_pushnumber(L, (double)num3);
					Lua.lua_pushnumber(L, (double)num2);
					return 2;
				}
				if (num == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					float current2 = (float)Lua.lua_tonumber(L, 1);
					float target2 = (float)Lua.lua_tonumber(L, 2);
					float num4 = (float)Lua.lua_tonumber(L, 3);
					float smoothTime2 = (float)Lua.lua_tonumber(L, 4);
					float maxSpeed = (float)Lua.lua_tonumber(L, 5);
					float num5 = Mathf.SmoothDampAngle(current2, target2, ref num4, smoothTime2, maxSpeed);
					Lua.lua_pushnumber(L, (double)num5);
					Lua.lua_pushnumber(L, (double)num4);
					return 2;
				}
				if (num == 6 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6))
				{
					float current3 = (float)Lua.lua_tonumber(L, 1);
					float target3 = (float)Lua.lua_tonumber(L, 2);
					float num6 = (float)Lua.lua_tonumber(L, 3);
					float smoothTime3 = (float)Lua.lua_tonumber(L, 4);
					float maxSpeed2 = (float)Lua.lua_tonumber(L, 5);
					float deltaTime = (float)Lua.lua_tonumber(L, 6);
					float num7 = Mathf.SmoothDampAngle(current3, target3, ref num6, smoothTime3, maxSpeed2, deltaTime);
					Lua.lua_pushnumber(L, (double)num7);
					Lua.lua_pushnumber(L, (double)num6);
					return 2;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Mathf.SmoothDampAngle!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Repeat_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float t = (float)Lua.lua_tonumber(L, 1);
				float length = (float)Lua.lua_tonumber(L, 2);
				float num = Mathf.Repeat(t, length);
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_PingPong_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float t = (float)Lua.lua_tonumber(L, 1);
				float length = (float)Lua.lua_tonumber(L, 2);
				float num = Mathf.PingPong(t, length);
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_InverseLerp_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float a = (float)Lua.lua_tonumber(L, 1);
				float b = (float)Lua.lua_tonumber(L, 2);
				float value = (float)Lua.lua_tonumber(L, 3);
				float num = Mathf.InverseLerp(a, b, value);
				Lua.lua_pushnumber(L, (double)num);
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
		private static int _m_DeltaAngle_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float current = (float)Lua.lua_tonumber(L, 1);
				float target = (float)Lua.lua_tonumber(L, 2);
				float num = Mathf.DeltaAngle(current, target);
				Lua.lua_pushnumber(L, (double)num);
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
	}
}
