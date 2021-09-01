using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigToy : MonoBehaviour
{
	private void Start()
	{
	}

	private void OnMouseEnter()
	{
		if (UIController.LockLevel != UIController.UILevel.None)
		{
			return;
		}
		Vector3 b = Camera.main.WorldToScreenPoint(base.transform.position);
		Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
		base.transform.DOPunchRotation((a - b).normalized, 0.2f, 10, 1f);
		EffectAudioManager.Instance.PlayEffectAudio(10, null);
		this.BigToyTitle.show();
	}

	private void OnMouseExit()
	{
		if (UIController.LockLevel != UIController.UILevel.None)
		{
			return;
		}
		this.BigToyTitle.hide();
	}

	private void Update()
	{
	}

	private IEnumerator ShowToyBox()
	{
		base.transform.GetComponent<Animator>().SetTrigger("open");
		EffectAudioManager.Instance.PlayEffectAudio(2, null);
		yield return new WaitForSeconds(1f);
		yield return SceneManager.LoadSceneAsync("ShowToyScene", LoadSceneMode.Additive);
		ShowToyMgr.Instance.InitShowScene(0);
		yield break;
	}

	private IEnumerator ShowHeroHome()
	{
		EffectAudioManager.Instance.PlayEffectAudio(8, null);
		yield return SceneManager.LoadSceneAsync("ShowHeroHome", LoadSceneMode.Additive);
		ShowHeroMgr.Instance.InitShowScene(2);
		yield break;
	}

	private IEnumerator ShowMedicineHome()
	{
		EffectAudioManager.Instance.PlayEffectAudio(8, null);
		yield return SceneManager.LoadSceneAsync("ShowToyScene", LoadSceneMode.Additive);
		ShowToyMgr.Instance.InitShowScene(3);
		yield break;
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= this.SceneLoadedCallBack;
		SceneManager.sceneUnloaded -= this.SceneUnloadedCallBack;
	}

	private void SceneLoadedCallBack(Scene scene, LoadSceneMode sceneType)
	{
	}

	private void SceneUnloadedCallBack(Scene scene)
	{
		if (scene.name.Equals("ShowToyScene") && base.transform.name.Equals("玩具箱") && base.transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("ToyBox"))
		{
			base.transform.GetComponent<BoxCollider>().enabled = true;
			base.transform.GetComponent<Animator>().SetTrigger("close");
			UIController.LockLevel = UIController.UILevel.None;
		}
	}

	public BigToyTitle BigToyTitle;

	public Transform UIAnchorPoint;
}
