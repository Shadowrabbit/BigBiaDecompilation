using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewLogPanelInGame : MonoBehaviour
{
	private void Start()
	{
		this.LogCountText.text = (this.logCount.ToString() ?? "");
		GameController.getInstance().GameEventManager.OnNewLogUpDate += this.OnLogUpdate;
	}

	public void InitPanel()
	{
		this.UserNameText.text = "发生的事";
		this.LogInfoText.SetActive(false);
		List<string> list = new List<string>();
		for (int i = 0; i < list.Count; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LogInfoText, this.LogInfoText.transform.parent);
			gameObject.SetActive(true);
			gameObject.transform.GetComponent<TMP_Text>().text = list[i];
		}
		if (list.Count == 0)
		{
			this.ClearContent();
		}
		this.scroll.value = 0f;
	}

	private string GetContentText(LogBean log)
	{
		switch (log.Type)
		{
		case 0:
			return string.Format(log.LogFormat, new object[]
			{
				log.Day,
				log.CurName,
				log.TarName,
				log.Count,
				log.ItemName,
				log.Coin
			});
		case 1:
			return string.Format(log.LogFormat, new object[]
			{
				log.Day,
				log.CurName,
				log.TarName,
				log.LogContent
			});
		case 2:
			return string.Format(log.LogFormat, new object[]
			{
				log.Day,
				log.CurName,
				log.TarName,
				log.LogContent
			});
		case 3:
			return string.Format(log.LogFormat, log.Day, log.CurName, log.LogContent);
		default:
			return null;
		}
	}

	public void OnPanelShow(GameObject go)
	{
		this.m_isShow = true;
		this.InitPanel();
		this.LogBtn.SetActive(false);
		this.logCount = 0;
		this.LogCountText.text = (this.logCount.ToString() ?? "");
		go.transform.DOScale(Vector3.one, 0.2f);
	}

	public void OnPanelClose(GameObject go)
	{
		this.m_isShow = false;
		this.logCount = 0;
		this.LogCountText.text = (this.logCount.ToString() ?? "");
		go.transform.DOScale(0f, 0.2f).OnComplete(delegate
		{
			this.LogBtn.SetActive(true);
			this.ClearContent();
		});
	}

	public void ShowLogBtn()
	{
		this.LogBtn.SetActive(true);
	}

	public void CloseLogBtn()
	{
		this.logCount = 0;
		this.LogCountText.text = (this.logCount.ToString() ?? "");
		base.gameObject.transform.DOScale(0f, 0.2f).OnComplete(delegate
		{
			this.LogBtn.SetActive(false);
			this.ClearContent();
		});
		GameController.ins.LogCtrl.ClearCurLog();
	}

	private void OnLogUpdate(string log)
	{
		this.logCount++;
		this.LogCountText.text = (this.logCount.ToString() ?? "");
		if (this.m_isShow)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LogInfoText, this.LogInfoText.transform.parent);
			gameObject.SetActive(true);
			gameObject.transform.GetComponent<TMP_Text>().text = log;
			this.scroll.value = 0f;
		}
	}

	private void OnDestroy()
	{
		GameController.getInstance().GameEventManager.OnNewLogUpDate -= this.OnLogUpdate;
	}

	private void ClearContent()
	{
		for (int i = 1; i < this.ContentPanel.childCount; i++)
		{
			UnityEngine.Object.Destroy(this.ContentPanel.GetChild(i).gameObject);
		}
	}

	private void Update()
	{
	}

	public TMP_Text UserNameText;

	public GameObject LogInfoText;

	public Scrollbar scroll;

	public Transform ContentPanel;

	public GameObject LogBtn;

	public TMP_Text LogCountText;

	private int logCount;

	private bool m_isShow;
}
