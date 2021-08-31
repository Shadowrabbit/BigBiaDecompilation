using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FeedLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = "盛宴";
		this.Desc = "己方回合结束时，回复随机1名友方单位" + base.Layers.ToString() + "生命。重复X次，X为充能层数。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
			List<CardData> HurtMinions = new List<CardData>();
			using (List<CardSlotData>.Enumerator enumerator = playerSlotSets.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardSlotData cardSlotData = enumerator.Current;
					if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从) && cardSlotData.ChildCardData != this.CardData && cardSlotData.ChildCardData.HP < cardSlotData.ChildCardData.MaxHP)
					{
						HurtMinions.Add(cardSlotData.ChildCardData);
					}
				}
				goto IL_268;
			}
			IL_ED:
			if (HurtMinions.Count <= 0)
			{
				goto IL_279;
			}
			CardData CureTarget = HurtMinions[UnityEngine.Random.Range(0, HurtMinions.Count)];
			ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HellHpBall", 0.2f);
			particleObject.transform.position = this.CardData.CardGameObject.transform.position;
			yield return particleObject.transform.DOMove(CureTarget.CardGameObject.transform.position, 0.2f, false).WaitForCompletion();
			string name = "Effect/HealHp";
			ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = CureTarget.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(CureTarget, base.Layers, this.CardData, false, 0, true, false);
			if (CureTarget.HP == CureTarget.MaxHP)
			{
				HurtMinions.Remove(CureTarget);
			}
			this.CardData.MP--;
			CureTarget = null;
			IL_268:
			if (this.CardData.MP > 0)
			{
				goto IL_ED;
			}
			IL_279:
			HurtMinions = null;
		}
		yield break;
	}
}
