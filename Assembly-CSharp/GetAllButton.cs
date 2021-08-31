using System;
using UnityEngine;

public class GetAllButton : MonoBehaviour
{
	private void OnMouseDown()
	{
		if (!this.Enable)
		{
			return;
		}
		this.GameAct.OnActGetAllButton();
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public GameAct GameAct;

	public bool Enable = true;
}
