using System;
using UnityEngine;

public class ShangdianGuanBi : MonoBehaviour
{
	private void Start()
	{
	}

	public void OnClose()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
