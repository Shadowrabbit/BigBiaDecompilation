using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HengTiaoLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_66_1");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_66");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_66_1");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_66");
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (target.ChildCardData == this.CardData)
		{
			this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_66_2");
			base.ShowMe();
			this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_66_1");
			yield return this.TryJump(target);
		}
		yield break;
	}

	public IEnumerator TryJump(CardSlotData csd)
	{
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		if (myBattleArea == null)
		{
			yield break;
		}
		CardSlotData target = myBattleArea[UnityEngine.Random.Range(0, myBattleArea.Count)];
		while (target.ChildCardData != null)
		{
			target = myBattleArea[UnityEngine.Random.Range(0, myBattleArea.Count)];
		}
		CardData card = csd.ChildCardData;
		yield return card.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		if (card.Attrs.ContainsKey("Col"))
		{
			card.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}
}
