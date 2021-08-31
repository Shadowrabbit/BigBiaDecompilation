using System;
using System.Collections;

public class ShouWeiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_88");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_88");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_88");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_88");
	}

	public override IEnumerator OnFinishAttack(CardData player, CardSlotData target)
	{
		if (target.ChildCardData.ModID.Equals("幼虫"))
		{
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, player, this.CardData.ATK, 0.2f, false, 0, null, null);
		}
		yield break;
	}
}
