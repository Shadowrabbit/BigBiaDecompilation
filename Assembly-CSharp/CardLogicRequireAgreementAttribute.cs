using System;

[AttributeUsage(AttributeTargets.Class)]
public class CardLogicRequireAgreementAttribute : Attribute
{
	public CardLogicRequireAgreementAttribute(int agreement)
	{
		this._agreement = agreement;
	}

	public int Agreement
	{
		get
		{
			return this._agreement;
		}
	}

	private int _agreement;
}
