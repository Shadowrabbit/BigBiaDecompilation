using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class SiFenWeiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.NeedEnergyCount = new Vector3Int(0, 0, 1);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_合身撞击");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_合身撞击"), Mathf.CeilToInt((float)this.CardData.HP * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_合身撞击");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_合身撞击"), Mathf.CeilToInt((float)this.CardData.HP * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		CardData target = base.GetDefaultTarget();
		if (target == null || DungeonOperationMgr.Instance.CheckCardDead(target))
		{
			yield break;
		}
		yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DOLocalMoveZ(target.CardGameObject.transform.position.z - this.CardData.CardGameObject.transform.position.z, 0.3f, false).SetEase(Ease.InBack).WaitForCompletion();
		yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(target, -Mathf.CeilToInt((float)this.CardData.HP * (this.baseDmg + this.increaseDmg * (float)base.Layers)), this.CardData, false, 0, true, false);
		yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DOLocalMoveZ(0f, 0.5f, false).WaitForCompletion();
		yield break;
	}

	private float baseDmg = 0.25f;

	private float increaseDmg = 0.25f;
}
