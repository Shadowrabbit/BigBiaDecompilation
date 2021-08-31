using System;

public class SameRowTempATKLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "攻击力";
		this.Desc = "同排所有单位攻击力+" + base.Layers.ToString() + "，持续1回合。";
	}

	public override void OnMerge(CardData mergeBy)
	{
		foreach (CardSlotData cardSlotData in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从) && base.GetMinionLine(cardSlotData.ChildCardData) == base.GetMinionLine(this.CardData))
			{
				CardLogic cardLogic = Activator.CreateInstance(Type.GetType("TempATKLogic")) as CardLogic;
				cardLogic.Init();
				cardLogic.Layers = base.Layers;
				cardLogic.CardData = cardSlotData.ChildCardData;
				cardSlotData.ChildCardData.CardLogics.Add(cardLogic);
				cardLogic.OnMerge(cardSlotData.ChildCardData);
			}
		}
		this.CardData.CardLogics.Remove(this);
		base.OnMerge(mergeBy);
	}
}
