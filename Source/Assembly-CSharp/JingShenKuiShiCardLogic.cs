using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JingShenKuiShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_克总9");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_克总9"), base.Layers + 1);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_克总9");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_克总9"), base.Layers + 1);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			yield break;
		}
		List<EnergyUI.EnergyType> energys = new List<EnergyUI.EnergyType>();
		int energyCount = GameController.ins.GameData.GetEnergyCount(EnergyUI.EnergyType.Yellow);
		if (energyCount > 0)
		{
			for (int j = 0; j < energyCount; j++)
			{
				energys.Add(EnergyUI.EnergyType.Yellow);
			}
		}
		energyCount = GameController.ins.GameData.GetEnergyCount(EnergyUI.EnergyType.Blue);
		if (energyCount > 0)
		{
			for (int k = 0; k < energyCount; k++)
			{
				energys.Add(EnergyUI.EnergyType.Blue);
			}
		}
		energyCount = GameController.ins.GameData.GetEnergyCount(EnergyUI.EnergyType.Red);
		if (energyCount > 0)
		{
			for (int l = 0; l < energyCount; l++)
			{
				energys.Add(EnergyUI.EnergyType.Red);
			}
		}
		if (energys.Count > 0)
		{
			base.ShowMe();
			int i = 0;
			while (i < energys.Count && i <= base.Layers && energys.Count > 0)
			{
				EnergyUI.EnergyType t = energys[SYNCRandom.Range(0, energys.Count)];
				yield return GameController.ins.UIController.EnergyUI.RemoveEnergy(t, this.CardData.CardGameObject.transform);
				yield return new WaitForSeconds(0.3f);
				switch (t)
				{
				case EnergyUI.EnergyType.Blue:
					for (int m = 0; m < 2; m++)
					{
						List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
						CardSlotData cardSlotData = allEmptySlotsInMyBattleArea[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea.Count)];
						CardData cardData = Card.InitCardDataByID("克苏鲁触手");
						cardData = DungeonOperationMgr.Instance.InitDungeonMonster(cardData, 25);
						cardData.PutInSlotData(cardSlotData, true);
						string name = "Effect/WaterBall";
						ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = cardSlotData.ChildCardData.CardGameObject.transform.position;
					}
					break;
				case EnergyUI.EnergyType.Red:
					for (int n = 0; n < 1; n++)
					{
						List<CardSlotData> allEmptySlotsInMyBattleArea2 = base.GetAllEmptySlotsInMyBattleArea();
						CardSlotData cardSlotData2 = allEmptySlotsInMyBattleArea2[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea2.Count)];
						CardData cardData2 = Card.InitCardDataByID("克苏鲁触手");
						cardData2 = DungeonOperationMgr.Instance.InitDungeonMonster(cardData2, 25);
						cardData2._ATK = Mathf.CeilToInt((float)cardData2._ATK * 1.5f);
						cardData2.MaxHP = (cardData2.HP = Mathf.CeilToInt((float)cardData2.MaxHP * 0.5f));
						cardData2.MaxArmor = (cardData2.Armor = 2);
						cardData2.PutInSlotData(cardSlotData2, true);
						string name2 = "Effect/WaterBall";
						ParticlePoolManager.Instance.Spawn(name2, 3f).transform.position = cardSlotData2.ChildCardData.CardGameObject.transform.position;
					}
					break;
				case EnergyUI.EnergyType.Yellow:
					for (int num = 0; num < 1; num++)
					{
						List<CardSlotData> allEmptySlotsInMyBattleArea3 = base.GetAllEmptySlotsInMyBattleArea();
						CardSlotData cardSlotData3 = allEmptySlotsInMyBattleArea3[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea3.Count)];
						CardData cardData3 = Card.InitCardDataByID("克苏鲁触手");
						cardData3 = DungeonOperationMgr.Instance.InitDungeonMonster(cardData3, 25);
						cardData3.MaxHP = (cardData3.HP = Mathf.CeilToInt((float)cardData3.MaxHP * 1.5f));
						cardData3.PutInSlotData(cardSlotData3, true);
						string name3 = "Effect/WaterBall";
						ParticlePoolManager.Instance.Spawn(name3, 3f).transform.position = cardSlotData3.ChildCardData.CardGameObject.transform.position;
					}
					break;
				}
				int num2 = i;
				i = num2 + 1;
			}
		}
		yield break;
	}
}
