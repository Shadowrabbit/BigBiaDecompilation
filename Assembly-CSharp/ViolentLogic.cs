using System;
using System.Collections;

public class ViolentLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = "暴戾";
		this.Desc = "己方回合结束时，若本回合击杀过一名敌人，使自己下回合攻击伤害翻倍。";
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target.HasTag(TagMap.怪物) && from != null && from == this.CardData)
		{
			this.HasKillEnemy = true;
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn && this.HasKillEnemy)
		{
			DoubleDamageLogic doubleDamageLogic = new DoubleDamageLogic
			{
				ExistsRound = 1
			};
			doubleDamageLogic.CardData = this.CardData;
			doubleDamageLogic.me = this.CardData.CardGameObject;
			this.CardData.CardLogicClassNames.Add("DoubleDamageLogic");
			this.CardData.CardLogics.Add(doubleDamageLogic);
			this.CardData.CardLogics[this.CardData.CardLogics.Count - 1].Init();
		}
		yield break;
	}

	private bool HasKillEnemy;
}
