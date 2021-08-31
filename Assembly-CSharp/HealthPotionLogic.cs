using System;

public class HealthPotionLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "生命恢复";
		this.Desc = "回复" + base.Layers.ToString() + "生命值";
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, base.Layers, this.CardData, false, 0, true, false));
		base.RemoveCardLogic(this.CardData, base.GetType(), "HealthPotionLogic");
	}
}
