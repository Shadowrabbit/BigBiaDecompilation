using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuiHuoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.NeedEnergyCount = new Vector3Int(0, 0, 2);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_39");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_39_1") + this.CardData.ATK.ToString() + LocalizationMgr.Instance.GetLocalizationWord("CT_D_39_2");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_39");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_39_1") + this.CardData.ATK.ToString() + LocalizationMgr.Instance.GetLocalizationWord("CT_D_39_2");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
		List<CardData> list = new List<CardData>
		{
			null,
			null,
			null
		};
		for (int i = enemiesBattleArea.Count - 1; i >= 0; i -= 3)
		{
			for (int j = 0; j < 3; j++)
			{
				if (list[j] == null && enemiesBattleArea[i - j] != null && enemiesBattleArea[i - j].ChildCardData != null && enemiesBattleArea[i - j].ChildCardData.HasTag(TagMap.怪物) && !DungeonOperationMgr.Instance.CheckCardDead(enemiesBattleArea[i - j].ChildCardData))
				{
					list[j] = enemiesBattleArea[i - j].ChildCardData;
				}
			}
		}
		using (List<CardData>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardData cardData = enumerator.Current;
				if (cardData != null)
				{
					DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, cardData, this.CardData.ATK, 0.2f, false, 0, null, null));
				}
			}
			yield break;
		}
		yield break;
	}

	public bool isUsing;
}
