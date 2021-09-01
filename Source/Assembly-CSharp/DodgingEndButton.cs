using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class DodgingEndButton : MonoBehaviour
{
	private void Start()
	{
		this.completeCallBack = new TweenCallback(this.DodgingSpecialToy.OnDodgingEndButton);
	}

	private void OnMouseDown()
	{
		if (this.DodgingSpecialToy.isCompleted || !this.DodgingSpecialToy.StartMouseControl)
		{
			return;
		}
		base.transform.DOMove(base.transform.position + new Vector3(0f, -0.02f, 0f), 0.1f, false);
	}

	private void OnMouseUp()
	{
		if (this.DodgingSpecialToy.isCompleted || !this.DodgingSpecialToy.StartMouseControl)
		{
			return;
		}
		base.transform.DOMove(base.transform.position + new Vector3(0f, 0.02f, 0f), 0.1f, false).OnComplete(this.completeCallBack);
	}

	public DodgingSpecialToy DodgingSpecialToy;

	private TweenCallback completeCallBack;
}
