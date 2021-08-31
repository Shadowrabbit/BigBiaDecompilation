using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherHouse : AreaLogic
{
	public object GetCardAttr(CardData cs, string name)
	{
		if (cs.Attrs.ContainsKey(name))
		{
			if (cs.Attrs[name] != null)
			{
				return cs.Attrs[name];
			}
			if (cs.HiddenAttrs[name] != null)
			{
				return cs.HiddenAttrs[name];
			}
		}
		return 1;
	}

	public override void BeforeInit()
	{
	}

	public override void BeforeEnter()
	{
	}

	public override void OnExit()
	{
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent -= this.Transaction;
		if (this.m_SlotData.ChildCardData != null)
		{
			this.m_SlotData.ChildCardData.PutInSlotData(GameController.ins.GetEmptySlotDataByCardData(this.m_SlotData.ChildCardData), true);
		}
		if (this.m_StartTimer != null)
		{
			GameController.getInstance().StopCoroutine(this.m_StartTimer);
		}
		base.Data.Attrs["Percent"] = 0;
		if (this.m_ProgressBar != null)
		{
			this.m_ProgressBar.SetProgress(0f, 0.ToString() ?? "");
		}
		UIController.LockLevel = this.m_Lock;
	}

	public override IEnumerator OnAlreadEnter()
	{
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent += this.Transaction;
		this.m_Lock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.None;
		List<CardSlotData> cardSlotDatas = base.Data.CardSlotDatas;
		this.m_SlotData = cardSlotDatas[0];
		this.m_SlotData.CardSlotGameObject.SetBorder(1);
		this.m_SlotData.CardSlotGameObject.SetIcon(4);
		this.m_SlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
		this.m_SlotData.SlotType = CardSlotData.Type.OnlyPut;
		this.m_SlotData.TagWhiteList = 65536UL;
		this.m_ProgressBar = UnityEngine.Object.FindObjectOfType<SpaceProgressBarTool>();
		if (this.m_ProgressBar != null)
		{
			this.m_ProgressBar.SetProgress(float.Parse(base.Data.Attrs["Percent"].ToString()) / 100f, base.Data.Attrs["Percent"].ToString());
		}
		GameController.ins.UIController.HideBlackMask(delegate
		{
			GameController.getInstance().UIController.ShowBackToHomeButton();
		}, 0.5f);
		yield break;
	}

	private void Transaction(CardSlotData oldCardSlot, CardSlotData newCardSlot, CardData card)
	{
		if (oldCardSlot == null || newCardSlot == null)
		{
			return;
		}
		if (oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Player && newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area)
		{
			if (card.Rare >= 4 || card.ModID.Equals("破鞋"))
			{
				if (card.Rare >= 4)
				{
					GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_12"), 1f, 2f, 1f, 1f);
				}
				if (card.ModID.Equals("破鞋"))
				{
					GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_43"), 1f, 2f, 1f, 1f);
				}
				card.PutInSlotData(GameController.ins.GetEmptySlotDataByCardData(card), true);
				return;
			}
			if (GameController.ins.CurrentAct != null)
			{
				GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_28"), 1f, 2f, 1f, 1f);
				card.PutInSlotData(GameController.ins.GetEmptySlotDataByCardData(card), true);
				return;
			}
			this.m_StartTimer = this.StartTimer(card);
			GameController.getInstance().StartCoroutine(this.m_StartTimer);
		}
	}

	private IEnumerator StartTimer(CardData card)
	{
		int t = 0;
		for (;;)
		{
			int num = t;
			t = num + 1;
			if (base.Data.Attrs.ContainsKey("Percent"))
			{
				base.Data.Attrs["Percent"] = int.Parse(base.Data.Attrs["Percent"].ToString()) + 1;
				if (this.m_ProgressBar != null)
				{
					this.m_ProgressBar.SetProgress(float.Parse(base.Data.Attrs["Percent"].ToString()) / 100f, base.Data.Attrs["Percent"].ToString());
				}
				if (int.Parse(base.Data.Attrs["Percent"].ToString()) > 99)
				{
					break;
				}
			}
			yield return new WaitForSeconds(0.03f);
		}
		base.Data.Attrs["Percent"] = 0;
		this.m_ProgressBar.SetProgress(0f, 0.ToString() ?? "");
		this.GetAndStartGift(card);
		card.DeleteCardData();
		yield break;
		yield break;
	}

	private void GetAndStartGift(CardData data)
	{
		if (SYNCRandom.Range(0, 100) < 50)
		{
			this.StartGiftAct("破鞋");
			JournalsConversationManager.PutJournals(new JournalsBean
			{
				FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_钓鱼房1")
			});
			return;
		}
		List<string> list = new List<string>();
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if ((cardData.HasTag(TagMap.食物) || cardData.HasTag(TagMap.药水) || cardData.HasTag(TagMap.工具) || cardData.HasTag(TagMap.放置物)) && cardData.Rare == ((data.Rare + 1 > 4) ? 4 : (data.Rare + 1)) && !cardData.HasTag(TagMap.特殊))
			{
				list.Add(cardData.ModID);
			}
		}
		int index = SYNCRandom.Range(0, list.Count);
		this.StartGiftAct(list[index]);
		JournalsConversationManager.PutJournals(new JournalsBean
		{
			FormatString = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_钓鱼房"), list[index])
		});
	}

	private void StartGiftAct(string Values)
	{
		ActData actData = new ActData();
		actData.Type = "Act/Gift";
		actData.Model = "ActTable/Gift";
		(GameController.ins.GameData.PlayerCardData.CardGameObject.StartAct(actData) as GiftAct).GiftNames.Add(Values);
	}

	private CardSlotData m_SlotData;

	private UIController.UILevel m_Lock = UIController.UILevel.All;

	private SpaceProgressBarTool m_ProgressBar;

	private IEnumerator m_StartTimer;
}
