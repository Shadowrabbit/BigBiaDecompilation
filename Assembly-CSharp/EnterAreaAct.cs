using System;

public class EnterAreaAct : GameAct
{
	private void Start()
	{
		this.Init();
		if (this.Source.CardData.Attrs.ContainsKey("AreaDataID"))
		{
			AreaData areaData;
			if (GlobalController.Instance.HomeDataController.info.PhysicsAreaData.ContainsKey(this.Source.CardData.Attrs["AreaDataID"].ToString()))
			{
				areaData = GlobalController.Instance.HomeDataController.info.PhysicsAreaData[this.Source.CardData.Attrs["AreaDataID"].ToString()];
			}
			else
			{
				areaData = GameController.getInstance().GameData.AreaMap[this.Source.CardData.Attrs["AreaDataID"].ToString()];
			}
			areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
			GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
			bool playAnimation = true;
			if (areaData.ParentArea.ID == null || areaData.ParentArea.ID == "/World")
			{
				playAnimation = false;
			}
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
