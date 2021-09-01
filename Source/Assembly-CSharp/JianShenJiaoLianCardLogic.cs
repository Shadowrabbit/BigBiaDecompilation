using System;
using System.Collections;
using System.Collections.Generic;

public class JianShenJiaoLianCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_加重量");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_加重量");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_加重量");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_加重量");
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		if (allCurrentMonsters.Count == 0)
		{
			yield break;
		}
		foreach (CardData cd in allCurrentMonsters)
		{
			if (cd.ModID == "公用杠铃")
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_这种量太轻了"));
				yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, cd);
				cd.InBattleATK += 2;
			}
			cd = null;
		}
		List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
		yield break;
		yield break;
	}
}
