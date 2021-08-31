using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CardLogicRequireRare(4)]
public class SiLingFaShiSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.NeedEnergyCount = new Vector3Int(4, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_亡灵大军");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_亡灵大军");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_亡灵大军");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_亡灵大军");
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		this.canUse = true;
		yield break;
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		if (!this.canUse)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_已经使用过了"));
			yield break;
		}
		this.CardData.IsAttacked = true;
		this.canUse = false;
		List<CardData> list = new List<CardData>();
		if (base.GetLogic(this.CardData, typeof(SiLingFaShiCardLogic)) != null)
		{
			list = (base.GetLogic(this.CardData, typeof(SiLingFaShiCardLogic)) as SiLingFaShiCardLogic).getMinions();
		}
		if (list.Count == 0)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_从没召唤过仆从"));
			yield break;
		}
		for (int i = list.Count - 1; i >= 0; i--)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			CardData cardData = list[i];
			if (!allCurrentMinions.Contains(cardData))
			{
				List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
				if (allEmptySlotsInMyBattleArea.Count == 0)
				{
					base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_空间不够了"));
					yield break;
				}
				cardData.MaxHP = (cardData.HP = 1);
				base.ShowMe();
				CardSlotData cardSlotData = allEmptySlotsInMyBattleArea[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea.Count)];
				ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = cardSlotData.CardSlotGameObject.transform.position;
				cardData.PutInSlotData(cardSlotData, true);
			}
		}
		yield break;
	}

	private bool canUse = true;
}
