using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class TestUpdate : MonoBehaviour
{
	private void Start()
	{
		base.StartCoroutine(this.queryAll());
		for (int i = 0; i < 300000; i++)
		{
			new CardData();
		}
		this.WriteCode();
	}

	private void Update()
	{
	}

	private void WriteCode()
	{
		string path = Environment.CurrentDirectory + "/Assets/Scripts/Act";
		string text = Application.persistentDataPath + "/1.txt";
		Debug.Log(text);
		if (!File.Exists(text))
		{
			File.Create(text);
		}
		using (FileStream fileStream = new FileStream(text, FileMode.Append))
		{
			using (StreamWriter streamWriter = new StreamWriter(fileStream))
			{
				string[] files = Directory.GetFiles(path);
				int num = 0;
				foreach (string text2 in files)
				{
					if (!text2.Contains("meta"))
					{
						using (FileStream fileStream2 = new FileStream(text2, FileMode.Open))
						{
							using (StreamReader streamReader = new StreamReader(fileStream2))
							{
								while (!streamReader.EndOfStream)
								{
									string text3 = streamReader.ReadLine();
									if (!string.IsNullOrEmpty(text3.Trim()) && !text3.Contains("//"))
									{
										num++;
										streamWriter.WriteLine(text3);
									}
								}
							}
						}
					}
				}
				Debug.Log(num);
			}
		}
	}

	private IEnumerator Upload()
	{
		WWWForm wwwform = new WWWForm();
		wwwform.AddField("guid", "123");
		wwwform.AddField("snapshot", "2");
		wwwform.AddField("pixelContent", "3");
		wwwform.AddField("cardModel", "4");
		wwwform.AddField("cardMessage", "");
		wwwform.AddField("steamID", SteamConstant.GetUserID().ToString());
		wwwform.AddField("status", "true");
		string uri = "http://59.110.49.146/PixelMatch/pixelAction_upload";
		using (UnityWebRequest request = UnityWebRequest.Post(uri, wwwform))
		{
			yield return request.SendWebRequest();
			if (request.isNetworkError || request.isHttpError)
			{
				Debug.Log(request.error);
			}
			else
			{
				Debug.Log(request.downloadHandler.text);
			}
		}
		UnityWebRequest request = null;
		yield break;
		yield break;
	}

	private IEnumerator query()
	{
		WWWForm wwwform = new WWWForm();
		wwwform.AddField("status", "true");
		wwwform.AddField("guid", "123");
		string uri = "http://59.110.49.146/PixelMatch/pixelAction_queryItem";
		using (UnityWebRequest request = UnityWebRequest.Post(uri, wwwform))
		{
			yield return request.SendWebRequest();
			if (request.isNetworkError || request.isHttpError)
			{
				Debug.Log(request.error);
			}
			else
			{
				Debug.Log(request.downloadHandler.text);
			}
		}
		UnityWebRequest request = null;
		yield break;
		yield break;
	}

	private IEnumerator queryAll()
	{
		WWWForm wwwform = new WWWForm();
		wwwform.AddField("status", "false");
		wwwform.AddField("steamID", "2435345");
		string uri = "http://59.110.49.146/PixelMatch/pixelAction_queryAll";
		using (UnityWebRequest request = UnityWebRequest.Post(uri, wwwform))
		{
			yield return request.SendWebRequest();
			if (request.isNetworkError || request.isHttpError)
			{
				Debug.Log(request.error);
			}
			else
			{
				Debug.Log(request.downloadHandler.text);
				foreach (MatchItem matchItem in JsonConvert.DeserializeObject<List<MatchItem>>(request.downloadHandler.text))
				{
					Debug.Log(matchItem.steamID);
				}
			}
		}
		UnityWebRequest request = null;
		yield break;
		yield break;
	}

	private IEnumerator vote()
	{
		WWWForm wwwform = new WWWForm();
		wwwform.AddField("status", "true");
		wwwform.AddField("steamid", "123456");
		wwwform.AddField("id", "6");
		wwwform.AddField("vote", "1");
		wwwform.AddField("guid", "123");
		string uri = "http://59.110.49.146/PixelMatch/pixelAction_voteItem";
		using (UnityWebRequest request = UnityWebRequest.Post(uri, wwwform))
		{
			yield return request.SendWebRequest();
			if (request.isNetworkError || request.isHttpError)
			{
				Debug.Log(request.error);
			}
			else
			{
				Debug.Log(request.downloadHandler.text);
			}
		}
		UnityWebRequest request = null;
		yield break;
		yield break;
	}

	private IEnumerator queryItemVote()
	{
		WWWForm wwwform = new WWWForm();
		wwwform.AddField("status", "true");
		wwwform.AddField("steamid", "123456");
		wwwform.AddField("id", "6");
		string uri = "http://59.110.49.146/PixelMatch/pixelAction_queryItemVote";
		using (UnityWebRequest request = UnityWebRequest.Post(uri, wwwform))
		{
			yield return request.SendWebRequest();
			if (request.isNetworkError || request.isHttpError)
			{
				Debug.Log(request.error);
			}
			else
			{
				Debug.Log(request.downloadHandler.text);
			}
		}
		UnityWebRequest request = null;
		yield break;
		yield break;
	}

	public GameObject prefab;
}
