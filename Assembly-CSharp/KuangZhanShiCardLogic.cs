using System;
using System.Collections;

public class KuangZhanShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_鲁莽");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_鲁莽"), base.Layers, 2 * base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_鲁莽");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_鲁莽"), base.Layers, 2 * base.Layers);
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		base.OnBeforeAttack(player, target);
		if (base.IsFirstAction(this.CardData) && this.CardData == player)
		{
			base.ShowMe();
			this.CardData.AddAffix(DungeonAffix.frail, base.Layers);
			if (!DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
			{
				target.ChildCardData.AddAffix(DungeonAffix.frail, base.Layers * 2);
			}
		}
		yield break;
	}
}
