using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PersonEvent
{
	public static List<PersonEvent> GetAllPersonEvents()
	{
		List<PersonEvent> list = new List<PersonEvent>();
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.受虐狂,
			Role2 = CharacterTag.弱智,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格1"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格2"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格3"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格4"), null)
			},
			Role1AddLogicName = typeof(Logic_AiShangLe),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格50"),
			Role2AddLogicName = typeof(Logic_AiShangLe),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格51"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格1")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.弱智,
			Role2 = (CharacterTag.受虐狂 | CharacterTag.弱智 | CharacterTag.猥琐 | CharacterTag.善良 | CharacterTag.大度 | CharacterTag.忠诚),
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格5"), new RuoZhiLogic().MakePoo())
			},
			Role1AddLogicName = null,
			Role2AddLogicName = null,
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格2")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.忠诚,
			Role2 = CharacterTag.弱智,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格6"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格7"), null)
			},
			Role1AddLogicName = typeof(Logic_TaoYan),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格52"),
			Role2AddLogicName = typeof(Logic_GaoXing),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格53"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格3")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.忠诚,
			Role2 = CharacterTag.善良,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格8"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格9"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格10"), null)
			},
			Role1AddLogicName = typeof(Logic_AiShangLe),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格54"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格4")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.忠诚,
			Role2 = CharacterTag.大度,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格11"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格12"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格13"), null)
			},
			Role1AddLogicName = typeof(Logic_ChongBai),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格55"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格5")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.忠诚,
			Role2 = CharacterTag.受虐狂,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格14"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格15"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格16"), null)
			},
			Role1AddLogicName = typeof(Logic_BuGaoXing),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格56"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格6")
		});
		PersonEvent personEvent = new PersonEvent();
		personEvent.ID = 1;
		personEvent.Role1 = CharacterTag.忠诚;
		personEvent.Role2 = CharacterTag.忠诚;
		personEvent.JournalsConversations = new JournalsConversation();
		personEvent.JournalsConversations.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格17"), null));
		personEvent.JournalsConversations.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格18"), null));
		personEvent.Role1AddLogicName = typeof(Logic_XiongDi);
		personEvent.Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格57");
		personEvent.Role2AddLogicName = typeof(Logic_XiongDi);
		personEvent.Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格57");
		personEvent.JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格7");
		list.Add(personEvent);
		list.Add(personEvent);
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.忠诚,
			Role2 = (CharacterTag.善良 | CharacterTag.大度),
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格19"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格20"), null)
			},
			Role1AddLogicName = typeof(Logic_GaoXing),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格58"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格8")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.大度,
			Role2 = CharacterTag.弱智,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格21"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格22"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格23"), null)
			},
			Role2AddLogicName = typeof(Logic_GaoXing),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格59"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格9")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.大度,
			Role2 = CharacterTag.受虐狂,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格24"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格25"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格26"), null)
			},
			Role2AddLogicName = typeof(Logic_BuGaoXing),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格60"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格10")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.大度,
			Role2 = CharacterTag.善良,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格27"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格28"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格29"), null)
			},
			Role1AddLogicName = typeof(Logic_XiongDi),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格61"),
			Role2AddLogicName = typeof(Logic_XiongDi),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格61"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格11")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.大度,
			Role2 = (CharacterTag.受虐狂 | CharacterTag.弱智 | CharacterTag.猥琐 | CharacterTag.善良 | CharacterTag.大度 | CharacterTag.忠诚),
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格30"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格31"), PersonEvent.GiveCard("假牙", 1))
			},
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格12")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.大度,
			Role2 = (CharacterTag.受虐狂 | CharacterTag.弱智 | CharacterTag.猥琐 | CharacterTag.善良 | CharacterTag.大度 | CharacterTag.忠诚),
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格32"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格33"), PersonEvent.GiveCard("破鞋", 1)),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格34"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格35"), null)
			},
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格13")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.大度,
			Role2 = (CharacterTag.受虐狂 | CharacterTag.弱智 | CharacterTag.猥琐 | CharacterTag.善良 | CharacterTag.大度 | CharacterTag.忠诚),
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格36"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格37"), PersonEvent.GiveCard("小呲花", 1))
			},
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格14")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.善良,
			Role2 = CharacterTag.猥琐,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格38"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格39"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格40"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格41"), null)
			},
			Role1AddLogicName = typeof(Logic_GaoXing),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格62"),
			Role2AddLogicName = typeof(Logic_GaoXing),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格63"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格15")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.善良,
			Role2 = CharacterTag.忠诚,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格42"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格43"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格44"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格45"), null)
			},
			Role2AddLogicName = typeof(Logic_JiDu),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格64"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格16")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.善良,
			Role2 = CharacterTag.弱智,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格46"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格47"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格48"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格49"), null)
			},
			Role2AddLogicName = typeof(Logic_TaoYan),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格65"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格17")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.善良,
			Role2 = CharacterTag.善良,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格50"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格51"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格52"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格53"), null)
			},
			Role1AddLogicName = typeof(Logic_AiShangLe),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格66"),
			Role2AddLogicName = typeof(Logic_AiShangLe),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格66"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格18")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.善良,
			Role2 = CharacterTag.善良,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格54"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格55"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格56"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格57"), null)
			},
			Role1AddLogicName = typeof(Logic_AiShangLe),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格67"),
			Role2AddLogicName = typeof(Logic_AiShangLe),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格67"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格19")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.善良,
			Role2 = CharacterTag.猥琐,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格58"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格59"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格60"), null)
			},
			Role2AddLogicName = typeof(Logic_GaoXing),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格68"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格20")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.善良,
			Role2 = CharacterTag.猥琐,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格61"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格62"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格63"), null)
			},
			Role2AddLogicName = typeof(Logic_GaoXing),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格68"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格21")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.善良,
			Role2 = CharacterTag.猥琐,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格64"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格65"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格66"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格67"), null)
			},
			Role2AddLogicName = typeof(Logic_BaiShi),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格69"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格22")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.猥琐,
			Role2 = CharacterTag.大度,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格68"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格69"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格70"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_好色5"), null)
			},
			Role1AddLogicName = typeof(Logic_TaoYan),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格70"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格23")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.猥琐,
			Role2 = CharacterTag.大度,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格71"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格72"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格73"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格74"), null)
			},
			Role1AddLogicName = typeof(Logic_AnLian),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格71"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格24")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.猥琐,
			Role2 = CharacterTag.受虐狂,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格75"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格76"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格77"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格78"), null)
			},
			Role2AddLogicName = typeof(Logic_GaoXing),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格72"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格25")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.猥琐,
			Role2 = CharacterTag.善良,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格79"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格80"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格81"), null)
			},
			Role1AddLogicName = typeof(Logic_ChongBai),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格73"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格26")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.猥琐,
			Role2 = (CharacterTag.受虐狂 | CharacterTag.弱智 | CharacterTag.猥琐 | CharacterTag.善良 | CharacterTag.大度 | CharacterTag.忠诚),
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格82"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格83"), PersonEvent.GiveCard("打火机", 1))
			},
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格27")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.猥琐,
			Role2 = (CharacterTag.受虐狂 | CharacterTag.弱智 | CharacterTag.猥琐 | CharacterTag.善良 | CharacterTag.大度 | CharacterTag.忠诚),
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格84"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格85"), PersonEvent.GiveCard("午饭袋", 1))
			},
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格28")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.猥琐,
			Role2 = (CharacterTag.受虐狂 | CharacterTag.弱智 | CharacterTag.猥琐 | CharacterTag.善良 | CharacterTag.大度 | CharacterTag.忠诚),
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格86"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格87"), PersonEvent.GiveCard("修改液", 1))
			},
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格29")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.猥琐,
			Role2 = CharacterTag.受虐狂,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格88"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格89"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格90"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格91"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格92"), null)
			},
			Role1AddLogicName = typeof(Logic_GaoXing),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格74"),
			Role2AddLogicName = typeof(Logic_AnLian),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格75"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格30")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.猥琐,
			Role2 = CharacterTag.善良,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格93"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格94"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格95"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格96"), null)
			},
			Role1AddLogicName = typeof(Logic_BuGaoXing),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格76"),
			Role2AddLogicName = typeof(Logic_GaoXing),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格77"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格31")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.猥琐,
			Role2 = CharacterTag.弱智,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格97"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格98"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格99"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格100"), null)
			},
			Role1AddLogicName = typeof(Logic_BuGaoXing),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格76"),
			Role2AddLogicName = typeof(Logic_GaoXing),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格78"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格32")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.受虐狂,
			Role2 = CharacterTag.受虐狂,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格101"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格102"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格103"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格104"), null)
			},
			Role1AddLogicName = typeof(Logic_AiShangLe),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格66"),
			Role2AddLogicName = typeof(Logic_AiShangLe),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格66"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格33")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.受虐狂,
			Role2 = CharacterTag.猥琐,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格105"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格106"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格107"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格108"), null)
			},
			Role1AddLogicName = typeof(Logic_XiongDi),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格79"),
			Role2AddLogicName = typeof(Logic_XiongDi),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格80"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格34")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.受虐狂,
			Role2 = CharacterTag.弱智,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格109"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格110"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格111"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格112"), null)
			},
			Role1AddLogicName = typeof(Logic_AiShangLe),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格81"),
			Role2AddLogicName = typeof(Logic_GaoXing),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格82"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格35")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.受虐狂,
			Role2 = CharacterTag.善良,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格113"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格114"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格115"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_好色5"), null)
			},
			Role1AddLogicName = typeof(Logic_TaoYan),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格83"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格36")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.受虐狂,
			Role2 = (CharacterTag.受虐狂 | CharacterTag.弱智 | CharacterTag.猥琐 | CharacterTag.善良 | CharacterTag.大度 | CharacterTag.忠诚),
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格116"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格117"), PersonEvent.GiveCard("哑铃", 1))
			},
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格37")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.受虐狂,
			Role2 = (CharacterTag.受虐狂 | CharacterTag.弱智 | CharacterTag.猥琐 | CharacterTag.善良 | CharacterTag.大度 | CharacterTag.忠诚),
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格118"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格119"), PersonEvent.GiveCard("小学作业", 1))
			},
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格38")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.弱智,
			Role2 = CharacterTag.弱智,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格120"), PersonEvent.GiveCard("坨坨", 1)),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格121"), PersonEvent.GiveCard("坨坨", 2))
			},
			Role1AddLogicName = typeof(Logic_XiongDi),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格84"),
			Role2AddLogicName = typeof(Logic_XiongDi),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格84"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格39")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.弱智,
			Role2 = CharacterTag.弱智,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格122"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格123"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格124"), PersonEvent.GiveCard("坨坨", 1)),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格125"), PersonEvent.GiveCard("坨坨", 2))
			},
			Role2AddLogicName = typeof(Logic_TaoYan),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格85"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格40")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.聪明,
			Role2 = CharacterTag.弱智,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格126"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格127"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格128"), null),
				new JournalsConversationContent(2, "", PersonEvent.GiveCard("坨坨", 2))
			},
			Role1AddLogicName = typeof(Logic_ChongBai),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格86"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格41")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.聪明,
			Role2 = CharacterTag.大度,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格129"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格130"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格131"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格132"), null)
			},
			Role1AddLogicName = typeof(Logic_FaFeng),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格87"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格42")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.聪明,
			Role2 = CharacterTag.受虐狂,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格133"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格134"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格135"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格136"), null)
			},
			Role2AddLogicName = typeof(Logic_GaoXing),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格88"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格43")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.聪明,
			Role2 = CharacterTag.善良,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格137"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格138"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格139"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格140"), null)
			},
			Role1AddLogicName = typeof(Logic_AnLian),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格89"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格44")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.聪明,
			Role2 = CharacterTag.忠诚,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格141"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格142"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格143"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格144"), null)
			},
			Role1AddLogicName = typeof(Logic_BuZhong),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格90"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格45")
		});
		list.Add(new PersonEvent
		{
			ID = 1,
			Role1 = CharacterTag.聪明,
			Role2 = CharacterTag.聪明,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格145"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格146"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_好色5"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_好色5"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格147"), null)
			},
			Role1AddLogicName = typeof(Logic_BuGaoXing),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格91"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格46")
		});
		list.Add(new PersonEvent
		{
			ID = 1001,
			Role1 = CharacterTag.聪明,
			Role2 = CharacterTag.忠诚,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格148"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格149"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格150"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格151"), null)
			},
			Role1AddLogicName = typeof(Logic_TaoYan),
			Role1Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格92"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格47")
		});
		list.Add(new PersonEvent
		{
			ID = 1003,
			Role1 = CharacterTag.善良,
			Role2 = CharacterTag.弱智,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格152"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格153"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格154"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格155"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格156"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_好色5"), PersonEvent.GiveCard("坨坨", 2))
			},
			Role2AddLogicName = typeof(Logic_AiShangLe),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格93"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格48")
		});
		list.Add(new PersonEvent
		{
			ID = 1004,
			Role1 = CharacterTag.聪明,
			Role2 = CharacterTag.忠诚,
			JournalsConversations = new JournalsConversation(),
			JournalsConversations = 
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格157"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格158"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格159"), null),
				new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_性格160"), null),
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_性格161"), null)
			},
			Role2AddLogicName = typeof(Logic_ChongBai),
			Role2Reason = LocalizationMgr.Instance.GetLocalizationWord("T_性格94"),
			JournalsBeanFormatString = LocalizationMgr.Instance.GetLocalizationWord("T_性格49")
		});
		return list;
	}

	public static IEnumerator GiveCard(string ModID, int FromRoleNum)
	{
		CardData cardData2;
		if (FromRoleNum == 1)
		{
			cardData2 = JournalsConversationManager.role1;
		}
		else
		{
			cardData2 = JournalsConversationManager.role2;
		}
		if (cardData2 == null || cardData2.CardGameObject == null)
		{
			yield break;
		}
		CardData cardData = Card.InitCardDataByID(ModID);
		if (cardData == null)
		{
			yield break;
		}
		CardSlotData cardSlotData = GameController.ins.GetEmptySlotDataByCardData(cardData);
		if (cardSlotData == null)
		{
			yield break;
		}
		GameObject card = Card.InitWithOutData(cardData, true);
		card.transform.position = cardData2.CardGameObject.transform.position;
		yield return card.transform.DOJump(cardSlotData.CardSlotGameObject.transform.position, 1f, 1, 1f, false).WaitForCompletion();
		UnityEngine.Object.DestroyImmediate(card.gameObject);
		cardData.PutInSlotData(cardSlotData, true);
		yield break;
	}

	public int ID;

	public CharacterTag Role1;

	public CharacterTag Role2;

	public JournalsConversation JournalsConversations;

	public Type Role1AddLogicName;

	public string Role1Reason;

	public Type Role2AddLogicName;

	public string Role2Reason;

	public string JournalsBeanFormatString;
}
