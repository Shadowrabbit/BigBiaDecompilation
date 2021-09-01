using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanYanLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_84");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_84"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_84");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_84"), base.Layers);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			int num;
			for (int i = 0; i < base.Layers; i = num + 1)
			{
				List<CardSlotData> myBattleArea = base.GetMyBattleArea();
				List<CardSlotData> list = new List<CardSlotData>();
				foreach (CardSlotData cardSlotData in myBattleArea)
				{
					if (cardSlotData.ChildCardData == null)
					{
						list.Add(cardSlotData);
					}
				}
				if (list.Count <= 0)
				{
					yield break;
				}
				base.ShowMe();
				CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("幼虫"), true);
				Card.InitCard(cardData);
				cardData.CardGameObject.transform.position = this.CardData.CurrentCardSlotData.CardSlotGameObject.transform.position;
				yield return this.TryJump(cardData);
				num = i;
			}
		}
		yield break;
	}

	public IEnumerator TryJump(CardData jumpO)
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
		yield return jumpO.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		if (jumpO.Attrs.ContainsKey("Col"))
		{
			jumpO.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}
}
