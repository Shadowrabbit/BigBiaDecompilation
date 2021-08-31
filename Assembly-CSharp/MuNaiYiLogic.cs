using System;
using System.Collections;
using System.Collections.Generic;

public class MuNaiYiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_83");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_83");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_83");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_83");
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player != this.CardData)
		{
			yield break;
		}
		List<CardData> list = new List<CardData>();
		List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
		if (enemiesBattleArea.IndexOf(target) - 1 >= 0 && enemiesBattleArea[enemiesBattleArea.IndexOf(target) - 1].ChildCardData != null)
		{
			list.Add(enemiesBattleArea[enemiesBattleArea.IndexOf(target) - 1].ChildCardData);
		}
		if (enemiesBattleArea.IndexOf(target) + 1 < enemiesBattleArea.Count && enemiesBattleArea[enemiesBattleArea.IndexOf(target) + 1].ChildCardData != null)
		{
			list.Add(enemiesBattleArea[enemiesBattleArea.IndexOf(target) + 1].ChildCardData);
		}
		if (enemiesBattleArea.IndexOf(target) + 3 < enemiesBattleArea.Count && enemiesBattleArea[enemiesBattleArea.IndexOf(target) + 3].ChildCardData != null)
		{
			list.Add(enemiesBattleArea[enemiesBattleArea.IndexOf(target) + 3].ChildCardData);
		}
		if (enemiesBattleArea.IndexOf(target) - 3 >= 0 && enemiesBattleArea[enemiesBattleArea.IndexOf(target) - 3].ChildCardData != null)
		{
			list.Add(enemiesBattleArea[enemiesBattleArea.IndexOf(target) - 3].ChildCardData);
		}
		if (list.Count > 0)
		{
			base.ShowMe();
			using (List<CardData>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData targetCardData = enumerator.Current;
					GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, targetCardData, this.CardData.ATK, 0.2f, false, 0, null, null));
				}
				yield break;
			}
		}
		yield break;
	}
}
