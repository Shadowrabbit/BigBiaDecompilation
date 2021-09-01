using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer)), ExecuteInEditMode]
public class UVChainLightning : MonoBehaviour
{
	private void Awake()
	{
		this._lineRender = base.GetComponent<LineRenderer>();
		this._linePosList = new List<Vector3>();
	}

	private void Update()
	{
		if (DungeonOperationMgr.Instance.CheckCardDead(this.start) || DungeonOperationMgr.Instance.CheckCardDead(this.target) || this.start.CardGameObject == null || this.target.CardGameObject == null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		if (Time.timeScale != 0f)
		{
			this._linePosList.Clear();
			Vector3 startPos = Vector3.zero;
			Vector3 vector = Vector3.zero;
			if (this.target != null)
			{
				vector = this.target.CardGameObject.transform.position + Vector3.up * this.yOffset;
			}
			if (this.start != null)
			{
				startPos = this.start.CardGameObject.transform.position + Vector3.up * this.yOffset;
			}
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

	public CardData target;

	public CardData start;

	public float yOffset;

	private LineRenderer _lineRender;

	private List<Vector3> _linePosList;
}
