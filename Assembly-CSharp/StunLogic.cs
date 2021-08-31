using System;
using System.Collections;

public class StunLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "禁锢";
		this.Desc = "当前单位不可移动。";
		this.ExistsRound = 2;
		if (this.CardData != null)
		{
			this.CardData.CurrentCardSlotData.SlotType = CardSlotData.Type.Freeze;
		}
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		return base.OnEndTurn(isPlayerTurn);
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		base.Terminate(cardSlotData);
		if (this.CardData != null)
		{
			this.CardData.CurrentCardSlotData.SlotType = CardSlotData.Type.Normal;
			yield break;
		}
		yield break;
	}
}
