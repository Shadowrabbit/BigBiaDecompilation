using System;
using UnityEngine;

public class Energy : MonoBehaviour
{
	public void init(Transform aim)
	{
		this.Target = aim;
	}

	private void Start()
	{
	}

	private void Update()
	{
		if (Vector3.Distance(base.transform.position, this.Target.position) < 0.3f)
		{
			this.Target.GetComponent<Consumer>().now++;
			UnityEngine.Object.DestroyImmediate(base.gameObject);
			return;
		}
		base.transform.position += (this.Target.position - base.transform.position).normalized * 0.01f;
	}

	public Transform Target;
}
