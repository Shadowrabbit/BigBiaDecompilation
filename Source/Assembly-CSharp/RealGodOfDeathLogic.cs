using System;
using System.Collections;

public class RealGodOfDeathLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_收割2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_收割2");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_收割2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_收割2");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, GameController.getInstance().GameData.PlayerCardData, this.CardData.ATK, 0.2f, false, 0, null, null);
		}
		yield break;
	}
}
