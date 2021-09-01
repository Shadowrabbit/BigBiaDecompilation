using System;
using System.Collections;

public class NiuZaiKuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_牛仔裤");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_牛仔裤"), base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_牛仔裤");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_牛仔裤"), base.Layers * this.weight);
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		base.OnBeforeHpChange(player, value, from);
		if (player == this.CardData && value.value < 0 && from != null && this.CardData.CurrentCardSlotData.GetAttr("Col") != from.CurrentCardSlotData.GetAttr("Col"))
		{
			base.ShowMe();
			this.CardData.AddAffix(DungeonAffix.def, base.Layers * this.weight);
			yield break;
		}
		yield break;
	}

	private int weight = 2;
}
