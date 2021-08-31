using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenZheCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.NeedEnergyCount = new Vector3Int(0, 1, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_9");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_9"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_9");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_9"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardSlotData> CardSlots = base.GetEnemiesBattleArea();
		if (CardSlots == null)
		{
			yield break;
		}
		int num;
		for (int i = 0; i < CardSlots.Count; i = num + 1)
		{
			if (CardSlots[i].GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col") && CardSlots[i].ChildCardData != null && CardSlots[i].ChildCardData.HasTag(TagMap.怪物))
			{
				base.ShowMe();
				this.CardData.CardGameObject.gameObject.SetActive(false);
				yield return base.ShowCustomEffect("忍杀释放", this.CardData.CurrentCardSlotData, 0.5f);
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, CardSlots[i].ChildCardData, Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), 0.2f, false, 0, null, null);
				yield return base.ShowCustomEffect("忍杀释放", this.CardData.CurrentCardSlotData, 0.5f);
				this.CardData.CardGameObject.gameObject.SetActive(true);
				yield break;
			}
			num = i;
		}
		yield break;
	}

	private float baseDmg = 1f;

	private float increaseDmg = 0.5f;
}
