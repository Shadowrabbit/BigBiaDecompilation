using System;
using System.Collections;
using UnityEngine;

public class ShadowBladeLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "影刃";
		this.Desc = "任意叛光者攻击前，对目标造成等同于攻击力的伤害。";
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		if (player.ModID == "叛光者" || player.ModID == "叛光者+" || player.ModID == "叛光者++")
		{
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, target.ChildCardData, this.CardData.ATK, 0.2f, false, 0, null, null);
		}
		yield break;
	}

	private WaitForSeconds waitSeconds = new WaitForSeconds(0.1f);
}
