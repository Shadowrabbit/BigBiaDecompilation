using System;
using System.Collections;
using System.Collections.Generic;

public class SheHuiQingNianLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_109");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_109");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_109");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_109");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			int num = 999;
			CardData cardData = null;
			foreach (CardData cardData2 in allCurrentMinions)
			{
				if (cardData2.HP < num)
				{
					num = cardData2.HP;
					cardData = cardData2;
				}
			}
			if (cardData != null)
			{
				List<CardSlotData> myBattleArea = base.GetMyBattleArea();
				List<CardSlotData> list = new List<CardSlotData>();
				foreach (CardSlotData cardSlotData in myBattleArea)
				{
					if ((int)cardSlotData.Attrs["Col"] == (int)cardData.CurrentCardSlotData.Attrs["Col"] && cardSlotData.ChildCardData == null)
					{
						list.Add(cardSlotData);
					}
				}
				if (list.Count > 0)
				{
					CardSlotData target = list[SYNCRandom.Range(0, list.Count)];
					yield return this.TryJump(this.CardData, target);
				}
			}
		}
		yield break;
	}

	public IEnumerator TryJump(CardData jumpO, CardSlotData target)
	{
		base.ShowMe();
		yield return jumpO.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		if (jumpO.Attrs.ContainsKey("Col"))
		{
			jumpO.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}
}
