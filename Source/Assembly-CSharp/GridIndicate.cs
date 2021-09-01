using System;
using System.Collections.Generic;
using UnityEngine;

public class GridIndicate : MonoBehaviour
{
	private void Awake()
	{
		GridIndicate.Instance = this;
		this.Init();
	}

	public void ShowGird(Vector3 centerPos, List<Vector3Int> offset, float coordinateScale = 1f, bool showCenter = true)
	{
		int count = offset.Count;
		if (this.girdLists.Count <= count)
		{
			this.AddGird(count - this.girdLists.Count + 1);
		}
		Vector3 scale = new Vector3(coordinateScale, coordinateScale, 1f);
		float num = 0f * coordinateScale;
		float num2 = 0f * coordinateScale;
		Vector3 pos = new Vector3(centerPos.x + num, 0.12f, centerPos.z - num2);
		if (showCenter)
		{
			this.SetGirdPosAndScale(this.girdLists[count], pos, scale);
		}
		for (int i = 0; i < count; i++)
		{
			float num3 = (float)offset[i].x * coordinateScale;
			float num4 = (float)offset[i].y * coordinateScale;
			Vector3 pos2 = new Vector3(centerPos.x + num3, 0.12f, centerPos.z - num4);
			this.SetGirdPosAndScale(this.girdLists[i], pos2, scale);
		}
	}

	public void HideGird()
	{
		foreach (SpriteRenderer spriteRenderer in this.girdLists)
		{
			spriteRenderer.gameObject.SetActive(false);
		}
	}

	private void Init()
	{
		this.girdLists = new List<SpriteRenderer>();
	}

	private void AddGird(int count)
	{
		for (int i = 0; i < count; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.girdPrefab);
			gameObject.transform.SetParent(base.transform);
			gameObject.SetActive(false);
			this.girdLists.Add(gameObject.GetComponent<SpriteRenderer>());
		}
	}

	private void SetGirdPosAndScale(SpriteRenderer gird, Vector3 pos, Vector3 scale)
	{
		gird.gameObject.SetActive(true);
		gird.transform.position = pos;
		gird.transform.localScale = scale;
	}

	public static GridIndicate Instance;

	public GameObject girdPrefab;

	public List<SpriteRenderer> girdLists;
}
