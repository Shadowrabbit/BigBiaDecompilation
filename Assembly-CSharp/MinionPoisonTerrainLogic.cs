using System;
using System.Collections;
using UnityEngine;

public class MinionPoisonTerrainLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "猛毒";
		this.Desc = "被本单位攻击后的目标进入中毒状态，每回合减少本单位当前攻击力的10%。";
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData)
		{
			this.AddLogic("PoisonLogic", Mathf.CeilToInt((float)this.CardData.ATK * 0.1f), target.ChildCardData);
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
