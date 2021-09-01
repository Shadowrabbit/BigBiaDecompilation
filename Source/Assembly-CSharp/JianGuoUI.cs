using System;
using UnityEngine;

public class JianGuoUI : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	public void CloseUI()
	{
		base.gameObject.SetActive(false);
	}

	public GameObject Tip;

	public GameObject End;
}
