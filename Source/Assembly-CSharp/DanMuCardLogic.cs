using System;
using System.Collections;

public class DanMuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_172");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_172"), base.Layers * this.Weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_172");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_172"), base.Layers * this.Weight);
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player != this.CardData)
		{
			yield break;
		}
		base.OnAfterAttack(player, target);
		base.ShowMe();
		yield return base.FeiDan(this.CardData, base.Layers * this.Weight);
		yield break;
	}

	private int Weight = 2;
}
