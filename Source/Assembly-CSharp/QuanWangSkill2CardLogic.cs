using System;
using System.Collections;
using UnityEngine;

[CardLogicRequireRare(4)]
public class QuanWangSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.NeedEnergyCount = new Vector3Int(0, 2, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_狂风骤雨");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_狂风骤雨"), this.CardData.AttackTimes, this.CardData.ATK);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(0, 2, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_狂风骤雨");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_狂风骤雨"), this.CardData.AttackTimes, this.CardData.ATK);
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
		int num;
		for (int i = 0; i < this.CardData.ATK; i = num + 1)
		{
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, target, this.CardData.AttackTimes, 0.2f, false, 0, null, null);
			num = i;
		}
		yield break;
	}
}
