using System;
using UnityEngine;

public class BuildButton : MonoBehaviour
{
	private void Start()
	{
	}

	private void OnMouseDown()
	{
	}

	private void Build(string s)
	{
		new ChangeCurrentArea().InitArea(s);
	}
}
