using System;
using System.Collections;
using System.Collections.Generic;

public class ShuaiGuoLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = "甩锅";
		this.Desc = "承受伤害时，将伤害传递至相邻单位（先左后右）。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		this.m_SkillTurn = 1;
		yield break;
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		if (player == this.CardData && this.m_SkillTurn > 0)
		{
			this.m_SkillTurn--;
			List<CardSlotData> yellowLineSlots = GameController.getInstance().YellowLineSlots;
			if (this.CardData.CurrentCardSlotData.GetAttr("Col").Equals("0") || this.CardData.CurrentCardSlotData.GetAttr("Col").Equals("2"))
			{
				if (yellowLineSlots[1].ChildCardData != null)
				{
					base.ShowMe();
					yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(yellowLineSlots[1].ChildCardData, value.value, from, true, 0, true, false);
					value.value = 0;
				}
			}
			else
			{
				if (yellowLineSlots[0].ChildCardData != null)
				{
					base.ShowMe();
					yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(yellowLineSlots[0].ChildCardData, value.value, from, true, 0, true, false);
					value.value = 0;
					yield break;
				}
				if (yellowLineSlots[2].ChildCardData != null)
				{
					base.ShowMe();
					yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(yellowLineSlots[2].ChildCardData, value.value, from, true, 0, true, false);
					value.value = 0;
				}
			}
		}
		yield break;
	}

	private int m_SkillTurn = 1;
}
