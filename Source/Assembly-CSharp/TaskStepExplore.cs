using System;

public class TaskStepExplore : TaskStep
{
	public TaskStepExplore()
	{
		this.Type = TaskStepType.EXPLORE;
	}

	protected override void OnSetState()
	{
		base.OnSetState();
		if (this.State == TaskState.ACTIVE)
		{
			GameController.getInstance().GameEventManager.OnEnterAreaEvent += this.OnEnterArea;
			return;
		}
		GameController.getInstance().GameEventManager.OnEnterAreaEvent -= this.OnEnterArea;
	}

	private void OnEnterArea(string areaId)
	{
		if (this.Destination.Equals(areaId))
		{
			base.SetState(TaskState.SUCCESS);
		}
	}

	public string Destination;
}
