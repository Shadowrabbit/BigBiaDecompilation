using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiLeiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_地雷");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_地雷"), this.increaseDmg * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_地雷");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_地雷"), this.increaseDmg * 100f);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			yield break;
		}
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardSlotData> list = new List<CardSlotData>();
		if (playerSlotSets.IndexOf(this.CardData.CurrentCardSlotData) < playerSlotSets.Count / 3 * 2 && playerSlotSets[playerSlotSets.IndexOf(this.CardData.CurrentCardSlotData) + playerSlotSets.Count / 3].ChildCardData != null)
		{
			CardSlotData item = playerSlotSets[playerSlotSets.IndexOf(this.CardData.CurrentCardSlotData) + playerSlotSets.Count / 3];
			list.Add(item);
		}
		if (list.Count == 0)
		{
			yield return this.Explode();
		}
		yield break;
	}

	private IEnumerator Explode()
	{
		base.ShowMe();
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		Dictionary<CardData, int> dictionary = new Dictionary<CardData, int>();
		if (allCurrentMinions.Count > 0)
		{
			foreach (CardData cardData in allCurrentMinions)
			{
				if (cardData != this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					dictionary.Add(cardData, -Mathf.CeilToInt((float)cardData.MaxHP * this.increaseDmg));
				}
			}
		}
		if (allCurrentMonsters.Count > 0)
		{
			foreach (CardData cardData2 in allCurrentMonsters)
			{
				if (cardData2 != this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(cardData2))
				{
					dictionary.Add(cardData2, -Mathf.CeilToInt((float)cardData2.MaxHP * this.increaseDmg));
				}
			}
		}
		string name = "Effect/捶胸大吼命中";
		ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = this.CardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
		foreach (KeyValuePair<CardData, int> keyValuePair in dictionary)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(keyValuePair.Key))
			{
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(keyValuePair.Key, keyValuePair.Value, this.CardData, false, 0, true, false);
			}
		}
		Dictionary<CardData, int>.Enumerator enumerator2 = default(Dictionary<CardData, int>.Enumerator);
		if (!DungeonOperationMgr.Instance.CheckCardDead(this.CardData))
		{
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -9999, this.CardData, true, 0, true, false);
		}
		yield break;
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target == this.CardData && from != this.CardData)
		{
			yield return this.Explode();
		}
		yield break;
	}

	private float baseDmg;

	private float increaseDmg = 0.7f;
}
