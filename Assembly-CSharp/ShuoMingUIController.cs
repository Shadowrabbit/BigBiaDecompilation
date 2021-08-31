using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShuoMingUIController : MonoBehaviour
{
	public void OnShowZhuJieMian()
	{
		UnityEngine.Object.DestroyImmediate(this.Content.gameObject);
		RectTransform rectTransform = UnityEngine.Object.Instantiate<RectTransform>(Resources.Load<RectTransform>("Textures/新教程/基本界面"));
		rectTransform.SetParent(this.ViewPort, false);
		this.Content = rectTransform;
		this.ScrollView.content = this.Content;
	}

	public void OnShowXiaoDiTu()
	{
		UnityEngine.Object.DestroyImmediate(this.Content.gameObject);
		RectTransform rectTransform = UnityEngine.Object.Instantiate<RectTransform>(Resources.Load<RectTransform>("Textures/新教程/小地图"));
		rectTransform.SetParent(this.ViewPort, false);
		this.Content = rectTransform;
		this.ScrollView.content = this.Content;
	}

	public void OnShowDanWei()
	{
		UnityEngine.Object.DestroyImmediate(this.Content.gameObject);
		RectTransform rectTransform = UnityEngine.Object.Instantiate<RectTransform>(Resources.Load<RectTransform>("Textures/新教程/单位"));
		rectTransform.SetParent(this.ViewPort, false);
		this.Content = rectTransform;
		this.ScrollView.content = this.Content;
	}

	public void OnShowZhanDou()
	{
		UnityEngine.Object.DestroyImmediate(this.Content.gameObject);
		RectTransform rectTransform = UnityEngine.Object.Instantiate<RectTransform>(Resources.Load<RectTransform>("Textures/新教程/战斗"));
		rectTransform.SetParent(this.ViewPort, false);
		this.Content = rectTransform;
		this.ScrollView.content = this.Content;
	}

	public void OnShowZhuDongJiNeng()
	{
		UnityEngine.Object.DestroyImmediate(this.Content.gameObject);
		RectTransform rectTransform = UnityEngine.Object.Instantiate<RectTransform>(Resources.Load<RectTransform>("Textures/新教程/主动技能"));
		rectTransform.SetParent(this.ViewPort, false);
		this.Content = rectTransform;
		this.ScrollView.content = this.Content;
	}

	public void OnShowHeCheng()
	{
		UnityEngine.Object.DestroyImmediate(this.Content.gameObject);
		RectTransform rectTransform = UnityEngine.Object.Instantiate<RectTransform>(Resources.Load<RectTransform>("Textures/新教程/合成"));
		rectTransform.SetParent(this.ViewPort, false);
		this.Content = rectTransform;
		this.ScrollView.content = this.Content;
	}

	public void OnShowDaoJu()
	{
		UnityEngine.Object.DestroyImmediate(this.Content.gameObject);
		RectTransform rectTransform = UnityEngine.Object.Instantiate<RectTransform>(Resources.Load<RectTransform>("Textures/新教程/工具药水"));
		rectTransform.SetParent(this.ViewPort, false);
		this.Content = rectTransform;
		this.ScrollView.content = this.Content;
	}

	public void Init()
	{
		UnityEngine.Object.DestroyImmediate(this.Content.gameObject);
		RectTransform rectTransform = UnityEngine.Object.Instantiate<RectTransform>(Resources.Load<RectTransform>("Textures/新教程/基本界面"));
		rectTransform.SetParent(this.ViewPort, false);
		this.Content = rectTransform;
		this.ScrollView.content = this.Content;
	}

	public RectTransform Content;

	public RectTransform ViewPort;

	public ScrollRect ScrollView;

	public List<Button> ShowPanels;
}
