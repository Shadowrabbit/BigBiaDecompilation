using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoShuShiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_99");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_99");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_99");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_99");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			yield break;
		}
		if (this.m_IsSkill)
		{
			yield break;
		}
		this.m_IsSkill = true;
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		foreach (CardData cardData in allCurrentMonsters)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				yield return this.TryJump(cardData);
			}
		}
		List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
		this.m_IsSkill = false;
		yield break;
		yield break;
	}

	public IEnumerator TryJump(CardData jumpO)
	{
		List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
		if (allEmptySlotsInMyBattleArea == null || allEmptySlotsInMyBattleArea.Count <= 0)
		{
			yield break;
		}
		CardSlotData target = allEmptySlotsInMyBattleArea[UnityEngine.Random.Range(0, allEmptySlotsInMyBattleArea.Count)];
		yield return jumpO.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		if (jumpO.Attrs.ContainsKey("Col"))
		{
			jumpO.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}

	private bool m_IsSkill;
}
