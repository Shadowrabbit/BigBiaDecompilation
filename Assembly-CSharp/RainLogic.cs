using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "细雨";
		this.Desc = "不会攻击。每个玩家回合结束时试图向下移动。已经在最下格时消灭自己，对每列最前的随从造成等同于生命值的伤害。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn && !this.Flag)
		{
			this.Flag = true;
			List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
			SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
			Vector3Int up = Vector3Int.up;
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(this.CardData.CurrentCardSlotData.GridPositionX, this.CardData.CurrentCardSlotData.GridPositionY, up.x, up.y, false);
			if (ralitiveCardSlotData == null || spaceAreaData.GridOpenState[cardSlotDatas.IndexOf(ralitiveCardSlotData)] == 0)
			{
				List<CardSlotData> PlayerCardSlots = GameController.getInstance().PlayerSlotSets;
				int num;
				for (int i = PlayerCardSlots.Count / 3 * 2; i < PlayerCardSlots.Count; i = num + 1)
				{
					if (PlayerCardSlots[i] != null && PlayerCardSlots[i].ChildCardData != null && PlayerCardSlots[i].ChildCardData.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(PlayerCardSlots[i].ChildCardData))
					{
						yield return DungeonOperationMgr.Instance.Hit(this.CardData, PlayerCardSlots[i].ChildCardData, this.CardData.HP, 0.3f, false, 0, null, null);
					}
					else if (PlayerCardSlots[i - PlayerCardSlots.Count / 3] != null && PlayerCardSlots[i - PlayerCardSlots.Count / 3].ChildCardData != null && PlayerCardSlots[i - PlayerCardSlots.Count / 3].ChildCardData.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(PlayerCardSlots[i - PlayerCardSlots.Count / 3].ChildCardData))
					{
						yield return DungeonOperationMgr.Instance.Hit(this.CardData, PlayerCardSlots[i - PlayerCardSlots.Count / 3].ChildCardData, this.CardData.HP, 0.3f, false, 0, null, null);
					}
					else if (PlayerCardSlots[i - PlayerCardSlots.Count / 3 * 2] != null && PlayerCardSlots[i - PlayerCardSlots.Count / 3 * 2].ChildCardData != null && PlayerCardSlots[i - PlayerCardSlots.Count / 3 * 2].ChildCardData.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(PlayerCardSlots[i - PlayerCardSlots.Count / 3 * 2].ChildCardData))
					{
						yield return DungeonOperationMgr.Instance.Hit(this.CardData, PlayerCardSlots[i - PlayerCardSlots.Count / 3 * 2].ChildCardData, this.CardData.HP, 0.3f, false, 0, null, null);
					}
					num = i;
				}
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -this.CardData.HP, this.CardData, false, 0, true, false);
				PlayerCardSlots = null;
			}
			else
			{
				if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData == null)
				{
					if (this.CardData.CardGameObject != null)
					{
						yield return this.CardData.CardGameObject.JumpToSlot(ralitiveCardSlotData.CardSlotGameObject, 0.2f, true);
					}
					yield break;
				}
				foreach (CardLogic cardLogic in this.CardData.CardLogics)
				{
					if (cardLogic.GetType() == typeof(SavingLogic))
					{
						this.CardData.MaxHP += cardLogic.Layers;
						yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, cardLogic.Layers, this.CardData, false, 0, true, false);
					}
				}
				List<CardLogic>.Enumerator enumerator = default(List<CardLogic>.Enumerator);
			}
		}
		if (!isPlayerTurn)
		{
			this.Flag = false;
		}
		yield break;
		yield break;
	}

	public bool Flag = true;
}
