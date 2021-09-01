using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class CameraScaleAndRoll : MonoBehaviour
{
	private void FixedUpdate()
	{
		if (!this.IsCanMove)
		{
			return;
		}
		if (Input.mousePosition.x <= (float)(Screen.width / 100) && this.MCamera.transform.position.x > this.MinX)
		{
			this.MCamera.transform.position += Vector3.left * this.MoveSpeed;
			return;
		}
		if (Input.mousePosition.x >= (float)(Screen.width / 100 * 99) && this.MCamera.transform.position.x < this.MaxX)
		{
			this.MCamera.transform.position += Vector3.right * this.MoveSpeed;
		}
	}

	private void Update()
	{
	}

	private void ChangeView(int dir)
	{
		if (this.m_IsView)
		{
			return;
		}
		if (dir != 0)
		{
			if (dir != 1)
			{
				return;
			}
			if (this.curIndex < 2)
			{
				this.m_IsView = true;
				this.MCamera.transform.DOMove(this.MCamera.transform.position - this.MCamera.transform.forward * this.ZoomDistance, 0.5f, false).SetEase(Ease.OutQuad).OnComplete(delegate
				{
					this.curIndex++;
					this.m_IsView = false;
				});
			}
		}
		else if (this.curIndex > 0)
		{
			this.m_IsView = true;
			this.MCamera.transform.DOMove(this.MCamera.transform.position + this.MCamera.transform.forward * this.ZoomDistance, 0.5f, false).SetEase(Ease.OutQuad).OnComplete(delegate
			{
				this.curIndex--;
				this.m_IsView = false;
			});
			return;
		}
	}

	public Camera MCamera;

	public float MinX;

	public float MaxX = 10f;

	public float MoveSpeed = 0.1f;

	public float ZoomDistance = 5f;

	private int curIndex;

	public bool IsCanMove = true;

	private bool m_IsView;
}
