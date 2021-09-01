using System;
using UnityEngine;

public class PreButton : MonoBehaviour
{
	private void OnMouseDown()
	{
		this.tradeAct.OnPreviousButton();
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public TradeAct tradeAct;
}
