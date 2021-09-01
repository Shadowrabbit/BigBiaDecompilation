using System;
using UnityEngine;

public abstract class UIControlBase : MonoBehaviour
{
	public virtual void Awake()
	{
		this.canvas = base.GetComponent<Canvas>();
	}

	public virtual void Init(object[] obj = null)
	{
	}

	public virtual void Update()
	{
	}

	[HideInInspector]
	public Canvas canvas;

	[HideInInspector]
	public int MakeType;

	public SortingLayerEnum SortingLayer = SortingLayerEnum.MainUI;

	public UIControlBase.RenderMode mode;

	public enum RenderMode
	{
		ScreenSpace,
		World
	}
}
