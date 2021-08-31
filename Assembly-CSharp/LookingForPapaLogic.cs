using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class LookingForPapaLogic : FaithCardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
	}

	public override IEnumerator OnMoveOnMap()
	{
		base.OnMoveOnMap();
		if (this.HasEnd)
		{
			yield break;
		}
		if (this.CardData.HasTag(TagMap.英雄))
		{
			yield break;
		}
		DialogueLua.SetVariable("EventEnd", false);
		if (GameController.ins.GameData.EventStep != this.m_preStep)
		{
			this.step++;
			this.m_preStep = GameController.ins.GameData.EventStep;
		}
		if (this.step % 7 == 0)
		{
			string key = "ZM_好吃";
			this.count++;
			if (this.count > 4)
			{
				DialogueLua.SetVariable("EventEnd", true);
				key = "DH_阿丑7";
			}
			List<string> list = new List<string>();
			foreach (CardData cardData in GameController.ins.CardDataModMap.Cards)
			{
				if (cardData.HasTag(TagMap.食物) && !cardData.HasTag(TagMap.特殊))
				{
					list.Add(cardData.ModID);
				}
			}
			string gift = list[SYNCRandom.Range(0, list.Count)];
			DialogueLua.SetVariable("RandomItem", gift);
			JournalsConversation journalsConversation = new JournalsConversation();
			JournalsConversationManager.role1 = this.CardData;
			JournalsConversationManager.role2 = base.GetHero();
			journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord(key), SpecialEventController.instance.StartConversation("小女孩事件")));
			yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation);
			if (this.count <= 4)
			{
				int asInt = DialogueLua.GetVariable("Options").asInt;
				CardData flower;
				GameObject tempCard;
				CardSlotData targetSlot;
				Vector3 oldScale;
				if (asInt != 1)
				{
					if (asInt == 2)
					{
						yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_小女孩2"));
						flower = Card.InitCardDataByID(gift);
						tempCard = Card.InitWithOutData(flower, true);
						targetSlot = GameController.ins.GetEmptySlotDataByCardData(flower);
						if (targetSlot == null)
						{
							yield break;
						}
						tempCard.transform.position = this.CardData.CardGameObject.transform.position;
						yield return tempCard.transform.DOJump(targetSlot.CardSlotGameObject.transform.position, 0.5f, 1, 0.2f, false).WaitForCompletion();
						UnityEngine.Object.DestroyImmediate(tempCard);
						flower.PutInSlotData(targetSlot, true);
					}
				}
				else
				{
					yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_小女孩1"));
					oldScale = this.CardData.CardGameObject.transform.localScale;
					yield return this.CardData.CardGameObject.transform.DOScale(oldScale + Vector3.one, 0.2f).WaitForCompletion();
					this.CardData.MergeBy(Card.InitCardDataByID(gift), true, true);
					yield return this.CardData.CardGameObject.transform.DOScale(oldScale, 0.2f).WaitForCompletion();
				}
				oldScale = default(Vector3);
				flower = null;
				tempCard = null;
				targetSlot = null;
			}
			else
			{
				if (DialogueLua.GetVariable("SpecialEventVal").asInt >= 0)
				{
					yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_小女孩3"));
					CardData flower = base.GetHero();
					GameController.ins.GameData.PlayerCardData = this.CardData;
					GameController.ins.PlayerToy = this.CardData.CardGameObject;
					this.CardData.CardGameObject.gameObject.AddComponent<Hero>();
					this.CardData.AddTag(TagMap.英雄);
					flower.RemoveTag(TagMap.英雄);
					Vector3 oldScale = this.CardData.CardGameObject.transform.localScale;
					yield return flower.CardGameObject.transform.DOJump(this.CardData.CardGameObject.transform.position, 0.5f, 1, 0.2f, false);
					yield return this.CardData.CardGameObject.transform.DOScale(oldScale + Vector3.one, 0.2f).WaitForCompletion();
					this.CardData.MergeBy(flower, true, true);
					this.CardData.Rare = ((flower.Rare >= this.CardData.Rare) ? flower.Rare : this.CardData.Rare);
					ModelPoolManager.Instance.UnSpawnModel(this.CardData.CardGameObject.BottomGameObject);
					string cardBottomName = ((flower.Rare >= this.CardData.Rare) ? flower : this.CardData).GetCardBottomName();
					this.CardData.CardGameObject.BottomGameObject = ModelPoolManager.Instance.SpawnModel(cardBottomName);
					this.CardData.CardGameObject.BottomGameObject.transform.SetParent(this.CardData.CardGameObject.transform, false);
					ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = this.CardData.CardGameObject.transform.position;
					yield return this.CardData.CardGameObject.transform.DOScale(oldScale, 0.2f).WaitForCompletion();
					flower.DeleteCardData();
					yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_小女孩4"));
					yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_小女孩5"));
					this.CardData.RemoveCardLogic(this);
					flower = null;
					oldScale = default(Vector3);
				}
				else
				{
					CardSlotData currentCardSlotData = this.CardData.CurrentCardSlotData;
					this.CardData.DeleteCardData();
					CardSlotData targetSlot = GameController.ins.GetEmptySlotDataByCardTag(TagMap.食物);
					if (targetSlot == null)
					{
						yield break;
					}
					CardData flower = Card.InitCardDataByID("小红花");
					GameObject tempCard = Card.InitWithOutData(flower, true);
					tempCard.transform.position = currentCardSlotData.CardSlotGameObject.transform.position;
					yield return tempCard.transform.DOJump(targetSlot.CardSlotGameObject.transform.position, 0.5f, 1, 0.2f, false).WaitForCompletion();
					UnityEngine.Object.DestroyImmediate(tempCard);
					flower.PutInSlotData(targetSlot, true);
					targetSlot = null;
					flower = null;
					tempCard = null;
				}
				DialogueLua.SetVariable("EventEnd", false);
				this.HasEnd = true;
			}
			gift = null;
		}
		yield break;
	}

	public int step;

	public bool HasEnd;

	public int count;

	public int m_preStep;
}
