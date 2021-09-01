using System;
using System.Collections;
using UnityEngine;

public class BasketballToyHouseAreaLogic : AreaLogic
{
	public override void BeforeInit()
	{
	}

	public override void BeforeEnter()
	{
		this.basketballSpecialToy = UnityEngine.Object.FindObjectOfType<BasketballSpecialToy>();
	}

	public override void OnExit()
	{
	}

	public override IEnumerator OnAlreadEnter()
	{
		this.basketballSpecialToy.StartMouseControl = true;
		yield break;
	}

	private BasketballSpecialToy basketballSpecialToy;
}
