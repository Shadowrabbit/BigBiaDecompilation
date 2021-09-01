using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class ShakeAnimation : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void StartShake()
	{
		if (this.isShake)
		{
			this.isShake = false;
			return;
		}
		this.isShake = true;
		this.ShakeOut();
	}

	private void ShakeOut()
	{
		if (!this.isShake)
		{
			return;
		}
		base.transform.DOLocalMove(new Vector3(0.03f, 0.06f, 0.03f), 0.05f, false).OnComplete(new TweenCallback(this.ShakeIn));
	}

	private void ShakeIn()
	{
		if (!this.isShake)
		{
			return;
		}
		base.transform.DOLocalMove(new Vector3(-0.03f, -0.06f, -0.03f), 0.05f, false).OnComplete(new TweenCallback(this.ShakeOut));
	}

	private bool isShake;
}
