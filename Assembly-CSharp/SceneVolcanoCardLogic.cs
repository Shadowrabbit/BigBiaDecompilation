using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SceneVolcanoCardLogic : CardLogic
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

	public override IEnumerator OnBattleStart()
	{
		int num = 3;
		this.m_TarCardSlot = new List<CardSlotData>();
		List<CardSlotData> list = new List<CardSlotData>();
		for (int i = 0; i < num; i++)
		{
			list = DungeonOperationMgr.Instance.BattleArea;
			int index = SYNCRandom.Range(0, list.Count);
			while (this.m_TarCardSlot.Contains(list[index]))
			{
				index = SYNCRandom.Range(0, list.Count);
			}
			this.m_TarCardSlot.Add(list[index]);
			list = DungeonOperationMgr.Instance.PlayerBattleArea;
			index = SYNCRandom.Range(0, list.Count);
			while (this.m_TarCardSlot.Contains(list[index]))
			{
				index = SYNCRandom.Range(0, list.Count);
			}
			this.m_TarCardSlot.Add(list[index]);
		}
		this.m_ParticleList = new List<ParticleObject>();
		using (List<CardSlotData>.Enumerator enumerator = this.m_TarCardSlot.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardSlotData cardSlotData = enumerator.Current;
				string name = "Effect/Insight_fire";
				ParticleObject particleObject = ParticlePoolManager.Instance.Spawn(name, 2.1474836E+09f);
				particleObject.transform.position = cardSlotData.CardSlotGameObject.transform.position;
				this.m_ParticleList.Add(particleObject);
			}
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		int num = 3;
		this.m_TarCardSlot = new List<CardSlotData>();
		List<CardSlotData> list = new List<CardSlotData>();
		for (int i = 0; i < num; i++)
		{
			list = DungeonOperationMgr.Instance.BattleArea;
			int index = SYNCRandom.Range(0, list.Count);
			while (this.m_TarCardSlot.Contains(list[index]))
			{
				index = SYNCRandom.Range(0, list.Count);
			}
			this.m_TarCardSlot.Add(list[index]);
			list = DungeonOperationMgr.Instance.PlayerBattleArea;
			index = SYNCRandom.Range(0, list.Count);
			while (this.m_TarCardSlot.Contains(list[index]))
			{
				index = SYNCRandom.Range(0, list.Count);
			}
			this.m_TarCardSlot.Add(list[index]);
		}
		this.m_ParticleList = new List<ParticleObject>();
		using (List<CardSlotData>.Enumerator enumerator = this.m_TarCardSlot.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardSlotData cardSlotData = enumerator.Current;
				string name = "Effect/Insight_fire";
				ParticleObject particleObject = ParticlePoolManager.Instance.Spawn(name, 2.1474836E+09f);
				particleObject.transform.position = cardSlotData.CardSlotGameObject.transform.position;
				this.m_ParticleList.Add(particleObject);
			}
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			foreach (CardSlotData slot in this.m_TarCardSlot)
			{
				string name = "Effect/喷发";
				ParticlePoolManager.Instance.Spawn(name, 2f).transform.position = this.m_VolcanoPos;
				Camera.main.GetComponent<CameraShake>().StartAnimate(0.1f, 0.2f, false);
				name = "Effect/火山攻击";
				ParticleObject particleObject = ParticlePoolManager.Instance.Spawn(name, 1f);
				particleObject.transform.position = this.m_VolcanoPos;
				yield return particleObject.transform.DOJump(slot.CardSlotGameObject.transform.position, 5f, 1, 0.5f, false).WaitForCompletion();
				ParticlePoolManager.Instance.Spawn("Effect/火山爆炸", 2f).transform.position = slot.CardSlotGameObject.transform.position;
				if (slot.ChildCardData != null)
				{
					bool flag = false;
					foreach (CardLogic cardLogic in slot.ChildCardData.CardLogics)
					{
						if (cardLogic is VolcanoLogic && cardLogic.GetType().GetMethod("BeFireBallAttacked").DeclaringType == cardLogic.GetType())
						{
							yield return ((VolcanoLogic)cardLogic).BeFireBallAttacked();
							flag = true;
						}
					}
					List<CardLogic>.Enumerator enumerator2 = default(List<CardLogic>.Enumerator);
					if (!flag)
					{
						yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(slot.ChildCardData, -Mathf.CeilToInt((float)slot.ChildCardData.MaxHP * 0.5f), null, true, 0, true, false);
					}
				}
				slot = null;
			}
			List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
			for (int i = this.m_ParticleList.Count - 1; i >= 0; i--)
			{
				ParticlePoolManager.Instance.UnSpawn(this.m_ParticleList[i]);
			}
			this.m_ParticleList.Clear();
		}
		yield break;
		yield break;
	}

	public override IEnumerator OnBattleEnd()
	{
		for (int i = this.m_ParticleList.Count - 1; i >= 0; i--)
		{
			ParticlePoolManager.Instance.UnSpawn(this.m_ParticleList[i]);
		}
		this.m_ParticleList.Clear();
		yield break;
	}

	private float dmg = 0.1f;

	private Vector3 m_VolcanoPos = new Vector3(-2.88f, 2.21f, 9.23f);

	private List<CardSlotData> m_TarCardSlot = new List<CardSlotData>();

	private List<ParticleObject> m_ParticleList = new List<ParticleObject>();
}
