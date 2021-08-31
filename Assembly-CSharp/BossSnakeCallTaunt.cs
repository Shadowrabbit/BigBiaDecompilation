using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSnakeCallTaunt : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇5");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇5");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇5");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇5");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			this.rounds++;
			List<CardSlotData> battleArea = DungeonOperationMgr.Instance.BattleArea;
			if (this.rounds % 3 == 0)
			{
				for (int i = 0; i < 2; i++)
				{
					List<CardSlotData> list = new List<CardSlotData>();
					foreach (CardSlotData cardSlotData in battleArea)
					{
						if (cardSlotData.ChildCardData == null)
						{
							list.Add(cardSlotData);
						}
					}
					if (list.Count <= 0)
					{
						break;
					}
					int index = UnityEngine.Random.Range(0, list.Count);
					int num = UnityEngine.Random.Range(0, 1);
					string modId = "";
					switch (num)
					{
					case 0:
						modId = "仙人球";
						break;
					case 1:
						modId = "沙虫";
						break;
					case 2:
						modId = "乌鸦";
						break;
					case 3:
						modId = "阳炎";
						break;
					}
					CardData cardData = Card.InitCardDataByID(modId);
					cardData.HP = (cardData.MaxHP = SYNCRandom.Range(35, 51));
					cardData._ATK = SYNCRandom.Range(5, 11);
					cardData.Armor = (cardData.MaxArmor = SYNCRandom.Range(0, 3));
					cardData.PutInSlotData(list[index], true);
				}
			}
		}
		yield break;
	}

	private int rounds;
}
