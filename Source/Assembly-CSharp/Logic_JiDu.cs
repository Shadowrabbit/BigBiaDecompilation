using System;
using System.Collections;

public class Logic_JiDu : TwoPeopleCardLogic
{
	public override void Init()
	{
		this.IsDebuff = true;
		base.Init();
		if (this.ExistsRound < 1 || this.ExistsRound > 1000)
		{
			this.ExistsRound = 5;
		}
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_153");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_153");
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		CardData t = base.GetCardByID(this.TargetID);
		if (t == null)
		{
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_嫉妒1"));
			this.CardData.RemoveCardLogic(this);
		}
		if (t == player && !this.CardData.IsAttacked)
		{
			if (t == this.CardData)
			{
				yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_嫉妒2"));
				this.CardData.RemoveCardLogic(this);
				yield break;
			}
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_42"));
			this.CardData.IsAttacked = true;
		}
		yield break;
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		CardData t = base.GetCardByID(this.TargetID);
		if (t == null)
		{
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_嫉妒3"));
			this.CardData.RemoveCardLogic(this);
		}
		if (t == user && !this.CardData.IsAttacked)
		{
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_42"));
			this.CardData.IsAttacked = true;
		}
		yield break;
	}
}
