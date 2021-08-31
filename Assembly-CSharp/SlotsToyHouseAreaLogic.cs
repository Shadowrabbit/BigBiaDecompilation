using System;
using System.Collections;
using UnityEngine;

public class SlotsToyHouseAreaLogic : AreaLogic
{
	public override void BeforeInit()
	{
	}

	public override void BeforeEnter()
	{
		this.slotsSpecialToy = UnityEngine.Object.FindObjectOfType<SlotsSpecialToy>();
	}

	public override void OnExit()
	{
	}

	public override IEnumerator OnAlreadEnter()
	{
		this.slotsSpecialToy.StartMouseControl = true;
		yield break;
	}

	private SlotsSpecialToy slotsSpecialToy;
}
