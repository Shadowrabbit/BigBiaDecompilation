using System;
using System.Collections;
using System.Collections.Generic;

public class XueNvCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_冰鲜");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_冰鲜");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_冰鲜");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_冰鲜");
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		if (allCurrentMinions.Count == 0)
		{
			yield break;
		}
		allCurrentMinions[SYNCRandom.Range(0, allCurrentMinions.Count)].IsAttacked = true;
		yield break;
	}
}
