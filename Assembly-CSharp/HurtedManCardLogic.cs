using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HurtedManCardLogic : FaithCardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_实力证明");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_实力证明"), this.KillCount);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_实力证明");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_实力证明"), this.KillCount);
		if (this.WillTransform)
		{
			this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_实力证明");
			this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_实力证明2");
		}
	}

	public override IEnumerator OnBattleEnd()
	{
		if (this.WillTransform)
		{
			List<CardSlotData> list = new List<CardSlotData>();
			List<CardSlotData> playerBattleArea = DungeonOperationMgr.Instance.PlayerBattleArea;
			if (playerBattleArea == null || playerBattleArea.Count == 0)
			{
				yield break;
			}
			foreach (CardSlotData cardSlotData in playerBattleArea)
			{
				if (cardSlotData.ChildCardData == null)
				{
					list.Add(cardSlotData);
				}
			}
			if (list.Count == 0)
			{
				base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_受伤的男人1"));
				yield break;
			}
			CardData HurtMan = Card.InitCardDataByID("中指");
			CardSlotData TargetSlot = list[SYNCRandom.Range(0, list.Count)];
			GameObject tempCard = Card.InitWithOutData(HurtMan, true);
			tempCard.transform.position = DungeonController.Instance.Chessman.position;
			yield return tempCard.transform.DOJump(TargetSlot.CardSlotGameObject.transform.position, 0.5f, 5, 2f, false).WaitForCompletion();
			UnityEngine.Object.DestroyImmediate(tempCard);
			HurtMan.PutInSlotData(TargetSlot, true);
			yield return new WaitForSeconds(0.1f);
			JournalsConversation journalsConversation = new JournalsConversation();
			JournalsConversationManager.role1 = HurtMan;
			JournalsConversationManager.role2 = this.CardData;
			journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_受伤的男人1"), null));
			if (this.CardData.HasTag(TagMap.英雄))
			{
				journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_受伤的男人2"), null));
				journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_受伤的男人3"), null));
			}
			yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation);
			CardSlotData targetCsd = HurtMan.CurrentCardSlotData;
			string targetName = this.CardData.PersonName;
			CardData winner = HurtMan;
			CardData cardData = this.CardData;
			if (this.CardData.HasTag(TagMap.英雄))
			{
				cardData = HurtMan;
				winner = this.CardData;
			}
			Vector3 oldScale = winner.CardGameObject.transform.localScale;
			yield return cardData.CardGameObject.transform.DOJump(winner.CardGameObject.transform.position, 0.5f, 1, 0.2f, false);
			yield return winner.CardGameObject.transform.DOScale(oldScale + Vector3.one, 0.2f).WaitForCompletion();
			yield return winner.CardGameObject.transform.DOScale(oldScale, 0.2f).WaitForCompletion();
			ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = winner.CardGameObject.transform.position;
			ParticlePoolManager.Instance.Spawn("Effect/LevelUP", 1f).gameObject.transform.position = winner.CardGameObject.transform.position;
			ParticlePoolManager.Instance.Spawn("Effect/Insight_yellow", 1f).transform.position = winner.CardGameObject.transform.position;
			if (this.CardData.HasTag(TagMap.英雄))
			{
				this.CardData.MergeBy(HurtMan, true, true);
				HurtMan.DeleteCardData();
				this.CardData.RemoveCardLogic(this);
			}
			else
			{
				CardData cardData2 = Card.InitCardDataByID("完整的男人");
				cardData2.MergeBy(HurtMan, true, true);
				cardData2.MergeBy(this.CardData, true, true);
				cardData2.PersonName = targetName;
				HurtMan.DeleteCardData();
				this.CardData.DeleteCardData();
				cardData2.PutInSlotData(targetCsd, true);
				base.RemoveCardLogic(cardData2, typeof(HurtedManCardLogic), "HurtedManCardLogic");
			}
			HurtMan = null;
			TargetSlot = null;
			tempCard = null;
			targetCsd = null;
			targetName = null;
			winner = null;
			oldScale = default(Vector3);
		}
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (from != null && target.HasTag(TagMap.怪物) && from == this.CardData)
		{
			this.KillCount--;
			if (this.KillCount < 0)
			{
				this.KillCount = 0;
			}
			int killCount = 2 * this.level - 1;
			if (this.KillCount == 0)
			{
				switch (this.level)
				{
				case 1:
					yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_受伤的男人2"));
					yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, this.CardData);
					this.CardData._ATK += 3;
					this.level++;
					killCount = 2 * this.level - 1;
					this.KillCount = killCount;
					break;
				case 2:
					yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_受伤的男人3"));
					yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, this.CardData);
					this.CardData._ATK += 5;
					this.level++;
					killCount = 2 * this.level - 1;
					this.KillCount = killCount;
					break;
				case 3:
					yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_受伤的男人4"));
					yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, this.CardData);
					this.CardData._ATK += 8;
					this.level++;
					killCount = 2 * this.level - 1;
					this.KillCount = killCount;
					break;
				case 4:
					yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_受伤的男人5"));
					yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_受伤的男人6"));
					yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_受伤的男人7"));
					yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, this.CardData);
					this.CardData._ATK += 12;
					this.level++;
					killCount = 2 * this.level - 1;
					this.KillCount = killCount;
					break;
				case 5:
					yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_受伤的男人8"));
					this.WillTransform = true;
					break;
				}
			}
		}
		yield break;
	}

	public bool WillTransform;

	public int level = 1;

	public int KillCount = 1;
}
