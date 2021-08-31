using System;
using System.Collections;
using System.Collections.Generic;

public class GodOfDeathLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_收割");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_收割");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_收割");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_收割");
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		base.ShowMe();
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		new CardData();
		if (allCurrentMinions.Count == 0)
		{
			yield break;
		}
		int num = 9999;
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in allCurrentMinions)
		{
			if (cardData.HP == num)
			{
				list.Add(cardData);
			}
			if (cardData.HP < num)
			{
				list.Clear();
				list.Add(cardData);
				num = cardData.HP;
			}
		}
		if (list.Count == 0)
		{
			yield break;
		}
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				attackMsg.Target = list[SYNCRandom.Range(0, list.Count)];
			}
		}
		yield break;
	}
}
