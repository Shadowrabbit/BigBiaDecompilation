using System;
using System.Collections;
using UnityEngine;

public class TianTongCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.NeedEnergyCount = new Vector3Int(0, 1, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_甜筒");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_甜筒"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f, 2 + base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_甜筒");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_甜筒"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f, 2 + base.Layers);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		CardData target = base.GetDefaultTarget();
		if (DungeonOperationMgr.Instance.CheckCardDead(target))
		{
			yield break;
		}
		base.ShowMe();
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, target, Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), 0.2f, false, 0, null, null);
		if (DungeonOperationMgr.Instance.CheckCardDead(target))
		{
			yield break;
		}
		target.AddAffix(DungeonAffix.frozen, 2 + base.Layers);
		yield break;
	}

	private float baseDmg = 1f;

	private float increaseDmg = 1f;
}
