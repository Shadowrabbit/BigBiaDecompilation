using System;
using System.Collections;
using System.Collections.Generic;

public class YangYuPeiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_玉佩阳");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_玉佩阳");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_玉佩阳");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_玉佩阳");
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
		List<CardData> list = new List<CardData>();
		if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) < slotsOnPlayerTable.Count / 3 * 2)
		{
			CardSlotData cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3];
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != 0 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 * 2)
		{
			CardSlotData cardSlotData2 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) - 1];
			if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData2.ChildCardData);
			}
		}
		if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 - 1 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 * 2 - 1 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count - 1)
		{
			CardSlotData cardSlotData3 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) + 1];
			if (cardSlotData3.ChildCardData != null && cardSlotData3.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData3.ChildCardData);
			}
		}
		if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) >= slotsOnPlayerTable.Count / 3)
		{
			CardSlotData cardSlotData4 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3];
			if (cardSlotData4.ChildCardData != null && cardSlotData4.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData4.ChildCardData);
			}
		}
		if (list.Count <= 0)
		{
			yield break;
		}
		if (list.Contains(user) && base.GetLogic(user, typeof(YinYuPeiCardLogic)) != null)
		{
			CardLogic logic = this.AddLogic(origin.GetType().Name, origin.Layers);
			bool state = this.CardData.IsAttacked;
			if (logic is FaithCardLogic)
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_玉佩毫无反应"));
			}
			else
			{
				base.ShowMe();
				yield return logic.OnUseSkill();
			}
			this.CardData.CardLogics.Remove(logic);
			this.CardData.IsAttacked = state;
			yield return logic.Terminate(this.CardData.CurrentCardSlotData);
			logic = null;
		}
		yield break;
	}

	private CardLogic AddLogic(string logicName, int layer = 0)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.CardData = this.CardData;
		cardLogic.Layers = layer;
		cardLogic.Init();
		this.CardData.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(this.CardData);
		return cardLogic;
	}
}
