using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuNaiYiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_木乃伊诅咒");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_木乃伊诅咒");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_木乃伊诅咒");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_木乃伊诅咒");
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		List<CardData> monstersNearBy = base.GetMonstersNearBy(this.CardData.CurrentCardSlotData, new List<Vector3Int>
		{
			Vector3Int.up,
			Vector3Int.down,
			Vector3Int.left,
			Vector3Int.right
		});
		monstersNearBy.Add(this.CardData);
		if (monstersNearBy.Count == 0 || from == null)
		{
			yield break;
		}
		if (monstersNearBy.Contains(player) && changedValue < 0 && !DungeonOperationMgr.Instance.CheckCardDead(from))
		{
			base.ShowMe();
			yield return DungeonOperationMgr.Instance.PlayerAttackEffect(this.CardData, from, 1f, null, null, null);
			from.AddAffix(DungeonAffix.frail, 1);
			from.AddAffix(DungeonAffix.weak, 1);
		}
		yield break;
	}
}
