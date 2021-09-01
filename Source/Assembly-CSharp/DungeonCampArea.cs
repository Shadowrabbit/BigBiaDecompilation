using System;
using UnityEngine;

public class DungeonCampArea : MonoBehaviour
{
	private void Start()
	{
		BGMusicManager.Instance.PlayBGMusic(8, 0, null);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f);
			if (raycastHit.collider != null && raycastHit.collider.gameObject == this.ExitBtn && UIController.LockLevel == UIController.UILevel.None)
			{
				this.ExitCampArea();
			}
		}
	}

	private void ExitCampArea()
	{
		GlobalController.Instance.IsLoadGame = false;
		DungeonController.Instance.GenerateNextArea(true);
	}

	public GameObject ExitBtn;
}
