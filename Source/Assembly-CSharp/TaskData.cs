using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

public class TaskData
{
	public static TaskData CopyTaskData(TaskData taskData)
	{
		return JsonConvert.DeserializeObject<TaskData>(JsonConvert.SerializeObject(taskData));
	}

	private TaskState GetState()
	{
		TaskState result = TaskState.SUCCESS;
		foreach (TaskStep taskStep in this.Steps)
		{
			if (taskStep.State == TaskState.ABANDON)
			{
				return TaskState.ABANDON;
			}
			if (taskStep.State == TaskState.FAILURE)
			{
				return TaskState.FAILURE;
			}
			if (taskStep.State == TaskState.ACTIVE)
			{
				result = TaskState.ACTIVE;
			}
		}
		return result;
	}

	public bool IsFinished()
	{
		foreach (TaskStep taskStep in this.Steps)
		{
			TaskState state = taskStep.State;
			if (state <= TaskState.ACTIVE)
			{
				return false;
			}
		}
		return true;
	}

	public bool IsActive()
	{
		return this.State == TaskState.ACTIVE;
	}

	public void Active()
	{
		if (this.IsActive())
		{
			return;
		}
		this.SetState(TaskState.ACTIVE);
	}

	public void SetState(TaskState state)
	{
		foreach (TaskStep taskStep in this.Steps)
		{
			taskStep.SetState(state);
		}
	}

	public void UpdateState()
	{
		TaskState taskState = TaskState.SUCCESS;
		foreach (TaskStep taskStep in this.Steps)
		{
			if (taskStep.State == TaskState.ABANDON)
			{
				taskState = TaskState.ABANDON;
				break;
			}
			if (taskStep.State == TaskState.FAILURE)
			{
				taskState = TaskState.FAILURE;
				break;
			}
			if (taskStep.State == TaskState.ACTIVE)
			{
				taskState = TaskState.ACTIVE;
			}
		}
		if (this.State != taskState)
		{
			this.State = taskState;
			GameController.getInstance().GameEventManager.TaskStateChanged(this.Name);
		}
	}

	[OnDeserialized]
	public void OnDeserialized(StreamingContext context)
	{
		int num = 0;
		foreach (TaskStep taskStep in this.Steps)
		{
			taskStep.Task = this;
			taskStep.Index = num++;
		}
	}

	public TaskState State;

	public string Name;

	public string ID;

	public string ModID;

	public string Model;

	public string Des;

	public bool AutoSettle;

	public bool IsSettled;

	public Dictionary<string, int> Rewards = new Dictionary<string, int>();

	public List<TaskStep> Steps = new List<TaskStep>();

	public Dictionary<TaskState, TaskData.TaskConversation> Conversations = new Dictionary<TaskState, TaskData.TaskConversation>();

	public Dictionary<int, TaskData.TaskConversation> StepConversations = new Dictionary<int, TaskData.TaskConversation>();

	public class TaskConversation
	{
		public string Conversation;

		public string Conversant;
	}
}
