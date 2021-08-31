using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class SlotsEndButton : MonoBehaviour
{
	private void Start()
	{
		this.completeCallBack = new TweenCallback(this.SlotsSpecialToy.OnSlotsEndButton);
	}

	private void OnMouseDown()
	{
		if (this.SlotsSpecialToy.isCompleted || !this.SlotsSpecialToy.StartMouseControl)
		{
			return;
		}
		base.transform.DOMove(base.transform.position + new Vector3(0f, -0.02f, 0f), 0.1f, false);
	}

	private void OnMouseUp()
	{
		if (this.SlotsSpecialToy.isCompleted || !this.SlotsSpecialToy.StartMouseControl)
		{
			return;
		}
		base.transform.DOMove(base.transform.position + new Vector3(0f, 0.02f, 0f), 0.1f, false).OnComplete(this.completeCallBack);
	}

	public SlotsSpecialToy SlotsSpecialToy;

	private TweenCallback completeCallBack;
}
