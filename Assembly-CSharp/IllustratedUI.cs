using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class IllustratedUI : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		this.curCanvas.OpenTips(this.CardData, Vector3.zero);
	}

	public CardData CardData;

	public IllustratedCanvasUI curCanvas;
}
