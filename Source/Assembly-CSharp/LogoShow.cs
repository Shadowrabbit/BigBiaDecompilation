using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoShow : MonoBehaviour
{
	private void Start()
	{
		base.StartCoroutine(this.show());
	}

	private IEnumerator show()
	{
		yield return new WaitForSeconds(0.2f);
		yield return this.Logo1.DOColor(Color.white, 0.3f).WaitForCompletion();
		yield return new WaitForSeconds(0.8f);
		yield return this.Logo1.DOColor(Color.clear, 0.3f).WaitForCompletion();
		yield return this.Logo2.DOColor(Color.white, 0.3f).WaitForCompletion();
		yield return new WaitForSeconds(0.8f);
		yield return this.Logo2.DOColor(Color.clear, 0.3f).WaitForCompletion();
		yield return new WaitForSeconds(0.2f);
		SceneManager.LoadScene(1);
		yield break;
	}

	private void Update()
	{
	}

	public SpriteRenderer Logo1;

	public SpriteRenderer Logo2;
}
