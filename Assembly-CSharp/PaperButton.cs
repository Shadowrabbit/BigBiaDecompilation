using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class PaperButton : MonoBehaviour
{
	private void Start()
	{
		this.completeCallBack = new TweenCallback(this.AniEnd);
	}

	private void Update()
	{
	}

	private void OnMouseDown()
	{
		base.transform.DOMove(base.transform.position + new Vector3(0f, -0.02f, 0f), 0.1f, false);
	}

	private void OnMouseUp()
	{
		base.transform.DOMove(base.transform.position + new Vector3(0f, 0.02f, 0f), 0.1f, false).OnComplete(this.completeCallBack);
	}

	private void AniEnd()
	{
		this.RockPaperScissors.OnButtonDown(2);
	}

	public RockPaperScissors RockPaperScissors;

	private TweenCallback completeCallBack;
}
