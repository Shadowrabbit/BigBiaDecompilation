using System;
using System.Collections.Generic;
using UnityEngine;

public class ShowCardsByTypeOnSelectAreaController : MonoBehaviour
{
	private void Start()
	{
		this.InitPanel(this.ShowType, this.Dir);
	}

	public void InitPanel(string type, int dir)
	{
		this.ClearSlotsAndCards();
		this.CreateSlotsOnTable(dir, type);
	}

	private void CreateSlotsOnTable(int dir, string type)
	{
		this.m_Slots = new List<CardSlot>();
		List<CardSlotData> list = new List<CardSlotData>();
		if (type != null)
		{
			if (!(type == "Minion"))
			{
				if (!(type == "Item"))
				{
					if (type == "Skill")
					{
						list = GlobalController.Instance.HomeDataController.GetMagicTableCardSlotDatasToHomeData();
					}
				}
				else
				{
					list = GlobalController.Instance.HomeDataController.GetItemTableCardSlotDatasToHomeData();
				}
			}
			else
			{
				list = GlobalController.Instance.HomeDataController.GetPlayerTableCardSlotDatasToHomeData();
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			CardSlotData cardSlotData = list[i];
			if (dir == 1)
			{
				cardSlotData.SlotForward = CardSlotData.Forward.Back;
			}
			else
			{
				cardSlotData.SlotForward = CardSlotData.Forward.Forward;
			}
			CardSlot cardSlot = CardSlot.InitCardSlot(cardSlotData, 0.111f);
			if (dir != -1)
			{
				if (dir == 1)
				{
					cardSlot.transform.SetParent(this.ShowPoint2, false);
					cardSlot.transform.localPosition = new Vector3((float)(i % this.m_Columns * -(float)dir), 0f, (float)(i / this.m_Columns * -(float)dir));
				}
			}
			else
			{
				cardSlot.transform.SetParent(this.ShowPoint1, false);
				cardSlot.transform.localPosition = new Vector3((float)(i % this.m_Columns), 0f, (float)(i / this.m_Columns * dir));
			}
			cardSlot.transform.localScale = Vector3.one;
			this.m_Slots.Add(cardSlot);
		}
		if (type != null)
		{
			if (type == "Minion")
			{
				this.SelectAreaAllSlotsController.AllMinionSlots = this.m_Slots;
				return;
			}
			if (type == "Item")
			{
				this.SelectAreaAllSlotsController.AllItemSlots = this.m_Slots;
				return;
			}
			if (!(type == "Skill"))
			{
				return;
			}
			this.SelectAreaAllSlotsController.AllMagicSlots = this.m_Slots;
		}
	}

	private void CreateCardsAndPutInSlots(string type)
	{
		if (type != null)
		{
			if (!(type == "Minion"))
			{
				if (!(type == "Item"))
				{
					if (!(type == "Skill"))
					{
						return;
					}
					goto IL_144;
				}
			}
			else
			{
				int num = 0;
				using (List<CardData>.Enumerator enumerator = GameController.getInstance().CardDataModMap.Cards.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						CardData cardData = enumerator.Current;
						if (cardData.CardTags == 128UL && cardData.Rare == 1 && num < this.m_Slots.Count)
						{
							CardData.CopyCardData(cardData, true).PutInSlotData(this.m_Slots[num].CardSlotData, true);
							num++;
						}
					}
					return;
				}
			}
			int num2 = 0;
			using (List<CardData>.Enumerator enumerator = GameController.getInstance().CardDataModMap.Cards.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData2 = enumerator.Current;
					if (cardData2.CardTags == 128UL && cardData2.Rare == 1 && num2 < this.m_Slots.Count)
					{
						CardData.CopyCardData(cardData2, true).PutInSlotData(this.m_Slots[num2].CardSlotData, true);
						num2++;
					}
				}
				return;
			}
			IL_144:
			int num3 = 0;
			foreach (CardData cardData3 in GameController.getInstance().CardDataModMap.Cards)
			{
				if (cardData3.CardTags == 128UL && cardData3.Rare == 1 && num3 < this.m_Slots.Count)
				{
					CardData.CopyCardData(cardData3, true).PutInSlotData(this.m_Slots[num3].CardSlotData, true);
					num3++;
				}
			}
		}
	}

	private void ClearSlotsAndCards()
	{
		for (int i = this.m_Slots.Count - 1; i >= 0; i--)
		{
			Component component = this.m_Slots[i];
			this.m_Slots.Remove(this.m_Slots[i]);
			UnityEngine.Object.DestroyImmediate(component.gameObject);
		}
	}

	public Transform ShowPoint1;

	public Transform ShowPoint2;

	public GameObject CloseBtn;

	public SelectAreaAllSlotsController SelectAreaAllSlotsController;

	public string ShowType = "";

	public int Dir = -1;

	private int m_Columns = 19;

	private int m_Rows = 2;

	private List<CardSlot> m_Slots = new List<CardSlot>();
}
