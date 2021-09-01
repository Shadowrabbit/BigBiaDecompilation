using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class ScenePoopWater : MonoBehaviour
{
	private void Start()
	{
		this.audioSource = base.transform.GetComponent<AudioSource>();
	}

	private void OnTriggerEnter(Collider other)
	{
		this.audioSource.clip = this.AudioClips[UnityEngine.Random.Range(0, this.AudioClips.Count)];
		this.audioSource.Play();
		this.WaterJump();
		base.StartCoroutine("WaterLeftYield");
		base.StartCoroutine("WaterRightYield");
	}

	private IEnumerator WaterLeftYield()
	{
		int num;
		for (int i = 6; i >= 0; i = num - 1)
		{
			this.WaterMove(base.transform.GetChild(i), (float)(7 - i));
			yield return new WaitForSeconds(0.1f);
			num = i;
		}
		yield break;
	}

	private IEnumerator WaterRightYield()
	{
		int num;
		for (int i = 7; i < base.transform.childCount; i = num + 1)
		{
			this.WaterMove(base.transform.GetChild(i), (float)(i - 6));
			yield return new WaitForSeconds(0.1f);
			num = i;
		}
		yield break;
	}

	private void WaterMove(Transform tran, float power)
	{
		TweenCallback <>9__1;
		tran.DOLocalMoveY(-0.2f * (1f - 0.1f * power), 0.3f, false).OnComplete(delegate
		{
			TweenerCore<Vector3, Vector3, VectorOptions> t = tran.DOLocalMoveY(0.2f * (1f - 0.1f * power), 0.3f, false);
			TweenCallback action;
			if ((action = <>9__1) == null)
			{
				action = (<>9__1 = delegate()
				{
					tran.DOLocalMoveY(0f, 0.15f, false);
				});
			}
			t.OnComplete(action);
		});
	}

	private void WaterJump()
	{
		if (this.WaterCount > 0)
		{
			this.WaterCount--;
			Transform wa = UnityEngine.Object.Instantiate<Transform>(this.Water);
			wa.position = new Vector3(2.4f, -0.39f, -0.29f);
			wa.name = "Water_" + UnityEngine.Random.Range(0, 9999).ToString();
			wa.DOJump(new Vector3(-1.76f, -1.76f + (float)UnityEngine.Random.Range(0, 101) / 100f * 2.7f, -1.06f + (float)UnityEngine.Random.Range(0, 101) / 100f * 1.51f), (float)UnityEngine.Random.Range(1, 100) / 100f, 1, 1f, false).SetId(this.Water.name).OnComplete(delegate
			{
				UnityEngine.Object.Destroy(wa.gameObject);
			});
		}
	}

	public Transform Water;

	public List<AudioClip> AudioClips;

	public int WaterCount;

	private AudioSource audioSource;
}
