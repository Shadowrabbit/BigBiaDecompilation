using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentAreaAttrPanel : MonoBehaviour
{
	private void Start()
	{
	}

	public void OnPanelShow(Card tar)
	{
		Dictionary<string, object> attrs = tar.CardData.Attrs;
		if (attrs.Count < 1)
		{
			return;
		}
		this.AttrText.SetActive(false);
		foreach (KeyValuePair<string, object> keyValuePair in attrs)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AttrText);
			gameObject.transform.SetParent(this.AttrText.transform.parent);
			Text component = gameObject.GetComponent<Text>();
			string key = keyValuePair.Key;
			string str = "     ";
			object value = keyValuePair.Value;
			component.text = key + str + ((value != null) ? value.ToString() : null);
			gameObject.SetActive(true);
		}
		this.AttrPanel.SetActive(true);
		this.CloseBtn.SetActive(true);
	}

	public void OnPanelShow(string ID)
	{
		Dictionary<string, object> attrs = GameController.getInstance().CardDataModMap.getCardDataByModID(ID).Attrs;
		if (attrs.Count < 1)
		{
			return;
		}
		this.AttrText.SetActive(false);
		foreach (KeyValuePair<string, object> keyValuePair in attrs)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AttrText);
			gameObject.transform.SetParent(this.AttrText.transform.parent);
			Text component = gameObject.GetComponent<Text>();
			string key = keyValuePair.Key;
			string str = "     ";
			object value = keyValuePair.Value;
			component.text = key + str + ((value != null) ? value.ToString() : null);
			gameObject.SetActive(true);
		}
		this.AttrPanel.SetActive(true);
		this.CloseBtn.SetActive(true);
	}

	public void OnPanelClose()
	{
		this.AttrPanel.SetActive(false);
		this.CloseBtn.gameObject.SetActive(false);
	}

	public void OnPanelShow()
	{
		Dictionary<string, object> attrs = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData.Attrs;
		if (attrs.Count < 1)
		{
			return;
		}
		this.AttrText.SetActive(false);
		foreach (KeyValuePair<string, object> keyValuePair in attrs)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AttrText);
			gameObject.transform.SetParent(this.AttrText.transform.parent);
			Text component = gameObject.GetComponent<Text>();
			string key = keyValuePair.Key;
			string str = "     ";
			object value = keyValuePair.Value;
			component.text = key + str + ((value != null) ? value.ToString() : null);
			gameObject.SetActive(true);
		}
		this.AttrPanel.SetActive(true);
		this.CloseBtn.SetActive(true);
	}

	public GameObject AttrPanel;

	public GameObject ShowBtn;

	public GameObject CloseBtn;

	public GameObject AttrText;
}
