using System;

public class TagMapUtil
{
	public static bool HasConsumeTag(CardData cardData)
	{
		bool result = false;
		if (cardData == null)
		{
			return result;
		}
		if (cardData.HasTag(TagMap.道具))
		{
			result = true;
		}
		if (cardData.HasTag(TagMap.符文))
		{
			result = true;
		}
		return result;
	}

	public static bool HasSkillTag(CardData cardData)
	{
		if (cardData == null)
		{
			return false;
		}
		bool result = false;
		if (cardData.HasTag(TagMap.法术))
		{
			result = true;
		}
		if (cardData.HasTag(TagMap.随从))
		{
			result = true;
		}
		return result;
	}
}
