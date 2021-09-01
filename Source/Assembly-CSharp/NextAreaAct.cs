using System;

public class NextAreaAct : GameAct
{
	private void Start()
	{
		this.Init();
		if (GameController.ins.GameData.CurrentDungeonType == GameData.DungeonType.Scene)
		{
			AreaData areaData = GameController.getInstance().GameData.AreaMap["入场选择"];
			areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
			GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
			GameController.getInstance().OnTableChange(areaData, true);
		}
		else if (GameController.ins.GameData.CurrentDungeonType == GameData.DungeonType.Dungeon)
		{
			GameController.ins.GameData.DungeonArea.Add(Card.InitCardDataByID("营地"));
			GameController.ins.GameData.DungeonArea.Add(this.Source.CardData);
			DungeonController.Instance.GenerateNextArea(false);
		}
		this.ActEnd();
	}
}
