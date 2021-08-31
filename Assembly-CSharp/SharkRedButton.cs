using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class SharkRedButton : MonoBehaviour
{
	private void Start()
	{
		this.completeCallBack = new TweenCallback(this.Shark.OnSharkEnd);
	}

	private void OnMouseDown()
	{
		if (this.isEnd)
		{
			return;
		}
		base.transform.DOMove(base.transform.position + new Vector3(0f, -0.02f, 0f), 0.1f, false);
	}

	private void OnMouseUp()
	{
		if (this.isEnd)
		{
			return;
		}
		DungeonOperationMgr.Instance.ChangeMoney(this.Shark.Gold);
		base.transform.DOMove(base.transform.position + new Vector3(0f, 0.02f, 0f), 0.1f, false).OnComplete(this.completeCallBack);
		this.isEnd = true;
	}

	public Shark Shark;

	public bool isEnd;

	private TweenCallback completeCallBack;
}
