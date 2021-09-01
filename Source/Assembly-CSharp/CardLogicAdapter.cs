using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CardLogicAdapter : CardLogic
{
	public override void Init()
	{
		base.Init();
		CardLogicAdapter.luaenv.DoString(GameController.ins.LuaLogicCache[this.LuaString], "chunk", null);
		this.ICardLogic = CardLogicAdapter.luaenv.Global.Get<ICardLogic>("ICardLogic");
		this.ICardLogic.myCardLogic = this;
		this.ICardLogic.Init();
	}

	public override IEnumerator BeforeFact()
	{
		yield return this.ICardLogic.BeforeFact();
		yield break;
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (this.ICardLogic.IsCustomAttack)
		{
			yield return this.ICardLogic.CustomAttack(target);
		}
		else if (!DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData) && DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		yield break;
	}

	public override void OnActEnd()
	{
		this.ICardLogic.OnActEnd();
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		yield return this.ICardLogic.OnAfterAttack(player, target);
		yield break;
	}

	public override IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
	{
		yield return this.ICardLogic.OnAfterKill(cardSlot, originCarddata);
		yield break;
	}

	public override IEnumerator OnAttackEffect(CardData origin, CardData target)
	{
		yield return this.ICardLogic.OnAttackEffect(origin, target);
		yield break;
	}

	public override IEnumerator OnBattleEnd()
	{
		yield return this.ICardLogic.OnBattleEnd();
		yield break;
	}

	public override IEnumerator OnBattleStart()
	{
		yield return this.ICardLogic.OnBattleStart();
		yield break;
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		yield return this.ICardLogic.OnBeforeAttack(player, target);
		yield break;
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		yield return this.ICardLogic.OnBeforeHpChange(player, value, from);
		yield break;
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		yield return this.ICardLogic.OnCardAfterUseSkill(user, origin);
		yield break;
	}

	public override IEnumerator OnCardBeforeUseSkill(CardData user, CardLogic origin)
	{
		yield return this.ICardLogic.OnCardBeforeUseSkill(user, origin);
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return this.ICardLogic.OnEndTurn(isPlayerTurn);
		yield break;
	}

	public override IEnumerator OnEnterArea(string areaID)
	{
		yield return this.ICardLogic.OnEnterArea(areaID);
		yield break;
	}

	public override IEnumerator OnFinishAttack(CardData player, CardSlotData target)
	{
		yield return this.ICardLogic.OnFinishAttack(player, target);
		yield break;
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		yield return this.ICardLogic.OnHpChange(player, changedValue, from);
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		yield return this.ICardLogic.OnKill(target, value, from);
		yield break;
	}

	public override void OnLeftClick(List<Vector2[]> res)
	{
		this.ICardLogic.OnLeftClick(res);
	}

	public override void OnMerge(CardData mergeBy)
	{
		this.ICardLogic.OnMerge(mergeBy);
	}

	public override IEnumerator OnMoneyChanged(int value)
	{
		yield return this.ICardLogic.OnMoneyChanged(value);
		yield break;
	}

	public override IEnumerator OnMoveOnMap()
	{
		yield return this.ICardLogic.OnMoveOnMap();
		yield break;
	}

	public override void OnPlayerExitArea()
	{
		this.ICardLogic.OnPlayerExitArea();
	}

	public override void OnRightClick(List<Vector2[]> res)
	{
		this.ICardLogic.OnRightClick(res);
	}

	public override void OnShowTips()
	{
		this.ICardLogic.OnShowTips();
	}

	public override IEnumerator OnTurnStart()
	{
		yield return this.ICardLogic.OnTurnStart();
		yield break;
	}

	public override IEnumerator OnUseSkill()
	{
		yield return this.ICardLogic.OnUseSkill();
		yield break;
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		yield return this.ICardLogic.Terminate(cardSlotData);
		yield break;
	}

	private ICardLogic ICardLogic;

	public string LuaString;

	public static LuaEnv luaenv = new LuaEnv();
}
