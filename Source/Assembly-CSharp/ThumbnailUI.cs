using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThumbnailUI : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		GameController.getInstance().GameEventManager.MakeListButtonClick(this.CardData);
		GameUIController.Instance.CloseUI(typeof(ThumbnailScreen));
	}

	public CardData CardData;
}
