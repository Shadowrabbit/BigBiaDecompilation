using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BudSeedLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		if (this.CardData != null)
		{
			this.Color = CardLogicColor.blue;
			if (base.Layers < 1)
			{
				base.Layers = 1;
			}
		}
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_反哺");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_反哺");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_反哺");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_反哺");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (this.CardData.HasTag(TagMap.怪物) && !isPlayerTurn)
		{
			List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
			foreach (CardSlotData cs in cardSlotDatas)
			{
				if (cs.ChildCardData != null && cs.ChildCardData.ModID.Equals("BossTreeCard") && cs.ChildCardData.HP < cs.ChildCardData.MaxHP)
				{
					ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HellHpBall", 0.5f);
					particleObject.transform.position = this.CardData.CardGameObject.transform.position;
					yield return particleObject.transform.DOMove(cs.ChildCardData.CardGameObject.transform.position, 0.5f, false).WaitForCompletion();
					string name = "Effect/HealHp";
					ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = cs.ChildCardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
					yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cs.ChildCardData, Mathf.CeilToInt((float)cs.ChildCardData.MaxHP * 0.02f), this.CardData, false, 0, true, false);
					yield break;
				}
				cs = null;
			}
			List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		}
		yield break;
		yield break;
	}
}
