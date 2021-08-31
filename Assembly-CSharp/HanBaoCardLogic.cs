using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanBaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_汉堡");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_汉堡"), base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_汉堡");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_汉堡"), base.Layers * this.weight);
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (player == this.CardData)
		{
			List<CardData> cardDataNearBy = DungeonOperationMgr.Instance.GetCardDataNearBy(this.CardData, new List<Vector3Int>
			{
				Vector3Int.up
			});
			if (cardDataNearBy.Count <= 0)
			{
				yield break;
			}
			using (List<CardData>.Enumerator enumerator = cardDataNearBy.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData = enumerator.Current;
					if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
					{
						base.ShowMe();
						DungeonOperationMgr.Instance.PlayVitalityEffect(new List<CardData>
						{
							cardData
						});
						cardData.AddAffix(DungeonAffix.vitality, base.Layers * this.weight);
					}
				}
				yield break;
			}
		}
		yield break;
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		if (user == this.CardData)
		{
			List<CardData> cardDataNearBy = DungeonOperationMgr.Instance.GetCardDataNearBy(this.CardData, new List<Vector3Int>
			{
				Vector3Int.up
			});
			if (cardDataNearBy.Count <= 0)
			{
				yield break;
			}
			using (List<CardData>.Enumerator enumerator = cardDataNearBy.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData = enumerator.Current;
					if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
					{
						base.ShowMe();
						DungeonOperationMgr.Instance.PlayVitalityEffect(new List<CardData>
						{
							cardData
						});
						cardData.AddAffix(DungeonAffix.vitality, base.Layers * this.weight);
					}
				}
				yield break;
			}
		}
		yield break;
	}

	private int weight = 3;
}
