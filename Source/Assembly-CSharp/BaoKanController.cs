using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaoKanController : MonoBehaviour
{
	private void Start()
	{
		this.Title.gameObject.SetActive(false);
		NewspaperItem.isDoing = false;
		BaoKanController.ins = this;
	}

	public IEnumerator ShowTitle(string title)
	{
		NewspaperItem.isDoing = true;
		this.Title.gameObject.SetActive(true);
		this.Title.localPosition = Vector3.left * 2000f;
		this.TitleText.text = title;
		yield return this.Title.DOLocalMoveX(0f, 0.5f, false).WaitForCompletion();
		while (!Input.anyKeyDown)
		{
			yield return null;
		}
		yield return this.Title.DOLocalMoveX(-2000f, 0.5f, false).WaitForCompletion();
		NewspaperItem.isDoing = false;
		yield return null;
		yield break;
	}

	public void OnBackHomeButton()
	{
		if (NewspaperItem.isDoing)
		{
			return;
		}
		base.StartCoroutine(this.BackToHome());
	}

	public IEnumerator BackToHome()
	{
		NewspaperItem.isDoing = true;
		EffectAudioManager.Instance.PlayEffectAudio(6, null);
		UnityEngine.Object.DestroyImmediate(GlobalController.Instance.gameObject);
		PlayerPrefs.SetString("SceneName", "Menu");
		yield return SceneManager.LoadSceneAsync("LoadingScene");
		yield break;
	}

	private void Update()
	{
	}

	public static BaoKanController ins;

	public Transform Title;

	public TextMeshProUGUI TitleText;

	public PaperObject currentPaperObjuct;
}
