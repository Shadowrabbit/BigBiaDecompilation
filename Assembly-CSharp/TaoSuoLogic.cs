using System;
using System.Collections;
using UnityEngine;

public class TaoSuoLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.NeedEnergyCount = new Vector3Int(0, 1, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_钩索");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_钩索"), Mathf.CeilToInt((this.baseDmg1 + this.increaseDmg1 * (float)base.Layers) * (float)this.CardData.ATK), (this.baseDmg1 + this.increaseDmg1 * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_钩索");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_钩索"), Mathf.CeilToInt((this.baseDmg1 + this.increaseDmg1 * (float)base.Layers) * (float)this.CardData.ATK), (this.baseDmg1 + this.increaseDmg1 * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		if (base.GetEnemiesBattleArea() == null)
		{
			yield break;
		}
		CardData target = base.GetDefaultTarget();
		this.CardData.IsAttacked = true;
		if (target != null)
		{
			base.ShowMe();
			int damage = Mathf.CeilToInt((this.baseDmg1 + this.increaseDmg1 * (float)base.Layers) * (float)this.CardData.ATK);
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, target, damage, 0.2f, false, 0, null, null);
			if (!DungeonOperationMgr.Instance.CheckCardDead(target))
			{
				yield return base.Shifting(target.CurrentCardSlotData, Vector3Int.up, base.GetEnemiesBattleArea());
			}
			yield break;
		}
		yield break;
	}

	private float baseDmg1 = 1f;

	private float increaseDmg1 = 0.5f;
}
