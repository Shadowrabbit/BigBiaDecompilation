using System;
using System.Collections;
using System.Collections.Generic;

public class ShuiShenCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_我要睡觉");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_我要睡觉");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_我要睡觉");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_我要睡觉");
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player == this.CardData && changedValue < 0)
		{
			List<CardData> list = new List<CardData>();
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			if (allCurrentMinions.Count == 0 || allCurrentMonsters.Count == 0)
			{
				yield break;
			}
			foreach (CardData cardData in allCurrentMonsters)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					list.Add(cardData);
				}
			}
			foreach (CardData cardData2 in allCurrentMinions)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData2))
				{
					list.Add(cardData2);
				}
			}
			CardData targetCardData = list[SYNCRandom.Range(0, list.Count)];
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("GW_D_睡神"));
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, targetCardData, this.CardData.ATK, 0.2f, false, 0, null, null);
		}
		yield break;
	}
}
