using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VedioSceneMgr : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		if (this.VP.frame == (long)(this.VP.frameCount - 3UL) && !this.m_IsClicked)
		{
			this.m_IsClicked = true;
			this.VP.Pause();
			base.StartCoroutine(this.StartLoading());
		}
		if (Input.anyKeyDown && !this.m_IsClicked)
		{
			this.m_IsClicked = true;
			this.VP.Pause();
			base.StartCoroutine(this.StartLoading());
		}
	}

	private IEnumerator LoadMenuScene()
	{
		yield return SceneManager.LoadSceneAsync("Menu");
		yield break;
	}

	private IEnumerator StartLoading()
	{
		PlayerPrefs.SetString("SceneName", "Menu");
		yield return SceneManager.LoadSceneAsync("LoadingScene");
		yield break;
	}

	public VideoPlayer VP;

	public GameObject Mask;

	private bool m_IsClicked;
}
