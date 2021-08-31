using System;
using System.Collections;
using System.Collections.Generic;

public class SceneRoninRoadCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		List<CardSlotData> battleArea = DungeonOperationMgr.Instance.BattleArea;
		List<CardSlotData> list = new List<CardSlotData>();
		if (battleArea == null)
		{
			yield break;
		}
		for (int i = 0; i < this.round; i++)
		{
			foreach (CardSlotData cardSlotData in battleArea)
			{
				if (cardSlotData.ChildCardData == null)
				{
					list.Add(cardSlotData);
				}
			}
			if (list.Count >= 1)
			{
				Card.InitCardDataByID("枫叶").PutInSlotData(list[SYNCRandom.Range(0, list.Count)], true);
				list.Clear();
			}
		}
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		List<CardSlotData> battleArea = DungeonOperationMgr.Instance.BattleArea;
		List<CardSlotData> list = new List<CardSlotData>();
		if (battleArea == null)
		{
			yield break;
		}
		for (int i = 0; i < this.round; i++)
		{
			foreach (CardSlotData cardSlotData in battleArea)
			{
				if (cardSlotData.ChildCardData == null)
				{
					list.Add(cardSlotData);
				}
			}
			if (list.Count >= 1)
			{
				Card.InitCardDataByID("枫叶").PutInSlotData(list[SYNCRandom.Range(0, list.Count)], true);
				list.Clear();
			}
		}
		yield break;
	}

	private int round = 2;
}
