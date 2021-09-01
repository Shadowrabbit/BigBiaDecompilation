using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class Basket : MonoBehaviour
{
	private void Start()
	{
		TweenerCore<Vector3, Vector3, VectorOptions> t = base.transform.DOLocalMoveY(1f, 3f, false);
		t.SetLoops(100, LoopType.Yoyo);
		t.SetEase(Ease.InOutCubic);
	}

	private void Update()
	{
	}
}
