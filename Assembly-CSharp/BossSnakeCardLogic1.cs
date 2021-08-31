using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSnakeCardLogic1 : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.m_ATK = this.CardData.ATK;
		this.m_ATKTimes = this.CardData.AttackTimes;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target == this.CardData)
		{
			UnityEngine.Object.FindObjectOfType<BossSnakeArea>().Boss.GetComponent<Animator>().SetTrigger("Die");
			if (GameController.ins.GameData.Agreenment < 10)
			{
				SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_busheren);
			}
			else
			{
				SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_zhongjibusheren);
			}
		}
		yield break;
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		if (player == this.CardData && changedValue <= 0 && !DungeonOperationMgr.Instance.CheckCardDead(player))
		{
			UnityEngine.Object.FindObjectOfType<BossSnakeArea>().Boss.GetComponent<Animator>().SetTrigger("BeAttacked");
		}
		yield break;
	}

	public override IEnumerator OnEnterArea(string areaID)
	{
		if (areaID.Equals("BossSnake"))
		{
			if (this.CurType >= 1)
			{
				yield break;
			}
			this.ChangeSnakeType(1);
			this.CurType = 1;
			this.CardData = DungeonOperationMgr.Instance.InitDungeonMonster(this.CardData, 30);
		}
		yield break;
	}

	private void ChangeSnakeType(int type)
	{
		switch (type)
		{
		case 1:
			this.CardData._ATK = 3;
			this.CardData._AttackTimes = 1;
			this.AddLogic("BossSnakeRecoveryHp");
			this.AddLogic("BossSnakeMakeRock");
			this.AddLogic("BossSnakeAOEAttack");
			return;
		case 2:
		{
			this.CardData._ATK = 4;
			this.CardData._AttackTimes = 2;
			List<CardSlotData> battleArea = DungeonOperationMgr.Instance.BattleArea;
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
				CardData.CopyCardData(Card.InitCardDataByID("沙虫"), true).PutInSlotData(list[index], true);
			}
			this.AddLogic("BossSnakeCallTaunt");
			return;
		}
		case 3:
		{
			this.RemoveLogic("BossSnakeCallTaunt");
			this.CardData._ATK = 4;
			this.CardData._AttackTimes = 3;
			List<CardSlotData> battleArea2 = DungeonOperationMgr.Instance.BattleArea;
			for (int j = 0; j < 2; j++)
			{
				List<CardSlotData> list2 = new List<CardSlotData>();
				foreach (CardSlotData cardSlotData2 in battleArea2)
				{
					if (cardSlotData2.ChildCardData == null)
					{
						list2.Add(cardSlotData2);
					}
				}
				if (list2.Count <= 0)
				{
					break;
				}
				int index2 = UnityEngine.Random.Range(0, list2.Count);
				Card.InitCardDataByID("血祭之卵").PutInSlotData(list2[index2], true);
			}
			this.AddLogic("BossSnakeCallSacrifice");
			this.AddLogic("BossSnakeEat");
			return;
		}
		default:
			return;
		}
	}

	private void AddLogic(string logicName)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		cardLogic.CardData = this.CardData;
		this.CardData.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(this.CardData);
	}

	private void RemoveLogic(string logicName)
	{
		Activator.CreateInstance(Type.GetType(logicName));
		foreach (CardLogic cardLogic in this.CardData.CardLogics)
		{
			if (cardLogic.GetType().Name.Equals(logicName))
			{
				for (int i = this.CardData.CardLogicClassNames.Count - 1; i >= 0; i--)
				{
					if (this.CardData.CardLogicClassNames[i].Split(new char[]
					{
						' '
					})[0].Equals(logicName))
					{
						this.CardData.CardLogicClassNames.Remove(this.CardData.CardLogicClassNames[i]);
					}
				}
				this.CardData.CardLogics.Remove(cardLogic);
				break;
			}
		}
	}

	public int CurType;

	private int m_ATK;

	private int m_ATKTimes;
}
