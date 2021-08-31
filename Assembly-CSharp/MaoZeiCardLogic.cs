using System;
using System.Collections;
using System.Collections.Generic;

public class MaoZeiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_70");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_70");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_70");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_70");
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		CardData Target = null;
		foreach (CardData cardData in allCurrentMinions)
		{
			if (cardData.CurrentCardSlotData.GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col"))
			{
				Target = cardData;
			}
		}
		if (Target == null)
		{
			yield break;
		}
		List<CardSlotData> playerBattleArea = DungeonOperationMgr.Instance.PlayerBattleArea;
		List<CardData> list = new List<CardData>();
		if (playerBattleArea.IndexOf(Target.CurrentCardSlotData) < playerBattleArea.Count / 3 * 2)
		{
			CardSlotData cardSlotData = playerBattleArea[playerBattleArea.IndexOf(Target.CurrentCardSlotData) + playerBattleArea.Count / 3];
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		if (playerBattleArea.IndexOf(Target.CurrentCardSlotData) != 0 && playerBattleArea.IndexOf(Target.CurrentCardSlotData) != playerBattleArea.Count / 3 && playerBattleArea.IndexOf(Target.CurrentCardSlotData) != playerBattleArea.Count / 3 * 2)
		{
			CardSlotData cardSlotData2 = playerBattleArea[playerBattleArea.IndexOf(Target.CurrentCardSlotData) - 1];
			if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData2.ChildCardData);
			}
		}
		if (playerBattleArea.IndexOf(Target.CurrentCardSlotData) != playerBattleArea.Count / 3 - 1 && playerBattleArea.IndexOf(Target.CurrentCardSlotData) != playerBattleArea.Count / 3 * 2 - 1 && playerBattleArea.IndexOf(Target.CurrentCardSlotData) != playerBattleArea.Count - 1)
		{
			CardSlotData cardSlotData3 = playerBattleArea[playerBattleArea.IndexOf(Target.CurrentCardSlotData) + 1];
			if (cardSlotData3.ChildCardData != null && cardSlotData3.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData3.ChildCardData);
			}
		}
		if (playerBattleArea.IndexOf(Target.CurrentCardSlotData) >= playerBattleArea.Count / 3)
		{
			CardSlotData cardSlotData4 = playerBattleArea[playerBattleArea.IndexOf(Target.CurrentCardSlotData) - playerBattleArea.Count / 3];
			if (cardSlotData4.ChildCardData != null && cardSlotData4.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData4.ChildCardData);
			}
		}
		if (list.Count <= 0)
		{
			base.ShowMe();
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, Target, 0, 0.2f, false, 0, null, null);
			Target.wATK -= Target.ATK;
		}
		yield break;
	}
}
