using System;
using System.Collections;

public class ChuangKeTieCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_创可贴");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_创可贴");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_创可贴");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_创可贴");
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		base.OnBeforeAttack(player, target);
		if (player == this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			this.targetMonster = target.ChildCardData;
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (player == this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(this.targetMonster) && this.targetMonster.HasAffix(DungeonAffix.bleeding))
		{
			base.ShowMe();
			yield return base.Cure(this.CardData, this.targetMonster.GetAffixData(DungeonAffix.bleeding), this.CardData);
			this.targetMonster = null;
		}
		yield break;
	}

	public CardData targetMonster;
}
