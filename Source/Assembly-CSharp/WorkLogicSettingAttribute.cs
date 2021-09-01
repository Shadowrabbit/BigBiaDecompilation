using System;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class WorkLogicSettingAttribute : Attribute
{
	public ushort Step { get; private set; }

	public string AnimClipName { get; private set; }

	public float Duration { get; private set; }

	public ushort? StepOnFailed { get; private set; }

	public WorkLogicSettingAttribute(ushort step, string animClipName, float duration, ushort? StepOnFailed)
	{
		this.Step = step;
		this.AnimClipName = animClipName;
		this.Duration = duration;
	}

	public WorkLogicSettingAttribute(ushort step, string animClipName, float duration) : this(step, animClipName, duration, null)
	{
	}
}
