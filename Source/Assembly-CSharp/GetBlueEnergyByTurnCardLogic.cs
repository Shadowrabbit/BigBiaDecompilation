using System;
using System.Collections;

public class GetBlueEnergyByTurnCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_180");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_180");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_180");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_180");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn && this.CardData != null && this.CardData.HasTag(TagMap.随从) && DungeonOperationMgr.Instance.PlayerBattleArea.Contains(this.CardData.CurrentCardSlotData))
		{
			yield return GameController.ins.UIController.EnergyUI.AddEnergy(EnergyUI.EnergyType.Blue, this.CardData.CardGameObject.transform);
		}
		yield break;
	}
}
