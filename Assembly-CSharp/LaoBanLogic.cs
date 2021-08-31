using System;
using System.Collections;
using System.Collections.Generic;

public class LaoBanLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_75");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_75");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_75");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_75");
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target != this.CardData)
		{
			List<CardSlotData> myBattleArea = base.GetMyBattleArea();
			int num = 0;
			foreach (CardSlotData cardSlotData in myBattleArea)
			{
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData != target && cardSlotData.ChildCardData != this.CardData)
				{
					num++;
				}
			}
			if (num <= 0)
			{
				yield return this.Explode();
			}
		}
		yield break;
	}

	private IEnumerator Explode()
	{
		base.ShowMe();
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		new List<CardData>();
		if (allCurrentMinions.Count > 0)
		{
			foreach (CardData targetCardData in allCurrentMinions)
			{
				GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, targetCardData, this.CardData.ATK, 0.2f, false, 0, null, null));
			}
		}
		if (allCurrentMonsters.Count > 0)
		{
			foreach (CardData targetCardData2 in allCurrentMonsters)
			{
				GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, targetCardData2, this.CardData.ATK, 0.2f, false, 0, null, null));
			}
		}
		yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -this.CardData.HP, this.CardData, true, 0, true, false);
		yield break;
	}
}
