using System;
using System.Collections;

public class CeHuaCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_骗氪");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_骗氪");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_骗氪");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_骗氪");
	}

	public override IEnumerator OnCardBeforeUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardBeforeUseSkill(user, origin);
		if (user.HasTag(TagMap.随从))
		{
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeMoney(-6);
		}
		yield break;
	}
}
