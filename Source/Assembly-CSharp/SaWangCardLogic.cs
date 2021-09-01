using System;
using System.Collections;
using UnityEngine;

public class SaWangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_麻痹箭");
		this.NeedEnergyCount = new Vector3Int(0, 0, 1);
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_麻痹箭"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_麻痹箭");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_麻痹箭"), base.Layers);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		base.ShowMe();
		this.CardData.IsAttacked = true;
		if (base.GetEnemiesBattleArea() == null)
		{
			yield break;
		}
		CardData t = base.GetDefaultTarget();
		if (t == null)
		{
			yield break;
		}
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, t, 0, 0.2f, false, 0, null, null);
		t.AddAffix(DungeonAffix.frail, base.Layers);
		if (!t.HasTag(TagMap.BOSS) && t.DizzyLayer == 0)
		{
			t.DizzyLayer++;
		}
		yield break;
	}

	public override void RemakeSkillEffect()
	{
		this.SkillEffect = "撒网释放";
	}
}
