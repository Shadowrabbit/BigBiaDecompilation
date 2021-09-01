using System;
using System.Collections;
using UnityEngine;

public class TiaoJiuShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(1, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_来一杯吗");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_来一杯吗"), base.Layers + 3);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_来一杯吗");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_来一杯吗"), base.Layers + 3);
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
		yield return base.ShowCustomEffect("毒药释放", this.CardData.CurrentCardSlotData, 0.5f);
		int num = SYNCRandom.Range(0, 101);
		int num2 = SYNCRandom.Range(1, 3);
		ParticlePoolManager.Instance.Spawn("Effect/毒药命中", 0.5f).transform.position = target.CurrentCardSlotData.CardSlotGameObject.transform.position;
		if (num <= 15)
		{
			target.AddAffix(DungeonAffix.poisoning, base.Layers + 3);
			target.AddAffix(DungeonAffix.weak, base.Layers + 3);
		}
		else if (num2 != 1)
		{
			if (num2 == 2)
			{
				target.AddAffix(DungeonAffix.weak, base.Layers + 3);
			}
		}
		else
		{
			target.AddAffix(DungeonAffix.poisoning, base.Layers + 3);
		}
		yield break;
	}
}
