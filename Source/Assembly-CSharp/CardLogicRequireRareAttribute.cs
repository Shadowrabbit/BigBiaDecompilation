using System;

[AttributeUsage(AttributeTargets.Class)]
public class CardLogicRequireRareAttribute : Attribute
{
	public CardLogicRequireRareAttribute(int rare)
	{
		this._rare = rare;
	}

	public int Rare
	{
		get
		{
			return this._rare;
		}
	}

	private int _rare;
}
