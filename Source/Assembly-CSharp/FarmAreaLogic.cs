using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class FarmAreaLogic : AreaLogic
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
		UIController.LockLevel = this.m_Lock;
	}

	public override IEnumerator OnAlreadEnter()
	{
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent += this.Transaction;
		this.m_Lock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.None;
		List<CardSlotData> cardSlotDatas = base.Data.CardSlotDatas;
		this.m_SlotData = cardSlotDatas[0];
		this.m_SlotData.CardSlotGameObject.SetIcon(7);
		using (List<CardSlotData>.Enumerator enumerator = cardSlotDatas.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardSlotData cardSlotData = enumerator.Current;
				cardSlotData.CardSlotGameObject.SetBorder(1);
				cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
				if (cardSlotData != this.m_SlotData)
				{
					cardSlotData.CardSlotGameObject.transform.localPosition = new Vector3(cardSlotData.CardSlotGameObject.transform.localPosition.x, 0.35f, cardSlotData.CardSlotGameObject.transform.localPosition.z);
				}
			}
			yield break;
		}
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
			if (newCardSlot == base.Data.CardSlotDatas[0])
			{
				if (card.ModID.Equals("时间卡片"))
				{
					bool flag = true;
					foreach (CardSlotData cardSlotData in base.Data.CardSlotDatas)
					{
						if (cardSlotData.ChildCardData != null && cardSlotData != this.m_SlotData)
						{
							flag = false;
							break;
						}
					}
					if (!flag)
					{
						this.m_StartTimer = this.StartTimer(card);
						GameController.getInstance().StartCoroutine(this.m_StartTimer);
					}
					else
					{
						card.PutInSlotData(this.GetEmptySlotFromPlayerTable(), true);
					}
				}
				else
				{
					card.PutInSlotData(this.GetEmptySlotFromPlayerTable(), true);
				}
			}
			else if (card.HasTag(TagMap.植物))
			{
				newCardSlot.SlotType = CardSlotData.Type.Freeze;
				if (card.Count > 1)
				{
					Card card2 = Card.InitCard(CardData.CopyCardData(card, true));
					card2.CardData.Count = card.Count - 1;
					card2.RefreshCountText();
					card2.CardData.PutInSlotData(oldCardSlot, true);
					card.MaxCount = 1;
					card.Count = 1;
					card.CardGameObject.RefreshCountText();
				}
			}
			else
			{
				card.PutInSlotData(this.GetEmptySlotFromPlayerTable(), true);
			}
		}
		if (newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Player && oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area && oldCardSlot == base.Data.CardSlotDatas[0] && card.ModID.Equals("时间卡片") && this.m_StartTimer != null)
		{
			GameController.getInstance().StopCoroutine(this.m_StartTimer);
			foreach (CardSlotData cardSlotData2 in base.Data.CardSlotDatas)
			{
				if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.Attrs.ContainsKey("Percent"))
				{
					cardSlotData2.ChildCardData.Attrs["Percent"] = int.Parse(cardSlotData2.ChildCardData.Attrs["Percent"].ToString()) - int.Parse(cardSlotData2.ChildCardData.Attrs["Percent"].ToString()) % 10;
				}
			}
		}
	}

	private IEnumerator StartTimer(CardData card)
	{
		int t = 0;
		for (;;)
		{
			this.isHaveSeed = false;
			foreach (CardSlotData cardSlotData in base.Data.CardSlotDatas)
			{
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.Attrs.ContainsKey("Percent"))
				{
					this.isHaveSeed = true;
				}
			}
			if (!this.isHaveSeed)
			{
				break;
			}
			int num = t;
			t = num + 1;
			if (card.Count <= 0)
			{
				goto IL_20F;
			}
			foreach (CardSlotData cardSlotData2 in base.Data.CardSlotDatas)
			{
				if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.Attrs.ContainsKey("Percent"))
				{
					cardSlotData2.ChildCardData.Attrs["Percent"] = int.Parse(cardSlotData2.ChildCardData.Attrs["Percent"].ToString()) + 1;
					if (int.Parse(cardSlotData2.ChildCardData.Attrs["Percent"].ToString()) > 99)
					{
						cardSlotData2.ChildCardData.Attrs.Remove("Percent");
						cardSlotData2.SlotType = CardSlotData.Type.Normal;
						GameController.getInstance().StartCoroutine(GameController.getInstance().RotateCardAnimate(cardSlotData2.CardSlotGameObject, cardSlotData2.ChildCardData.Attrs["Ripe"].ToString()));
					}
				}
			}
			if (t % 10 == 0)
			{
				this.FadeTip(card);
				card.Count--;
			}
			yield return new WaitForSeconds(0.1f);
		}
		card.PutInSlotData(this.GetEmptySlotFromPlayerTable(), true);
		yield break;
		IL_20F:
		card.DeleteCardData();
		yield break;
		yield break;
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

	private IEnumerator m_StartTimer;

	private bool isHaveSeed;
}
