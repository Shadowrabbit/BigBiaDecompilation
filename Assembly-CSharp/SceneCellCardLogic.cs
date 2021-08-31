using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SceneCellCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.MoveEvent));
		GameEventManager gameEventManager2 = GameController.ins.GameEventManager;
		gameEventManager2.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Combine(gameEventManager2.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.MoveEvent));
		yield break;
	}

	public override IEnumerator OnBattleEnd()
	{
		base.OnBattleEnd();
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.MoveEvent));
		yield break;
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
		if (DungeonOperationMgr.Instance.CheckCardDead(target) || target.CardGameObject == null)
		{
			yield break;
		}
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

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (from == null)
		{
			yield break;
		}
		yield return this.SceneCure(new Vector3(-8.7f, 0f, 8f), Mathf.CeilToInt(this.buff * (float)from.MaxHP), from);
		yield break;
	}

	private void MoveEvent(CardSlotData arg1, CardData arg2)
	{
		DungeonController.Instance.StartCoroutine(this.GoDeep(arg1, arg2));
	}

	public IEnumerator GoDeep(CardSlotData csd, CardData cd)
	{
		List<CardSlotData> battleArea = DungeonOperationMgr.Instance.BattleArea;
		List<CardSlotData> playerBattleArea = DungeonOperationMgr.Instance.PlayerBattleArea;
		if (DungeonOperationMgr.Instance.CheckCardDead(cd) || (!battleArea.Contains(csd) && !playerBattleArea.Contains(csd)) || (!battleArea.Contains(cd.CurrentCardSlotData) && !playerBattleArea.Contains(cd.CurrentCardSlotData)) || csd == cd.CurrentCardSlotData)
		{
			yield break;
		}
		if (base.GetLogic(cd, typeof(BaiGuYuZuCardLogic)) != null)
		{
			yield break;
		}
		this.GetChainLighting(new Vector3(-8.7f, 0f, 6.9f), cd.CardGameObject.transform.position, 1);
		cd.AddAffix(DungeonAffix.bleeding, 1);
		yield break;
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.MoveEvent));
		yield break;
	}

	private float buff = 0.2f;
}
