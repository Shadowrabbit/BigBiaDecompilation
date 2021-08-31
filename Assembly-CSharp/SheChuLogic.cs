using System;
using System.Collections;
using System.Collections.Generic;

public class SheChuLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_76");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_76");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_76");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_76");
	}

	public override IEnumerator OnBattleStart()
	{
		base.ShowMe();
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		int num = 0;
		using (List<CardData>.Enumerator enumerator = allCurrentMonsters.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.ModID.Equals(this.CardData.ModID))
				{
					num++;
				}
			}
		}
		this.CardData.MaxHP = this.CardData.MaxHP * num;
		this.CardData.HP = this.CardData.HP * num;
		yield break;
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		if (player != this.CardData)
		{
			yield break;
		}
		if (value.value < 0 && !from.ModID.Equals(this.CardData.ModID))
		{
			base.ShowMe();
			using (List<CardData>.Enumerator enumerator = base.GetAllCurrentMonsters().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData = enumerator.Current;
					if (cardData != this.CardData && cardData.ModID.Equals(this.CardData.ModID))
					{
						GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, cardData, -value.value, 0.2f, false, 0, null, null));
					}
				}
				yield break;
			}
		}
		yield break;
	}
}
