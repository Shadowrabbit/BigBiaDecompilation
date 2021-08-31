using System;
using System.Collections;

public class Logic_TanCai : PersonCardLogic
{
	public override void Init()
	{
		this.IsDebuff = true;
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_162");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_162");
	}

	public override IEnumerator OnBattleEnd()
	{
		yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_51"));
		int num = SYNCRandom.Range(1, 11);
		GameController.ins.GameData.Money = ((GameController.ins.GameData.Money - num >= 0) ? (GameController.ins.GameData.Money - num) : 0);
		yield break;
	}
}
