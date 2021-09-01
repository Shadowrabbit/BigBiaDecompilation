using System;
using System.Collections;

public class BleedingCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "流血";
		this.ExistsRound = 2;
		this.Desc = string.Concat(new string[]
		{
			"回合结束时，受到",
			base.Layers.ToString(),
			"点伤害，持续",
			this.ExistsRound.ToString(),
			"回合。每次移动获得+1层数，且刷新持续时间"
		});
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.MoveEvent));
		GameEventManager gameEventManager2 = GameController.ins.GameEventManager;
		gameEventManager2.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Combine(gameEventManager2.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.MoveEvent));
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Desc = string.Concat(new string[]
		{
			"回合结束时，受到",
			base.Layers.ToString(),
			"点伤害，持续",
			this.ExistsRound.ToString(),
			"回合。每次移动获得+1层数，且刷新持续时间"
		});
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			base.ShowMe();
			if (DungeonOperationMgr.Instance.CheckCardDead(this.CardData))
			{
				yield break;
			}
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, this.CardData, base.Layers, 0.2f, false, 0, null, null);
		}
		yield return base.OnEndTurn(isPlayerTurn);
		yield break;
	}

	private void MoveEvent(CardSlotData arg1, CardData arg2)
	{
		if (arg2 != null && arg2 == this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(arg2) && base.GetMyBattleArea().Contains(arg1) && base.GetMyBattleArea().Contains(arg2.CurrentCardSlotData))
		{
			DungeonController.Instance.StartCoroutine(this.GoDeep(arg1, arg2));
		}
	}

	public IEnumerator GoDeep(CardSlotData csd, CardData cd)
	{
		base.ShowLogic("流血+1");
		base.Layers++;
		this.ExistsRound = 2;
		yield break;
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.MoveEvent));
		yield break;
	}
}
