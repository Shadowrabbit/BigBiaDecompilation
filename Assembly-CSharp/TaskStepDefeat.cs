using System;

public class TaskStepDefeat : TaskStep
{
	public TaskStepDefeat()
	{
		this.Type = TaskStepType.DEFEAT;
	}

	protected override void OnSetState()
	{
		base.OnSetState();
		if (this.State == TaskState.ACTIVE)
		{
			GameController.getInstance().GameEventManager.OnCurrentActEndEvent += this.OnActEnd;
			return;
		}
		GameController.getInstance().GameEventManager.OnCurrentActEndEvent -= this.OnActEnd;
	}

	private void OnActEnd()
	{
		if (this.Count == this.MaxCount && this.State != TaskState.SUCCESS)
		{
			base.SetState(TaskState.SUCCESS);
		}
	}

	private void OnCharacterKilled(string name)
	{
		if (this.TargetName.Equals(name))
		{
			this.Count++;
			if (this.Count >= this.MaxCount)
			{
				this.Count = this.MaxCount;
			}
		}
	}

	public string TargetName;

	public int MaxCount;

	public int Count;
}
