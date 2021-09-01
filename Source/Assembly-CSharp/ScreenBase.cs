using System;
using UnityEngine;

public abstract class ScreenBase
{
	public GameUIController GameUIController
	{
		get
		{
			return GameUIController.Instance;
		}
	}

	public ScreenBase(string panelName)
	{
		this.panelName = panelName;
	}

	public virtual void StartLoad(string panelName)
	{
		ResourceManager.Instance.LoadResource(panelName, new Action<object>(this.OnLoadComplete));
	}

	public virtual void OnLoadComplete(object asset)
	{
		this.uiControlPanel = UnityEngine.Object.Instantiate<GameObject>((GameObject)asset);
		this.uiControlPanel.SetActive(true);
		this.uIControlBase = this.uiControlPanel.GetComponent<UIControlBase>();
		this.uIControlBase.MakeType = this.MakeType;
		this.UpdateLayerLevel();
		this.uIControlBase.Init(this.objects);
		GameUIController.Instance.AttachUI(this, asset);
	}

	public virtual void OnOpen()
	{
	}

	public void UpdateLayerLevel()
	{
		if (this.uIControlBase.mode == UIControlBase.RenderMode.ScreenSpace)
		{
			Camera uicamera = GameUIController.Instance.UICamera;
			if (uicamera != null)
			{
				this.uIControlBase.canvas.worldCamera = uicamera;
			}
		}
		this.uIControlBase.canvas.pixelPerfect = true;
		this.uIControlBase.canvas.overrideSorting = true;
		this.uIControlBase.canvas.sortingLayerID = (int)this.uIControlBase.SortingLayer;
		this.sortingLayer = (int)this.uIControlBase.SortingLayer;
		this.uIControlBase.canvas.sortingOrder = this.openOrder;
	}

	public virtual void OnClose()
	{
		this.uIControlBase.canvas.enabled = false;
	}

	public virtual void Dispose()
	{
		UnityEngine.Object.Destroy(this.uiControlPanel);
	}

	public void SetUILockLevel()
	{
		UIController.LockLevel = (UIController.UILevel)2147483639;
	}

	public UIControlBase uIControlBase;

	public GameObject uiControlPanel;

	public int openOrder;

	public int sortingLayer;

	public string panelName;

	public int MakeType;

	public object[] objects;
}
