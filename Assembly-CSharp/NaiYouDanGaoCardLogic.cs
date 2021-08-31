using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaiYouDanGaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_卡路里");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_卡路里"), this.buff);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_卡路里");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_卡路里"), this.buff);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
			List<CardData> ProtectTargets = new List<CardData>();
			if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) < slotsOnPlayerTable.Count / 3 * 2)
			{
				CardSlotData cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3];
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
				{
					ProtectTargets.Add(cardSlotData.ChildCardData);
				}
			}
			if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != 0 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 * 2)
			{
				CardSlotData cardSlotData2 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) - 1];
				if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
				{
					ProtectTargets.Add(cardSlotData2.ChildCardData);
				}
			}
			if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 - 1 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 * 2 - 1 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count - 1)
			{
				CardSlotData cardSlotData3 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) + 1];
				if (cardSlotData3.ChildCardData != null && cardSlotData3.ChildCardData.HasTag(TagMap.随从))
				{
					ProtectTargets.Add(cardSlotData3.ChildCardData);
				}
			}
			if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) >= slotsOnPlayerTable.Count / 3)
			{
				CardSlotData cardSlotData4 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3];
				if (cardSlotData4.ChildCardData != null && cardSlotData4.ChildCardData.HasTag(TagMap.随从))
				{
					ProtectTargets.Add(cardSlotData4.ChildCardData);
				}
			}
			if (ProtectTargets.Count <= 0)
			{
				yield break;
			}
			foreach (CardData cardData in ProtectTargets)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData) && cardData.HP < cardData.MaxHP)
				{
					DungeonOperationMgr.Instance.StartCoroutine(base.PlayCureEffect(this.CardData, cardData));
				}
			}
			yield return new WaitForSeconds(0.3f);
			foreach (CardData cardData2 in ProtectTargets)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData2))
				{
					base.Show(LocalizationMgr.Instance.GetLocalizationWord("T_真香"), cardData2);
					cardData2.AddAffix(DungeonAffix.weak, this.buff);
					yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cardData2, Mathf.CeilToInt(0.1f * (float)cardData2.MaxHP), this.CardData, false, 0, true, false);
				}
			}
			List<CardData>.Enumerator enumerator2 = default(List<CardData>.Enumerator);
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -9999, this.CardData, true, 0, true, false);
			ProtectTargets = null;
		}
		yield break;
		yield break;
	}

	private int buff = 3;
}
