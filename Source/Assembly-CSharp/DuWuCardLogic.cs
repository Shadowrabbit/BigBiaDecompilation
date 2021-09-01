using System;
using System.Collections;
using System.Collections.Generic;

public class DuWuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大蛇1");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大蛇1");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大蛇1");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大蛇1");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			if (this.particleList.Count > 0)
			{
				foreach (ParticleObject particle in this.particleList)
				{
					ParticlePoolManager.Instance.UnSpawn(particle);
				}
			}
			this.particleList.Clear();
			if (this.targetSlots.Count > 0)
			{
				foreach (CardSlotData cardSlotData in this.targetSlots)
				{
					if (cardSlotData != null && !DungeonOperationMgr.Instance.CheckCardDead(cardSlotData.ChildCardData) && cardSlotData.ChildCardData.HasTag(TagMap.随从))
					{
						cardSlotData.ChildCardData.AddAffix(DungeonAffix.poisoning, 3);
					}
				}
			}
			this.targetSlots.Clear();
		}
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		int num = 3;
		this.playerSlots = base.GetEnemiesBattleArea();
		for (int i = 0; i < num; i++)
		{
			CardSlotData item = this.playerSlots[SYNCRandom.Range(0, this.playerSlots.Count)];
			if (this.targetSlots.Contains(item))
			{
				i--;
			}
			else
			{
				this.targetSlots.Add(item);
			}
		}
		if (this.targetSlots.Count > 0)
		{
			using (List<CardSlotData>.Enumerator enumerator = this.targetSlots.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardSlotData cardSlotData = enumerator.Current;
					string name = "Effect/Insight_rock";
					ParticleObject particleObject = ParticlePoolManager.Instance.Spawn(name, 2.1474836E+09f);
					particleObject.transform.position = cardSlotData.CardSlotGameObject.transform.position;
					this.particleList.Add(particleObject);
				}
				yield break;
			}
		}
		yield break;
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		base.Terminate(cardSlotData);
		if (this.particleList.Count > 0)
		{
			foreach (ParticleObject particle in this.particleList)
			{
				ParticlePoolManager.Instance.UnSpawn(particle);
			}
		}
		this.particleList.Clear();
		yield break;
	}

	private List<CardSlotData> playerSlots = new List<CardSlotData>();

	private List<CardSlotData> targetSlots = new List<CardSlotData>();

	private List<ParticleObject> particleList = new List<ParticleObject>();
}
