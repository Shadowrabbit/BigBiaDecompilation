using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RuoZhiLogic : NatureLogic
{
	public override void Init()
	{
		base.Init();
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.MakePoo();
	}

	public override IEnumerator OnMoveOnMap()
	{
		if (!this.isHappened)
		{
			DungeonOperationMgr.Instance.AddRandomJournalsProcess(this.CreateNatureEvent());
		}
		yield break;
	}

	public IEnumerator MakePoo()
	{
		if (SYNCRandom.Range(0, 100) < 10)
		{
			CardData cardData = CardData.CopyCardData(Card.InitCardDataByID("便便"), true);
			cardData.PutInSlotData(GameController.ins.GetEmptySlotDataByCardData(cardData), true);
		}
		else
		{
			CardData cardData2 = CardData.CopyCardData(Card.InitCardDataByID("坨坨"), true);
			cardData2.PutInSlotData(GameController.ins.GetEmptySlotDataByCardData(cardData2), true);
		}
		yield return null;
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
				if ((int)cardSlotData.Attrs["Col"] == (int)this.CardData.CurrentCardSlotData.Attrs["Col"])
				{
					list.Add(cardSlotData.ChildCardData);
				}
				else if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) / 3 == myBattleArea.IndexOf(cardSlotData) / 3 && Mathf.Abs(myBattleArea.IndexOf(cardSlotData) - myBattleArea.IndexOf(this.CardData.CurrentCardSlotData)) == 1)
				{
					list.Add(cardSlotData.ChildCardData);
				}
			}
		}
		if (list.Count > 0)
		{
			CardData target = list[SYNCRandom.Range(0, list.Count)];
			CharacterTag charactorTag = target.CharactorTag;
			int num = SYNCRandom.Range(0, this.m_TalkList.Count);
			JournalsConversationManager.role1 = this.CardData;
			JournalsConversationManager.role2 = target;
			JournalsConversation jornal = new JournalsConversation();
			jornal.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_弱智1"), null));
			this.MakePoo();
			JournalsBean bean = new JournalsBean();
			bean.FormatString = LocalizationMgr.Instance.GetLocalizationWord(this.m_TalkList[num]);
			bean.Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + "·" + this.CardData.PersonName;
			bean.Target = LocalizationMgr.Instance.GetLocalizationWord(target.Name) + "·" + target.PersonName;
			List<string> list2 = new List<string>();
			if (charactorTag <= CharacterTag.弱智)
			{
				if (charactorTag != CharacterTag.受虐狂)
				{
					if (charactorTag == CharacterTag.弱智)
					{
						list2 = new List<string>();
						list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_弱智1"));
						list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_弱智2"));
						list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_弱智3"));
						JournalsBean journalsBean = bean;
						journalsBean.FormatString += list2[SYNCRandom.Range(0, list2.Count)];
						Logic_GaoXing logic_GaoXing = new Logic_GaoXing();
						logic_GaoXing.ExistsRound = 3;
						logic_GaoXing.Reason = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_很高兴"), LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name), this.CardData.PersonName);
						this.CardData.AddPersonLogic(logic_GaoXing);
						target.AddPersonLogic(new Logic_GaoXing
						{
							ExistsRound = 3,
							Reason = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_很高兴"), LocalizationMgr.Instance.GetLocalizationWord(target.Name), target.PersonName)
						});
						jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_弱智2"), null));
						jornal.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_弱智3"), null));
						yield return DungeonOperationMgr.Instance.RunJournalsConversation(jornal);
						JournalsConversationManager.PutJournals(bean);
						this.MakePoo();
						yield break;
					}
				}
				else
				{
					list2 = new List<string>();
					list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_弱智5"));
					list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_弱智7"));
					JournalsBean journalsBean2 = bean;
					journalsBean2.FormatString += list2[SYNCRandom.Range(0, list2.Count)];
					target.AddPersonLogic(new Logic_BuGaoXing
					{
						ExistsRound = 3,
						Reason = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_想要的"), LocalizationMgr.Instance.GetLocalizationWord(target.Name), target.PersonName)
					});
					jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_弱智4"), null));
				}
			}
			else if (charactorTag != CharacterTag.善良)
			{
				if (charactorTag != CharacterTag.大度)
				{
					if (charactorTag == CharacterTag.忠诚)
					{
						list2 = new List<string>();
						if (this.CardData.HasTag(TagMap.英雄))
						{
							list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_弱智11"));
							list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_弱智12"));
							Logic_ChongBai logic_ChongBai = new Logic_ChongBai();
							logic_ChongBai.TargetID = this.CardData.ID;
							logic_ChongBai.Reason = LocalizationMgr.Instance.GetLocalizationWord("T_主公真是");
							if (!base.IsHavePersonLogic(logic_ChongBai, target))
							{
								target.AddPersonLogic(logic_ChongBai);
							}
							jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_弱智9"), null));
						}
						else
						{
							list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_弱智13"));
							jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_弱智10"), null));
						}
						JournalsBean journalsBean3 = bean;
						journalsBean3.FormatString += list2[SYNCRandom.Range(0, list2.Count)];
					}
				}
				else
				{
					list2 = new List<string>();
					if (num == 3)
					{
						list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_弱智8"));
						Logic_GaoXing logic_GaoXing2 = new Logic_GaoXing();
						logic_GaoXing2.ExistsRound = 3;
						logic_GaoXing2.Reason = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_很高兴"), LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name), this.CardData.PersonName);
						this.CardData.AddPersonLogic(logic_GaoXing2);
						jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_弱智6"), null));
						jornal.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_弱智7"), null));
						jornal.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_弱智3"), null));
					}
					else
					{
						list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_弱智9"));
						list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_弱智10"));
						jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_弱智8"), null));
					}
					JournalsBean journalsBean4 = bean;
					journalsBean4.FormatString += list2[SYNCRandom.Range(0, list2.Count)];
				}
			}
			else
			{
				list2 = new List<string>();
				list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_弱智6"));
				JournalsBean journalsBean5 = bean;
				journalsBean5.FormatString += list2[SYNCRandom.Range(0, list2.Count)];
				ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HellHpBall", 0.3f);
				particleObject.transform.position = target.CardGameObject.transform.position;
				yield return particleObject.transform.DOMove(this.CardData.CardGameObject.transform.position, 0.3f, false).WaitForCompletion();
				string name = "Effect/HealHp";
				ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = this.CardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, 3, target, false, 0, true, false);
				jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_弱智5"), null));
			}
			yield return DungeonOperationMgr.Instance.RunJournalsConversation(jornal);
			JournalsConversationManager.PutJournals(bean);
			target = null;
			jornal = null;
			bean = null;
		}
		else
		{
			JournalsConversationManager.role1 = this.CardData;
			JournalsConversation conversation = new JournalsConversation
			{
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_弱智11"), null)
			};
			yield return DungeonOperationMgr.Instance.RunJournalsConversation(conversation);
			JournalsConversationManager.PutJournals(new JournalsBean
			{
				FormatString = LocalizationMgr.Instance.GetLocalizationWord(this.m_TalkList[this.m_TalkList.Count - 1]),
				Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + "·" + this.CardData.PersonName
			});
			Logic_GaoXing logic_GaoXing3 = new Logic_GaoXing();
			logic_GaoXing3.ExistsRound = 3;
			logic_GaoXing3.Reason = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_很高兴"), LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name), this.CardData.PersonName);
			this.CardData.AddPersonLogic(logic_GaoXing3);
			this.MakePoo();
		}
		yield break;
	}

	private List<string> m_TalkList = new List<string>
	{
		"T_弱智4"
	};
}
