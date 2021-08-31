using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZhuanShengLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "转生";
		this.Desc = "里面沉睡的单位一回合后苏醒并出现在随机空格处，回复全部生命值。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn && this.CardData.Attrs.ContainsKey("Child"))
		{
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
					Card.InitCard(cardData);
					cardData.CardGameObject.transform.position = this.CardData.CurrentCardSlotData.CardSlotGameObject.transform.position;
					yield return this.TryJump(cardData);
				}
			}
			List<KeyValuePair<CardData, int>>.Enumerator enumerator = default(List<KeyValuePair<CardData, int>>.Enumerator);
			dictionary = null;
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
		int num = 0;
		if (this.CardData.Attrs.ContainsKey("Child"))
		{
			num = (this.CardData.Attrs["Child"] as Dictionary<CardData, int>).Count;
		}
		this.displayName = "转生";
		this.Desc = "里面沉睡的单位一回合后苏醒并出现在随机空格处，回复全部生命值。\n当前沉睡：" + num.ToString() + " 单位";
	}

	public IEnumerator TryJump(CardData jumpO)
	{
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		if (myBattleArea == null)
		{
			yield break;
		}
		CardSlotData target = myBattleArea[UnityEngine.Random.Range(0, myBattleArea.Count)];
		while (target.ChildCardData != null)
		{
			target = myBattleArea[UnityEngine.Random.Range(0, myBattleArea.Count)];
		}
		yield return jumpO.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		if (jumpO.Attrs.ContainsKey("Col"))
		{
			jumpO.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}
}
