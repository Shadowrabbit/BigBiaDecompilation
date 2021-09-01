using System;
using DG.Tweening;
using UnityEngine;

public class RedButton : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnMouseDown()
	{
		if (!this.noBoundarySpecialToy.IsStart)
		{
			this.noBoundarySpecialToy.statTime = Time.time;
			this.noBoundarySpecialToy.IsStart = true;
		}
		if (this.noBoundarySpecialToy.IsEnd)
		{
			this.noBoundarySpecialToy.OnEnd();
		}
		base.transform.DOMove(base.transform.position + new Vector3(0f, -0.02f, 0f), 0.1f, false);
	}

	private void OnMouseUp()
	{
		base.transform.DOMove(base.transform.position + new Vector3(0f, 0.02f, 0f), 0.1f, false);
	}

	public NoBoundarySpecialToy noBoundarySpecialToy;
}
