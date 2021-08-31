using System;
using System.Collections;
using UnityEngine;

public class RingShotToyHouseAreaLogic : AreaLogic
{
	public override void BeforeInit()
	{
	}

	public override void BeforeEnter()
	{
		this.ringShotSpecialToy = UnityEngine.Object.FindObjectOfType<RingShotSpecialToy>();
	}

	public override void OnExit()
	{
	}

	public override IEnumerator OnAlreadEnter()
	{
		this.ringShotSpecialToy.StartMouseControl = true;
		yield break;
	}

	private RingShotSpecialToy ringShotSpecialToy;
}
