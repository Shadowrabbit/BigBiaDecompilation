using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainOfLightningLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(3, 0, 0);
		this.displayName = "闪电链";
		this.Desc = "向前方发出一道闪电，造成[80%攻击力]的真实伤害并传递到相邻4格中的随机敌人身上，重复" + (2 + base.Layers).ToString() + "次。";
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = false;
		List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
		for (int i = enemiesBattleArea.Count - 1; i >= 0; i--)
		{
			if (enemiesBattleArea[i].GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col") && enemiesBattleArea[i].ChildCardData != null && enemiesBattleArea[i].ChildCardData.HasTag(TagMap.怪物))
			{
				CardSlotData cardSlotData = enemiesBattleArea[i];
				this.Targets.Clear();
				List<Vector3Int> list = new List<Vector3Int>();
				list.Add(Vector3Int.up);
				list.Add(Vector3Int.down);
				list.Add(Vector3Int.left);
				list.Add(Vector3Int.right);
				SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
				CardData cardData = cardSlotData.ChildCardData;
				if (this.CardData.MP <= 0)
				{
					yield break;
				}
				DungeonOperationMgr.Instance.CurrentAttackMsgStruct.TransferEffects.Add("Effect/ChainLighting");
				base.ShowMe();
				int num = 0;
				while (num < 3 && cardData != null)
				{
					List<CardData> list2 = new List<CardData>();
					if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
					{
						this.Targets.Add(cardData);
					}
					if (spaceAreaData != null)
					{
						foreach (Vector3Int vector3Int in list)
						{
							CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(cardData.CurrentCardSlotData.GridPositionX, cardData.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
							if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && !DungeonOperationMgr.Instance.CheckCardDead(ralitiveCardSlotData.ChildCardData) && ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物))
							{
								list2.Add(ralitiveCardSlotData.ChildCardData);
							}
						}
						if (list2.Count <= 0)
						{
							break;
						}
						CardData cardData2 = list2[SYNCRandom.Range(0, list2.Count)];
						DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Add(new List<AttackMsg>
						{
							new AttackMsg(cardData2, this.CardData.ATK, false, true, 0, 0, null)
						});
						cardData = cardData2;
					}
					num++;
				}
			}
		}
		yield break;
	}

	private void GetChainLighting(CardData from, CardData to, int duration)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Effect/ChainLighting"));
		UVChainLightning component = gameObject.GetComponent<UVChainLightning>();
		component.start = from;
		component.target = to;
		component.gameObject.SetActive(true);
		UnityEngine.Object.Destroy(gameObject, (float)duration);
	}

	public List<CardData> Targets = new List<CardData>();
}
