using System;
using System.Collections;
using SFB;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CanvasSampleOpenFileImage : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
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
		string[] array = StandaloneFileBrowser.OpenFilePanel("Title", "", ".png", false);
		if (array.Length != 0)
		{
			base.StartCoroutine(this.OutputRoutine(new Uri(array[0]).AbsoluteUri));
		}
	}

	private IEnumerator OutputRoutine(string url)
	{
		WWW loader = new WWW(url);
		yield return loader;
		this.output.texture = loader.texture;
		yield break;
	}

	public RawImage output;
}
