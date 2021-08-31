using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class HuntingCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_62");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_62");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_62");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_62");
	}

	public override IEnumerator OnTurnStart()
	{
		if (this.HaveJumped)
		{
			List<CardData> allMonsters = base.GetAllCurrentMonsters();
			if (allMonsters.Count == 0)
			{
				yield break;
			}
			float minDistance = 99f;
			List<CardData> AllPreys = new List<CardData>();
			foreach (CardData cardData in allMonsters)
			{
				if (cardData != this.CardData && base.GetLogic(cardData, typeof(HuntingCardLogic)) == null && !cardData.HasTag(TagMap.植物))
				{
					float num = Mathf.Pow((float)(cardData.CurrentCardSlotData.GridPositionX - this.CardData.CurrentCardSlotData.GridPositionX), 2f);
					float num2 = Mathf.Pow((float)(cardData.CurrentCardSlotData.GridPositionY - this.CardData.CurrentCardSlotData.GridPositionY), 2f);
					float num3 = num + num2;
					if (num3 == minDistance)
					{
						AllPreys.Add(cardData);
					}
					if (num3 < minDistance)
					{
						AllPreys.Clear();
						minDistance = num3;
						AllPreys.Add(cardData);
					}
				}
			}
			if (minDistance == 1f)
			{
				base.ShowMe();
				CardData cardData2 = AllPreys[SYNCRandom.Range(0, AllPreys.Count)];
				int hp = cardData2.HP;
				int atk = cardData2.ATK;
				cardData2.Price = 0;
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, cardData2, 9999, 0.1f, true, 0, "", "Effect/animal_scratch_1");
				this.CardData._ATK += atk;
				this.CardData.MaxHP += hp;
				Vector3 oldScale = this.CardData.CardGameObject.transform.localScale;
				this.CardData.CardGameObject.transform.DOScale(oldScale + Vector3.one * 0.5f, 0.5f).SetEase(Ease.OutBack);
				yield return new WaitForSeconds(0.8f);
				this.CardData.CardGameObject.transform.DOScale(oldScale, 0.2f);
				yield return new WaitForSeconds(0.2f);
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, hp, this.CardData, false, 0, true, false);
				yield break;
			}
			if (AllPreys.Count > 0)
			{
				base.ShowMe();
				CardData cardData3 = AllPreys[SYNCRandom.Range(0, AllPreys.Count)];
				this.HaveJumped = false;
				yield return this.TryJumpTo(this.CardData.CurrentCardSlotData, cardData3.CurrentCardSlotData);
			}
			foreach (CardData cardData4 in allMonsters)
			{
				if (cardData4 != this.CardData && base.GetLogic(cardData4, typeof(HuntingCardLogic)) == null && !cardData4.HasTag(TagMap.植物))
				{
					float num4 = Mathf.Pow((float)(cardData4.CurrentCardSlotData.GridPositionX - this.CardData.CurrentCardSlotData.GridPositionX), 2f);
					float num5 = Mathf.Pow((float)(cardData4.CurrentCardSlotData.GridPositionY - this.CardData.CurrentCardSlotData.GridPositionY), 2f);
					float num6 = num4 + num5;
					if (num6 == minDistance)
					{
						AllPreys.Add(cardData4);
					}
					if (num6 < minDistance)
					{
						AllPreys.Clear();
						minDistance = num6;
						AllPreys.Add(cardData4);
					}
				}
			}
			if (minDistance == 1f)
			{
				base.ShowMe();
				CardData cardData5 = AllPreys[SYNCRandom.Range(0, AllPreys.Count)];
				int atk = cardData5.HP;
				int hp = cardData5.ATK;
				cardData5.Price = 0;
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, cardData5, 9999, 0.1f, true, 0, "", "Effect/animal_scratch_1");
				this.CardData._ATK += hp;
				this.CardData.MaxHP += atk;
				Vector3 oldScale = this.CardData.CardGameObject.transform.localScale;
				this.CardData.CardGameObject.transform.DOScale(oldScale + Vector3.one * 0.5f, 0.5f).SetEase(Ease.OutBack);
				yield return new WaitForSeconds(0.8f);
				this.CardData.CardGameObject.transform.DOScale(oldScale, 0.2f);
				yield return new WaitForSeconds(0.2f);
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, atk, this.CardData, false, 0, true, false);
				oldScale = default(Vector3);
			}
			allMonsters = null;
			AllPreys = null;
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		this.HaveJumped = true;
		yield break;
	}

	public IEnumerator TryJumpTo(CardSlotData me, CardSlotData csd)
	{
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		if (myBattleArea == null)
		{
			yield break;
		}
		List<CardSlotData> path = base.GetPath(myBattleArea, me, csd);
		if (path != null && path.Count > 0)
		{
			yield return me.ChildCardData.CardGameObject.JumpToSlot(path[0].CardSlotGameObject, 0.2f, true);
			if (this.CardData != null && this.CardData.Attrs.ContainsKey("Col"))
			{
				this.CardData.Attrs["Col"] = path[0].Attrs["Col"];
			}
		}
		yield break;
	}

	private bool HaveJumped = true;
}
