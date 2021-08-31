using System;
using System.Collections;

public class YuanZhuBiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_圆珠笔");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_圆珠笔"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_圆珠笔");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_圆珠笔"), base.Layers);
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		base.OnBeforeAttack(player, target);
		if (player == this.CardData)
		{
			base.GetAllCurrentMinions();
			if (!base.IsFirstAction(this.CardData))
			{
				yield break;
			}
			if (this.CardData.HasTag(TagMap.随从))
			{
				base.ShowMe();
				this.CardData.AddAffix(DungeonAffix.strength, base.Layers);
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
			if (!base.IsFirstAction(this.CardData))
			{
				yield break;
			}
			if (this.CardData.HasTag(TagMap.随从))
			{
				base.ShowMe();
				this.CardData.AddAffix(DungeonAffix.strength, base.Layers);
			}
		}
		yield break;
	}
}
