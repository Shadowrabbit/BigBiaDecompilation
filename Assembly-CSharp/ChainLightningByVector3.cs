using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer)), ExecuteInEditMode]
public class ChainLightningByVector3 : MonoBehaviour
{
	private void Awake()
	{
		this._lineRender = base.GetComponent<LineRenderer>();
		this._linePosList = new List<Vector3>();
		base.StartCoroutine(this.DestoryCorotine());
	}

	private IEnumerator DestoryCorotine()
	{
		yield return new WaitForSeconds(this.Duration);
		UnityEngine.Object.DestroyImmediate(base.gameObject);
		yield break;
	}

	private void Update()
	{
		if (Time.timeScale != 0f)
		{
			this._linePosList.Clear();
			Vector3 startPos = Vector3.zero;
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = this.target;
			vector = this.target + Vector3.up * this.yOffset;
			Vector3 vector3 = this.start;
			startPos = this.start + Vector3.up * this.yOffset;
			this.CollectLinPos(startPos, vector, this.displacement);
			this._linePosList.Add(vector);
			this._lineRender.SetVertexCount(this._linePosList.Count);
			int i = 0;
			int count = this._linePosList.Count;
			while (i < count)
			{
				this._lineRender.SetPosition(i, this._linePosList[i]);
				i++;
			}
		}
	}

	private void CollectLinPos(Vector3 startPos, Vector3 destPos, float displace)
	{
		if (displace < this.detail)
		{
			this._linePosList.Add(startPos);
			return;
		}
		float num = (startPos.x + destPos.x) / 2f;
		float num2 = (startPos.y + destPos.y) / 2f;
		float num3 = (startPos.z + destPos.z) / 2f;
		num += (float)((double)UnityEngine.Random.value - 0.5) * displace;
		num2 += (float)((double)UnityEngine.Random.value - 0.5) * displace;
		num3 += (float)((double)UnityEngine.Random.value - 0.5) * displace;
		Vector3 vector = new Vector3(num, num2, num3);
		this.CollectLinPos(startPos, vector, displace / 2f);
		this.CollectLinPos(vector, destPos, displace / 2f);
	}

	public float detail = 1f;

	public float displacement = 15f;

	public Vector3 target;

	public Vector3 start;

	public float yOffset;

	public float Duration = 1f;

	private LineRenderer _lineRender;

	private List<Vector3> _linePosList;
}
