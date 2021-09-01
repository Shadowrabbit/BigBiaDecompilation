using System;
using System.Collections;
using UnityEngine;

[CardLogicRequireRare(4)]
public class ZhangSanFengSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.NeedEnergyCount = new Vector3Int(1, 1, 1);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_借力打力");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_借力打力");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(1 - base.Layers, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_借力打力");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_借力打力");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		CardData target = base.GetDefaultTarget();
		if (target == null || DungeonOperationMgr.Instance.CheckCardDead(target))
		{
			yield break;
		}
		base.ShowMe();
		int num;
		for (int i = 0; i < this.CardData.AttackTimes + target.AttackTimes; i = num + 1)
		{
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, target, this.CardData.ATK + target.ATK, 0.2f, false, 0, null, null);
			num = i;
		}
		yield break;
	}
}
