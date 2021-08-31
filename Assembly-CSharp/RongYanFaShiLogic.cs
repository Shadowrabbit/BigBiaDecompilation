using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RongYanFaShiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_92");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_92");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_92");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_92");
	}

	public override IEnumerator OnBattleStart()
	{
		if (base.GetAllEmptySlotsInMyBattleArea().Count > 0)
		{
			base.ShowMe();
			CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("岩浆球"), true);
			Card.InitCard(cardData);
			cardData.CardGameObject.transform.position = this.CardData.CurrentCardSlotData.CardSlotGameObject.transform.position;
			yield return this.TryJump(cardData);
		}
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		if (base.GetAllEmptySlotsInMyBattleArea().Count > 0)
		{
			base.ShowMe();
			CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("岩浆球"), true);
			Card.InitCard(cardData);
			cardData.CardGameObject.transform.position = this.CardData.CurrentCardSlotData.CardSlotGameObject.transform.position;
			yield return this.TryJump(cardData);
		}
		yield break;
	}

	public IEnumerator TryJump(CardData jumpO)
	{
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
