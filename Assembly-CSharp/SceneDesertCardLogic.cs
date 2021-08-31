using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SceneDesertCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
	}

	private new void GetChainLighting(Vector3 from, Vector3 to, int duration = 1)
	{
		ChainLightningByVector3 component = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Effect/ChainLightingByVector3")).GetComponent<ChainLightningByVector3>();
		component.start = from;
		component.target = to;
		component.gameObject.SetActive(true);
	}

	public IEnumerator SceneCure(Vector3 origin, int val, CardData target)
	{
		if (target.HP >= target.MaxHP)
		{
			yield break;
		}
		ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HellHpBall", 0.3f);
		particleObject.transform.position = origin;
		yield return particleObject.transform.DOMove(target.CardGameObject.transform.position, 0.3f, false).WaitForCompletion();
		string name = "Effect/HealHp";
		ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = target.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
		yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(target, val, target, false, 0, true, false);
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			yield break;
		}
		List<CardData> allMinions = base.GetAllCurrentMinions();
		List<CardData> allMonsters = base.GetAllCurrentMonsters();
		if (allMinions.Count == 0 || allMonsters.Count == 0)
		{
			yield break;
		}
		foreach (CardData player in allMinions)
		{
			List<CardSlotData> playerBattleArea = DungeonOperationMgr.Instance.PlayerBattleArea;
			List<CardData> list = new List<CardData>();
			if (playerBattleArea.IndexOf(player.CurrentCardSlotData) < playerBattleArea.Count / 3 * 2)
			{
				CardSlotData cardSlotData = playerBattleArea[playerBattleArea.IndexOf(player.CurrentCardSlotData) + playerBattleArea.Count / 3];
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
				{
					list.Add(cardSlotData.ChildCardData);
				}
			}
			if (playerBattleArea.IndexOf(player.CurrentCardSlotData) != 0 && playerBattleArea.IndexOf(player.CurrentCardSlotData) != playerBattleArea.Count / 3 && playerBattleArea.IndexOf(player.CurrentCardSlotData) != playerBattleArea.Count / 3 * 2)
			{
				CardSlotData cardSlotData2 = playerBattleArea[playerBattleArea.IndexOf(player.CurrentCardSlotData) - 1];
				if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
				{
					list.Add(cardSlotData2.ChildCardData);
				}
			}
			if (playerBattleArea.IndexOf(player.CurrentCardSlotData) != playerBattleArea.Count / 3 - 1 && playerBattleArea.IndexOf(player.CurrentCardSlotData) != playerBattleArea.Count / 3 * 2 - 1 && playerBattleArea.IndexOf(player.CurrentCardSlotData) != playerBattleArea.Count - 1)
			{
				CardSlotData cardSlotData3 = playerBattleArea[playerBattleArea.IndexOf(player.CurrentCardSlotData) + 1];
				if (cardSlotData3.ChildCardData != null && cardSlotData3.ChildCardData.HasTag(TagMap.随从))
				{
					list.Add(cardSlotData3.ChildCardData);
				}
			}
			if (playerBattleArea.IndexOf(player.CurrentCardSlotData) >= playerBattleArea.Count / 3)
			{
				CardSlotData cardSlotData4 = playerBattleArea[playerBattleArea.IndexOf(player.CurrentCardSlotData) - playerBattleArea.Count / 3];
				if (cardSlotData4.ChildCardData != null && cardSlotData4.ChildCardData.HasTag(TagMap.随从))
				{
					list.Add(cardSlotData4.ChildCardData);
				}
			}
			if (list.Count <= 0 && allMinions.Count > 1)
			{
				yield return GameController.ins.UIController.TabooUIPunchEffect();
				this.GetChainLighting(new Vector3(-8.7f, 0f, 6.9f), player.CardGameObject.transform.position, 1);
				DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(player, -Mathf.CeilToInt((float)player.MaxHP * this.debuff), player, true, 0, true, false));
			}
			else if (list.Count > 0)
			{
				DungeonOperationMgr.Instance.StartCoroutine(this.SceneCure(new Vector3(-8.7f, 0f, 8f), Mathf.CeilToInt(this.buff * (float)player.MaxHP * (float)list.Count), player));
			}
			player = null;
		}
		List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
		foreach (CardData player in allMonsters)
		{
			List<Vector3Int> list2 = new List<Vector3Int>();
			list2.Add(Vector3Int.left);
			list2.Add(Vector3Int.right);
			list2.Add(Vector3Int.up);
			list2.Add(Vector3Int.down);
			SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
			List<CardData> list3 = new List<CardData>();
			foreach (Vector3Int vector3Int in list2)
			{
				CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(player.CurrentCardSlotData.GridPositionX, player.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
				if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物))
				{
					list3.Add(ralitiveCardSlotData.ChildCardData);
				}
			}
			if (list3.Count <= 0 && allMonsters.Count > 1)
			{
				yield return GameController.ins.UIController.TabooUIPunchEffect();
				this.GetChainLighting(new Vector3(-8.7f, 0f, 6.9f), player.CardGameObject.transform.position, 1);
				DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(player, -Mathf.CeilToInt((float)player.MaxHP * this.debuff), player, true, 0, true, false));
			}
			else if (list3.Count > 0)
			{
				DungeonOperationMgr.Instance.StartCoroutine(this.SceneCure(new Vector3(-8.7f, 0f, 8f), Mathf.CeilToInt(this.buff * (float)player.MaxHP * (float)list3.Count), player));
			}
			player = null;
		}
		enumerator = default(List<CardData>.Enumerator);
		yield break;
		yield break;
	}

	private float debuff = 0.2f;

	private float buff = 0.05f;

	private Dictionary<CardData, int> CardList = new Dictionary<CardData, int>();
}
