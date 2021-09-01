using System;
using UnityEngine;

public class QuitGamePanelController : MonoBehaviour
{
	public void OnQuitGame()
	{
		base.gameObject.SetActive(false);
		GameController.getInstance().GameData.isInDungeon = false;
		DungeonController.Instance.StartCoroutine(DungeonController.Instance.GameOver(true));
	}

	public void OnCancel()
	{
		base.gameObject.SetActive(false);
	}
}
