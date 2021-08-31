using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class EncounterMinionInnerAct : GameAct
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
				string value = keyValuePair.Value;
				DungeonOperationMgr.Instance.CurrentTerrain = value;
				break;
			}
		}
		DungeonTheme dungeonTheme = GameController.ins.GameData.DungeonTheme;
		EncounterType encounterType = (EncounterType)Enum.Parse(typeof(EncounterType), this.Source.CardData.Attrs["EncounterType"].ToString());
		int.Parse(this.Source.CardData.GetAttr("EnemyCount"));
		int num6 = int.Parse(this.Source.CardData.GetAttr("EnemyDifficult"));
		List<EnemyConfigBean> enemyConfigBeans = GlobalController.Instance.GetEnemyConfig().EnemyConfigBeans;
		List<EnemyConfigBean> list = new List<EnemyConfigBean>();
		List<EnemyConfigBean> list2 = new List<EnemyConfigBean>();
		EnemyConfigBean item = new EnemyConfigBean();
		foreach (EnemyConfigBean enemyConfigBean in enemyConfigBeans)
		{
			if ((DungeonTheme)Enum.Parse(typeof(DungeonTheme), enemyConfigBean.EnemyTheme) == dungeonTheme || (DungeonTheme)Enum.Parse(typeof(DungeonTheme), enemyConfigBean.EnemyTheme) == DungeonTheme.Normal)
			{
				if (enemyConfigBean.IsElite == "True")
				{
					list2.Add(enemyConfigBean);
				}
				else
				{
					list.Add(enemyConfigBean);
				}
			}
		}
		List<EnemyConfigBean> range = list.GetRange(0, 1);
		List<EnemyConfigBean> range2 = list.GetRange(1, list.Count - 1);
		if (encounterType == EncounterType.ELITE)
		{
			item = list2[SYNCRandom.Range(0, list2.Count)];
		}
		else if (GameController.ins.GameData.level != 1 || num6 >= 2)
		{
			item = range2[SYNCRandom.Range(0, range2.Count)];
			int num7 = 0;
			while (EncounterMinionInnerAct.CollapseiEnemySet.Contains(item))
			{
				item = range2[SYNCRandom.Range(0, range2.Count)];
				if (++num7 > 100)
				{
					break;
				}
			}
			range2.Remove(item);
		}
		else
		{
			item = range[SYNCRandom.Range(0, range.Count)];
			range.Remove(item);
		}
		List<CardData> list3 = new List<CardData>();
		List<CardData> list4 = new List<CardData>();
		List<CardData> list5 = new List<CardData>();
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if (cardData.HasTag(TagMap.怪物) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.特殊) && !cardData.HasTag(TagMap.BOSS))
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
		List<string> enemyIdList = new List<string>();
		int num8 = SYNCRandom.Range(6, 8);
		for (int k = 0; k < 9; k++)
		{
			enemyIdList.Add(list3[SYNCRandom.Range(0, list3.Count)].ModID);
		}
		int l = 0;
		while (l < num8)
		{
			int index = SYNCRandom.Range(0, enemyIdList.Count);
			if (enemyIdList[index] != null)
			{
				enemyIdList[index] = null;
				l++;
			}
		}
		List<CardData> checkedEnemies = new List<CardData>();
		float waitTime = 0.2f;
		int ec = 0;
		foreach (string text in enemyIdList)
		{
			if (text != null && !string.IsNullOrEmpty(text))
			{
				ec++;
			}
		}
		float radians = 0.017453292f * Mathf.Round((float)(360 / ec));
		float r = 1.25f;
		int num11;
		for (int i = 0; i < 9; i = num11 + 1)
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
				float num9 = Mathf.Sin(radians * (float)ec) * r;
				float num10 = Mathf.Cos(radians * (float)ec) * r;
				cardData2.CardGameObject.transform.DOLocalMove(new Vector3(this.Source.transform.position.x + num9, this.Source.transform.position.y, this.Source.transform.position.z + num10), waitTime, false).SetEase(Ease.OutBack);
				num11 = ec;
				ec = num11 - 1;
				int level = GameController.ins.GameData.level;
				cardData2 = DungeonOperationMgr.Instance.InitDungeonMonster(cardData2, GameController.ins.GameData.InnerMinionCardData.Rare);
				if (cardData2.HP < 1)
				{
					cardData2.HP = 1;
				}
				checkedEnemies.Add(cardData2);
				yield return new WaitForSeconds(waitTime);
			}
			num11 = i;
		}
		for (int i = 0; i < checkedEnemies.Count; i = num11 + 1)
		{
			if (checkedEnemies[i] != null)
			{
				yield return DungeonOperationMgr.Instance.MonsterJumpToBattleAreaInWorld(checkedEnemies[i], i, true);
			}
			else
			{
				yield return DungeonOperationMgr.Instance.MonsterJumpToBattleArea(checkedEnemies[i], true);
			}
			num11 = i;
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
		yield return DungeonOperationMgr.Instance.StartBattle(false);
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

	public static HashSet<EnemyConfigBean> CollapseiEnemySet = new HashSet<EnemyConfigBean>();
}
