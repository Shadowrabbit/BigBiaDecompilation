using System;
using System.Collections;
using UnityEngine;

public class Missile : MonoBehaviour
{
	private void Start()
	{
		this.IsOver = false;
	}

	private void Update()
	{
	}

	public void OnInit()
	{
	}

	public void OnDie()
	{
	}

	public IEnumerator Run()
	{
		yield break;
	}

	public bool IsOver;
}
