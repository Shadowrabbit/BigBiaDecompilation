using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhongYaLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.NeedEnergyCount = new Vector3Int(0, 0, 1);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_41");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_41");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_41");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_41");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		List<CardSlotData> CardSlots = base.GetEnemiesBattleArea();
		if (CardSlots == null)
		{
			yield break;
		}
		int num;
		for (int i = CardSlots.Count - 1; i >= 0; i = num - 1)
		{
			if (CardSlots[i].GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col") && CardSlots[i].ChildCardData != null && CardSlots[i].ChildCardData.HasTag(TagMap.怪物))
			{
				base.ShowMe();
				int damage = (this.CardData.HP - CardSlots[i].ChildCardData.HP > 0) ? (this.CardData.HP - CardSlots[i].ChildCardData.HP) : 0;
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, CardSlots[i].ChildCardData, damage, 0.2f, false, 0, null, null);
				yield return this.TryJump(CardSlots[i]);
				this.CardData.IsAttacked = true;
				yield break;
			}
			num = i;
		}
		yield break;
	}

	public IEnumerator TryJump(CardSlotData csd)
	{
		List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
		if (enemiesBattleArea == null || csd.ChildCardData == null || DungeonOperationMgr.Instance.CheckCardDead(csd.ChildCardData))
		{
			yield break;
		}
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		Vector3Int down = Vector3Int.down;
		CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(csd.GridPositionX, csd.GridPositionY, down.x, down.y, false);
		if (ralitiveCardSlotData == null || enemiesBattleArea.IndexOf(csd) <= 2)
		{
			yield break;
		}
		if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData == null && csd.ChildCardData.CardGameObject != null)
		{
			yield return csd.ChildCardData.CardGameObject.JumpToSlot(ralitiveCardSlotData.CardSlotGameObject, 0.2f, true);
			yield break;
		}
		yield break;
	}
}
