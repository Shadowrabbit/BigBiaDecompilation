using System;
using System.Collections;
using UnityEngine;

public class HuoZhiJiSiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(2, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_28");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_28"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_28");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_28"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		if (base.GetEnemiesBattleArea() == null)
		{
			yield break;
		}
		CardData defaultTarget = base.GetDefaultTarget();
		if (defaultTarget == null)
		{
			yield break;
		}
		base.ShowMe();
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, defaultTarget, Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), 0.2f, false, 0, null, null);
		yield break;
	}

	public override void RemakeSkillEffect()
	{
		this.SkillEffect = "捶胸大吼释放";
	}

	private float baseDmg = 3f;

	private float increaseDmg = 1f;
}
