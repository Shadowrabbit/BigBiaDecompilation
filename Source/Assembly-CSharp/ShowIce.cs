using System;
using DG.Tweening;
using UnityEngine;

public class ShowIce : MonoBehaviour
{
	private void Start()
	{
		base.transform.localPosition = new Vector3(0f, -0.05f, 0f);
		base.transform.localScale = new Vector3(1f, 0f, 1f);
		base.transform.DOScaleY(0.3f, 0.5f);
	}

	private void Update()
	{
	}
}
