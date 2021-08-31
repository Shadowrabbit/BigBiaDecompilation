using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class ShiRenCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_知秋");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_知秋");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_知秋");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_知秋");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			yield break;
		}
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in base.GetAllCurrentMonsters())
		{
			if (cardData.ModID == "枫叶")
			{
				list.Add(cardData);
			}
		}
		if (list.Count > 0)
		{
			base.ShowMe();
			CardData cardData2 = list[SYNCRandom.Range(0, list.Count)];
			CardSlotData TargetSlot = cardData2.CurrentCardSlotData;
			yield return this.TryJump(TargetSlot, this.CardData.CurrentCardSlotData);
			switch (SYNCRandom.Range(0, 3))
			{
			case 0:
				Card.InitCardDataByID("慷慨之诗").PutInSlotData(TargetSlot, true);
				break;
			case 1:
				Card.InitCardDataByID("凌云之诗").PutInSlotData(TargetSlot, true);
				break;
			case 2:
				Card.InitCardDataByID("明月之诗").PutInSlotData(TargetSlot, true);
				break;
			}
			TargetSlot = null;
		}
		yield break;
	}

	public IEnumerator TryJump(CardSlotData csd, CardSlotData target)
	{
		CardData card = csd.ChildCardData;
		yield return card.CardGameObject.transform.DOJump(target.CardSlotGameObject.transform.position, 0.3f, 1, 0.2f, false).WaitForCompletion();
		yield return null;
		card.DeleteCardData();
		yield return null;
		yield break;
	}
}
