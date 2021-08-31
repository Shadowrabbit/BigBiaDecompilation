﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShiYiJiQiRenCardLogic : CardLogic
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
		foreach (CardSlotData cardSlotData in playerBattleArea)
		{
			if (cardSlotData.ChildCardData == null)
			{
				list.Add(cardSlotData);
			}
		}
		if (list.Count == 0)
		{
			yield break;
		}
		CardData girl = Card.InitCardDataByID("失忆的头");
		CardSlotData TargetSlot = list[SYNCRandom.Range(0, list.Count)];
		GameObject tempCard = Card.InitWithOutData(girl, true);
		tempCard.transform.position = DungeonController.Instance.Chessman.position;
		yield return tempCard.transform.DOJump(TargetSlot.CardSlotGameObject.transform.position, 0.5f, 5, 2f, false).WaitForCompletion();
		UnityEngine.Object.DestroyImmediate(tempCard);
		girl.PutInSlotData(TargetSlot, true);
		yield return new WaitForSeconds(1f);
		CardData hero = base.GetHero();
		JournalsConversation journalsConversation = new JournalsConversation();
		JournalsConversationManager.role1 = girl;
		JournalsConversationManager.role2 = hero;
		journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人12"), null));
		journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人13"), null));
		journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人14"), null));
		journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人15"), null));
		journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_机器人16"), null));
		yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation);
		JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("T_机器人"), null, null, null, null, null, null));
		yield break;
	}
}
