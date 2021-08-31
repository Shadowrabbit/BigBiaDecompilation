using System;
using System.IO;
using SFB;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CanvasSampleSaveFileImage : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	private void Awake()
	{
		int num = 100;
		int num2 = 100;
		Texture2D texture2D = new Texture2D(num, num2, TextureFormat.RGB24, false);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				texture2D.SetPixel(i, j, Color.red);
			}
		}
		texture2D.Apply();
		this._textureBytes = texture2D.EncodeToPNG();
		UnityEngine.Object.Destroy(texture2D);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	private void Start()
	{
		base.GetComponent<Button>().onClick.AddListener(new UnityAction(this.OnClick));
	}

	public void OnClick()
	{
		string text = StandaloneFileBrowser.SaveFilePanel("Title", "", "sample", "png");
		if (!string.IsNullOrEmpty(text))
		{
			File.WriteAllBytes(text, this._textureBytes);
		}
	}

	public Text output;

	private byte[] _textureBytes;
}
