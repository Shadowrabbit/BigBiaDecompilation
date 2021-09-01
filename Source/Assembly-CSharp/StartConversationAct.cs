using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class StartConversationAct : GameAct
{
	private void Start()
	{
		this.Init();
		if (GlobalController.Instance.GameSettingController.info.language == LanguageType.EN)
		{
			DialogueManager.instance.SetLanguage("en");
		}
		else
		{
			DialogueManager.instance.SetLanguage("");
		}
		GameController.getInstance().DialogueController.Actor = GameController.getInstance().PlayerToy;
		GameController.getInstance().DialogueController.Conversant = this.Source;
		GameController.getInstance().DialogueController.ConversantSlot = this.Source.CurrentCardSlot;
		GameController.getInstance().GameEventManager.OpenGameUI();
		List<string> list = new List<string>();
		list.Add("大饭店");
		list.Add("废弃货车");
		list.Add("战士残骸");
		list.Add("搜索遗迹");
		list.Add("清澈的湖水");
		list.Add("破落神殿");
		list.Add("赌博");
		list.Add("路边商店");
		list.Add("踩地雷");
		list.Add("运送货物");
		if (GlobalController.Instance.GameSettingController.info.language == LanguageType.ZH_CN)
		{
			list.Add("幸运女神在微笑");
		}
		DialogueManager.StartConversation(list[UnityEngine.Random.Range(0, list.Count)], base.transform, this.Source.CurrentCardSlot.transform);
		GameController.getInstance().GameEventManager.StartTalking();
	}

	public void OnConversationEnd(Transform actor)
	{
		this.isDone = true;
	}

	public IEnumerator ConversationProcess()
	{
		yield return SpecialEventController.instance.StartRandomDialog();
		this.Source.CardData.DeleteCardData();
		DungeonOperationMgr.Instance.FlipAllFlopableCards();
		this.ActEnd();
		yield break;
	}

	private void Update()
	{
		if (this.isDone)
		{
			this.Source.CardData.DeleteCardData();
			DungeonOperationMgr.Instance.FlipAllFlopableCards();
			this.ActEnd();
		}
	}

	private bool isDone;
}
