using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

[CardLogicRequireRare(4)]
public class JuDunBuBingSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.NeedEnergyCount = new Vector3Int(0, 0, 3);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_136");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_136");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(0, 0, 3);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_136");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_136");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = false;
		if (this.CardData.HasTag(TagMap.英雄))
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_英雄没盾可不行"));
			yield break;
		}
		List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
		List<CardData> targets = new List<CardData>();
		for (int j = enemiesBattleArea.Count - 1; j >= 0; j--)
		{
			if (enemiesBattleArea[j].ChildCardData != null && enemiesBattleArea[j].ChildCardData.HasTag(TagMap.怪物))
			{
				targets.Add(enemiesBattleArea[j].ChildCardData);
			}
		}
		base.ShowMe();
		CardData cardData = this.CardData;
		int num = (targets.Count > 3) ? 3 : targets.Count;
		DisplayModel slashParticle = ModelPoolManager.Instance.SpawnModel("Card/地雷");
		slashParticle.transform.position = cardData.CardGameObject.transform.position;
		int i = 0;
		while (i < num && targets.Count >= 1)
		{
			CardData nextTarget = targets[SYNCRandom.Range(0, targets.Count)];
			int num2;
			if (DungeonOperationMgr.Instance.CheckCardDead(nextTarget) || nextTarget.CardGameObject == null)
			{
				targets.Remove(nextTarget);
				num2 = i;
				i = num2 - 1;
			}
			else
			{
				slashParticle.transform.forward = nextTarget.CardGameObject.transform.position - slashParticle.transform.position;
				if (!slashParticle.transform.GetComponent<AudioSource>())
				{
					EffectAudioManager.Instance.PlayEffectAudio(27, null);
				}
				yield return slashParticle.transform.DOMove(nextTarget.CardGameObject.transform.position, 0.3f, false).OnComplete(delegate
				{
					Camera.main.GetComponent<CameraShake>().StartAnimate(0.1f, 0.1f, false);
					EffectAudioManager.Instance.PlayEffectAudio(28, null);
				}).SetEase(Ease.InCubic).WaitForCompletion();
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(nextTarget, -5 * this.CardData.ATK, this.CardData, false, 0, true, false);
				targets.Remove(nextTarget);
				nextTarget = null;
			}
			num2 = i;
			i = num2 + 1;
		}
		ModelPoolManager.Instance.UnSpawnModel(slashParticle);
		if (this.CardData.HasTag(TagMap.英雄))
		{
			this.CardData.IsAttacked = true;
			yield break;
		}
		CardData cardData2 = CardData.CopyCardData(this.CardData, true);
		cardData2.Name = "没盾步兵";
		cardData2.Model = "Card/随从/无盾步兵";
		cardData2.Attrs.Add("OriginMinion", this.CardData);
		CardSlotData currentCardSlotData = this.CardData.CurrentCardSlotData;
		MeiDunBuBingCardLogic meiDunBuBingCardLogic = new MeiDunBuBingCardLogic();
		meiDunBuBingCardLogic.CardData = cardData2;
		cardData2.CardLogics.Add(meiDunBuBingCardLogic);
		meiDunBuBingCardLogic.Init();
		CardLogic item = null;
		CardLogic item2 = null;
		foreach (CardLogic cardLogic in cardData2.CardLogics)
		{
			if (cardLogic is JuDunBuBingSkill2CardLogic)
			{
				item = cardLogic;
			}
			if (cardLogic is JuDunBuBingCardLogic)
			{
				item2 = cardLogic;
			}
		}
		cardData2.CardLogics.Remove(item);
		cardData2.CardLogics.Remove(item2);
		foreach (CardData cardData3 in base.GetAllCurrentMinions())
		{
			if (cardData3 != this.CardData)
			{
				foreach (CardLogic cardLogic2 in cardData3.CardLogics)
				{
					if (cardLogic2 is TwoPeopleCardLogic)
					{
						TwoPeopleCardLogic twoPeopleCardLogic = (TwoPeopleCardLogic)cardLogic2;
						if (twoPeopleCardLogic.TargetID == this.CardData.ID)
						{
							twoPeopleCardLogic.TargetID = cardData2.ID;
						}
					}
				}
			}
		}
		this.CardData.DeleteCardData();
		cardData2.PutInSlotData(currentCardSlotData, true);
		cardData2.IsAttacked = true;
		yield return 1;
		yield break;
	}

	public new static int RequireRare = 4;

	public List<CardData> Targets = new List<CardData>();
}
