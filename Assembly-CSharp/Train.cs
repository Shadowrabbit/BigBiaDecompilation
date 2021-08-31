using System;

public class Train : CardSlotLogic
{
	public override void OnCardPutIn(CardSlot fromSlot, CardSlot tarSlot, Card card)
	{
		throw new NotImplementedException();
	}

	public override void OnDayPassed()
	{
		if (base.Data.ChildCardData == null)
		{
			return;
		}
		base.Data.ChildCardData.MaxHP += base.Data.GetIntAttr("MaxHpBouns");
	}
}
