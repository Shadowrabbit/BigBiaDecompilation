using System;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBattleCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		if (this.CardData != null && GameController.ins != null && GameController.ins.CardDataModMap != null && GameController.ins.CardDataModMap.getCardDataByModID("战斗卡") == null)
		{
			return;
		}
		if (this.CardData.Attrs.ContainsKey("Theme"))
		{
			string str = this.CardData.Attrs["Theme"].ToString();
			CardData cardData = this.CardData;
			cardData.desc = cardData.desc + "theme:" + str;
			return;
		}
		if (this.CardData != null)
		{
			List<CardData> cards = GameController.ins.CardDataModMap.Cards;
			if (cards.Count == 0)
			{
				return;
			}
			List<CardData> list = new List<CardData>();
			int num = (Mathf.CeilToInt((float)(GameController.ins.GameData.step / 1)) > 0) ? 5 : 1;
			foreach (CardData cardData2 in cards)
			{
				if (cardData2.HasTag(TagMap.地下城入口) && cardData2.HasTag(TagMap.地点) && !cardData2.HasTag(TagMap.特殊) && !cardData2.HasTag(TagMap.BOSS) && cardData2.Attrs.ContainsKey("Theme") && cardData2.Level <= num)
				{
					list.Add(CardData.CopyCardData(cardData2, true));
				}
			}
			CardData cardData3 = list[SYNCRandom.Range(0, list.Count)];
			object value = cardData3.Attrs["Theme"];
			if (this.CardData.Attrs.ContainsKey("Theme"))
			{
				this.CardData.Attrs["Theme"] = value;
			}
			else
			{
				this.CardData.Attrs.Add("Theme", value);
			}
			AreaData areaData = GameController.getInstance().GameData.AreaMap[cardData3.ModID];
			if (areaData.Attrs.ContainsKey("JieJieName"))
			{
				if (this.CardData.Attrs.ContainsKey("JieJieName"))
				{
					this.CardData.Attrs["JieJieName"] = areaData.Attrs["JieJieName"];
				}
				else
				{
					this.CardData.Attrs.Add("JieJieName", areaData.Attrs["JieJieName"]);
				}
			}
			this.CardData.desc = "战斗主题:" + cardData3.ModID;
		}
	}
}
