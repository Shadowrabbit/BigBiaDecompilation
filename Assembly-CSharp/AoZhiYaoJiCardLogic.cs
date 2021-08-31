using System;
using System.Collections;
using UnityEngine;

public class AoZhiYaoJiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(2, 0, 0);
		this.displayName = "熬制汤剂";
		this.Desc = "随机熬制一瓶汤剂。";
	}

	public override IEnumerator OnUseSkill()
	{
		return base.OnUseSkill();
	}
}
