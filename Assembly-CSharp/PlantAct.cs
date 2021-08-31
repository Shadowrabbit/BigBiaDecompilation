using System;
using System.Collections.Generic;
using UnityEngine;

public class PlantAct : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<OKButton>().GameAct = this;
		this.OKButton = base.GetComponentInChildren<OKButton>();
		this.SeedCardIDs = new List<string>();
		this.RewardCardIDs = new List<string>();
		this.HarvestedCardIDs = new List<string>();
		this.Source.CardData.DoAllLogic("OnPlant", new object[]
		{
			this.SeedCardIDs,
			this.HarvestedCardIDs,
			this.RewardCardIDs
		});
		int num = 0;
		CardSlotData cardSlotData = new CardSlotData();
		if (this.Source.CardData.Attrs.ContainsKey("PlantNum"))
		{
			num = Convert.ToInt32(this.Source.CardData.Attrs["PlantNum"]);
			base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.3f, 0f, 0f), num, false, null, this.SeedSlots, cardSlotData);
			if (this.Source.CardData.Attrs.ContainsKey("PlantedSeeds") && this.Source.CardData.Attrs["PlantedSeeds"] as string != "")
			{
				string[] array = this.Source.CardData.Attrs["PlantedSeeds"].ToString().Split(new char[]
				{
					','
				});
				for (int i = array.Length - 1; i >= 0; i--)
				{
					CardData cardData = GameController.getInstance().CardDataInWorldMap[array[i]];
				}
			}
		}
		if (this.HarvestedCardIDs.Count > 0)
		{
			for (int j = 0; j < this.HarvestedCardIDs.Count; j++)
			{
				GameController.getInstance().CardDataInWorldMap[this.HarvestedCardIDs[j]].CardGameObject.DeleteCard();
			}
		}
		if (this.RewardCardIDs.Count > 0)
		{
			this.SlotsTrans.position += new Vector3((float)num * 1.3f, 0f, 0f);
			cardSlotData.SlotType = CardSlotData.Type.OnlyTake;
			cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Act;
			base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.3f, 0f, 0f), this.RewardCardIDs.Count, false, null, this.RewardSlots, cardSlotData);
			for (int k = 0; k < this.RewardCardIDs.Count; k++)
			{
			}
		}
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
	}

	private void Update()
	{
	}

	public override void OnActOKButton()
	{
		base.OnActOKButton();
		if (this.Source.CardData.Attrs.ContainsKey("PlantedSeeds"))
		{
			this.Source.CardData.Attrs["PlantedSeeds"] = "";
		}
		else
		{
			this.Source.CardData.Attrs.Add("PlantedSeeds", "");
		}
		foreach (CardSlot cardSlot in this.SeedSlots)
		{
			if (cardSlot.ChildCard != null)
			{
				if (this.Source.CardData.Attrs["PlantedSeeds"] as string != "")
				{
					Dictionary<string, object> attrs = this.Source.CardData.Attrs;
					Dictionary<string, object> dictionary = attrs;
					string key = "PlantedSeeds";
					object obj = attrs["PlantedSeeds"];
					dictionary[key] = ((obj != null) ? obj.ToString() : null) + "," + cardSlot.ChildCard.CardData.ID;
				}
				else
				{
					Dictionary<string, object> attrs = this.Source.CardData.Attrs;
					Dictionary<string, object> dictionary2 = attrs;
					string key2 = "PlantedSeeds";
					object obj2 = attrs["PlantedSeeds"];
					dictionary2[key2] = ((obj2 != null) ? obj2.ToString() : null) + cardSlot.ChildCard.CardData.ID;
				}
				if (!this.SeedCardIDs.Contains(cardSlot.ChildCard.CardData.ID))
				{
					if (cardSlot.ChildCard.CardData.Attrs.ContainsKey("PlantedDays"))
					{
						cardSlot.ChildCard.CardData.Attrs["PlantedDays"] = "0";
					}
					else
					{
						cardSlot.ChildCard.CardData.Attrs.Add("PlantedDays", "0");
					}
				}
			}
		}
		if (this.Source.GetType() == typeof(Toy))
		{
			Toy toy = this.Source as Toy;
			if (toy.CardData.Attrs.ContainsKey("PlantedSeeds") && toy.CardData.Attrs["PlantedSeeds"] as string != "")
			{
				string text = "";
				string[] array = toy.CardData.Attrs["PlantedSeeds"].ToString().Split(new char[]
				{
					','
				});
				for (int i = array.Length - 1; i >= 0; i--)
				{
					CardData cardData = GameController.getInstance().CardDataInWorldMap[array[i]];
					text += cardData.Name;
					if (cardData.Attrs.ContainsKey("PlantedDays") && cardData.Attrs.ContainsKey("NeededPlantedDays") && Convert.ToInt32(cardData.Attrs["PlantedDays"]) >= Convert.ToInt32(cardData.Attrs["NeededPlantedDays"]))
					{
						text += ":已成熟";
					}
					else
					{
						string[] array2 = new string[6];
						array2[0] = text;
						array2[1] = ":正在生长-";
						int num = 2;
						object obj3 = cardData.Attrs["PlantedDays"];
						array2[num] = ((obj3 != null) ? obj3.ToString() : null);
						array2[3] = "/";
						int num2 = 4;
						object obj4 = cardData.Attrs["NeededPlantedDays"];
						array2[num2] = ((obj4 != null) ? obj4.ToString() : null);
						array2[5] = "天";
						text = string.Concat(array2);
					}
				}
				text += "\n";
				toy.UpdateAlwaysShowTips(text);
			}
			else
			{
				toy.UpdateAlwaysShowTips(null);
			}
		}
		base.StartCoroutine(base.ActEndAni(this.eventalOffset, this.oppositeOffset, this.during));
	}

	public List<string> SeedCardIDs;

	public List<CardSlot> SeedSlots;

	public List<string> RewardCardIDs;

	public List<CardSlot> RewardSlots;

	public List<string> HarvestedCardIDs;

	public Transform SlotsTrans;
}
