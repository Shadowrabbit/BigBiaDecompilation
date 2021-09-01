using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic_HuaiYun : TwoPeopleCardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_怀孕");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_怀孕"), this.m_Round);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_怀孕");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_怀孕"), this.m_Round);
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		if (player == this.CardData && value.value < 0)
		{
			GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_怀孕2"), UnityEngine.Color.white, 0, false, false);
			value.value *= 2;
		}
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target == this.CardData)
		{
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_怀孕1"));
			JournalsConversationManager.PutJournals(new JournalsBean
			{
				FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_关系怀孕2"),
				Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + "·" + this.CardData.PersonName
			});
		}
		yield break;
	}

	public override IEnumerator OnBattleEnd()
	{
		this.m_Round--;
		if (this.m_Round <= 0)
		{
			List<CardSlotData> targetSlots = new List<CardSlotData>();
			foreach (CardSlotData cardSlotData in base.GetMyBattleArea())
			{
				if (cardSlotData.ChildCardData == null)
				{
					targetSlots.Add(cardSlotData);
				}
			}
			if (targetSlots.Count > 0)
			{
				base.ShowMe();
				CardData cardByID = base.GetCardByID(this.TargetID);
				List<CardLogic> logics = new List<CardLogic>();
				if (cardByID != null)
				{
					foreach (CardLogic cardLogic in cardByID.CardLogics)
					{
						if (!(cardLogic is MinionLogic) && !(cardLogic is PersonCardLogic) && !(cardLogic is FaithCardLogic))
						{
							logics.Add(cardLogic);
						}
					}
				}
				foreach (CardLogic cardLogic2 in this.CardData.CardLogics)
				{
					if (!(cardLogic2 is MinionLogic) && !(cardLogic2 is PersonCardLogic) && !(cardLogic2 is FaithCardLogic))
					{
						logics.Add(cardLogic2);
					}
				}
				yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_怀孕"));
				CardSlotData slotData = targetSlots[SYNCRandom.Range(0, targetSlots.Count)];
				CardData cardData = Card.InitCardDataByID("熊孩子");
				if (logics.Count > 0)
				{
					int num = (logics.Count > 1) ? 2 : 1;
					List<CardLogic> list = new List<CardLogic>();
					for (int i = 0; i < num; i++)
					{
						CardLogic item = logics[SYNCRandom.Range(0, logics.Count)];
						while (list.Contains(item))
						{
							item = logics[SYNCRandom.Range(0, logics.Count)];
						}
						list.Add(item);
					}
					foreach (CardLogic logic in list)
					{
						this.AddLogic(logic, cardData);
					}
				}
				cardData.PutInSlotData(slotData, true);
				logics = null;
			}
			JournalsConversationManager.PutJournals(new JournalsBean
			{
				FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_关系怀孕1"),
				Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + "·" + this.CardData.PersonName,
				Target = ""
			});
			this.CardData.RemoveLogic(this);
			targetSlots = null;
		}
		yield break;
	}

	private void AddLogic(CardLogic logic, CardData data)
	{
		CardLogic cardLogic = Activator.CreateInstance(logic.GetType()) as CardLogic;
		cardLogic.Layers = logic.Layers;
		cardLogic.CardData = data;
		cardLogic.Init();
		data.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(data);
	}

	private int m_Round = 3;
}
