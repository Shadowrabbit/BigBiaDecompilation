using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
	private void Start()
	{
		this.SubTitleCN = new List<string>();
		this.SubTitleCN.Add("你可能不知道");
		this.SubTitleCN.Add("有个宇宙和你所在的世界大不相同");
		this.SubTitleCN.Add("在那里一切都很简单");
		this.SubTitleCN.Add("没有什么是用\"BIA\"解决不了的");
		this.SubTitleCN.Add("吃东西就BIA掉食物");
		this.SubTitleCN.Add("困了就BIA一会");
		this.SubTitleCN.Add("爱一个人就BIA他");
		this.SubTitleCN.Add("恨一个人就BIA他");
		this.SubTitleCN.Add("说起那个世界的诞生");
		this.SubTitleCN.Add("源于一次宇宙大拍扁");
		this.SubTitleCN.Add("史称");
		this.SubTitleCN.Add("<size=128>BIG BIA</size>");
		this.subtitleText.color = new Color(1f, 1f, 1f, 0f);
		base.StartCoroutine(this.play());
	}

	private IEnumerator play()
	{
		int num;
		for (int i = 0; i < this.SubTitleCN.Count; i = num + 1)
		{
			this.subtitleText.text = this.SubTitleCN[i];
			yield return this.subtitleText.DOFade(1f, 1f).WaitForCompletion();
			yield return new WaitForSeconds(2f);
			if (i == this.SubTitleCN.Count - 1)
			{
				yield return new WaitForSeconds(5f);
			}
			yield return this.subtitleText.DOFade(0f, 1f).WaitForCompletion();
			num = i;
		}
		yield break;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			base.StopAllCoroutines();
			base.StartCoroutine(this.StartLoading());
		}
	}

	private IEnumerator StartLoading()
	{
		PlayerPrefs.SetString("SceneName", "Menu");
		yield return SceneManager.LoadSceneAsync("LoadingScene");
		yield break;
	}

	public TextMeshProUGUI subtitleText;

	public List<string> SubTitleCN;
}
