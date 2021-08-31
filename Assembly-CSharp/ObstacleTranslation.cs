using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class ObstacleTranslation : MonoBehaviour
{
	private void Start()
	{
		base.transform.DOLocalMoveZ(this.translationValue, 2f, false).SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo);
	}

	private void Update()
	{
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.name == "Ball")
		{
			this.noBoundarySpecialToy.OnGameFail();
		}
	}

	public NoBoundarySpecialToy noBoundarySpecialToy;

	public float translationValue = 0.1f;
}
