using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShopCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "进货";
		this.Desc = "在地图上再移动" + (this.RefreshTime - base.Layers).ToString() + "步，商铺会更新货物。";
	}

	public override IEnumerator OnMoveOnMap()
	{
		base.OnMoveOnMap();
		int layers = base.Layers;
		base.Layers = layers + 1;
		if (base.Layers < this.RefreshTime)
		{
			yield break;
		}
		base.ShowMe();
		foreach (CardData cardData in this.allCardDatas)
		{
			if (cardData.HasTag(TagMap.道具) && !this.AlllockedItemNames.Contains(cardData.ModID))
			{
				this.allItems.Add(cardData);
			}
		}
		if (this.allItems.Count > 0)
		{
			string text = "";
			for (int i = 0; i < 4; i++)
			{
				string modID = this.allItems[UnityEngine.Random.Range(0, this.allItems.Count)].ModID;
				text += modID;
				if (i != 3)
				{
					text += ",";
				}
			}
			if (this.CardData.Attrs.ContainsKey("Goods"))
			{
				this.CardData.Attrs["Goods"] = text;
			}
			else
			{
				this.CardData.Attrs.Add("Goods", text);
			}
		}
		yield break;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "进货";
		this.Desc = "还有" + (this.RefreshTime - base.Layers).ToString() + "个回合，商铺会更新货物。";
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		foreach (CardData cardData in this.allCardDatas)
		{
			if (cardData.HasTag(TagMap.道具) && !this.AlllockedItemNames.Contains(cardData.ModID))
			{
				this.allItems.Add(cardData);
			}
		}
		if (this.allItems.Count > 0)
		{
			string text = "";
			for (int i = 0; i < 4; i++)
			{
				string modID = this.allItems[UnityEngine.Random.Range(0, this.allItems.Count)].ModID;
				text += modID;
				if (i != 3)
				{
					text += ",";
				}
			}
			if (mergeBy.Attrs.ContainsKey("Goods"))
			{
				mergeBy.Attrs["Goods"] = text;
				return;
			}
			mergeBy.Attrs.Add("Goods", text);
		}
	}

	private List<CardData> allCardDatas = GameController.getInstance().CardDataModMap.Cards;

	private List<string> AlllockedItemNames = GlobalController.Instance.GlobalData.LockedItemsModID;

	private List<CardData> allItems = new List<CardData>();

	private int RefreshTime = 5;
}
