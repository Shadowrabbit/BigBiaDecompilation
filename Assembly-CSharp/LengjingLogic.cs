using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class LengjingLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_193");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_193"), Mathf.CeilToInt((float)this.CardData.MP * 0.5f));
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn && !this.CardData.IsAttacked && this.CardData.MP > 0)
		{
			base.ShowMe();
			ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HellHpBall", 0.5f);
			particleObject.transform.position = this.CardData.CardGameObject.transform.position;
			yield return particleObject.transform.DOMove(this.CardData.CardGameObject.transform.position, 0.5f, false).WaitForCompletion();
			string name = "Effect/HealHp";
			ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = this.CardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, this.CardData.MP, this.CardData, false, 0, true, false);
			this.CardData.MP = 0;
		}
		yield break;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_193");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_193"), Mathf.CeilToInt((float)this.CardData.MP * 0.5f));
	}
}
