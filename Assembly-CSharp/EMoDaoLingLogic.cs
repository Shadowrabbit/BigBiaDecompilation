using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMoDaoLingLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_91");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_91");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_91");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_91");
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		if (target.ChildCardData != this.CardData)
		{
			yield break;
		}
		if (player.ATK > this.CardData.ATK)
		{
			yield return this.TryJump(this.CardData);
		}
		yield break;
	}

	public IEnumerator TryJump(CardData jumpO)
	{
		base.ShowMe();
		List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
		if (allEmptySlotsInMyBattleArea == null || allEmptySlotsInMyBattleArea.Count <= 0)
		{
			yield break;
		}
		CardSlotData target = allEmptySlotsInMyBattleArea[UnityEngine.Random.Range(0, allEmptySlotsInMyBattleArea.Count)];
		yield return jumpO.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		if (jumpO.Attrs.ContainsKey("Col"))
		{
			jumpO.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}
}
