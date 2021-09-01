using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
	private void Start()
	{
		base.transform.DOLocalRotate(new Vector3(0f, -360f, 0f), this.RotationTime, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
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

	public float RotationTime = 3f;
}
