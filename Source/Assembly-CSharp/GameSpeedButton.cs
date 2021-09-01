using System;
using UnityEngine;

public class GameSpeedButton : MonoBehaviour
{
	private void Start()
	{
		if (GameController.ins.UIController.SpeedOneButton.gameObject == base.gameObject)
		{
			GameController.ins.UIController.SpeedOneButton.localPosition = new Vector3(GameController.ins.UIController.SpeedOneButton.localPosition.x, -0.1f, GameController.ins.UIController.SpeedOneButton.localPosition.z);
		}
	}

	private void OnMouseDown()
	{
		if (GameController.ins.GameSpeed != this.Speed)
		{
			GameController.ins.GameSpeed = this.Speed;
			Time.timeScale = (float)this.Speed;
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, -0.1f, base.transform.localPosition.z);
			if (GameController.ins.UIController.SpeedOneButton.gameObject != base.gameObject)
			{
				GameController.ins.UIController.SpeedOneButton.localPosition = new Vector3(GameController.ins.UIController.SpeedOneButton.localPosition.x, 0.062f, GameController.ins.UIController.SpeedOneButton.localPosition.z);
				return;
			}
			if (GameController.ins.UIController.SpeedTwoButton.gameObject != base.gameObject)
			{
				GameController.ins.UIController.SpeedTwoButton.localPosition = new Vector3(GameController.ins.UIController.SpeedTwoButton.localPosition.x, 0.062f, GameController.ins.UIController.SpeedTwoButton.localPosition.z);
			}
		}
	}

	private void Update()
	{
	}

	public int Speed;
}
