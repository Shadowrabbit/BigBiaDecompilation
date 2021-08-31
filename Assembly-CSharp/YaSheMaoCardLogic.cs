using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaSheMaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_鸭舌帽");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_鸭舌帽"), base.Layers + 1);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_鸭舌帽");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_鸭舌帽"), base.Layers + 1);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			if (DungeonOperationMgr.Instance.GetCardDataNearBy(this.CardData, new List<Vector3Int>
			{
				Vector3Int.up,
				Vector3Int.up + Vector3Int.up
			}).Count == 0)
			{
				base.ShowMe();
				this.CardData.AddAffix(DungeonAffix.crit, base.Layers + 1);
			}
			yield break;
		}
		yield break;
	}
}
