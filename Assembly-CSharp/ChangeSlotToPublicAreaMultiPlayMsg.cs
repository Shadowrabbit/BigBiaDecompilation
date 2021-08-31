using System;

[Serializable]
public class ChangeSlotToPublicAreaMultiPlayMsg : MultiPlayMsg
{
	public int FromSlotIndex;

	public int AimSlotIndex;
}
