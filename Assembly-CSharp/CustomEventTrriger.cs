using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomEventTrriger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerClickHandler, IPointerExitHandler, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
	private event CustomEventTrriger.TriggerAction OnPointerClickEvent;

	private event CustomEventTrriger.TriggerAction OnPointerEnterEvent;

	private event CustomEventTrriger.TriggerAction OnPointerExitEvent;

	private event CustomEventTrriger.TriggerAction OnPointerDownEvent;

	private event CustomEventTrriger.TriggerAction OnPointerBeginDragEvent;

	private event CustomEventTrriger.TriggerAction OnPointerDragEvent;

	private event CustomEventTrriger.TriggerAction OnPointerEndDragEvent;

	private event CustomEventTrriger.TriggerAction OnPointerDropEvent;

	public void OnPointerClick(PointerEventData eventData)
	{
		CustomEventTrriger.TriggerAction onPointerClickEvent = this.OnPointerClickEvent;
		if (onPointerClickEvent == null)
		{
			return;
		}
		onPointerClickEvent(eventData);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		CustomEventTrriger.TriggerAction onPointerEnterEvent = this.OnPointerEnterEvent;
		if (onPointerEnterEvent == null)
		{
			return;
		}
		onPointerEnterEvent(eventData);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CustomEventTrriger.TriggerAction onPointerExitEvent = this.OnPointerExitEvent;
		if (onPointerExitEvent == null)
		{
			return;
		}
		onPointerExitEvent(eventData);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		CustomEventTrriger.TriggerAction onPointerDownEvent = this.OnPointerDownEvent;
		if (onPointerDownEvent == null)
		{
			return;
		}
		onPointerDownEvent(eventData);
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		CustomEventTrriger.TriggerAction onPointerBeginDragEvent = this.OnPointerBeginDragEvent;
		if (onPointerBeginDragEvent == null)
		{
			return;
		}
		onPointerBeginDragEvent(eventData);
	}

	public void OnDrag(PointerEventData eventData)
	{
		CustomEventTrriger.TriggerAction onPointerDragEvent = this.OnPointerDragEvent;
		if (onPointerDragEvent == null)
		{
			return;
		}
		onPointerDragEvent(eventData);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		CustomEventTrriger.TriggerAction onPointerEndDragEvent = this.OnPointerEndDragEvent;
		if (onPointerEndDragEvent == null)
		{
			return;
		}
		onPointerEndDragEvent(eventData);
	}

	public void OnDrop(PointerEventData eventData)
	{
		CustomEventTrriger.TriggerAction onPointerDropEvent = this.OnPointerDropEvent;
		if (onPointerDropEvent == null)
		{
			return;
		}
		onPointerDropEvent(eventData);
	}

	public void AddListener(EventTriggerType type, CustomEventTrriger.TriggerAction action)
	{
		switch (type)
		{
		case EventTriggerType.PointerEnter:
			this.OnPointerEnterEvent += action;
			return;
		case EventTriggerType.PointerExit:
			this.OnPointerExitEvent += action;
			return;
		case EventTriggerType.PointerDown:
			this.OnPointerDownEvent += action;
			return;
		case EventTriggerType.PointerClick:
			this.OnPointerClickEvent += action;
			return;
		case EventTriggerType.Drag:
			this.OnPointerDragEvent += action;
			return;
		case EventTriggerType.Drop:
			this.OnPointerDropEvent += action;
			return;
		case EventTriggerType.BeginDrag:
			this.OnPointerBeginDragEvent += action;
			return;
		case EventTriggerType.EndDrag:
			this.OnPointerEndDragEvent += action;
			return;
		}
		Debug.Log("CustomTrriger不包含这个事件类型" + type.ToString());
	}

	public void ClearListener(EventTriggerType type)
	{
		switch (type)
		{
		case EventTriggerType.PointerEnter:
			this.OnPointerEnterEvent = null;
			return;
		case EventTriggerType.PointerExit:
			this.OnPointerExitEvent = null;
			return;
		case EventTriggerType.PointerDown:
			this.OnPointerDownEvent = null;
			return;
		case EventTriggerType.PointerClick:
			this.OnPointerClickEvent = null;
			return;
		case EventTriggerType.Drag:
			this.OnPointerDragEvent = null;
			return;
		case EventTriggerType.Drop:
			this.OnPointerDropEvent = null;
			return;
		case EventTriggerType.BeginDrag:
			this.OnPointerBeginDragEvent = null;
			return;
		case EventTriggerType.EndDrag:
			this.OnPointerEndDragEvent = null;
			return;
		}
		Debug.Log("CustomTrriger不包含这个事件类型" + type.ToString());
	}

	public void ClearListener()
	{
		this.OnPointerClickEvent = null;
		this.OnPointerEnterEvent = null;
		this.OnPointerExitEvent = null;
		this.OnPointerDownEvent = null;
		this.OnPointerBeginDragEvent = null;
		this.OnPointerDragEvent = null;
		this.OnPointerEndDragEvent = null;
		this.OnPointerDropEvent = null;
	}

	public delegate void TriggerAction(PointerEventData eventData);
}
