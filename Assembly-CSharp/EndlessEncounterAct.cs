using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class EndlessEncounterAct : GameAct
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
		string[] array = this.Source.CardData.GetAttr("Theme").Split(new char[]
		{
			','
		});
		List<DungeonTheme> list = new List<DungeonTheme>();
		foreach (string value in array)
		{
			list.Add((DungeonTheme)Enum.Parse(typeof(DungeonTheme), value));
		}
		int enemyDifficult = GameController.ins.GameData.step;
		int BattleLevel;
		DungeonController.Instance.BattleLevel = (BattleLevel = this.Source.CardData.Rare - 1);
		List<EnemyConfigBean> enemyConfigBeans = GlobalController.Instance.GetEnemyConfig().EnemyConfigBeans;
		List<string> enemyIdList = new List<string>();
		List<CardData> list2 = new List<CardData>();
		List<CardData> list3 = new List<CardData>();
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if (cardData.HasTag(TagMap.怪物) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.特殊) && !cardData.HasTag(TagMap.BOSS) && list.Contains((DungeonTheme)Enum.Parse(typeof(DungeonTheme), cardData.GetAttr("Theme").ToString())))
			{
				if (cardData.Level < 2)
				{
					list2.Add(cardData);
				}
				else
				{
					list3.Add(cardData);
				}
			}
		}
		int num = this.Source.CardData.Rare + 2;
		bool flag = false;
		if (list.Contains(DungeonTheme.Forest))
		{
			num++;
			flag = true;
		}
		if (list.Contains(DungeonTheme.Studio))
		{
			num++;
			flag = true;
		}
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		for (int k = 0; k < num; k++)
		{
			CardData cardData2 = list2[SYNCRandom.Range(0, list2.Count)];
			List<int> list4 = new List<int>();
			for (int l = 0; l < 9; l++)
			{
				if (!dictionary.ContainsKey(l))
				{
					list4.Add(l);
				}
			}
			if (flag)
			{
				if (list.Contains(DungeonTheme.Forest))
				{
					dictionary.Add(list4[SYNCRandom.Range(0, list4.Count)], "小青杉");
				}
				if (list.Contains(DungeonTheme.Studio))
				{
					dictionary.Add(list4[SYNCRandom.Range(0, list4.Count)], "颜料桶");
				}
				flag = false;
			}
			else if (list4.Count > 0 && cardData2 != null)
			{
				dictionary.Add(list4[SYNCRandom.Range(0, list4.Count)], cardData2.ModID);
			}
		}
		for (int m = 0; m < 9; m++)
		{
			if (dictionary.ContainsKey(m))
			{
				enemyIdList.Add(dictionary[m]);
			}
			else
			{
				enemyIdList.Add(null);
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
		int j;
		for (int i = 0; i < 9; i = j + 1)
		{
			if (string.IsNullOrEmpty(enemyIdList[i]))
			{
				checkedEnemies.Add(null);
			}
			else
			{
				CardData cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID(enemyIdList[i]);
				CardData cardData3 = CardData.CopyCardData(cardDataByModID, true);
				Card.InitCard(cardData3);
				cardData3.CardGameObject.transform.position = this.Source.transform.position;
				float num2 = Mathf.Sin(radians * (float)ec) * r;
				float num3 = Mathf.Cos(radians * (float)ec) * r;
				cardData3.CardGameObject.transform.DOLocalMove(new Vector3(this.Source.transform.position.x + num2, this.Source.transform.position.y, this.Source.transform.position.z + num3), waitTime, false).SetEase(Ease.OutBack);
				j = ec;
				ec = j - 1;
				int level = GameController.ins.GameData.level;
				if (GameController.ins.GameData.CurrentDungeonType == GameData.DungeonType.Dungeon)
				{
					cardData3 = DungeonOperationMgr.Instance.InitDungeonMonster(cardData3, enemyDifficult + BattleLevel * 5 - 1);
				}
				else if (GameController.ins.GameData.CurrentDungeonType == GameData.DungeonType.Scene)
				{
					cardData3 = DungeonOperationMgr.Instance.InitSceneMonster(cardData3);
				}
				if (cardData3.HP < 1)
				{
					cardData3.HP = 1;
				}
				checkedEnemies.Add(cardData3);
				yield return new WaitForSeconds(waitTime);
			}
			j = i;
		}
		for (int i = 0; i < checkedEnemies.Count; i = j + 1)
		{
			if (checkedEnemies[i] != null)
			{
				yield return DungeonOperationMgr.Instance.MonsterJumpToBattleAreaInWorld(checkedEnemies[i], i, true);
			}
			else
			{
				yield return DungeonOperationMgr.Instance.MonsterJumpToBattleArea(checkedEnemies[i], true);
			}
			j = i;
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

	public static HashSet<EnemyConfigBean> CollapseiEnemySet = new HashSet<EnemyConfigBean>();
}
