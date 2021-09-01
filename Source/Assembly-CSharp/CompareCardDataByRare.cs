using System;
using System.Collections.Generic;

public class CompareCardDataByRare : IComparer<CardData>
{
	public int Compare(CardData x, CardData y)
	{
		if (x.Rare < y.Rare)
		{
			return -1;
		}
		if (x.Rare > y.Rare)
		{
			return 1;
		}
		return 0;
	}
}
