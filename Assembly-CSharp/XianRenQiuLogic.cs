using System;
using System.Collections;
using System.Collections.Generic;

public class XianRenQiuLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_82");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_82");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_82");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_82");
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player != this.CardData)
		{
			yield break;
		}
		base.ShowMe();
		yield return this.TryJump(target);
		yield break;
	}

	public IEnumerator TryJump(CardSlotData csd)
	{
		List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
		if (enemiesBattleArea == null || csd.ChildCardData == null || DungeonOperationMgr.Instance.CheckCardDead(csd.ChildCardData))
		{
			yield break;
		}
		if (enemiesBattleArea.IndexOf(csd) <= 2)
		{
			yield break;
		}
		CardSlotData cardSlotData = enemiesBattleArea[enemiesBattleArea.IndexOf(csd) - 3];
		if (cardSlotData.ChildCardData == null)
		{
			base.ShowMe();
			yield return csd.ChildCardData.CardGameObject.JumpToSlot(cardSlotData.CardSlotGameObject, 0.2f, true);
		}
		yield break;
	}
}
