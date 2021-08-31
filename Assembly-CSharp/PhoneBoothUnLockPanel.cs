using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class PhoneBoothUnLockPanel : MonoBehaviour
{
	public void OnUnLock()
	{
		PhoneBoothController.Instance.UnLockCards.Add(this.CardInfo.cardData);
		base.gameObject.SetActive(false);
		this.CardInfo.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack).OnComplete(delegate
		{
			this.CardInfo.gameObject.SetActive(false);
			UnityEngine.Object.Destroy(base.gameObject);
		});
	}

	public void OnCancel()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public PhoneCardInfo CardInfo;
}
