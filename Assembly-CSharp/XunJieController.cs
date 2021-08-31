using System;

public class XunJieController : FaithBase
{
	public override void OnLevelUp()
	{
		base.OnLevelUp();
		if (GameController.ins.GameData.CurFaithPoint <= 0)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_13"), 1f, 2f, 1f, 1f);
			return;
		}
		if (GameController.ins.GameData.FaithData.XunJie + 1 > 3)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_12"), 1f, 2f, 1f, 1f);
			return;
		}
		GameController.ins.GameData.CurFaithPoint--;
		this.FaithPanelController.CurPoint.text = (GameController.ins.GameData.CurFaithPoint.ToString() ?? "");
		GameController.ins.GameData.FaithData.XunJie++;
		this.CurLevel.text = (GameController.ins.GameData.FaithData.XunJie.ToString() ?? "");
		switch (GameController.ins.GameData.FaithData.XunJie)
		{
		case 1:
			GameController.ins.GameData.TorchNum += 5;
			return;
		case 2:
			GameController.ins.GameData.PlayerCardData._AttackTimes++;
			return;
		case 3:
			base.AddLogic("XunJie3Logic", GameController.ins.GameData.PlayerCardData);
			return;
		default:
			return;
		}
	}

	private void Start()
	{
		this.CurLevel.text = (GameController.ins.GameData.FaithData.XunJie.ToString() ?? "");
	}
}
