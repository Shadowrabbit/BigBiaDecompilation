using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class AmoutTextEffect : MonoBehaviour
{
	private void Start()
	{
		base.StartCoroutine(this.StartEffect());
	}

	private IEnumerator StartEffect()
	{
		Vector3 oldPos = base.transform.position;
		Vector3 oldScalse = base.transform.localScale;
		if (this.isPop)
		{
			if (this.isLoop)
			{
				for (;;)
				{
					base.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
					DOTween.Sequence().Append(base.transform.DOMove(base.transform.position + Vector3.up * 80f, 1f, false)).SetEase(Ease.OutQuad).Insert(0f, base.transform.DOPunchScale(Vector3.one * 3f, 1f, 1, 1f).SetEase(Ease.OutBack)).AppendInterval(0.3f).OnComplete(delegate
					{
					});
					yield return new WaitForSeconds(1.5f);
					base.transform.position = oldPos;
					base.transform.localScale = Vector3.zero;
				}
			}
			else
			{
				base.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
				DOTween.Sequence().Append(base.transform.DOMove(base.transform.position + Vector3.up * 80f, 1f, false)).SetEase(Ease.OutQuad).Insert(0f, base.transform.DOPunchScale(Vector3.one * 3f, 1f, 1, 1f).SetEase(Ease.OutBack)).AppendInterval(0.3f).OnComplete(delegate
				{
					UnityEngine.Object.Destroy(this.gameObject);
				});
			}
		}
		else if (this.isLoop)
		{
			DOTween.Sequence().Append(base.transform.DOMove(base.transform.position + Vector3.up * 80f, 1f, false)).SetEase(Ease.OutQuad).AppendInterval(0.3f);
			yield return new WaitForSeconds(1f);
			for (;;)
			{
				base.transform.DOScale(base.transform.localScale * 1.2f, 0.5f).OnComplete(delegate
				{
					this.transform.DOScale(oldScalse, 0.5f);
				});
				yield return new WaitForSeconds(1.3f);
			}
		}
		else
		{
			DOTween.Sequence().Append(base.transform.DOMove(base.transform.position + Vector3.up * 80f, 1f, false)).SetEase(Ease.OutQuad).AppendInterval(0.3f).OnComplete(delegate
			{
				UnityEngine.Object.Destroy(this.gameObject);
			});
		}
		yield break;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && this.isLoop)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public bool isPop;

	public bool isLoop;
}
