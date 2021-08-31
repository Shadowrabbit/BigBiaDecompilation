using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class TutorialAct : GameAct
{
	private void Start()
	{
		this.Init();
		base.StartCoroutine(this.GetEnemiesAndFlyToBattleArea());
	}

	private void Update()
	{
	}

	public virtual IEnumerator GetEnemiesAndFlyToBattleArea()
	{
		UIController.LockLevel = UIController.UILevel.All;
		string terrainType = "";
		AreaData areaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId];
		List<CardSlotData> cardSlotDatas = areaData.CardSlotDatas;
		SpaceAreaData spaceAreaData = areaData as SpaceAreaData;
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		int num = 0;
		for (int j = 0; j < cardSlotDatas.Count; j++)
		{
			if (cardSlotDatas[j].ChildCardData != null && cardSlotDatas[j].ChildCardData.HasTag(TagMap.地形) && cardSlotDatas[j].ChildCardData.Attrs.ContainsKey("Terrain"))
			{
				dictionary.Add(j, cardSlotDatas[j].ChildCardData.GetAttr("Terrain"));
			}
			if (cardSlotDatas[j].ChildCardData != null && cardSlotDatas[j].ChildCardData == this.Source.CardData)
			{
				num = j;
			}
		}
		foreach (KeyValuePair<int, string> keyValuePair in dictionary)
		{
			int num2 = (num % spaceAreaData.CardSlotGridWidth - 1 < 0) ? 0 : (num % spaceAreaData.CardSlotGridWidth - 1);
			int num3 = (num % spaceAreaData.CardSlotGridWidth + 1 > spaceAreaData.CardSlotGridWidth) ? spaceAreaData.CardSlotGridWidth : (num % spaceAreaData.CardSlotGridWidth + 1);
			int num4 = (num / spaceAreaData.CardSlotGridWidth - 1 < 0) ? 0 : (num / spaceAreaData.CardSlotGridWidth - 1);
			int num5 = (num / spaceAreaData.CardSlotGridWidth + 1 > spaceAreaData.CardSlotGridHeight) ? spaceAreaData.CardSlotGridHeight : (num / spaceAreaData.CardSlotGridWidth + 1);
			if (keyValuePair.Key % spaceAreaData.CardSlotGridWidth >= num2 && keyValuePair.Key % spaceAreaData.CardSlotGridWidth <= num3 && keyValuePair.Key / spaceAreaData.CardSlotGridWidth >= num4 && keyValuePair.Key / spaceAreaData.CardSlotGridWidth <= num5)
			{
				terrainType = keyValuePair.Value;
				DungeonOperationMgr.Instance.CurrentTerrain = terrainType;
				break;
			}
		}
		DungeonTheme dungeonTheme = DungeonTheme.Tutorial;
		EncounterType encounterType = (EncounterType)Enum.Parse(typeof(EncounterType), this.Source.CardData.Attrs["EncounterType"].ToString());
		int enemyCount = int.Parse(this.Source.CardData.GetAttr("EnemyCount"));
		int enemyDifficult = int.Parse(this.Source.CardData.GetAttr("EnemyDifficult"));
		List<EnemyConfigBean> enemyConfigBeans = GlobalController.Instance.GetEnemyConfig().EnemyConfigBeans;
		enemyConfigBeans.GetRange(0, 3);
		enemyConfigBeans.GetRange(3, enemyConfigBeans.Count - 3);
		List<string> enemyIdList = new List<string>();
		List<CardData> allEnemies = new List<CardData>();
		List<CardData> allStartEnemies = new List<CardData>();
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if ((cardData.GetAttr("Theme").Equals(dungeonTheme.ToString()) || cardData.GetAttr("Theme").Equals("Normal")) && cardData.HasTag(TagMap.怪物) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.特殊) && !cardData.HasTag(TagMap.BOSS))
			{
				if (cardData.Level < 2)
				{
					if (cardData.GetAttr("Start") != "")
					{
						allStartEnemies.Add(cardData);
					}
					allEnemies.Add(cardData);
				}
				else
				{
					list.Add(cardData);
				}
			}
		}
		List<CardData> checkedEnemies = new List<CardData>();
		float waitTime = 0.2f;
		float radians = 0.017453292f * Mathf.Round((float)(360 / enemyCount));
		float r = 1.25f;
		int num10;
		switch (encounterType)
		{
		case EncounterType.RANDOM:
			for (int i = 0; i < enemyCount; i = num10 + 1)
			{
				CardData cardDataByModID;
				if (GameController.ins.GameData.level == 1 && enemyDifficult <= 3)
				{
					cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID(allStartEnemies[UnityEngine.Random.Range(0, allStartEnemies.Count)].ModID);
				}
				else
				{
					cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID(allEnemies[UnityEngine.Random.Range(0, allEnemies.Count)].ModID);
				}
				CardData cardData2 = CardData.CopyCardData(cardDataByModID, true);
				Card.InitCard(cardData2);
				cardData2.CardGameObject.transform.position = this.Source.transform.position;
				float num6 = Mathf.Sin(radians * (float)i) * r;
				float num7 = Mathf.Cos(radians * (float)i) * r;
				cardData2.CardGameObject.transform.DOLocalMove(new Vector3(this.Source.transform.position.x + num6, this.Source.transform.position.y, this.Source.transform.position.z + num7), waitTime, false).SetEase(Ease.OutBack);
				int num8 = GameController.ins.GameData.level - 1;
				int num9 = enemyDifficult * enemyDifficult;
				int atk = GameController.getInstance().CardDataModMap.getCardDataByModID(cardData2.ModID).ATK;
				float datk = GameController.getInstance().CardDataModMap.getCardDataByModID(cardData2.ModID).DATK;
				int maxHP = GameController.getInstance().CardDataModMap.getCardDataByModID(cardData2.ModID).MaxHP;
				float dhp = GameController.getInstance().CardDataModMap.getCardDataByModID(cardData2.ModID).DHP;
				int armor = GameController.getInstance().CardDataModMap.getCardDataByModID(cardData2.ModID).Armor;
				float darmor = GameController.getInstance().CardDataModMap.getCardDataByModID(cardData2.ModID).DArmor;
				cardData2._ATK = Mathf.CeilToInt(((float)num9 * ((float)atk * DungeonOperationMgr.Instance.TotalDATK) + (float)atk * 0.15f * (float)enemyDifficult + (float)atk) * DungeonOperationMgr.Instance.TotalATK / (float)enemyCount);
				cardData2.MaxHP = (cardData2.HP = Mathf.CeilToInt(((float)num9 * ((float)maxHP * DungeonOperationMgr.Instance.TotalDHp) + (float)maxHP * 1.85f * (float)enemyDifficult + (float)maxHP) * DungeonOperationMgr.Instance.TotalHp / (float)enemyCount));
				cardData2.MaxArmor = (cardData2.Armor = ((armor > 0) ? (armor + num8 / 2) : 0));
				cardData2.Price = UnityEngine.Random.Range(Mathf.CeilToInt((float)(10 / enemyCount - 1)), Mathf.CeilToInt((float)(10 / enemyCount + 2))) * 2;
				this.AddLogicByTerrainToEnemy(terrainType, cardData2);
				checkedEnemies.Add(cardData2);
				yield return new WaitForSeconds(waitTime);
				num10 = i;
			}
			break;
		case EncounterType.CUSTOM:
		{
			DungeonOperationMgr.Instance.CurrentBattleDifficult = enemyDifficult;
			switch (enemyDifficult)
			{
			case 2:
				enemyIdList = new List<string>
				{
					"史莱姆弟弟",
					null,
					null,
					"史莱姆弟弟",
					null,
					null,
					null,
					null,
					null
				};
				break;
			case 3:
				enemyIdList = new List<string>
				{
					null,
					null,
					"死神学弟",
					null,
					null,
					null,
					"死神学弟",
					null,
					null
				};
				break;
			case 4:
				enemyIdList = new List<string>
				{
					null,
					null,
					null,
					"死神学长",
					null,
					"死神学长",
					null,
					null,
					null
				};
				break;
			}
			int ec = 0;
			foreach (string text in enemyIdList)
			{
				if (text != null && !string.IsNullOrEmpty(text))
				{
					ec++;
				}
			}
			radians = 0.017453292f * Mathf.Round((float)(360 / ec));
			r = 1.25f;
			for (int i = 0; i < 9; i = num10 + 1)
			{
				if (string.IsNullOrEmpty(enemyIdList[i]))
				{
					checkedEnemies.Add(null);
				}
				else
				{
					CardData cardData3 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(enemyIdList[i]), true);
					Card.InitCard(cardData3);
					cardData3.CardGameObject.transform.position = this.Source.transform.position;
					float num11 = Mathf.Sin(radians * (float)ec) * r;
					float num12 = Mathf.Cos(radians * (float)ec) * r;
					cardData3.CardGameObject.transform.DOLocalMove(new Vector3(this.Source.transform.position.x + num11, this.Source.transform.position.y, this.Source.transform.position.z + num12), waitTime, false).SetEase(Ease.OutBack);
					num10 = ec;
					ec = num10 - 1;
					int level = GameController.ins.GameData.level;
					this.AddLogicByTerrainToEnemy(terrainType, cardData3);
					checkedEnemies.Add(cardData3);
					yield return new WaitForSeconds(waitTime);
				}
				num10 = i;
			}
			break;
		}
		}
		for (int ec = 0; ec < checkedEnemies.Count; ec = num10 + 1)
		{
			if (encounterType == EncounterType.CUSTOM && checkedEnemies[ec] != null)
			{
				yield return DungeonOperationMgr.Instance.MonsterJumpToBattleAreaInWorld(checkedEnemies[ec], ec, true);
			}
			else
			{
				yield return DungeonOperationMgr.Instance.MonsterJumpToBattleArea(checkedEnemies[ec], true);
			}
			num10 = ec;
		}
		this.Source.CardData.DeleteCardData();
		UIController.LockLevel = UIController.UILevel.None;
		if (this.Source != null && this.Source.CardData != null && this.Source.CardData.CardLogics != null)
		{
			foreach (CardLogic cardLogic in this.Source.CardData.CardLogics)
			{
				cardLogic.OnActEnd();
			}
		}
		foreach (AreaLogic areaLogic in GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData.Logics)
		{
			areaLogic.OnActEnd();
		}
		DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.StartBattle(false));
		yield break;
	}

	private void AddLogicByTerrainToEnemy(string terrainType, CardData enemy)
	{
		if (terrainType != null && terrainType == "Poison")
		{
			CardLogic cardLogic = Activator.CreateInstance(Type.GetType("EnemyPoisonTerrainLogic")) as CardLogic;
			cardLogic.Init();
			cardLogic.CardData = enemy;
			enemy.CardLogics.Add(cardLogic);
			cardLogic.OnMerge(enemy);
		}
	}
}
