using System;
using System.Collections;
using UnityEngine;

[CardLogicRequireRare(4)]
public class RenZheSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.NeedEnergyCount = new Vector3Int(0, 2, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_132");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_132");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(0, 2, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_132");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_132");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		if (this.CardData.HasTag(TagMap.英雄))
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_英雄怎么能伪装自己"));
			yield break;
		}
		this.CardData.IsAttacked = true;
		CardSlotData currentCardSlotData = this.CardData.CurrentCardSlotData;
		CardData cardData = Card.InitCardDataByID("忍兔");
		cardData.Attrs.Add("Source", this.CardData);
		base.ShowMe();
		this.CardData.DeleteCardData();
		cardData.PutInSlotData(currentCardSlotData, true);
		cardData.IsAttacked = false;
		yield break;
	}
}
