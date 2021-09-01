using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaoMaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_草帽");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_草帽"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_草帽");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_草帽"), base.Layers);
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (from == this.CardData && changedValue < 0)
		{
			List<CardData> cardDataNearBy = DungeonOperationMgr.Instance.GetCardDataNearBy(this.CardData, new List<Vector3Int>
			{
				Vector3Int.left,
				Vector3Int.left + Vector3Int.left,
				Vector3Int.right,
				Vector3Int.right + Vector3Int.right
			});
			if (cardDataNearBy.Count <= 0)
			{
				yield break;
			}
			base.ShowMe();
			using (List<CardData>.Enumerator enumerator = cardDataNearBy.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData = enumerator.Current;
					cardData.AddAffix(DungeonAffix.crit, base.Layers);
				}
				yield break;
			}
		}
		yield break;
	}
}
