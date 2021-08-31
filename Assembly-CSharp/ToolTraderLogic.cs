using System;
using System.Collections.Generic;
using UnityEngine;

public class ToolTraderLogic : CardLogic
{
	public override void OnDayPass()
	{
		if (GameController.getInstance().GameData.Days % 7 != 1)
		{
			this.SecretBigTravel();
			return;
		}
		this.TraderMeeting();
	}

	private void SecretBigTravel()
	{
		List<ToolTraderLogic.MySlots> list = new List<ToolTraderLogic.MySlots>();
		foreach (KeyValuePair<string, AreaData> keyValuePair in GameController.getInstance().GameData.AreaMap)
		{
			if (keyValuePair.Value.CardSlotDatas != null)
			{
				foreach (CardSlotData cardSlotData in keyValuePair.Value.CardSlotDatas)
				{
					if (cardSlotData.ChildCardData == null && (cardSlotData.TagWhiteList == 0UL || (cardSlotData.TagWhiteList & 16UL) > 0UL))
					{
						list.Add(new ToolTraderLogic.MySlots
						{
							MyAD = keyValuePair.Value,
							MyCSD = cardSlotData
						});
					}
				}
			}
		}
		if (list != null && list.Count >= 1)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			foreach (CardSlotData cardSlotData2 in GameController.getInstance().GameData.AreaMap[this.CardData.CurrentAreaID].CardSlotDatas)
			{
				if (cardSlotData2.ChildCardData == this.CardData)
				{
					cardSlotData2.SetChildCardData(null);
				}
			}
			list[index].MyCSD.SetChildCardData(this.CardData);
			this.CardData.CurrentAreaID = list[index].MyAD.ID;
			Debug.Log(string.Concat(new string[]
			{
				this.CardData.Name,
				"移动至",
				list[index].MyAD.ID,
				"坐标X：",
				list[index].MyCSD.DisplayPositionX.ToString(),
				"坐标Y：",
				list[index].MyCSD.DisplayPositionZ.ToString()
			}));
		}
	}

	private void TraderMeeting()
	{
		string text = "";
		List<ToolTraderLogic.MySlots> list = new List<ToolTraderLogic.MySlots>();
		if (this.CardData.Attrs["CurrentParty"] != null)
		{
			string b = (string)this.CardData.Attrs["CurrentParty"];
			using (List<Party>.Enumerator enumerator = GameController.getInstance().GameData.Partys.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					Party party = enumerator.Current;
					if (party.ID == b)
					{
						text = party.HomeAreaID;
					}
				}
			}
		}
		if (text != "")
		{
			foreach (KeyValuePair<string, AreaData> keyValuePair in GameController.getInstance().GameData.AreaMap)
			{
				if (keyValuePair.Value.ID == text)
				{
					foreach (CardSlotData cardSlotData in keyValuePair.Value.CardSlotDatas)
					{
						if (cardSlotData.ChildCardData == null && (cardSlotData.TagWhiteList == 0UL || (cardSlotData.TagWhiteList & 16UL) > 0UL))
						{
							list.Add(new ToolTraderLogic.MySlots
							{
								MyAD = keyValuePair.Value,
								MyCSD = cardSlotData
							});
						}
					}
				}
			}
			if (list != null && list.Count >= 1)
			{
				int index = UnityEngine.Random.Range(0, list.Count);
				foreach (CardSlotData cardSlotData2 in GameController.getInstance().GameData.AreaMap[this.CardData.CurrentAreaID].CardSlotDatas)
				{
					if (cardSlotData2.ChildCardData == this.CardData)
					{
						cardSlotData2.SetChildCardData(null);
					}
				}
				list[index].MyCSD.SetChildCardData(this.CardData);
				this.CardData.CurrentAreaID = list[index].MyAD.ID;
				Debug.Log(this.CardData.Name + "移动至" + list[index].MyAD.ID);
			}
		}
	}

	public class MySlots
	{
		public AreaData MyAD;

		public CardSlotData MyCSD;
	}
}
