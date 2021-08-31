using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class TestWater : MonoBehaviour
{
	private void Start()
	{
		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				Transform transform = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
				transform.position = new Vector3((float)(i - this.aryCenter) * this.radiu, 0f, (float)(j - this.aryCenter) * this.radiu);
				transform.name = "Cube_" + i.ToString() + "_" + j.ToString();
				this.transMap[i, j] = transform;
			}
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			base.StartCoroutine("WaterYield");
		}
	}

	private IEnumerator WaterYield()
	{
		int num;
		for (int i = 0; i < 9; i = num + 1)
		{
			for (int j = 0; j < 9; j++)
			{
				this.WaterMove(this.transMap[i, j]);
			}
			yield return new WaitForSeconds(0.1f);
			num = i;
		}
		yield break;
	}

	private void WaterMove(Transform tran)
	{
		TweenCallback <>9__1;
		tran.DOLocalMoveY(-0.1f, 0.3f, false).OnComplete(delegate
		{
			TweenerCore<Vector3, Vector3, VectorOptions> t = tran.DOLocalMoveY(0.1f, 0.3f, false);
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

	private Transform[,] transMap = new Transform[9, 9];

	private int aryCenter = 4;

	private int length = 4;

	private float radiu = 1f;
}
