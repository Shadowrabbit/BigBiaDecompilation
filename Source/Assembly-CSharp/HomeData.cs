using System;
using System.Collections.Generic;

public class HomeData
{
	public List<CardSlotData> PlayerTableCardSlotDatas = new List<CardSlotData>();

	public List<CardSlotData> ItemTableCardSlotDatas = new List<CardSlotData>();

	public List<CardSlotData> MagicTableCardSlotDatas = new List<CardSlotData>();

	public List<CardSlotData> OppositeTableCardSlotDatas = new List<CardSlotData>();

	public Dictionary<string, AreaData> PhysicsAreaData = new Dictionary<string, AreaData>();
}
