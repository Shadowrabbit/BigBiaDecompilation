using System;
using System.Collections;
using UnityEngine;

public class QuanWangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.NeedEnergyCount = new Vector3Int(0, 1, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_左摆拳");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_左摆拳"), 2 * base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(0, 1, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_左摆拳");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_左摆拳"), 2 * base.Layers);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		CardData target = base.GetDefaultTarget();
		if (target == null)
		{
			yield break;
		}
		base.ShowMe();
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, target, 0, 0.2f, false, 0, null, null);
		target.AddAffix(DungeonAffix.frail, 2 * base.Layers);
		yield return base.Shifting(target.CurrentCardSlotData, Vector3Int.right, base.GetEnemiesBattleArea());
		yield break;
	}
}
