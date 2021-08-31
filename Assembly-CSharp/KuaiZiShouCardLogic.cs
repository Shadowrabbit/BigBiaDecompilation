using System;
using System.Collections;
using System.Collections.Generic;

public class KuaiZiShouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_血涌快感");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_血涌快感");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_血涌快感");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_血涌快感");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		int num = 0;
		if (!isPlayerTurn)
		{
			List<CardData> allCardsInBattleArea = base.GetAllCardsInBattleArea();
			if (allCardsInBattleArea.Count == 0)
			{
				yield break;
			}
			foreach (CardData cardData in allCardsInBattleArea)
			{
				if (cardData.HasAffix(DungeonAffix.bleeding))
				{
					num += cardData.GetAffixData(DungeonAffix.bleeding);
				}
			}
		}
		if (this.CardData.HP < this.CardData.MaxHP)
		{
			base.ShowMe();
			yield return base.Cure(this.CardData, num, this.CardData);
		}
		yield break;
	}

	private int Count;
}
