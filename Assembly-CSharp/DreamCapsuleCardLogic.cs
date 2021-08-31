using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamCapsuleCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_梦想胶囊");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_梦想胶囊");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_梦想胶囊");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_梦想胶囊");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData.RemoveLogic(this);
		foreach (CardLogic cardLogic in mergeBy.CardLogics)
		{
			if (cardLogic.GetType() == base.GetType())
			{
				cardLogic.OnLeftClick(null);
			}
		}
	}

	public override void OnLeftClick(List<Vector2[]> res)
	{
		GameController.ins.StartCoroutine(this.Use());
	}

	private IEnumerator Use()
	{
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		if (allCurrentMonsters.Count == 0)
		{
			yield break;
		}
		using (List<CardData>.Enumerator enumerator = allCurrentMonsters.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.HasTag(TagMap.BOSS))
				{
					yield break;
				}
			}
		}
		UIController.LockLevel = UIController.UILevel.All;
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in cards)
		{
			if ((cardData.CardTags & 1048576UL) > 0UL && !cardData.HasTag(TagMap.奇遇))
			{
				list.Add(cardData);
			}
		}
		if (list.Count == 0)
		{
			yield break;
		}
		CardData cardData2 = list[SYNCRandom.Range(0, list.Count)];
		AreaData areaData = GameController.getInstance().GameData.AreaMap[cardData2.ModID];
		areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
		GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
		GameController.getInstance().OnTableChange(areaData, true);
		UIController.LockLevel = UIController.UILevel.None;
		this.CardData.DeleteCardData();
		yield break;
	}
}
