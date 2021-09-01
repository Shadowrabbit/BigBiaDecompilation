using System;
using UnityEngine;

public class ClickToClose : MonoBehaviour
{
	private void Start()
	{
	}

	public void OnClick()
	{
		PlayerPrefs.SetInt(this.ObjectName, 1);
		UnityEngine.Object.DestroyImmediate(this.target);
	}

	private void Update()
	{
	}

	public GameObject target;

	public string ObjectName = "Newspaper";
}
