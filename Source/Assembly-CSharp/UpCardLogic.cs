using System;
using UnityEngine;

public class UpCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_上");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_上");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_上");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_上");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		DungeonOperationMgr.Instance.StartCoroutine(base.Shifting(this.CardData.CurrentCardSlotData, Vector3Int.down, base.GetMyBattleArea()));
		base.RemoveCardLogic(this.CardData, typeof(UpCardLogic), "UpCardLogic");
	}
}
