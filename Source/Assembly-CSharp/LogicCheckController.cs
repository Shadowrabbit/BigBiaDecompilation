using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicCheckController : MonoBehaviour
{
	private void InitPanel()
	{
		this.m_LogicCount = 0;
		this.m_DeleteLogicContents = new List<LogicCheckContent>();
		this.m_InstantiateObjs = new List<GameObject>();
		foreach (CardLogic cardLogic in this.m_Data.CardLogics)
		{
			if (!(cardLogic is MinionLogic) && !(cardLogic is PersonCardLogic) && !(cardLogic is FaithCardLogic))
			{
				cardLogic.OnShowTips();
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ShowLogicContent);
				gameObject.transform.SetParent(this.ShowLogicContent.transform.parent);
				LogicCheckContent componentInChildren = gameObject.transform.GetComponentInChildren<LogicCheckContent>();
				componentInChildren.LogicData = cardLogic;
				componentInChildren.InitLogicContent();
				gameObject.SetActive(true);
				this.m_InstantiateObjs.Add(gameObject);
				this.m_LogicCount++;
			}
		}
	}

	public void CheckCurrentLogicCountAndAddLogic(LogicCheckContent content)
	{
		this.m_DeleteLogicContents.Add(content);
		while (this.m_LogicCount - this.m_DeleteLogicContents.Count < this.m_SaveCount)
		{
			GameController.ins.CreateSubtitle("当前删除词条超出上限，删除原有选项！", 1f, 2f, 1f, 1f);
			this.m_DeleteLogicContents[0].CheckImage.color = new Color(this.m_DeleteLogicContents[0].CheckImage.color.r, this.m_DeleteLogicContents[0].CheckImage.color.g, this.m_DeleteLogicContents[0].CheckImage.color.b, 0f);
			this.m_DeleteLogicContents[0].m_IsClicked = false;
			this.m_DeleteLogicContents[0].transform.GetComponent<Button>().interactable = false;
			this.m_DeleteLogicContents[0].transform.GetComponent<Button>().interactable = true;
			this.m_DeleteLogicContents.RemoveAt(0);
		}
	}

	public bool IsContainsLogic(LogicCheckContent content)
	{
		return this.m_DeleteLogicContents.Contains(content);
	}

	public void RemoveContent(LogicCheckContent content)
	{
		this.m_DeleteLogicContents.Remove(content);
	}

	public void CheckOver()
	{
		if (this.m_LogicCount - this.m_DeleteLogicContents.Count < this.m_SaveCount)
		{
			GameController.ins.CreateSubtitle("必须保留 " + this.m_SaveCount.ToString() + " 个词条！", 1f, 2f, 1f, 1f);
			return;
		}
		if (this.m_LogicCount - this.m_DeleteLogicContents.Count > this.m_SaveCount)
		{
			GameController.ins.CreateSubtitle("当前保留词条过多！", 1f, 2f, 1f, 1f);
			return;
		}
		for (int i = this.m_DeleteLogicContents.Count - 1; i >= 0; i--)
		{
			this.m_Data.RemoveCardLogic(this.m_DeleteLogicContents[i].LogicData);
		}
		this.ClosePanel();
	}

	public void OpenPanel(CardData data)
	{
		UIController.LockLevel = UIController.UILevel.All;
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

	private List<LogicCheckContent> m_DeleteLogicContents = new List<LogicCheckContent>();

	private List<GameObject> m_InstantiateObjs;

	private int m_LogicCount;

	private int m_SaveCount = 5;
}
