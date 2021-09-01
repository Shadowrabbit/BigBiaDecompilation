using System;

public class TaskStepRecruit : TaskStep
{
	public TaskStepRecruit()
	{
		this.Type = TaskStepType.RECRUIT;
	}

	protected override void OnSetState()
	{
		base.OnSetState();
		if (this.State == TaskState.ACTIVE)
		{
			GameController.getInstance().GameEventManager.OnRoleBeRecruitEvent += this.OnRoleBeRecruit;
			return;
		}
		GameController.getInstance().GameEventManager.OnRoleBeRecruitEvent -= this.OnRoleBeRecruit;
	}

	private void OnRoleBeRecruit(CardData targetCardData)
	{
		int count = GameController.getInstance().FindCardOnPlayerTableByType(targetCardData);
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

	public string TargetType;

	public int MaxCount;

	public int Count;
}
