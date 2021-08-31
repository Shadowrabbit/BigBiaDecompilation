using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogPanel : MonoBehaviour
{
	private void Start()
	{
		this.LogCountText.text = (this.logCount.ToString() ?? "");
		GameController.getInstance().GameEventManager.OnLogUpdateEvent += this.OnLogUpdate;
		this.EmptyTipText.gameObject.SetActive(false);
	}

	public void InitPanel(string userName)
	{
		this.LogInfoText.SetActive(false);
		int num = 0;
		ArrayList arrayList = LoggerWriter.Instance.LoadLog();
		for (int i = 0; i < arrayList.Count; i++)
		{
			LogBean logBean = (LogBean)arrayList[i];
			if (userName.Equals(logBean.CurName) || userName.Equals(logBean.TarName) || userName.Equals("全体成员") || userName.Equals(""))
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LogInfoText, this.LogInfoText.transform.parent);
				gameObject.SetActive(true);
				string text = this.GetContentText(logBean).Contains("/World/") ? this.GetContentText(logBean).Replace("/World/", "") : this.GetContentText(logBean);
				text = (text.Contains("/") ? text.Replace("/", "的") : text);
				gameObject.transform.GetComponent<TMP_Text>().text = (text.Contains("<的") ? text.Replace("<的", "</") : text);
				num++;
			}
		}
		if (num == 0)
		{
			this.EmptyTipText.text = "尚未拥有交互信息！";
		}
		this.scroll.value = 0f;
	}

	public void InitPanel()
	{
		this.UserNameText.text = "发生的事";
		this.LogInfoText.SetActive(false);
		ArrayList arrayList = LoggerWriter.Instance.LoadLog();
		for (int i = 0; i < arrayList.Count; i++)
		{
			LogBean log = (LogBean)arrayList[i];
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LogInfoText, this.LogInfoText.transform.parent);
			gameObject.SetActive(true);
			string text = this.GetContentText(log).Contains("/World/") ? this.GetContentText(log).Replace("/World/", "") : this.GetContentText(log);
			text = (text.Contains("/") ? text.Replace("/", "的") : text);
			gameObject.transform.GetComponent<TMP_Text>().text = (text.Contains("<的") ? text.Replace("<的", "</") : text);
		}
		if (arrayList.Count == 0)
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

	private void OnLogUpdate(LogBean log)
	{
		this.logCount++;
		this.LogCountText.text = (this.logCount.ToString() ?? "");
		if (this.m_isShow)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LogInfoText, this.LogInfoText.transform.parent);
			gameObject.SetActive(true);
			gameObject.transform.GetComponent<TMP_Text>().text = this.GetContentText(log);
			this.EmptyTipText.text = "";
			this.scroll.value = 0f;
		}
	}

	private void OnDestroy()
	{
		GameController.getInstance().GameEventManager.OnLogUpdateEvent -= this.OnLogUpdate;
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

	public TMP_Text EmptyTipText;

	public Transform ContentPanel;

	public GameObject LogBtn;

	public TMP_Text LogCountText;

	private int logCount;

	private bool m_isShow;

	public TestSub m_test;
}
