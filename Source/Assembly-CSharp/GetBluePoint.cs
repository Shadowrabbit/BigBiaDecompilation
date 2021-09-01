using System;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class GetBluePoint : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "蓝色标记";
		this.Desc = "消灭本单位来在本次事件中获得" + base.Layers.ToString() + "个蓝色标记。";
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target == this.CardData && from != this.CardData)
		{
			DungeonOperationMgr.Instance.GainsBluePointInEventBattle += base.Layers;
			DialogueLua.SetVariable("GainsBluePointInEventBattle", DungeonOperationMgr.Instance.GainsBluePointInEventBattle);
			yield break;
		}
		yield break;
	}

	private float damage = 0.15f;
}
