using System;
using System.Collections.Generic;

[Serializable]
public class SyncCardsMultiPlayMsg : MultiPlayMsg
{
	public List<CardData> cards;
}
