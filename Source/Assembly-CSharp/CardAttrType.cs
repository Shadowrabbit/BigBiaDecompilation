using System;

public class CardAttrType
{
	public CardAttrType(string name, Type type, string desc)
	{
		this.Name = name;
		this.Type = type;
		this.desc = desc;
	}

	public string Name;

	public Type Type;

	public string desc;
}
