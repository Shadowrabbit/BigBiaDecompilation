using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicUpdateContent : MonoBehaviour
{
	public void OnClick()
	{
		if (!this.m_IsClicked)
		{
			if (!this.LogicUpdateController.IsContainsLogic(this))
			{
				this.CheckImage.color = new Color(this.CheckImage.color.r, this.CheckImage.color.g, this.CheckImage.color.b, 1f);
				this.LogicUpdateController.CheckCurrentLogicCountAndAddLogic(this);
				this.m_IsClicked = true;
			}
		}
		else
		{
			this.LogicUpdateController.RemoveContent(this);
			this.CheckImage.color = new Color(this.CheckImage.color.r, this.CheckImage.color.g, this.CheckImage.color.b, 0f);
			this.m_IsClicked = false;
		}
		base.transform.GetComponent<Button>().interactable = false;
		base.transform.GetComponent<Button>().interactable = true;
	}

	public void OnHighlight()
	{
		this.CheckImage.color = new Color(this.CheckImage.color.r, this.CheckImage.color.g, this.CheckImage.color.b, 1f);
	}

	public void HideHighlight()
	{
		if (!this.LogicUpdateController.IsContainsLogic(this))
		{
			this.CheckImage.color = new Color(this.CheckImage.color.r, this.CheckImage.color.g, this.CheckImage.color.b, 0f);
		}
	}

	public void InitLogicContent()
	{
		this.CheckImage.color = new Color(this.CheckImage.color.r, this.CheckImage.color.g, this.CheckImage.color.b, 0f);
		this.BgImage.color = GameController.RowColor[(int)this.LogicData.Color];
		this.LogicNameText.text = this.LogicData.displayName + " " + this.LogicData.Layers.ToString();
		this.LogicDescText.text = this.LogicData.Desc;
	}

	public Image CheckImage;

	public Image BgImage;

	public LogicUpdateController LogicUpdateController;

	public TMP_Text LogicNameText;

	public TMP_Text LogicDescText;

	public CardLogic LogicData;

	public bool m_IsClicked;
}
