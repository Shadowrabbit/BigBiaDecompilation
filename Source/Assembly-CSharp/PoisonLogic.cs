using System;
using System.Collections;
using UnityEngine;

public class PoisonLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "毒";
		base.Layers = 1;
		this.Desc = string.Concat(new string[]
		{
			"该单位每回合生命值-",
			base.Layers.ToString(),
			"，持续",
			this.ExistsRound.ToString(),
			"回合。"
		});
		this.ExistsRound = 5;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Desc = string.Concat(new string[]
		{
			"该单位每回合生命值-",
			base.Layers.ToString(),
			"，持续",
			this.ExistsRound.ToString(),
			"回合。"
		});
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (this.CardData.HasTag(TagMap.随从) && isPlayerTurn && !DungeonOperationMgr.Instance.CheckCardDead(this.CardData))
		{
			int num = base.Layers;
			num = ((this.CardData.HP - num > 0) ? num : this.CardData.HP);
			base.ShowMe();
			this.CardData.HP -= num;
			GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, num.ToString(), UnityEngine.Color.red, 0, false, false);
			if (this.CardData.HP <= 0)
			{
				DungeonOperationMgr.Instance.DungeonHandler.Die(this.CardData, num, this.CardData);
			}
		}
		if (this.CardData.HasTag(TagMap.怪物) && !isPlayerTurn && !DungeonOperationMgr.Instance.CheckCardDead(this.CardData))
		{
			int num2 = base.Layers;
			num2 = ((this.CardData.HP - num2 > 0) ? num2 : this.CardData.HP);
			base.ShowMe();
			this.CardData.HP -= num2;
			GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, num2.ToString(), UnityEngine.Color.red, 0, false, false);
			if (this.CardData.HP <= 0)
			{
				DungeonOperationMgr.Instance.DungeonHandler.Die(this.CardData, num2, this.CardData);
			}
		}
		yield return base.OnEndTurn(isPlayerTurn);
		yield break;
	}
}
