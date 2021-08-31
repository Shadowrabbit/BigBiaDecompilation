using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class TaskStepConverter : CustomCreationConverter<TaskStep>
{
	public override TaskStep Create(Type objectType)
	{
		TaskStepType taskStepType = TaskStepType.DEFEAT;
		if (Enum.TryParse<TaskStepType>(this.typeString, out taskStepType))
		{
			switch (taskStepType)
			{
			case TaskStepType.DEFEAT:
				return new TaskStepDefeat();
			case TaskStepType.ESCORT:
				return new TaskStepEscort();
			case TaskStepType.TALK:
				return new TaskStepTalk();
			case TaskStepType.COLLECT:
				return new TaskStepCollect();
			case TaskStepType.EXPLORE:
				return new TaskStepExplore();
			case TaskStepType.RECRUIT:
				return new TaskStepRecruit();
			}
		}
		Debug.LogError("Can't parse action type " + this.typeString);
		return new TaskStep();
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		JObject jobject = JObject.Load(reader);
		this.typeString = jobject["Type"].ToString();
		return base.ReadJson(jobject.CreateReader(), objectType, existingValue, serializer);
	}

	private string typeString;
}
