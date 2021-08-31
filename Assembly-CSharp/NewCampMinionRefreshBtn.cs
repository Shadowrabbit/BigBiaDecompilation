using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class NewCampMinionRefreshBtn : MonoBehaviour
{
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
			this.m_IsClick = false;
			this.NewCampArea.RefreshMinion();
		});
	}

	public NewCampArea NewCampArea;

	private bool m_IsClick;
}
