using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class EncounterAct : GameAct
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
		int enemyDifficult = int.Parse(this.Source.CardData.GetAttr("EnemyDifficult"));
		int BattleLevel = 0;
		if (this.Source.CardData.Attrs.ContainsKey("BattleLevel"))
		{
			DungeonController.Instance.BattleLevel = (BattleLevel = int.Parse(this.Source.CardData.GetAttr("BattleLevel")));
		}
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
		enemyConfigBean = list[SYNCRandom.Range(0, list.Count)];
		int num6 = 0;
		while (EncounterAct.CollapseiEnemySet.Contains(enemyConfigBean))
		{
			enemyConfigBean = list[SYNCRandom.Range(0, list.Count)];
			if (++num6 > 200)
			{
				break;
			}
		}
		list.Remove(enemyConfigBean);
		if (GameController.ins.GameData.Agreenment >= 4 && SYNCRandom.Range(0, 100) < 30 && list2.Count > 0)
		{
			enemyConfigBean = list2[SYNCRandom.Range(0, list2.Count)];
		}
		List<string> enemyIdList = enemyConfigBean.EnemiesModID;
		List<CardData> allEnemies = new List<CardData>();
		List<CardData> list3 = new List<CardData>();
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if (cardData.HasTag(TagMap.怪物) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.特殊) && !cardData.HasTag(TagMap.BOSS) && (DungeonTheme)Enum.Parse(typeof(DungeonTheme), cardData.GetAttr("Theme").ToString()) == dungeonTheme)
			{
				if (cardData.Level < 2)
				{
					allEnemies.Add(cardData);
				}
				else
				{
					list3.Add(cardData);
				}
			}
		}
		List<CardData> checkedEnemies = new List<CardData>();
		float waitTime = 0.2f;
		DungeonOperationMgr.Instance.CurrentBattleDifficult = enemyDifficult;
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
		bool agreementBuff = false;
		bool TreasureGoblin = false;
		int i = 0;
		int num7;
		while (i < 9)
		{
			CardData cardDataByModID;
			if (!string.IsNullOrEmpty(enemyIdList[i]))
			{
				cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID(enemyIdList[i]);
				goto IL_6F1;
			}
			if (GameController.ins.GameData.Agreenment >= 6 && !agreementBuff && SYNCRandom.Range(0, 101) < 12 && allEnemies.Count > 0)
			{
				agreementBuff = true;
				cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID(allEnemies[SYNCRandom.Range(0, allEnemies.Count)].ModID);
				goto IL_6F1;
			}
			if (!TreasureGoblin && !agreementBuff && SYNCRandom.Range(0, 101) < 8)
			{
				TreasureGoblin = true;
				cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID("钥匙地精");
				goto IL_6F1;
			}
			checkedEnemies.Add(null);
			IL_896:
			num7 = i;
			i = num7 + 1;
			continue;
			IL_6F1:
			CardData cardData2 = CardData.CopyCardData(cardDataByModID, true);
			Card.InitCard(cardData2);
			cardData2.CardGameObject.transform.position = this.Source.transform.position;
			float num8 = Mathf.Sin(radians * (float)ec) * r;
			float num9 = Mathf.Cos(radians * (float)ec) * r;
			if (ec == 0)
			{
				num9 = (num8 = 0f);
			}
			cardData2.CardGameObject.transform.DOLocalMove(new Vector3(this.Source.transform.position.x + num8, this.Source.transform.position.y, this.Source.transform.position.z + num9), waitTime, false).SetEase(Ease.OutBack);
			num7 = ec;
			ec = num7 - 1;
			if (GameController.ins.GameData.CurrentDungeonType == GameData.DungeonType.Dungeon)
			{
				int num10 = 5;
				if (GameController.ins.GameData.Agreenment >= 10)
				{
					num10 = 7;
				}
				cardData2 = DungeonOperationMgr.Instance.InitDungeonMonster(cardData2, enemyDifficult + BattleLevel * num10 - 1);
			}
			else if (GameController.ins.GameData.CurrentDungeonType == GameData.DungeonType.Scene)
			{
				cardData2 = DungeonOperationMgr.Instance.InitSceneMonster(cardData2);
			}
			if (cardData2.HP < 1)
			{
				cardData2.HP = 1;
			}
			checkedEnemies.Add(cardData2);
			yield return new WaitForSeconds(waitTime);
			goto IL_896;
		}
		for (i = 0; i < checkedEnemies.Count; i = num7 + 1)
		{
			if (checkedEnemies[i] != null)
			{
				yield return DungeonOperationMgr.Instance.MonsterJumpToBattleAreaInWorld(checkedEnemies[i], i, true);
			}
			else
			{
				yield return DungeonOperationMgr.Instance.MonsterJumpToBattleArea(checkedEnemies[i], true);
			}
			num7 = i;
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
