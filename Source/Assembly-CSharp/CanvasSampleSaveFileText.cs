using System;
using System.IO;
using SFB;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CanvasSampleSaveFileText : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public void OnPointerDown(PointerEventData eventData)
	{
	}

	private void Start()
	{
		base.GetComponent<Button>().onClick.AddListener(new UnityAction(this.OnClick));
	}

	public void OnClick()
	{
		string text = StandaloneFileBrowser.SaveFilePanel("Title", "", "sample", "txt");
		if (!string.IsNullOrEmpty(text))
		{
			File.WriteAllText(text, this._data);
		}
	}

	public Text output;

	private string _data = "Example text created by StandaloneFileBrowser";
}
