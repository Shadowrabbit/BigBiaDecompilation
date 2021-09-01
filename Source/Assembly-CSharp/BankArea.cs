using System;
using UnityEngine;

public class BankArea : MonoBehaviour
{
	private void Start()
	{
		this.isDo = false;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (UIController.LockLevel == UIController.UILevel.All)
			{
				return;
			}
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f);
			if (raycastHit.collider != null && raycastHit.collider.gameObject == this.Waiter)
			{
				if (this.isDo)
				{
					GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_14"), 1f, 2f, 1f, 1f);
					return;
				}
				this.ShowBankPanel();
			}
		}
	}

	private void ShowBankPanel()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("UI/Canvas/BankCanvas"));
		gameObject.transform.position = new Vector3(2.99f, 0f, 8.63f);
		gameObject.transform.rotation = Quaternion.Euler(55f, 0f, 0f);
		this.isDo = true;
	}

	public GameObject Waiter;

	public bool isDo;
}
