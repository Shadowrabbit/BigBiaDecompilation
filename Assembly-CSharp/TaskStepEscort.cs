using System;

public class TaskStepEscort : TaskStep
{
	public TaskStepEscort()
	{
		this.Type = TaskStepType.ESCORT;
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

	private void OnDungeonComplete(string areaId)
	{
		if (this.Destination.Equals(areaId))
		{
			base.SetState(TaskState.SUCCESS);
		}
	}

	private void OnEnterArea(string areaId)
	{
		if (this.Destination.Equals(areaId) && string.IsNullOrEmpty(GameController.getInstance().GameData.AreaMap[areaId].DungeonPath))
		{
			base.SetState(TaskState.SUCCESS);
		}
	}

	private void OnCharacterKilled(string name)
	{
		if (this.TargetName.Equals(name))
		{
			base.SetState(TaskState.FAILURE);
		}
	}

	public string TargetName;

	public string Destination;
}
