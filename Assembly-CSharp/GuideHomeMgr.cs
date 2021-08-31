using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuideHomeMgr : MonoBehaviour
{
	private void Start()
	{
		EventTriggerListener.Get(base.gameObject).onClick = new EventTriggerListener.VoidDelegate(this.OnGameObjectClicked);
	}

	private void OnGameObjectClicked(GameObject go)
	{
		if (go == base.gameObject && !this.isStart)
		{
			this.isStart = true;
			base.StartCoroutine(this.StartGuideThread());
		}
	}

	private IEnumerator StartGuideThread()
	{
		base.gameObject.transform.GetComponentInChildren<BigToyTitle>().show();
		yield return new WaitForSeconds(3f);
		int num;
		for (int i = 0; i < this.Toys.Count; i = num + 1)
		{
			yield return base.StartCoroutine(this.ShowToyThread(this.Toys[i], null));
			num = i;
		}
		yield return base.StartCoroutine(this.ShowRoleThread(this.Roles, null));
		yield return new WaitForSeconds(3f);
		Debug.Log("引导流程结束！");
		GlobalController.Instance.ChangeGuideState(true);
		GlobalController.Instance.TempUnLockedObjs.Add(GameController.getInstance().CardDataModMap.getCardDataByModID("隐"));
		yield return SceneManager.UnloadSceneAsync("GuideHome");
		yield break;
	}

	private IEnumerator ShowToyThread(Transform toy, AudioClip clip = null)
	{
		EffectAudioManager.Instance.PlayEffectAudio(17, null);
		toy.DOMove(this.ShowPos.position, 1f, false).SetEase(Ease.OutBack);
		yield return new WaitForSeconds(1f);
		toy.DOLocalRotate(Vector3.zero, 1f, RotateMode.Fast);
		TweenCallback <>9__3;
		TweenCallback <>9__2;
		TweenCallback <>9__1;
		toy.DOLocalMove(Vector3.zero, 1f, false).OnComplete(delegate
		{
			TweenerCore<Vector3, Vector3, VectorOptions> t = toy.DOScaleX(1f, 0.3f).SetEase(Ease.OutBack);
			TweenCallback action;
			if ((action = <>9__1) == null)
			{
				action = (<>9__1 = delegate()
				{
					TweenerCore<Vector3, Vector3, VectorOptions> t2 = toy.DOScaleZ(1f, 0.3f).SetEase(Ease.OutBack);
					TweenCallback action2;
					if ((action2 = <>9__2) == null)
					{
						action2 = (<>9__2 = delegate()
						{
							EffectAudioManager.Instance.PlayEffectAudio(19, null);
							TweenerCore<Vector3, Vector3, VectorOptions> t3 = toy.DOScaleY(1f, 1f);
							TweenCallback action3;
							if ((action3 = <>9__3) == null)
							{
								action3 = (<>9__3 = delegate()
								{
									toy.transform.GetComponentInChildren<BigToyTitle>().show();
								});
							}
							t3.OnComplete(action3);
						});
					}
					t2.OnComplete(action2);
				});
			}
			t.OnComplete(action);
		});
		yield return new WaitForSeconds(4f);
		yield return base.StartCoroutine(this.NotherThread());
		yield break;
	}

	private IEnumerator ShowRoleThread(List<Transform> roles, AudioClip clip = null)
	{
		int num;
		for (int i = 0; i < roles.Count; i = num + 1)
		{
			Transform role = roles[i];
			EffectAudioManager.Instance.PlayEffectAudio(17, null);
			TweenCallback <>9__1;
			role.DOMove(this.ShowPos.position, 1f, false).SetEase(Ease.OutBack).OnComplete(delegate
			{
				role.DOLocalRotate(Vector3.zero, 1f, RotateMode.Fast);
				EffectAudioManager.Instance.PlayEffectAudio(18, null);
				TweenerCore<Vector3, Vector3, VectorOptions> t = role.DOLocalMove(Vector3.zero, 1f, false);
				TweenCallback action;
				if ((action = <>9__1) == null)
				{
					action = (<>9__1 = delegate()
					{
						EffectAudioManager.Instance.PlayEffectAudio(19, null);
						role.DOScale(Vector3.one, 0.5f);
					});
				}
				t.OnComplete(action);
			});
			yield return new WaitForSeconds(1f);
			num = i;
		}
		yield break;
	}

	private IEnumerator NotherThread()
	{
		yield return null;
		yield break;
	}

	public List<Transform> Toys;

	public List<Transform> Roles;

	public Transform ShowPos;

	public AudioSource AudioSource;

	private bool isStart;
}
