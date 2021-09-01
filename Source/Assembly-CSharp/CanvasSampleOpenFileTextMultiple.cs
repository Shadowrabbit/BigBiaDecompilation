using System;
using System.Collections;
using System.Collections.Generic;
using SFB;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CanvasSampleOpenFileTextMultiple : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public void OnPointerDown(PointerEventData eventData)
	{
	}

	private void Start()
	{
		base.GetComponent<Button>().onClick.AddListener(new UnityAction(this.OnClick));
	}

	private void OnClick()
	{
		string[] array = StandaloneFileBrowser.OpenFilePanel("Open File", "", "", true);
		if (array.Length != 0)
		{
			List<string> list = new List<string>(array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(new Uri(array[i]).AbsoluteUri);
			}
			base.StartCoroutine(this.OutputRoutine(list.ToArray()));
		}
	}

	private IEnumerator OutputRoutine(string[] urlArr)
	{
		string outputText = "";
		int num;
		for (int i = 0; i < urlArr.Length; i = num + 1)
		{
			WWW loader = new WWW(urlArr[i]);
			yield return loader;
			outputText += loader.text;
			loader = null;
			num = i;
		}
		this.output.text = outputText;
		yield break;
	}

	public Text output;
}
