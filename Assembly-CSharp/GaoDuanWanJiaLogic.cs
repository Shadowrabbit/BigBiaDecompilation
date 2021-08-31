using System;
using System.Collections;
using UnityEngine;

public class GaoDuanWanJiaLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_110");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_110") + this.m_ATKGain.ToString() + "%";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_110");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_110") + this.m_ATKGain.ToString() + "%";
	}

	public override IEnumerator OnTurnStart()
	{
		if (this.CardData.HP < this.CardData.MaxHP)
		{
			GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_1"), UnityEngine.Color.white, 0, false, false);
			this.m_ATKGain = 5 * (this.CardData.MaxHP - this.CardData.HP);
			string name = "Effect/HealATK";
			ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = this.CardData.CardGameObject.transform.position;
		}
		this.CardData._ATK = this.CardData.ATK + Mathf.CeilToInt((float)(this.CardData.ATK * this.m_ATKGain / 100));
		yield break;
	}

	private int m_ATKGain;
}
