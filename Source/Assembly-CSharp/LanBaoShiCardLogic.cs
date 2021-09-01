using System;
using System.Collections;

public class LanBaoShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_185");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_185"), base.Layers * 10);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_185");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_185"), base.Layers * 10);
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		if (user != this.CardData)
		{
			yield break;
		}
		if (GameController.ins.GameData.GetEnergyCount(EnergyUI.EnergyType.Blue) < this.needEnergy)
		{
			yield break;
		}
		int num;
		for (int i = 0; i < this.needEnergy; i = num + 1)
		{
			yield return GameController.ins.UIController.EnergyUI.RemoveEnergy(EnergyUI.EnergyType.Blue, this.CardData.CardGameObject.transform);
			num = i;
		}
		if (SYNCRandom.Range(1, 101) <= base.Layers * 10)
		{
			yield return origin.OnUseSkill();
		}
		yield break;
	}

	private int needEnergy = 1;
}
