using System;

public class BaoNuController : FaithBase
{
	public override void OnLevelUp()
	{
		base.OnLevelUp();
		if (GameController.ins.GameData.CurFaithPoint <= 0)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_13"), 1f, 2f, 1f, 1f);
			return;
		}
		if (GameController.ins.GameData.FaithData.BaoNu + 1 > 3)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_12"), 1f, 2f, 1f, 1f);
			return;
		}
		GameController.ins.GameData.CurFaithPoint--;
		this.FaithPanelController.CurPoint.text = (GameController.ins.GameData.CurFaithPoint.ToString() ?? "");
		GameController.ins.GameData.FaithData.BaoNu++;
		this.CurLevel.text = (GameController.ins.GameData.FaithData.BaoNu.ToString() ?? "");
		switch (GameController.ins.GameData.FaithData.BaoNu)
		{
		case 1:
			GameController.ins.GameData.PlayerCardData._ATK += 5;
			return;
		case 2:
			base.AddLogic("BaoNu2Logic", GameController.ins.GameData.PlayerCardData);
			return;
		case 3:
			GameController.ins.GameData.PlayerCardData._CRIT = 100;
			return;
		default:
			return;
		}
	}

	private void Start()
	{
		this.CurLevel.text = (GameController.ins.GameData.FaithData.BaoNu.ToString() ?? "");
	}
}
