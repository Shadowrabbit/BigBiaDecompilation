using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerListener : EventTrigger
{
	public static EventTriggerListener Get(GameObject go)
	{
		EventTriggerListener eventTriggerListener = go.GetComponent<EventTriggerListener>();
		if (eventTriggerListener == null)
		{
			eventTriggerListener = go.AddComponent<EventTriggerListener>();
		}
		return eventTriggerListener;
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (this.onClick != null)
		{
			this.onClick(base.gameObject);
		}
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		if (this.onDown != null)
		{
			this.onDown(base.gameObject);
		}
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		if (this.onEnter != null)
		{
			this.onEnter(base.gameObject);
		}
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		if (this.onExit != null)
		{
			this.onExit(base.gameObject);
		}
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		if (this.onUp != null)
		{
			this.onUp(base.gameObject);
		}
	}

	public override void OnSelect(BaseEventData eventData)
	{
		if (this.onSelect != null)
		{
			this.onSelect(base.gameObject);
		}
	}

	public override void OnUpdateSelected(BaseEventData eventData)
	{
		if (this.onUpdateSelect != null)
		{
			this.onUpdateSelect(base.gameObject);
		}
	}

	public override void OnDrag(PointerEventData eventData)
	{
		if (this.onDrag != null)
		{
			this.onDrag(base.gameObject);
		}
	}

	public override void OnEndDrag(PointerEventData eventData)
	{
		if (this.onEndDrag != null)
		{
			this.onEndDrag(base.gameObject);
		}
	}

	public override void OnBeginDrag(PointerEventData eventData)
	{
		EventTriggerListener.VoidDelegate voidDelegate = this.onBeginDrag;
		if (voidDelegate == null)
		{
			return;
		}
		voidDelegate(base.gameObject);
	}

	public EventTriggerListener.VoidDelegate onClick;

	public EventTriggerListener.VoidDelegate onDown;

	public EventTriggerListener.VoidDelegate onEnter;

	public EventTriggerListener.VoidDelegate onExit;

	public EventTriggerListener.VoidDelegate onUp;

	public EventTriggerListener.VoidDelegate onSelect;

	public EventTriggerListener.VoidDelegate onUpdateSelect;

	public EventTriggerListener.VoidDelegate onDrag;

	public EventTriggerListener.VoidDelegate onEndDrag;

	public EventTriggerListener.VoidDelegate onBeginDrag;

	public delegate void VoidDelegate(GameObject go);
}
