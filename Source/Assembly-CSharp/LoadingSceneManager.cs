using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
	private void Start()
	{
		base.StartCoroutine(this.StartLoading());
	}

	private IEnumerator StartLoading()
	{
		AsyncOperation op = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("SceneName"));
		op.allowSceneActivation = false;
		while (!op.isDone)
		{
			if (op.progress >= 0.9f)
			{
				yield return new WaitForSeconds(1f);
				op.allowSceneActivation = true;
			}
			yield return new WaitForEndOfFrame();
		}
		yield break;
	}
}
