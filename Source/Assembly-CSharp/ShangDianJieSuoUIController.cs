using System;
using UnityEngine;

public class ShangDianJieSuoUIController : MonoBehaviour
{
	private void Start()
	{
	}

	public void OnClose()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
