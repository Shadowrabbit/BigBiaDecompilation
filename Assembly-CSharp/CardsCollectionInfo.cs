using System;
using UnityEngine;

public class CardsCollectionInfo : MonoBehaviour
{
	private void OnMouseOver()
	{
		GameUIController.Instance.OpenTips(this.cardData, base.transform.position);
	}

	public void OnMouseExit()
	{
		GameUIController.Instance.CloseTips();
	}

	public CardData cardData;
}
