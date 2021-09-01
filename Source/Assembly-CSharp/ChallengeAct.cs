using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class ChallengeAct : GameAct
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
		DungeonTheme dungeonTheme = GameController.ins.GameData.DungeonTheme;
		EncounterType encounterType = (EncounterType)Enum.Parse(typeof(EncounterType), this.Source.CardData.Attrs["EncounterType"].ToString());
		int enemyDifficult = int.Parse(this.Source.CardData.GetAttr("EnemyDifficult"));
		DungeonOperationMgr.Instance.EnemyDifficult = enemyDifficult;
		List<EnemyConfigBean> enemyConfigBeans = GlobalController.Instance.GetEnemyConfig().EnemyConfigBeans;
		List<EnemyConfigBean> list = new List<EnemyConfigBean>();
		List<EnemyConfigBean> list2 = new List<EnemyConfigBean>();
		EnemyConfigBean enemyConfigBean = new EnemyConfigBean();
		foreach (EnemyConfigBean enemyConfigBean2 in enemyConfigBeans)
		{
			if ((DungeonTheme)Enum.Parse(typeof(DungeonTheme), enemyConfigBean2.EnemyTheme) == dungeonTheme || (DungeonTheme)Enum.Parse(typeof(DungeonTheme), enemyConfigBean2.EnemyTheme) == DungeonTheme.Normal)
			{
				if (enemyConfigBean2.IsElite == "True")
				{
					list2.Add(enemyConfigBean2);
				}
				else
				{
					list.Add(enemyConfigBean2);
				}
			}
		}
		List<string> enemyIdList = enemyConfigBean.EnemiesModID;
		List<CardData> list3 = new List<CardData>();
		List<CardData> list4 = new List<CardData>();
		List<CardData> list5 = new List<CardData>();
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if ((cardData.GetAttr("Theme").Equals(dungeonTheme.ToString()) || cardData.GetAttr("Theme").Equals("Normal")) && cardData.HasTag(TagMap.怪物) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.特殊) && !cardData.HasTag(TagMap.BOSS))
			{
				if (cardData.Level < 2)
				{
					if (cardData.GetAttr("Start") != "")
					{
						list4.Add(cardData);
					}
					list3.Add(cardData);
				}
				else
				{
					list5.Add(cardData);
				}
			}
		}
		List<CardData> checkedEnemies = new List<CardData>();
		float waitTime = 0.2f;
		float r = 1.25f;
		int num6;
		if (encounterType == EncounterType.CUSTOM)
		{
			DungeonOperationMgr.Instance.CurrentBattleDifficult = enemyDifficult;
			num6 = enemyDifficult;
			if (num6 != 1)
			{
				if (num6 == 3)
				{
					enemyIdList = new List<string>
					{
						null,
						null,
						null,
						"囍字",
						"哈迪",
						"CrapTears",
						null,
						"西蒙",
						null
					};
				}
			}
			else
			{
				enemyIdList = new List<string>
				{
					"机组成员",
					null,
					"机组成员",
					null,
					null,
					null,
					"机组成员",
					null,
					null
				};
			}
			int ec = 0;
			foreach (string text in enemyIdList)
			{
				if (text != null && !string.IsNullOrEmpty(text))
				{
					ec++;
				}
			}
			float radians = 0.017453292f * Mathf.Round((float)(360 / ec));
			r = 1.25f;
			for (int i = 0; i < 9; i = num6 + 1)
			{
				if (string.IsNullOrEmpty(enemyIdList[i]))
				{
					checkedEnemies.Add(null);
				}
				else
				{
					CardData cardData2 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(enemyIdList[i]), true);
					Card.InitCard(cardData2);
					cardData2.CardGameObject.transform.position = this.Source.transform.position;
					float num7 = Mathf.Sin(radians * (float)ec) * r;
					float num8 = Mathf.Cos(radians * (float)ec) * r;
					cardData2.CardGameObject.transform.DOLocalMove(new Vector3(this.Source.transform.position.x + num7, this.Source.transform.position.y, this.Source.transform.position.z + num8), waitTime, false).SetEase(Ease.OutBack);
					num6 = ec;
					ec = num6 - 1;
					int level = GameController.ins.GameData.level;
					this.AddLogicByTerrainToEnemy(terrainType, cardData2);
					checkedEnemies.Add(cardData2);
					yield return new WaitForSeconds(waitTime);
				}
				num6 = i;
			}
		}
		for (int ec = 0; ec < checkedEnemies.Count; ec = num6 + 1)
		{
			if (encounterType == EncounterType.CUSTOM && checkedEnemies[ec] != null)
			{
				yield return DungeonOperationMgr.Instance.MonsterJumpToBattleAreaInWorld(checkedEnemies[ec], ec, true);
			}
			else
			{
				yield return DungeonOperationMgr.Instance.MonsterJumpToBattleArea(checkedEnemies[ec], true);
			}
			num6 = ec;
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
