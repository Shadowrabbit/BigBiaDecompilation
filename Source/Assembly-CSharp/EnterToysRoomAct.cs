using System;
using System.Collections.Generic;

public class EnterToysRoomAct : GameAct
{
	private void Start()
	{
		this.Init();
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in cards)
		{
			if (cardData.HasTag(TagMap.玩具房间) && !cardData.HasTag(TagMap.奇遇))
			{
				list.Add(cardData);
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		AreaData areaData = GameController.getInstance().GameData.AreaMap[list[SYNCRandom.Range(0, list.Count)].ModID];
		areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
		GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
		bool playAnimation = true;
		if (areaData.ParentArea.ID == null || areaData.ParentArea.ID == "/World")
		{
			playAnimation = false;
		}
		GameController.getInstance().OnTableChange(areaData, playAnimation);
		if (this.Source.CardData.Attrs.ContainsKey("DeleteAfterEnter") && this.Source.CardData.Attrs["DeleteAfterEnter"].ToString() == "true")
		{
			this.Source.CardData.DeleteCardData();
		}
		UIController.LockLevel = UIController.UILevel.None;
		this.ActEnd();
	}

	private void Update()
	{
	}
}
