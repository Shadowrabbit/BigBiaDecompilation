using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PEButtonScript : MonoBehaviour, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	private void Start()
	{
		this.myButton = base.gameObject.GetComponent<Button>();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		UICanvasManager.GlobalAccess.MouseOverButton = true;
		UICanvasManager.GlobalAccess.UpdateToolTip(this.ButtonType);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		UICanvasManager.GlobalAccess.MouseOverButton = false;
		UICanvasManager.GlobalAccess.ClearToolTip();
	}

	public void OnButtonClicked()
	{
		UICanvasManager.GlobalAccess.UIButtonClick(this.ButtonType);
	}

	private Button myButton;

	public ButtonTypes ButtonType;
}
