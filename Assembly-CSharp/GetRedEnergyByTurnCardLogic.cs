using System;
using System.Collections;

public class GetRedEnergyByTurnCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_179");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_179");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_179");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_179");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn && this.CardData != null && this.CardData.HasTag(TagMap.随从) && DungeonOperationMgr.Instance.PlayerBattleArea.Contains(this.CardData.CurrentCardSlotData))
		{
			yield return GameController.ins.UIController.EnergyUI.AddEnergy(EnergyUI.EnergyType.Red, this.CardData.CardGameObject.transform);
		}
		yield break;
	}
}
