using System;

[Serializable]
public class MergeCardToPlayerTableFromAreaTableMultiPlayMsg : MultiPlayMsg
{
	public int FromSlotIndex;

	public int AimSlotIndex;
}
