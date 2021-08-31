using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class GameControllerWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(GameController);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 45, 65, 64, -1);
			Utils.RegisterFunc(L, -3, "SaveGame", new lua_CSFunction(GameControllerWrap._m_SaveGame));
			Utils.RegisterFunc(L, -3, "LoadGame", new lua_CSFunction(GameControllerWrap._m_LoadGame));
			Utils.RegisterFunc(L, -3, "DeleteAllSaveData", new lua_CSFunction(GameControllerWrap._m_DeleteAllSaveData));
			Utils.RegisterFunc(L, -3, "LoadHomeScene", new lua_CSFunction(GameControllerWrap._m_LoadHomeScene));
			Utils.RegisterFunc(L, -3, "LoadGuideHomeScene", new lua_CSFunction(GameControllerWrap._m_LoadGuideHomeScene));
			Utils.RegisterFunc(L, -3, "ShowTable", new lua_CSFunction(GameControllerWrap._m_ShowTable));
			Utils.RegisterFunc(L, -3, "ChangeTimePause", new lua_CSFunction(GameControllerWrap._m_ChangeTimePause));
			Utils.RegisterFunc(L, -3, "ChangeTimeScale", new lua_CSFunction(GameControllerWrap._m_ChangeTimeScale));
			Utils.RegisterFunc(L, -3, "func", new lua_CSFunction(GameControllerWrap._m_func));
			Utils.RegisterFunc(L, -3, "EnterLoadScene", new lua_CSFunction(GameControllerWrap._m_EnterLoadScene));
			Utils.RegisterFunc(L, -3, "InitWorld", new lua_CSFunction(GameControllerWrap._m_InitWorld));
			Utils.RegisterFunc(L, -3, "InitPlayerTable", new lua_CSFunction(GameControllerWrap._m_InitPlayerTable));
			Utils.RegisterFunc(L, -3, "GetCurrentAreaData", new lua_CSFunction(GameControllerWrap._m_GetCurrentAreaData));
			Utils.RegisterFunc(L, -3, "InitCOOPPlayerTable", new lua_CSFunction(GameControllerWrap._m_InitCOOPPlayerTable));
			Utils.RegisterFunc(L, -3, "InitVSPlayerTable", new lua_CSFunction(GameControllerWrap._m_InitVSPlayerTable));
			Utils.RegisterFunc(L, -3, "CreatePlayer", new lua_CSFunction(GameControllerWrap._m_CreatePlayer));
			Utils.RegisterFunc(L, -3, "IsPlayerCardSlotData", new lua_CSFunction(GameControllerWrap._m_IsPlayerCardSlotData));
			Utils.RegisterFunc(L, -3, "FindCard", new lua_CSFunction(GameControllerWrap._m_FindCard));
			Utils.RegisterFunc(L, -3, "FindCardOnPlayerTable", new lua_CSFunction(GameControllerWrap._m_FindCardOnPlayerTable));
			Utils.RegisterFunc(L, -3, "FindCardOnPlayerTableCount", new lua_CSFunction(GameControllerWrap._m_FindCardOnPlayerTableCount));
			Utils.RegisterFunc(L, -3, "FindCardOnPlayerTableByType", new lua_CSFunction(GameControllerWrap._m_FindCardOnPlayerTableByType));
			Utils.RegisterFunc(L, -3, "OnMoveInTheWorld", new lua_CSFunction(GameControllerWrap._m_OnMoveInTheWorld));
			Utils.RegisterFunc(L, -3, "RotateCardAnimate", new lua_CSFunction(GameControllerWrap._m_RotateCardAnimate));
			Utils.RegisterFunc(L, -3, "SkipBtn", new lua_CSFunction(GameControllerWrap._m_SkipBtn));
			Utils.RegisterFunc(L, -3, "ChangeCurrentArea", new lua_CSFunction(GameControllerWrap._m_ChangeCurrentArea));
			Utils.RegisterFunc(L, -3, "OnDayPast", new lua_CSFunction(GameControllerWrap._m_OnDayPast));
			Utils.RegisterFunc(L, -3, "UnlockCardSlot", new lua_CSFunction(GameControllerWrap._m_UnlockCardSlot));
			Utils.RegisterFunc(L, -3, "OnTableChange", new lua_CSFunction(GameControllerWrap._m_OnTableChange));
			Utils.RegisterFunc(L, -3, "CameraMove", new lua_CSFunction(GameControllerWrap._m_CameraMove));
			Utils.RegisterFunc(L, -3, "CameraMoveRevert", new lua_CSFunction(GameControllerWrap._m_CameraMoveRevert));
			Utils.RegisterFunc(L, -3, "CreateSubtitle", new lua_CSFunction(GameControllerWrap._m_CreateSubtitle));
			Utils.RegisterFunc(L, -3, "GiveACard", new lua_CSFunction(GameControllerWrap._m_GiveACard));
			Utils.RegisterFunc(L, -3, "GiveACardData", new lua_CSFunction(GameControllerWrap._m_GiveACardData));
			Utils.RegisterFunc(L, -3, "GiveCards", new lua_CSFunction(GameControllerWrap._m_GiveCards));
			Utils.RegisterFunc(L, -3, "ActiveTask", new lua_CSFunction(GameControllerWrap._m_ActiveTask));
			Utils.RegisterFunc(L, -3, "GetTask", new lua_CSFunction(GameControllerWrap._m_GetTask));
			Utils.RegisterFunc(L, -3, "SettleTask", new lua_CSFunction(GameControllerWrap._m_SettleTask));
			Utils.RegisterFunc(L, -3, "LoadModelOfType", new lua_CSFunction(GameControllerWrap._m_LoadModelOfType));
			Utils.RegisterFunc(L, -3, "ShowGuideCanvas", new lua_CSFunction(GameControllerWrap._m_ShowGuideCanvas));
			Utils.RegisterFunc(L, -3, "HasEmptCardSlotOnPlayerTable", new lua_CSFunction(GameControllerWrap._m_HasEmptCardSlotOnPlayerTable));
			Utils.RegisterFunc(L, -3, "ShowAmountText", new lua_CSFunction(GameControllerWrap._m_ShowAmountText));
			Utils.RegisterFunc(L, -3, "ShowLogicChanged", new lua_CSFunction(GameControllerWrap._m_ShowLogicChanged));
			Utils.RegisterFunc(L, -3, "GetHeroDataByLevel", new lua_CSFunction(GameControllerWrap._m_GetHeroDataByLevel));
			Utils.RegisterFunc(L, -3, "GetEmptySlotDataByCardTag", new lua_CSFunction(GameControllerWrap._m_GetEmptySlotDataByCardTag));
			Utils.RegisterFunc(L, -3, "GetEmptySlotDataByCardData", new lua_CSFunction(GameControllerWrap._m_GetEmptySlotDataByCardData));
			Utils.RegisterFunc(L, -2, "IsTimeStop", new lua_CSFunction(GameControllerWrap._g_get_IsTimeStop));
			Utils.RegisterFunc(L, -2, "GameEventManager", new lua_CSFunction(GameControllerWrap._g_get_GameEventManager));
			Utils.RegisterFunc(L, -2, "AsyncEventManager", new lua_CSFunction(GameControllerWrap._g_get_AsyncEventManager));
			Utils.RegisterFunc(L, -2, "GameLogic", new lua_CSFunction(GameControllerWrap._g_get_GameLogic));
			Utils.RegisterFunc(L, -2, "PlayerToy", new lua_CSFunction(GameControllerWrap._g_get_PlayerToy));
			Utils.RegisterFunc(L, -2, "PlayerCardSlot", new lua_CSFunction(GameControllerWrap._g_get_PlayerCardSlot));
			Utils.RegisterFunc(L, -2, "CardSlotsOnPlayerTable", new lua_CSFunction(GameControllerWrap._g_get_CardSlotsOnPlayerTable));
			Utils.RegisterFunc(L, -2, "PlayerSlotSets", new lua_CSFunction(GameControllerWrap._g_get_PlayerSlotSets));
			Utils.RegisterFunc(L, -2, "HomeTable", new lua_CSFunction(GameControllerWrap._g_get_HomeTable));
			Utils.RegisterFunc(L, -2, "PlayerTable", new lua_CSFunction(GameControllerWrap._g_get_PlayerTable));
			Utils.RegisterFunc(L, -2, "GameSpeed", new lua_CSFunction(GameControllerWrap._g_get_GameSpeed));
			Utils.RegisterFunc(L, -2, "CardSlotsOnPlayerTableWidth", new lua_CSFunction(GameControllerWrap._g_get_CardSlotsOnPlayerTableWidth));
			Utils.RegisterFunc(L, -2, "CardSlotsOnPlayerTableHeight", new lua_CSFunction(GameControllerWrap._g_get_CardSlotsOnPlayerTableHeight));
			Utils.RegisterFunc(L, -2, "playerTableText", new lua_CSFunction(GameControllerWrap._g_get_playerTableText));
			Utils.RegisterFunc(L, -2, "UICamera", new lua_CSFunction(GameControllerWrap._g_get_UICamera));
			Utils.RegisterFunc(L, -2, "PlayerTableSlotParent", new lua_CSFunction(GameControllerWrap._g_get_PlayerTableSlotParent));
			Utils.RegisterFunc(L, -2, "WorldTableSlotParent", new lua_CSFunction(GameControllerWrap._g_get_WorldTableSlotParent));
			Utils.RegisterFunc(L, -2, "UndisplaySlotPrefab", new lua_CSFunction(GameControllerWrap._g_get_UndisplaySlotPrefab));
			Utils.RegisterFunc(L, -2, "CardsFromMods", new lua_CSFunction(GameControllerWrap._g_get_CardsFromMods));
			Utils.RegisterFunc(L, -2, "UIController", new lua_CSFunction(GameControllerWrap._g_get_UIController));
			Utils.RegisterFunc(L, -2, "DialogueController", new lua_CSFunction(GameControllerWrap._g_get_DialogueController));
			Utils.RegisterFunc(L, -2, "GameData", new lua_CSFunction(GameControllerWrap._g_get_GameData));
			Utils.RegisterFunc(L, -2, "CameraTrans", new lua_CSFunction(GameControllerWrap._g_get_CameraTrans));
			Utils.RegisterFunc(L, -2, "Opposite", new lua_CSFunction(GameControllerWrap._g_get_Opposite));
			Utils.RegisterFunc(L, -2, "CurrentArea", new lua_CSFunction(GameControllerWrap._g_get_CurrentArea));
			Utils.RegisterFunc(L, -2, "CurrentTable", new lua_CSFunction(GameControllerWrap._g_get_CurrentTable));
			Utils.RegisterFunc(L, -2, "NextArea", new lua_CSFunction(GameControllerWrap._g_get_NextArea));
			Utils.RegisterFunc(L, -2, "NextTable", new lua_CSFunction(GameControllerWrap._g_get_NextTable));
			Utils.RegisterFunc(L, -2, "NextAreaData", new lua_CSFunction(GameControllerWrap._g_get_NextAreaData));
			Utils.RegisterFunc(L, -2, "LastArea", new lua_CSFunction(GameControllerWrap._g_get_LastArea));
			Utils.RegisterFunc(L, -2, "Effect", new lua_CSFunction(GameControllerWrap._g_get_Effect));
			Utils.RegisterFunc(L, -2, "CurrentAct", new lua_CSFunction(GameControllerWrap._g_get_CurrentAct));
			Utils.RegisterFunc(L, -2, "Evental", new lua_CSFunction(GameControllerWrap._g_get_Evental));
			Utils.RegisterFunc(L, -2, "EventalTable", new lua_CSFunction(GameControllerWrap._g_get_EventalTable));
			Utils.RegisterFunc(L, -2, "IDIndex", new lua_CSFunction(GameControllerWrap._g_get_IDIndex));
			Utils.RegisterFunc(L, -2, "CardDataInWorldMap", new lua_CSFunction(GameControllerWrap._g_get_CardDataInWorldMap));
			Utils.RegisterFunc(L, -2, "CardDataModMap", new lua_CSFunction(GameControllerWrap._g_get_CardDataModMap));
			Utils.RegisterFunc(L, -2, "BuildingModMap", new lua_CSFunction(GameControllerWrap._g_get_BuildingModMap));
			Utils.RegisterFunc(L, -2, "AreaDataModMap", new lua_CSFunction(GameControllerWrap._g_get_AreaDataModMap));
			Utils.RegisterFunc(L, -2, "BookDataModMap", new lua_CSFunction(GameControllerWrap._g_get_BookDataModMap));
			Utils.RegisterFunc(L, -2, "TaskDataMap", new lua_CSFunction(GameControllerWrap._g_get_TaskDataMap));
			Utils.RegisterFunc(L, -2, "gameSettingInfo", new lua_CSFunction(GameControllerWrap._g_get_gameSettingInfo));
			Utils.RegisterFunc(L, -2, "RedLineSlots", new lua_CSFunction(GameControllerWrap._g_get_RedLineSlots));
			Utils.RegisterFunc(L, -2, "YellowLineSlots", new lua_CSFunction(GameControllerWrap._g_get_YellowLineSlots));
			Utils.RegisterFunc(L, -2, "BlueLineSlots", new lua_CSFunction(GameControllerWrap._g_get_BlueLineSlots));
			Utils.RegisterFunc(L, -2, "AllPersonEvents", new lua_CSFunction(GameControllerWrap._g_get_AllPersonEvents));
			Utils.RegisterFunc(L, -2, "WorldMoveArea", new lua_CSFunction(GameControllerWrap._g_get_WorldMoveArea));
			Utils.RegisterFunc(L, -2, "LogCtrl", new lua_CSFunction(GameControllerWrap._g_get_LogCtrl));
			Utils.RegisterFunc(L, -2, "CurrentCityID", new lua_CSFunction(GameControllerWrap._g_get_CurrentCityID));
			Utils.RegisterFunc(L, -2, "IsUseCommandLine", new lua_CSFunction(GameControllerWrap._g_get_IsUseCommandLine));
			Utils.RegisterFunc(L, -2, "PNGResourceCache", new lua_CSFunction(GameControllerWrap._g_get_PNGResourceCache));
			Utils.RegisterFunc(L, -2, "LuaLogicCache", new lua_CSFunction(GameControllerWrap._g_get_LuaLogicCache));
			Utils.RegisterFunc(L, -2, "jsonsFromWorkShop", new lua_CSFunction(GameControllerWrap._g_get_jsonsFromWorkShop));
			Utils.RegisterFunc(L, -2, "CurrentTableType", new lua_CSFunction(GameControllerWrap._g_get_CurrentTableType));
			Utils.RegisterFunc(L, -2, "PlayerTableTempArea", new lua_CSFunction(GameControllerWrap._g_get_PlayerTableTempArea));
			Utils.RegisterFunc(L, -2, "PublicArea", new lua_CSFunction(GameControllerWrap._g_get_PublicArea));
			Utils.RegisterFunc(L, -2, "PartnerArea", new lua_CSFunction(GameControllerWrap._g_get_PartnerArea));
			Utils.RegisterFunc(L, -2, "CityMap", new lua_CSFunction(GameControllerWrap._g_get_CityMap));
			Utils.RegisterFunc(L, -2, "Subtitle", new lua_CSFunction(GameControllerWrap._g_get_Subtitle));
			Utils.RegisterFunc(L, -2, "MainCamera", new lua_CSFunction(GameControllerWrap._g_get_MainCamera));
			Utils.RegisterFunc(L, -2, "Gear", new lua_CSFunction(GameControllerWrap._g_get_Gear));
			Utils.RegisterFunc(L, -2, "Gan", new lua_CSFunction(GameControllerWrap._g_get_Gan));
			Utils.RegisterFunc(L, -2, "GuideCanvas", new lua_CSFunction(GameControllerWrap._g_get_GuideCanvas));
			Utils.RegisterFunc(L, -2, "AmountText", new lua_CSFunction(GameControllerWrap._g_get_AmountText));
			Utils.RegisterFunc(L, -2, "HeroHomeCurrentHeroModID", new lua_CSFunction(GameControllerWrap._g_get_HeroHomeCurrentHeroModID));
			Utils.RegisterFunc(L, -1, "GameEventManager", new lua_CSFunction(GameControllerWrap._s_set_GameEventManager));
			Utils.RegisterFunc(L, -1, "AsyncEventManager", new lua_CSFunction(GameControllerWrap._s_set_AsyncEventManager));
			Utils.RegisterFunc(L, -1, "GameLogic", new lua_CSFunction(GameControllerWrap._s_set_GameLogic));
			Utils.RegisterFunc(L, -1, "PlayerToy", new lua_CSFunction(GameControllerWrap._s_set_PlayerToy));
			Utils.RegisterFunc(L, -1, "PlayerCardSlot", new lua_CSFunction(GameControllerWrap._s_set_PlayerCardSlot));
			Utils.RegisterFunc(L, -1, "CardSlotsOnPlayerTable", new lua_CSFunction(GameControllerWrap._s_set_CardSlotsOnPlayerTable));
			Utils.RegisterFunc(L, -1, "PlayerSlotSets", new lua_CSFunction(GameControllerWrap._s_set_PlayerSlotSets));
			Utils.RegisterFunc(L, -1, "HomeTable", new lua_CSFunction(GameControllerWrap._s_set_HomeTable));
			Utils.RegisterFunc(L, -1, "PlayerTable", new lua_CSFunction(GameControllerWrap._s_set_PlayerTable));
			Utils.RegisterFunc(L, -1, "GameSpeed", new lua_CSFunction(GameControllerWrap._s_set_GameSpeed));
			Utils.RegisterFunc(L, -1, "CardSlotsOnPlayerTableWidth", new lua_CSFunction(GameControllerWrap._s_set_CardSlotsOnPlayerTableWidth));
			Utils.RegisterFunc(L, -1, "CardSlotsOnPlayerTableHeight", new lua_CSFunction(GameControllerWrap._s_set_CardSlotsOnPlayerTableHeight));
			Utils.RegisterFunc(L, -1, "playerTableText", new lua_CSFunction(GameControllerWrap._s_set_playerTableText));
			Utils.RegisterFunc(L, -1, "UICamera", new lua_CSFunction(GameControllerWrap._s_set_UICamera));
			Utils.RegisterFunc(L, -1, "PlayerTableSlotParent", new lua_CSFunction(GameControllerWrap._s_set_PlayerTableSlotParent));
			Utils.RegisterFunc(L, -1, "WorldTableSlotParent", new lua_CSFunction(GameControllerWrap._s_set_WorldTableSlotParent));
			Utils.RegisterFunc(L, -1, "UndisplaySlotPrefab", new lua_CSFunction(GameControllerWrap._s_set_UndisplaySlotPrefab));
			Utils.RegisterFunc(L, -1, "CardsFromMods", new lua_CSFunction(GameControllerWrap._s_set_CardsFromMods));
			Utils.RegisterFunc(L, -1, "UIController", new lua_CSFunction(GameControllerWrap._s_set_UIController));
			Utils.RegisterFunc(L, -1, "DialogueController", new lua_CSFunction(GameControllerWrap._s_set_DialogueController));
			Utils.RegisterFunc(L, -1, "GameData", new lua_CSFunction(GameControllerWrap._s_set_GameData));
			Utils.RegisterFunc(L, -1, "CameraTrans", new lua_CSFunction(GameControllerWrap._s_set_CameraTrans));
			Utils.RegisterFunc(L, -1, "Opposite", new lua_CSFunction(GameControllerWrap._s_set_Opposite));
			Utils.RegisterFunc(L, -1, "CurrentArea", new lua_CSFunction(GameControllerWrap._s_set_CurrentArea));
			Utils.RegisterFunc(L, -1, "CurrentTable", new lua_CSFunction(GameControllerWrap._s_set_CurrentTable));
			Utils.RegisterFunc(L, -1, "NextArea", new lua_CSFunction(GameControllerWrap._s_set_NextArea));
			Utils.RegisterFunc(L, -1, "NextTable", new lua_CSFunction(GameControllerWrap._s_set_NextTable));
			Utils.RegisterFunc(L, -1, "NextAreaData", new lua_CSFunction(GameControllerWrap._s_set_NextAreaData));
			Utils.RegisterFunc(L, -1, "LastArea", new lua_CSFunction(GameControllerWrap._s_set_LastArea));
			Utils.RegisterFunc(L, -1, "Effect", new lua_CSFunction(GameControllerWrap._s_set_Effect));
			Utils.RegisterFunc(L, -1, "CurrentAct", new lua_CSFunction(GameControllerWrap._s_set_CurrentAct));
			Utils.RegisterFunc(L, -1, "Evental", new lua_CSFunction(GameControllerWrap._s_set_Evental));
			Utils.RegisterFunc(L, -1, "EventalTable", new lua_CSFunction(GameControllerWrap._s_set_EventalTable));
			Utils.RegisterFunc(L, -1, "IDIndex", new lua_CSFunction(GameControllerWrap._s_set_IDIndex));
			Utils.RegisterFunc(L, -1, "CardDataInWorldMap", new lua_CSFunction(GameControllerWrap._s_set_CardDataInWorldMap));
			Utils.RegisterFunc(L, -1, "CardDataModMap", new lua_CSFunction(GameControllerWrap._s_set_CardDataModMap));
			Utils.RegisterFunc(L, -1, "BuildingModMap", new lua_CSFunction(GameControllerWrap._s_set_BuildingModMap));
			Utils.RegisterFunc(L, -1, "AreaDataModMap", new lua_CSFunction(GameControllerWrap._s_set_AreaDataModMap));
			Utils.RegisterFunc(L, -1, "BookDataModMap", new lua_CSFunction(GameControllerWrap._s_set_BookDataModMap));
			Utils.RegisterFunc(L, -1, "TaskDataMap", new lua_CSFunction(GameControllerWrap._s_set_TaskDataMap));
			Utils.RegisterFunc(L, -1, "gameSettingInfo", new lua_CSFunction(GameControllerWrap._s_set_gameSettingInfo));
			Utils.RegisterFunc(L, -1, "RedLineSlots", new lua_CSFunction(GameControllerWrap._s_set_RedLineSlots));
			Utils.RegisterFunc(L, -1, "YellowLineSlots", new lua_CSFunction(GameControllerWrap._s_set_YellowLineSlots));
			Utils.RegisterFunc(L, -1, "BlueLineSlots", new lua_CSFunction(GameControllerWrap._s_set_BlueLineSlots));
			Utils.RegisterFunc(L, -1, "AllPersonEvents", new lua_CSFunction(GameControllerWrap._s_set_AllPersonEvents));
			Utils.RegisterFunc(L, -1, "WorldMoveArea", new lua_CSFunction(GameControllerWrap._s_set_WorldMoveArea));
			Utils.RegisterFunc(L, -1, "LogCtrl", new lua_CSFunction(GameControllerWrap._s_set_LogCtrl));
			Utils.RegisterFunc(L, -1, "CurrentCityID", new lua_CSFunction(GameControllerWrap._s_set_CurrentCityID));
			Utils.RegisterFunc(L, -1, "IsUseCommandLine", new lua_CSFunction(GameControllerWrap._s_set_IsUseCommandLine));
			Utils.RegisterFunc(L, -1, "PNGResourceCache", new lua_CSFunction(GameControllerWrap._s_set_PNGResourceCache));
			Utils.RegisterFunc(L, -1, "LuaLogicCache", new lua_CSFunction(GameControllerWrap._s_set_LuaLogicCache));
			Utils.RegisterFunc(L, -1, "jsonsFromWorkShop", new lua_CSFunction(GameControllerWrap._s_set_jsonsFromWorkShop));
			Utils.RegisterFunc(L, -1, "CurrentTableType", new lua_CSFunction(GameControllerWrap._s_set_CurrentTableType));
			Utils.RegisterFunc(L, -1, "PlayerTableTempArea", new lua_CSFunction(GameControllerWrap._s_set_PlayerTableTempArea));
			Utils.RegisterFunc(L, -1, "PublicArea", new lua_CSFunction(GameControllerWrap._s_set_PublicArea));
			Utils.RegisterFunc(L, -1, "PartnerArea", new lua_CSFunction(GameControllerWrap._s_set_PartnerArea));
			Utils.RegisterFunc(L, -1, "CityMap", new lua_CSFunction(GameControllerWrap._s_set_CityMap));
			Utils.RegisterFunc(L, -1, "Subtitle", new lua_CSFunction(GameControllerWrap._s_set_Subtitle));
			Utils.RegisterFunc(L, -1, "MainCamera", new lua_CSFunction(GameControllerWrap._s_set_MainCamera));
			Utils.RegisterFunc(L, -1, "Gear", new lua_CSFunction(GameControllerWrap._s_set_Gear));
			Utils.RegisterFunc(L, -1, "Gan", new lua_CSFunction(GameControllerWrap._s_set_Gan));
			Utils.RegisterFunc(L, -1, "GuideCanvas", new lua_CSFunction(GameControllerWrap._s_set_GuideCanvas));
			Utils.RegisterFunc(L, -1, "AmountText", new lua_CSFunction(GameControllerWrap._s_set_AmountText));
			Utils.RegisterFunc(L, -1, "HeroHomeCurrentHeroModID", new lua_CSFunction(GameControllerWrap._s_set_HeroHomeCurrentHeroModID));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(GameControllerWrap.__CreateInstance), 2, 4, 4);
			Utils.RegisterFunc(L, -4, "getInstance", new lua_CSFunction(GameControllerWrap._m_getInstance_xlua_st_));
			Utils.RegisterFunc(L, -2, "ins", new lua_CSFunction(GameControllerWrap._g_get_ins));
			Utils.RegisterFunc(L, -2, "RowColor", new lua_CSFunction(GameControllerWrap._g_get_RowColor));
			Utils.RegisterFunc(L, -2, "GameSavingSyncLock", new lua_CSFunction(GameControllerWrap._g_get_GameSavingSyncLock));
			Utils.RegisterFunc(L, -2, "PersistentDataPath", new lua_CSFunction(GameControllerWrap._g_get_PersistentDataPath));
			Utils.RegisterFunc(L, -1, "ins", new lua_CSFunction(GameControllerWrap._s_set_ins));
			Utils.RegisterFunc(L, -1, "RowColor", new lua_CSFunction(GameControllerWrap._s_set_RowColor));
			Utils.RegisterFunc(L, -1, "GameSavingSyncLock", new lua_CSFunction(GameControllerWrap._s_set_GameSavingSyncLock));
			Utils.RegisterFunc(L, -1, "PersistentDataPath", new lua_CSFunction(GameControllerWrap._s_set_PersistentDataPath));
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
					GameController o = new GameController();
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
			return Lua.luaL_error(L, "invalid arguments to GameController constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_getInstance_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController instance = GameController.getInstance();
				objectTranslator.Push(L, instance);
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
		private static int _m_SaveGame(IntPtr L)
		{
			int result;
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).SaveGame();
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
		private static int _m_LoadGame(IntPtr L)
		{
			int result;
			try
			{
				bool value = ((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).LoadGame();
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
		private static int _m_DeleteAllSaveData(IntPtr L)
		{
			int result;
			try
			{
				bool value = ((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DeleteAllSaveData();
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
		private static int _m_LoadHomeScene(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				IEnumerator o = ((GameController)objectTranslator.FastGetCSObj(L, 1)).LoadHomeScene();
				objectTranslator.PushAny(L, o);
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
		private static int _m_LoadGuideHomeScene(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				IEnumerator o = ((GameController)objectTranslator.FastGetCSObj(L, 1)).LoadGuideHomeScene();
				objectTranslator.PushAny(L, o);
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
		private static int _m_ShowTable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					gameController.ShowTable();
					return 0;
				}
				if (num == 3 && objectTranslator.Assignable<TableType>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					TableType tableType;
					objectTranslator.Get<TableType>(L, 2, out tableType);
					bool hideMainTable = Lua.lua_toboolean(L, 3);
					IEnumerator o = gameController.ShowTable(tableType, hideMainTable);
					objectTranslator.PushAny(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<TableType>(L, 2))
				{
					TableType tableType2;
					objectTranslator.Get<TableType>(L, 2, out tableType2);
					IEnumerator o2 = gameController.ShowTable(tableType2, false);
					objectTranslator.PushAny(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to GameController.ShowTable!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ChangeTimePause(IntPtr L)
		{
			int result;
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				bool value = Lua.lua_toboolean(L, 2);
				gameController.ChangeTimePause(value);
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
		private static int _m_ChangeTimeScale(IntPtr L)
		{
			int result;
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				float scale = (float)Lua.lua_tonumber(L, 2);
				gameController.ChangeTimeScale(scale);
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
		private static int _m_func(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				CardSlot oldCardSlot = (CardSlot)objectTranslator.GetObject(L, 2, typeof(CardSlot));
				CardSlot newCardSlot = (CardSlot)objectTranslator.GetObject(L, 3, typeof(CardSlot));
				Card card = (Card)objectTranslator.GetObject(L, 4, typeof(Card));
				gameController.func(oldCardSlot, newCardSlot, card);
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
		private static int _m_EnterLoadScene(IntPtr L)
		{
			int result;
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).EnterLoadScene();
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
		private static int _m_InitWorld(IntPtr L)
		{
			int result;
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).InitWorld();
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
		private static int _m_InitPlayerTable(IntPtr L)
		{
			int result;
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).InitPlayerTable();
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
		private static int _m_GetCurrentAreaData(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AreaData currentAreaData = ((GameController)objectTranslator.FastGetCSObj(L, 1)).GetCurrentAreaData();
				objectTranslator.Push(L, currentAreaData);
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
		private static int _m_InitCOOPPlayerTable(IntPtr L)
		{
			int result;
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).InitCOOPPlayerTable();
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
		private static int _m_InitVSPlayerTable(IntPtr L)
		{
			int result;
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).InitVSPlayerTable();
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
		private static int _m_CreatePlayer(IntPtr L)
		{
			int result;
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				string name = Lua.lua_tostring(L, 2);
				gameController.CreatePlayer(name);
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
		private static int _m_IsPlayerCardSlotData(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				CardSlotData cardSlot = (CardSlotData)objectTranslator.GetObject(L, 2, typeof(CardSlotData));
				bool value = gameController.IsPlayerCardSlotData(cardSlot);
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
		private static int _m_FindCard(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				string name = Lua.lua_tostring(L, 2);
				Card o = gameController.FindCard(name);
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
		private static int _m_FindCardOnPlayerTable(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				string name = Lua.lua_tostring(L, 2);
				Card o = gameController.FindCardOnPlayerTable(name);
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
		private static int _m_FindCardOnPlayerTableCount(IntPtr L)
		{
			int result;
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				string name = Lua.lua_tostring(L, 2);
				int value = gameController.FindCardOnPlayerTableCount(name);
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
		private static int _m_FindCardOnPlayerTableByType(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				CardData targetCardData = (CardData)objectTranslator.GetObject(L, 2, typeof(CardData));
				int value = gameController.FindCardOnPlayerTableByType(targetCardData);
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
		private static int _m_OnMoveInTheWorld(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				Area middleArea = (Area)objectTranslator.GetObject(L, 2, typeof(Area));
				Area nextArea = (Area)objectTranslator.GetObject(L, 3, typeof(Area));
				gameController.OnMoveInTheWorld(middleArea, nextArea);
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
		private static int _m_RotateCardAnimate(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				CardSlot cardSlot = (CardSlot)objectTranslator.GetObject(L, 2, typeof(CardSlot));
				string newCardID = Lua.lua_tostring(L, 3);
				IEnumerator o = gameController.RotateCardAnimate(cardSlot, newCardID);
				objectTranslator.PushAny(L, o);
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
		private static int _m_SkipBtn(IntPtr L)
		{
			int result;
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).SkipBtn();
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
		private static int _m_ChangeCurrentArea(IntPtr L)
		{
			int result;
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).ChangeCurrentArea();
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
		private static int _m_OnDayPast(IntPtr L)
		{
			int result;
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).OnDayPast();
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
		private static int _m_UnlockCardSlot(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				int line = Lua.xlua_tointeger(L, 2);
				IEnumerator o = gameController.UnlockCardSlot(line);
				objectTranslator.PushAny(L, o);
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
		private static int _m_OnTableChange(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 3 && objectTranslator.Assignable<AreaData>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					AreaData nextAreaData = (AreaData)objectTranslator.GetObject(L, 2, typeof(AreaData));
					bool playAnimation = Lua.lua_toboolean(L, 3);
					gameController.OnTableChange(nextAreaData, playAnimation);
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<AreaData>(L, 2))
				{
					AreaData nextAreaData2 = (AreaData)objectTranslator.GetObject(L, 2, typeof(AreaData));
					gameController.OnTableChange(nextAreaData2, true);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to GameController.OnTableChange!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_CameraMove(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				float view = (float)Lua.lua_tonumber(L, 2);
				Vector3 pos;
				objectTranslator.Get(L, 3, out pos);
				Vector3 rot;
				objectTranslator.Get(L, 4, out rot);
				float duration = (float)Lua.lua_tonumber(L, 5);
				IEnumerator o = gameController.CameraMove(view, pos, rot, duration);
				objectTranslator.PushAny(L, o);
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
		private static int _m_CameraMoveRevert(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				float view = (float)Lua.lua_tonumber(L, 2);
				Vector3 pos;
				objectTranslator.Get(L, 3, out pos);
				Vector3 rot;
				objectTranslator.Get(L, 4, out rot);
				float duration = (float)Lua.lua_tonumber(L, 5);
				IEnumerator o = gameController.CameraMoveRevert(view, pos, rot, duration);
				objectTranslator.PushAny(L, o);
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
		private static int _m_CreateSubtitle(IntPtr L)
		{
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 6 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6))
				{
					string content = Lua.lua_tostring(L, 2);
					float openTime = (float)Lua.lua_tonumber(L, 3);
					float showTime = (float)Lua.lua_tonumber(L, 4);
					float closeTime = (float)Lua.lua_tonumber(L, 5);
					float fontScale = (float)Lua.lua_tonumber(L, 6);
					gameController.CreateSubtitle(content, openTime, showTime, closeTime, fontScale);
					return 0;
				}
				if (num == 5 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					string content2 = Lua.lua_tostring(L, 2);
					float openTime2 = (float)Lua.lua_tonumber(L, 3);
					float showTime2 = (float)Lua.lua_tonumber(L, 4);
					float closeTime2 = (float)Lua.lua_tonumber(L, 5);
					gameController.CreateSubtitle(content2, openTime2, showTime2, closeTime2, 1f);
					return 0;
				}
				if (num == 4 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					string content3 = Lua.lua_tostring(L, 2);
					float openTime3 = (float)Lua.lua_tonumber(L, 3);
					float showTime3 = (float)Lua.lua_tonumber(L, 4);
					gameController.CreateSubtitle(content3, openTime3, showTime3, 1f, 1f);
					return 0;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					string content4 = Lua.lua_tostring(L, 2);
					float openTime4 = (float)Lua.lua_tonumber(L, 3);
					gameController.CreateSubtitle(content4, openTime4, 2f, 1f, 1f);
					return 0;
				}
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string content5 = Lua.lua_tostring(L, 2);
					gameController.CreateSubtitle(content5, 1f, 2f, 1f, 1f);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to GameController.CreateSubtitle!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GiveACard(IntPtr L)
		{
			int result;
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				string name = Lua.lua_tostring(L, 2);
				gameController.GiveACard(name);
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
		private static int _m_GiveACardData(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				CardData cardData = (CardData)objectTranslator.GetObject(L, 2, typeof(CardData));
				gameController.GiveACardData(cardData);
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
		private static int _m_GiveCards(IntPtr L)
		{
			int result;
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				string str = Lua.lua_tostring(L, 2);
				gameController.GiveCards(str);
				result = 0;
			}
			catch (Exception ex)
			{
				string str2 = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str2 + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ActiveTask(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<Card>(L, 3))
				{
					string name = Lua.lua_tostring(L, 2);
					Card source = (Card)objectTranslator.GetObject(L, 3, typeof(Card));
					gameController.ActiveTask(name, source);
					return 0;
				}
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string name2 = Lua.lua_tostring(L, 2);
					gameController.ActiveTask(name2, null);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to GameController.ActiveTask!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetTask(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				string name = Lua.lua_tostring(L, 2);
				TaskData task = gameController.GetTask(name);
				objectTranslator.Push(L, task);
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
		private static int _m_SettleTask(IntPtr L)
		{
			int result;
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				string name = Lua.lua_tostring(L, 2);
				gameController.SettleTask(name);
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
		private static int _m_LoadModelOfType(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					string modelName = Lua.lua_tostring(L, 2);
					int modelType = Lua.xlua_tointeger(L, 3);
					GameObject o = gameController.LoadModelOfType(modelName, modelType);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string modelName2 = Lua.lua_tostring(L, 2);
					GameObject o2 = gameController.LoadModelOfType(modelName2, 0);
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
			return Lua.luaL_error(L, "invalid arguments to GameController.LoadModelOfType!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ShowGuideCanvas(IntPtr L)
		{
			int result;
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int startIndex = Lua.xlua_tointeger(L, 2);
				int endIndex = Lua.xlua_tointeger(L, 3);
				gameController.ShowGuideCanvas(startIndex, endIndex);
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
		private static int _m_HasEmptCardSlotOnPlayerTable(IntPtr L)
		{
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					int value = gameController.HasEmptCardSlotOnPlayerTable();
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 2 && (LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) || Lua.lua_isuint64(L, 2)))
				{
					ulong tag = Lua.lua_touint64(L, 2);
					int value2 = gameController.HasEmptCardSlotOnPlayerTable(tag);
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
			return Lua.luaL_error(L, "invalid arguments to GameController.HasEmptCardSlotOnPlayerTable!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ShowAmountText(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 7 && objectTranslator.Assignable<Vector3>(L, 2) && (Lua.lua_isnil(L, 3) || Lua.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<Color>(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 6) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 7))
				{
					Vector3 position;
					objectTranslator.Get(L, 2, out position);
					string value = Lua.lua_tostring(L, 3);
					Color color;
					objectTranslator.Get(L, 4, out color);
					int index = Lua.xlua_tointeger(L, 5);
					bool pop = Lua.lua_toboolean(L, 6);
					bool loop = Lua.lua_toboolean(L, 7);
					gameController.ShowAmountText(position, value, color, index, pop, loop);
					return 0;
				}
				if (num == 6 && objectTranslator.Assignable<Vector3>(L, 2) && (Lua.lua_isnil(L, 3) || Lua.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<Color>(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 6))
				{
					Vector3 position2;
					objectTranslator.Get(L, 2, out position2);
					string value2 = Lua.lua_tostring(L, 3);
					Color color2;
					objectTranslator.Get(L, 4, out color2);
					int index2 = Lua.xlua_tointeger(L, 5);
					bool pop2 = Lua.lua_toboolean(L, 6);
					gameController.ShowAmountText(position2, value2, color2, index2, pop2, false);
					return 0;
				}
				if (num == 5 && objectTranslator.Assignable<Vector3>(L, 2) && (Lua.lua_isnil(L, 3) || Lua.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<Color>(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					Vector3 position3;
					objectTranslator.Get(L, 2, out position3);
					string value3 = Lua.lua_tostring(L, 3);
					Color color3;
					objectTranslator.Get(L, 4, out color3);
					int index3 = Lua.xlua_tointeger(L, 5);
					gameController.ShowAmountText(position3, value3, color3, index3, false, false);
					return 0;
				}
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && (Lua.lua_isnil(L, 3) || Lua.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<Color>(L, 4))
				{
					Vector3 position4;
					objectTranslator.Get(L, 2, out position4);
					string value4 = Lua.lua_tostring(L, 3);
					Color color4;
					objectTranslator.Get(L, 4, out color4);
					gameController.ShowAmountText(position4, value4, color4, 0, false, false);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to GameController.ShowAmountText!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ShowLogicChanged(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				Vector3 position;
				objectTranslator.Get(L, 2, out position);
				string value = Lua.lua_tostring(L, 3);
				CardLogicColor color;
				objectTranslator.Get<CardLogicColor>(L, 4, out color);
				gameController.ShowLogicChanged(position, value, color);
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
		private static int _m_GetHeroDataByLevel(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				CardData data = (CardData)objectTranslator.GetObject(L, 2, typeof(CardData));
				CardData heroDataByLevel = gameController.GetHeroDataByLevel(data);
				objectTranslator.Push(L, heroDataByLevel);
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
		private static int _m_GetEmptySlotDataByCardTag(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				TagMap type;
				objectTranslator.Get<TagMap>(L, 2, out type);
				CardSlotData emptySlotDataByCardTag = gameController.GetEmptySlotDataByCardTag(type);
				objectTranslator.Push(L, emptySlotDataByCardTag);
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
		private static int _m_GetEmptySlotDataByCardData(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				CardData data = (CardData)objectTranslator.GetObject(L, 2, typeof(CardData));
				CardSlotData emptySlotDataByCardData = gameController.GetEmptySlotDataByCardData(data);
				objectTranslator.Push(L, emptySlotDataByCardData);
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
		private static int _g_get_IsTimeStop(IntPtr L)
		{
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, gameController.IsTimeStop);
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
		private static int _g_get_ins(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).Push(L, GameController.ins);
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
		private static int _g_get_RowColor(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).Push(L, GameController.RowColor);
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
		private static int _g_get_GameSavingSyncLock(IntPtr L)
		{
			try
			{
				Lua.lua_pushboolean(L, GameController.GameSavingSyncLock);
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
		private static int _g_get_PersistentDataPath(IntPtr L)
		{
			try
			{
				Lua.lua_pushstring(L, GameController.PersistentDataPath);
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
		private static int _g_get_GameEventManager(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.GameEventManager);
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
		private static int _g_get_AsyncEventManager(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.AsyncEventManager);
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
		private static int _g_get_GameLogic(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.GameLogic);
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
		private static int _g_get_PlayerToy(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.PlayerToy);
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
		private static int _g_get_PlayerCardSlot(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.PlayerCardSlot);
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
		private static int _g_get_CardSlotsOnPlayerTable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.CardSlotsOnPlayerTable);
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
		private static int _g_get_PlayerSlotSets(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.PlayerSlotSets);
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
		private static int _g_get_HomeTable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.HomeTable);
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
		private static int _g_get_PlayerTable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.PlayerTable);
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
		private static int _g_get_GameSpeed(IntPtr L)
		{
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, gameController.GameSpeed);
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
		private static int _g_get_CardSlotsOnPlayerTableWidth(IntPtr L)
		{
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, gameController.CardSlotsOnPlayerTableWidth);
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
		private static int _g_get_CardSlotsOnPlayerTableHeight(IntPtr L)
		{
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, gameController.CardSlotsOnPlayerTableHeight);
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
		private static int _g_get_playerTableText(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.playerTableText);
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
		private static int _g_get_UICamera(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.UICamera);
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
		private static int _g_get_PlayerTableSlotParent(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.PlayerTableSlotParent);
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
		private static int _g_get_WorldTableSlotParent(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.WorldTableSlotParent);
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
		private static int _g_get_UndisplaySlotPrefab(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.UndisplaySlotPrefab);
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
		private static int _g_get_CardsFromMods(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.CardsFromMods);
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
		private static int _g_get_UIController(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.UIController);
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
		private static int _g_get_DialogueController(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.DialogueController);
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
		private static int _g_get_GameData(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.GameData);
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
		private static int _g_get_CameraTrans(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.CameraTrans);
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
		private static int _g_get_Opposite(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.Opposite);
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
		private static int _g_get_CurrentArea(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.CurrentArea);
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
		private static int _g_get_CurrentTable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.CurrentTable);
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
		private static int _g_get_NextArea(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.NextArea);
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
		private static int _g_get_NextTable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.NextTable);
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
		private static int _g_get_NextAreaData(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.NextAreaData);
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
		private static int _g_get_LastArea(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.LastArea);
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
		private static int _g_get_Effect(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.Effect);
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
		private static int _g_get_CurrentAct(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.CurrentAct);
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
		private static int _g_get_Evental(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.Evental);
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
		private static int _g_get_EventalTable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.EventalTable);
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
		private static int _g_get_IDIndex(IntPtr L)
		{
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, gameController.IDIndex);
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
		private static int _g_get_CardDataInWorldMap(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.CardDataInWorldMap);
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
		private static int _g_get_CardDataModMap(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.CardDataModMap);
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
		private static int _g_get_BuildingModMap(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.BuildingModMap);
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
		private static int _g_get_AreaDataModMap(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.AreaDataModMap);
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
		private static int _g_get_BookDataModMap(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.BookDataModMap);
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
		private static int _g_get_TaskDataMap(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.TaskDataMap);
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
		private static int _g_get_gameSettingInfo(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.gameSettingInfo);
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
		private static int _g_get_RedLineSlots(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.RedLineSlots);
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
		private static int _g_get_YellowLineSlots(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.YellowLineSlots);
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
		private static int _g_get_BlueLineSlots(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.BlueLineSlots);
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
		private static int _g_get_AllPersonEvents(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.AllPersonEvents);
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
		private static int _g_get_WorldMoveArea(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.WorldMoveArea);
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
		private static int _g_get_LogCtrl(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.LogCtrl);
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
		private static int _g_get_CurrentCityID(IntPtr L)
		{
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, gameController.CurrentCityID);
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
		private static int _g_get_IsUseCommandLine(IntPtr L)
		{
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, gameController.IsUseCommandLine);
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
		private static int _g_get_PNGResourceCache(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.PNGResourceCache);
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
		private static int _g_get_LuaLogicCache(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.LuaLogicCache);
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
		private static int _g_get_jsonsFromWorkShop(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.jsonsFromWorkShop);
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
		private static int _g_get_CurrentTableType(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.CurrentTableType);
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
		private static int _g_get_PlayerTableTempArea(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.PlayerTableTempArea);
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
		private static int _g_get_PublicArea(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.PublicArea);
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
		private static int _g_get_PartnerArea(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.PartnerArea);
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
		private static int _g_get_CityMap(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.CityMap);
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
		private static int _g_get_Subtitle(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.Subtitle);
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
		private static int _g_get_MainCamera(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.MainCamera);
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
		private static int _g_get_Gear(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.Gear);
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
		private static int _g_get_Gan(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.Gan);
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
		private static int _g_get_GuideCanvas(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.GuideCanvas);
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
		private static int _g_get_AmountText(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameController.AmountText);
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
		private static int _g_get_HeroHomeCurrentHeroModID(IntPtr L)
		{
			try
			{
				GameController gameController = (GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, gameController.HeroHomeCurrentHeroModID);
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
		private static int _s_set_ins(IntPtr L)
		{
			try
			{
				GameController.ins = (GameController)ObjectTranslatorPool.Instance.Find(L).GetObject(L, 1, typeof(GameController));
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
		private static int _s_set_RowColor(IntPtr L)
		{
			try
			{
				GameController.RowColor = (Color32[])ObjectTranslatorPool.Instance.Find(L).GetObject(L, 1, typeof(Color32[]));
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
		private static int _s_set_GameSavingSyncLock(IntPtr L)
		{
			try
			{
				GameController.GameSavingSyncLock = Lua.lua_toboolean(L, 1);
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
		private static int _s_set_PersistentDataPath(IntPtr L)
		{
			try
			{
				GameController.PersistentDataPath = Lua.lua_tostring(L, 1);
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
		private static int _s_set_GameEventManager(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).GameEventManager = (GameEventManager)objectTranslator.GetObject(L, 2, typeof(GameEventManager));
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
		private static int _s_set_AsyncEventManager(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).AsyncEventManager = (AsyncEventManager)objectTranslator.GetObject(L, 2, typeof(AsyncEventManager));
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
		private static int _s_set_GameLogic(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).GameLogic = (GameLogic)objectTranslator.GetObject(L, 2, typeof(GameLogic));
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
		private static int _s_set_PlayerToy(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).PlayerToy = (Card)objectTranslator.GetObject(L, 2, typeof(Card));
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
		private static int _s_set_PlayerCardSlot(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).PlayerCardSlot = (CardSlot)objectTranslator.GetObject(L, 2, typeof(CardSlot));
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
		private static int _s_set_CardSlotsOnPlayerTable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).CardSlotsOnPlayerTable = (CardSlot[])objectTranslator.GetObject(L, 2, typeof(CardSlot[]));
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
		private static int _s_set_PlayerSlotSets(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).PlayerSlotSets = (List<CardSlotData>)objectTranslator.GetObject(L, 2, typeof(List<CardSlotData>));
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
		private static int _s_set_HomeTable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).HomeTable = (Transform)objectTranslator.GetObject(L, 2, typeof(Transform));
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
		private static int _s_set_PlayerTable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).PlayerTable = (Transform)objectTranslator.GetObject(L, 2, typeof(Transform));
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
		private static int _s_set_GameSpeed(IntPtr L)
		{
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).GameSpeed = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_CardSlotsOnPlayerTableWidth(IntPtr L)
		{
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).CardSlotsOnPlayerTableWidth = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_CardSlotsOnPlayerTableHeight(IntPtr L)
		{
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).CardSlotsOnPlayerTableHeight = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_playerTableText(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).playerTableText = (PlayerTableTextLabel)objectTranslator.GetObject(L, 2, typeof(PlayerTableTextLabel));
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
		private static int _s_set_UICamera(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).UICamera = (Camera)objectTranslator.GetObject(L, 2, typeof(Camera));
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
		private static int _s_set_PlayerTableSlotParent(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).PlayerTableSlotParent = (Transform)objectTranslator.GetObject(L, 2, typeof(Transform));
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
		private static int _s_set_WorldTableSlotParent(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).WorldTableSlotParent = (Transform)objectTranslator.GetObject(L, 2, typeof(Transform));
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
		private static int _s_set_UndisplaySlotPrefab(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).UndisplaySlotPrefab = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
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
		private static int _s_set_CardsFromMods(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).CardsFromMods = (List<string>)objectTranslator.GetObject(L, 2, typeof(List<string>));
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
		private static int _s_set_UIController(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).UIController = (UIController)objectTranslator.GetObject(L, 2, typeof(UIController));
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
		private static int _s_set_DialogueController(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).DialogueController = (DialogueController)objectTranslator.GetObject(L, 2, typeof(DialogueController));
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
		private static int _s_set_GameData(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).GameData = (GameData)objectTranslator.GetObject(L, 2, typeof(GameData));
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
		private static int _s_set_CameraTrans(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).CameraTrans = (Transform)objectTranslator.GetObject(L, 2, typeof(Transform));
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
		private static int _s_set_Opposite(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).Opposite = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
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
		private static int _s_set_CurrentArea(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).CurrentArea = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
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
		private static int _s_set_CurrentTable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).CurrentTable = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
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
		private static int _s_set_NextArea(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).NextArea = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
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
		private static int _s_set_NextTable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).NextTable = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
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
		private static int _s_set_NextAreaData(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).NextAreaData = (AreaData)objectTranslator.GetObject(L, 2, typeof(AreaData));
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
		private static int _s_set_LastArea(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).LastArea = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
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
		private static int _s_set_Effect(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).Effect = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
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
		private static int _s_set_CurrentAct(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).CurrentAct = (GameAct)objectTranslator.GetObject(L, 2, typeof(GameAct));
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
		private static int _s_set_Evental(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).Evental = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
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
		private static int _s_set_EventalTable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).EventalTable = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
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
		private static int _s_set_IDIndex(IntPtr L)
		{
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).IDIndex = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_CardDataInWorldMap(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).CardDataInWorldMap = (Dictionary<string, CardData>)objectTranslator.GetObject(L, 2, typeof(Dictionary<string, CardData>));
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
		private static int _s_set_CardDataModMap(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).CardDataModMap = (CardDataMap)objectTranslator.GetObject(L, 2, typeof(CardDataMap));
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
		private static int _s_set_BuildingModMap(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).BuildingModMap = (CardDataMap)objectTranslator.GetObject(L, 2, typeof(CardDataMap));
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
		private static int _s_set_AreaDataModMap(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).AreaDataModMap = (AreaDataMap)objectTranslator.GetObject(L, 2, typeof(AreaDataMap));
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
		private static int _s_set_BookDataModMap(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).BookDataModMap = (BookDataMap)objectTranslator.GetObject(L, 2, typeof(BookDataMap));
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
		private static int _s_set_TaskDataMap(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).TaskDataMap = (TaskDataMap)objectTranslator.GetObject(L, 2, typeof(TaskDataMap));
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
		private static int _s_set_gameSettingInfo(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).gameSettingInfo = (GameSettingInfo)objectTranslator.GetObject(L, 2, typeof(GameSettingInfo));
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
		private static int _s_set_RedLineSlots(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).RedLineSlots = (List<CardSlotData>)objectTranslator.GetObject(L, 2, typeof(List<CardSlotData>));
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
		private static int _s_set_YellowLineSlots(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).YellowLineSlots = (List<CardSlotData>)objectTranslator.GetObject(L, 2, typeof(List<CardSlotData>));
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
		private static int _s_set_BlueLineSlots(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).BlueLineSlots = (List<CardSlotData>)objectTranslator.GetObject(L, 2, typeof(List<CardSlotData>));
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
		private static int _s_set_AllPersonEvents(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).AllPersonEvents = (List<PersonEvent>)objectTranslator.GetObject(L, 2, typeof(List<PersonEvent>));
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
		private static int _s_set_WorldMoveArea(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).WorldMoveArea = (Area)objectTranslator.GetObject(L, 2, typeof(Area));
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
		private static int _s_set_LogCtrl(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).LogCtrl = (LogController)objectTranslator.GetObject(L, 2, typeof(LogController));
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
		private static int _s_set_CurrentCityID(IntPtr L)
		{
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).CurrentCityID = Lua.lua_tostring(L, 2);
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
		private static int _s_set_IsUseCommandLine(IntPtr L)
		{
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).IsUseCommandLine = Lua.lua_toboolean(L, 2);
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
		private static int _s_set_PNGResourceCache(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).PNGResourceCache = (Dictionary<string, byte[]>)objectTranslator.GetObject(L, 2, typeof(Dictionary<string, byte[]>));
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
		private static int _s_set_LuaLogicCache(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).LuaLogicCache = (Dictionary<string, string>)objectTranslator.GetObject(L, 2, typeof(Dictionary<string, string>));
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
		private static int _s_set_jsonsFromWorkShop(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).jsonsFromWorkShop = (List<FileInfo>)objectTranslator.GetObject(L, 2, typeof(List<FileInfo>));
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
		private static int _s_set_CurrentTableType(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameController gameController = (GameController)objectTranslator.FastGetCSObj(L, 1);
				TableType currentTableType;
				objectTranslator.Get<TableType>(L, 2, out currentTableType);
				gameController.CurrentTableType = currentTableType;
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
		private static int _s_set_PlayerTableTempArea(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).PlayerTableTempArea = (List<CardSlotData>)objectTranslator.GetObject(L, 2, typeof(List<CardSlotData>));
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
		private static int _s_set_PublicArea(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).PublicArea = (List<CardSlotData>)objectTranslator.GetObject(L, 2, typeof(List<CardSlotData>));
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
		private static int _s_set_PartnerArea(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).PartnerArea = (List<CardSlotData>)objectTranslator.GetObject(L, 2, typeof(List<CardSlotData>));
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
		private static int _s_set_CityMap(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).CityMap = (Dictionary<AreaData, List<object[]>>)objectTranslator.GetObject(L, 2, typeof(Dictionary<AreaData, List<object[]>>));
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
		private static int _s_set_Subtitle(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).Subtitle = (SubtitleCanvas)objectTranslator.GetObject(L, 2, typeof(SubtitleCanvas));
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
		private static int _s_set_MainCamera(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).MainCamera = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
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
		private static int _s_set_Gear(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).Gear = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
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
		private static int _s_set_Gan(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).Gan = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
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
		private static int _s_set_GuideCanvas(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).GuideCanvas = (GuideCanvasController)objectTranslator.GetObject(L, 2, typeof(GuideCanvasController));
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
		private static int _s_set_AmountText(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((GameController)objectTranslator.FastGetCSObj(L, 1)).AmountText = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
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
		private static int _s_set_HeroHomeCurrentHeroModID(IntPtr L)
		{
			try
			{
				((GameController)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).HeroHomeCurrentHeroModID = Lua.lua_tostring(L, 2);
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
