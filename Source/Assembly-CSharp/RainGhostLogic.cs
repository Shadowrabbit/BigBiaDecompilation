using System;
using System.Collections;
using System.Collections.Generic;

public class RainGhostLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "雨天";
		this.Desc = "回合结束时，场上每有一张【细雨】，便获得+1+1";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		int num = 0;
		if (!isPlayerTurn)
		{
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			if (allCurrentMonsters == null || allCurrentMonsters.Count == 0)
			{
				yield break;
			}
			foreach (CardData cardData in allCurrentMonsters)
			{
				using (List<CardLogic>.Enumerator enumerator2 = cardData.CardLogics.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.GetType() == typeof(RainLogic))
						{
							num++;
						}
					}
				}
			}
			if (num > 0)
			{
				base.ShowMe();
				this.CardData._ATK += num;
				this.CardData.MaxHP += num;
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, num, this.CardData, false, 0, true, false);
			}
		}
		yield break;
	}
}
