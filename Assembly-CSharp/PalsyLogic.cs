using System;
using System.Collections;

public class PalsyLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "麻痹";
		this.Desc = "无法行动。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			base.Layers++;
			if (base.Layers >= 3)
			{
				DungeonOperationMgr.Instance.ChangeMoney(1);
				base.Layers = 1;
			}
		}
		yield break;
	}
}
