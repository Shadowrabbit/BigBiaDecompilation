using System;
using System.Collections;
using UnityEngine;

public class tick : MonoBehaviour
{
	private void Start()
	{
		base.StartCoroutine(this.JavaGet());
	}

	private IEnumerator JavaGet()
	{
		for (;;)
		{
			WWW www = new WWW("http://www.sdslgbhdzx.com/CMS/embedservice/count.shtml?method=read&articleId=3423312b-bf17-4ea6-9dc1-a5b7aec72fe8&channelId=5b6f7753-3225-4179-a232-bfe822e44be4&siteId=5251c8c7-cb9f-47b4-ad4c-6c4f7599cd0c");
			yield return www;
			if (www.error == null)
			{
				string text = www.text;
				Debug.Log("消息长度:" + text.Length.ToString() + "消息内容为：" + text);
			}
			else
			{
				Debug.Log("GET请求出错");
			}
			www = null;
		}
		yield break;
	}

	private void Update()
	{
	}
}
