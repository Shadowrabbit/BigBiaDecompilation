using System;
using System.Collections;
using System.Collections.Generic;

public class ScreamSeedLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_刺耳尖叫");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_刺耳尖叫"), 2);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_刺耳尖叫");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_刺耳尖叫"), 2);
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		base.ShowMe();
		using (List<CardData>.Enumerator enumerator = allCurrentMinions.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardData cardData = enumerator.Current;
				cardData.AddAffix(DungeonAffix.weak, 2);
			}
			yield break;
		}
		yield break;
	}

	private CardData CurrentData;
}
