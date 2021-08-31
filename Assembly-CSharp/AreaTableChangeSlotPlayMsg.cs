using System;

[Serializable]
public class AreaTableChangeSlotPlayMsg : MultiPlayMsg
{
	public int FromSlotIndex;

	public int AimSlotIndex;
}
