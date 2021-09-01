using System;
using System.Collections;

public class XieZiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_尾针");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_尾针");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_尾针");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_尾针");
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player != this.CardData)
		{
			yield break;
		}
		if (target.ChildCardData != null && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			base.ShowMe();
			GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, target.ChildCardData, 0, 0.2f, false, 0, null, null));
			target.SlotType = CardSlotData.Type.Freeze;
			this.m_IsMaBi = true;
			this.m_Slot = target;
		}
		yield break;
	}

	public override IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
	{
		if (cardSlot == this.m_Slot)
		{
			this.m_Slot.SlotType = CardSlotData.Type.Normal;
			this.m_Slot = null;
		}
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target == this.CardData && this.m_Slot != null)
		{
			this.m_Slot.SlotType = CardSlotData.Type.Normal;
			this.m_Slot = null;
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn && this.m_IsMaBi)
		{
			this.m_Round++;
			if (this.m_Round % 2 == 0)
			{
				this.m_Round = 0;
				this.m_Slot.SlotType = CardSlotData.Type.Normal;
				this.m_Slot = null;
			}
		}
		yield break;
	}

	private int m_Round;

	private bool m_IsMaBi;

	private CardSlotData m_Slot;
}
