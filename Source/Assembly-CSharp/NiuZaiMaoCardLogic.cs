using System;
using System.Collections;

public class NiuZaiMaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_牛仔帽");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_牛仔帽"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_牛仔帽");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_牛仔帽"), base.Layers);
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		base.OnBeforeAttack(player, target);
		if (player == this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData) && target.ChildCardData.HP > this.CardData.HP)
		{
			base.ShowMe();
			this.CardData.AddAffix(DungeonAffix.crit, base.Layers);
		}
		yield break;
	}
}
