using System;

public static class CardDataExtension
{
	public static string GetCardBottomName(this CardData cardData)
	{
		string result = "CardBottom/NBottom";
		if (!cardData.HasTag(TagMap.奇遇))
		{
			int rare = cardData.Rare;
			switch (rare)
			{
			case 2:
				result = "CardBottom/RBottom";
				break;
			case 3:
				result = "CardBottom/SSSRBottom";
				break;
			case 4:
				result = "CardBottom/SSRBottom";
				break;
			case 5:
				result = "CardBottom/SSSSRBottom";
				break;
			case 6:
				result = "CardBottom/SSSSSRBottom";
				break;
			default:
				if (rare == 101)
				{
					result = "CardBottom/怪物卡面";
				}
				break;
			}
			if (cardData.HasTag(TagMap.药水))
			{
				result = "CardBottom/药水卡面";
			}
			if (cardData.HasTag(TagMap.工具) || cardData.HasTag(TagMap.放置物))
			{
				result = "CardBottom/工具卡面";
			}
			if (cardData.Attrs.ContainsKey("Elite"))
			{
				result = "CardBottom/精英怪物卡面";
			}
		}
		else
		{
			result = "Card/卡背/无尽/1";
			switch (cardData.Rare)
			{
			case 2:
				result = "Card/卡背/无尽/2";
				break;
			case 3:
				result = "Card/卡背/无尽/3";
				break;
			case 4:
				result = "Card/卡背/无尽/4";
				break;
			case 5:
				result = "Card/卡背/无尽/5";
				break;
			}
		}
		return result;
	}
}
