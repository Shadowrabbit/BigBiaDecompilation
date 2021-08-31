using System;
using UnityEngine;

public class CampArea : MonoBehaviour
{
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
		try
		{
			GameController.ins.SaveGame();
		}
		catch
		{
			Debug.Log("储存游戏失败");
		}
		foreach (CardSlotData cardSlotData in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.法术))
			{
				cardSlotData.ChildCardData.RemainTime = 0;
				cardSlotData.ChildCardData.IsAttacked = false;
			}
		}
		DungeonController.Instance.GenerateNextArea(true);
	}

	public GameObject ExitBtn;
}
