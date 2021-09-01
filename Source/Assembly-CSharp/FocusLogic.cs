using System;
using System.Collections;
using System.Collections.Generic;

public class FocusLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "专注";
		this.Desc = "若同列上方没有随从，攻击造成真实伤害。";
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		switch (base.GetMinionLine(this.CardData))
		{
		case 0:
			yield return DungeonOperationMgr.Instance.CustomizeAttack(this.CardData, target, this.CardData.ATK, null, 0, true, 0);
			yield break;
		case 1:
			if (playerSlotSets[playerSlotSets.IndexOf(this.CardData.CurrentCardSlotData) + playerSlotSets.Count / 3].ChildCardData == null)
			{
				yield return DungeonOperationMgr.Instance.CustomizeAttack(this.CardData, target, this.CardData.ATK, null, 0, true, 0);
				yield break;
			}
			break;
		case 2:
			if (playerSlotSets[playerSlotSets.IndexOf(this.CardData.CurrentCardSlotData) + playerSlotSets.Count / 3].ChildCardData == null && playerSlotSets[playerSlotSets.IndexOf(this.CardData.CurrentCardSlotData) + playerSlotSets.Count / 3 * 2].ChildCardData == null)
			{
				yield return DungeonOperationMgr.Instance.CustomizeAttack(this.CardData, target, this.CardData.ATK, null, 0, true, 0);
				yield break;
			}
			break;
		}
		yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		yield break;
	}
}
