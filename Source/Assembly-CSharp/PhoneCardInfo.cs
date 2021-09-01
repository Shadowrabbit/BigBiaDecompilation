using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class PhoneCardInfo : MonoBehaviour
{
	private void Start()
	{
		EventTriggerListener.Get(base.gameObject).onClick = new EventTriggerListener.VoidDelegate(this.OnGoClicked);
	}

	private void OnGoClicked(GameObject go)
	{
		if (go == base.gameObject)
		{
			PhoneBoothController.Instance.CheckHaveUnlockedPanel();
			Transform transform = UnityEngine.Object.Instantiate<Transform>(Resources.Load<Transform>("UI/PhoneBoothUnLockPanel"));
			transform.GetComponent<PhoneBoothUnLockPanel>().CardInfo = this;
			transform.SetParent(PhoneBoothController.Instance.Canvas);
			transform.localScale = Vector3.zero;
			transform.position = PhoneBoothController.Instance.Camera.WorldToScreenPoint(base.gameObject.transform.position);
			transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
			PhoneBoothController.Instance.AllUnlockedPanel.Add(transform.gameObject);
		}
	}

	public void OnMouseEnter()
	{
		GameUIController.Instance.OpenTips(this.cardData, base.transform.position, PhoneBoothController.Instance.Camera);
	}

	public void OnMouseExit()
	{
		GameUIController.Instance.CloseTips();
	}

	public CardData cardData;
}
