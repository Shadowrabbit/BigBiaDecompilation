using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class TavernArea : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f);
			if (raycastHit.collider != null && raycastHit.collider.gameObject == this.Bartender.gameObject)
			{
				if (GlobalController.Instance.GlobalData.HadSlotCount < 8)
				{
					DialogueManager.StartConversation("酒保", base.transform, this.Bartender);
					return;
				}
				GameController.getInstance().CreateSubtitle("您已解锁全部卡槽！", 1f, 2f, 1f, 1f);
			}
		}
	}

	public Transform Bartender;

	public TavernAreaLogic TavernAreaLogic;
}
