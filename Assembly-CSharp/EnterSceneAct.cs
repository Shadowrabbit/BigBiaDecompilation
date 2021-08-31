using System;

public class EnterSceneAct : GameAct
{
	private void Start()
	{
		this.Init();
		if (this.Source.CardData.Attrs.ContainsKey("SceneDataID"))
		{
			AreaData areaData;
			if (GlobalController.Instance.HomeDataController.info.PhysicsAreaData.ContainsKey(this.Source.CardData.Attrs["SceneDataID"].ToString()))
			{
				areaData = GlobalController.Instance.HomeDataController.info.PhysicsAreaData[this.Source.CardData.Attrs["SceneDataID"].ToString()];
			}
			else
			{
				areaData = GameController.getInstance().GameData.AreaMap[this.Source.CardData.Attrs["SceneDataID"].ToString()];
			}
			GameController.ins.GameData.Agreenment = this.Source.CardData.Level;
			GameController.ins.GameData.DungeonTheme = (DungeonTheme)int.Parse(this.Source.CardData.Attrs["Theme"].ToString());
			GameController.ins.GameData.DungeonArea.Add(CardData.CopyCardData(this.Source.CardData, true));
			GameController.ins.GameData.CurrentDungeonType = GameData.DungeonType.Scene;
			GameController.ins.GameData.DungeonArea.Add(CardData.CopyCardData(Card.InitCardDataByID("营地"), true));
			areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
			bool playAnimation = true;
			if (areaData.ParentArea.ID == "/World")
			{
				playAnimation = false;
			}
			GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
			GameController.getInstance().OnTableChange(areaData, playAnimation);
		}
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
