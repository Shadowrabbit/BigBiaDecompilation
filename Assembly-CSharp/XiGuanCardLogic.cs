using System;
using System.Collections;

public class XiGuanCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_剪刀");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_剪刀"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_剪刀");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_剪刀"), base.Layers);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn && this.CardData.HasTag(TagMap.随从))
		{
			this.CardData.AddAffix(DungeonAffix.beatBack, base.Layers);
		}
		yield break;
	}
}
