using System;
using System.Collections;
using UnityEngine;

public class MaoShanDaoShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(1, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_天雷咒");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_天雷咒"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), Mathf.CeilToInt((this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f), this.baseChance + this.increaseChance * (float)base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_天雷咒");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_天雷咒"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), Mathf.CeilToInt((this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f), this.baseChance + this.increaseChance * (float)base.Layers);
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
		base.GetChainLighting(target.CardGameObject.transform.position + new Vector3(0f, 3f, 0f), target.CardGameObject.transform.position, 1);
		yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(target, -Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), this.CardData, false, 0, true, false);
		if (DungeonOperationMgr.Instance.CheckCardDead(target) || target.HasTag(TagMap.BOSS))
		{
			yield break;
		}
		if ((float)SYNCRandom.Range(0, 101) < this.baseChance + this.increaseChance * (float)base.Layers)
		{
			target.DizzyLayer = 1;
		}
		yield break;
	}

	private float baseDmg = 0.75f;

	private float increaseDmg = 0.25f;

	private float baseChance = 50f;

	private float increaseChance = 10f;
}
