using System;
using UnityEngine;

public class AlwaysRotate : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		base.transform.RotateAround(this.go.position, this.Axis, this.Speed);
	}

	public Vector3 Axis;

	public Vector3 Delta;

	public float Speed;

	public Transform go;
}
