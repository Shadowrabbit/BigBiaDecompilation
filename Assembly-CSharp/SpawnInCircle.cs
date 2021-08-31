using System;
using UnityEngine;

public class SpawnInCircle : MonoBehaviour
{
	private void Update()
	{
		if (this.DoIt && this.Prefab != null)
		{
			Vector3 position = base.transform.position;
			Quaternion rotation = base.transform.rotation;
			int num = 0;
			while ((float)num < this.Amount)
			{
				int num2 = UnityEngine.Random.Range(0, 360);
				Vector3 vector = new Vector3(Mathf.Cos((float)num2), 0f, Mathf.Sin((float)num2));
				vector = position + vector * Mathf.Sqrt(UnityEngine.Random.Range(0f, 1f)) * this.Radius;
				UnityEngine.Object.Instantiate<GameObject>(this.Prefab, vector, rotation, base.transform.parent);
				num++;
			}
		}
		this.DoIt = false;
	}

	public GameObject Prefab;

	public float Radius = 1000f;

	public float Amount = 10000f;

	public bool DoIt;
}
