using System;
using System.Collections.Generic;

[Serializable]
public class ActData
{
	public string Name;

	public string Type;

	public string Model;

	public int InputSlotNum;

	public List<bool> Necessary;

	[NonSerialized]
	public Action Callback;
}
