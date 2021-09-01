using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[CSharpCallLua]
public interface ICardLogic
{
	CardLogic myCardLogic { get; set; }

	bool IsCustomAttack { get; set; }

	void Init();

	void OnShowTips();

	IEnumerator Terminate(CardSlotData cardSlotData);

	void OnLeftClick(List<Vector2[]> res);

	void OnRightClick(List<Vector2[]> res);

	void OnPlayerExitArea();

	void OnActEnd();

	IEnumerator OnEndTurn(bool isPlayerTurn);

	IEnumerator CustomAttack(CardSlotData target);

	IEnumerator OnTurnStart();

	IEnumerator OnAttackEffect(CardData origin, CardData target);

	IEnumerator OnHpChange(CardData player, int changedValue, CardData from);

	IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from);

	IEnumerator OnBeforeAttack(CardData player, CardSlotData target);

	IEnumerator OnAfterAttack(CardData player, CardSlotData target);

	IEnumerator OnFinishAttack(CardData player, CardSlotData target);

	IEnumerator OnKill(CardData target, int value, CardData from);

	void OnMerge(CardData mergeBy);

	IEnumerator OnMoneyChanged(int value);

	IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata);

	IEnumerator OnBattleStart();

	IEnumerator OnBattleEnd();

	IEnumerator OnUseSkill();

	IEnumerator OnCardBeforeUseSkill(CardData user, CardLogic origin);

	IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin);

	IEnumerator OnEnterArea(string areaID);

	IEnumerator OnMoveOnMap();

	IEnumerator BeforeFact();
}
