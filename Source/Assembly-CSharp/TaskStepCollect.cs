using System;

public class TaskStepCollect : TaskStep
{
	public TaskStepCollect()
	{
		this.Type = TaskStepType.COLLECT;
	}

	protected override void OnSetState()
	{
		base.OnSetState();
		if (this.State == TaskState.ACTIVE)
		{
			GameController.getInstance().GameEventManager.OnItemBeCollectedEvent += this.OnItemBeCollected;
			return;
		}
		GameController.getInstance().GameEventManager.OnItemBeCollectedEvent -= this.OnItemBeCollected;
	}

	private void OnItemBeCollected(string name, int itemCount)
	{
		int count = GameController.getInstance().FindCardOnPlayerTableCount(this.TargetName);
		this.Count = count;
		if (this.Count >= this.MaxCount)
		{
			this.Count = this.MaxCount;
		}
		if (this.Count == this.MaxCount && this.State != TaskState.SUCCESS)
		{
			base.SetState(TaskState.SUCCESS);
		}
	}

	public string TargetName;

	public int MaxCount;

	public int Count;
}
