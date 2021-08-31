using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class CangBaoTuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "寻宝";
		this.Desc = "地点已经在地图上标记出来了，去寻宝吧！";
	}

	public override void OnLeftClick(List<Vector2[]> res)
	{
		base.OnLeftClick(res);
		if (this.target == null)
		{
			base.ShowMe();
			SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.ins.GameData.CurrentAreaId] as SpaceAreaData;
			List<CardSlotData> cardSlotDatas = spaceAreaData.CardSlotDatas;
			List<CardSlotData> list = new List<CardSlotData>();
			if (cardSlotDatas == null || cardSlotDatas.Count == 0)
			{
				return;
			}
			foreach (CardSlotData cardSlotData in cardSlotDatas)
			{
				if (spaceAreaData.GridOpenState[cardSlotDatas.IndexOf(cardSlotData)] == 1 && !DungeonOperationMgr.Instance.BattleArea.Contains(cardSlotData) && DungeonOperationMgr.Instance.CurrentPositionInMap != cardSlotData && (cardSlotData.ChildCardData == null || !cardSlotData.ChildCardData.HasTag(TagMap.地下城入口)))
				{
					list.Add(cardSlotData);
				}
			}
			if (list.Count > 0)
			{
				this.target = list[SYNCRandom.Range(0, list.Count)];
				string name = "Effect/Insight_yellow";
				this.particle = ParticlePoolManager.Instance.Spawn(name, 2.1474836E+09f);
				this.particle.transform.position = this.target.CardSlotGameObject.transform.position;
				return;
			}
		}
		else
		{
			base.ShowLogic("地点已经标出来了");
		}
	}

	public override IEnumerator OnMoveOnMap()
	{
		if (this.target == null)
		{
			SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.ins.GameData.CurrentAreaId] as SpaceAreaData;
			List<CardSlotData> cardSlotDatas = spaceAreaData.CardSlotDatas;
			List<CardSlotData> list = new List<CardSlotData>();
			if (cardSlotDatas == null || cardSlotDatas.Count == 0)
			{
				yield break;
			}
			foreach (CardSlotData cardSlotData in cardSlotDatas)
			{
				if (spaceAreaData.GridOpenState[cardSlotDatas.IndexOf(cardSlotData)] == 1 && !DungeonOperationMgr.Instance.BattleArea.Contains(cardSlotData) && DungeonOperationMgr.Instance.CurrentPositionInMap != cardSlotData && (cardSlotData.ChildCardData == null || !cardSlotData.ChildCardData.HasTag(TagMap.地下城入口)))
				{
					list.Add(cardSlotData);
				}
			}
			if (list.Count > 0)
			{
				this.target = list[SYNCRandom.Range(0, list.Count)];
				string name = "Effect/Insight_yellow";
				this.particle = ParticlePoolManager.Instance.Spawn(name, 2.1474836E+09f);
				this.particle.transform.position = this.target.CardSlotGameObject.transform.position;
			}
		}
		if (DungeonOperationMgr.Instance.CurrentPositionInMap == this.target)
		{
			if (base.GetHero() != null)
			{
				DialogueManager.StartConversation("到达宝藏格", base.GetHero().CardGameObject.transform);
				this.CardData.DeleteCardData();
			}
			yield break;
		}
		yield break;
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		base.Terminate(cardSlotData);
		if (this.target != null)
		{
			this.target = null;
		}
		if (this.particle != null)
		{
			ParticlePoolManager.Instance.UnSpawn(this.particle);
		}
		yield break;
	}

	public CardSlotData target;

	private ParticleObject particle;
}
