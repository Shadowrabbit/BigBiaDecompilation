using System;
using System.Collections;

public class JuJiShouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_狙击");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_狙击"), base.Layers * this.increase);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_狙击");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_狙击"), base.Layers * this.increase);
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		base.OnBeforeAttack(player, target);
		if (base.IsFirstAction(this.CardData) && this.CardData == player)
		{
			base.ShowMe();
			yield return base.ShowCustomEffect("忍杀释放", this.CardData.CurrentCardSlotData, 0.5f);
			this.CardData.wCRIT += base.Layers * this.increase;
		}
		yield break;
	}

	private int increase = 10;
}
