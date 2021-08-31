using System;

public abstract class CardSlotLogic
{
	public CardSlotData Data
	{
		get
		{
			return this.m_Data;
		}
		set
		{
			this.m_Data = value;
		}
	}

	public abstract void OnDayPassed();

	public abstract void OnCardPutIn(CardSlot fromSlot, CardSlot tarSlot, Card card);

	protected CardSlotData m_Data;
}
