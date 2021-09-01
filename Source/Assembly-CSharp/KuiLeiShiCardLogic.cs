using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuiLeiShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(2, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_死亡契约");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_死亡契约"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_死亡契约");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_死亡契约"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
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
		string monsterId = t.ModID;
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, t, Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), 0.2f, false, 0, null, null);
		if (DungeonOperationMgr.Instance.CheckCardDead(t))
		{
			List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
			if (allEmptySlotsInMyBattleArea.Count == 0)
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_空间不够了"));
				yield break;
			}
			CardData cardData = Card.InitCardDataByID(LocalizationMgr.Instance.GetLocalizationWord("傀儡"));
			CardData cardDataByModID = base.GameController.CardDataModMap.getCardDataByModID(monsterId);
			cardData._ATK = cardDataByModID._ATK;
			cardData.MaxArmor = (cardData.Armor = cardDataByModID.MaxArmor);
			base.ShowMe();
			CardSlotData cardSlotData = allEmptySlotsInMyBattleArea[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea.Count)];
			ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = cardSlotData.CardSlotGameObject.transform.position;
			cardData.PutInSlotData(cardSlotData, true);
		}
		yield break;
	}

	private float baseDmg = 0.75f;

	private float increaseDmg = 0.25f;
}
