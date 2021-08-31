using System;
using System.Collections;
using System.Collections.Generic;

public class ShePiZouWeiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇9");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇9");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇9");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇9");
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		if (player == this.CardData)
		{
			this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_66_2");
			base.ShowMe();
			this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_66_1");
			yield return this.TryJump(player.CurrentCardSlotData);
		}
		yield break;
	}

	public IEnumerator TryJump(CardSlotData csd)
	{
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		if (myBattleArea == null)
		{
			yield break;
		}
		CardSlotData target = myBattleArea[SYNCRandom.Range(0, myBattleArea.Count)];
		while (target.ChildCardData != null)
		{
			target = myBattleArea[SYNCRandom.Range(0, myBattleArea.Count)];
		}
		CardData card = csd.ChildCardData;
		yield return card.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		if (card.Attrs.ContainsKey("Col"))
		{
			card.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}
}
