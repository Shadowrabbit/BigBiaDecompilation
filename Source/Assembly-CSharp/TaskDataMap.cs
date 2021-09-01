using System;
using System.Collections.Generic;
using UnityEngine;

public class TaskDataMap
{
	[SerializeField]
	public List<TaskData> Tasks { get; set; }

	public TaskData getTaskDataByModID(string modId)
	{
		foreach (TaskData taskData in this.Tasks)
		{
			if (taskData.ModID.Equals(modId))
			{
				return taskData;
			}
		}
		return null;
	}
}
