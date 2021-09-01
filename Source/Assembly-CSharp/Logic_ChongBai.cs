using System;
using System.Collections;
using UnityEngine;

public class Logic_ChongBai : TwoPeopleCardLogic
{
	public override void Init()
	{
		if (this.ExistsRound < 1 || this.ExistsRound > 1000)
		{
			this.ExistsRound = UnityEngine.Random.Range(3, 8);
		}
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_154");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_154");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			CardData cardByID = base.GetCardByID(this.TargetID);
			if (cardByID != null)
			{
				if (cardByID == this.CardData)
				{
					yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_崇拜1"));
					this.CardData.RemoveCardLogic(this);
					yield break;
				}
				int targetSlotIndex = base.GetMyBattleArea().IndexOf(cardByID.CurrentCardSlotData);
				if (targetSlotIndex > 2 && base.GetMyBattleArea()[targetSlotIndex - 3].ChildCardData == null)
				{
					yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_43"));
					yield return this.CardData.CardGameObject.JumpToSlot(base.GetMyBattleArea()[targetSlotIndex - 3].CardSlotGameObject, 0.2f, true);
				}
			}
			else
			{
				yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_崇拜2"));
				this.CardData.RemoveCardLogic(this);
			}
		}
		yield break;
	}
}
