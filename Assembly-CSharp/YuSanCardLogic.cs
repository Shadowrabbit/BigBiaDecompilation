using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YuSanCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_雨伞");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_雨伞"), base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_雨伞");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_雨伞"), base.Layers * this.weight);
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		if (DungeonOperationMgr.Instance.GetCardDataNearBy(this.CardData, new List<Vector3Int>
		{
			Vector3Int.down,
			Vector3Int.down + Vector3Int.down
		}).Count > 0)
		{
			base.ShowMe();
			this.CardData.AddAffix(DungeonAffix.def, base.Layers * this.weight);
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		if (DungeonOperationMgr.Instance.GetCardDataNearBy(this.CardData, new List<Vector3Int>
		{
			Vector3Int.down,
			Vector3Int.down + Vector3Int.down
		}).Count > 0)
		{
			base.ShowMe();
			this.CardData.AddAffix(DungeonAffix.def, base.Layers * this.weight);
			yield break;
		}
		yield break;
	}

	private int weight = 1;
}
