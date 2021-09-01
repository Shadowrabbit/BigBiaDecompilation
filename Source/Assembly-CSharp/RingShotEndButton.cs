using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class RingShotEndButton : MonoBehaviour
{
	private void Start()
	{
		this.completeCallBack = new TweenCallback(this.RingShotSpecialToy.OnRingShotStartButton);
	}

	private void OnMouseDown()
	{
		if (this.RingShotSpecialToy.isCompleted || !this.RingShotSpecialToy.StartMouseControl)
		{
			return;
		}
		base.transform.DOMove(base.transform.position + new Vector3(0f, -0.02f, 0f), 0.1f, false);
	}

	private void OnMouseUp()
	{
		if (this.RingShotSpecialToy.isCompleted || !this.RingShotSpecialToy.StartMouseControl)
		{
			return;
		}
		base.transform.DOMove(base.transform.position + new Vector3(0f, 0.02f, 0f), 0.1f, false).OnComplete(this.completeCallBack);
	}

	public RingShotSpecialToy RingShotSpecialToy;

	private TweenCallback completeCallBack;
}
