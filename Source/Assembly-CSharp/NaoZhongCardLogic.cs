using System;
using System.Collections;
using System.Collections.Generic;

public class NaoZhongCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_闹钟");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_闹钟"), base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_闹钟");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_闹钟"), base.Layers * this.weight);
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		bool flag = true;
		if (player == this.CardData)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			if (allCurrentMinions.Count <= 0)
			{
				yield break;
			}
			foreach (CardData cardData in allCurrentMinions)
			{
				if (cardData != this.CardData && !cardData.IsAttacked)
				{
					flag = false;
				}
			}
			if (flag)
			{
				base.ShowMe();
				this.CardData.AddAffix(DungeonAffix.guard, base.Layers * this.weight);
			}
		}
		yield break;
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		bool flag = true;
		if (user == this.CardData)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			if (allCurrentMinions.Count <= 0)
			{
				yield break;
			}
			foreach (CardData cardData in allCurrentMinions)
			{
				if (cardData != this.CardData && !cardData.IsAttacked)
				{
					flag = false;
				}
			}
			if (flag)
			{
				base.ShowMe();
				this.CardData.AddAffix(DungeonAffix.guard, base.Layers * this.weight);
			}
		}
		yield break;
	}

	private int weight = 3;
}
