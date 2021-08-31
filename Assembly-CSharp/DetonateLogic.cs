using System;
using System.Collections;
using System.Collections.Generic;

public class DetonateLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_种子自爆");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_种子自爆"), 3 - base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_种子自爆");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_种子自爆"), 3 - base.Layers);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			base.Layers++;
			if (base.Layers >= 3)
			{
				List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
				foreach (CardData cardData in allCurrentMinions)
				{
					if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
					{
						GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.PlayerAttackEffect(this.CardData, cardData, 1f, null, null, null));
					}
				}
				foreach (CardData cardData2 in allCurrentMinions)
				{
					if (!DungeonOperationMgr.Instance.CheckCardDead(cardData2))
					{
						yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cardData2, -this.CardData.ATK, this.CardData, false, 0, true, false);
					}
				}
				List<CardData>.Enumerator enumerator2 = default(List<CardData>.Enumerator);
				base.Layers = 0;
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -this.CardData.HP, this.CardData, true, 999, true, false);
			}
		}
		yield break;
		yield break;
	}
}
