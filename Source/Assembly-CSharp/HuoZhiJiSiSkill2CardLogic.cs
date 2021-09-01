using System;
using System.Collections;
using UnityEngine;

[CardLogicRequireRare(4)]
public class HuoZhiJiSiSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(4, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_135");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_135");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(4, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_135");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_135");
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
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, defaultTarget, Mathf.CeilToInt((float)(this.CardData.ATK * 10)), 0.2f, false, 0, null, null);
		yield break;
	}
}
