using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicUpdateController : MonoBehaviour
{
	private void InitPanel()
	{
		this.m_UpdateLogicContents = new List<LogicUpdateContent>();
		this.m_InstantiateObjs = new List<GameObject>();
		foreach (CardLogic cardLogic in this.m_Data.CardLogics)
		{
			if (!(cardLogic is MinionLogic) && !(cardLogic is PersonCardLogic) && cardLogic.Layers > 0)
			{
				cardLogic.OnShowTips();
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ShowLogicContent);
				gameObject.transform.SetParent(this.ShowLogicContent.transform.parent);
				LogicUpdateContent componentInChildren = gameObject.transform.GetComponentInChildren<LogicUpdateContent>();
				componentInChildren.LogicData = cardLogic;
				componentInChildren.InitLogicContent();
				gameObject.SetActive(true);
				this.m_InstantiateObjs.Add(gameObject);
			}
		}
	}

	public void CheckCurrentLogicCountAndAddLogic(LogicUpdateContent content)
	{
		this.m_UpdateLogicContents.Add(content);
		while (this.m_UpdateLogicContents.Count > this.m_LogicCount)
		{
			this.m_UpdateLogicContents[0].CheckImage.color = new Color(this.m_UpdateLogicContents[0].CheckImage.color.r, this.m_UpdateLogicContents[0].CheckImage.color.g, this.m_UpdateLogicContents[0].CheckImage.color.b, 0f);
			this.m_UpdateLogicContents[0].m_IsClicked = false;
			this.m_UpdateLogicContents[0].transform.GetComponent<Button>().interactable = false;
			this.m_UpdateLogicContents[0].transform.GetComponent<Button>().interactable = true;
			this.m_UpdateLogicContents.RemoveAt(0);
		}
	}

	public bool IsContainsLogic(LogicUpdateContent content)
	{
		return this.m_UpdateLogicContents.Contains(content);
	}

	public void RemoveContent(LogicUpdateContent content)
	{
		this.m_UpdateLogicContents.Remove(content);
	}

	public void CheckOver()
	{
		if (this.m_UpdateLogicContents.Count > this.m_LogicCount)
		{
			GameController.ins.CreateSubtitle("只能升级" + this.m_LogicCount.ToString() + "个词条！", 1f, 2f, 1f, 1f);
			return;
		}
		for (int i = this.m_UpdateLogicContents.Count - 1; i >= 0; i--)
		{
			this.m_UpdateLogicContents[i].LogicData.Layers += this.m_Layers;
		}
		this.ClosePanel();
	}

	public void OpenPanel(CardData data, int count = 1, int layers = 1)
	{
		UIController.LockLevel = UIController.UILevel.All;
		this.m_LogicCount = count;
		this.m_Layers = layers;
		this.m_Data = data;
		this.InitPanel();
		base.gameObject.SetActive(true);
	}

	private void ClosePanel()
	{
		for (int i = this.m_InstantiateObjs.Count - 1; i >= 0; i--)
		{
			UnityEngine.Object.Destroy(this.m_InstantiateObjs[i]);
		}
		base.gameObject.SetActive(false);
		UIController.LockLevel = UIController.UILevel.None;
	}

	public GameObject ShowLogicContent;

	private CardData m_Data;

	private List<LogicUpdateContent> m_UpdateLogicContents = new List<LogicUpdateContent>();

	private List<GameObject> m_InstantiateObjs;

	private int m_LogicCount;

	private int m_Layers;
}
