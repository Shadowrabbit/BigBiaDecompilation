using System;
using System.Collections;
using UnityEngine;

public class YiYangZhiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_一阳指");
		this.Color = CardLogicColor.white;
		this.NeedEnergyCount = new Vector3Int(0, 1, 0);
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_一阳指"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_一阳指");
		this.NeedEnergyCount = new Vector3Int(0, 1, 0);
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_一阳指"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		CardData defaultTarget = base.GetDefaultTarget();
		if (!DungeonOperationMgr.Instance.CheckCardDead(defaultTarget))
		{
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, defaultTarget, Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), 0.2f, true, 0, null, null);
		}
		yield break;
	}

	private float baseDmg = 1f;

	private float increaseDmg = 1f;
}
