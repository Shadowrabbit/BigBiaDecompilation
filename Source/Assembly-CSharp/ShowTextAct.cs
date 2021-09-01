using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;

public class ShowTextAct : GameAct
{
	private void Start()
	{
		this.Init();
	}

	private IEnumerator ShowContentCorotine()
	{
		this.ShowTrans.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
		yield return 0.5f;
		this.TextContent.text = this.ShowContent;
		yield break;
	}

	public void OnEnd()
	{
		this.TextContent.text = "";
		this.ShowTrans.localScale = Vector3.zero;
		this.Source.CardData.DeleteCardData();
		this.ActEnd();
	}

	public Transform ShowTrans;

	public TMP_Text TextContent;

	public string ShowContent;
}
