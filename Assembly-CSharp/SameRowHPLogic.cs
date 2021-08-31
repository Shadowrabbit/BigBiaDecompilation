using System;

public class SameRowHPLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "回复生命";
		this.Desc = "同排所有单位回复" + base.Layers.ToString() + "生命。";
	}

	public override void OnMerge(CardData mergeBy)
	{
		foreach (CardSlotData cardSlotData in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从) && base.GetMinionLine(cardSlotData.ChildCardData) == base.GetMinionLine(this.CardData) && cardSlotData.ChildCardData.HP < cardSlotData.ChildCardData.MaxHP)
			{
				cardSlotData.ChildCardData.HP = ((cardSlotData.ChildCardData.HP + base.Layers > cardSlotData.ChildCardData.MaxHP) ? cardSlotData.ChildCardData.MaxHP : (cardSlotData.ChildCardData.HP + base.Layers));
				ParticlePoolManager.Instance.Spawn("Effect/HealHp", 3f).transform.position = cardSlotData.ChildCardData.CardGameObject.transform.position;
			}
		}
		this.CardData.CardLogics.Remove(this);
		base.OnMerge(mergeBy);
	}
}
