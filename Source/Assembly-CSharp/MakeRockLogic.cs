using System;
using System.Collections;

public class MakeRockLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "30%几率石化目标。";
		this.Desc = "石化";
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		yield return null;
		yield break;
	}
}
