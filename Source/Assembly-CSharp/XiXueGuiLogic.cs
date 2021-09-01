using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiXueGuiLogic : FaithCardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_吸血鬼");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_吸血鬼");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_吸血鬼");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_吸血鬼");
	}

	public override IEnumerator OnBattleStart()
	{
		this.CardData.AddAffix(DungeonAffix.strength, 3);
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		this.CardData.AddAffix(DungeonAffix.strength, 3);
		yield break;
	}

	public override IEnumerator OnMoveOnMap()
	{
		yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -Mathf.CeilToInt((float)this.CardData.MaxHP * 0.05f), this.CardData, true, 0, true, false);
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (from == this.CardData)
		{
			GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, "渴血", UnityEngine.Color.white, 0, false, false);
			yield return base.Cure(this.CardData, Mathf.CeilToInt((float)this.CardData.MaxHP * 0.3f), this.CardData);
		}
		yield break;
	}

	public override IEnumerator OnBattleEnd()
	{
		this.m_Count++;
		if (this.m_Count % 7 == 0)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			List<CardData> list = new List<CardData>();
			foreach (CardData cardData in allCurrentMinions)
			{
				if (cardData != this.CardData)
				{
					bool flag = false;
					foreach (CardLogic cardLogic in cardData.CardLogics)
					{
						if (cardLogic is XueYiLogic || cardLogic is XueYiXuRuoLogic)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						list.Add(cardData);
					}
				}
			}
			if (list.Count > 0)
			{
				CardData target = list[SYNCRandom.Range(0, list.Count)];
				JournalsConversationManager.role1 = this.CardData;
				JournalsConversationManager.role2 = target;
				JournalsConversation journalsConversation = new JournalsConversation();
				int num = SYNCRandom.Range(0, 2);
				if (num != 0)
				{
					if (num == 1)
					{
						journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_吸血鬼2"), null));
					}
				}
				else
				{
					journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_吸血鬼1"), null));
				}
				journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_吸血鬼3"), null));
				yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation);
				this.AddLogic("XueYiXuRuoLogic", target);
				JournalsConversationManager.PutJournals(new JournalsBean
				{
					FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_吸血鬼1"),
					Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + "·" + this.CardData.PersonName,
					Target = LocalizationMgr.Instance.GetLocalizationWord(target.Name) + "·" + target.PersonName
				});
				target = null;
			}
			this.m_Count = 0;
		}
		else
		{
			List<CardData> allCurrentMinions2 = base.GetAllCurrentMinions();
			List<CardData> list2 = new List<CardData>();
			foreach (CardData cardData2 in allCurrentMinions2)
			{
				if (cardData2 != this.CardData)
				{
					bool flag2 = false;
					foreach (CardLogic cardLogic2 in cardData2.CardLogics)
					{
						if (cardLogic2 is XueYiLogic || cardLogic2 is XueYiXuRuoLogic)
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						list2.Add(cardData2);
					}
				}
			}
			if (list2.Count > 0 && SYNCRandom.Range(0, 100) < 20)
			{
				CardData target = list2[SYNCRandom.Range(0, list2.Count)];
				JournalsConversationManager.role1 = this.CardData;
				JournalsConversationManager.role2 = target;
				JournalsConversation journalsConversation2 = new JournalsConversation();
				int num = SYNCRandom.Range(0, 2);
				if (num != 0)
				{
					if (num == 1)
					{
						journalsConversation2.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_吸血鬼5"), null));
					}
				}
				else
				{
					journalsConversation2.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_吸血鬼4"), null));
				}
				journalsConversation2.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_吸血鬼6"), null));
				yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation2);
				this.AddLogic("XueYiXuRuoLogic", target);
				JournalsConversationManager.PutJournals(new JournalsBean
				{
					FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_吸血鬼2"),
					Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + "·" + this.CardData.PersonName,
					Target = LocalizationMgr.Instance.GetLocalizationWord(target.Name) + "·" + target.PersonName
				});
				this.m_Count = 0;
				target = null;
			}
		}
		yield break;
	}

	private void AddLogic(string logicName, CardData data)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		cardLogic.CardData = data;
		data.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(data);
	}

	public int m_Count;
}
