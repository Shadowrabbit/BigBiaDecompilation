using System;
using System.Collections;

public class MiningLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		if (this.CardData.HasTag(TagMap.随从))
		{
			this.Color = CardLogicColor.blue;
		}
		base.Layers = this.CardData.Level;
		if (base.Layers < 1)
		{
			base.Layers = 1;
		}
		this.displayName = "挖矿";
		this.Desc = "我方回合结束时获得1层充能，3层时获得1金币并初始化层数。";
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
