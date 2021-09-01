using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPawnShop : AreaLogic
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
		foreach (CardSlotData cardSlotData in base.Data.CardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null)
			{
				cardSlotData.ChildCardData.PutInSlotData(this.GetEmptySlotFromPlayerTable(), true);
			}
		}
		UIController.LockLevel = this.m_Lock;
	}

	public override IEnumerator OnAlreadEnter()
	{
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent += this.Transaction;
		this.m_Lock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.None;
		using (List<CardSlotData>.Enumerator enumerator = base.Data.CardSlotDatas.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardSlotData cardSlotData = enumerator.Current;
				cardSlotData.CardSlotGameObject.SetBorder(1);
				cardSlotData.CardSlotGameObject.SetIcon(4);
				cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
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
			if (card.HasTag(TagMap.道具))
			{
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
				bool flag = true;
				using (List<CardSlotData>.Enumerator enumerator = base.Data.CardSlotDatas.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.ChildCardData == null)
						{
							flag = false;
							break;
						}
					}
				}
				if (!flag)
				{
					return;
				}
				this.StartGiftAct("能量药水", card.CardGameObject);
				using (List<CardSlotData>.Enumerator enumerator = base.Data.CardSlotDatas.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						CardSlotData cardSlotData = enumerator.Current;
						if (cardSlotData.ChildCardData != null)
						{
							cardSlotData.ChildCardData.DeleteCardData();
						}
					}
					return;
				}
			}
			card.PutInSlotData(oldCardSlot, true);
		}
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
			if (cardData.HasTag(TagMap.道具))
			{
				list.Add(cardData.ModID);
			}
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		giftAct.GiftNames.Add(list[index]);
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

	private UIController.UILevel m_Lock = UIController.UILevel.All;
}
