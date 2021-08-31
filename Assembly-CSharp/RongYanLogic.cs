using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class RongYanLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "";
		this.Desc = "";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			if (this.CardData.Attrs.ContainsKey("Child"))
			{
				if (base.GetAllEmptySlotsInMyBattleArea().Count <= 0)
				{
					yield break;
				}
				Dictionary<CardData, int> dictionary = this.CardData.Attrs["Child"] as Dictionary<CardData, int>;
				foreach (KeyValuePair<CardData, int> keyValuePair in dictionary.ToList<KeyValuePair<CardData, int>>())
				{
					int value = keyValuePair.Value - 1;
					dictionary[keyValuePair.Key] = value;
					if (keyValuePair.Value < 1)
					{
						CardData key = keyValuePair.Key;
						dictionary.Remove(keyValuePair.Key);
						CardData cardData = CardData.CopyCardData(key, true);
						cardData.HP = cardData.MaxHP;
						cardData.MaxArmor += 2;
						cardData.Armor += 2;
						Card.InitCard(cardData);
						cardData.CardGameObject.transform.position = this.CardData.CurrentCardSlotData.CardSlotGameObject.transform.position;
						base.ShowMe();
						yield return this.TryJump(cardData);
					}
				}
				List<KeyValuePair<CardData, int>>.Enumerator enumerator = default(List<KeyValuePair<CardData, int>>.Enumerator);
				dictionary = null;
			}
			List<CardData> list = new List<CardData>();
			foreach (CardData cardData2 in base.GetAllCurrentMonsters())
			{
				if (cardData2.ModID != this.CardData.ModID && cardData2.HP < cardData2.MaxHP)
				{
					list.Add(cardData2);
				}
			}
			if (list.Count <= 0)
			{
				yield break;
			}
			CardData cardData3 = list[SYNCRandom.Range(0, list.Count)];
			base.ShowMe();
			yield return this.TryJumpIn(cardData3.CurrentCardSlotData, this.CardData.CurrentCardSlotData);
		}
		yield break;
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target == this.CardData && this.CardData.Attrs.ContainsKey("Child"))
		{
			Dictionary<CardData, int> dictionary = this.CardData.Attrs["Child"] as Dictionary<CardData, int>;
			foreach (KeyValuePair<CardData, int> keyValuePair in dictionary.ToList<KeyValuePair<CardData, int>>())
			{
				CardData key = keyValuePair.Key;
				dictionary.Remove(keyValuePair.Key);
				CardData cardData = CardData.CopyCardData(key, true);
				Card.InitCard(cardData);
				cardData.CardGameObject.transform.position = target.CurrentCardSlotData.CardSlotGameObject.transform.position;
				yield return this.TryJump(cardData);
			}
			List<KeyValuePair<CardData, int>>.Enumerator enumerator = default(List<KeyValuePair<CardData, int>>.Enumerator);
			dictionary = null;
		}
		yield break;
		yield break;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		if (this.CardData.Attrs.ContainsKey("Child"))
		{
			int count = (this.CardData.Attrs["Child"] as Dictionary<CardData, int>).Count;
		}
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_沙藏");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_沙藏");
	}

	public IEnumerator TryJump(CardData jumpO)
	{
		List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
		if (allEmptySlotsInMyBattleArea == null || allEmptySlotsInMyBattleArea.Count <= 0)
		{
			yield break;
		}
		CardSlotData target = allEmptySlotsInMyBattleArea[UnityEngine.Random.Range(0, allEmptySlotsInMyBattleArea.Count)];
		while (target.ChildCardData != null)
		{
			target = allEmptySlotsInMyBattleArea[UnityEngine.Random.Range(0, allEmptySlotsInMyBattleArea.Count)];
		}
		yield return jumpO.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		if (jumpO.Attrs.ContainsKey("Col"))
		{
			jumpO.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}

	public IEnumerator TryJumpIn(CardSlotData csd, CardSlotData target)
	{
		CardData card = csd.ChildCardData;
		CardData targetCard = target.ChildCardData;
		card.CardGameObject.transform.DOJump(target.CardSlotGameObject.transform.position, 0.3f, 1, 0.2f, false);
		yield return new WaitForSeconds(0.2f);
		if (targetCard.Attrs.ContainsKey("Child"))
		{
			(targetCard.Attrs["Child"] as Dictionary<CardData, int>).Add(card, 1);
		}
		else
		{
			Dictionary<CardData, int> dictionary = new Dictionary<CardData, int>();
			dictionary.Add(card, 1);
			targetCard.Attrs.Add("Child", dictionary);
		}
		card.DeleteCardData();
		yield break;
	}
}
