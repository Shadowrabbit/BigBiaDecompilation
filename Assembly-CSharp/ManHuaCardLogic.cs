using System;
using System.Collections;

public class ManHuaCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_漫画");
		this.Desc = "班主任转身时，对此单位周围的所有单位造成等同于班主任攻击力的伤害。";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_漫画");
		this.Desc = "班主任转身时，对此单位周围的所有单位造成等同于班主任攻击力的伤害。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -9999, this.CardData, true, 0, true, false);
		yield break;
	}
}
