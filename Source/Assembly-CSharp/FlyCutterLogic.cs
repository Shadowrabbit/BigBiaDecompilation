using System;
using System.Collections;
using UnityEngine;

public class FlyCutterLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		if (this.CardData == null || (this.CardData != null && this.CardData.HasTag(TagMap.随从)))
		{
			this.Color = CardLogicColor.red;
		}
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_D_35");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_N_35");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_D_35");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_N_35");
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		CardData target = base.GetDefaultTarget();
		if (user == this.CardData && target != null)
		{
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, target, 0, 0.2f, false, 0, null, null);
			base.AddLogic("BleedingCardLogic", 1, target);
		}
		yield break;
	}

	private WaitForSeconds waitSeconds = new WaitForSeconds(0.1f);
}
