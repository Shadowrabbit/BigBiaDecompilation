using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardDataMap
{
	[SerializeField]
	public List<CardData> Cards { get; set; }

	public CardData getCardDataByModID(string modId)
	{
		if (this.Cards == null)
		{
			return null;
		}
		foreach (CardData cardData in this.Cards)
		{
			if (cardData.ModID.Equals(modId))
			{
				return cardData;
			}
		}
		return null;
	}
}
