using System;

public class RenNaiController : FaithBase
{
	public override void OnLevelUp()
	{
		base.OnLevelUp();
		if (GameController.ins.GameData.CurFaithPoint > 0)
		{
			if (GameController.ins.GameData.FaithData.RenNai + 1 > 3)
			{
				GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_12"), 1f, 2f, 1f, 1f);
				return;
			}
			GameController.ins.GameData.CurFaithPoint--;
			this.FaithPanelController.CurPoint.text = (GameController.ins.GameData.CurFaithPoint.ToString() ?? "");
			GameController.ins.GameData.FaithData.RenNai++;
			this.CurLevel.text = (GameController.ins.GameData.FaithData.RenNai.ToString() ?? "");
			switch (GameController.ins.GameData.FaithData.RenNai)
			{
			case 1:
			{
				CardData playerCardData = GameController.ins.GameData.PlayerCardData;
				playerCardData.Armor = ++playerCardData.MaxArmor;
				return;
			}
			case 2:
				base.AddLogic("RenNai2Logic", GameController.ins.GameData.PlayerCardData);
				return;
			case 3:
				break;
			default:
				return;
			}
		}
		else
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_50"), 1f, 2f, 1f, 1f);
		}
	}

	private void Start()
	{
		this.CurLevel.text = (GameController.ins.GameData.FaithData.RenNai.ToString() ?? "");
	}
}
