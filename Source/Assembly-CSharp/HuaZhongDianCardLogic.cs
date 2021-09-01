using System;
using System.Collections;

public class HuaZhongDianCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_25");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_25"), this.Count);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_25");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_25"), this.Count);
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		if (user != this.CardData)
		{
			yield break;
		}
		if (origin.Color == CardLogicColor.blue)
		{
			this.Count--;
		}
		if (this.Count < 0)
		{
			base.ShowMe();
			yield return origin.OnUseSkill();
			this.Count = 3;
		}
		yield break;
	}

	public int Count = 3;
}
