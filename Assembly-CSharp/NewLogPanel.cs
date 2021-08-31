using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewLogPanel : MonoBehaviour
{
	public void InitPanel(string fileName)
	{
		this.LogInfoText.SetActive(false);
		this.ClearContent();
		this.BossImage.sprite = ImageTools.ReadImage(fileName);
		LogData logData = GlobalController.Instance.LogDataController.LoadAdvanceDataInfo(fileName + ".log");
		for (int i = 0; i < logData.Content.Count; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LogInfoText, this.LogInfoText.transform.parent);
			gameObject.SetActive(true);
			string text = logData.Content[i].ToString();
			gameObject.transform.GetComponent<TMP_Text>().text = text;
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

	private void ClearContent()
	{
		for (int i = 1; i < this.ContentPanel.childCount; i++)
		{
			UnityEngine.Object.Destroy(this.ContentPanel.GetChild(i).gameObject);
		}
	}

	public GameObject LogInfoText;

	public Scrollbar scroll;

	public Transform ContentPanel;

	public Image BossImage;
}
