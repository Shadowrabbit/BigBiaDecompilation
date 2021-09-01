using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class PunctureAttackLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "穿刺攻击";
		this.Desc = "攻击目标及目标下方1格单位，并对下方1格单位造成200%伤害。";
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		CardData behindTarget = null;
		CardData targetCardData = target.ChildCardData;
		int AttackTimes = this.CardData.AttackTimes;
		int q = 0;
		TweenCallback <>9__0;
		while (q < AttackTimes)
		{
			if (DungeonOperationMgr.Instance.CheckCardDead(this.CardData) || DungeonOperationMgr.Instance.CheckCardDead(targetCardData))
			{
				yield break;
			}
			if (this.CardData.AttackExtraRange == null)
			{
				goto IL_1CB;
			}
			SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
			if (spaceAreaData == null)
			{
				goto IL_1CB;
			}
			CardSlotData checkedNeighbourSlotData = spaceAreaData.GetRalitiveCardSlotData(targetCardData.CurrentCardSlotData.GridPositionX, targetCardData.CurrentCardSlotData.GridPositionY, targetCardData.CurrentCardSlotData.GridPositionX, targetCardData.CurrentCardSlotData.GridPositionY - 1, false);
			if (checkedNeighbourSlotData != null && checkedNeighbourSlotData.ChildCardData != null && checkedNeighbourSlotData.ChildCardData.HasTag(TagMap.怪物))
			{
				yield return DungeonOperationMgr.Instance.PlayerAttackEffect(this.CardData, checkedNeighbourSlotData.ChildCardData, 0.1f, null, null, null);
				behindTarget = checkedNeighbourSlotData.ChildCardData;
				checkedNeighbourSlotData = null;
				goto IL_1CB;
			}
			IL_3A4:
			int num = q;
			q = num + 1;
			continue;
			IL_1CB:
			yield return DungeonOperationMgr.Instance.PlayerAttackEffect(this.CardData, targetCardData, 1f, null, null, null);
			ParticleObject particleObject = ParticlePoolManager.Instance.Spawn(this.CardData.ShotEffect, 0.3f);
			particleObject.transform.position = targetCardData.CardGameObject.transform.position;
			particleObject.transform.forward = behindTarget.CardGameObject.transform.position - targetCardData.CardGameObject.transform.position;
			TweenerCore<Vector3, Vector3, VectorOptions> t = particleObject.transform.DOMove(behindTarget.CardGameObject.transform.position, 0.2f, false);
			TweenCallback action;
			if ((action = <>9__0) == null)
			{
				action = (<>9__0 = delegate()
				{
					ParticlePoolManager.Instance.Spawn(this.CardData.HitEffect, 0.1f).transform.position = behindTarget.CardGameObject.transform.position + Vector3.up + Vector3.back * 0.25f;
				});
			}
			yield return t.OnComplete(action).SetEase(Ease.InCubic).WaitForCompletion();
			if (!DungeonOperationMgr.Instance.CheckCardDead(targetCardData))
			{
				yield return this.DungeonHandler.ChangeHp(targetCardData, -this.CardData.ATK, this.CardData, false, 0, true, false);
			}
			if (!DungeonOperationMgr.Instance.CheckCardDead(behindTarget))
			{
				yield return this.DungeonHandler.ChangeHp(behindTarget, -this.CardData.ATK * 2, this.CardData, false, 0, true, false);
				goto IL_3A4;
			}
			goto IL_3A4;
		}
		yield break;
	}

	public DungeonHandler DungeonHandler = new DungeonHandler();

	private const float c_MonsterShakeTime = 0.1f;
}
