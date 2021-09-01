using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

public class CameraShake : MonoBehaviour
{
	private IEnumerator Shake(float duration, float magnitude)
	{
		this.isShakeing = true;
		Vector3 originalPos = base.transform.localPosition;
		float elapsed = 0f;
		while (elapsed < duration)
		{
			float num = UnityEngine.Random.Range(-1f, 1f) * magnitude;
			float num2 = UnityEngine.Random.Range(-1f, 1f) * magnitude;
			base.transform.localPosition = new Vector3(originalPos.x + num, originalPos.y + num2, originalPos.z);
			elapsed += Time.deltaTime;
			yield return null;
		}
		base.transform.localPosition = originalPos;
		this.isShakeing = false;
		yield break;
	}

	public void StartAnimate(float du, float ma, bool showDmgImg = false)
	{
		if (this.isShakeing)
		{
			return;
		}
		base.StopAllCoroutines();
		this.DamageImage.DOKill(false);
		base.StartCoroutine(this.Shake(du, ma));
		if (!showDmgImg)
		{
			return;
		}
		this.DamageImage.DOFade(1f, 0.5f).OnComplete(delegate
		{
			this.DamageImage.DOFade(0f, 1.5f);
		});
	}

	private void Update()
	{
	}

	public Image DamageImage;

	public Image MaskPanel;

	private bool isShakeing;
}
