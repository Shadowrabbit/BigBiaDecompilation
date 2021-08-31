using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class ChiYeCaiDeAChouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
	}

	public override IEnumerator BeforeFact()
	{
		List<CardSlotData> list = new List<CardSlotData>();
		List<CardSlotData> playerBattleArea = DungeonOperationMgr.Instance.PlayerBattleArea;
		if (playerBattleArea == null || playerBattleArea.Count == 0)
		{
			yield break;
		}
		CardData minion = new CardData();
		foreach (CardSlotData cardSlotData in playerBattleArea)
		{
			if (cardSlotData.ChildCardData == null)
			{
				list.Add(cardSlotData);
			}
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				minion = cardSlotData.ChildCardData;
			}
		}
		if (list.Count == 0)
		{
			yield break;
		}
		CardData achou = Card.InitCardDataByID("小恶魔");
		achou.PersonName = "阿丑";
		CardSlotData TargetSlot = list[SYNCRandom.Range(0, list.Count)];
		GameObject tempCard = Card.InitWithOutData(achou, true);
		tempCard.transform.position = DungeonController.Instance.Chessman.position;
		yield return tempCard.transform.DOJump(TargetSlot.CardSlotGameObject.transform.position, 0.5f, 5, 2f, false).WaitForCompletion();
		UnityEngine.Object.DestroyImmediate(tempCard);
		achou.PutInSlotData(TargetSlot, true);
		yield return new WaitForSeconds(1f);
		CardData hero = base.GetHero();
		JournalsConversation journalsConversation = new JournalsConversation();
		JournalsConversationManager.role1 = minion;
		DialogueLua.SetVariable("Role1ID", minion.ID);
		DialogueLua.SetVariable("Role1Name", LocalizationMgr.Instance.GetLocalizationWord(minion.Name) + "-" + minion.PersonName);
		JournalsConversationManager.role2 = hero;
		journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑18"), null));
		journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑19"), SpecialEventController.instance.StartConversation("发现阿丑")));
		journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑20"), null));
		journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_阿丑21"), null));
		yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation);
		JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("T_阿丑1"), null, null, null, null, null, null));
		yield break;
	}
}
