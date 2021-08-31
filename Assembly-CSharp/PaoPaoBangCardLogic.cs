using System;
using System.Collections;

public class PaoPaoBangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_泡泡棒");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_泡泡棒"), base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_泡泡棒");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_泡泡棒"), base.Layers * this.weight);
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		if (user == this.CardData)
		{
			base.ShowMe();
			yield return base.FeiDan(this.CardData, base.Layers * this.weight);
		}
		yield break;
	}

	private int weight = 5;
}
