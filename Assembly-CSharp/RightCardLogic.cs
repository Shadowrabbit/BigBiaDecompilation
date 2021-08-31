using System;
using UnityEngine;

public class RightCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_右");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_右");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_右");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_右");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		DungeonOperationMgr.Instance.StartCoroutine(base.Shifting(this.CardData.CurrentCardSlotData, Vector3Int.right, base.GetMyBattleArea()));
		base.RemoveCardLogic(this.CardData, typeof(RightCardLogic), "RightCardLogic");
	}
}
