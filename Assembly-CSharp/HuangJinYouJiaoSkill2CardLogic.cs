using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

[CardLogicRequireRare(4)]
public class HuangJinYouJiaoSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.NeedEnergyCount = new Vector3Int(0, 2, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_假摔");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_假摔");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(0, 2, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_假摔");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_假摔");
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		this.canUse = true;
		yield break;
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		if (!this.canUse)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_裁判盯着"));
			yield break;
		}
		base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_犯规"));
		yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DORotate(new Vector3(0f, 90f, 0f), 0.2f, RotateMode.Fast).SetEase(Ease.OutExpo).WaitForCompletion();
		if (base.GetAllCurrentMonsters().Count == 0)
		{
			yield break;
		}
		foreach (CardData cardData in base.GetAllCurrentMonsters())
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData) && cardData.DizzyLayer <= 0)
			{
				base.Show(LocalizationMgr.Instance.GetLocalizationWord("T_纳尼"), cardData);
				cardData.DizzyLayer++;
			}
		}
		yield return new WaitForSeconds(1f);
		yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DORotate(Vector3.zero, 0.3f, RotateMode.Fast).SetEase(Ease.OutExpo).WaitForCompletion();
		this.CardData.IsAttacked = true;
		this.canUse = false;
		yield break;
	}

	private bool canUse = true;
}
