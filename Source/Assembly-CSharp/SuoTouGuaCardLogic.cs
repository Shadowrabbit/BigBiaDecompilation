using System;
using System.Collections;
using System.Collections.Generic;

public class SuoTouGuaCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_锁头挂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_锁头挂");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_锁头挂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_锁头挂");
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		base.ShowMe();
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		CardData target2 = new CardData();
		if (allCurrentMinions.Count == 0)
		{
			yield break;
		}
		foreach (CardData cardData in allCurrentMinions)
		{
			if (cardData.HasTag(TagMap.英雄))
			{
				target2 = cardData;
			}
		}
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				attackMsg.Target = target2;
			}
		}
		yield break;
	}
}
