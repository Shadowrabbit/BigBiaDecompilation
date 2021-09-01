using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookContentUI : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		this.curCanvas.ShowBookContent(this.BookData);
	}

	public BookData BookData;

	public IllustratedCanvasUI curCanvas;
}
