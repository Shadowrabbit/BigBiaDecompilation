using System;
using System.Collections;
using UnityEngine;

public class ChengZhangLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_85");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_85");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_85");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_85");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			base.ShowMe();
			this.CardData.MaxArmor += 2;
			this.CardData.Armor += 2;
			string name = "Effect/HealArmor";
			ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = this.CardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
		}
		yield break;
	}
}
