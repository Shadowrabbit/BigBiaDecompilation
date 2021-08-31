using System;
using System.Collections;
using System.Collections.Generic;

public class XieEZhanFangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_克总10");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_克总10");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_克总10");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_克总10");
	}

	public override IEnumerator OnTurnStart()
	{
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		if (allCurrentMinions.Count == 0)
		{
			yield break;
		}
		base.ShowLogic("hlirgh li'hee fm'latgh-og");
		foreach (CardData minion in allCurrentMinions)
		{
			if (base.GetLogic(minion, typeof(Logic_FaFeng)) != null)
			{
				yield return base.GetLogic(minion, typeof(Logic_FaFeng)).OnBattleEnd();
			}
			if (base.GetLogic(minion, typeof(Logic_ZiCan)) != null)
			{
				yield return base.GetLogic(minion, typeof(Logic_ZiCan)).OnBattleEnd();
			}
			if (base.GetLogic(minion, typeof(Logic_BuZhong)) != null)
			{
				yield return base.GetLogic(minion, typeof(Logic_BuZhong)).OnTurnStart();
			}
			minion = null;
		}
		List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
		yield break;
		yield break;
	}
}
