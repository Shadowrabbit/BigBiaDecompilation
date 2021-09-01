using System;
using UnityEngine;

public class LeaderBoardOpenButton : MonoBehaviour
{
	private void Start()
	{
	}

	public void OnClick()
	{
		UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("UI/排行榜/LeaderBoard")).transform.SetParent(GameController.ins.UIController.FullScreenCanvasTrans.transform, false);
	}
}
