using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class PreSceneDialogueTrigger : MonoBehaviour
{
	private void Start()
	{
		DialogueManager.StartConversation("教官");
	}

	private void Update()
	{
	}
}
