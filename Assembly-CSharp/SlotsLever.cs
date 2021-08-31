using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class SlotsLever : MonoBehaviour
{
	private void Start()
	{
		this.completeCallBack = new TweenCallback(this.SlotsSpecialToy.OnSlotsLever);
	}

	private void OnMouseDown()
	{
		if (this.SlotsSpecialToy.isCompleted || !this.SlotsSpecialToy.StartMouseControl)
		{
			return;
		}
		base.transform.DORotate(new Vector3(-30f, 0f, 0f), 0.1f, RotateMode.Fast);
	}

	private void OnMouseUp()
	{
		if (this.SlotsSpecialToy.isCompleted || !this.SlotsSpecialToy.StartMouseControl)
		{
			return;
		}
		base.transform.DORotate(new Vector3(30f, 0f, 0f), 0.1f, RotateMode.Fast).OnComplete(this.completeCallBack);
	}

	public SlotsSpecialToy SlotsSpecialToy;

	private TweenCallback completeCallBack;
}
