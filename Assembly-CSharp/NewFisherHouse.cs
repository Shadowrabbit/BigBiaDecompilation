using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class NewFisherHouse : AreaLogic
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
			this.m_SlotData.ChildCardData.PutInSlotData(this.GetEmptySlotFromPlayerTable(), true);
		}
		if (this.m_StartTimer != null)
		{
			GameController.getInstance().StopCoroutine(this.m_StartTimer);
		}
		base.Data.Attrs["Percent"] = int.Parse(base.Data.Attrs["Percent"].ToString()) - int.Parse(base.Data.Attrs["Percent"].ToString()) % 10;
		if (this.m_ProgressBar != null)
		{
			this.m_ProgressBar.SetProgress(float.Parse(base.Data.Attrs["Percent"].ToString()) / 100f, base.Data.Attrs["Percent"].ToString());
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
		this.m_SlotData.CardSlotGameObject.SetIcon(7);
		this.m_SlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
		this.m_ProgressBar = UnityEngine.Object.FindObjectOfType<SpaceProgressBarTool>();
		if (this.m_ProgressBar != null)
		{
			this.m_ProgressBar.SetProgress(float.Parse(base.Data.Attrs["Percent"].ToString()) / 100f, base.Data.Attrs["Percent"].ToString());
		}
		yield break;
	}

	private void Transaction(CardSlotData oldCardSlot, CardSlotData newCardSlot, CardData card)
	{
		if (oldCardSlot == null || newCardSlot == null)
		{
			return;
		}
		if (oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Player && newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area && card.ModID.Equals("时间卡片"))
		{
			this.m_StartTimer = this.StartTimer(card);
			GameController.getInstance().StartCoroutine(this.m_StartTimer);
		}
		if (newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Player && oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area && card.ModID.Equals("时间卡片") && this.m_StartTimer != null)
		{
			GameController.getInstance().StopCoroutine(this.m_StartTimer);
			base.Data.Attrs["Percent"] = int.Parse(base.Data.Attrs["Percent"].ToString()) - int.Parse(base.Data.Attrs["Percent"].ToString()) % 10;
			if (this.m_ProgressBar != null)
			{
				this.m_ProgressBar.SetProgress(float.Parse(base.Data.Attrs["Percent"].ToString()) / 100f, base.Data.Attrs["Percent"].ToString());
			}
		}
	}

	private IEnumerator StartTimer(CardData card)
	{
		int t = 0;
		for (;;)
		{
			int num = t;
			t = num + 1;
			if (card.Count <= 0)
			{
				goto IL_19D;
			}
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
			if (t % 10 == 0)
			{
				this.FadeTip(card);
				card.Count--;
			}
			yield return new WaitForSeconds(0.1f);
		}
		base.Data.Attrs["Percent"] = 0;
		card.Count--;
		card.PutInSlotData(this.GetEmptySlotFromPlayerTable(), true);
		this.StartGiftAct("寿司,披萨,汉堡,生命药水", card.CardGameObject);
		yield break;
		IL_19D:
		card.DeleteCardData();
		yield break;
		yield break;
	}

	private void StartGiftAct(string Values, Card card)
	{
		GiftAct giftAct = card.StartAct(new ActData
		{
			Type = "Act/Gift",
			Model = "ActTable/Gift"
		}) as GiftAct;
		List<string> list = new List<string>();
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if (cardData.HasTag(TagMap.肉))
			{
				list.Add(cardData.ModID);
			}
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		giftAct.GiftNames.Add(list[index]);
		card.CardData.PutInSlotData(this.GetEmptySlotFromPlayerTable(), true);
	}

	private CardSlotData GetEmptySlotFromPlayerTable()
	{
		for (int i = 0; i < GlobalController.Instance.HomeDataController.GetPlayerTableCardSlotDatasToHomeData().Count; i++)
		{
			if (GlobalController.Instance.HomeDataController.GetPlayerTableCardSlotDatasToHomeData()[i].ChildCardData == null)
			{
				return GlobalController.Instance.HomeDataController.GetPlayerTableCardSlotDatasToHomeData()[i];
			}
		}
		return null;
	}

	private void FadeTip(CardData card)
	{
		GameObject copyGo = Card.InitWithOutData(card, true);
		copyGo.transform.SetParent(card.CardGameObject.transform.parent);
		copyGo.transform.localPosition = card.CardGameObject.transform.localPosition;
		copyGo.transform.localScale = card.CardGameObject.transform.localScale;
		new FadeModel(copyGo, 0.5f).HideModel();
		copyGo.transform.DOScale(Vector3.one * 2f, 0.5f).OnComplete(delegate
		{
			UnityEngine.Object.Destroy(copyGo);
		});
	}

	private CardSlotData m_SlotData;

	private UIController.UILevel m_Lock = UIController.UILevel.All;

	private SpaceProgressBarTool m_ProgressBar;

	private IEnumerator m_StartTimer;
}
