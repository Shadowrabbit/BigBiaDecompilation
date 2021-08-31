using System;
using System.Collections;
using System.Collections.Generic;

public class ShangKouSiLieCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.round = base.Layers;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_伤口撕裂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_伤口撕裂");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_伤口撕裂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_伤口撕裂");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.MoveEvent));
		GameEventManager gameEventManager2 = GameController.ins.GameEventManager;
		gameEventManager2.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Combine(gameEventManager2.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.MoveEvent));
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			this.round--;
			if (this.round == 0)
			{
				this.CardData.RemoveCardLogic(this);
				yield break;
			}
		}
		yield break;
	}

	private void MoveEvent(CardSlotData arg1, CardData arg2)
	{
		DungeonController.Instance.StartCoroutine(this.GoDeep(arg1, arg2));
	}

	public IEnumerator GoDeep(CardSlotData csd, CardData cd)
	{
		List<CardSlotData> battleArea = DungeonOperationMgr.Instance.BattleArea;
		List<CardSlotData> playerBattleArea = DungeonOperationMgr.Instance.PlayerBattleArea;
		if (!DungeonOperationMgr.Instance.CheckCardDead(cd) && (battleArea.Contains(csd) || playerBattleArea.Contains(csd)) && (battleArea.Contains(cd.CurrentCardSlotData) || playerBattleArea.Contains(cd.CurrentCardSlotData)) && csd != cd.CurrentCardSlotData && cd == this.CardData)
		{
			base.ShowMe();
			int affixData = this.CardData.GetAffixData(DungeonAffix.bleeding);
			this.CardData.AddAffix(DungeonAffix.bleeding, affixData);
			yield break;
		}
		yield break;
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.MoveEvent));
		yield break;
	}

	public int round;
}
