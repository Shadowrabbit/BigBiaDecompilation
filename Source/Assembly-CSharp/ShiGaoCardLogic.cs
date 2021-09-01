using System;
using System.Collections;
using UnityEngine;

public class ShiGaoCardLogic : CardLogic
{
	public override void Init()
	{
	}

	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_临摹");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_临摹"), base.Layers * 2);
	}

	public IEnumerator ChangeColor(CardLogicColor color)
	{
		if (this.CardData != null && this.CardData.CardGameObject != null)
		{
			ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = this.CardData.CardGameObject.transform.position;
			this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.GameObject.GetComponentInChildren<MeshRenderer>().material.color = GameController.RowColor[(int)color];
			this.currentColor = color;
		}
		yield return null;
		yield break;
	}

	public CardLogicColor currentColor;
}
