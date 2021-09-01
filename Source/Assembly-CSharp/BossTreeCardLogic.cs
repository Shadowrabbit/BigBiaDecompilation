using System;
using System.Collections;
using UnityEngine;

public class BossTreeCardLogic : CardLogic
{
	public override IEnumerator OnEnterArea(string areaID)
	{
		if (areaID == "BossTree")
		{
			this.CardData = DungeonOperationMgr.Instance.InitDungeonMonster(this.CardData, 30);
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (this.CardData.Armor <= 0 && base.Layers == 1)
		{
			base.Layers++;
			this.CardData.MaxArmor = 0;
			this.CardData.DizzyLayer = 0;
			base.ShowMe();
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn && base.Layers == 2)
		{
			this.changeStage++;
			if (this.changeStage == 3)
			{
				base.Layers = 1;
				this.CardData.MaxArmor = 10;
				this.CardData.Armor = 10;
				this.CardData.DizzyLayer = 0;
				base.ShowMe();
				this.changeStage = 0;
			}
		}
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target == this.CardData)
		{
			UnityEngine.Object.FindObjectOfType<BossTreeArea>().Boss.GetComponent<Animator>().SetTrigger("Die");
			SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_famugong);
		}
		yield break;
	}

	private int changeStage;
}
