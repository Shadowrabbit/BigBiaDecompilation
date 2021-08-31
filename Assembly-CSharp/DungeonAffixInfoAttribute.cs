using System;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
public class DungeonAffixInfoAttribute : Attribute
{
	public string defaultName { get; private set; }

	public string defaultDescription { get; private set; }

	public string shortDescription { get; private set; }

	public string defaultSpritePath { get; private set; }

	public DungeonAffixInfoAttribute(string defaultName, string defaultDescription, string shortDescription, string defaultSpritePath)
	{
		this.defaultName = defaultName;
		this.defaultDescription = defaultDescription;
		this.shortDescription = shortDescription;
		this.defaultSpritePath = defaultSpritePath;
	}
}
