using System;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class WorkLogicRedisplaySettingAttribute : Attribute
{
	public WorkLogicRedisplaySettingAttribute(ushort linkedStep)
	{
		this.LinkedStep = linkedStep;
	}

	public ushort LinkedStep;
}
