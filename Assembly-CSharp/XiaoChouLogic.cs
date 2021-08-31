using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiaoChouLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Combine(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.MoveEvent));
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_98");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_98");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_98");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_98");
	}

	private void MoveEvent(CardSlotData arg1, CardData arg2)
	{
		if (arg2 == this.CardData && base.GetMyBattleArea().Contains(arg1))
		{
			DungeonController.Instance.StartCoroutine(this.GoDeep(arg1, arg2));
		}
	}

	public IEnumerator GoDeep(CardSlotData csd, CardData cd)
	{
		this.FeiDao();
		yield break;
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.MoveEvent));
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (target.ChildCardData != this.CardData)
		{
			yield break;
		}
		base.ShowMe();
		yield return this.TryJump(this.CardData);
		yield break;
	}

	private void FeiDao()
	{
		if (SYNCRandom.Range(0, 100) < 100)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			CardData cardData = null;
			foreach (CardData cardData2 in allCurrentMinions)
			{
				if ((int)cardData2.CurrentCardSlotData.Attrs["Col"] == (int)this.CardData.CurrentCardSlotData.Attrs["Col"])
				{
					if (cardData != null)
					{
						List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
						if (enemiesBattleArea.IndexOf(cardData.CurrentCardSlotData) <= enemiesBattleArea.IndexOf(cardData2.CurrentCardSlotData))
						{
							cardData = cardData2;
						}
					}
					else
					{
						cardData = cardData2;
					}
				}
			}
			if (cardData != null)
			{
				GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_8"), UnityEngine.Color.white, 0, false, false);
				GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, cardData, Mathf.CeilToInt((float)this.CardData.ATK * 0.05f), 0.2f, false, 0, null, null));
				cardData.AddAffix(DungeonAffix.bleeding, 1);
			}
		}
	}

	public IEnumerator TryJump(CardData jumpO)
	{
		List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
		if (allEmptySlotsInMyBattleArea == null || allEmptySlotsInMyBattleArea.Count <= 0)
		{
			yield break;
		}
		CardSlotData target = allEmptySlotsInMyBattleArea[UnityEngine.Random.Range(0, allEmptySlotsInMyBattleArea.Count)];
		yield return jumpO.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		if (jumpO.Attrs.ContainsKey("Col"))
		{
			jumpO.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}
}
