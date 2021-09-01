using System;
using System.Collections;
using SFB;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PreViewFile : MonoBehaviour
{
	public string Path
	{
		get
		{
			return this.m_PreViewFilePath;
		}
	}

	private void Start()
	{
		this.button.onClick.AddListener(new UnityAction(this.OnButtonClick));
	}

	private void Update()
	{
	}

	private void OnButtonClick()
	{
		string[] array = StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false);
		if (array != null && array.Length != 0)
		{
			string text = array[0];
			if (text.ToLower().Contains("jpg") || text.ToLower().Contains("png"))
			{
				this.m_PreViewFilePath = text;
				base.StartCoroutine(this.LoadImage(text));
			}
		}
	}

	private IEnumerator LoadImage(string path)
	{
		yield return null;
		using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(path))
		{
			yield return uwr.SendWebRequest();
			if (uwr.isNetworkError || uwr.isHttpError)
			{
				Debug.Log(uwr.error);
			}
			else
			{
				Texture2D content = DownloadHandlerTexture.GetContent(uwr);
				this.image.texture = content;
			}
		}
		UnityWebRequest uwr = null;
		yield break;
		yield break;
	}

	public RawImage image;

	public Button button;

	private string m_PreViewFilePath;
}
