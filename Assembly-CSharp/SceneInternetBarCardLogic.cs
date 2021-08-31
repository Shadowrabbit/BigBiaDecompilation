using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SceneInternetBarCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			this.round++;
			if (this.round % 2 > 0)
			{
				yield break;
			}
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			if (allCurrentMonsters.Count == 0)
			{
				yield break;
			}
			List<CardData> list = new List<CardData>();
			foreach (CardData item in allCurrentMonsters)
			{
				if (!this.HadDad.Contains(item))
				{
					list.Add(item);
				}
			}
			if (list.Count == 0)
			{
				yield break;
			}
			CardData son = list[SYNCRandom.Range(0, list.Count)];
			this.HadDad.Add(son);
			CardData Father = Card.InitCardDataByID("爸爸");
			Father.Name = LocalizationMgr.Instance.GetLocalizationWord(son.Name) + "的爸爸";
			Father.MaxHP = (Father.HP = ((Mathf.CeilToInt((float)son.MaxHP * 1.2f) > 999) ? 999 : Mathf.CeilToInt((float)son.MaxHP * 1.2f)));
			Father.MaxArmor = (Father.Armor = son.Armor + 1);
			Father.Price = 0;
			Father.Attrs.Clear();
			Father.Attrs.Add("Son", son.ID);
			List<CardSlotData> list2 = new List<CardSlotData>();
			List<CardSlotData> battleArea = DungeonOperationMgr.Instance.BattleArea;
			if (battleArea == null || battleArea.Count == 0)
			{
				yield break;
			}
			foreach (CardSlotData cardSlotData in battleArea)
			{
				if (cardSlotData.ChildCardData == null)
				{
					list2.Add(cardSlotData);
				}
			}
			if (list2.Count == 0)
			{
				yield break;
			}
			GameObject tempCard = Card.InitWithOutData(Father, true);
			CardSlotData TargetSlot = list2[SYNCRandom.Range(0, list2.Count)];
			tempCard.transform.position = new Vector3(-9.53f, 0f, 5.14f);
			yield return tempCard.transform.DOJump(TargetSlot.CardSlotGameObject.transform.position, 0.5f, 5, 2f, false).WaitForCompletion();
			UnityEngine.Object.DestroyImmediate(tempCard);
			Father.PutInSlotData(TargetSlot, true);
			yield return Father.CardLogics[0].ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_网吧1"));
			this.GetChainLighting(Father, son);
			son = null;
			Father = null;
			tempCard = null;
			TargetSlot = null;
		}
		yield break;
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		this.HadDad.Clear();
		yield break;
	}

	private GameObject GetChainLighting(CardData from, CardData to)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Effect/ChainPosLine"));
		UVChainLightning component = gameObject.GetComponent<UVChainLightning>();
		component.start = from;
		component.target = to;
		component.gameObject.SetActive(true);
		return gameObject;
	}

	private int round = 1;

	private List<CardData> HadDad = new List<CardData>();
}
