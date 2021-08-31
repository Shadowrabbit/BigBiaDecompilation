using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiZhenLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_143");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_73");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_143");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_73");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			base.ShowMe();
			GameController.getInstance().MainCamera.transform.GetChild(0).GetComponent<CameraShake>().StartAnimate(0.3f, 0.1f, false);
			List<CardSlotData> playerSlots = new List<CardSlotData>();
			foreach (CardSlotData cardSlotData in GameController.getInstance().PlayerSlotSets)
			{
				if (cardSlotData.Attrs.ContainsKey("Col") && (int)cardSlotData.Attrs["Col"] < 3)
				{
					playerSlots.Add(cardSlotData);
				}
			}
			List<CardData> moveMinions = new List<CardData>();
			int num4;
			for (int i = 0; i < playerSlots.Count; i = num4 + 1)
			{
				if (playerSlots[i].ChildCardData != null && playerSlots[i].ChildCardData.HasTag(TagMap.随从) && !moveMinions.Contains(playerSlots[i].ChildCardData))
				{
					int num = i % 3;
					int num2 = i / 3;
					List<CardSlotData> list = new List<CardSlotData>();
					if (num == 0)
					{
						if (playerSlots[i + 1].ChildCardData == null)
						{
							list.Add(playerSlots[i + 1]);
						}
					}
					else if (num == 1)
					{
						if (playerSlots[i + 1].ChildCardData == null)
						{
							list.Add(playerSlots[i + 1]);
						}
						else if (playerSlots[i - 1].ChildCardData == null)
						{
							list.Add(playerSlots[i - 1]);
						}
					}
					else if (num == 2 && playerSlots[i - 1].ChildCardData == null)
					{
						list.Add(playerSlots[i - 1]);
					}
					CardSlotData target = null;
					if (list.Count > 0)
					{
						target = list[0];
						if (list.Count > 1)
						{
							target = list[UnityEngine.Random.Range(0, list.Count)];
						}
					}
					moveMinions.Add(playerSlots[i].ChildCardData);
					CardData card = playerSlots[i].ChildCardData;
					if (target != null)
					{
						yield return playerSlots[i].ChildCardData.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
						if (card.Attrs.ContainsKey("Col"))
						{
							card.Attrs["Col"] = target.Attrs["Col"];
						}
					}
					int num3 = (int)((float)this.CardData.ATK * 0.5f);
					num3 = ((card.HP - num3 > 0) ? num3 : card.HP);
					yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(card, -num3, this.CardData, false, 0, true, false);
					target = null;
					card = null;
				}
				num4 = i;
			}
			playerSlots = null;
			moveMinions = null;
		}
		yield break;
	}
}
