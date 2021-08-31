using System;
using System.Collections;
using DG.Tweening;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class AChouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
	}

	public override IEnumerator OnMoveOnMap()
	{
		base.OnMoveOnMap();
		if (this.HasEnd)
		{
			yield break;
		}
		JournalsConversationManager.role1 = this.CardData;
		CardData cardData = null;
		foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.PlayerBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ID.Equals(DialogueLua.GetVariable("Role1ID").asString))
			{
				cardData = cardSlotData.ChildCardData;
			}
		}
		CardData flower;
		GameObject tempCard;
		CardSlotData targetSlot;
		if (cardData != null)
		{
			JournalsConversationManager.role2 = cardData;
			if (GameController.ins.GameData.EventStep != this.m_preStep)
			{
				this.step++;
				this.m_preStep = GameController.ins.GameData.EventStep;
			}
			if (this.step % 7 == 0)
			{
				this.count++;
				switch (this.count)
				{
				case 1:
				{
					JournalsConversation journalsConversation = new JournalsConversation();
					journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑4"), null));
					journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑5"), null));
					journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑6"), null));
					journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑7"), null));
					yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation);
					break;
				}
				case 2:
				{
					JournalsConversation journalsConversation2 = new JournalsConversation();
					journalsConversation2.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑8"), null));
					journalsConversation2.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑9"), null));
					journalsConversation2.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑10"), null));
					journalsConversation2.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑11"), null));
					journalsConversation2.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑12"), null));
					yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation2);
					break;
				}
				case 3:
				{
					JournalsConversation journalsConversation3 = new JournalsConversation();
					journalsConversation3.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑13"), null));
					journalsConversation3.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑14"), null));
					journalsConversation3.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑15"), null));
					journalsConversation3.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑7"), null));
					yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation3);
					break;
				}
				default:
				{
					JournalsConversation journalsConversation4 = new JournalsConversation();
					journalsConversation4.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑10"), null));
					journalsConversation4.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑16"), null));
					journalsConversation4.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑17"), null));
					journalsConversation4.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑7"), SpecialEventController.instance.StartConversation("阿丑离开")));
					yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation4);
					flower = Card.InitCardDataByID("洋葱");
					tempCard = Card.InitWithOutData(flower, true);
					targetSlot = GameController.ins.GetEmptySlotDataByCardData(flower);
					if (targetSlot == null)
					{
						yield break;
					}
					tempCard.transform.position = this.CardData.CardGameObject.transform.position;
					yield return tempCard.transform.DOJump(targetSlot.CardSlotGameObject.transform.position, 0.5f, 1, 0.2f, false).WaitForCompletion();
					UnityEngine.Object.DestroyImmediate(tempCard);
					flower.PutInSlotData(targetSlot, true);
					this.HasEnd = true;
					this.CardData.DeleteCardData();
					yield break;
				}
				}
				flower = null;
				tempCard = null;
				targetSlot = null;
			}
			yield break;
		}
		JournalsConversationManager.role2 = base.GetHero();
		JournalsConversation journalsConversation5 = new JournalsConversation();
		journalsConversation5.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑1"), null));
		journalsConversation5.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑2"), null));
		journalsConversation5.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑3"), SpecialEventController.instance.StartConversation("阿丑伙伴牺牲")));
		yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation5);
		JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志1"), null, null, null, null, null, null));
		flower = Card.InitCardDataByID("洋葱");
		tempCard = Card.InitWithOutData(flower, true);
		targetSlot = GameController.ins.GetEmptySlotDataByCardData(flower);
		if (targetSlot == null)
		{
			yield break;
		}
		tempCard.transform.position = this.CardData.CardGameObject.transform.position;
		yield return tempCard.transform.DOJump(targetSlot.CardSlotGameObject.transform.position, 0.5f, 1, 0.2f, false).WaitForCompletion();
		UnityEngine.Object.DestroyImmediate(tempCard);
		flower.PutInSlotData(targetSlot, true);
		this.HasEnd = true;
		this.CardData.DeleteCardData();
		yield break;
	}

	private int step;

	private bool HasEnd;

	private int count;

	private int m_preStep;
}
