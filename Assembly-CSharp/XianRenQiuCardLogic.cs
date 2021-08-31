using System;
using System.Collections;
using UnityEngine;

public class XianRenQiuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_尖刺");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_尖刺"), Mathf.CeilToInt((float)this.CardData.ATK * 0.5f * (float)base.Layers), 50 * base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_尖刺");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_尖刺"), Mathf.CeilToInt((float)this.CardData.ATK * 0.5f * (float)base.Layers), 50 * base.Layers);
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (!DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData) && target.ChildCardData == this.CardData && this.CardData.Armor > 0)
		{
			base.ShowMe();
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, player, Mathf.CeilToInt((float)this.CardData.ATK * 0.5f * (float)base.Layers), 0.2f, false, 0, null, null);
		}
		yield break;
	}
}
