using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JingShenXiaoHuoLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_107");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_107");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_107");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_107");
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player != this.CardData || target.ChildCardData.HasTag(TagMap.英雄))
		{
			yield break;
		}
		GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_2"), UnityEngine.Color.white, 0, false, false);
		yield return this.TryJump(target.ChildCardData);
		yield break;
	}

	public IEnumerator TryJump(CardData jumpO)
	{
		List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
		if (enemiesBattleArea.IndexOf(jumpO.CurrentCardSlotData) < enemiesBattleArea.Count - 3)
		{
			CardSlotData target = enemiesBattleArea[enemiesBattleArea.IndexOf(jumpO.CurrentCardSlotData) + 3];
			CardData card = jumpO;
			yield return card.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
			if (card.Attrs.ContainsKey("Col"))
			{
				card.Attrs["Col"] = target.Attrs["Col"];
			}
			target = null;
			card = null;
		}
		yield break;
	}
}
