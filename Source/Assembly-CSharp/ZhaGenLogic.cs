using System;
using System.Collections;

public class ZhaGenLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_144");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_44");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_144");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_44");
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		if (target.ChildCardData == this.CardData)
		{
			this.m_Slot = target;
		}
		yield break;
	}

	public override IEnumerator OnFinishAttack(CardData player, CardSlotData target)
	{
		if (target != this.CardData.CurrentCardSlotData && !DungeonOperationMgr.Instance.CheckCardDead(this.CardData))
		{
			base.ShowMe();
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, player, player.ATK, 0.2f, false, 0, null, null);
		}
		yield break;
	}

	private CardSlotData m_Slot;
}
