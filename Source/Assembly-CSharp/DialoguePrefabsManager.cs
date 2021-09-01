using System;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class DialoguePrefabsManager : MonoBehaviour
{
	private DialoguePrefabsManager()
	{
		DialoguePrefabsManager.Instance = this;
	}

	public void ChangeDialogueUI(int index)
	{
		DialogueManager.UseDialogueUI(this.DialoguePrefabs[index]);
	}

	private void Update()
	{
	}

	public static DialoguePrefabsManager Instance;

	public List<GameObject> DialoguePrefabs;
}
