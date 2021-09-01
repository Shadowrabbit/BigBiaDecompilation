using System;
using System.Collections;
using UnityEngine;

public class EnemyPoisonTerrainLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "猛毒";
		this.Desc = "被该单位攻击后的目标进入中毒状态，每回合减少目标当前最大生命值的5%。";
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData)
		{
			this.AddLogic("PoisonLogic", Mathf.CeilToInt((float)target.ChildCardData.MaxHP * 0.05f), target.ChildCardData);
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
