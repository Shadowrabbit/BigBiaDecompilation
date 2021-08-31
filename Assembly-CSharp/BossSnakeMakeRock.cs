using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSnakeMakeRock : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇1");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇1");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇1");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇1");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			int num = 3;
			this.playerSlots = base.GetEnemiesBattleArea();
			int num2 = this.rounds % this.cycle;
			if (num2 != 0)
			{
				if (num2 != 1)
				{
					goto IL_1E7;
				}
			}
			else
			{
				this.tempIndexList = new List<int>();
				for (int i = 0; i < num; i++)
				{
					int item = UnityEngine.Random.Range(0, this.playerSlots.Count);
					while (this.tempIndexList.Contains(item))
					{
						item = UnityEngine.Random.Range(0, this.playerSlots.Count);
					}
					this.tempIndexList.Add(item);
				}
				this.particleList = new List<ParticleObject>();
				using (List<int>.Enumerator enumerator = this.tempIndexList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						int index = enumerator.Current;
						string name = "Effect/Insight_rock";
						ParticleObject particleObject = ParticlePoolManager.Instance.Spawn(name, 2.1474836E+09f);
						particleObject.transform.position = this.playerSlots[index].CardSlotGameObject.transform.position;
						this.particleList.Add(particleObject);
					}
					goto IL_1E7;
				}
			}
			for (int j = this.particleList.Count - 1; j >= 0; j--)
			{
				ParticlePoolManager.Instance.UnSpawn(this.particleList[j]);
			}
			this.particleList.Clear();
			foreach (int index2 in this.tempIndexList)
			{
				CardData childCardData = this.playerSlots[index2].ChildCardData;
				if (childCardData != null && childCardData.HasTag(TagMap.随从))
				{
					childCardData.AddAffix(DungeonAffix.dizzy, 2);
				}
			}
			this.tempIndexList.Clear();
			IL_1E7:
			this.rounds++;
		}
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target == this.CardData && this.particleList.Count > 0)
		{
			for (int i = this.particleList.Count - 1; i >= 0; i--)
			{
				ParticlePoolManager.Instance.UnSpawn(this.particleList[i]);
			}
			this.particleList.Clear();
		}
		yield break;
	}

	private int rounds;

	private int cycle = 2;

	private List<CardSlotData> playerSlots = new List<CardSlotData>();

	private List<int> tempIndexList = new List<int>();

	private List<ParticleObject> particleList = new List<ParticleObject>();
}
