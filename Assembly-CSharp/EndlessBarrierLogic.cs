using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBarrierLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "永无止境";
		this.Desc = "源源不断的挑战";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			this.DCount++;
			GameController.ins.GameData.level = this.DCount;
			List<CardSlotData> CardSlots = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
			SpaceAreaData dungeonAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
			int num = 999;
			int minY = 999;
			foreach (CardSlotData cardSlotData in CardSlots)
			{
				if (dungeonAreaData.GridOpenState[CardSlots.IndexOf(cardSlotData)] >= 1)
				{
					if (cardSlotData.GridPositionX < num)
					{
						num = cardSlotData.GridPositionX;
					}
					if (cardSlotData.GridPositionY < minY)
					{
						minY = cardSlotData.GridPositionY;
					}
				}
			}
			int x = 2;
			CardSlotData targetCardSlot;
			int num2;
			for (int i = CardSlots.Count - 1; i >= 0; i = num2 - 1)
			{
				targetCardSlot = CardSlots[i];
				if (targetCardSlot != null && targetCardSlot.ChildCardData != null && targetCardSlot.ChildCardData.HasTag(TagMap.怪物))
				{
					yield return this.TryJump(targetCardSlot);
				}
				if (targetCardSlot.ChildCardData == null && targetCardSlot.GridPositionY == minY && dungeonAreaData.GridOpenState[CardSlots.IndexOf(targetCardSlot)] >= 1)
				{
					CardSlotData csd = targetCardSlot;
					num2 = x;
					x = num2 - 1;
					this.InitMonster(csd, num2);
				}
				num2 = i;
			}
			CardSlots = null;
			dungeonAreaData = null;
			targetCardSlot = null;
		}
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target.HasTag(TagMap.怪物))
		{
			int layers = base.Layers;
			base.Layers = layers + 1;
			if ((float)base.Layers >= this.RestCount)
			{
				base.Layers = 0;
				List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
				CardData cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID("酒馆");
				CardData cardDataByModID2 = GameController.getInstance().CardDataModMap.getCardDataByModID("商铺");
				for (int i = 0; i < cardSlotDatas.Count; i++)
				{
					CardSlotData cardSlotData = cardSlotDatas[i];
					if (cardSlotData.GridPositionX == 12 && cardSlotData.GridPositionY == 5 && cardSlotData.ChildCardData == null)
					{
						cardDataByModID.PutInSlotData(cardSlotData, true);
					}
					if (cardSlotData.GridPositionX == 14 && cardSlotData.GridPositionY == 5 && cardSlotData.ChildCardData == null)
					{
						cardDataByModID2.PutInSlotData(cardSlotData, true);
					}
				}
			}
			this.m_ProgressBar = UnityEngine.Object.FindObjectOfType<SpaceProgressBarTool>();
			if (this.m_ProgressBar != null)
			{
				this.m_ProgressBar.SetProgress((float)base.Layers / this.RestCount, "还有" + (this.RestCount - (float)base.Layers).ToString() + "回合");
			}
			yield break;
		}
		yield break;
	}

	public void InitMonster(CardSlotData csd, int col)
	{
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		Dictionary<int, List<CardData>> dictionary = new Dictionary<int, List<CardData>>();
		foreach (CardData cardData in cards)
		{
			if (cardData.HasTag(TagMap.怪物) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.特殊) && !cardData.HasTag(TagMap.BOSS) && !cardData.Attrs.ContainsKey("Endless"))
			{
				if (cardData.Level <= 0)
				{
					cardData.Level = 1;
				}
				if (!dictionary.ContainsKey(cardData.Level))
				{
					dictionary.Add(cardData.Level, new List<CardData>());
				}
				dictionary[cardData.Level].Add(cardData);
			}
		}
		CardData cardData2 = CardData.CopyCardData(dictionary[1][UnityEngine.Random.Range(0, dictionary[1].Count)], true);
		DungeonOperationMgr.Instance.SetEndlessMonster(cardData2, this.DCount / 4);
		cardData2.PutInSlotData(csd, true);
		cardData2.Attrs.Add("Col", col);
	}

	public IEnumerator TryJump(CardSlotData csd)
	{
		List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		Vector3Int up = Vector3Int.up;
		CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(csd.GridPositionX, csd.GridPositionY, up.x, up.y, false);
		if (ralitiveCardSlotData == null || spaceAreaData.GridOpenState[cardSlotDatas.IndexOf(ralitiveCardSlotData)] == 0)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			foreach (CardData cardData in allCurrentMinions)
			{
				if (cardData.HasTag(TagMap.英雄))
				{
					yield return DungeonOperationMgr.Instance.Hit(csd.ChildCardData, cardData, csd.ChildCardData.HP, 0.2f, false, 0, null, null);
				}
			}
			List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
			csd.ChildCardData.Price = 0;
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(csd.ChildCardData, -csd.ChildCardData.HP, csd.ChildCardData, true, 0, true, false);
			yield break;
		}
		if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData == null && csd.ChildCardData.CardGameObject != null)
		{
			yield return csd.ChildCardData.CardGameObject.JumpToSlot(ralitiveCardSlotData.CardSlotGameObject, 0.2f, true);
			yield break;
		}
		yield break;
		yield break;
	}

	private int GameOverCount;

	private int GameOverMax = 10;

	private float RestCount = 10f;

	private int DCount;

	private int DungeonLevel;

	private SpaceProgressBarTool m_ProgressBar;
}
