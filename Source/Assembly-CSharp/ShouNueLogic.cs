using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShouNueLogic : NatureLogic
{
	public override void Init()
	{
		base.Init();
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			DungeonOperationMgr.Instance.AddRandomJournalsProcess(this.CreateNatureEvent());
		}
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
			int num = SYNCRandom.Range(0, this.m_TalkList.Count - 1);
			JournalsConversationManager.role1 = this.CardData;
			JournalsConversationManager.role2 = target;
			JournalsConversation jornal = new JournalsConversation();
			jornal.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_受虐1"), null));
			JournalsBean bean = new JournalsBean();
			bean.FormatString = LocalizationMgr.Instance.GetLocalizationWord(this.m_TalkList[num]);
			bean.Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + "·" + this.CardData.PersonName;
			bean.Target = LocalizationMgr.Instance.GetLocalizationWord(target.Name) + "·" + target.PersonName;
			List<string> list2 = new List<string>();
			if (charactorTag <= CharacterTag.善良)
			{
				ulong num2 = charactorTag - CharacterTag.受虐狂;
				if (num2 <= 3UL)
				{
					switch ((uint)num2)
					{
					case 0U:
					{
						list2 = new List<string>();
						if (num == 3)
						{
							list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_受虐4"));
							target.AddPersonLogic(new Logic_BuGaoXing
							{
								ExistsRound = 2,
								Reason = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_抢风头"), LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name), this.CardData.PersonName)
							});
							jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_受虐5"), null));
						}
						else if (num == 1)
						{
							list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_受虐5"));
							Logic_BaiShi logic_BaiShi = new Logic_BaiShi();
							logic_BaiShi.TargetID = this.CardData.ID;
							logic_BaiShi.Reason = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_渺小"), LocalizationMgr.Instance.GetLocalizationWord(target.Name), target.PersonName);
							if (!base.IsHavePersonLogic(logic_BaiShi, target))
							{
								target.AddPersonLogic(logic_BaiShi);
							}
							jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_受虐6"), null));
							jornal.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_受虐7"), null));
						}
						else
						{
							list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_受虐6"));
							list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_受虐7"));
							target.AddPersonLogic(new Logic_BuGaoXing
							{
								ExistsRound = 2,
								Reason = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_抢风头"), LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name), this.CardData.PersonName)
							});
							jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_受虐8"), null));
						}
						JournalsBean journalsBean = bean;
						journalsBean.FormatString += list2[SYNCRandom.Range(0, list2.Count)];
						goto IL_B0E;
					}
					case 1U:
					{
						list2 = new List<string>();
						if (num == 3)
						{
							list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_受虐1"));
							Logic_TaoYan logic_TaoYan = new Logic_TaoYan();
							logic_TaoYan.TargetID = target.ID;
							logic_TaoYan.ExistsRound = 3;
							logic_TaoYan.Reason = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_惩罚"), LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name), this.CardData.PersonName);
							if (!base.IsHavePersonLogic(logic_TaoYan, null))
							{
								this.CardData.AddPersonLogic(logic_TaoYan);
							}
							jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_弱智6"), null));
							jornal.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_受虐2"), null));
						}
						else
						{
							list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_受虐2"));
							list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_受虐3"));
							Logic_TaoYan logic_TaoYan2 = new Logic_TaoYan();
							logic_TaoYan2.ExistsRound = 3;
							logic_TaoYan2.TargetID = target.ID;
							logic_TaoYan2.Reason = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_掌声"), LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name), this.CardData.PersonName);
							if (!base.IsHavePersonLogic(logic_TaoYan2, null))
							{
								this.CardData.AddPersonLogic(logic_TaoYan2);
							}
							jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_受虐3"), null));
							jornal.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_受虐4"), null));
						}
						JournalsBean journalsBean2 = bean;
						journalsBean2.FormatString += list2[SYNCRandom.Range(0, list2.Count)];
						goto IL_B0E;
					}
					case 2U:
						goto IL_B0E;
					case 3U:
					{
						list2 = new List<string>();
						list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_受虐8"));
						JournalsBean journalsBean3 = bean;
						journalsBean3.FormatString += list2[SYNCRandom.Range(0, list2.Count)];
						jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_受虐9"), null));
						yield return DungeonOperationMgr.Instance.RunJournalsConversation(jornal);
						JournalsConversationManager.PutJournals(bean);
						yield return DungeonOperationMgr.Instance.Hit(target, this.CardData, 3, 0.2f, true, 0, null, null);
						yield break;
					}
					}
				}
				if (charactorTag == CharacterTag.善良)
				{
					list2 = new List<string>();
					list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_受虐9"));
					list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_受虐10"));
					JournalsBean journalsBean4 = bean;
					journalsBean4.FormatString += list2[SYNCRandom.Range(0, list2.Count)];
					ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HellHpBall", 0.3f);
					particleObject.transform.position = target.CardGameObject.transform.position;
					yield return particleObject.transform.DOMove(this.CardData.CardGameObject.transform.position, 0.3f, false).WaitForCompletion();
					string name = "Effect/HealHp";
					ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = this.CardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
					yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, 3, target, false, 0, true, false);
					jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_受虐10"), null));
				}
			}
			else if (charactorTag != CharacterTag.大度)
			{
				if (charactorTag == CharacterTag.忠诚)
				{
					list2 = new List<string>();
					if (this.CardData.HasTag(TagMap.英雄))
					{
						list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_受虐14"));
						jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_受虐13"), null));
					}
					else
					{
						list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_受虐20"));
						jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_受虐14"), null));
					}
					JournalsBean journalsBean5 = bean;
					journalsBean5.FormatString += list2[SYNCRandom.Range(0, list2.Count)];
				}
			}
			else
			{
				list2 = new List<string>();
				list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_受虐11"));
				list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_受虐12"));
				list2.Add(LocalizationMgr.Instance.GetLocalizationWord("T_受虐13"));
				JournalsBean journalsBean6 = bean;
				journalsBean6.FormatString += list2[SYNCRandom.Range(0, list2.Count)];
				Logic_AiShangLe logic_AiShangLe = new Logic_AiShangLe();
				logic_AiShangLe.TargetID = target.ID;
				logic_AiShangLe.Reason = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_梦一样"), LocalizationMgr.Instance.GetLocalizationWord(target.Name), target.PersonName);
				if (!base.IsHavePersonLogic(logic_AiShangLe, null))
				{
					this.CardData.AddPersonLogic(logic_AiShangLe);
				}
				jornal.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_受虐11"), null));
				jornal.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_受虐12"), null));
			}
			IL_B0E:
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
				new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_受虐15"), null)
			};
			yield return DungeonOperationMgr.Instance.RunJournalsConversation(conversation);
			JournalsConversationManager.PutJournals(new JournalsBean
			{
				FormatString = LocalizationMgr.Instance.GetLocalizationWord(this.m_TalkList[this.m_TalkList.Count - 1]),
				Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + "·" + this.CardData.PersonName
			});
			Logic_ZiCan logic_ZiCan = new Logic_ZiCan();
			logic_ZiCan.ExistsRound = 3;
			logic_ZiCan.Reason = LocalizationMgr.Instance.GetLocalizationWord("T_没人来");
			this.CardData.AddPersonLogic(logic_ZiCan);
		}
		yield break;
	}

	private List<string> m_TalkList = new List<string>
	{
		"T_受虐15",
		"T_受虐16",
		"T_受虐17",
		"T_受虐18",
		"T_受虐19"
	};
}
