using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class BanZhuRenCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "保持安静！";
		this.Desc = "任意单位攻击或施法" + this.count.ToString() + "次后，转身并攻击最后一个行动的单位。";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "保持安静！";
		this.Desc = "任意单位攻击或施法" + this.count.ToString() + "次后，转身并攻击最后一个行动的单位。";
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_开始上课"));
		this.atk = this.CardData._ATK;
		this.CardData._ATK = 0;
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		if (allCurrentMinions.Count == 0)
		{
			yield break;
		}
		foreach (CardData cd in allCurrentMinions)
		{
			base.Show(LocalizationMgr.Instance.GetLocalizationWord("T_老师好"), cd);
		}
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		if (allCurrentMonsters.Count == 0)
		{
			yield break;
		}
		foreach (CardData cardData in allCurrentMonsters)
		{
			if (cardData != this.CardData)
			{
				base.Show(LocalizationMgr.Instance.GetLocalizationWord("T_老师好"), cardData);
			}
		}
		yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DORotate(new Vector3(0f, 180f, 0f), 0.2f, RotateMode.Fast).SetEase(Ease.OutExpo).WaitForCompletion();
		this.hasTurnAround = false;
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnFinishAttack(player, target);
		if (!DungeonOperationMgr.Instance.CheckCardDead(player))
		{
			if (!this.hasTurnAround)
			{
				yield return this.TryTurnAround(1, player);
			}
			else if (player != this.CardData)
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_老师看着还敢动"));
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, player, this.CardData.ATK, 0.2f, false, 0, null, null);
			}
		}
		yield break;
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		if (!DungeonOperationMgr.Instance.CheckCardDead(user))
		{
			if (!this.hasTurnAround)
			{
				yield return this.TryTurnAround(1, user);
			}
			else if (user != this.CardData)
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_老师看着还敢动"));
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, user, this.CardData.ATK, 0.2f, false, 0, null, null);
			}
		}
		yield break;
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player == this.CardData && changedValue < 0 && !this.hasTurnAround && !DungeonOperationMgr.Instance.CheckCardDead(from))
		{
			yield return this.TryTurnAround(this.count, from);
		}
		yield break;
	}

	public IEnumerator TryTurnAround(int extraChance, CardData extraCard)
	{
		this.count -= extraChance;
		if (this.hasTurnAround)
		{
			yield break;
		}
		if (this.count <= 0)
		{
			this.Desc = "老师转过来了！最好别搞小动作...";
			yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DORotate(Vector3.zero, 0.3f, RotateMode.Fast).SetEase(Ease.OutExpo).WaitForCompletion();
			yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, this.CardData);
			this.CardData._ATK = this.atk + 1;
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_让我看看是谁在搞小动作"));
			this.hasTurnAround = true;
			if (!DungeonOperationMgr.Instance.CheckCardDead(extraCard))
			{
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, extraCard, this.CardData.ATK, 0.2f, false, 0, null, null);
			}
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			foreach (CardData minion in allCurrentMinions)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(minion) && base.GetLogic(minion, typeof(ManHuaCardLogic)) != null)
				{
					yield return base.ShowMePlus("还有人敢看漫画！");
					List<Vector3Int> dirs = new List<Vector3Int>
					{
						Vector3Int.left,
						Vector3Int.right,
						Vector3Int.up,
						Vector3Int.down
					};
					List<CardData> cardDataNearBy = DungeonOperationMgr.Instance.GetCardDataNearBy(minion, dirs);
					Dictionary<CardData, int> dictionary = new Dictionary<CardData, int>();
					if (cardDataNearBy.Count > 0)
					{
						foreach (CardData cardData in cardDataNearBy)
						{
							if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
							{
								dictionary.Add(cardData, -this.CardData.ATK);
							}
						}
					}
					dictionary.Add(minion, -999);
					yield return base.AOE(dictionary, this.CardData, false, 0, true);
				}
				minion = null;
			}
			List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
			allCurrentMinions = base.GetAllCurrentMinions();
			List<CardData> goodStudents = new List<CardData>();
			foreach (CardData cardData2 in allCurrentMinions)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData2) && !cardData2.IsAttacked && cardData2 != extraCard)
				{
					goodStudents.Add(cardData2);
				}
			}
			if (goodStudents.Count > 0)
			{
				yield return base.ShowMePlus("多向好孩子们学习！");
			}
			foreach (CardData minion in goodStudents)
			{
				yield return base.PlayCureEffect(this.CardData, minion);
				minion.AddAffix(DungeonAffix.heal, 2);
				minion = null;
			}
			enumerator = default(List<CardData>.Enumerator);
			goodStudents = null;
		}
		if (this.count == 1)
		{
			base.ShowLogic("保持安静！！");
		}
		if (this.count == 2)
		{
			base.ShowLogic("不要讲话！");
		}
		if (this.count == 3)
		{
			base.ShowLogic("嗯？");
		}
		yield break;
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (this.hasTurnAround)
		{
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_我们继续上课"));
			this.atk = this.CardData._ATK;
			this.CardData._ATK = 0;
			this.Desc = "任意单位攻击或施法" + this.count.ToString() + "次后，转身并攻击最后一个行动的单位。自身受到攻击时立刻转身！";
			yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DORotate(new Vector3(0f, 180f, 0f), 0.2f, RotateMode.Fast).SetEase(Ease.OutExpo).WaitForCompletion();
			this.count = SYNCRandom.Range(8, 15);
			this.hasTurnAround = false;
		}
		yield break;
	}

	public bool hasTurnAround = true;

	public int atk;

	public int count = 10;
}
