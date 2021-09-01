using System;
using System.Collections;
using System.Collections.Generic;

public class SceneGymCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			List<CardData> allItems = new List<CardData>();
			List<CardData> list = new List<CardData>();
			if (allCurrentMonsters.Count == 0)
			{
				yield break;
			}
			foreach (CardData cardData in allCurrentMonsters)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					if (cardData.ModID == "公用杠铃")
					{
						allItems.Add(cardData);
					}
					else if (cardData.ModID != "沙袋")
					{
						list.Add(cardData);
					}
				}
			}
			if (allItems.Count == 0 || list.Count == 0)
			{
				yield break;
			}
			foreach (CardData cardData2 in list)
			{
				string key = "";
				switch (SYNCRandom.Range(0, 3))
				{
				case 0:
					key = "T_强身健体";
					break;
				case 1:
					key = "T_健身时间到";
					break;
				case 2:
					key = "T_流血流汗不流泪";
					break;
				}
				base.Show(LocalizationMgr.Instance.GetLocalizationWord(key), cardData2);
				yield return DungeonOperationMgr.Instance.Hit(cardData2, allItems[SYNCRandom.Range(0, allItems.Count)], cardData2.ATK, 0.2f, false, 0, null, null);
			}
			List<CardData>.Enumerator enumerator2 = default(List<CardData>.Enumerator);
			allItems = null;
		}
		yield break;
		yield break;
	}
}
