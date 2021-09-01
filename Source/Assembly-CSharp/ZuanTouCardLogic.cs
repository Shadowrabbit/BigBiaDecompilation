using System;
using System.Collections;
using UnityEngine;

public class ZuanTouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.NeedEnergyCount = new Vector3Int(0, 0, 2);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_钻头");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_钻头"), this.baseLayer + base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_钻头");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_钻头"), this.baseLayer + base.Layers);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		CardData defaultTarget = base.GetDefaultTarget();
		if (DungeonOperationMgr.Instance.CheckCardDead(defaultTarget))
		{
			yield break;
		}
		base.ShowMe();
		defaultTarget.AddLogic("ShangKouSiLieCardLogic", this.baseLayer + base.Layers);
		yield return base.Shifting(defaultTarget.CurrentCardSlotData, Vector3Int.down, base.GetEnemiesBattleArea());
		yield break;
	}

	private int baseLayer = 1;
}
