using System;
using System.Collections;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogPanel_Back : UIControlBase
{
	private void Start()
	{
		GameController.getInstance().GameEventManager.OnLogUpdateEvent += this.OnLogUpdate;
	}

	public void InitPanel(string userName)
	{
		this.realName = userName;
		this.UserNameText.text = (this.realName.Contains("/") ? this.realName.Split(new char[]
		{
			'/'
		})[this.realName.Split(new char[]
		{
			'/'
		}).Length - 1] : this.realName);
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
		this.UserNameText.text = "日志";
		this.LogInfoText.SetActive(false);
		int num = 0;
		ArrayList arrayList = LoggerWriter.Instance.LoadLog();
		for (int i = 0; i < arrayList.Count; i++)
		{
			LogBean log = (LogBean)arrayList[i];
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LogInfoText, this.LogInfoText.transform.parent);
			gameObject.SetActive(true);
			string text = this.GetContentText(log).Contains("/World/") ? this.GetContentText(log).Replace("/World/", "") : this.GetContentText(log);
			text = (text.Contains("/") ? text.Replace("/", "的") : text);
			gameObject.transform.GetComponent<TMP_Text>().text = (text.Contains("<的") ? text.Replace("<的", "</") : text);
			num++;
		}
		if (num == 0)
		{
			this.EmptyTipText.text = "尚未拥有交互信息！";
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

	public void OnPanelClose(GameObject go)
	{
		UnityEngine.Object.Destroy(go, 0f);
	}

	private void OnLogUpdate(LogBean log)
	{
		if (this.realName.Equals(log.CurName) || this.realName.Equals(log.TarName) || this.realName.Equals("全体成员") || this.realName.Equals("") || log.TarName.Equals("全体成员") || log.CurName.Equals("全体成员"))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LogInfoText, this.LogInfoText.transform.parent);
			gameObject.SetActive(true);
			gameObject.transform.GetComponent<TMP_Text>().text = this.GetContentText(log);
			this.EmptyTipText.text = "";
		}
		this.scroll.value = 0f;
	}

	private void OnDestroy()
	{
		GameController.getInstance().GameEventManager.OnLogUpdateEvent -= this.OnLogUpdate;
	}

	public override void Awake()
	{
		base.Awake();
	}

	public override void Init(object[] obj = null)
	{
		base.Init(obj);
		this.InitPanel(DialogueLua.GetVariable("CurrentCharacterID").asString);
	}

	public TMP_Text UserNameText;

	public GameObject LogInfoText;

	public Scrollbar scroll;

	public TMP_Text EmptyTipText;

	private string realName;
}
