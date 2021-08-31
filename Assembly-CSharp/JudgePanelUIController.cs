using System;
using System.Collections.Generic;
using UnityEngine;

public class JudgePanelUIController : MonoBehaviour
{
	public void InitJudgePanel(List<EventJudgeBean> contents)
	{
		this.m_CurrentContent = Vector3.zero;
		this.m_MissionPanels = new List<JudgeMissionPanel>();
		foreach (EventJudgeBean eventJudgeBean in contents)
		{
			JudgeMissionPanel judgeMissionPanel = UnityEngine.Object.Instantiate<JudgeMissionPanel>(this.MissionPanel);
			judgeMissionPanel.gameObject.SetActive(true);
			judgeMissionPanel.transform.SetParent(this.MissionPanel.transform.parent);
			judgeMissionPanel.YellowText.text = this.m_CurrentContent.x.ToString() + "/" + eventJudgeBean.MissionContent.x.ToString();
			judgeMissionPanel.RedText.text = this.m_CurrentContent.y.ToString() + "/" + eventJudgeBean.MissionContent.y.ToString();
			judgeMissionPanel.BlueText.text = this.m_CurrentContent.z.ToString() + "/" + eventJudgeBean.MissionContent.z.ToString();
			judgeMissionPanel.MissionText.text = eventJudgeBean.MissionTitleOrReward;
			judgeMissionPanel.MissionContent = eventJudgeBean.MissionContent;
			this.m_MissionPanels.Add(judgeMissionPanel);
		}
	}

	public void UpdateJudgePanel(Vector3 target)
	{
		this.m_CurrentContent += target;
		foreach (JudgeMissionPanel judgeMissionPanel in this.m_MissionPanels)
		{
			Vector3 currentContent = this.m_CurrentContent;
			if (currentContent.x >= judgeMissionPanel.MissionContent.x)
			{
				currentContent.x = judgeMissionPanel.MissionContent.x;
				judgeMissionPanel.YellowText.text = currentContent.x.ToString() + "/" + judgeMissionPanel.MissionContent.x.ToString();
			}
			else
			{
				judgeMissionPanel.YellowText.text = currentContent.x.ToString() + "/" + judgeMissionPanel.MissionContent.x.ToString();
			}
			if (currentContent.y >= judgeMissionPanel.MissionContent.y)
			{
				currentContent.y = judgeMissionPanel.MissionContent.y;
				judgeMissionPanel.RedText.text = currentContent.y.ToString() + "/" + judgeMissionPanel.MissionContent.y.ToString();
			}
			else
			{
				judgeMissionPanel.RedText.text = currentContent.y.ToString() + "/" + judgeMissionPanel.MissionContent.y.ToString();
			}
			if (currentContent.z >= judgeMissionPanel.MissionContent.z)
			{
				currentContent.z = judgeMissionPanel.MissionContent.z;
				judgeMissionPanel.BlueText.text = currentContent.z.ToString() + "/" + judgeMissionPanel.MissionContent.z.ToString();
			}
			else
			{
				judgeMissionPanel.BlueText.text = currentContent.z.ToString() + "/" + judgeMissionPanel.MissionContent.z.ToString();
			}
			if (currentContent.x >= judgeMissionPanel.MissionContent.x && currentContent.y >= judgeMissionPanel.MissionContent.y && currentContent.z >= judgeMissionPanel.MissionContent.z)
			{
				judgeMissionPanel.TipText.text = "达成";
			}
		}
	}

	public void CloseJudgePanel()
	{
		foreach (JudgeMissionPanel judgeMissionPanel in this.m_MissionPanels)
		{
			judgeMissionPanel.ClearPanel();
			UnityEngine.Object.Destroy(judgeMissionPanel.gameObject);
		}
		this.m_CurrentContent = Vector3.zero;
	}

	public JudgeMissionPanel MissionPanel;

	private List<JudgeMissionPanel> m_MissionPanels;

	private Vector3 m_CurrentContent = Vector3.zero;
}
