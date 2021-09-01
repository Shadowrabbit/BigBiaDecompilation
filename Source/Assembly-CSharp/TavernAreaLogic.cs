using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class TavernAreaLogic : BrookAreaLogic
{
	public override void BeforeInit()
	{
		GameController.getInstance().UIController.ShowBackToHomeButton();
		DungeonController.Instance.CurrentDungeonLogic = this;
		Lua.RegisterFunction("UnLockTavernSlot", this, SymbolExtensions.GetMethodInfo(Expression.Lambda<Action>(Expression.Call(Expression.Constant(this, typeof(TavernAreaLogic)), methodof(TavernAreaLogic.UnLockTavernSlot()), Array.Empty<Expression>()), Array.Empty<ParameterExpression>())));
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent += this.OnCardChangeSlot;
		int num = GlobalController.Instance.GlobalData.HadSlotCount;
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
		{
			base.Data.CardSlotDatas = new List<CardSlotData>();
			int num2 = 0;
			for (int i = 0; i < (base.Data as SpaceAreaData).CardSlotGridHeight; i++)
			{
				for (int j = 0; j < (base.Data as SpaceAreaData).CardSlotGridWidth; j++)
				{
					if ((base.Data as SpaceAreaData).GridOpenState[i * (base.Data as SpaceAreaData).CardSlotGridWidth + j] != 0)
					{
						num2++;
						CardSlotData cardSlotData = new CardSlotData();
						cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
						if (num > 0)
						{
							cardSlotData.IconIndex = 1;
							cardSlotData.SlotType = CardSlotData.Type.OnlyTake;
						}
						else
						{
							cardSlotData.IconIndex = 2;
							cardSlotData.SlotType = CardSlotData.Type.Freeze;
						}
						cardSlotData.GridPositionX = j;
						cardSlotData.GridPositionY = i;
						cardSlotData.TagWhiteList = 0UL;
						cardSlotData.OnlyAcceptOneCard = true;
						switch (num2)
						{
						case 0:
						case 1:
							cardSlotData.DisplayPositionX = 0f;
							cardSlotData.DisplayPositionZ = -4.77f;
							break;
						case 2:
							cardSlotData.DisplayPositionX = 2.86f;
							cardSlotData.DisplayPositionZ = -4.77f;
							break;
						case 3:
							cardSlotData.DisplayPositionX = 4.41f;
							cardSlotData.DisplayPositionZ = -4.77f;
							break;
						case 4:
							cardSlotData.DisplayPositionX = 7.41f;
							cardSlotData.DisplayPositionZ = -4.77f;
							break;
						case 5:
							cardSlotData.DisplayPositionX = 0f;
							cardSlotData.DisplayPositionZ = -6.68f;
							break;
						case 6:
							cardSlotData.DisplayPositionX = 2.86f;
							cardSlotData.DisplayPositionZ = -6.68f;
							break;
						case 7:
							cardSlotData.DisplayPositionX = 4.41f;
							cardSlotData.DisplayPositionZ = -6.68f;
							break;
						case 8:
							cardSlotData.DisplayPositionX = 7.41f;
							cardSlotData.DisplayPositionZ = -6.68f;
							break;
						}
						cardSlotData.CurrentAreaData = base.Data;
						base.Data.CardSlotDatas.Add(cardSlotData);
						num--;
					}
				}
			}
		}
	}

	public override void OnDayPass()
	{
		if (base.Data.Attrs.ContainsKey("OnDayFirst"))
		{
			base.Data.Attrs["OnDayFirst"] = false;
			return;
		}
		base.Data.Attrs.Add("OnDayFirst", false);
	}

	public override IEnumerator OnAlreadEnter()
	{
		if (base.Data.Attrs.ContainsKey("OnDayFirst"))
		{
			if (!(bool)base.Data.Attrs["OnDayFirst"])
			{
				base.Data.Attrs["OnDayFirst"] = true;
				this.UpdateMinion();
			}
		}
		else
		{
			base.Data.Attrs.Add("OnDayFirst", true);
			this.UpdateMinion();
		}
		foreach (CardSlotData cardSlotData in base.Data.CardSlotDatas)
		{
			cardSlotData.CardSlotGameObject.transform.position = new Vector3(cardSlotData.CardSlotGameObject.transform.position.x, 0.76f, cardSlotData.CardSlotGameObject.transform.position.z);
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ModID != null)
			{
				cardSlotData.ChildCardData.CardGameObject.PriceText.transform.parent.gameObject.SetActive(true);
				cardSlotData.ChildCardData.CardGameObject.PriceText.text = (cardSlotData.ChildCardData.Price.ToString() ?? "");
			}
		}
		this.TavernArea = UnityEngine.Object.FindObjectOfType<TavernArea>();
		this.TavernArea.TavernAreaLogic = this;
		return base.OnAlreadEnter();
	}

	public override void OnExit()
	{
		base.OnExit();
		GameController.getInstance().UIController.HideBackToHomeButton();
		Lua.UnregisterFunction("UnLockTavernSlot");
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent -= this.OnCardChangeSlot;
	}

	private void OnCardChangeSlot(CardSlotData oldCardSlot, CardSlotData newCardSlot, CardData card)
	{
		if (oldCardSlot != null && oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area && newCardSlot.SlotOwnerType == CardSlotData.OwnerType.SecondaryAct)
		{
			if (GlobalController.Instance.GlobalData.Money >= card.Price)
			{
				GlobalController.Instance.ChangeGlobalMoney(-card.Price);
				card.CardGameObject.PriceText.transform.parent.gameObject.SetActive(false);
				return;
			}
			card.PutInSlotData(oldCardSlot, true);
			GameController.getInstance().CreateSubtitle("您的资金还不足以拥有此单位！", 1f, 2f, 1f, 1f);
		}
	}

	private void UnLockTavernSlot()
	{
		int num = GlobalController.Instance.GlobalData.HadSlotCount;
		List<CardSlotData> list = new List<CardSlotData>();
		foreach (CardSlotData item in base.Data.CardSlotDatas)
		{
			if (num > 0)
			{
				num--;
			}
			else
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			list[0].SlotType = CardSlotData.Type.OnlyTake;
			list[0].IconIndex = 1;
			list[0].CardSlotGameObject.SetIcon(1);
			GlobalController.Instance.GlobalData.HadSlotCount = GlobalController.Instance.GlobalData.HadSlotCount + 1;
			GlobalController.Instance.ChangeGlobalMoney(-50);
			List<string> list2 = new List<string>();
			foreach (CardSlotData cardSlotData in base.Data.CardSlotDatas)
			{
				if (cardSlotData.ChildCardData != null)
				{
					list2.Add(cardSlotData.ChildCardData.ModID);
				}
			}
			foreach (string text in GlobalController.Instance.GetHadMinionsID())
			{
				bool flag = false;
				using (List<string>.Enumerator enumerator3 = list2.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						if (enumerator3.Current.Equals(text))
						{
							flag = true;
							break;
						}
						flag = false;
					}
				}
				if (!flag)
				{
					CardData cardData = Card.InitCardDataByID(text);
					cardData.PutInSlotData(list[0], true);
					cardData.CardGameObject.PriceText.transform.parent.gameObject.SetActive(true);
					cardData.CardGameObject.PriceText.text = (cardData.Price.ToString() ?? "");
					break;
				}
			}
		}
	}

	private void UpdateMinion()
	{
		foreach (CardSlotData cardSlotData in base.Data.CardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null)
			{
				cardSlotData.ChildCardData.DeleteCardData();
			}
		}
		List<string> list = new List<string>();
		if (GlobalController.Instance.GetHadMinionsID().Count < GlobalController.Instance.GlobalData.HadSlotCount)
		{
			using (List<string>.Enumerator enumerator2 = GlobalController.Instance.GetHadMinionsID().GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					string item = enumerator2.Current;
					list.Add(item);
				}
				goto IL_12A;
			}
		}
		for (int i = 0; i < GlobalController.Instance.GlobalData.HadSlotCount; i++)
		{
			string item2 = GlobalController.Instance.GetHadMinionsID()[SYNCRandom.Range(0, GlobalController.Instance.GetHadMinionsID().Count)];
			while (list.Contains(item2))
			{
				item2 = GlobalController.Instance.GetHadMinionsID()[SYNCRandom.Range(0, GlobalController.Instance.GetHadMinionsID().Count)];
			}
			list.Add(item2);
		}
		IL_12A:
		for (int j = 0; j < base.Data.CardSlotDatas.Count; j++)
		{
			if (list.Count == 0)
			{
				return;
			}
			string text = list[SYNCRandom.Range(0, list.Count)];
			CardData cardData = Card.InitCardDataByID(text);
			cardData.PersonName = CardData.GetChinessName();
			cardData.PutInSlotData(base.Data.CardSlotDatas[j], true);
			list.Remove(text);
		}
	}

	public TavernArea TavernArea;
}
