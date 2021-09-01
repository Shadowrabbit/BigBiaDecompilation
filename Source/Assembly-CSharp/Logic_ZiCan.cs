using System;
using System.Collections;

public class Logic_ZiCan : PersonCardLogic
{
	public override void Init()
	{
		this.IsDebuff = true;
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_161");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_161");
	}

	public override IEnumerator OnBattleEnd()
	{
		yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_50"));
		this.CardData.HP = 1;
		yield break;
	}
}
