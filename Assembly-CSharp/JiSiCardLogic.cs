using System;
using System.Collections;

public class JiSiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "邪能祈祷";
		this.Desc = "回合结束时，对敌方英雄造成20点伤害。";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "邪能祈祷";
		this.Desc = "回合结束时，对敌方英雄造成20点伤害。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			CardData hero = base.GetHero();
			base.ShowMe();
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, hero, 20, 0.2f, false, 0, null, null);
		}
		yield break;
	}
}
