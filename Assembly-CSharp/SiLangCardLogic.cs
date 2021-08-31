using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiLangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_妖刀");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_妖刀");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_妖刀");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_妖刀");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			yield break;
		}
		List<CardData> monstersNearBy = base.GetMonstersNearBy(this.CardData.CurrentCardSlotData, new List<Vector3Int>
		{
			Vector3Int.up,
			Vector3Int.down,
			Vector3Int.left,
			Vector3Int.right
		});
		if (monstersNearBy.Count == 0)
		{
			yield break;
		}
		CardData cardData = monstersNearBy[SYNCRandom.Range(0, monstersNearBy.Count)];
		if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
		{
			base.ShowMe();
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, cardData, this.CardData._ATK, 0.2f, false, 0, null, null);
			yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, this.CardData);
			this.CardData._ATK++;
		}
		yield break;
	}

	private float debuff = 0.1f;

	private float buff = 1.2f;
}
