using System;
using System.Collections;

public class DisappearLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "消逝";
		this.Desc = base.Layers.ToString() + "个我方回合后，消灭自己。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			if (base.Layers > 0)
			{
				int layers = base.Layers;
				base.Layers = layers - 1;
			}
			if (base.Layers <= 0)
			{
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -this.CardData.HP, this.CardData, false, 0, true, false);
			}
		}
		yield break;
	}
}
