using System;
using UnityEngine.SceneManagement;

public class GuideExitAct : GameAct
{
	private void Start()
	{
		this.Init();
		GameController.ins.UIController.ShowBlackMask(null, 0.5f);
		SceneManager.LoadScene("LoadingScene");
		this.ActEnd();
	}
}
