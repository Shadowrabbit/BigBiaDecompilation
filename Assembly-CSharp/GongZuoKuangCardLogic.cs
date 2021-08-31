using System;
using System.Collections;
using UnityEngine;

public class GongZuoKuangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_14");
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_14_1"),
			Mathf.CeilToInt((float)this.CardData.MaxHP * 0.15f).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_14_1"),
			Mathf.CeilToInt((float)this.CardData.ATK * (0.75f + 0.25f * (float)base.Layers)).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_14_1"),
			(75 + 25 * base.Layers).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_14_1")
		});
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_14");
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_14_1"),
			Mathf.CeilToInt((float)this.CardData.MaxHP * 0.15f).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_14_1"),
			Mathf.CeilToInt((float)this.CardData.ATK * (0.75f + 0.25f * (float)base.Layers)).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_14_1"),
			(75 + 25 * base.Layers).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_14_1")
		});
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		if (base.GetEnemiesBattleArea() == null)
		{
			yield break;
		}
		CardData t = base.GetDefaultTarget();
		if (t == null)
		{
			yield break;
		}
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, this.CardData, Mathf.CeilToInt((float)this.CardData.MaxHP * 0.15f), 0.2f, false, 0, null, null);
		if (DungeonOperationMgr.Instance.CheckCardDead(this.CardData))
		{
			yield break;
		}
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, t, Mathf.CeilToInt((float)this.CardData.ATK * (0.75f + 0.25f * (float)base.Layers)), 0.2f, false, 0, null, null);
		yield break;
	}
}
