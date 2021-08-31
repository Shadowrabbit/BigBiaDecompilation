using System;
using UnityEngine;

public static class CardUtils
{
	public static GameController GameController
	{
		get
		{
			return GameController.getInstance();
		}
	}

	public static bool CanPutInSlot(this Card card, CardSlot cardSlot)
	{
		return false;
	}

	public static bool CheckOverLay(this Card card, CardSlot cardSlot)
	{
		if (card.CardData == null)
		{
			return false;
		}
		if (cardSlot == null || cardSlot.ChildCard == null)
		{
			return false;
		}
		if (cardSlot.CardSlotData.OnlyAcceptOneCard)
		{
			return false;
		}
		CardData cardData = cardSlot.ChildCard.CardData;
		if (card.CardData == cardData)
		{
			return false;
		}
		if (card.CardData.Count + cardData.Count > card.CardData.MaxCount)
		{
			return false;
		}
		if (!string.IsNullOrEmpty(cardData.ModID))
		{
			return cardData.ModID.Equals(card.CardData.ModID);
		}
		return !string.IsNullOrEmpty(cardData.StructBase64String) && cardData.StructBase64String.Equals(card.CardData.StructBase64String);
	}

	public static bool IsUserCard(CardData cardData)
	{
		return cardData != null && cardData.CurrentCardSlotData != null && CardUtils.GameController.IsPlayerCardSlotData(cardData.CurrentCardSlotData);
	}

	public static Vector3[] Dirs = new Vector3[]
	{
		Vector3.forward,
		Vector3.right,
		Vector3.back,
		Vector3.left,
		Vector3.up
	};
}
