using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class JournalsConversationManager
{
	public static void PutJournals(JournalsBean journalsBean)
	{
		GameController.ins.GameData.JournalsList.Add(journalsBean);
		TextMeshProUGUI journalsText = GameController.ins.UIController.JournalsText;
		journalsText.text = journalsText.text + "\n\n" + journalsBean.ToString();
		GameController.ins.UIController.JournalsScroll.gameObject.SetActive(false);
		GameController.ins.UIController.JournalsScroll.gameObject.SetActive(true);
		GameController.ins.UIController.JournalsScroll.GetComponent<RectTransform>().ForceUpdateRectTransforms();
		GameController.ins.UIController.JournalsScroll.verticalScrollbar.value = 0f;
	}

	static JournalsConversationManager()
	{
		JournalsConversation item = new JournalsConversation
		{
			new JournalsConversationContent(1, "昨天你在河边偷偷拉屎时被我看到了", null),
			new JournalsConversationContent(2, "你胡说！我才没有做过这些", null),
			new JournalsConversationContent(1, "你放心，我不会告诉别人的", null)
		};
		JournalsConversationManager.JournalsConversations.Add(item);
		JournalsConversation item2 = new JournalsConversation
		{
			new JournalsConversationContent(1, "我从小就梦想得到一个红宝石", null),
			new JournalsConversationContent(2, "那是什么？", null),
			new JournalsConversationContent(1, "一个神奇且美丽的物件，据说拥有它的人可以得到能量", null),
			new JournalsConversationContent(2, "也许那只是你的想象罢了", null)
		};
		JournalsConversationManager.JournalsConversations.Add(item2);
		JournalsConversation item3 = new JournalsConversation
		{
			new JournalsConversationContent(1, "我想要成为主角", null),
			new JournalsConversationContent(2, "你现在就是故事的主角", null),
			new JournalsConversationContent(1, "还不够，我想成为的是整个故事的主角", null),
			new JournalsConversationContent(2, "那我会出现在你的故事里吗？", null)
		};
		JournalsConversationManager.JournalsConversations.Add(item3);
		JournalsConversation item4 = new JournalsConversation
		{
			new JournalsConversationContent(1, "我曾犯下一个大错，至今仍然感到十分悔恨", null),
			new JournalsConversationContent(2, "是什么错误呢？", null),
			new JournalsConversationContent(1, "一个无法被原谅的错误", null),
			new JournalsConversationContent(2, "那是什么样的错误？", null),
			new JournalsConversationContent(1, "我太后悔了，如果我当初没有那么做……", null)
		};
		JournalsConversationManager.JournalsConversations.Add(item4);
		JournalsConversation item5 = new JournalsConversation
		{
			new JournalsConversationContent(1, "你可以帮我一个忙吗？", null),
			new JournalsConversationContent(2, "不可以", null),
			new JournalsConversationContent(1, "我还没说要帮什么", null),
			new JournalsConversationContent(2, "总之就是不可以", null)
		};
		JournalsConversationManager.JournalsConversations.Add(item5);
	}

	public static List<JournalsConversation> JournalsConversations = new List<JournalsConversation>();

	public static CardData role1;

	public static CardData role2;

	public static CardData role3;

	public static CardData role4;
}
