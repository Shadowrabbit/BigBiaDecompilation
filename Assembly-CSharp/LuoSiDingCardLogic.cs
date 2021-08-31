using System;
using System.Collections;

public class LuoSiDingCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_螺丝钉");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_螺丝钉"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_螺丝钉");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_螺丝钉"), base.Layers);
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		base.OnBeforeAttack(player, target);
		if (player == this.CardData)
		{
			base.GetAllCurrentMinions();
			if (!base.IsLastAction(this.CardData))
			{
				yield break;
			}
			if (this.CardData.HasTag(TagMap.随从))
			{
				base.ShowMe();
				this.CardData.AddAffix(DungeonAffix.beatBack, base.Layers);
			}
		}
		yield break;
	}

	public override IEnumerator OnCardBeforeUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardBeforeUseSkill(user, origin);
		if (user == this.CardData)
		{
			base.GetAllCurrentMinions();
			if (!base.IsLastAction(this.CardData))
			{
				yield break;
			}
			if (this.CardData.HasTag(TagMap.随从))
			{
				this.CardData.AddAffix(DungeonAffix.beatBack, base.Layers);
			}
		}
		yield break;
	}
}
