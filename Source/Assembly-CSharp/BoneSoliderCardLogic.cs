using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneSoliderCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "酷刑";
		this.Desc = "玩家回合结束时，对随机友军造成" + Mathf.CeilToInt((float)this.CardData.ATK * 0.25f).ToString() + "[25%攻击力]点伤害，并令其攻击力提高50%。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			for (int i = 0; i < allCurrentMonsters.Count; i++)
			{
				if (allCurrentMonsters[i] == this.CardData)
				{
					allCurrentMonsters.RemoveAt(i);
					break;
				}
			}
			if (allCurrentMonsters.Count <= 0)
			{
				yield break;
			}
			CardData SelectedMonster = allCurrentMonsters[SYNCRandom.Range(0, allCurrentMonsters.Count)];
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, SelectedMonster, Mathf.CeilToInt((float)this.CardData.ATK * 0.25f), 0.2f, false, 0, null, null);
			SelectedMonster._ATK = Mathf.CeilToInt((float)SelectedMonster.ATK * 1.5f);
			SelectedMonster = null;
		}
		yield break;
	}
}
