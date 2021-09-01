using System;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class GetYellowPoint : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "黄色标记";
		this.Desc = "消灭本单位来在本次事件中获得" + base.Layers.ToString() + "个黄色标记。";
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target == this.CardData && from != this.CardData)
		{
			DungeonOperationMgr.Instance.GainsYellowPointInEventBattle += base.Layers;
			DialogueLua.SetVariable("GainsYellowPointInEventBattle", DungeonOperationMgr.Instance.GainsYellowPointInEventBattle);
			yield break;
		}
		yield break;
	}

	private float damage = 0.15f;
}
