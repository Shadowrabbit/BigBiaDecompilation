using System;
using System.Collections;

public class DontMoveCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_31");
	}

	public override IEnumerator OnBattleStart()
	{
		if (GameController.ins != null)
		{
			GameEventManager gameEventManager = GameController.ins.GameEventManager;
			gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.atk));
			GameEventManager gameEventManager2 = GameController.ins.GameEventManager;
			gameEventManager2.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Combine(gameEventManager2.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.atk));
		}
		return base.OnBattleStart();
	}

	public override void OnShowTips()
	{
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_31");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_31"), base.Layers * 2);
		base.OnShowTips();
	}

	private void atk(CardSlotData arg1, CardData arg2)
	{
		if (this.CardData != null && arg2 != null && arg1 != null && GameController.getInstance().PlayerSlotSets.Contains(this.CardData.CurrentCardSlotData))
		{
			DungeonController.Instance.StartCoroutine(this.WolfAtk(arg1, arg2));
		}
	}

	public IEnumerator WolfAtk(CardSlotData csd, CardData cd)
	{
		if (!DungeonOperationMgr.Instance.CheckCardDead(cd) && cd.HasTag(TagMap.怪物) && base.GetEnemiesBattleArea().Contains(csd) && this.CardData.CurrentCardSlotData.Color == CardSlotData.LineColor.blue)
		{
			base.ShowMe();
			cd.AddAffix(DungeonAffix.frail, 2 * base.Layers);
			yield break;
		}
		yield break;
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.atk));
		yield break;
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		if (GameController.ins != null)
		{
			GameEventManager gameEventManager = GameController.ins.GameEventManager;
			gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.atk));
			GameEventManager gameEventManager2 = GameController.ins.GameEventManager;
			gameEventManager2.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Combine(gameEventManager2.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.atk));
		}
	}
}
