using System;
using Cinemachine;
using UnityEngine;

public class ActivateOnKeypress : MonoBehaviour
{
	private void Start()
	{
		this.vcam = base.GetComponent<CinemachineVirtualCameraBase>();
	}

	private void Update()
	{
		if (this.vcam != null)
		{
			if (Input.GetKey(this.ActivationKey))
			{
				if (!this.boosted)
				{
					this.vcam.Priority += this.PriorityBoostAmount;
					this.boosted = true;
				}
			}
			else if (this.boosted)
			{
				this.vcam.Priority -= this.PriorityBoostAmount;
				this.boosted = false;
			}
		}
		if (this.Reticle != null)
		{
			this.Reticle.SetActive(this.boosted);
		}
	}

	public KeyCode ActivationKey = KeyCode.LeftControl;

	public int PriorityBoostAmount = 10;

	public GameObject Reticle;

	private CinemachineVirtualCameraBase vcam;

	private bool boosted;
}
