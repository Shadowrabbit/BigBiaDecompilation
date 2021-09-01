using System;

public class TaskStep
{
	public void SetState(TaskState state)
	{
		if (this.State != state)
		{
			this.State = state;
			this.OnSetState();
		}
	}

	protected virtual void OnSetState()
	{
		GameController.getInstance().GameEventManager.TaskStepStateChanged(this.Task.Name, this.Index);
		this.Task.UpdateState();
	}

	[NonSerialized]
	public TaskData Task;

	[NonSerialized]
	public int Index;

	public TaskStepType Type;

	public TaskState State;
}
