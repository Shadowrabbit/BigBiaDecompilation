using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSnakeAOEAttack : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇2");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇2");
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		List<CardData> list = new List<CardData>();
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		for (int i = playerSlotSets.Count / 3 * 2; i < playerSlotSets.Count; i++)
		{
			if (playerSlotSets[i] != null && playerSlotSets[i].ChildCardData != null && playerSlotSets[i].ChildCardData.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(playerSlotSets[i].ChildCardData))
			{
				list.Add(playerSlotSets[i].ChildCardData);
			}
			else if (playerSlotSets[i - playerSlotSets.Count / 3] != null && playerSlotSets[i - playerSlotSets.Count / 3].ChildCardData != null && playerSlotSets[i - playerSlotSets.Count / 3].ChildCardData.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(playerSlotSets[i - playerSlotSets.Count / 3].ChildCardData))
			{
				list.Add(playerSlotSets[i - playerSlotSets.Count / 3].ChildCardData);
			}
			else if (playerSlotSets[i - playerSlotSets.Count / 3 * 2] != null && playerSlotSets[i - playerSlotSets.Count / 3 * 2].ChildCardData != null && playerSlotSets[i - playerSlotSets.Count / 3 * 2].ChildCardData.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(playerSlotSets[i - playerSlotSets.Count / 3 * 2].ChildCardData))
			{
				list.Add(playerSlotSets[i - playerSlotSets.Count / 3 * 2].ChildCardData);
			}
		}
		CardData originCardData = this.CardData;
		int attackTimes = originCardData.AttackTimes;
		foreach (CardData cardData in list)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(originCardData) && !DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.BossAttackEffect(originCardData, cardData, UnityEngine.Object.FindObjectOfType<BossSnakeArea>().CardSlot.transform.position, 1f, null, null, null));
			}
		}
		foreach (CardData cardData2 in list)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(originCardData) && !DungeonOperationMgr.Instance.CheckCardDead(cardData2) && !DungeonOperationMgr.Instance.CheckCardDead(cardData2))
			{
				yield return this.DungeonHandler.ChangeHp(cardData2, -originCardData.ATK, originCardData, false, 0, true, false);
			}
		}
		List<CardData>.Enumerator enumerator2 = default(List<CardData>.Enumerator);
		yield return new WaitForSeconds(0.15f);
		yield break;
		yield break;
	}

	public bool IsCanAttack;

	public DungeonHandler DungeonHandler = new DungeonHandler();

	private const float c_SlashEffectSpeed = 10f;

	private const float c_SlashMaxTime = 2f;

	private const float c_MonsterDamagedTime = 0.1f;

	private const float c_MonsterShakeTime = 0.1f;
}
