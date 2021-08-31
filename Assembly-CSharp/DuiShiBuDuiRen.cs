using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuiShiBuDuiRen : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_对事不对人");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_对事不对人");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_对事不对人");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_对事不对人");
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield break;
		}
		base.ShowMe();
		List<Vector3Int> list = this.CardData.AttackExtraRange;
		if (list == null)
		{
			list = new List<Vector3Int>();
		}
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.BattleArea)
		{
			if (cardSlotData.ChildCardData != null && target.ChildCardData.ModID.Equals(cardSlotData.ChildCardData.ModID))
			{
				DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Add(new List<AttackMsg>
				{
					new AttackMsg(cardSlotData.ChildCardData, this.CardData.ATK, false, true, 0, 0, null)
				});
			}
		}
		using (List<Vector3Int>.Enumerator enumerator2 = list.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				Vector3Int vector3Int = enumerator2.Current;
				CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(target.GridPositionX, target.GridPositionY, vector3Int.x, vector3Int.y, false);
				if (ralitiveCardSlotData != null && ralitiveCardSlotData != target && ralitiveCardSlotData.ChildCardData != null && ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物))
				{
					foreach (CardData cardData in base.GetAllCurrentMonsters())
					{
						if (!ralitiveCardSlotData.ChildCardData.ModID.Equals(target.ChildCardData.ModID) && ralitiveCardSlotData.ChildCardData.ModID.Equals(cardData.ModID))
						{
							DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Add(new List<AttackMsg>
							{
								new AttackMsg(cardData, this.CardData.ATK, false, true, 0, 0, null)
							});
						}
					}
				}
			}
			yield break;
		}
		yield break;
	}
}
