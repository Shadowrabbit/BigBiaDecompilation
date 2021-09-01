using System;
using System.Collections;

public class BoHeTangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_薄荷糖");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_薄荷糖"), 3 * base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_薄荷糖");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_薄荷糖"), 3 * base.Layers);
	}

	public override IEnumerator OnBattleEnd()
	{
		base.OnBattleEnd();
		yield return base.Cure(this.CardData, 3 * base.Layers, this.CardData);
		yield break;
	}

	private float baseDmg;

	private float increaseDmg = 0.1f;
}
