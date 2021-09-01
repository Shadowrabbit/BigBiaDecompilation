using System;

public class SameRowMaxHPLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "增加最大生命";
		this.Desc = "同排所有单位最大生命值" + base.Layers.ToString() + "。";
	}

	public override void OnMerge(CardData mergeBy)
	{
		foreach (CardSlotData cardSlotData in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从) && base.GetMinionLine(cardSlotData.ChildCardData) == base.GetMinionLine(this.CardData))
			{
				cardSlotData.ChildCardData.MaxHP += base.Layers;
			}
		}
		this.CardData.CardLogics.Remove(this);
		base.OnMerge(mergeBy);
	}
}
