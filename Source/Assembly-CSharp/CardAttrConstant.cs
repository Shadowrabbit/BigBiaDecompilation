using System;
using System.Collections.Generic;

public class CardAttrConstant
{
	public static T GetAttr<T>(CardData cardData, CardAttrType cat)
	{
		return (T)((object)Convert.ChangeType(cardData.Attrs[cat.Name], cat.Type));
	}

	public static CardAttrType ReputationInPartys = new CardAttrType("ReputationInPartys", typeof(Dictionary<string, int>), "在组织中的声望");
}
