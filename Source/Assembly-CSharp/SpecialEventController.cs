using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class SpecialEventController : MonoBehaviour
{
	public void Awake()
	{
		SpecialEventController.instance = this;
	}

	public IEnumerator StartRandomDialog()
	{
		SpecialEventController.isDone = false;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.PlayerBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从) && !cardSlotData.ChildCardData.HasTag(TagMap.英雄))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		List<SpecialEvent> list2 = new List<SpecialEvent>();
		List<int> list3 = new List<int>();
		foreach (SpecialEvent specialEvent in SpecialEventController.specialEvents)
		{
			int item = specialEvent.IsAvailableCheckFunction();
			list2.Add(specialEvent);
			list3.Add(item);
		}
		int num = int.MinValue;
		for (int i = 0; i < list2.Count; i++)
		{
			if (num < list3[i])
			{
				num = list3[i];
			}
		}
		for (int j = list2.Count - 1; j >= 0; j--)
		{
			if (list3[j] < num)
			{
				list2.RemoveAt(j);
				list3.RemoveAt(j);
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			int index = SYNCRandom.Range(0, list.Count);
			CardData value = list[k];
			list[k] = list[index];
			list[index] = value;
		}
		int num2 = SYNCRandom.Range(0, 100);
		Debug.Log(num2);
		if (num2 < 30 && list.Count > 0)
		{
			GameController.ins.GameData.InnerMinionCardData = list[0];
			DialogueLua.SetVariable("TargetMinionName", list[0].PersonName);
			DialogueLua.SetVariable("TargetMinionModID", list[0].ModID);
			DialogueManager.StartConversation("初级成长", base.transform);
		}
		else if (list2.Count > 0 && list.Count >= 2)
		{
			int index2 = SYNCRandom.Range(0, list2.Count);
			DialogueLua.SetVariable("HeroID", GameController.ins.GameData.PlayerCardData.ID);
			DialogueLua.SetVariable("Role1ID", list[0].ID);
			DialogueLua.SetVariable("Role2ID", list[1].ID);
			DialogueLua.SetVariable("Role1Name", LocalizationMgr.Instance.GetLocalizationWord(list[0].Name) + "-" + list[0].PersonName);
			DialogueLua.SetVariable("Role2Name", LocalizationMgr.Instance.GetLocalizationWord(list[1].Name) + "-" + list[1].PersonName);
			SpecialEventController.isDone = false;
			if (list2[index2].BeforeConversationFunc != null)
			{
				list2[index2].BeforeConversationFunc();
			}
			DialogueManager.StartConversation(list2[index2].DialogName, base.transform);
		}
		else
		{
			DialogueManager.StartConversation("无事发生", base.transform);
		}
		while (!SpecialEventController.isDone)
		{
			yield return null;
		}
		yield break;
	}

	public IEnumerator StartConversation(string ConversationName)
	{
		SpecialEventController.isDone = false;
		DialogueManager.StartConversation(ConversationName, base.transform);
		while (!SpecialEventController.isDone)
		{
			yield return null;
		}
		yield break;
	}

	public void OnConversationEnd(Transform actor)
	{
		SpecialEventController.isDone = true;
	}

	public static SpecialEventController instance;

	public static List<SpecialEvent> specialEvents = new List<SpecialEvent>
	{
		new SpecialEvent("陷入爱河", () => 2, delegate()
		{
			foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.PlayerBattleArea)
			{
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从) && !cardSlotData.ChildCardData.HasTag(TagMap.英雄))
				{
					bool flag = false;
					CardData childCardData = cardSlotData.ChildCardData;
					using (List<CardLogic>.Enumerator enumerator2 = cardSlotData.ChildCardData.CardLogics.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							if (enumerator2.Current.GetType() == typeof(Logic_AiShangLe))
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						DialogueLua.SetVariable("Role1ID", childCardData.ID);
						DialogueLua.SetVariable("Role1Name", LocalizationMgr.Instance.GetLocalizationWord(childCardData.Name) + "-" + childCardData.PersonName);
						break;
					}
				}
			}
		}),
		new SpecialEvent("对抗怪物", () => 2, null),
		new SpecialEvent("拜师", () => 2, null),
		new SpecialEvent("想到好主意", () => 2, null),
		new SpecialEvent("扔香蕉皮", () => 2, null),
		new SpecialEvent("吃野菜的阿丑", () => 2, null),
		new SpecialEvent("石头剪子布秘籍", () => 2, null),
		new SpecialEvent("炫技的魔术师", () => 2, null),
		new SpecialEvent("牙缝里的食物", () => 2, null),
		new SpecialEvent("星星上的树", () => 2, null),
		new SpecialEvent("许愿池", () => 2, null),
		new SpecialEvent("神秘的阿丑", delegate()
		{
			foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.PlayerBattleArea)
			{
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从) && !cardSlotData.ChildCardData.HasTag(TagMap.英雄))
				{
					bool flag = false;
					foreach (CardLogic cardLogic in cardSlotData.ChildCardData.CardLogics)
					{
						if (cardLogic is PersonCardLogic && cardLogic.GetType() == typeof(Logic_BuZhong) && (cardLogic as PersonCardLogic).Reason == LocalizationMgr.Instance.GetLocalizationWord("T_扔掉阿丑"))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						return 10;
					}
				}
			}
			return 0;
		}, delegate()
		{
			foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.PlayerBattleArea)
			{
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从) && !cardSlotData.ChildCardData.HasTag(TagMap.英雄))
				{
					bool flag = false;
					CardData childCardData = cardSlotData.ChildCardData;
					foreach (CardLogic cardLogic in cardSlotData.ChildCardData.CardLogics)
					{
						if (cardLogic is PersonCardLogic && cardLogic.GetType() == typeof(Logic_BuZhong) && (cardLogic as PersonCardLogic).Reason == LocalizationMgr.Instance.GetLocalizationWord("T_扔掉阿丑"))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						DialogueLua.SetVariable("Role1ID", childCardData.ID);
						DialogueLua.SetVariable("Role1Name", LocalizationMgr.Instance.GetLocalizationWord(childCardData.Name) + "-" + childCardData.PersonName);
						break;
					}
				}
			}
		}),
		new SpecialEvent("古老的仪式", () => 2, null)
	};

	public static bool isDone = false;
}
