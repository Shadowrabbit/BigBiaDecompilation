using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
	private void Awake()
	{
		Lua.RegisterFunction("StartGift", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.StartGift(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("StartRandomGift", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.StartRandomGift(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("StartAct", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.StartAct(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("HaveEnoughMoney", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.HaveEnoughMoney(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("HaveEnoughCardSlots", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.HaveEnoughCardSlots(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("HaveEnoughCardSlotsWithTag", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.HaveEnoughCardSlotsWithTag(float, float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GetRandom", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GetRandom(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GiveMoney", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GiveMoney(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("IsPlayerHave", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.IsPlayerHave(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GetMoney", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GetMoney()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("RandomFlip", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.RandomFlip(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("CheckCardBacks", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.CheckCardBacks(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("CheckMinionsCount", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.CheckMinionsCount(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("ChangeRandomMinionATKAndMaxHP", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.ChangeRandomMinionATKAndMaxHP(float, float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("ChangeRandomMinionATKToAndATKTimes", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.ChangeRandomMinionATKToAndATKTimes(float, float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GetMonster", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GetMonster(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GiveRandomItem", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GiveRandomItem()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GiveRandomItemByType", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GiveRandomItemByType(string, float, float)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GiveRandomMinion", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GiveRandomMinion(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GiveRandomMinionWithProp", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GiveRandomMinionWithProp(float, float, float, float, float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("DeleteMinion", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.DeleteMinion(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("DeleteMinionById", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.DeleteMinionById(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("AllMinionsRecovery", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.AllMinionsRecovery(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("AllMinionsReset", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.AllMinionsReset()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("TargetLineChangeAttr", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.TargetLineChangeAttr(float, float, float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("TargetLineChangeRatioAttr", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.TargetLineChangeRatioAttr(float, float, float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("ChangeRatioAttrByModId", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.ChangeRatioAttrByModId(string, float, float)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("ChangeMinionHpByMaxHpRatio", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.ChangeMinionHpByMaxHpRatio(string, float)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("AllUnitLostArmor", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.AllUnitLostArmor()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("HaveMinion", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.HaveMinion(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GetRandomMinionModId", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GetRandomMinionModId(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GetRandomMinionButNotHeroModId", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GetRandomMinionButNotHeroModId(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GetCardByModId", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GetCardByModId(string, string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("HaveOtherMinion", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.HaveOtherMinion()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("NotHero", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.NotHero(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("HaveEnoughCardSlots", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.HaveEnoughCardSlots(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("StartJudge", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.StartJudge(float, float, float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("PlayContentVoice", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.PlayContentVoice(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("HaveEnoughVoxel", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.HaveEnoughVoxel(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("ChangeVoxel", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.ChangeVoxel(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("UnlockMinion", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.UnlockMinion()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("AllMinionsChangeUnHappy", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.AllMinionsChangeUnHappy(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("ChangeRatioAttrByID", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.ChangeRatioAttrByID(string, float, float)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GetMinionsByIndex", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GetMinionsByIndex()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("CheckMinionByIndex", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.CheckMinionByIndex(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("SelectedMinionByIndex", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.SelectedMinionByIndex(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GetSkillsByIndex", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GetSkillsByIndex()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("CheckSkillByIndex", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.CheckSkillByIndex(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("MergeSkillByIndex", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.MergeSkillByIndex(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("ChangeInnerMinionProp", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.ChangeInnerMinionProp(string, float)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("LogicOnePerson", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.LogicOnePerson(string, string, string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("LogicTwoPerson", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.LogicTwoPerson(string, string, string, string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("RemoveLogic", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.RemoveLogic(string, string, string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GetRandomMinionID", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GetRandomMinionID(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GetCardNameByID", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GetCardNameByID(string, string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("GetCardPersonNameByID", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.GetCardPersonNameByID(string, string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("IsHaveCharactorTag", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.IsHaveCharactorTag(string, string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("AllMinionsAddLogic", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.AllMinionsAddLogic(string, string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("AddLogicByCharacterTag", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.AddLogicByCharacterTag(string, string, float)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("AllMinionsRemoveDebuff", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.AllMinionsRemoveDebuff()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("AllMinionsChangeAttr", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.AllMinionsChangeAttr(float, float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("AllMinionsChangeRadioAttr", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.AllMinionsChangeRadioAttr(float, float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float)),
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("ChangeTorchNum", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.ChangeTorchNum(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("OpenShopWithDisCount", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.OpenShopWithDisCount(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("CheckTeamByCharactorTag", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.CheckTeamByCharactorTag(float)), new Expression[]
		{
			Expression.Constant(0f, typeof(float))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("ChangeMinionsAllLogicToOneColor", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.ChangeMinionsAllLogicToOneColor(string, string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty)),
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
		Lua.RegisterFunction("UpdateLogic", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(DialogueController)), methodof(DialogueController.UpdateLogic(string)), new Expression[]
		{
			Expression.Field(null, fieldof(string.Empty))
		}), Array.Empty<ParameterExpression>())));
	}

	private void OnDestroy()
	{
		Lua.UnregisterFunction("CheckTeamByCharactorTag");
		Lua.UnregisterFunction("OpenShopWithDisCount");
		Lua.UnregisterFunction("DeleteMinionById");
		Lua.UnregisterFunction("AllMinionsAddLogic");
		Lua.UnregisterFunction("ChangeTorchNum");
		Lua.UnregisterFunction("AllMinionsChangeAttr");
		Lua.UnregisterFunction("AllMinionsChangeRadioAttr");
		Lua.UnregisterFunction("AllMinionsRemoveDebuff");
		Lua.UnregisterFunction("ChangeInnerMinionProp");
		Lua.UnregisterFunction("GetMinionsByIndex");
		Lua.UnregisterFunction("CheckMinionByIndex");
		Lua.UnregisterFunction("SelectedMinionByIndex");
		Lua.UnregisterFunction("GetSkillsByIndex");
		Lua.UnregisterFunction("CheckSkillByIndex");
		Lua.UnregisterFunction("MergeSkillByIndex");
		Lua.UnregisterFunction("StartGift");
		Lua.UnregisterFunction("StartRandomGift");
		Lua.UnregisterFunction("StartAct");
		Lua.UnregisterFunction("HaveEnoughMoney");
		Lua.UnregisterFunction("HaveEnoughCardSlots");
		Lua.UnregisterFunction("GiveMoney");
		Lua.UnregisterFunction("IsPlayerHave");
		Lua.UnregisterFunction("PlayContentVoice");
		Lua.UnregisterFunction("GetRandom");
		Lua.UnregisterFunction("GetMoney");
		Lua.UnregisterFunction("RandomFlip");
		Lua.UnregisterFunction("CheckCardBacks");
		Lua.UnregisterFunction("CheckMinionsCount");
		Lua.UnregisterFunction("ChangeRandomMinionATKAndMaxHP");
		Lua.UnregisterFunction("ChangeRandomMinionATKToAndATKTimes");
		Lua.UnregisterFunction("GetMonster");
		Lua.UnregisterFunction("GiveRandomItem");
		Lua.UnregisterFunction("GiveRandomItemByType");
		Lua.UnregisterFunction("GiveRandomMinion");
		Lua.UnregisterFunction("DeleteMinion");
		Lua.UnregisterFunction("AllMinionsRecovery");
		Lua.UnregisterFunction("AllMinionsReset");
		Lua.UnregisterFunction("TargetLineChangeAttr");
		Lua.UnregisterFunction("TargetLineChangeRatioAttr");
		Lua.UnregisterFunction("ChangeRatioAttrByModId");
		Lua.UnregisterFunction("AllUnitLostArmor");
		Lua.UnregisterFunction("HaveMinion");
		Lua.UnregisterFunction("GetRandomMinionModId");
		Lua.UnregisterFunction("GetRandomMinionButNotHeroModId");
		Lua.UnregisterFunction("GetCardByModId");
		Lua.UnregisterFunction("HaveOtherMinion");
		Lua.UnregisterFunction("HaveEnoughCardSlots");
		Lua.UnregisterFunction("ChangeMinionHpByMaxHpRatio");
		Lua.UnregisterFunction("NotHero");
		Lua.UnregisterFunction("StartJudge");
		Lua.UnregisterFunction("HaveEnoughVoxel");
		Lua.UnregisterFunction("ChangeVoxel");
		Lua.UnregisterFunction("UnlockMinion");
		Lua.UnregisterFunction("AllMinionsChangeUnHappy");
		Lua.UnregisterFunction("LogicOnePerson");
		Lua.UnregisterFunction("LogicTwoPerson");
		Lua.UnregisterFunction("RemoveLogic");
		Lua.UnregisterFunction("ChangeRatioAttrByID");
		Lua.UnregisterFunction("GetRandomMinionID");
		Lua.UnregisterFunction("GetCardNameByID");
		Lua.UnregisterFunction("GetCardPersonNameByID");
		Lua.UnregisterFunction("IsHaveCharactorTag");
		Lua.UnregisterFunction("ChangeMinionsAllLogicToOneColor");
		Lua.UnregisterFunction("UpdateLogic");
	}

	private void OpenACcustomerShop(string ItemsString)
	{
		ActData actData = new ActData();
		actData.Type = "Act/DungeonShop";
		actData.Model = "ActTable/地下城商店";
		DungeonShopAct dungeonShopAct = GameController.ins.GameData.PlayerCardData.CardGameObject.StartAct(actData) as DungeonShopAct;
		if (!string.IsNullOrEmpty(ItemsString))
		{
			foreach (string text in ItemsString.Split(new char[]
			{
				','
			}))
			{
				dungeonShopAct.OptionNames.Add(text.Trim());
			}
		}
	}

	private bool CheckTeamByCharactorTag(float tag)
	{
		List<CardData> allCurrentMinions = this.GetAllCurrentMinions();
		int num = (int)tag;
		if (allCurrentMinions.Count == 0)
		{
			return false;
		}
		using (List<CardData>.Enumerator enumerator = allCurrentMinions.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (((int)enumerator.Current.CharactorTag & num) != 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void OpenShopWithDisCount(float discount)
	{
		ActData actData = new ActData();
		actData.Type = "Act/DungeonShop";
		actData.Model = "ActTable/地下城商店";
		(GameController.ins.GameData.PlayerCardData.CardGameObject.StartAct(actData) as DungeonShopAct).Discount = discount;
	}

	private void AddLogicByCharacterTag(string type, string reason, float tag)
	{
		List<CardData> allCurrentMinions = this.GetAllCurrentMinions();
		if (allCurrentMinions.Count == 0)
		{
			return;
		}
		foreach (CardData cardData in allCurrentMinions)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData) && this.IsHaveCharactorTag(cardData.ID, tag.ToString()))
			{
				this.LogicOnePerson(cardData.ID, reason, type);
			}
		}
	}

	private void AllMinionsAddLogic(string type, string reason)
	{
		List<CardData> allCurrentMinions = this.GetAllCurrentMinions();
		if (allCurrentMinions.Count == 0)
		{
			return;
		}
		foreach (CardData cardData in allCurrentMinions)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData) && (!(type == "HuaiYun") || (!(cardData.ModID == "熊孩子") && !(cardData.ModID == "流浪狗") && !cardData.HasTag(TagMap.特殊))))
			{
				this.LogicOnePerson(cardData.ID, reason, type);
			}
		}
	}

	private void ChangeTorchNum(float num)
	{
		if (num > 0f)
		{
			Vector3 position = GameController.getInstance().playerTableText.Money.transform.position + new Vector3(1f, 0f, 0f);
			string name = "Effect/HealMoney";
			ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = position;
		}
		GameController.ins.GameData.TorchNum += (int)num;
	}

	private void AllMinionsChangeRadioAttr(float type, float value)
	{
		List<CardData> allCurrentMinions = this.GetAllCurrentMinions();
		if (allCurrentMinions.Count == 0)
		{
			return;
		}
		if (type == 0f)
		{
			if (value > 0f)
			{
				DungeonOperationMgr.Instance.PlayCureEffect(allCurrentMinions);
			}
			else
			{
				DungeonOperationMgr.Instance.PlayLightningEffect(allCurrentMinions);
			}
			foreach (CardData cardData in allCurrentMinions)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cardData, Mathf.CeilToInt((float)cardData.MaxHP * value), null, false, 0, true, false));
				}
			}
		}
	}

	private void AllMinionsChangeAttr(float type, float value)
	{
		List<CardData> allCurrentMinions = this.GetAllCurrentMinions();
		if (allCurrentMinions.Count == 0)
		{
			return;
		}
		if (type == 0f)
		{
			if (value > 0f)
			{
				DungeonOperationMgr.Instance.PlayCureEffect(allCurrentMinions);
			}
			else
			{
				DungeonOperationMgr.Instance.PlayLightningEffect(allCurrentMinions);
			}
			foreach (CardData cardData in allCurrentMinions)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cardData, (int)value, null, false, 0, true, false));
				}
			}
		}
	}

	private void AllMinionsRemoveDebuff()
	{
		List<CardData> allCurrentMinions = this.GetAllCurrentMinions();
		if (allCurrentMinions.Count == 0)
		{
			return;
		}
		foreach (CardData cardData in allCurrentMinions)
		{
			if (cardData.CardLogics.Count != 0)
			{
				foreach (CardLogic cardLogic in cardData.CardLogics)
				{
					if (cardLogic is PersonCardLogic)
					{
						PersonCardLogic personCardLogic = cardLogic as PersonCardLogic;
						if (personCardLogic.IsDebuff)
						{
							cardData.RemoveCardLogic(personCardLogic);
						}
					}
				}
			}
		}
	}

	private void ChangeInnerMinionProp(string type, float val)
	{
		if (type != null)
		{
			if (type == "ATK")
			{
				GameController.ins.GameData.InnerMinionCardData._ATK += (int)val;
				return;
			}
			if (type == "MaxHP")
			{
				GameController.ins.GameData.InnerMinionCardData.MaxHP += (int)val;
				return;
			}
			if (!(type == "HP"))
			{
				return;
			}
			GameController.ins.GameData.InnerMinionCardData.HP += (int)val;
		}
	}

	private void GetMinionsByIndex()
	{
		List<CardData> allCurrentMinions = this.GetAllCurrentMinions();
		if (allCurrentMinions.Count == 0)
		{
			return;
		}
		int num = 1;
		using (List<CardData>.Enumerator enumerator = allCurrentMinions.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardData cardData = enumerator.Current;
				DialogueLua.SetVariable("Minion" + num.ToString(), cardData.ModID + " " + cardData.PersonName);
				num++;
			}
			goto IL_8B;
		}
		IL_6C:
		DialogueLua.SetVariable("Minion" + num.ToString(), "空");
		num++;
		IL_8B:
		if (num >= 10)
		{
			return;
		}
		goto IL_6C;
	}

	private bool CheckMinionByIndex(float index)
	{
		return !(DialogueLua.GetVariable("Minion" + index.ToString()).asString == "空");
	}

	private void SelectedMinionByIndex(float index)
	{
		List<CardData> allCurrentMinions = this.GetAllCurrentMinions();
		if (allCurrentMinions.Count > (int)index - 1)
		{
			DialogueLua.SetVariable("SelectedMinionModID", allCurrentMinions[(int)index - 1].ID);
			DialogueLua.SetVariable("SelectedMinionName", allCurrentMinions[(int)index - 1].ModID + " " + allCurrentMinions[(int)index - 1].PersonName);
		}
	}

	private void GetSkillsByIndex()
	{
		List<CardData> allCurrentMinions = this.GetAllCurrentMinions();
		if (allCurrentMinions.Count == 0 || DialogueLua.GetVariable("SelectedMinionModID").asString == "nil")
		{
			return;
		}
		foreach (CardData cardData in allCurrentMinions)
		{
			if (cardData.ID == DialogueLua.GetVariable("SelectedMinionModID").asString && cardData.CardLogics.Count > 0)
			{
				int num = 1;
				using (List<CardLogic>.Enumerator enumerator2 = cardData.CardLogics.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						CardLogic cardLogic = enumerator2.Current;
						if (!(cardLogic.GetType() == typeof(MinionLogic)))
						{
							DialogueLua.SetVariable("Skill" + num.ToString(), cardLogic.displayName + " " + ((cardLogic.Layers == 0) ? string.Empty : cardLogic.Layers.ToString()));
							num++;
						}
					}
					goto IL_12F;
				}
				goto IL_10E;
				IL_12F:
				if (num >= 10)
				{
					continue;
				}
				IL_10E:
				DialogueLua.SetVariable("Skill" + num.ToString(), "空");
				num++;
				goto IL_12F;
			}
		}
	}

	private bool CheckSkillByIndex(float index)
	{
		return !(DialogueLua.GetVariable("Skill" + index.ToString()).asString == "空");
	}

	private void MergeSkillByIndex(float index)
	{
		List<CardData> allCurrentMinions = this.GetAllCurrentMinions();
		if (allCurrentMinions.Count == 0 || DialogueLua.GetVariable("SelectedMinionModID").asString == "nil")
		{
			return;
		}
		foreach (CardData cardData in allCurrentMinions)
		{
			if (cardData.ID == DialogueLua.GetVariable("SelectedMinionModID").asString && cardData.CardLogics.Count > 0)
			{
				List<CardLogic> list = new List<CardLogic>();
				foreach (CardLogic cardLogic in cardData.CardLogics)
				{
					if (!(cardLogic.GetType() == typeof(MinionLogic)))
					{
						list.Add(cardLogic);
					}
				}
				this.AddLogic(list[(int)index - 1].GetType().Name, list[(int)index - 1].Layers, GameController.ins.GameData.InnerMinionCardData);
			}
		}
	}

	public void AddLogic(string logicName, int layers, CardData target)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Layers = layers;
		cardLogic.CardData = target;
		cardLogic.Init();
		if (target.CardLogicClassNames.Contains(logicName))
		{
			using (List<CardLogic>.Enumerator enumerator = target.CardLogics.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardLogic cardLogic2 = enumerator.Current;
					if (cardLogic2.GetType().Name == logicName && cardLogic2.Layers != 0)
					{
						CardLogic cardLogic3 = cardLogic2;
						int layers2 = cardLogic3.Layers;
						cardLogic3.Layers = layers2 + 1;
					}
				}
				return;
			}
		}
		target.CardLogics.Add(cardLogic);
		target.CardLogicClassNames.Add(logicName);
		cardLogic.OnMerge(target);
	}

	public List<CardData> GetAllCurrentMinions()
	{
		List<CardSlotData> playerBattleArea = DungeonOperationMgr.Instance.PlayerBattleArea;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in playerBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		return list;
	}

	private void AllMinionsChangeUnHappy(float val)
	{
		foreach (CardSlotData cardSlotData in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				cardSlotData.ChildCardData.UnHappy += (int)val;
			}
		}
	}

	private void UnlockMinion()
	{
		string asString = DialogueLua.GetVariable("UnlockMinionModID").asString;
		bool flag = false;
		using (List<string>.Enumerator enumerator = GlobalController.Instance.GetHadMinionsID().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current == asString)
				{
					flag = true;
				}
			}
		}
		if (!flag)
		{
			GlobalController.Instance.AddHadMinions(asString);
		}
		this.StartGift(asString);
	}

	private void ChangeVoxel(float val)
	{
		GlobalController.Instance.ChangeGlobalMoney((int)val);
	}

	private void StartJudge(float y, float r, float b)
	{
		DialogueLua.SetVariable("GainsYellowPointInEventBattle", 0);
		DialogueLua.SetVariable("GainsRedPointInEventBattle", 0);
		DialogueLua.SetVariable("GainsBluePointInEventBattle", 0);
		DungeonOperationMgr.Instance.GainsBluePointInEventBattle = 0;
		DungeonOperationMgr.Instance.GainsRedPointInEventBattle = 0;
		DungeonOperationMgr.Instance.GainsYellowPointInEventBattle = 0;
		base.StartCoroutine(this.StartJudgeProgress(y, r, b));
	}

	private IEnumerator StartJudgeProgress(float y, float r, float b)
	{
		foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.BattleArea)
		{
			if (cardSlotData.ChildCardData == null)
			{
				int num = SYNCRandom.Range(0, 100);
				CardData cardData;
				if ((float)num < y)
				{
					cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("黄色标记"), true);
				}
				else if ((float)num < y + r)
				{
					cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("红色标记"), true);
				}
				else
				{
					cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("蓝色标记"), true);
				}
				cardData.PutInSlotData(cardSlotData, true);
			}
		}
		UIController.LockLevel = UIController.UILevel.None;
		yield return DungeonOperationMgr.Instance.StartBattle(true);
		yield break;
	}

	private bool NotHero(string name)
	{
		List<CardData> allCurrentMinions = this.GetAllCurrentMinions();
		if (allCurrentMinions.Count == 0)
		{
			return false;
		}
		foreach (CardData cardData in allCurrentMinions)
		{
			if (cardData.ID == name && cardData.HasTag(TagMap.英雄))
			{
				return false;
			}
		}
		return true;
	}

	private void ChangeMinionHpByMaxHpRatio(string modid, float ratio)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		if (playerSlotSets == null)
		{
			return;
		}
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ModID == modid)
			{
				CardData childCardData = cardSlotData.ChildCardData;
				base.StartCoroutine(this.ChangeCardHp(childCardData, -Mathf.CeilToInt((float)childCardData.MaxHP * ratio)));
				break;
			}
		}
	}

	private IEnumerator ChangeCardHp(CardData cd, int value)
	{
		yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(new AttackMsg(cd, value, false, true, 0, 0, null), cd);
		yield break;
	}

	private void ChangeRatioAttrByModId(string modid, float attr, float ratio)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		if (playerSlotSets == null)
		{
			return;
		}
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ModID == modid)
			{
				CardData childCardData = cardSlotData.ChildCardData;
				if (attr == 0f)
				{
					base.StartCoroutine(this.ChangeCardHp(childCardData, -Mathf.CeilToInt((float)childCardData.HP * ratio)));
				}
				if (attr == 1f)
				{
					childCardData._ATK += Mathf.CeilToInt((float)childCardData.ATK * ratio);
				}
				if (attr == 2f)
				{
					childCardData.MP += Mathf.CeilToInt((float)childCardData.MP * ratio);
				}
				if (attr == 3f)
				{
					childCardData.Armor += Mathf.CeilToInt((float)childCardData.Armor * ratio);
				}
				if (attr == 4f)
				{
					childCardData.MaxHP += Mathf.CeilToInt((float)childCardData.MaxHP * ratio);
				}
				break;
			}
		}
	}

	private void ChangeRatioAttrByID(string ID, float attr, float ratio)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		if (playerSlotSets == null)
		{
			return;
		}
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ID == ID)
			{
				CardData childCardData = cardSlotData.ChildCardData;
				if (attr == 0f)
				{
					base.StartCoroutine(this.ChangeCardHp(childCardData, -Mathf.CeilToInt((float)childCardData.HP * ratio)));
				}
				if (attr == 1f)
				{
					childCardData._ATK += Mathf.CeilToInt((float)childCardData.ATK * ratio);
				}
				if (attr == 2f)
				{
					childCardData.MP += Mathf.CeilToInt((float)childCardData.MP * ratio);
				}
				if (attr == 3f)
				{
					childCardData.Armor += Mathf.CeilToInt((float)childCardData.Armor * ratio);
				}
				if (attr == 4f)
				{
					childCardData.MaxHP += Mathf.CeilToInt((float)childCardData.MaxHP * ratio);
				}
				break;
			}
		}
	}

	private void TargetLineChangeRatioAttr(float line, float attr, float ratio)
	{
		List<CardData> list = new List<CardData>();
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		int num = 0;
		int num2 = 0;
		if (line != 1f)
		{
			if (line != 2f)
			{
				if (line == 3f)
				{
					num = 0;
					num2 = playerSlotSets.Count / 3;
				}
			}
			else
			{
				num = playerSlotSets.Count / 3;
				num2 = playerSlotSets.Count / 3 * 2;
			}
		}
		else
		{
			num = playerSlotSets.Count / 3 * 2;
			num2 = playerSlotSets.Count;
		}
		for (int i = num; i < num2; i++)
		{
			if (playerSlotSets[i].ChildCardData != null && playerSlotSets[i].ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(playerSlotSets[i].ChildCardData);
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		foreach (CardData cardData in list)
		{
			if (attr == 0f)
			{
				base.StartCoroutine(this.ChangeCardHp(cardData, -Mathf.CeilToInt((float)cardData.HP * ratio)));
			}
			if (attr == 1f)
			{
				cardData._ATK += Mathf.CeilToInt((float)cardData.ATK * ratio);
			}
			if (attr == 2f)
			{
				cardData.MP += Mathf.CeilToInt((float)cardData.MP * ratio);
			}
			if (attr == 3f)
			{
				cardData.Armor += Mathf.CeilToInt((float)cardData.Armor * ratio);
			}
			if (attr == 4f)
			{
				cardData.MaxHP += Mathf.CeilToInt((float)cardData.MaxHP * ratio);
			}
		}
	}

	private bool HaveEnoughCardSlots(string type)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardSlotData> list = new List<CardSlotData>();
		ulong num = 128UL;
		if (type != null)
		{
			if (!(type == "minion"))
			{
				if (type == "item")
				{
					num = 65536UL;
				}
			}
			else
			{
				num = 128UL;
			}
		}
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData == null && (cardSlotData.TagWhiteList & num) > 0UL)
			{
				list.Add(cardSlotData);
			}
		}
		return list.Count > 0;
	}

	private bool HaveOtherMinion()
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		return list.Count > 1;
	}

	private void GetCardByModId(string modid, string type)
	{
		base.StartCoroutine(this.GetCardByModIdProcess(modid, type));
	}

	private IEnumerator GetCardByModIdProcess(string modid, string type)
	{
		CardData cardData = Card.InitCardDataByID(modid);
		CardSlotData emptySlotDataByCardData = GameController.ins.GetEmptySlotDataByCardData(cardData);
		if (emptySlotDataByCardData == null)
		{
			cardData.DeleteCardData();
			yield break;
		}
		Card.InitCard(cardData);
		cardData.CardGameObject.transform.position = this.ConversantSlot.transform.position;
		yield return cardData.CardGameObject.JumpToSlot(emptySlotDataByCardData.CardSlotGameObject, 0.3f, true);
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
	}

	private CardSlotData GetRandomSlot(string type)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardSlotData> list = new List<CardSlotData>();
		ulong num = 128UL;
		if (type != null)
		{
			if (!(type == "minion"))
			{
				if (type == "item")
				{
					num = 65536UL;
				}
			}
			else
			{
				num = 128UL;
			}
		}
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData == null && (cardSlotData.TagWhiteList & num) > 0UL)
			{
				list.Add(cardSlotData);
			}
		}
		if (list.Count > 0)
		{
			return list[SYNCRandom.Range(0, list.Count)];
		}
		return null;
	}

	private void GetRandomMinionModId(string name)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		DialogueLua.SetVariable(name, list[SYNCRandom.Range(0, list.Count - 1)].ModID);
	}

	private void GetRandomMinionButNotHeroModId(string name)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从) && !cardSlotData.ChildCardData.HasTag(TagMap.英雄))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		DialogueLua.SetVariable(name, list[SYNCRandom.Range(0, list.Count - 1)].ModID);
	}

	private void GetRandomMinionID(string name)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		DialogueLua.SetVariable(name, list[SYNCRandom.Range(0, list.Count - 1)].ID);
	}

	private void GetCardNameByID(string ID, string variableName)
	{
		string value;
		if (GameController.ins.CardDataInWorldMap[ID] != null)
		{
			value = LocalizationMgr.Instance.GetLocalizationWord(GameController.ins.CardDataInWorldMap[ID].Name);
		}
		else
		{
			value = "UnKown";
		}
		DialogueLua.SetVariable(variableName, value);
	}

	private void GetCardPersonNameByID(string ID, string variableName)
	{
		string value;
		if (GameController.ins.CardDataInWorldMap.ContainsKey(ID))
		{
			value = LocalizationMgr.Instance.GetLocalizationWord(GameController.ins.CardDataInWorldMap[ID].PersonName);
		}
		else
		{
			value = "UnKown";
		}
		DialogueLua.SetVariable(variableName, value);
	}

	private bool IsHaveCharactorTag(string ID, string TagNumber)
	{
		if (GameController.ins.CardDataInWorldMap[ID] != null)
		{
			int num = int.Parse(TagNumber);
			return ((int)GameController.ins.CardDataInWorldMap[ID].CharactorTag & num) != 0;
		}
		return false;
	}

	private bool GetRandom(float chance)
	{
		return (float)SYNCRandom.Range(0, 100) <= chance;
	}

	private bool IsPlayerHave(string key)
	{
		foreach (CardSlotData cardSlotData in GameController.getInstance().GameData.SlotsOnPlayerTable)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ModID != null && cardSlotData.ChildCardData.ModID == key)
			{
				return true;
			}
		}
		return false;
	}

	private void StartAct(string actName)
	{
		this.Conversant.StartAct(actName);
	}

	private void StartRandomGift(string Values)
	{
		ActData actData = new ActData();
		actData.Type = "Act/Gift";
		actData.Model = "ActTable/Gift";
		this.Conversant = GameController.ins.GameData.PlayerCardData.CardGameObject;
		GiftAct giftAct = this.Conversant.StartAct(actData) as GiftAct;
		if (Values != "")
		{
			string[] array = Values.Split(new char[]
			{
				','
			});
			if (array.Length != 0)
			{
				int num = SYNCRandom.Range(0, array.Length);
				giftAct.GiftNames.Add(array[num]);
			}
		}
	}

	public void StartGift(string Values)
	{
		ActData actData = new ActData();
		actData.Type = "Act/Gift";
		actData.Model = "ActTable/Gift";
		this.Conversant = GameController.ins.GameData.PlayerCardData.CardGameObject;
		GiftAct giftAct = this.Conversant.StartAct(actData) as GiftAct;
		if (Values != "")
		{
			string[] array = Values.Split(new char[]
			{
				','
			});
			if (array.Length != 0)
			{
				foreach (string item in array)
				{
					giftAct.GiftNames.Add(item);
				}
			}
		}
	}

	private int GetMoney()
	{
		return GameController.getInstance().GameData.Money;
	}

	private bool HaveEnoughMoney(float money)
	{
		return (float)GameController.getInstance().GameData.Money >= money;
	}

	private bool HaveEnoughVoxel(float voxel)
	{
		return (float)GlobalController.Instance.GlobalData.Money >= voxel;
	}

	private bool HaveEnoughCardSlots(float count)
	{
		return (float)GameController.getInstance().HasEmptCardSlotOnPlayerTable() >= count;
	}

	private bool HaveEnoughCardSlotsWithTag(float count, float tag)
	{
		return (float)GameController.getInstance().HasEmptCardSlotOnPlayerTable((ulong)tag) >= count;
	}

	private void GiveMoney(float money)
	{
		if (money <= 0f)
		{
			DungeonOperationMgr.Instance.ChangeMoney(-(int)money);
			return;
		}
		if ((float)GameController.getInstance().GameData.Money >= money)
		{
			DungeonOperationMgr.Instance.ChangeMoney(-(int)money);
			return;
		}
		DungeonOperationMgr.Instance.ChangeMoney(-GameController.getInstance().GameData.Money);
	}

	private void RandomFlip(float count)
	{
		List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
		List<CardData> list = new List<CardData>();
		CardData cardData = new CardData();
		foreach (CardSlotData cardSlotData in cardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.卡背))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		int num = 0;
		while ((float)num < count)
		{
			if (list.Count == 0)
			{
				return;
			}
			cardData = list[SYNCRandom.Range(0, list.Count)];
			DungeonOperationMgr.Instance.Flip(cardData, true);
			list.Remove(cardData);
			num++;
		}
	}

	private bool CheckCardBacks(float count)
	{
		List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in cardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.卡背))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		return (float)list.Count >= count;
	}

	private bool CheckMinionsCount(float count)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		return (float)list.Count >= count;
	}

	private CardData GetRandomMinion()
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		if (list.Count > 0)
		{
			return list[SYNCRandom.Range(0, list.Count)];
		}
		return null;
	}

	private void ChangeRandomMinionATKAndMaxHP(float atk, float hp)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardData> list = new List<CardData>();
		CardData cardData = new CardData();
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		if (list.Count > 0)
		{
			cardData = list[SYNCRandom.Range(0, list.Count)];
			cardData._ATK += Mathf.CeilToInt((float)(cardData.ATK * (int)atk) * 0.1f);
			if (cardData.ATK < 0)
			{
				cardData._ATK = 0;
			}
			cardData.MaxHP += Mathf.CeilToInt((float)(cardData.MaxHP * (int)hp) * 0.1f);
			if (cardData.HP > cardData.MaxHP)
			{
				int num = cardData.HP - cardData.MaxHP;
				GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cardData, -num, cardData, false, 0, true, false));
			}
		}
	}

	private void ChangeRandomMinionATKToAndATKTimes(float atk, float atkTimes)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardData> list = new List<CardData>();
		new CardData();
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		if (list.Count > 0)
		{
			CardData cardData = list[SYNCRandom.Range(0, list.Count)];
			cardData._ATK = (int)atk;
			cardData._AttackTimes += (int)atkTimes;
		}
	}

	private void GetMonster(string modId)
	{
		base.StartCoroutine(this.GetMonsterPorcess(modId));
	}

	private IEnumerator GetMonsterPorcess(string modId)
	{
		CardData Monster = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(modId), true);
		Monster = DungeonOperationMgr.Instance.InitSceneMonster(Monster);
		Card.InitCard(Monster);
		Monster.CardGameObject.transform.position = this.ConversantSlot.transform.position;
		yield return DungeonOperationMgr.Instance.MonsterJumpToBattleArea(Monster, true);
		UIController.LockLevel = UIController.UILevel.None;
		yield return DungeonOperationMgr.Instance.StartBattle(false);
		Monster.DizzyLayer++;
		yield break;
	}

	private void GiveRandomItem()
	{
		ActData actData = new ActData();
		actData.Type = "Act/Gift";
		actData.Model = "ActTable/Gift";
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		List<CardData> list = new List<CardData>();
		GiftAct giftAct = this.Conversant.StartAct(actData) as GiftAct;
		foreach (CardData cardData in cards)
		{
			if (cardData.HasTag(TagMap.道具) && !cardData.HasTag(TagMap.衍生物) && cardData.Rare <= 2)
			{
				list.Add(cardData);
			}
		}
		if (list.Count > 0)
		{
			CardData cardData2 = list[SYNCRandom.Range(0, list.Count)];
			giftAct.GiftNames.Add(cardData2.ModID);
		}
	}

	private void GiveRandomItemByType(string type, float minRare, float maxRare)
	{
		ActData actData = new ActData();
		actData.Type = "Act/Gift";
		actData.Model = "ActTable/Gift";
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		List<CardData> list = new List<CardData>();
		GiftAct giftAct = this.Conversant.StartAct(actData) as GiftAct;
		TagMap tagMask = TagMap.道具;
		if (type != null)
		{
			if (!(type == "Item"))
			{
				if (!(type == "Arm"))
				{
					if (!(type == "Tool"))
					{
						if (!(type == "Food"))
						{
							if (!(type == "Meat"))
							{
								if (type == "Potion")
								{
									tagMask = TagMap.药水;
								}
							}
							else
							{
								tagMask = TagMap.肉;
							}
						}
						else
						{
							tagMask = TagMap.食物;
						}
					}
					else
					{
						tagMask = TagMap.工具;
					}
				}
				else
				{
					tagMask = TagMap.装备;
				}
			}
			else
			{
				tagMask = TagMap.道具;
			}
		}
		foreach (CardData cardData in cards)
		{
			if (cardData.HasTag(tagMask) && !cardData.HasTag(TagMap.特殊) && !cardData.HasTag(TagMap.衍生物) && (float)cardData.Rare >= minRare && (float)cardData.Rare <= maxRare)
			{
				list.Add(cardData);
			}
		}
		if (list.Count > 0)
		{
			CardData cardData2 = list[SYNCRandom.Range(0, list.Count)];
			giftAct.GiftNames.Add(cardData2.ModID);
		}
	}

	private void GiveRandomMinionWithProp(float rare, float hp = -1f, float atk = -1f, float mp = -1f, float armor = -1f)
	{
		ActData actData = new ActData();
		actData.Type = "Act/Gift";
		actData.Model = "ActTable/Gift";
		List<CardData> allUnlockMinions = this.GetAllUnlockMinions(rare);
		GiftAct giftAct = this.Conversant.StartAct(actData) as GiftAct;
		if (allUnlockMinions.Count > 0)
		{
			CardData cardData = allUnlockMinions[SYNCRandom.Range(0, allUnlockMinions.Count)];
			if (hp > 0f)
			{
				cardData.HP = (int)hp;
			}
			if (hp > 0f)
			{
				cardData._ATK = (int)atk;
			}
			if (hp > 0f)
			{
				cardData.MP = (int)mp;
			}
			if (hp > 0f)
			{
				cardData.Armor = (int)armor;
			}
			giftAct.GiftNames.Add(cardData.ModID);
		}
	}

	private void GiveRandomMinion(float rare)
	{
		ActData actData = new ActData();
		actData.Type = "Act/Gift";
		actData.Model = "ActTable/Gift";
		List<CardData> allUnlockMinions = this.GetAllUnlockMinions(rare);
		GiftAct giftAct = this.Conversant.StartAct(actData) as GiftAct;
		if (allUnlockMinions.Count > 0)
		{
			CardData cardData = allUnlockMinions[SYNCRandom.Range(0, allUnlockMinions.Count)];
			giftAct.GiftNames.Add(cardData.ModID);
		}
	}

	private List<CardData> GetAllUnlockMinions(float rare)
	{
		List<CardData> list = new List<CardData>();
		List<CardData> list2 = new List<CardData>();
		List<CardData> list3 = new List<CardData>();
		List<CardData> list4 = new List<CardData>();
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if (cardData.CardTags == 128UL)
			{
				CardData cardData2 = CardData.CopyCardData(cardData, true);
				if (cardData2 != null)
				{
					switch (cardData2.Rare)
					{
					case 1:
						list2.Add(cardData2);
						break;
					case 2:
						list3.Add(cardData2);
						break;
					case 3:
						list4.Add(cardData2);
						break;
					}
					list.Add(cardData2);
				}
			}
		}
		if (rare == 0f)
		{
			return list;
		}
		if (rare == 1f)
		{
			return list2;
		}
		if (rare == 2f)
		{
			return list3;
		}
		if (rare != 3f)
		{
			return list;
		}
		return list4;
	}

	private void DeleteMinionById(string id)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		if (playerSlotSets == null)
		{
			return;
		}
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ID == id)
			{
				cardSlotData.ChildCardData.DeleteCardData();
				break;
			}
		}
	}

	private void DeleteMinion(string modid)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		if (playerSlotSets == null)
		{
			return;
		}
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ModID == modid)
			{
				cardSlotData.ChildCardData.DeleteCardData();
				break;
			}
		}
	}

	private bool HaveMinion(string modid)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		if (playerSlotSets == null)
		{
			return false;
		}
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ModID == modid)
			{
				return true;
			}
		}
		return false;
	}

	private void AllMinionsRecovery(float value)
	{
		base.StartCoroutine(this.AllMinionsRecoveryProcess(value));
	}

	private IEnumerator AllMinionsRecoveryProcess(float value)
	{
		UIController.LockLevel = UIController.UILevel.All;
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		if (list.Count <= 0)
		{
			yield break;
		}
		foreach (CardData cardData in list)
		{
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cardData, (int)value, cardData, false, 0, true, false);
		}
		List<CardData>.Enumerator enumerator2 = default(List<CardData>.Enumerator);
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
		yield break;
	}

	private void AllMinionsReset()
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		foreach (CardData cardData in list)
		{
			if (cardData.IsAttacked)
			{
				cardData.IsAttacked = false;
			}
		}
	}

	private void TargetLineChangeAttr(float line, float attr, float val)
	{
		List<CardData> list = new List<CardData>();
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		int num = 0;
		int num2 = 0;
		if (line != 1f)
		{
			if (line != 2f)
			{
				if (line == 3f)
				{
					num = 0;
					num2 = playerSlotSets.Count / 3;
				}
			}
			else
			{
				num = playerSlotSets.Count / 3;
				num2 = playerSlotSets.Count / 3 * 2;
			}
		}
		else
		{
			num = playerSlotSets.Count / 3 * 2;
			num2 = playerSlotSets.Count;
		}
		for (int i = num; i < num2; i++)
		{
			if (playerSlotSets[i].ChildCardData != null && playerSlotSets[i].ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(playerSlotSets[i].ChildCardData);
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		foreach (CardData cardData in list)
		{
			if (attr == 0f)
			{
				base.StartCoroutine(this.ChangeCardHp(cardData, -(int)val));
			}
			if (attr == 1f)
			{
				cardData._ATK += (int)val;
			}
			if (attr == 2f)
			{
				cardData.MP += (int)val;
			}
			if (attr == 3f)
			{
				cardData.MaxArmor += (int)val;
				cardData.Armor += (int)val;
			}
			if (attr == 4f)
			{
				cardData.MaxHP += (int)val;
			}
		}
	}

	private void AllUnitLostArmor()
	{
		List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in cardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.怪物))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		foreach (CardSlotData cardSlotData2 in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData2.ChildCardData);
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		foreach (CardData cardData in list)
		{
			if (cardData.Armor > 0)
			{
				cardData.Armor = 0;
			}
		}
	}

	private void PlayContentVoice(string content)
	{
	}

	private CardData GetCardByID(string ID)
	{
		CardData result = null;
		foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.PlayerBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ID.Equals(ID))
			{
				result = cardSlotData.ChildCardData;
			}
		}
		return result;
	}

	private void AddLogic(CardData data, string logicName)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		cardLogic.CardData = data;
		data.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(data);
	}

	private void AddLogic(CardData data, string logicName, string reason, string targetName = null, float step = 0f)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		if (targetName != null && targetName.Length == 0)
		{
			CardLogic cardLogic2 = cardLogic;
			cardLogic2.displayName = cardLogic2.displayName + " " + targetName;
		}
		CardLogic cardLogic3 = cardLogic;
		cardLogic3.Desc = cardLogic3.Desc + "\n " + LocalizationMgr.Instance.GetLocalizationWord("T_52") + LocalizationMgr.Instance.GetLocalizationWord(reason);
		cardLogic.CardData = data;
		data.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(data);
		if (cardLogic is PersonCardLogic)
		{
			(cardLogic as PersonCardLogic).Reason = reason;
		}
		if (cardLogic is TwoPeopleCardLogic)
		{
			(cardLogic as TwoPeopleCardLogic).TargetID = targetName;
		}
		cardLogic.ExistsRound = (int)step;
	}

	private void LogicOnePerson(string ID, string reason, string type)
	{
		CardData cardByID = this.GetCardByID(ID);
		if (cardByID != null)
		{
			if (cardByID.Attrs.ContainsKey("Logic_" + type + "_Reason"))
			{
				(cardByID.Attrs["Logic_" + type + "_Reason"] as List<string>).Add(reason);
				this.AddLogic(cardByID, "Logic_" + type, reason, null, 3f);
				return;
			}
			cardByID.Attrs.Add("Logic_" + type + "_Reason", new List<string>
			{
				reason
			});
			this.AddLogic(cardByID, "Logic_" + type, reason, null, 3f);
		}
	}

	private void LogicTwoPerson(string fromID, string targetID, string reason, string type)
	{
		CardData cardByID = this.GetCardByID(fromID);
		if (cardByID != null)
		{
			if (cardByID.Attrs.ContainsKey("Logic_" + type + "_Reason"))
			{
				(cardByID.Attrs["Logic_" + type + "_Reason"] as List<string>).Add(reason);
				this.AddLogic(cardByID, "Logic_" + type, reason, LocalizationMgr.Instance.GetLocalizationWord(this.GetCardByID(targetID).Name) + " " + this.GetCardByID(targetID).PersonName, 0f);
			}
			else
			{
				cardByID.Attrs.Add("Logic_" + type + "_Reason", new List<string>
				{
					reason
				});
				this.AddLogic(cardByID, "Logic_" + type, reason, LocalizationMgr.Instance.GetLocalizationWord(this.GetCardByID(targetID).Name) + " " + this.GetCardByID(targetID).PersonName, 0f);
			}
			if (cardByID.Attrs.ContainsKey("Logic_" + type + "_Target"))
			{
				(cardByID.Attrs["Logic_" + type + "_Target"] as List<string>).Add(targetID);
				return;
			}
			cardByID.Attrs.Add("Logic_" + type + "_Target", new List<string>
			{
				targetID
			});
		}
	}

	private void RemoveLogic(string ID, string reason, string type)
	{
		CardData cardByID = this.GetCardByID(ID);
		if (cardByID != null)
		{
			for (int i = 0; i < cardByID.CardLogics.Count; i++)
			{
				CardLogic cardLogic = cardByID.CardLogics[i];
				if (cardLogic is PersonCardLogic && cardLogic.GetType() == Type.GetType("Logic_" + type) && (cardLogic as PersonCardLogic).Reason == reason)
				{
					cardByID.RemoveCardLogic(cardLogic);
					return;
				}
			}
		}
	}

	private void ChangeMinionsAllLogicToOneColor(string ID, string ColorNum)
	{
		if (GameController.ins.CardDataInWorldMap.ContainsKey(ID))
		{
			CardData cardData = GameController.ins.CardDataInWorldMap[ID];
			if (cardData.CardLogics == null)
			{
				return;
			}
			foreach (CardLogic cardLogic in cardData.CardLogics)
			{
				cardLogic.Color = (CardLogicColor)int.Parse(ColorNum);
			}
		}
	}

	private void UpdateLogic(string modID)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		if (playerSlotSets == null)
		{
			return;
		}
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ModID == modID)
			{
				GameController.ins.UIController.ShowUpdateCardLogicPanel(cardSlotData.ChildCardData, 1, 1);
				break;
			}
		}
	}

	public Card Actor;

	public Card Conversant;

	public CardSlot ConversantSlot;
}
