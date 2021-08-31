using System;

public class Work : CardSlotLogic
{
	public override void OnDayPassed()
	{
		if (base.Data.ChildCardData == null)
		{
			return;
		}
		GameController.getInstance().GameData.Money += base.Data.GetIntAttr("WorkRewardMoney");
		GameController.getInstance().GameEventManager.MoneyChange(GameController.getInstance().GameData.Money);
	}

	public override void OnCardPutIn(CardSlot fromSlot, CardSlot tarSlot, Card card)
	{
		throw new NotImplementedException();
	}
}
