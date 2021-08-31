using System;
using System.Collections;
using UnityEngine;

public class DodgingToyHouseAreaLogic : AreaLogic
{
	public override void BeforeInit()
	{
	}

	public override void BeforeEnter()
	{
		this.dodgingSpecialToy = UnityEngine.Object.FindObjectOfType<DodgingSpecialToy>();
	}

	public override void OnExit()
	{
	}

	public override IEnumerator OnAlreadEnter()
	{
		this.dodgingSpecialToy.StartMouseControl = true;
		yield break;
	}

	private DodgingSpecialToy dodgingSpecialToy;
}
