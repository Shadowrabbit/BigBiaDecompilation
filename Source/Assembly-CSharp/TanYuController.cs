using System;

public class TanYuController : FaithBase
{
	public override void OnLevelUp()
	{
		base.OnLevelUp();
		if (GameController.ins.GameData.CurFaithPoint <= 0)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_13"), 1f, 2f, 1f, 1f);
			return;
		}
		if (GameController.ins.GameData.FaithData.TanYu + 1 > 3)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_12"), 1f, 2f, 1f, 1f);
			return;
		}
		GameController.ins.GameData.CurFaithPoint--;
		this.FaithPanelController.CurPoint.text = (GameController.ins.GameData.CurFaithPoint.ToString() ?? "");
		GameController.ins.GameData.FaithData.TanYu++;
		this.CurLevel.text = (GameController.ins.GameData.FaithData.TanYu.ToString() ?? "");
		switch (GameController.ins.GameData.FaithData.TanYu)
		{
		case 1:
			DungeonOperationMgr.Instance.MoneyAddition = 1.2f;
			return;
		case 2:
			GameController.ins.GameData.PlayerCardData.HP += 20;
			GameController.ins.GameData.PlayerCardData.MaxHP += 20;
			return;
		case 3:
			base.AddLogic("TanYu3Logic", GameController.ins.GameData.PlayerCardData);
			return;
		default:
			return;
		}
	}

	private void Start()
	{
		this.CurLevel.text = (GameController.ins.GameData.FaithData.TanYu.ToString() ?? "");
	}
}
