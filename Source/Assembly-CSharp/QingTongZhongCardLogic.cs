using System;
using System.Collections;
using UnityEngine;

public class QingTongZhongCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.NeedEnergyCount = new Vector3Int(0, 0, 1);
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_青铜钟");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_青铜钟"), base.Layers * this.weight, base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_青铜钟");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_青铜钟"), base.Layers * this.weight, base.Layers * this.weight);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		base.ShowMe();
		this.CardData.IsAttacked = true;
		this.CardData.AddAffix(DungeonAffix.guard, base.Layers * this.weight);
		this.CardData.AddAffix(DungeonAffix.def, base.Layers * this.weight);
		yield break;
	}

	private int weight = 2;
}
