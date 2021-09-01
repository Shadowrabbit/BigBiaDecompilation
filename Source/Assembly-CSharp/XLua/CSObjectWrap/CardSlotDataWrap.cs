using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class CardSlotDataWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(CardSlotData);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 12, 24, 23, -1);
			Utils.RegisterFunc(L, -3, "MarkFlipState", new lua_CSFunction(CardSlotDataWrap._m_MarkFlipState));
			Utils.RegisterFunc(L, -3, "GetIntAttr", new lua_CSFunction(CardSlotDataWrap._m_GetIntAttr));
			Utils.RegisterFunc(L, -3, "GetFloatAttr", new lua_CSFunction(CardSlotDataWrap._m_GetFloatAttr));
			Utils.RegisterFunc(L, -3, "GetBoolAttr", new lua_CSFunction(CardSlotDataWrap._m_GetBoolAttr));
			Utils.RegisterFunc(L, -3, "GetAttr", new lua_CSFunction(CardSlotDataWrap._m_GetAttr));
			Utils.RegisterFunc(L, -3, "SetBoolAttr", new lua_CSFunction(CardSlotDataWrap._m_SetBoolAttr));
			Utils.RegisterFunc(L, -3, "SetAttr", new lua_CSFunction(CardSlotDataWrap._m_SetAttr));
			Utils.RegisterFunc(L, -3, "HasAttr", new lua_CSFunction(CardSlotDataWrap._m_HasAttr));
			Utils.RegisterFunc(L, -3, "ClearCardData", new lua_CSFunction(CardSlotDataWrap._m_ClearCardData));
			Utils.RegisterFunc(L, -3, "Terminate", new lua_CSFunction(CardSlotDataWrap._m_Terminate));
			Utils.RegisterFunc(L, -3, "SetChildCardData", new lua_CSFunction(CardSlotDataWrap._m_SetChildCardData));
			Utils.RegisterFunc(L, -3, "OnDeserialized", new lua_CSFunction(CardSlotDataWrap._m_OnDeserialized));
			Utils.RegisterFunc(L, -2, "IsFlipped", new lua_CSFunction(CardSlotDataWrap._g_get_IsFlipped));
			Utils.RegisterFunc(L, -2, "DisplayPositionX", new lua_CSFunction(CardSlotDataWrap._g_get_DisplayPositionX));
			Utils.RegisterFunc(L, -2, "DisplayPositionZ", new lua_CSFunction(CardSlotDataWrap._g_get_DisplayPositionZ));
			Utils.RegisterFunc(L, -2, "GridPositionX", new lua_CSFunction(CardSlotDataWrap._g_get_GridPositionX));
			Utils.RegisterFunc(L, -2, "GridPositionY", new lua_CSFunction(CardSlotDataWrap._g_get_GridPositionY));
			Utils.RegisterFunc(L, -2, "CardSlotGameObject", new lua_CSFunction(CardSlotDataWrap._g_get_CardSlotGameObject));
			Utils.RegisterFunc(L, -2, "CurrentAreaData", new lua_CSFunction(CardSlotDataWrap._g_get_CurrentAreaData));
			Utils.RegisterFunc(L, -2, "OnlyAcceptOneCard", new lua_CSFunction(CardSlotDataWrap._g_get_OnlyAcceptOneCard));
			Utils.RegisterFunc(L, -2, "IsFreeze", new lua_CSFunction(CardSlotDataWrap._g_get_IsFreeze));
			Utils.RegisterFunc(L, -2, "IconIndex", new lua_CSFunction(CardSlotDataWrap._g_get_IconIndex));
			Utils.RegisterFunc(L, -2, "IsInScene", new lua_CSFunction(CardSlotDataWrap._g_get_IsInScene));
			Utils.RegisterFunc(L, -2, "CanClick", new lua_CSFunction(CardSlotDataWrap._g_get_CanClick));
			Utils.RegisterFunc(L, -2, "SlotType", new lua_CSFunction(CardSlotDataWrap._g_get_SlotType));
			Utils.RegisterFunc(L, -2, "TagWhiteList", new lua_CSFunction(CardSlotDataWrap._g_get_TagWhiteList));
			Utils.RegisterFunc(L, -2, "Color", new lua_CSFunction(CardSlotDataWrap._g_get_Color));
			Utils.RegisterFunc(L, -2, "ChildCardData", new lua_CSFunction(CardSlotDataWrap._g_get_ChildCardData));
			Utils.RegisterFunc(L, -2, "Model", new lua_CSFunction(CardSlotDataWrap._g_get_Model));
			Utils.RegisterFunc(L, -2, "desc", new lua_CSFunction(CardSlotDataWrap._g_get_desc));
			Utils.RegisterFunc(L, -2, "SlotOwnerType", new lua_CSFunction(CardSlotDataWrap._g_get_SlotOwnerType));
			Utils.RegisterFunc(L, -2, "SlotForward", new lua_CSFunction(CardSlotDataWrap._g_get_SlotForward));
			Utils.RegisterFunc(L, -2, "SlotScale", new lua_CSFunction(CardSlotDataWrap._g_get_SlotScale));
			Utils.RegisterFunc(L, -2, "Attrs", new lua_CSFunction(CardSlotDataWrap._g_get_Attrs));
			Utils.RegisterFunc(L, -2, "LogicNames", new lua_CSFunction(CardSlotDataWrap._g_get_LogicNames));
			Utils.RegisterFunc(L, -2, "Logics", new lua_CSFunction(CardSlotDataWrap._g_get_Logics));
			Utils.RegisterFunc(L, -1, "DisplayPositionX", new lua_CSFunction(CardSlotDataWrap._s_set_DisplayPositionX));
			Utils.RegisterFunc(L, -1, "DisplayPositionZ", new lua_CSFunction(CardSlotDataWrap._s_set_DisplayPositionZ));
			Utils.RegisterFunc(L, -1, "GridPositionX", new lua_CSFunction(CardSlotDataWrap._s_set_GridPositionX));
			Utils.RegisterFunc(L, -1, "GridPositionY", new lua_CSFunction(CardSlotDataWrap._s_set_GridPositionY));
			Utils.RegisterFunc(L, -1, "CardSlotGameObject", new lua_CSFunction(CardSlotDataWrap._s_set_CardSlotGameObject));
			Utils.RegisterFunc(L, -1, "CurrentAreaData", new lua_CSFunction(CardSlotDataWrap._s_set_CurrentAreaData));
			Utils.RegisterFunc(L, -1, "OnlyAcceptOneCard", new lua_CSFunction(CardSlotDataWrap._s_set_OnlyAcceptOneCard));
			Utils.RegisterFunc(L, -1, "IsFreeze", new lua_CSFunction(CardSlotDataWrap._s_set_IsFreeze));
			Utils.RegisterFunc(L, -1, "IconIndex", new lua_CSFunction(CardSlotDataWrap._s_set_IconIndex));
			Utils.RegisterFunc(L, -1, "IsInScene", new lua_CSFunction(CardSlotDataWrap._s_set_IsInScene));
			Utils.RegisterFunc(L, -1, "CanClick", new lua_CSFunction(CardSlotDataWrap._s_set_CanClick));
			Utils.RegisterFunc(L, -1, "SlotType", new lua_CSFunction(CardSlotDataWrap._s_set_SlotType));
			Utils.RegisterFunc(L, -1, "TagWhiteList", new lua_CSFunction(CardSlotDataWrap._s_set_TagWhiteList));
			Utils.RegisterFunc(L, -1, "Color", new lua_CSFunction(CardSlotDataWrap._s_set_Color));
			Utils.RegisterFunc(L, -1, "ChildCardData", new lua_CSFunction(CardSlotDataWrap._s_set_ChildCardData));
			Utils.RegisterFunc(L, -1, "Model", new lua_CSFunction(CardSlotDataWrap._s_set_Model));
			Utils.RegisterFunc(L, -1, "desc", new lua_CSFunction(CardSlotDataWrap._s_set_desc));
			Utils.RegisterFunc(L, -1, "SlotOwnerType", new lua_CSFunction(CardSlotDataWrap._s_set_SlotOwnerType));
			Utils.RegisterFunc(L, -1, "SlotForward", new lua_CSFunction(CardSlotDataWrap._s_set_SlotForward));
			Utils.RegisterFunc(L, -1, "SlotScale", new lua_CSFunction(CardSlotDataWrap._s_set_SlotScale));
			Utils.RegisterFunc(L, -1, "Attrs", new lua_CSFunction(CardSlotDataWrap._s_set_Attrs));
			Utils.RegisterFunc(L, -1, "LogicNames", new lua_CSFunction(CardSlotDataWrap._s_set_LogicNames));
			Utils.RegisterFunc(L, -1, "Logics", new lua_CSFunction(CardSlotDataWrap._s_set_Logics));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(CardSlotDataWrap.__CreateInstance), 2, 0, 0);
			Utils.RegisterFunc(L, -4, "CopyCardSlotData", new lua_CSFunction(CardSlotDataWrap._m_CopyCardSlotData_xlua_st_));
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
					CardSlotData o = new CardSlotData();
					objectTranslator.Push(L, o);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to CardSlotData constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_MarkFlipState(IntPtr L)
		{
			int result;
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				bool value = Lua.lua_toboolean(L, 2);
				cardSlotData.MarkFlipState(value);
				result = 0;
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
		private static int _m_GetIntAttr(IntPtr L)
		{
			int result;
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				string name = Lua.lua_tostring(L, 2);
				int intAttr = cardSlotData.GetIntAttr(name);
				Lua.xlua_pushinteger(L, intAttr);
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
		private static int _m_GetFloatAttr(IntPtr L)
		{
			int result;
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				string name = Lua.lua_tostring(L, 2);
				float floatAttr = cardSlotData.GetFloatAttr(name);
				Lua.lua_pushnumber(L, (double)floatAttr);
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
		private static int _m_GetBoolAttr(IntPtr L)
		{
			int result;
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				string name = Lua.lua_tostring(L, 2);
				bool boolAttr = cardSlotData.GetBoolAttr(name);
				Lua.lua_pushboolean(L, boolAttr);
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
		private static int _m_GetAttr(IntPtr L)
		{
			int result;
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				string name = Lua.lua_tostring(L, 2);
				string attr = cardSlotData.GetAttr(name);
				Lua.lua_pushstring(L, attr);
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
		private static int _m_SetBoolAttr(IntPtr L)
		{
			int result;
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				string name = Lua.lua_tostring(L, 2);
				bool value = Lua.lua_toboolean(L, 3);
				cardSlotData.SetBoolAttr(name, value);
				result = 0;
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
		private static int _m_SetAttr(IntPtr L)
		{
			int result;
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				string name = Lua.lua_tostring(L, 2);
				string value = Lua.lua_tostring(L, 3);
				cardSlotData.SetAttr(name, value);
				result = 0;
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
		private static int _m_HasAttr(IntPtr L)
		{
			int result;
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				string name = Lua.lua_tostring(L, 2);
				bool value = cardSlotData.HasAttr(name);
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
		private static int _m_ClearCardData(IntPtr L)
		{
			int result;
			try
			{
				((CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).ClearCardData();
				result = 0;
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
		private static int _m_Terminate(IntPtr L)
		{
			int result;
			try
			{
				((CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Terminate();
				result = 0;
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
		private static int _m_SetChildCardData(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				CardData childCardData = (CardData)objectTranslator.GetObject(L, 2, typeof(CardData));
				cardSlotData.SetChildCardData(childCardData);
				result = 0;
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
		private static int _m_CopyCardSlotData_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData o = CardSlotData.CopyCardSlotData((CardSlotData)objectTranslator.GetObject(L, 1, typeof(CardSlotData)));
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
		private static int _m_OnDeserialized(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				StreamingContext context;
				objectTranslator.Get<StreamingContext>(L, 2, out context);
				cardSlotData.OnDeserialized(context);
				result = 0;
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
		private static int _g_get_IsFlipped(IntPtr L)
		{
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, cardSlotData.IsFlipped);
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
		private static int _g_get_DisplayPositionX(IntPtr L)
		{
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)cardSlotData.DisplayPositionX);
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
		private static int _g_get_DisplayPositionZ(IntPtr L)
		{
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)cardSlotData.DisplayPositionZ);
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
		private static int _g_get_GridPositionX(IntPtr L)
		{
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardSlotData.GridPositionX);
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
		private static int _g_get_GridPositionY(IntPtr L)
		{
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardSlotData.GridPositionY);
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
		private static int _g_get_CardSlotGameObject(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardSlotData.CardSlotGameObject);
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
		private static int _g_get_CurrentAreaData(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardSlotData.CurrentAreaData);
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
		private static int _g_get_OnlyAcceptOneCard(IntPtr L)
		{
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, cardSlotData.OnlyAcceptOneCard);
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
		private static int _g_get_IsFreeze(IntPtr L)
		{
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, cardSlotData.IsFreeze);
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
		private static int _g_get_IconIndex(IntPtr L)
		{
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardSlotData.IconIndex);
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
		private static int _g_get_IsInScene(IntPtr L)
		{
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, cardSlotData.IsInScene);
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
		private static int _g_get_CanClick(IntPtr L)
		{
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, cardSlotData.CanClick);
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
		private static int _g_get_SlotType(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardSlotData.SlotType);
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
		private static int _g_get_TagWhiteList(IntPtr L)
		{
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushuint64(L, cardSlotData.TagWhiteList);
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
		private static int _g_get_Color(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardSlotData.Color);
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
		private static int _g_get_ChildCardData(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardSlotData.ChildCardData);
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
		private static int _g_get_Model(IntPtr L)
		{
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, cardSlotData.Model);
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
		private static int _g_get_desc(IntPtr L)
		{
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, cardSlotData.desc);
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
		private static int _g_get_SlotOwnerType(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardSlotData.SlotOwnerType);
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
		private static int _g_get_SlotForward(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardSlotData.SlotForward);
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
		private static int _g_get_SlotScale(IntPtr L)
		{
			try
			{
				CardSlotData cardSlotData = (CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)cardSlotData.SlotScale);
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
		private static int _g_get_Attrs(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardSlotData.Attrs);
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
		private static int _g_get_LogicNames(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardSlotData.LogicNames);
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
		private static int _g_get_Logics(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardSlotData.Logics);
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
		private static int _s_set_DisplayPositionX(IntPtr L)
		{
			try
			{
				((CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DisplayPositionX = (float)Lua.lua_tonumber(L, 2);
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
		private static int _s_set_DisplayPositionZ(IntPtr L)
		{
			try
			{
				((CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DisplayPositionZ = (float)Lua.lua_tonumber(L, 2);
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
		private static int _s_set_GridPositionX(IntPtr L)
		{
			try
			{
				((CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).GridPositionX = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_GridPositionY(IntPtr L)
		{
			try
			{
				((CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).GridPositionY = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_CardSlotGameObject(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardSlotData)objectTranslator.FastGetCSObj(L, 1)).CardSlotGameObject = (CardSlot)objectTranslator.GetObject(L, 2, typeof(CardSlot));
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
		private static int _s_set_CurrentAreaData(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardSlotData)objectTranslator.FastGetCSObj(L, 1)).CurrentAreaData = (AreaData)objectTranslator.GetObject(L, 2, typeof(AreaData));
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
		private static int _s_set_OnlyAcceptOneCard(IntPtr L)
		{
			try
			{
				((CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).OnlyAcceptOneCard = Lua.lua_toboolean(L, 2);
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
		private static int _s_set_IsFreeze(IntPtr L)
		{
			try
			{
				((CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).IsFreeze = Lua.lua_toboolean(L, 2);
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
		private static int _s_set_IconIndex(IntPtr L)
		{
			try
			{
				((CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).IconIndex = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_IsInScene(IntPtr L)
		{
			try
			{
				((CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).IsInScene = Lua.lua_toboolean(L, 2);
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
		private static int _s_set_CanClick(IntPtr L)
		{
			try
			{
				((CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).CanClick = Lua.lua_toboolean(L, 2);
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
		private static int _s_set_SlotType(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				CardSlotData.Type slotType;
				objectTranslator.Get<CardSlotData.Type>(L, 2, out slotType);
				cardSlotData.SlotType = slotType;
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
		private static int _s_set_TagWhiteList(IntPtr L)
		{
			try
			{
				((CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).TagWhiteList = Lua.lua_touint64(L, 2);
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
		private static int _s_set_Color(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				CardSlotData.LineColor color;
				objectTranslator.Get<CardSlotData.LineColor>(L, 2, out color);
				cardSlotData.Color = color;
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
		private static int _s_set_ChildCardData(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardSlotData)objectTranslator.FastGetCSObj(L, 1)).ChildCardData = (CardData)objectTranslator.GetObject(L, 2, typeof(CardData));
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
		private static int _s_set_Model(IntPtr L)
		{
			try
			{
				((CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Model = Lua.lua_tostring(L, 2);
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
		private static int _s_set_desc(IntPtr L)
		{
			try
			{
				((CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).desc = Lua.lua_tostring(L, 2);
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
		private static int _s_set_SlotOwnerType(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				CardSlotData.OwnerType slotOwnerType;
				objectTranslator.Get<CardSlotData.OwnerType>(L, 2, out slotOwnerType);
				cardSlotData.SlotOwnerType = slotOwnerType;
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
		private static int _s_set_SlotForward(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardSlotData cardSlotData = (CardSlotData)objectTranslator.FastGetCSObj(L, 1);
				CardSlotData.Forward slotForward;
				objectTranslator.Get<CardSlotData.Forward>(L, 2, out slotForward);
				cardSlotData.SlotForward = slotForward;
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
		private static int _s_set_SlotScale(IntPtr L)
		{
			try
			{
				((CardSlotData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).SlotScale = (float)Lua.lua_tonumber(L, 2);
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
		private static int _s_set_Attrs(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardSlotData)objectTranslator.FastGetCSObj(L, 1)).Attrs = (Dictionary<string, object>)objectTranslator.GetObject(L, 2, typeof(Dictionary<string, object>));
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
		private static int _s_set_LogicNames(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardSlotData)objectTranslator.FastGetCSObj(L, 1)).LogicNames = (List<string>)objectTranslator.GetObject(L, 2, typeof(List<string>));
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
		private static int _s_set_Logics(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardSlotData)objectTranslator.FastGetCSObj(L, 1)).Logics = (List<CardSlotLogic>)objectTranslator.GetObject(L, 2, typeof(List<CardSlotLogic>));
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
