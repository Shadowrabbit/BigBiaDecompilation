using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CardLogicRequireRare(4)]
public class KuiLeiShiSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(5, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_借尸还魂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_借尸还魂");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(5, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_借尸还魂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_借尸还魂");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		if (allCurrentMinions.Count == 0)
		{
			yield break;
		}
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in GameController.ins.GameData.DeadMinionsList)
		{
			if (!cardData.HasTag(TagMap.英雄) && !cardData.HasTag(TagMap.衍生物))
			{
				cardData.HP = 1;
				cardData.IsAttacked = false;
				list.Add(cardData);
			}
		}
		if (list.Count == 0)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_没有需要复活"));
			yield break;
		}
		List<CardData> list2 = new List<CardData>();
		foreach (CardData cardData2 in allCurrentMinions)
		{
			if (cardData2.ModID == "傀儡")
			{
				list2.Add(cardData2);
			}
		}
		if (list2.Count == 0)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_先召唤一个傀儡吧"));
			yield break;
		}
		CardData cardData3 = list2[SYNCRandom.Range(0, list2.Count)];
		CardSlotData currentCardSlotData = cardData3.CurrentCardSlotData;
		cardData3.DeleteCardData();
		CardData cardData4 = list[SYNCRandom.Range(0, list.Count)];
		base.ShowMe();
		ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = currentCardSlotData.CardSlotGameObject.transform.position;
		cardData4.PutInSlotData(currentCardSlotData, true);
		GameController.ins.GameData.DeadMinionsList.Remove(cardData4);
		yield break;
	}
}
