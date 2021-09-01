using System;
using System.Collections;
using System.Collections.Generic;

public class TiWoDePiGu : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_踢我的屁股");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_踢我的屁股");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_踢我的屁股");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_踢我的屁股");
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		if (player == this.CardData && changedValue < 0)
		{
			base.ShowMe();
			using (List<CardData>.Enumerator enumerator = base.GetAllCurrentMinions().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData = enumerator.Current;
					cardData.AddAffix(DungeonAffix.heal, 1);
				}
				yield break;
			}
		}
		yield break;
	}
}
