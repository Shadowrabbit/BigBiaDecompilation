using System;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineColorWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Color);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 5, 3, 8, 4, -1);
			Utils.RegisterFunc(L, -4, "__add", new lua_CSFunction(UnityEngineColorWrap.__AddMeta));
			Utils.RegisterFunc(L, -4, "__sub", new lua_CSFunction(UnityEngineColorWrap.__SubMeta));
			Utils.RegisterFunc(L, -4, "__mul", new lua_CSFunction(UnityEngineColorWrap.__MulMeta));
			Utils.RegisterFunc(L, -4, "__div", new lua_CSFunction(UnityEngineColorWrap.__DivMeta));
			Utils.RegisterFunc(L, -4, "__eq", new lua_CSFunction(UnityEngineColorWrap.__EqMeta));
			Utils.RegisterFunc(L, -3, "ToString", new lua_CSFunction(UnityEngineColorWrap._m_ToString));
			Utils.RegisterFunc(L, -3, "GetHashCode", new lua_CSFunction(UnityEngineColorWrap._m_GetHashCode));
			Utils.RegisterFunc(L, -3, "Equals", new lua_CSFunction(UnityEngineColorWrap._m_Equals));
			Utils.RegisterFunc(L, -2, "grayscale", new lua_CSFunction(UnityEngineColorWrap._g_get_grayscale));
			Utils.RegisterFunc(L, -2, "linear", new lua_CSFunction(UnityEngineColorWrap._g_get_linear));
			Utils.RegisterFunc(L, -2, "gamma", new lua_CSFunction(UnityEngineColorWrap._g_get_gamma));
			Utils.RegisterFunc(L, -2, "maxColorComponent", new lua_CSFunction(UnityEngineColorWrap._g_get_maxColorComponent));
			Utils.RegisterFunc(L, -2, "r", new lua_CSFunction(UnityEngineColorWrap._g_get_r));
			Utils.RegisterFunc(L, -2, "g", new lua_CSFunction(UnityEngineColorWrap._g_get_g));
			Utils.RegisterFunc(L, -2, "b", new lua_CSFunction(UnityEngineColorWrap._g_get_b));
			Utils.RegisterFunc(L, -2, "a", new lua_CSFunction(UnityEngineColorWrap._g_get_a));
			Utils.RegisterFunc(L, -1, "r", new lua_CSFunction(UnityEngineColorWrap._s_set_r));
			Utils.RegisterFunc(L, -1, "g", new lua_CSFunction(UnityEngineColorWrap._s_set_g));
			Utils.RegisterFunc(L, -1, "b", new lua_CSFunction(UnityEngineColorWrap._s_set_b));
			Utils.RegisterFunc(L, -1, "a", new lua_CSFunction(UnityEngineColorWrap._s_set_a));
			Utils.EndObjectRegister(typeFromHandle, L, translator, new lua_CSFunction(UnityEngineColorWrap.__CSIndexer), new lua_CSFunction(UnityEngineColorWrap.__NewIndexer), null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineColorWrap.__CreateInstance), 5, 11, 0);
			Utils.RegisterFunc(L, -4, "Lerp", new lua_CSFunction(UnityEngineColorWrap._m_Lerp_xlua_st_));
			Utils.RegisterFunc(L, -4, "LerpUnclamped", new lua_CSFunction(UnityEngineColorWrap._m_LerpUnclamped_xlua_st_));
			Utils.RegisterFunc(L, -4, "RGBToHSV", new lua_CSFunction(UnityEngineColorWrap._m_RGBToHSV_xlua_st_));
			Utils.RegisterFunc(L, -4, "HSVToRGB", new lua_CSFunction(UnityEngineColorWrap._m_HSVToRGB_xlua_st_));
			Utils.RegisterFunc(L, -2, "red", new lua_CSFunction(UnityEngineColorWrap._g_get_red));
			Utils.RegisterFunc(L, -2, "green", new lua_CSFunction(UnityEngineColorWrap._g_get_green));
			Utils.RegisterFunc(L, -2, "blue", new lua_CSFunction(UnityEngineColorWrap._g_get_blue));
			Utils.RegisterFunc(L, -2, "white", new lua_CSFunction(UnityEngineColorWrap._g_get_white));
			Utils.RegisterFunc(L, -2, "black", new lua_CSFunction(UnityEngineColorWrap._g_get_black));
			Utils.RegisterFunc(L, -2, "yellow", new lua_CSFunction(UnityEngineColorWrap._g_get_yellow));
			Utils.RegisterFunc(L, -2, "cyan", new lua_CSFunction(UnityEngineColorWrap._g_get_cyan));
			Utils.RegisterFunc(L, -2, "magenta", new lua_CSFunction(UnityEngineColorWrap._g_get_magenta));
			Utils.RegisterFunc(L, -2, "gray", new lua_CSFunction(UnityEngineColorWrap._g_get_gray));
			Utils.RegisterFunc(L, -2, "grey", new lua_CSFunction(UnityEngineColorWrap._g_get_grey));
			Utils.RegisterFunc(L, -2, "clear", new lua_CSFunction(UnityEngineColorWrap._g_get_clear));
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (Lua.lua_gettop(L) == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					float r = (float)Lua.lua_tonumber(L, 2);
					float g = (float)Lua.lua_tonumber(L, 3);
					float b = (float)Lua.lua_tonumber(L, 4);
					float a = (float)Lua.lua_tonumber(L, 5);
					Color val = new Color(r, g, b, a);
					objectTranslator.PushUnityEngineColor(L, val);
					return 1;
				}
				if (Lua.lua_gettop(L) == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float r2 = (float)Lua.lua_tonumber(L, 2);
					float g2 = (float)Lua.lua_tonumber(L, 3);
					float b2 = (float)Lua.lua_tonumber(L, 4);
					Color val2 = new Color(r2, g2, b2);
					objectTranslator.PushUnityEngineColor(L, val2);
					return 1;
				}
				if (Lua.lua_gettop(L) == 1)
				{
					objectTranslator.PushUnityEngineColor(L, default(Color));
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Color constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int __CSIndexer(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Color>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					Color color;
					objectTranslator.Get(L, 1, out color);
					int index = Lua.xlua_tointeger(L, 2);
					Lua.lua_pushboolean(L, true);
					Lua.lua_pushnumber(L, (double)color[index]);
					return 2;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			Lua.lua_pushboolean(L, false);
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int __NewIndexer(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			try
			{
				if (objectTranslator.Assignable<Color>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Color color;
					objectTranslator.Get(L, 1, out color);
					int index = Lua.xlua_tointeger(L, 2);
					color[index] = (float)Lua.lua_tonumber(L, 3);
					Lua.lua_pushboolean(L, true);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			Lua.lua_pushboolean(L, false);
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __AddMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Color>(L, 1) && objectTranslator.Assignable<Color>(L, 2))
				{
					Color a;
					objectTranslator.Get(L, 1, out a);
					Color b;
					objectTranslator.Get(L, 2, out b);
					objectTranslator.PushUnityEngineColor(L, a + b);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of + operator, need UnityEngine.Color!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __SubMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Color>(L, 1) && objectTranslator.Assignable<Color>(L, 2))
				{
					Color a;
					objectTranslator.Get(L, 1, out a);
					Color b;
					objectTranslator.Get(L, 2, out b);
					objectTranslator.PushUnityEngineColor(L, a - b);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of - operator, need UnityEngine.Color!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __MulMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Color>(L, 1) && objectTranslator.Assignable<Color>(L, 2))
				{
					Color a;
					objectTranslator.Get(L, 1, out a);
					Color b;
					objectTranslator.Get(L, 2, out b);
					objectTranslator.PushUnityEngineColor(L, a * b);
					return 1;
				}
				if (objectTranslator.Assignable<Color>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					Color a2;
					objectTranslator.Get(L, 1, out a2);
					float b2 = (float)Lua.lua_tonumber(L, 2);
					objectTranslator.PushUnityEngineColor(L, a2 * b2);
					return 1;
				}
				if (LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && objectTranslator.Assignable<Color>(L, 2))
				{
					float b3 = (float)Lua.lua_tonumber(L, 1);
					Color a3;
					objectTranslator.Get(L, 2, out a3);
					objectTranslator.PushUnityEngineColor(L, b3 * a3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of * operator, need UnityEngine.Color!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __DivMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Color>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					Color a;
					objectTranslator.Get(L, 1, out a);
					float b = (float)Lua.lua_tonumber(L, 2);
					objectTranslator.PushUnityEngineColor(L, a / b);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of / operator, need UnityEngine.Color!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __EqMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Color>(L, 1) && objectTranslator.Assignable<Color>(L, 2))
				{
					Color lhs;
					objectTranslator.Get(L, 1, out lhs);
					Color rhs;
					objectTranslator.Get(L, 2, out rhs);
					Lua.lua_pushboolean(L, lhs == rhs);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of == operator, need UnityEngine.Color!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ToString(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Color val;
				objectTranslator.Get(L, 1, out val);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					string str = val.ToString();
					Lua.lua_pushstring(L, str);
					objectTranslator.UpdateUnityEngineColor(L, 1, val);
					return 1;
				}
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string format = Lua.lua_tostring(L, 2);
					string str2 = val.ToString(format);
					Lua.lua_pushstring(L, str2);
					objectTranslator.UpdateUnityEngineColor(L, 1, val);
					return 1;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<IFormatProvider>(L, 3))
				{
					string format2 = Lua.lua_tostring(L, 2);
					IFormatProvider formatProvider = (IFormatProvider)objectTranslator.GetObject(L, 3, typeof(IFormatProvider));
					string str3 = val.ToString(format2, formatProvider);
					Lua.lua_pushstring(L, str3);
					objectTranslator.UpdateUnityEngineColor(L, 1, val);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str4 = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str4 + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Color.ToString!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetHashCode(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Color val;
				objectTranslator.Get(L, 1, out val);
				int hashCode = val.GetHashCode();
				Lua.xlua_pushinteger(L, hashCode);
				objectTranslator.UpdateUnityEngineColor(L, 1, val);
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
		private static int _m_Equals(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Color val;
				objectTranslator.Get(L, 1, out val);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<object>(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 2, typeof(object));
					bool value = val.Equals(@object);
					Lua.lua_pushboolean(L, value);
					objectTranslator.UpdateUnityEngineColor(L, 1, val);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Color>(L, 2))
				{
					Color other;
					objectTranslator.Get(L, 2, out other);
					bool value2 = val.Equals(other);
					Lua.lua_pushboolean(L, value2);
					objectTranslator.UpdateUnityEngineColor(L, 1, val);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Color.Equals!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Lerp_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Color a;
				objectTranslator.Get(L, 1, out a);
				Color b;
				objectTranslator.Get(L, 2, out b);
				float t = (float)Lua.lua_tonumber(L, 3);
				Color val = Color.Lerp(a, b, t);
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
		private static int _m_LerpUnclamped_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Color a;
				objectTranslator.Get(L, 1, out a);
				Color b;
				objectTranslator.Get(L, 2, out b);
				float t = (float)Lua.lua_tonumber(L, 3);
				Color val = Color.LerpUnclamped(a, b, t);
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
		private static int _m_RGBToHSV_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				Color rgbColor;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out rgbColor);
				float num;
				float num2;
				float num3;
				Color.RGBToHSV(rgbColor, out num, out num2, out num3);
				Lua.lua_pushnumber(L, (double)num);
				Lua.lua_pushnumber(L, (double)num2);
				Lua.lua_pushnumber(L, (double)num3);
				result = 3;
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
		private static int _m_HSVToRGB_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float h = (float)Lua.lua_tonumber(L, 1);
					float s = (float)Lua.lua_tonumber(L, 2);
					float v = (float)Lua.lua_tonumber(L, 3);
					Color val = Color.HSVToRGB(h, s, v);
					objectTranslator.PushUnityEngineColor(L, val);
					return 1;
				}
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 4))
				{
					float h2 = (float)Lua.lua_tonumber(L, 1);
					float s2 = (float)Lua.lua_tonumber(L, 2);
					float v2 = (float)Lua.lua_tonumber(L, 3);
					bool hdr = Lua.lua_toboolean(L, 4);
					Color val2 = Color.HSVToRGB(h2, s2, v2, hdr);
					objectTranslator.PushUnityEngineColor(L, val2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Color.HSVToRGB!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_red(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineColor(L, Color.red);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_green(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineColor(L, Color.green);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_blue(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineColor(L, Color.blue);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_white(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineColor(L, Color.white);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_black(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineColor(L, Color.black);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_yellow(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineColor(L, Color.yellow);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_cyan(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineColor(L, Color.cyan);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_magenta(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineColor(L, Color.magenta);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_gray(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineColor(L, Color.gray);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_grey(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineColor(L, Color.grey);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_clear(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineColor(L, Color.clear);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_grayscale(IntPtr L)
		{
			try
			{
				Color color;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out color);
				Lua.lua_pushnumber(L, (double)color.grayscale);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_linear(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Color color;
				objectTranslator.Get(L, 1, out color);
				objectTranslator.PushUnityEngineColor(L, color.linear);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_gamma(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Color color;
				objectTranslator.Get(L, 1, out color);
				objectTranslator.PushUnityEngineColor(L, color.gamma);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_maxColorComponent(IntPtr L)
		{
			try
			{
				Color color;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out color);
				Lua.lua_pushnumber(L, (double)color.maxColorComponent);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_r(IntPtr L)
		{
			try
			{
				Color color;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out color);
				Lua.lua_pushnumber(L, (double)color.r);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_g(IntPtr L)
		{
			try
			{
				Color color;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out color);
				Lua.lua_pushnumber(L, (double)color.g);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_b(IntPtr L)
		{
			try
			{
				Color color;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out color);
				Lua.lua_pushnumber(L, (double)color.b);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_a(IntPtr L)
		{
			try
			{
				Color color;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out color);
				Lua.lua_pushnumber(L, (double)color.a);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_r(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Color val;
				objectTranslator.Get(L, 1, out val);
				val.r = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.UpdateUnityEngineColor(L, 1, val);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_g(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Color val;
				objectTranslator.Get(L, 1, out val);
				val.g = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.UpdateUnityEngineColor(L, 1, val);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_b(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Color val;
				objectTranslator.Get(L, 1, out val);
				val.b = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.UpdateUnityEngineColor(L, 1, val);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_a(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Color val;
				objectTranslator.Get(L, 1, out val);
				val.a = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.UpdateUnityEngineColor(L, 1, val);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}
	}
}
