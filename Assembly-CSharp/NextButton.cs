using System;
using UnityEngine;

public class NextButton : MonoBehaviour
{
	private void OnMouseDown()
	{
		this.tradeAct.OnNextButton();
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public TradeAct tradeAct;
}
