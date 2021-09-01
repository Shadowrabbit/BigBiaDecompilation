using System;

public class TaskStepTalk : TaskStep
{
	public TaskStepTalk()
	{
		this.Type = TaskStepType.TALK;
	}

	public string TargetName;

	public string Tip;
}
