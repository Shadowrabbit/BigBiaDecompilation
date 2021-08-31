using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HeTunDuLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "神经毒素";
		this.Desc = "该单位使所有玩家卡牌进入中毒状态，每回合减少目标当前最大生命值的5%。";
	}

	public override IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
	{
		if (this.CardData.MP >= 5)
		{
			base.ShowMe();
			Sequence sequence = DOTween.Sequence();
			sequence.Append(this.CardData.CardGameObject.transform.GetChild(4).transform.DOLocalMoveY(1f, 0.3f, false));
			sequence.Append(this.CardData.CardGameObject.transform.GetChild(4).transform.DOShakePosition(1f, new Vector3(0.2f, 0f, 0.2f), 100, 90f, false, true).SetEase(Ease.OutCubic));
			yield return sequence.Play<Sequence>().WaitForCompletion();
			yield return new WaitForSeconds(0.1f);
			ParticlePoolManager.Instance.Spawn("Effect/武道家02", 3f).transform.position = this.CardData.CardGameObject.transform.position;
			this.CardData.DeleteCardData();
			using (List<CardSlotData>.Enumerator enumerator = GameController.getInstance().GameData.SlotsOnPlayerTable.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardSlotData cardSlotData = enumerator.Current;
					if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
					{
						this.AddLogic("PoisonLogic", Mathf.CeilToInt((float)cardSlotData.ChildCardData.MaxHP * 0.05f), cardSlotData.ChildCardData);
						ParticlePoolManager.Instance.Spawn("Effect/HealPoison", 3f).transform.position = cardSlotData.CardSlotGameObject.transform.position;
					}
				}
				yield break;
			}
		}
		yield break;
	}

	private new void AddLogic(string logicName, int layers, CardData target)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		cardLogic.Layers = layers;
		cardLogic.CardData = target;
		target.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(target);
	}
}
