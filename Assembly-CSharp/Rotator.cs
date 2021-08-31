using System;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	private void OnEnable()
	{
		base.InvokeRepeating("Rotate", 0f, 0.0167f);
	}

	private void OnDisable()
	{
		base.CancelInvoke();
	}

	private void Rotate()
	{
		base.transform.localEulerAngles += new Vector3(this.x, this.y, this.z);
	}

	public float x;

	public float y;

	public float z;
}
