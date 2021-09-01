using System;
using System.Collections;
using System.Collections.Generic;

public class ShuPianCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_薯片");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_薯片"), base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_薯片");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_薯片"), base.Layers * this.weight);
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (player == this.CardData)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			if (allCurrentMinions.Count == 0)
			{
				yield break;
			}
			List<CardData> list = new List<CardData>();
			foreach (CardData cardData in allCurrentMinions)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData) && cardData != this.CardData)
				{
					if (list.Count == 0)
					{
						list.Add(cardData);
					}
					else if (list[0].ATK < cardData.ATK)
					{
						list.Clear();
						list.Add(cardData);
					}
					else if (list[0].ATK == cardData.ATK)
					{
						list.Add(cardData);
					}
				}
			}
			if (list.Count == 0)
			{
				yield break;
			}
			base.ShowMe();
			CardData cardData2 = list[SYNCRandom.Range(0, list.Count)];
			DungeonOperationMgr.Instance.PlayVitalityEffect(new List<CardData>
			{
				cardData2
			});
			cardData2.AddAffix(DungeonAffix.vitality, base.Layers * this.weight);
		}
		yield break;
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		if (user == this.CardData)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			if (allCurrentMinions.Count == 0)
			{
				yield break;
			}
			List<CardData> list = new List<CardData>();
			foreach (CardData cardData in allCurrentMinions)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData) && cardData != this.CardData)
				{
					if (list.Count == 0)
					{
						list.Add(cardData);
					}
					else if (list[0].ATK < cardData.ATK)
					{
						list.Clear();
						list.Add(cardData);
					}
					else if (list[0].ATK == cardData.ATK)
					{
						list.Add(cardData);
					}
				}
			}
			if (list.Count == 0)
			{
				yield break;
			}
			base.ShowMe();
			CardData cardData2 = list[SYNCRandom.Range(0, list.Count)];
			DungeonOperationMgr.Instance.PlayVitalityEffect(new List<CardData>
			{
				cardData2
			});
			cardData2.AddAffix(DungeonAffix.vitality, base.Layers * this.weight);
		}
		yield break;
	}

	private int weight = 5;
}
