using System;

public class SpaceAreaData : AreaData
{
	public CardSlotData GetRalitiveCardSlotData(int TargetX, int TargetY, int RalitiveX, int RalitiveY, bool checkOpenState = false)
	{
		if (TargetX + RalitiveX < 0 || TargetX + RalitiveX >= this.CardSlotGridWidth || TargetY + RalitiveY < 0 || TargetY + RalitiveY >= this.CardSlotGridHeight)
		{
			return null;
		}
		if (!checkOpenState)
		{
			return this.CardSlotDatas[(TargetY + RalitiveY) * this.CardSlotGridWidth + TargetX + RalitiveX];
		}
		if (this.GridOpenState[(TargetY + RalitiveY) * this.CardSlotGridWidth + TargetX + RalitiveX] > 0)
		{
			return this.CardSlotDatas[(TargetY + RalitiveY) * this.CardSlotGridWidth + TargetX + RalitiveX];
		}
		return null;
	}

	public CardSlotData InputFromSlotData;

	public CardSlotData InputToSlotData;

	public CardSlotData OutputFromSlotData;

	public CardSlotData OutputToSlotData;

	public int CardSlotGridWidth;

	public int CardSlotGridHeight;

	public int[] GridOpenState;
}
