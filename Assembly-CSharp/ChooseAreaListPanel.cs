using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChooseAreaListPanel : UIControlBase
{
	private void Start()
	{
		this.closeButton.onClick.AddListener(new UnityAction(this.ClosePanel));
	}

	private new void Update()
	{
	}

	public override void Init(object[] obj = null)
	{
		if (this.areaUIList.Count > 0)
		{
			return;
		}
		List<AreaData> areas = GameController.getInstance().AreaDataModMap.Areas;
		if (areas != null && areas.Count > 0)
		{
			for (int i = 0; i < areas.Count; i++)
			{
				AreaDataDetailUI areaDataDetailUI = UnityEngine.Object.Instantiate<AreaDataDetailUI>(this.areaPrefab);
				this.areaUIList.Add(areaDataDetailUI);
				areaDataDetailUI.SetMessage(areas[i]);
				areaDataDetailUI.transform.SetParent(this.ScrollContent);
				areaDataDetailUI.GetComponent<RectTransform>().localScale = Vector3.one;
			}
		}
	}

	public void ClosePanel()
	{
		GameUIController.Instance.CloseUI<ChooseAreaScreen>();
	}

	public List<AreaDataDetailUI> areaUIList;

	public RectTransform ScrollContent;

	public AreaDataDetailUI areaPrefab;

	public Button closeButton;
}
