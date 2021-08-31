using System;

public class Trash : CardSlotLogic
{
	public override void OnDayPassed()
	{
		throw new NotImplementedException();
	}

	public override void OnCardPutIn(CardSlot formSlot, CardSlot tarSlot, Card card)
	{
		card.PlayAnimationForCardSlotChild(tarSlot.transform, "OnCardPutIn");
		card.DeleteCard();
	}
}
