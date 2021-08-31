using System;

public class SameRowEnergyLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "充能";
		this.Desc = "同排所有单位增加" + base.Layers.ToString() + "能量。";
	}

	public override void OnMerge(CardData mergeBy)
	{
		foreach (CardSlotData cardSlotData in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从) && base.GetMinionLine(cardSlotData.ChildCardData) == base.GetMinionLine(this.CardData))
			{
				cardSlotData.ChildCardData.MP += base.Layers;
			}
		}
		this.CardData.CardLogics.Remove(this);
		base.OnMerge(mergeBy);
	}
}
