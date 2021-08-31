using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class CardDataWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(CardData);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 34, 107, 103, -1);
			Utils.RegisterFunc(L, -3, "PutInSlotData", new lua_CSFunction(CardDataWrap._m_PutInSlotData));
			Utils.RegisterFunc(L, -3, "DoAllLogic", new lua_CSFunction(CardDataWrap._m_DoAllLogic));
			Utils.RegisterFunc(L, -3, "ChangeCardSlot", new lua_CSFunction(CardDataWrap._m_ChangeCardSlot));
			Utils.RegisterFunc(L, -3, "MoveToArea", new lua_CSFunction(CardDataWrap._m_MoveToArea));
			Utils.RegisterFunc(L, -3, "MergeBy", new lua_CSFunction(CardDataWrap._m_MergeBy));
			Utils.RegisterFunc(L, -3, "Terminate", new lua_CSFunction(CardDataWrap._m_Terminate));
			Utils.RegisterFunc(L, -3, "DeleteCardData", new lua_CSFunction(CardDataWrap._m_DeleteCardData));
			Utils.RegisterFunc(L, -3, "Consume", new lua_CSFunction(CardDataWrap._m_Consume));
			Utils.RegisterFunc(L, -3, "MergeWith", new lua_CSFunction(CardDataWrap._m_MergeWith));
			Utils.RegisterFunc(L, -3, "SetLevel", new lua_CSFunction(CardDataWrap._m_SetLevel));
			Utils.RegisterFunc(L, -3, "AddExp", new lua_CSFunction(CardDataWrap._m_AddExp));
			Utils.RegisterFunc(L, -3, "GetLevelExp", new lua_CSFunction(CardDataWrap._m_GetLevelExp));
			Utils.RegisterFunc(L, -3, "GetLevelByExp", new lua_CSFunction(CardDataWrap._m_GetLevelByExp));
			Utils.RegisterFunc(L, -3, "HasTag", new lua_CSFunction(CardDataWrap._m_HasTag));
			Utils.RegisterFunc(L, -3, "AddTag", new lua_CSFunction(CardDataWrap._m_AddTag));
			Utils.RegisterFunc(L, -3, "RemoveTag", new lua_CSFunction(CardDataWrap._m_RemoveTag));
			Utils.RegisterFunc(L, -3, "HasConversation", new lua_CSFunction(CardDataWrap._m_HasConversation));
			Utils.RegisterFunc(L, -3, "ReloadLogics", new lua_CSFunction(CardDataWrap._m_ReloadLogics));
			Utils.RegisterFunc(L, -3, "GetHP", new lua_CSFunction(CardDataWrap._m_GetHP));
			Utils.RegisterFunc(L, -3, "GetATK", new lua_CSFunction(CardDataWrap._m_GetATK));
			Utils.RegisterFunc(L, -3, "TakeDamage", new lua_CSFunction(CardDataWrap._m_TakeDamage));
			Utils.RegisterFunc(L, -3, "OnSerializing", new lua_CSFunction(CardDataWrap._m_OnSerializing));
			Utils.RegisterFunc(L, -3, "OnDeserialized", new lua_CSFunction(CardDataWrap._m_OnDeserialized));
			Utils.RegisterFunc(L, -3, "OnGameLoaded", new lua_CSFunction(CardDataWrap._m_OnGameLoaded));
			Utils.RegisterFunc(L, -3, "AddLogic", new lua_CSFunction(CardDataWrap._m_AddLogic));
			Utils.RegisterFunc(L, -3, "RemoveLogic", new lua_CSFunction(CardDataWrap._m_RemoveLogic));
			Utils.RegisterFunc(L, -3, "AddPersonLogic", new lua_CSFunction(CardDataWrap._m_AddPersonLogic));
			Utils.RegisterFunc(L, -3, "HasAffix", new lua_CSFunction(CardDataWrap._m_HasAffix));
			Utils.RegisterFunc(L, -3, "GetAffixData", new lua_CSFunction(CardDataWrap._m_GetAffixData));
			Utils.RegisterFunc(L, -3, "AddAffix", new lua_CSFunction(CardDataWrap._m_AddAffix));
			Utils.RegisterFunc(L, -3, "RemoveAffix", new lua_CSFunction(CardDataWrap._m_RemoveAffix));
			Utils.RegisterFunc(L, -3, "RemoveCardLogic", new lua_CSFunction(CardDataWrap._m_RemoveCardLogic));
			Utils.RegisterFunc(L, -3, "ChangeHeroHp", new lua_CSFunction(CardDataWrap._m_ChangeHeroHp));
			Utils.RegisterFunc(L, -3, "ChangeHeroMp", new lua_CSFunction(CardDataWrap._m_ChangeHeroMp));
			Utils.RegisterFunc(L, -2, "CharactorTag", new lua_CSFunction(CardDataWrap._g_get_CharactorTag));
			Utils.RegisterFunc(L, -2, "PersonName", new lua_CSFunction(CardDataWrap._g_get_PersonName));
			Utils.RegisterFunc(L, -2, "ATK", new lua_CSFunction(CardDataWrap._g_get_ATK));
			Utils.RegisterFunc(L, -2, "AttackTimes", new lua_CSFunction(CardDataWrap._g_get_AttackTimes));
			Utils.RegisterFunc(L, -2, "CRIT", new lua_CSFunction(CardDataWrap._g_get_CRIT));
			Utils.RegisterFunc(L, -2, "affixesDic", new lua_CSFunction(CardDataWrap._g_get_affixesDic));
			Utils.RegisterFunc(L, -2, "TempData", new lua_CSFunction(CardDataWrap._g_get_TempData));
			Utils.RegisterFunc(L, -2, "CardGameObject", new lua_CSFunction(CardDataWrap._g_get_CardGameObject));
			Utils.RegisterFunc(L, -2, "CurrentCardSlotData", new lua_CSFunction(CardDataWrap._g_get_CurrentCardSlotData));
			Utils.RegisterFunc(L, -2, "IsToy", new lua_CSFunction(CardDataWrap._g_get_IsToy));
			Utils.RegisterFunc(L, -2, "CurrentAreaID", new lua_CSFunction(CardDataWrap._g_get_CurrentAreaID));
			Utils.RegisterFunc(L, -2, "PreName", new lua_CSFunction(CardDataWrap._g_get_PreName));
			Utils.RegisterFunc(L, -2, "MergedCardModIDs", new lua_CSFunction(CardDataWrap._g_get_MergedCardModIDs));
			Utils.RegisterFunc(L, -2, "ADJ_Affix", new lua_CSFunction(CardDataWrap._g_get_ADJ_Affix));
			Utils.RegisterFunc(L, -2, "ADV_Affix", new lua_CSFunction(CardDataWrap._g_get_ADV_Affix));
			Utils.RegisterFunc(L, -2, "V_Affix", new lua_CSFunction(CardDataWrap._g_get_V_Affix));
			Utils.RegisterFunc(L, -2, "CharactorTagUlong", new lua_CSFunction(CardDataWrap._g_get_CharactorTagUlong));
			Utils.RegisterFunc(L, -2, "ArmsUsagePosition", new lua_CSFunction(CardDataWrap._g_get_ArmsUsagePosition));
			Utils.RegisterFunc(L, -2, "UsageTimes", new lua_CSFunction(CardDataWrap._g_get_UsageTimes));
			Utils.RegisterFunc(L, -2, "MaxUsageTimes", new lua_CSFunction(CardDataWrap._g_get_MaxUsageTimes));
			Utils.RegisterFunc(L, -2, "TotalTime", new lua_CSFunction(CardDataWrap._g_get_TotalTime));
			Utils.RegisterFunc(L, -2, "RemainTime", new lua_CSFunction(CardDataWrap._g_get_RemainTime));
			Utils.RegisterFunc(L, -2, "Life", new lua_CSFunction(CardDataWrap._g_get_Life));
			Utils.RegisterFunc(L, -2, "LimitedTime", new lua_CSFunction(CardDataWrap._g_get_LimitedTime));
			Utils.RegisterFunc(L, -2, "Frequency", new lua_CSFunction(CardDataWrap._g_get_Frequency));
			Utils.RegisterFunc(L, -2, "killEnemyCount", new lua_CSFunction(CardDataWrap._g_get_killEnemyCount));
			Utils.RegisterFunc(L, -2, "MaxCount", new lua_CSFunction(CardDataWrap._g_get_MaxCount));
			Utils.RegisterFunc(L, -2, "Count", new lua_CSFunction(CardDataWrap._g_get_Count));
			Utils.RegisterFunc(L, -2, "Rare", new lua_CSFunction(CardDataWrap._g_get_Rare));
			Utils.RegisterFunc(L, -2, "CardTags", new lua_CSFunction(CardDataWrap._g_get_CardTags));
			Utils.RegisterFunc(L, -2, "AcceptTags", new lua_CSFunction(CardDataWrap._g_get_AcceptTags));
			Utils.RegisterFunc(L, -2, "desc", new lua_CSFunction(CardDataWrap._g_get_desc));
			Utils.RegisterFunc(L, -2, "UnHappy", new lua_CSFunction(CardDataWrap._g_get_UnHappy));
			Utils.RegisterFunc(L, -2, "Charm", new lua_CSFunction(CardDataWrap._g_get_Charm));
			Utils.RegisterFunc(L, -2, "Production", new lua_CSFunction(CardDataWrap._g_get_Production));
			Utils.RegisterFunc(L, -2, "Intelligence", new lua_CSFunction(CardDataWrap._g_get_Intelligence));
			Utils.RegisterFunc(L, -2, "Struct", new lua_CSFunction(CardDataWrap._g_get_Struct));
			Utils.RegisterFunc(L, -2, "StructWidth", new lua_CSFunction(CardDataWrap._g_get_StructWidth));
			Utils.RegisterFunc(L, -2, "StructHeight", new lua_CSFunction(CardDataWrap._g_get_StructHeight));
			Utils.RegisterFunc(L, -2, "StructTexture", new lua_CSFunction(CardDataWrap._g_get_StructTexture));
			Utils.RegisterFunc(L, -2, "StructBase64String", new lua_CSFunction(CardDataWrap._g_get_StructBase64String));
			Utils.RegisterFunc(L, -2, "StructId", new lua_CSFunction(CardDataWrap._g_get_StructId));
			Utils.RegisterFunc(L, -2, "Clock", new lua_CSFunction(CardDataWrap._g_get_Clock));
			Utils.RegisterFunc(L, -2, "Logic", new lua_CSFunction(CardDataWrap._g_get_Logic));
			Utils.RegisterFunc(L, -2, "CardLogicClassNames", new lua_CSFunction(CardDataWrap._g_get_CardLogicClassNames));
			Utils.RegisterFunc(L, -2, "CardLogics", new lua_CSFunction(CardDataWrap._g_get_CardLogics));
			Utils.RegisterFunc(L, -2, "ammoContainer", new lua_CSFunction(CardDataWrap._g_get_ammoContainer));
			Utils.RegisterFunc(L, -2, "ActDatas", new lua_CSFunction(CardDataWrap._g_get_ActDatas));
			Utils.RegisterFunc(L, -2, "sacrificeVal", new lua_CSFunction(CardDataWrap._g_get_sacrificeVal));
			Utils.RegisterFunc(L, -2, "rotateTime", new lua_CSFunction(CardDataWrap._g_get_rotateTime));
			Utils.RegisterFunc(L, -2, "IsFlipAnimDone", new lua_CSFunction(CardDataWrap._g_get_IsFlipAnimDone));
			Utils.RegisterFunc(L, -2, "IsAttacked", new lua_CSFunction(CardDataWrap._g_get_IsAttacked));
			Utils.RegisterFunc(L, -2, "Level", new lua_CSFunction(CardDataWrap._g_get_Level));
			Utils.RegisterFunc(L, -2, "MaxHP", new lua_CSFunction(CardDataWrap._g_get_MaxHP));
			Utils.RegisterFunc(L, -2, "HP", new lua_CSFunction(CardDataWrap._g_get_HP));
			Utils.RegisterFunc(L, -2, "HB", new lua_CSFunction(CardDataWrap._g_get_HB));
			Utils.RegisterFunc(L, -2, "EXATK", new lua_CSFunction(CardDataWrap._g_get_EXATK));
			Utils.RegisterFunc(L, -2, "EXATKTimes", new lua_CSFunction(CardDataWrap._g_get_EXATKTimes));
			Utils.RegisterFunc(L, -2, "EXRange", new lua_CSFunction(CardDataWrap._g_get_EXRange));
			Utils.RegisterFunc(L, -2, "AddHP", new lua_CSFunction(CardDataWrap._g_get_AddHP));
			Utils.RegisterFunc(L, -2, "InBattleATK", new lua_CSFunction(CardDataWrap._g_get_InBattleATK));
			Utils.RegisterFunc(L, -2, "AttackColor", new lua_CSFunction(CardDataWrap._g_get_AttackColor));
			Utils.RegisterFunc(L, -2, "Armor", new lua_CSFunction(CardDataWrap._g_get_Armor));
			Utils.RegisterFunc(L, -2, "wArmor", new lua_CSFunction(CardDataWrap._g_get_wArmor));
			Utils.RegisterFunc(L, -2, "MaxArmor", new lua_CSFunction(CardDataWrap._g_get_MaxArmor));
			Utils.RegisterFunc(L, -2, "DArmor", new lua_CSFunction(CardDataWrap._g_get_DArmor));
			Utils.RegisterFunc(L, -2, "DizzyLayer", new lua_CSFunction(CardDataWrap._g_get_DizzyLayer));
			Utils.RegisterFunc(L, -2, "_ATK", new lua_CSFunction(CardDataWrap._g_get__ATK));
			Utils.RegisterFunc(L, -2, "_AttackTimes", new lua_CSFunction(CardDataWrap._g_get__AttackTimes));
			Utils.RegisterFunc(L, -2, "wAttackTimes", new lua_CSFunction(CardDataWrap._g_get_wAttackTimes));
			Utils.RegisterFunc(L, -2, "NextAttackTimes", new lua_CSFunction(CardDataWrap._g_get_NextAttackTimes));
			Utils.RegisterFunc(L, -2, "AB", new lua_CSFunction(CardDataWrap._g_get_AB));
			Utils.RegisterFunc(L, -2, "MP", new lua_CSFunction(CardDataWrap._g_get_MP));
			Utils.RegisterFunc(L, -2, "BasicMaxMp", new lua_CSFunction(CardDataWrap._g_get_BasicMaxMp));
			Utils.RegisterFunc(L, -2, "ManaCost", new lua_CSFunction(CardDataWrap._g_get_ManaCost));
			Utils.RegisterFunc(L, -2, "MaxMP", new lua_CSFunction(CardDataWrap._g_get_MaxMP));
			Utils.RegisterFunc(L, -2, "DHP", new lua_CSFunction(CardDataWrap._g_get_DHP));
			Utils.RegisterFunc(L, -2, "wDHP", new lua_CSFunction(CardDataWrap._g_get_wDHP));
			Utils.RegisterFunc(L, -2, "wHP", new lua_CSFunction(CardDataWrap._g_get_wHP));
			Utils.RegisterFunc(L, -2, "DATK", new lua_CSFunction(CardDataWrap._g_get_DATK));
			Utils.RegisterFunc(L, -2, "wDATK", new lua_CSFunction(CardDataWrap._g_get_wDATK));
			Utils.RegisterFunc(L, -2, "wATK", new lua_CSFunction(CardDataWrap._g_get_wATK));
			Utils.RegisterFunc(L, -2, "ATKRange", new lua_CSFunction(CardDataWrap._g_get_ATKRange));
			Utils.RegisterFunc(L, -2, "_CRIT", new lua_CSFunction(CardDataWrap._g_get__CRIT));
			Utils.RegisterFunc(L, -2, "wCRIT", new lua_CSFunction(CardDataWrap._g_get_wCRIT));
			Utils.RegisterFunc(L, -2, "InBattleCRIT", new lua_CSFunction(CardDataWrap._g_get_InBattleCRIT));
			Utils.RegisterFunc(L, -2, "SPD", new lua_CSFunction(CardDataWrap._g_get_SPD));
			Utils.RegisterFunc(L, -2, "RemainSPD", new lua_CSFunction(CardDataWrap._g_get_RemainSPD));
			Utils.RegisterFunc(L, -2, "MoveRange", new lua_CSFunction(CardDataWrap._g_get_MoveRange));
			Utils.RegisterFunc(L, -2, "AttackExtraRange", new lua_CSFunction(CardDataWrap._g_get_AttackExtraRange));
			Utils.RegisterFunc(L, -2, "Exp", new lua_CSFunction(CardDataWrap._g_get_Exp));
			Utils.RegisterFunc(L, -2, "ShotEffect", new lua_CSFunction(CardDataWrap._g_get_ShotEffect));
			Utils.RegisterFunc(L, -2, "HitEffect", new lua_CSFunction(CardDataWrap._g_get_HitEffect));
			Utils.RegisterFunc(L, -2, "BlueLine", new lua_CSFunction(CardDataWrap._g_get_BlueLine));
			Utils.RegisterFunc(L, -2, "RedLine", new lua_CSFunction(CardDataWrap._g_get_RedLine));
			Utils.RegisterFunc(L, -2, "YellowLine", new lua_CSFunction(CardDataWrap._g_get_YellowLine));
			Utils.RegisterFunc(L, -2, "Value", new lua_CSFunction(CardDataWrap._g_get_Value));
			Utils.RegisterFunc(L, -2, "Price", new lua_CSFunction(CardDataWrap._g_get_Price));
			Utils.RegisterFunc(L, -2, "PriceMaxFluctuation", new lua_CSFunction(CardDataWrap._g_get_PriceMaxFluctuation));
			Utils.RegisterFunc(L, -2, "ContainsNumber", new lua_CSFunction(CardDataWrap._g_get_ContainsNumber));
			Utils.RegisterFunc(L, -2, "ContainsIDs", new lua_CSFunction(CardDataWrap._g_get_ContainsIDs));
			Utils.RegisterFunc(L, -2, "IsCopy", new lua_CSFunction(CardDataWrap._g_get_IsCopy));
			Utils.RegisterFunc(L, -2, "Belongings", new lua_CSFunction(CardDataWrap._g_get_Belongings));
			Utils.RegisterFunc(L, -2, "DefaultBelongings", new lua_CSFunction(CardDataWrap._g_get_DefaultBelongings));
			Utils.RegisterFunc(L, -2, "PreNameList", new lua_CSFunction(CardDataWrap._g_get_PreNameList));
			Utils.RegisterFunc(L, -2, "CoveredWidth", new lua_CSFunction(CardDataWrap._g_get_CoveredWidth));
			Utils.RegisterFunc(L, -2, "CoveredHeight", new lua_CSFunction(CardDataWrap._g_get_CoveredHeight));
			Utils.RegisterFunc(L, -1, "CharactorTag", new lua_CSFunction(CardDataWrap._s_set_CharactorTag));
			Utils.RegisterFunc(L, -1, "PersonName", new lua_CSFunction(CardDataWrap._s_set_PersonName));
			Utils.RegisterFunc(L, -1, "TempData", new lua_CSFunction(CardDataWrap._s_set_TempData));
			Utils.RegisterFunc(L, -1, "CardGameObject", new lua_CSFunction(CardDataWrap._s_set_CardGameObject));
			Utils.RegisterFunc(L, -1, "CurrentCardSlotData", new lua_CSFunction(CardDataWrap._s_set_CurrentCardSlotData));
			Utils.RegisterFunc(L, -1, "IsToy", new lua_CSFunction(CardDataWrap._s_set_IsToy));
			Utils.RegisterFunc(L, -1, "CurrentAreaID", new lua_CSFunction(CardDataWrap._s_set_CurrentAreaID));
			Utils.RegisterFunc(L, -1, "PreName", new lua_CSFunction(CardDataWrap._s_set_PreName));
			Utils.RegisterFunc(L, -1, "MergedCardModIDs", new lua_CSFunction(CardDataWrap._s_set_MergedCardModIDs));
			Utils.RegisterFunc(L, -1, "ADJ_Affix", new lua_CSFunction(CardDataWrap._s_set_ADJ_Affix));
			Utils.RegisterFunc(L, -1, "ADV_Affix", new lua_CSFunction(CardDataWrap._s_set_ADV_Affix));
			Utils.RegisterFunc(L, -1, "V_Affix", new lua_CSFunction(CardDataWrap._s_set_V_Affix));
			Utils.RegisterFunc(L, -1, "CharactorTagUlong", new lua_CSFunction(CardDataWrap._s_set_CharactorTagUlong));
			Utils.RegisterFunc(L, -1, "ArmsUsagePosition", new lua_CSFunction(CardDataWrap._s_set_ArmsUsagePosition));
			Utils.RegisterFunc(L, -1, "UsageTimes", new lua_CSFunction(CardDataWrap._s_set_UsageTimes));
			Utils.RegisterFunc(L, -1, "MaxUsageTimes", new lua_CSFunction(CardDataWrap._s_set_MaxUsageTimes));
			Utils.RegisterFunc(L, -1, "TotalTime", new lua_CSFunction(CardDataWrap._s_set_TotalTime));
			Utils.RegisterFunc(L, -1, "RemainTime", new lua_CSFunction(CardDataWrap._s_set_RemainTime));
			Utils.RegisterFunc(L, -1, "Life", new lua_CSFunction(CardDataWrap._s_set_Life));
			Utils.RegisterFunc(L, -1, "LimitedTime", new lua_CSFunction(CardDataWrap._s_set_LimitedTime));
			Utils.RegisterFunc(L, -1, "Frequency", new lua_CSFunction(CardDataWrap._s_set_Frequency));
			Utils.RegisterFunc(L, -1, "killEnemyCount", new lua_CSFunction(CardDataWrap._s_set_killEnemyCount));
			Utils.RegisterFunc(L, -1, "MaxCount", new lua_CSFunction(CardDataWrap._s_set_MaxCount));
			Utils.RegisterFunc(L, -1, "Count", new lua_CSFunction(CardDataWrap._s_set_Count));
			Utils.RegisterFunc(L, -1, "Rare", new lua_CSFunction(CardDataWrap._s_set_Rare));
			Utils.RegisterFunc(L, -1, "CardTags", new lua_CSFunction(CardDataWrap._s_set_CardTags));
			Utils.RegisterFunc(L, -1, "AcceptTags", new lua_CSFunction(CardDataWrap._s_set_AcceptTags));
			Utils.RegisterFunc(L, -1, "desc", new lua_CSFunction(CardDataWrap._s_set_desc));
			Utils.RegisterFunc(L, -1, "UnHappy", new lua_CSFunction(CardDataWrap._s_set_UnHappy));
			Utils.RegisterFunc(L, -1, "Charm", new lua_CSFunction(CardDataWrap._s_set_Charm));
			Utils.RegisterFunc(L, -1, "Production", new lua_CSFunction(CardDataWrap._s_set_Production));
			Utils.RegisterFunc(L, -1, "Intelligence", new lua_CSFunction(CardDataWrap._s_set_Intelligence));
			Utils.RegisterFunc(L, -1, "Struct", new lua_CSFunction(CardDataWrap._s_set_Struct));
			Utils.RegisterFunc(L, -1, "StructWidth", new lua_CSFunction(CardDataWrap._s_set_StructWidth));
			Utils.RegisterFunc(L, -1, "StructHeight", new lua_CSFunction(CardDataWrap._s_set_StructHeight));
			Utils.RegisterFunc(L, -1, "StructTexture", new lua_CSFunction(CardDataWrap._s_set_StructTexture));
			Utils.RegisterFunc(L, -1, "StructBase64String", new lua_CSFunction(CardDataWrap._s_set_StructBase64String));
			Utils.RegisterFunc(L, -1, "StructId", new lua_CSFunction(CardDataWrap._s_set_StructId));
			Utils.RegisterFunc(L, -1, "Clock", new lua_CSFunction(CardDataWrap._s_set_Clock));
			Utils.RegisterFunc(L, -1, "Logic", new lua_CSFunction(CardDataWrap._s_set_Logic));
			Utils.RegisterFunc(L, -1, "CardLogicClassNames", new lua_CSFunction(CardDataWrap._s_set_CardLogicClassNames));
			Utils.RegisterFunc(L, -1, "CardLogics", new lua_CSFunction(CardDataWrap._s_set_CardLogics));
			Utils.RegisterFunc(L, -1, "ammoContainer", new lua_CSFunction(CardDataWrap._s_set_ammoContainer));
			Utils.RegisterFunc(L, -1, "ActDatas", new lua_CSFunction(CardDataWrap._s_set_ActDatas));
			Utils.RegisterFunc(L, -1, "sacrificeVal", new lua_CSFunction(CardDataWrap._s_set_sacrificeVal));
			Utils.RegisterFunc(L, -1, "rotateTime", new lua_CSFunction(CardDataWrap._s_set_rotateTime));
			Utils.RegisterFunc(L, -1, "IsFlipAnimDone", new lua_CSFunction(CardDataWrap._s_set_IsFlipAnimDone));
			Utils.RegisterFunc(L, -1, "IsAttacked", new lua_CSFunction(CardDataWrap._s_set_IsAttacked));
			Utils.RegisterFunc(L, -1, "Level", new lua_CSFunction(CardDataWrap._s_set_Level));
			Utils.RegisterFunc(L, -1, "MaxHP", new lua_CSFunction(CardDataWrap._s_set_MaxHP));
			Utils.RegisterFunc(L, -1, "HP", new lua_CSFunction(CardDataWrap._s_set_HP));
			Utils.RegisterFunc(L, -1, "HB", new lua_CSFunction(CardDataWrap._s_set_HB));
			Utils.RegisterFunc(L, -1, "EXATK", new lua_CSFunction(CardDataWrap._s_set_EXATK));
			Utils.RegisterFunc(L, -1, "EXATKTimes", new lua_CSFunction(CardDataWrap._s_set_EXATKTimes));
			Utils.RegisterFunc(L, -1, "EXRange", new lua_CSFunction(CardDataWrap._s_set_EXRange));
			Utils.RegisterFunc(L, -1, "AddHP", new lua_CSFunction(CardDataWrap._s_set_AddHP));
			Utils.RegisterFunc(L, -1, "InBattleATK", new lua_CSFunction(CardDataWrap._s_set_InBattleATK));
			Utils.RegisterFunc(L, -1, "AttackColor", new lua_CSFunction(CardDataWrap._s_set_AttackColor));
			Utils.RegisterFunc(L, -1, "Armor", new lua_CSFunction(CardDataWrap._s_set_Armor));
			Utils.RegisterFunc(L, -1, "wArmor", new lua_CSFunction(CardDataWrap._s_set_wArmor));
			Utils.RegisterFunc(L, -1, "MaxArmor", new lua_CSFunction(CardDataWrap._s_set_MaxArmor));
			Utils.RegisterFunc(L, -1, "DArmor", new lua_CSFunction(CardDataWrap._s_set_DArmor));
			Utils.RegisterFunc(L, -1, "DizzyLayer", new lua_CSFunction(CardDataWrap._s_set_DizzyLayer));
			Utils.RegisterFunc(L, -1, "_ATK", new lua_CSFunction(CardDataWrap._s_set__ATK));
			Utils.RegisterFunc(L, -1, "_AttackTimes", new lua_CSFunction(CardDataWrap._s_set__AttackTimes));
			Utils.RegisterFunc(L, -1, "wAttackTimes", new lua_CSFunction(CardDataWrap._s_set_wAttackTimes));
			Utils.RegisterFunc(L, -1, "NextAttackTimes", new lua_CSFunction(CardDataWrap._s_set_NextAttackTimes));
			Utils.RegisterFunc(L, -1, "AB", new lua_CSFunction(CardDataWrap._s_set_AB));
			Utils.RegisterFunc(L, -1, "MP", new lua_CSFunction(CardDataWrap._s_set_MP));
			Utils.RegisterFunc(L, -1, "BasicMaxMp", new lua_CSFunction(CardDataWrap._s_set_BasicMaxMp));
			Utils.RegisterFunc(L, -1, "ManaCost", new lua_CSFunction(CardDataWrap._s_set_ManaCost));
			Utils.RegisterFunc(L, -1, "MaxMP", new lua_CSFunction(CardDataWrap._s_set_MaxMP));
			Utils.RegisterFunc(L, -1, "DHP", new lua_CSFunction(CardDataWrap._s_set_DHP));
			Utils.RegisterFunc(L, -1, "wDHP", new lua_CSFunction(CardDataWrap._s_set_wDHP));
			Utils.RegisterFunc(L, -1, "wHP", new lua_CSFunction(CardDataWrap._s_set_wHP));
			Utils.RegisterFunc(L, -1, "DATK", new lua_CSFunction(CardDataWrap._s_set_DATK));
			Utils.RegisterFunc(L, -1, "wDATK", new lua_CSFunction(CardDataWrap._s_set_wDATK));
			Utils.RegisterFunc(L, -1, "wATK", new lua_CSFunction(CardDataWrap._s_set_wATK));
			Utils.RegisterFunc(L, -1, "ATKRange", new lua_CSFunction(CardDataWrap._s_set_ATKRange));
			Utils.RegisterFunc(L, -1, "_CRIT", new lua_CSFunction(CardDataWrap._s_set__CRIT));
			Utils.RegisterFunc(L, -1, "wCRIT", new lua_CSFunction(CardDataWrap._s_set_wCRIT));
			Utils.RegisterFunc(L, -1, "InBattleCRIT", new lua_CSFunction(CardDataWrap._s_set_InBattleCRIT));
			Utils.RegisterFunc(L, -1, "SPD", new lua_CSFunction(CardDataWrap._s_set_SPD));
			Utils.RegisterFunc(L, -1, "RemainSPD", new lua_CSFunction(CardDataWrap._s_set_RemainSPD));
			Utils.RegisterFunc(L, -1, "MoveRange", new lua_CSFunction(CardDataWrap._s_set_MoveRange));
			Utils.RegisterFunc(L, -1, "AttackExtraRange", new lua_CSFunction(CardDataWrap._s_set_AttackExtraRange));
			Utils.RegisterFunc(L, -1, "Exp", new lua_CSFunction(CardDataWrap._s_set_Exp));
			Utils.RegisterFunc(L, -1, "ShotEffect", new lua_CSFunction(CardDataWrap._s_set_ShotEffect));
			Utils.RegisterFunc(L, -1, "HitEffect", new lua_CSFunction(CardDataWrap._s_set_HitEffect));
			Utils.RegisterFunc(L, -1, "BlueLine", new lua_CSFunction(CardDataWrap._s_set_BlueLine));
			Utils.RegisterFunc(L, -1, "RedLine", new lua_CSFunction(CardDataWrap._s_set_RedLine));
			Utils.RegisterFunc(L, -1, "YellowLine", new lua_CSFunction(CardDataWrap._s_set_YellowLine));
			Utils.RegisterFunc(L, -1, "Value", new lua_CSFunction(CardDataWrap._s_set_Value));
			Utils.RegisterFunc(L, -1, "Price", new lua_CSFunction(CardDataWrap._s_set_Price));
			Utils.RegisterFunc(L, -1, "PriceMaxFluctuation", new lua_CSFunction(CardDataWrap._s_set_PriceMaxFluctuation));
			Utils.RegisterFunc(L, -1, "ContainsNumber", new lua_CSFunction(CardDataWrap._s_set_ContainsNumber));
			Utils.RegisterFunc(L, -1, "ContainsIDs", new lua_CSFunction(CardDataWrap._s_set_ContainsIDs));
			Utils.RegisterFunc(L, -1, "IsCopy", new lua_CSFunction(CardDataWrap._s_set_IsCopy));
			Utils.RegisterFunc(L, -1, "Belongings", new lua_CSFunction(CardDataWrap._s_set_Belongings));
			Utils.RegisterFunc(L, -1, "DefaultBelongings", new lua_CSFunction(CardDataWrap._s_set_DefaultBelongings));
			Utils.RegisterFunc(L, -1, "PreNameList", new lua_CSFunction(CardDataWrap._s_set_PreNameList));
			Utils.RegisterFunc(L, -1, "CoveredWidth", new lua_CSFunction(CardDataWrap._s_set_CoveredWidth));
			Utils.RegisterFunc(L, -1, "CoveredHeight", new lua_CSFunction(CardDataWrap._s_set_CoveredHeight));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(CardDataWrap.__CreateInstance), 6, 0, 0);
			Utils.RegisterFunc(L, -4, "CheckOverLay", new lua_CSFunction(CardDataWrap._m_CheckOverLay_xlua_st_));
			Utils.RegisterFunc(L, -4, "CopyCardData", new lua_CSFunction(CardDataWrap._m_CopyCardData_xlua_st_));
			Utils.RegisterFunc(L, -4, "ThreeCombo", new lua_CSFunction(CardDataWrap._m_ThreeCombo_xlua_st_));
			Utils.RegisterFunc(L, -4, "GetCardDataByStructTexture", new lua_CSFunction(CardDataWrap._m_GetCardDataByStructTexture_xlua_st_));
			Utils.RegisterFunc(L, -4, "GetChinessName", new lua_CSFunction(CardDataWrap._m_GetChinessName_xlua_st_));
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
					CardData o = new CardData();
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
			return Lua.luaL_error(L, "invalid arguments to CardData constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_PutInSlotData(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 3 && objectTranslator.Assignable<CardSlotData>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					CardSlotData slotData = (CardSlotData)objectTranslator.GetObject(L, 2, typeof(CardSlotData));
					bool callEvent = Lua.lua_toboolean(L, 3);
					cardData.PutInSlotData(slotData, callEvent);
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<CardSlotData>(L, 2))
				{
					CardSlotData slotData2 = (CardSlotData)objectTranslator.GetObject(L, 2, typeof(CardSlotData));
					cardData.PutInSlotData(slotData2, true);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to CardData.PutInSlotData!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_CheckOverLay_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.GetObject(L, 1, typeof(CardData));
				CardSlotData slotData = (CardSlotData)objectTranslator.GetObject(L, 2, typeof(CardSlotData));
				bool value = CardData.CheckOverLay(cardData, slotData);
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
		private static int _m_DoAllLogic(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				string funcName = Lua.lua_tostring(L, 2);
				object[] @params = objectTranslator.GetParams<object>(L, 3);
				cardData.DoAllLogic(funcName, @params);
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
		private static int _m_ChangeCardSlot(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				CardSlotData target = (CardSlotData)objectTranslator.GetObject(L, 2, typeof(CardSlotData));
				cardData.ChangeCardSlot(target);
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
		private static int _m_MoveToArea(IntPtr L)
		{
			int result;
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				string id = Lua.lua_tostring(L, 2);
				float x = (float)Lua.lua_tonumber(L, 3);
				float z = (float)Lua.lua_tonumber(L, 4);
				float rot = (float)Lua.lua_tonumber(L, 5);
				bool withCardSlot = Lua.lua_toboolean(L, 6);
				cardData.MoveToArea(id, x, z, rot, withCardSlot);
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
		private static int _m_MergeBy(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && objectTranslator.Assignable<CardData>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 4))
				{
					CardData cardData2 = (CardData)objectTranslator.GetObject(L, 2, typeof(CardData));
					bool callEvent = Lua.lua_toboolean(L, 3);
					bool force = Lua.lua_toboolean(L, 4);
					cardData.MergeBy(cardData2, callEvent, force);
					return 0;
				}
				if (num == 3 && objectTranslator.Assignable<CardData>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					CardData cardData3 = (CardData)objectTranslator.GetObject(L, 2, typeof(CardData));
					bool callEvent2 = Lua.lua_toboolean(L, 3);
					cardData.MergeBy(cardData3, callEvent2, false);
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<CardData>(L, 2))
				{
					CardData cardData4 = (CardData)objectTranslator.GetObject(L, 2, typeof(CardData));
					cardData.MergeBy(cardData4, true, false);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to CardData.MergeBy!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_CopyCardData_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<CardData>(L, 1) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					CardData cardData = (CardData)objectTranslator.GetObject(L, 1, typeof(CardData));
					bool deep = Lua.lua_toboolean(L, 2);
					CardData o = CardData.CopyCardData(cardData, deep);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 1 && objectTranslator.Assignable<CardData>(L, 1))
				{
					CardData o2 = CardData.CopyCardData((CardData)objectTranslator.GetObject(L, 1, typeof(CardData)), true);
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
			return Lua.luaL_error(L, "invalid arguments to CardData.CopyCardData!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Terminate(IntPtr L)
		{
			int result;
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Terminate();
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
		private static int _m_DeleteCardData(IntPtr L)
		{
			int result;
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DeleteCardData();
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
		private static int _m_Consume(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int count = Lua.xlua_tointeger(L, 2);
					cardData.Consume(count);
					return 0;
				}
				if (num == 1)
				{
					cardData.Consume(1);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to CardData.Consume!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_MergeWith(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				CardData cardData2 = (CardData)objectTranslator.GetObject(L, 2, typeof(CardData));
				CardData o = cardData.MergeWith(cardData2);
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
		private static int _m_ThreeCombo_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.GetObject(L, 1, typeof(CardData));
				CardData cardData2 = (CardData)objectTranslator.GetObject(L, 2, typeof(CardData));
				CardData cardData3 = (CardData)objectTranslator.GetObject(L, 3, typeof(CardData));
				CardData o = CardData.ThreeCombo(cardData, cardData2, cardData3);
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
		private static int _m_SetLevel(IntPtr L)
		{
			int result;
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int level = Lua.xlua_tointeger(L, 2);
				cardData.SetLevel(level);
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
		private static int _m_AddExp(IntPtr L)
		{
			int result;
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int amount = Lua.xlua_tointeger(L, 2);
				cardData.AddExp(amount);
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
		private static int _m_GetLevelExp(IntPtr L)
		{
			int result;
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int level = Lua.xlua_tointeger(L, 2);
				int levelExp = cardData.GetLevelExp(level);
				Lua.xlua_pushinteger(L, levelExp);
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
		private static int _m_GetLevelByExp(IntPtr L)
		{
			int result;
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int exp = Lua.xlua_tointeger(L, 2);
				int levelByExp = cardData.GetLevelByExp(exp);
				Lua.xlua_pushinteger(L, levelByExp);
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
		private static int _m_HasTag(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int tagMask = Lua.xlua_tointeger(L, 2);
					bool value = cardData.HasTag(tagMask);
					Lua.lua_pushboolean(L, value);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<TagMap>(L, 2))
				{
					TagMap tagMask2;
					objectTranslator.Get<TagMap>(L, 2, out tagMask2);
					bool value2 = cardData.HasTag(tagMask2);
					Lua.lua_pushboolean(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to CardData.HasTag!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_AddTag(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				TagMap tagMask;
				objectTranslator.Get<TagMap>(L, 2, out tagMask);
				cardData.AddTag(tagMask);
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
		private static int _m_RemoveTag(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				TagMap tagMask;
				objectTranslator.Get<TagMap>(L, 2, out tagMask);
				cardData.RemoveTag(tagMask);
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
		private static int _m_HasConversation(IntPtr L)
		{
			int result;
			try
			{
				bool value = ((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).HasConversation();
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
		private static int _m_ReloadLogics(IntPtr L)
		{
			int result;
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).ReloadLogics();
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
		private static int _m_GetCardDataByStructTexture_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardDataByStructTexture = CardData.GetCardDataByStructTexture((Texture2D)objectTranslator.GetObject(L, 1, typeof(Texture2D)));
				objectTranslator.Push(L, cardDataByStructTexture);
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
		private static int _m_GetHP(IntPtr L)
		{
			int result;
			try
			{
				int hp = ((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).GetHP();
				Lua.xlua_pushinteger(L, hp);
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
		private static int _m_GetATK(IntPtr L)
		{
			int result;
			try
			{
				int atk = ((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).GetATK();
				Lua.xlua_pushinteger(L, atk);
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
		private static int _m_TakeDamage(IntPtr L)
		{
			int result;
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int amount = Lua.xlua_tointeger(L, 2);
				cardData.TakeDamage(amount);
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
		private static int _m_OnSerializing(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				StreamingContext context;
				objectTranslator.Get<StreamingContext>(L, 2, out context);
				cardData.OnSerializing(context);
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
		private static int _m_OnDeserialized(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				StreamingContext context;
				objectTranslator.Get<StreamingContext>(L, 2, out context);
				cardData.OnDeserialized(context);
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
		private static int _m_OnGameLoaded(IntPtr L)
		{
			int result;
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).OnGameLoaded();
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
		private static int _m_AddLogic(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<CardLogic>(L, 2))
				{
					CardLogic cardLogic = (CardLogic)objectTranslator.GetObject(L, 2, typeof(CardLogic));
					cardData.AddLogic(cardLogic);
					return 0;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					string logicName = Lua.lua_tostring(L, 2);
					int layer = Lua.xlua_tointeger(L, 3);
					CardLogic o = cardData.AddLogic(logicName, layer);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string logicName2 = Lua.lua_tostring(L, 2);
					CardLogic o2 = cardData.AddLogic(logicName2, 0);
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
			return Lua.luaL_error(L, "invalid arguments to CardData.AddLogic!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_RemoveLogic(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				CardLogic cardLogic = (CardLogic)objectTranslator.GetObject(L, 2, typeof(CardLogic));
				bool value = cardData.RemoveLogic(cardLogic);
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
		private static int _m_AddPersonLogic(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				PersonCardLogic logic = (PersonCardLogic)objectTranslator.GetObject(L, 2, typeof(PersonCardLogic));
				cardData.AddPersonLogic(logic);
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
		private static int _m_HasAffix(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				DungeonAffix affix;
				objectTranslator.Get<DungeonAffix>(L, 2, out affix);
				bool value = cardData.HasAffix(affix);
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
		private static int _m_GetAffixData(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				DungeonAffix affix;
				objectTranslator.Get<DungeonAffix>(L, 2, out affix);
				int affixData = cardData.GetAffixData(affix);
				Lua.xlua_pushinteger(L, affixData);
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
		private static int _m_AddAffix(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				DungeonAffix affix;
				objectTranslator.Get<DungeonAffix>(L, 2, out affix);
				int num = Lua.xlua_tointeger(L, 3);
				cardData.AddAffix(affix, num);
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
		private static int _m_RemoveAffix(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				DungeonAffix affix;
				objectTranslator.Get<DungeonAffix>(L, 2, out affix);
				cardData.RemoveAffix(affix);
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
		private static int _m_RemoveCardLogic(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				CardLogic cl = (CardLogic)objectTranslator.GetObject(L, 2, typeof(CardLogic));
				cardData.RemoveCardLogic(cl);
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
		private static int _m_GetChinessName_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				string chinessName = CardData.GetChinessName();
				Lua.lua_pushstring(L, chinessName);
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
		private static int _m_ChangeHeroHp(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					int value = Lua.xlua_tointeger(L, 2);
					bool isSimulation = Lua.lua_toboolean(L, 3);
					cardData.ChangeHeroHp(value, isSimulation);
					return 0;
				}
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int value2 = Lua.xlua_tointeger(L, 2);
					cardData.ChangeHeroHp(value2, false);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to CardData.ChangeHeroHp!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ChangeHeroMp(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					int value = Lua.xlua_tointeger(L, 2);
					bool isSimulation = Lua.lua_toboolean(L, 3);
					cardData.ChangeHeroMp(value, isSimulation);
					return 0;
				}
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int value2 = Lua.xlua_tointeger(L, 2);
					cardData.ChangeHeroMp(value2, false);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to CardData.ChangeHeroMp!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_CharactorTag(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.CharactorTag);
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
		private static int _g_get_PersonName(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, cardData.PersonName);
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
		private static int _g_get_ATK(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.ATK);
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
		private static int _g_get_AttackTimes(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.AttackTimes);
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
		private static int _g_get_CRIT(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.CRIT);
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
		private static int _g_get_affixesDic(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.affixesDic);
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
		private static int _g_get_TempData(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.TempData);
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
		private static int _g_get_CardGameObject(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.CardGameObject);
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
		private static int _g_get_CurrentCardSlotData(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.CurrentCardSlotData);
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
		private static int _g_get_IsToy(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, cardData.IsToy);
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
		private static int _g_get_CurrentAreaID(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, cardData.CurrentAreaID);
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
		private static int _g_get_PreName(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, cardData.PreName);
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
		private static int _g_get_MergedCardModIDs(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.MergedCardModIDs);
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
		private static int _g_get_ADJ_Affix(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, cardData.ADJ_Affix);
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
		private static int _g_get_ADV_Affix(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, cardData.ADV_Affix);
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
		private static int _g_get_V_Affix(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, cardData.V_Affix);
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
		private static int _g_get_CharactorTagUlong(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushuint64(L, cardData.CharactorTagUlong);
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
		private static int _g_get_ArmsUsagePosition(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.ArmsUsagePosition);
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
		private static int _g_get_UsageTimes(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.UsageTimes);
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
		private static int _g_get_MaxUsageTimes(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.MaxUsageTimes);
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
		private static int _g_get_TotalTime(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.TotalTime);
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
		private static int _g_get_RemainTime(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.RemainTime);
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
		private static int _g_get_Life(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.Life);
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
		private static int _g_get_LimitedTime(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)cardData.LimitedTime);
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
		private static int _g_get_Frequency(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.Frequency);
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
		private static int _g_get_killEnemyCount(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.killEnemyCount);
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
		private static int _g_get_MaxCount(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.MaxCount);
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
		private static int _g_get_Count(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.Count);
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
		private static int _g_get_Rare(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.Rare);
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
		private static int _g_get_CardTags(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushuint64(L, cardData.CardTags);
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
		private static int _g_get_AcceptTags(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushuint64(L, cardData.AcceptTags);
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
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, cardData.desc);
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
		private static int _g_get_UnHappy(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.UnHappy);
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
		private static int _g_get_Charm(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.Charm);
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
		private static int _g_get_Production(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.Production);
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
		private static int _g_get_Intelligence(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.Intelligence);
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
		private static int _g_get_Struct(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.Struct);
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
		private static int _g_get_StructWidth(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.StructWidth);
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
		private static int _g_get_StructHeight(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.StructHeight);
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
		private static int _g_get_StructTexture(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.StructTexture);
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
		private static int _g_get_StructBase64String(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, cardData.StructBase64String);
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
		private static int _g_get_StructId(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.StructId);
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
		private static int _g_get_Clock(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.Clock);
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
		private static int _g_get_Logic(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, cardData.Logic);
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
		private static int _g_get_CardLogicClassNames(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.CardLogicClassNames);
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
		private static int _g_get_CardLogics(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.CardLogics);
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
		private static int _g_get_ammoContainer(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.ammoContainer);
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
		private static int _g_get_ActDatas(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.ActDatas);
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
		private static int _g_get_sacrificeVal(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.sacrificeVal);
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
		private static int _g_get_rotateTime(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.rotateTime);
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
		private static int _g_get_IsFlipAnimDone(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, cardData.IsFlipAnimDone);
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
		private static int _g_get_IsAttacked(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, cardData.IsAttacked);
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
		private static int _g_get_Level(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.Level);
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
		private static int _g_get_MaxHP(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.MaxHP);
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
		private static int _g_get_HP(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.HP);
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
		private static int _g_get_HB(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)cardData.HB);
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
		private static int _g_get_EXATK(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.EXATK);
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
		private static int _g_get_EXATKTimes(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.EXATKTimes);
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
		private static int _g_get_EXRange(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.EXRange);
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
		private static int _g_get_AddHP(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.AddHP);
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
		private static int _g_get_InBattleATK(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.InBattleATK);
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
		private static int _g_get_AttackColor(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.AttackColor);
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
		private static int _g_get_Armor(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.Armor);
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
		private static int _g_get_wArmor(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.wArmor);
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
		private static int _g_get_MaxArmor(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.MaxArmor);
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
		private static int _g_get_DArmor(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)cardData.DArmor);
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
		private static int _g_get_DizzyLayer(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.DizzyLayer);
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
		private static int _g_get__ATK(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData._ATK);
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
		private static int _g_get__AttackTimes(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData._AttackTimes);
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
		private static int _g_get_wAttackTimes(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.wAttackTimes);
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
		private static int _g_get_NextAttackTimes(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.NextAttackTimes);
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
		private static int _g_get_AB(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)cardData.AB);
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
		private static int _g_get_MP(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.MP);
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
		private static int _g_get_BasicMaxMp(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.BasicMaxMp);
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
		private static int _g_get_ManaCost(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.ManaCost);
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
		private static int _g_get_MaxMP(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.MaxMP);
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
		private static int _g_get_DHP(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)cardData.DHP);
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
		private static int _g_get_wDHP(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)cardData.wDHP);
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
		private static int _g_get_wHP(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.wHP);
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
		private static int _g_get_DATK(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)cardData.DATK);
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
		private static int _g_get_wDATK(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)cardData.wDATK);
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
		private static int _g_get_wATK(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.wATK);
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
		private static int _g_get_ATKRange(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.ATKRange);
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
		private static int _g_get__CRIT(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData._CRIT);
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
		private static int _g_get_wCRIT(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.wCRIT);
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
		private static int _g_get_InBattleCRIT(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.InBattleCRIT);
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
		private static int _g_get_SPD(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.SPD);
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
		private static int _g_get_RemainSPD(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.RemainSPD);
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
		private static int _g_get_MoveRange(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.MoveRange);
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
		private static int _g_get_AttackExtraRange(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.AttackExtraRange);
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
		private static int _g_get_Exp(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.Exp);
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
		private static int _g_get_ShotEffect(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, cardData.ShotEffect);
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
		private static int _g_get_HitEffect(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, cardData.HitEffect);
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
		private static int _g_get_BlueLine(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.BlueLine);
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
		private static int _g_get_RedLine(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.RedLine);
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
		private static int _g_get_YellowLine(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.YellowLine);
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
		private static int _g_get_Value(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.Value);
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
		private static int _g_get_Price(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.Price);
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
		private static int _g_get_PriceMaxFluctuation(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.PriceMaxFluctuation);
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
		private static int _g_get_ContainsNumber(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.ContainsNumber);
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
		private static int _g_get_ContainsIDs(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.ContainsIDs);
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
		private static int _g_get_IsCopy(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, cardData.IsCopy);
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
		private static int _g_get_Belongings(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.Belongings);
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
		private static int _g_get_DefaultBelongings(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.DefaultBelongings);
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
		private static int _g_get_PreNameList(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, cardData.PreNameList);
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
		private static int _g_get_CoveredWidth(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.CoveredWidth);
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
		private static int _g_get_CoveredHeight(IntPtr L)
		{
			try
			{
				CardData cardData = (CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, cardData.CoveredHeight);
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
		private static int _s_set_CharactorTag(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				CharacterTag charactorTag;
				objectTranslator.Get<CharacterTag>(L, 2, out charactorTag);
				cardData.CharactorTag = charactorTag;
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
		private static int _s_set_PersonName(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).PersonName = Lua.lua_tostring(L, 2);
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
		private static int _s_set_TempData(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).TempData = (MinionTempData)objectTranslator.GetObject(L, 2, typeof(MinionTempData));
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
		private static int _s_set_CardGameObject(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).CardGameObject = (Card)objectTranslator.GetObject(L, 2, typeof(Card));
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
		private static int _s_set_CurrentCardSlotData(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).CurrentCardSlotData = (CardSlotData)objectTranslator.GetObject(L, 2, typeof(CardSlotData));
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
		private static int _s_set_IsToy(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).IsToy = Lua.lua_toboolean(L, 2);
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
		private static int _s_set_CurrentAreaID(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).CurrentAreaID = Lua.lua_tostring(L, 2);
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
		private static int _s_set_PreName(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).PreName = Lua.lua_tostring(L, 2);
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
		private static int _s_set_MergedCardModIDs(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).MergedCardModIDs = (List<string>)objectTranslator.GetObject(L, 2, typeof(List<string>));
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
		private static int _s_set_ADJ_Affix(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).ADJ_Affix = Lua.lua_tostring(L, 2);
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
		private static int _s_set_ADV_Affix(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).ADV_Affix = Lua.lua_tostring(L, 2);
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
		private static int _s_set_V_Affix(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).V_Affix = Lua.lua_tostring(L, 2);
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
		private static int _s_set_CharactorTagUlong(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).CharactorTagUlong = Lua.lua_touint64(L, 2);
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
		private static int _s_set_ArmsUsagePosition(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				ArmsUsagePositionType armsUsagePosition;
				objectTranslator.Get<ArmsUsagePositionType>(L, 2, out armsUsagePosition);
				cardData.ArmsUsagePosition = armsUsagePosition;
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
		private static int _s_set_UsageTimes(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).UsageTimes = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_MaxUsageTimes(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).MaxUsageTimes = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_TotalTime(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).TotalTime = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_RemainTime(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).RemainTime = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_Life(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				CardData cardData = (CardData)objectTranslator.FastGetCSObj(L, 1);
				CardData.LifeType life;
				objectTranslator.Get<CardData.LifeType>(L, 2, out life);
				cardData.Life = life;
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
		private static int _s_set_LimitedTime(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).LimitedTime = (float)Lua.lua_tonumber(L, 2);
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
		private static int _s_set_Frequency(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Frequency = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_killEnemyCount(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).killEnemyCount = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_MaxCount(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).MaxCount = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_Count(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Count = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_Rare(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Rare = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_CardTags(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).CardTags = Lua.lua_touint64(L, 2);
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
		private static int _s_set_AcceptTags(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).AcceptTags = Lua.lua_touint64(L, 2);
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
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).desc = Lua.lua_tostring(L, 2);
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
		private static int _s_set_UnHappy(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).UnHappy = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_Charm(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Charm = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_Production(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Production = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_Intelligence(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Intelligence = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_Struct(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).Struct = (string[])objectTranslator.GetObject(L, 2, typeof(string[]));
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
		private static int _s_set_StructWidth(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).StructWidth = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_StructHeight(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).StructHeight = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_StructTexture(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).StructTexture = (Texture2D)objectTranslator.GetObject(L, 2, typeof(Texture2D));
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
		private static int _s_set_StructBase64String(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).StructBase64String = Lua.lua_tostring(L, 2);
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
		private static int _s_set_StructId(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).StructId = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_Clock(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Clock = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_Logic(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Logic = Lua.lua_tostring(L, 2);
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
		private static int _s_set_CardLogicClassNames(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).CardLogicClassNames = (List<string>)objectTranslator.GetObject(L, 2, typeof(List<string>));
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
		private static int _s_set_CardLogics(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).CardLogics = (List<CardLogic>)objectTranslator.GetObject(L, 2, typeof(List<CardLogic>));
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
		private static int _s_set_ammoContainer(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).ammoContainer = (CardData)objectTranslator.GetObject(L, 2, typeof(CardData));
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
		private static int _s_set_ActDatas(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).ActDatas = (List<ActData>)objectTranslator.GetObject(L, 2, typeof(List<ActData>));
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
		private static int _s_set_sacrificeVal(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).sacrificeVal = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_rotateTime(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).rotateTime = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_IsFlipAnimDone(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).IsFlipAnimDone = Lua.lua_toboolean(L, 2);
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
		private static int _s_set_IsAttacked(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).IsAttacked = Lua.lua_toboolean(L, 2);
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
		private static int _s_set_Level(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Level = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_MaxHP(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).MaxHP = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_HP(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).HP = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_HB(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).HB = (float)Lua.lua_tonumber(L, 2);
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
		private static int _s_set_EXATK(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).EXATK = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_EXATKTimes(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).EXATKTimes = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_EXRange(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).EXRange = (List<int>)objectTranslator.GetObject(L, 2, typeof(List<int>));
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
		private static int _s_set_AddHP(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).AddHP = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_InBattleATK(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).InBattleATK = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_AttackColor(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).AttackColor = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_Armor(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Armor = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_wArmor(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).wArmor = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_MaxArmor(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).MaxArmor = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_DArmor(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DArmor = (float)Lua.lua_tonumber(L, 2);
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
		private static int _s_set_DizzyLayer(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DizzyLayer = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set__ATK(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1))._ATK = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set__AttackTimes(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1))._AttackTimes = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_wAttackTimes(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).wAttackTimes = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_NextAttackTimes(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).NextAttackTimes = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_AB(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).AB = (float)Lua.lua_tonumber(L, 2);
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
		private static int _s_set_MP(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).MP = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_BasicMaxMp(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).BasicMaxMp = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_ManaCost(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).ManaCost = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_MaxMP(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).MaxMP = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_DHP(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DHP = (float)Lua.lua_tonumber(L, 2);
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
		private static int _s_set_wDHP(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).wDHP = (float)Lua.lua_tonumber(L, 2);
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
		private static int _s_set_wHP(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).wHP = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_DATK(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DATK = (float)Lua.lua_tonumber(L, 2);
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
		private static int _s_set_wDATK(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).wDATK = (float)Lua.lua_tonumber(L, 2);
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
		private static int _s_set_wATK(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).wATK = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_ATKRange(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).ATKRange = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set__CRIT(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1))._CRIT = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_wCRIT(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).wCRIT = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_InBattleCRIT(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).InBattleCRIT = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_SPD(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).SPD = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_RemainSPD(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).RemainSPD = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_MoveRange(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).MoveRange = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_AttackExtraRange(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).AttackExtraRange = (List<Vector3Int>)objectTranslator.GetObject(L, 2, typeof(List<Vector3Int>));
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
		private static int _s_set_Exp(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Exp = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_ShotEffect(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).ShotEffect = Lua.lua_tostring(L, 2);
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
		private static int _s_set_HitEffect(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).HitEffect = Lua.lua_tostring(L, 2);
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
		private static int _s_set_BlueLine(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).BlueLine = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_RedLine(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).RedLine = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_YellowLine(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).YellowLine = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_Value(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Value = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_Price(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Price = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_PriceMaxFluctuation(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).PriceMaxFluctuation = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_ContainsNumber(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).ContainsNumber = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_ContainsIDs(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).ContainsIDs = (List<string>)objectTranslator.GetObject(L, 2, typeof(List<string>));
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
		private static int _s_set_IsCopy(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).IsCopy = Lua.lua_toboolean(L, 2);
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
		private static int _s_set_Belongings(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).Belongings = (List<string>)objectTranslator.GetObject(L, 2, typeof(List<string>));
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
		private static int _s_set_DefaultBelongings(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).DefaultBelongings = (List<string>)objectTranslator.GetObject(L, 2, typeof(List<string>));
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
		private static int _s_set_PreNameList(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((CardData)objectTranslator.FastGetCSObj(L, 1)).PreNameList = (List<string>)objectTranslator.GetObject(L, 2, typeof(List<string>));
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
		private static int _s_set_CoveredWidth(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).CoveredWidth = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_CoveredHeight(IntPtr L)
		{
			try
			{
				((CardData)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).CoveredHeight = Lua.xlua_tointeger(L, 2);
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
