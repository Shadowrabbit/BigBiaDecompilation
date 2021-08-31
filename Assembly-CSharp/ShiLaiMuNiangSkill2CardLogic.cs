using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

[CardLogicRequireRare(4)]
public class ShiLaiMuNiangSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.NeedEnergyCount = new Vector3Int(0, 0, 3);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_不存在的心脏");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_不存在的心脏"), Mathf.CeilToInt((float)this.CardData.HP * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(0, 0, 3);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_不存在的心脏");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_不存在的心脏"), Mathf.CeilToInt((float)this.CardData.HP * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		if (this.CardData.Attrs.ContainsKey("ShiLaiMuNiang"))
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_没法再包裹其他人了"));
			yield break;
		}
		List<CardData> allCurrentMinionsExceptHero = base.GetAllCurrentMinionsExceptHero();
		if (allCurrentMinionsExceptHero.Count == 0)
		{
			yield break;
		}
		float num = 1f;
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in allCurrentMinionsExceptHero)
		{
			float num2 = (float)cardData.HP;
			float num3 = (float)cardData.MaxHP;
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				if (cardData != this.CardData && num2 / num3 < num)
				{
					num = num2 / num3;
					list.Clear();
					list.Add(cardData);
				}
				else if (cardData != this.CardData && num2 / num3 == num && num <= 1f)
				{
					list.Add(cardData);
				}
			}
		}
		if (list.Count == 0)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_没人需要治疗"));
			yield break;
		}
		CardData target = list[SYNCRandom.Range(0, list.Count)];
		Vector3 oldScale = target.CardGameObject.transform.localScale;
		yield return target.CardGameObject.transform.DOJump(this.CardData.CardGameObject.transform.position, 0.5f, 1, 0.2f, false);
		yield return target.CardGameObject.transform.DOScale(oldScale + Vector3.one, 0.2f).SetEase(Ease.InBack).WaitForCompletion();
		yield return target.CardGameObject.transform.DOScale(oldScale, 0.2f).WaitForCompletion();
		ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = this.CardData.CardGameObject.transform.position;
		if (this.CardData.Attrs.ContainsKey("ShiLaiMuNiang"))
		{
			this.CardData.Attrs["ShiLaiMuNiang"] = target;
		}
		else
		{
			this.CardData.Attrs.Add("ShiLaiMuNiang", target);
		}
		target.DeleteCardData();
		base.Show(LocalizationMgr.Instance.GetLocalizationWord("T_你会没事的"), this.CardData);
		yield break;
	}

	public override IEnumerator OnBattleEnd()
	{
		base.OnBattleEnd();
		if (this.CardData.Attrs.ContainsKey("ShiLaiMuNiang"))
		{
			List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
			if (allEmptySlotsInMyBattleArea.Count == 0)
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_位置不够了"));
				yield break;
			}
			CardSlotData slotData = allEmptySlotsInMyBattleArea[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea.Count)];
			CardData cardData = (CardData)this.CardData.Attrs["ShiLaiMuNiang"];
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_终于安全了"));
			cardData.PutInSlotData(slotData, true);
			yield return base.Cure(this.CardData, Mathf.CeilToInt((float)this.CardData.HP * (this.baseDmg + this.increaseDmg * (float)base.Layers)), cardData);
			this.CardData.Attrs.Remove("ShiLaiMuNiang");
		}
		yield break;
	}

	private float baseDmg = 0.25f;

	private float increaseDmg = 0.25f;
}
