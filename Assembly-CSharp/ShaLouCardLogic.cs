using System;
using System.Collections;
using System.Collections.Generic;

public class ShaLouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_沙漏");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_沙漏"), base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_沙漏");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_沙漏"), base.Layers * this.weight);
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
		int num = 0;
		foreach (CardData cd in allCurrentMinions)
		{
			if (base.GetMinionLine(cd) == base.GetMinionLine(this.CardData))
			{
				num++;
			}
		}
		base.ShowMe();
		this.CardData.AddAffix(DungeonAffix.guard, base.Layers * this.weight * num);
		yield break;
	}

	private int weight = 2;
}
