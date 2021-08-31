using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "龙卷风";
		this.Desc = "每个玩家回合结束都会随机更换位置并获得+5+5";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn && !this.Flag)
		{
			this.Flag = true;
			List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
			SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
			List<CardSlotData> AllCardSlots = new List<CardSlotData>();
			foreach (CardSlotData cardSlotData in cardSlotDatas)
			{
				if (cardSlotData.ChildCardData == null && spaceAreaData.GridOpenState[cardSlotDatas.IndexOf(cardSlotData)] >= 1)
				{
					AllCardSlots.Add(cardSlotData);
				}
			}
			this.CardData._ATK += 5;
			this.CardData.MaxHP += 5;
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, 5, this.CardData, false, 0, true, false);
			if (AllCardSlots.Count > 0)
			{
				yield return this.CardData.CardGameObject.JumpToSlot(AllCardSlots[UnityEngine.Random.Range(0, AllCardSlots.Count)].CardSlotGameObject, 1f, true);
			}
			AllCardSlots = null;
		}
		if (!isPlayerTurn)
		{
			this.Flag = false;
		}
		yield break;
	}

	public bool Flag = true;
}
