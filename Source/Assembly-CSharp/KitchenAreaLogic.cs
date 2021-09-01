using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenAreaLogic : AreaLogic
{
	public object GetCardAttr(CardData cs, string name)
	{
		if (cs.Attrs.ContainsKey(name))
		{
			if (cs.Attrs[name] != null)
			{
				return cs.Attrs[name];
			}
			if (cs.HiddenAttrs[name] != null)
			{
				return cs.HiddenAttrs[name];
			}
		}
		return 1;
	}

	public override void BeforeInit()
	{
	}

	public override void BeforeEnter()
	{
	}

	public override void OnExit()
	{
		GameController.ins.HomeTable.gameObject.SetActive(false);
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent -= this.Transaction;
		foreach (CardSlotData cardSlotData in base.Data.CardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null)
			{
				cardSlotData.ChildCardData.PutInSlotData(this.GetEmptySlotFromPlayerTable(), true);
			}
		}
		if (this.m_StartTimer != null)
		{
			GameController.getInstance().StopCoroutine(this.m_StartTimer);
		}
		base.Data.Attrs["Percent"] = 0;
		if (this.m_ProgressBar != null)
		{
			this.m_ProgressBar.SetProgress(float.Parse(base.Data.Attrs["Percent"].ToString()) / 100f, base.Data.Attrs["Percent"].ToString());
		}
		UIController.LockLevel = this.m_Lock;
	}

	public override IEnumerator OnAlreadEnter()
	{
		this.InitRecipes();
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent += this.Transaction;
		this.m_Lock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.None;
		List<CardSlotData> cardSlotDatas = base.Data.CardSlotDatas;
		base.Data.CardSlotDatas[0].CardSlotGameObject.SetIcon(8);
		foreach (CardSlotData cardSlotData in cardSlotDatas)
		{
			cardSlotData.CardSlotGameObject.SetBorder(1);
			cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
		}
		this.m_ProgressBar = UnityEngine.Object.FindObjectOfType<SpaceProgressBarTool>();
		if (this.m_ProgressBar != null)
		{
			this.m_ProgressBar.SetProgress(float.Parse(base.Data.Attrs["Percent"].ToString()) / 100f, base.Data.Attrs["Percent"].ToString());
		}
		yield break;
	}

	private void Transaction(CardSlotData oldCardSlot, CardSlotData newCardSlot, CardData card)
	{
		if (oldCardSlot == null || newCardSlot == null)
		{
			return;
		}
		if (oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Player && newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area)
		{
			if (card.HasTag(TagMap.食物) || card.ModID.Equals("能量卡片"))
			{
				if ((newCardSlot == base.Data.CardSlotDatas[0] && !card.ModID.Equals("能量卡片")) || (card.ModID.Equals("能量卡片") && newCardSlot != base.Data.CardSlotDatas[0]))
				{
					card.PutInSlotData(oldCardSlot, true);
					return;
				}
				if (card.Count > 1)
				{
					Card card2 = Card.InitCard(CardData.CopyCardData(card, true));
					card2.CardData.Count = card.Count - 1;
					card2.RefreshCountText();
					card2.CardData.PutInSlotData(oldCardSlot, true);
					card.MaxCount = 1;
					card.Count = 1;
					card.CardGameObject.RefreshCountText();
				}
				int num = 0;
				using (List<CardSlotData>.Enumerator enumerator = base.Data.CardSlotDatas.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.ChildCardData != null)
						{
							num++;
						}
					}
				}
				if (num > 2)
				{
					List<string> list = new List<string>();
					string value = "";
					for (int i = 0; i < base.Data.CardSlotDatas.Count; i++)
					{
						if (base.Data.CardSlotDatas[i].ChildCardData != null)
						{
							list.Add(base.Data.CardSlotDatas[i].ChildCardData.ModID);
						}
					}
					this.InitRecipes();
					foreach (KeyValuePair<string, List<string>> keyValuePair in this.Recipes)
					{
						if (keyValuePair.Value.Count == list.Count)
						{
							for (int j = list.Count - 1; j >= 0; j--)
							{
								if (keyValuePair.Value.Contains(list[j]))
								{
									keyValuePair.Value.Remove(list[j]);
								}
							}
							if (keyValuePair.Value.Count == 0)
							{
								value = keyValuePair.Key;
							}
						}
					}
					if (!string.IsNullOrEmpty(value))
					{
						this.m_StartTimer = this.StartTimer(value, card);
						GameController.getInstance().StartCoroutine(this.m_StartTimer);
					}
				}
			}
			else
			{
				card.PutInSlotData(oldCardSlot, true);
			}
		}
		if (newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Player && oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Area && this.m_StartTimer != null)
		{
			GameController.getInstance().StopCoroutine(this.m_StartTimer);
			base.Data.Attrs["Percent"] = 0;
			if (this.m_ProgressBar != null)
			{
				this.m_ProgressBar.SetProgress(float.Parse(base.Data.Attrs["Percent"].ToString()) / 100f, base.Data.Attrs["Percent"].ToString());
			}
		}
	}

	private void StartGiftAct(string value, Card card)
	{
		(card.StartAct(new ActData
		{
			Type = "Act/Gift",
			Model = "ActTable/Gift"
		}) as GiftAct).GiftNames.Add(value);
	}

	private void InitRecipes()
	{
		this.Recipes = new Dictionary<string, List<string>>();
		this.Recipes.Add("鱼肉一明治", new List<string>
		{
			"能量卡片",
			"小麦",
			"鲑鱼",
			"生菜"
		});
		this.Recipes.Add("鱼肉二明治", new List<string>
		{
			"能量卡片",
			"小麦",
			"泡泡鱼",
			"生菜"
		});
		this.Recipes.Add("鱼肉三明治", new List<string>
		{
			"能量卡片",
			"小麦",
			"大泡泡鱼",
			"生菜"
		});
		this.Recipes.Add("黄金鱼肉三明治", new List<string>
		{
			"能量卡片",
			"小麦",
			"黄金泡泡鱼",
			"生菜"
		});
		this.Recipes.Add("翡翠牛肉汉堡", new List<string>
		{
			"能量卡片",
			"小麦",
			"生菜",
			"肉"
		});
		this.Recipes.Add("翡翠烤肉", new List<string>
		{
			"能量卡片",
			"生菜",
			"肉"
		});
		this.Recipes.Add("菜饼", new List<string>
		{
			"能量卡片",
			"小麦",
			"生菜"
		});
		this.Recipes.Add("细鱼豆腐汤", new List<string>
		{
			"能量卡片",
			"大豆",
			"鲑鱼"
		});
		this.Recipes.Add("鱼肉豆腐汤", new List<string>
		{
			"能量卡片",
			"大豆",
			"泡泡鱼"
		});
		this.Recipes.Add("鱼头豆腐汤", new List<string>
		{
			"能量卡片",
			"大豆",
			"大泡泡鱼"
		});
		this.Recipes.Add("黄金鱼头豆腐煲", new List<string>
		{
			"能量卡片",
			"大豆",
			"黄金泡泡鱼"
		});
		this.Recipes.Add("豆饼", new List<string>
		{
			"能量卡片",
			"小麦",
			"大豆"
		});
		this.Recipes.Add("翡翠豆饼", new List<string>
		{
			"能量卡片",
			"生菜",
			"大豆",
			"小麦"
		});
		this.Recipes.Add("大豆炖肉", new List<string>
		{
			"能量卡片",
			"肉",
			"大豆"
		});
		this.Recipes.Add("炸小鱼排", new List<string>
		{
			"能量卡片",
			"小麦",
			"鲑鱼"
		});
		this.Recipes.Add("普通炸鱼排", new List<string>
		{
			"能量卡片",
			"小麦",
			"泡泡鱼"
		});
		this.Recipes.Add("上等炸鱼排", new List<string>
		{
			"能量卡片",
			"小麦",
			"大泡泡鱼"
		});
		this.Recipes.Add("黄金炸鱼排", new List<string>
		{
			"能量卡片",
			"小麦",
			"黄金泡泡鱼"
		});
		this.Recipes.Add("牛肉汉堡", new List<string>
		{
			"能量卡片",
			"小麦",
			"肉"
		});
		this.Recipes.Add("鲜肉汤", new List<string>
		{
			"能量卡片",
			"生菜",
			"肉"
		});
	}

	private IEnumerator StartTimer(string value, CardData card)
	{
		for (;;)
		{
			if (base.Data.Attrs.ContainsKey("Percent"))
			{
				base.Data.Attrs["Percent"] = int.Parse(base.Data.Attrs["Percent"].ToString()) + 1;
				if (this.m_ProgressBar != null)
				{
					this.m_ProgressBar.SetProgress(float.Parse(base.Data.Attrs["Percent"].ToString()) / 100f, base.Data.Attrs["Percent"].ToString());
				}
				if (int.Parse(base.Data.Attrs["Percent"].ToString()) > 99)
				{
					break;
				}
			}
			yield return new WaitForSeconds(0.1f);
		}
		base.Data.Attrs["Percent"] = 0;
		this.m_ProgressBar.SetProgress(float.Parse(base.Data.Attrs["Percent"].ToString()) / 100f, base.Data.Attrs["Percent"].ToString());
		this.StartGiftAct(value, card.CardGameObject);
		foreach (CardSlotData cardSlotData in base.Data.CardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null)
			{
				cardSlotData.ChildCardData.DeleteCardData();
			}
		}
		yield break;
		yield break;
	}

	private CardSlotData GetEmptySlotFromPlayerTable()
	{
		for (int i = 0; i < GlobalController.Instance.HomeDataController.GetPlayerTableCardSlotDatasToHomeData().Count; i++)
		{
			if (GlobalController.Instance.HomeDataController.GetPlayerTableCardSlotDatasToHomeData()[i].ChildCardData == null)
			{
				return GlobalController.Instance.HomeDataController.GetPlayerTableCardSlotDatasToHomeData()[i];
			}
		}
		return null;
	}

	private UIController.UILevel m_Lock = UIController.UILevel.All;

	private SpaceProgressBarTool m_ProgressBar;

	private Dictionary<string, List<string>> Recipes = new Dictionary<string, List<string>>();

	private IEnumerator m_StartTimer;
}
