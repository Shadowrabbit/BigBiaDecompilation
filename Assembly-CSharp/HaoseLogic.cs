using System;
using System.Collections;
using System.Collections.Generic;

public class HaoseLogic : NatureLogic
{
	public override void Init()
	{
		base.Init();
	}

	public override IEnumerator OnMoveOnMap()
	{
		DungeonOperationMgr.Instance.AddRandomJournalsProcess(this.CreateNatureEvent());
		yield break;
	}

	private IEnumerator CreateNatureEvent()
	{
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		if (myBattleArea == null)
		{
			yield break;
		}
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in myBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData != this.CardData)
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		if (list.Count == 0)
		{
			yield break;
		}
		CardData cardData = list[SYNCRandom.Range(0, list.Count)];
		CharacterTag charactorTag = cardData.CharactorTag;
		JournalsConversationManager.role1 = this.CardData;
		JournalsConversationManager.role2 = cardData;
		JournalsConversation journalsConversation = new JournalsConversation();
		journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_好色1"), null));
		JournalsBean bean = new JournalsBean();
		bean.Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + " " + this.CardData.PersonName;
		bean.Target = LocalizationMgr.Instance.GetLocalizationWord(cardData.Name) + " " + cardData.PersonName;
		bean.FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_好色1");
		if (charactorTag != CharacterTag.弱智)
		{
			if (charactorTag != CharacterTag.猥琐)
			{
				if (charactorTag == CharacterTag.大度)
				{
					journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_好色2"), null));
					journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_好色3"), null));
					JournalsBean journalsBean = bean;
					journalsBean.FormatString += LocalizationMgr.Instance.GetLocalizationWord("T_好色2");
					TwoPeopleCardLogic twoPeopleCardLogic = new Logic_AiShangLe();
					twoPeopleCardLogic.TargetID = cardData.ID;
					twoPeopleCardLogic.Reason = LocalizationMgr.Instance.GetLocalizationWord("T_完美");
					if (!base.IsHavePersonLogic(twoPeopleCardLogic, this.CardData))
					{
						this.CardData.AddLogic(twoPeopleCardLogic);
					}
				}
				else
				{
					journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_好色7"), null));
					journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_好色8"), null));
					JournalsBean journalsBean2 = bean;
					journalsBean2.FormatString += LocalizationMgr.Instance.GetLocalizationWord("T_好色5");
					TwoPeopleCardLogic twoPeopleCardLogic = new Logic_AnLian();
					twoPeopleCardLogic.Reason = LocalizationMgr.Instance.GetLocalizationWord("T_酷炫");
					twoPeopleCardLogic.TargetID = cardData.ID;
					if (!base.IsHavePersonLogic(twoPeopleCardLogic, this.CardData))
					{
						this.CardData.AddLogic(twoPeopleCardLogic);
					}
				}
			}
			else
			{
				journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_好色6"), null));
				journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_好色5"), null));
				JournalsBean journalsBean3 = bean;
				journalsBean3.FormatString += LocalizationMgr.Instance.GetLocalizationWord("T_好色4");
				Logic_BuGaoXing logic_BuGaoXing = new Logic_BuGaoXing();
				logic_BuGaoXing.Reason = LocalizationMgr.Instance.GetLocalizationWord("T_被鄙视");
				logic_BuGaoXing.ExistsRound = 3;
			}
		}
		else
		{
			journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_好色4"), null));
			journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_好色5"), null));
			JournalsBean journalsBean4 = bean;
			journalsBean4.FormatString += LocalizationMgr.Instance.GetLocalizationWord("T_好色3");
			TwoPeopleCardLogic twoPeopleCardLogic = new Logic_TaoYan();
			twoPeopleCardLogic.ExistsRound = 3;
			twoPeopleCardLogic.TargetID = cardData.ID;
			twoPeopleCardLogic.Reason = LocalizationMgr.Instance.GetLocalizationWord("T_拒绝");
			if (!base.IsHavePersonLogic(twoPeopleCardLogic, this.CardData))
			{
				this.CardData.AddLogic(twoPeopleCardLogic);
			}
		}
		yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation);
		JournalsConversationManager.PutJournals(bean);
		yield break;
	}
}
