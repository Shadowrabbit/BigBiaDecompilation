using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CardLogicRequireRare(4)]
public class LieRen2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_167");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_167");
		this.NeedEnergyCount = new Vector3Int(2, 0, 0);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_167");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_167");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		foreach (CardSlotData cardSlotData in base.GetMyBattleArea())
		{
			if (cardSlotData.ChildCardData == null)
			{
				int num = SYNCRandom.Range(0, 3);
				if (num == 0)
				{
					CardData cardData = Card.InitCardDataByID("鹿");
					cardData.CardTags = 524416UL;
					MinionLogic minionLogic = new MinionLogic();
					minionLogic.CardData = cardData;
					cardData.CardLogics = new List<CardLogic>();
					cardData.CardLogics.Add(minionLogic);
					minionLogic.Init();
					ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = cardSlotData.CardSlotGameObject.transform.position;
					cardData.PutInSlotData(cardSlotData, true);
				}
				if (num == 1)
				{
					CardData cardData2 = Card.InitCardDataByID("黑狼");
					cardData2.CardTags = 524416UL;
					cardData2.MaxArmor = (cardData2.Armor = 0);
					MinionLogic minionLogic2 = new MinionLogic();
					minionLogic2.CardData = cardData2;
					cardData2.CardLogics = new List<CardLogic>();
					cardData2.CardLogics.Add(minionLogic2);
					minionLogic2.Init();
					cardData2.PutInSlotData(cardSlotData, true);
					ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = cardSlotData.CardSlotGameObject.transform.position;
				}
				if (num == 2)
				{
					CardData cardData3 = Card.InitCardDataByID("巨熊");
					cardData3.CardTags = 524416UL;
					MinionLogic minionLogic3 = new MinionLogic();
					minionLogic3.CardData = cardData3;
					cardData3.CardLogics = new List<CardLogic>();
					cardData3.CardLogics.Add(minionLogic3);
					minionLogic3.Init();
					cardData3.PutInSlotData(cardSlotData, true);
					ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = cardSlotData.CardSlotGameObject.transform.position;
					break;
				}
				break;
			}
		}
		this.CardData.IsAttacked = true;
		yield break;
	}
}
