using System;
using System.Collections;

public class SelectSceneAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
	}

	public override void BeforeInit()
	{
	}

	public override IEnumerator OnAlreadEnter()
	{
		AreaData parentArea;
		if (GlobalController.Instance.HomeDataController.info.PhysicsAreaData.ContainsKey(GameController.ins.GameData.CurrentAreaId))
		{
			parentArea = GlobalController.Instance.HomeDataController.info.PhysicsAreaData[GameController.ins.GameData.CurrentAreaId].ParentArea;
		}
		else
		{
			parentArea = GameController.ins.GameData.AreaMap[GameController.ins.GameData.CurrentAreaId].ParentArea;
		}
		if (parentArea != null && parentArea.ID != "/World")
		{
			GameController.ins.UIController.ShowGetCardTipPanel();
		}
		return base.OnAlreadEnter();
	}

	public override void OnExit()
	{
	}
}
