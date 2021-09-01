using System;
using UnityEngine;

public class CameraDir : MonoBehaviour
{
	private void Start()
	{
		this.anchorDir = base.transform.forward;
		this.thisDir = base.transform.forward;
	}

	private void Update()
	{
		if (!this.isFoward)
		{
			return;
		}
		Vector3 a = new Vector3(Input.mousePosition.x - (float)(Screen.width / 2), Input.mousePosition.y - (float)(Screen.height / 2));
		if (Vector3.Distance(a, Vector3.zero) > 1000f)
		{
			a = a.normalized * 1000f;
		}
		base.transform.forward = this.thisDir * this.Power + a / 1500f;
	}

	public float Power = 20f;

	[NonSerialized]
	public bool isFoward = true;

	private Vector3 anchorDir;

	private Vector3 thisDir;
}
