using System;

[Serializable]
public class ChangeSlotMultiPlayMsg : MultiPlayMsg
{
	public int FromSlotIndex;

	public int AimSlotIndex;
}
