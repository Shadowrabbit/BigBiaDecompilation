using System;
using System.Collections;
using UnityEngine;

[CardLogicRequireRare(4)]
public class SenLinNvWuSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(4, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_131");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_131");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(4, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_131");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_131");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		CardData defaultTarget = base.GetDefaultTarget();
		if (defaultTarget == null || defaultTarget.HasTag(TagMap.BOSS) || defaultTarget.Level > 1)
		{
			yield break;
		}
		CardSlotData currentCardSlotData = defaultTarget.CurrentCardSlotData;
		base.ShowMe();
		defaultTarget.DeleteCardData();
		Card.InitCardDataByID(LocalizationMgr.Instance.GetLocalizationWord("GW_N_1")).PutInSlotData(currentCardSlotData, true);
		yield break;
	}
}
