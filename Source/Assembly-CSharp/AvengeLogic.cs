using System;
using System.Collections;

public class AvengeLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		if (this.CardData == null || (this.CardData != null && this.CardData.HasTag(TagMap.随从)))
		{
			this.Color = CardLogicColor.white;
		}
		this.displayName = "复仇";
		this.Desc = "友方随从死亡时，获得+" + base.Layers.ToString() + "/+" + base.Layers.ToString();
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target != this.CardData && target.HasTag(TagMap.随从) && !target.HasTag(TagMap.衍生物))
		{
			this.CardData._ATK += base.Layers;
			this.CardData.MaxHP += base.Layers;
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, base.Layers, this.CardData, false, 0, true, false);
		}
		yield break;
	}
}
