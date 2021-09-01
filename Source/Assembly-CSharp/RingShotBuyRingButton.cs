using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class RingShotBuyRingButton : MonoBehaviour
{
	private void Start()
	{
		this.completeCallBack = new TweenCallback(this.RingShotSpecialToy.OnBuyRing);
	}

	private void OnMouseDown()
	{
		if (this.isBuying)
		{
			return;
		}
		this.isBuying = true;
		base.transform.DOMove(base.transform.position + new Vector3(0f, -0.02f, 0f), 0.1f, false);
	}

	private void OnMouseUp()
	{
		this.isBuying = false;
		base.transform.DOMove(base.transform.position + new Vector3(0f, 0.02f, 0f), 0.1f, false).OnComplete(this.completeCallBack);
	}

	public RingShotSpecialToy RingShotSpecialToy;

	public bool isBuying;

	private TweenCallback completeCallBack;
}
