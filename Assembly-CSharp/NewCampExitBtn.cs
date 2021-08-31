using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class NewCampExitBtn : MonoBehaviour
{
	private void Start()
	{
		this.m_IsClick = false;
	}

	private void OnMouseDown()
	{
		if (this.m_IsClick)
		{
			return;
		}
		base.transform.DOMove(base.transform.position + new Vector3(0f, -0.05f, 0f), 0.1f, false);
	}

	private void OnMouseUp()
	{
		if (this.m_IsClick)
		{
			return;
		}
		this.m_IsClick = true;
		base.transform.DOMove(base.transform.position + new Vector3(0f, 0.05f, 0f), 0.1f, false).OnComplete(delegate
		{
			this.NewCampArea.ExitCampArea();
		});
	}

	public NewCampArea NewCampArea;

	private bool m_IsClick;
}
