using System;
using System.Collections;
using UnityEngine;

public class BloodthirstyLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		if (this.CardData == null || (this.CardData != null && this.CardData.HasTag(TagMap.随从)))
		{
			this.Color = CardLogicColor.red;
		}
		this.displayName = "享用美食";
		this.Desc = string.Concat(new string[]
		{
			"击杀时，回复",
			Mathf.CeilToInt(0.1f * (float)base.Layers * (float)this.CardData.ATK).ToString(),
			"[",
			(base.Layers * 10).ToString(),
			"%攻击力]生命值"
		});
	}

	public override IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
	{
		if (originCarddata != null && originCarddata == this.CardData && this.CardData.HP < this.CardData.MaxHP)
		{
			yield return base.Cure(this.CardData, Mathf.CeilToInt(0.1f * (float)base.Layers * (float)this.CardData.ATK), this.CardData);
		}
		yield break;
	}
}
