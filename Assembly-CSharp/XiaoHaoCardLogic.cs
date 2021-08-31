using System;
using System.Collections;
using System.Collections.Generic;

public class XiaoHaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_小号");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_小号"), base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_小号");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_小号"), base.Layers * this.weight);
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		if (!this.CardData.HasTag(TagMap.随从))
		{
			yield break;
		}
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		if (allCurrentMinions.Count <= 0)
		{
			yield break;
		}
		base.ShowMe();
		using (List<CardData>.Enumerator enumerator = allCurrentMinions.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardData cardData = enumerator.Current;
				if (base.GetMinionLine(cardData) == base.GetMinionLine(this.CardData) && cardData != this.CardData)
				{
					cardData.AddAffix(DungeonAffix.strength, base.Layers * this.weight);
				}
			}
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		if (!this.CardData.HasTag(TagMap.随从))
		{
			yield break;
		}
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		if (allCurrentMinions.Count <= 0)
		{
			yield break;
		}
		base.ShowMe();
		using (List<CardData>.Enumerator enumerator = allCurrentMinions.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardData cardData = enumerator.Current;
				if (base.GetMinionLine(cardData) == base.GetMinionLine(this.CardData) && cardData != this.CardData)
				{
					cardData.AddAffix(DungeonAffix.strength, base.Layers * this.weight);
				}
			}
			yield break;
		}
		yield break;
	}

	private int weight = 2;
}
