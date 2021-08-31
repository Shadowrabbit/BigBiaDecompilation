using System;
using System.Collections;
using System.Collections.Generic;

public class TeZhongBingCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_21");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_21");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_21");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_21");
	}

	public override IEnumerator OnFinishAttack(CardData player, CardSlotData target)
	{
		base.OnFinishAttack(player, target);
		if (player == this.CardData && !this.HasJumped)
		{
			this.HasJumped = true;
			yield return this.TryJump(this.CardData.CurrentCardSlotData);
		}
		yield break;
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData && this.HasJumped)
		{
			this.HasJumped = false;
			yield break;
		}
		yield break;
	}

	public IEnumerator TryJump(CardSlotData csd)
	{
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		List<CardSlotData> list = new List<CardSlotData>();
		if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != 0 && myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != myBattleArea.Count / 3 && myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != myBattleArea.Count / 3 * 2 && myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) - 1].ChildCardData == null)
		{
			CardSlotData item = myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) - 1];
			list.Add(item);
		}
		if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != myBattleArea.Count / 3 - 1 && myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != myBattleArea.Count / 3 * 2 - 1 && myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != myBattleArea.Count - 1 && myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + 1].ChildCardData == null)
		{
			CardSlotData item2 = myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + 1];
			list.Add(item2);
		}
		if (list.Count == 0)
		{
			yield break;
		}
		CardSlotData cardSlotData = list[SYNCRandom.Range(0, list.Count)];
		CardData childCardData = csd.ChildCardData;
		base.ShowMe();
		yield return childCardData.CardGameObject.JumpToSlot(cardSlotData.CardSlotGameObject, 0.2f, true);
		yield break;
	}

	private bool HasJumped;
}
