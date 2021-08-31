using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class CommentController : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	public void QueryComment(int number, int type, Action<List<UserComment>> callBack)
	{
		base.StartCoroutine(this.InternalQueryAll(number, type, callBack));
	}

	public void InsertComment(UserComment comment)
	{
		base.StartCoroutine(this.InternalInsertComment(comment));
	}

	private IEnumerator InternalInsertComment(UserComment comment)
	{
		WWWForm wwwform = new WWWForm();
		wwwform.AddField("comment", JsonConvert.SerializeObject(comment));
		UnityWebRequest request = UnityWebRequest.Post(OACCController.URL + "magzineAction_insertComment", wwwform);
		yield return request.SendWebRequest();
		Debug.Log(request.responseCode);
		if (request.isHttpError || request.isNetworkError)
		{
			Debug.Log(request.error);
		}
		else if (JsonConvert.DeserializeObject<List<UserComment>>(request.downloadHandler.text) == null)
		{
			new List<UserComment>();
		}
		yield break;
	}

	private IEnumerator InternalQueryAll(int number, int type, Action<List<UserComment>> callBack)
	{
		WWWForm wwwform = new WWWForm();
		wwwform.AddField("number", number);
		wwwform.AddField("type", type);
		UnityWebRequest request = UnityWebRequest.Post(OACCController.URL + "magzineAction_queryComment", wwwform);
		yield return request.SendWebRequest();
		if (request.isHttpError || request.isNetworkError)
		{
			Debug.Log(request.error);
		}
		else
		{
			string text = request.downloadHandler.text;
			Debug.Log(text);
			List<UserComment> list = JsonConvert.DeserializeObject<List<UserComment>>(text);
			if (list == null)
			{
				list = new List<UserComment>();
			}
			if (callBack != null)
			{
				callBack(list);
			}
		}
		yield break;
	}
}
