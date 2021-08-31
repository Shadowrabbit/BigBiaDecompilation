using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AreaDataDetailUI : MonoBehaviour
{
	private GameController GameController
	{
		get
		{
			return GameController.getInstance();
		}
	}

	private void Start()
	{
		this.button.onClick.AddListener(new UnityAction(this.ChooseArea));
	}

	public void SetMessage(AreaData data)
	{
		this.m_AreaData = data;
		this.title.text = data.Name;
		this.price.text = data.MaxLevel.ToString();
	}

	private void ChooseArea()
	{
		if (!this.CheckCondition())
		{
			return;
		}
		new ChangeCurrentArea().InitArea(this.m_AreaData.ModID);
		GameUIController.Instance.CloseUI<ChooseAreaScreen>();
	}

	private bool CheckCondition()
	{
		return true;
	}

	public TextMeshProUGUI title;

	public TextMeshProUGUI price;

	public Button button;

	private AreaData m_AreaData;
}
