using System;
using System.Collections;
using UnityEngine;

public class BlackWolfCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "伺机";
		this.Desc = string.Concat(new string[]
		{
			"敌方单位移动时，对其造成",
			Mathf.CeilToInt((float)this.CardData.ATK * 0.25f).ToString(),
			"[25%攻击力]伤害，重复",
			base.Layers.ToString(),
			"次"
		});
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Combine(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.atk));
	}

	private void atk(CardSlotData arg1, CardData arg2)
	{
		DungeonController.Instance.StartCoroutine(this.WolfAtk(arg1, arg2));
	}

	public IEnumerator WolfAtk(CardSlotData csd, CardData cd)
	{
		base.ShowMe();
		int num;
		for (int i = 0; i < base.Layers; i = num + 1)
		{
			if (i == base.Layers - 1)
			{
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, cd, Mathf.CeilToInt((float)this.CardData.ATK * 0.25f), 0.2f, false, 0, null, null);
			}
			else
			{
				GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, cd, Mathf.CeilToInt((float)this.CardData.ATK * 0.25f), 0.2f, false, 0, null, null));
				yield return new WaitForSeconds(0.1f);
			}
			num = i;
		}
		yield break;
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.atk));
		yield break;
	}
}
