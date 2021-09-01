using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class PanRenCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_障目");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_障目");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_障目");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_障目");
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		base.OnBeforeHpChange(player, value, from);
		if (player == this.CardData && value.value < 0)
		{
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			List<CardData> list = new List<CardData>();
			if (allCurrentMonsters.Count == 0)
			{
				yield break;
			}
			foreach (CardData cardData in allCurrentMonsters)
			{
				if (cardData.ModID == "枫叶" && !DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					list.Add(cardData);
				}
			}
			if (list.Count == 0)
			{
				yield break;
			}
			CardData cardData2 = list[SYNCRandom.Range(0, list.Count)];
			CardSlotData TargetSlot = cardData2.CurrentCardSlotData;
			base.ShowMe();
			cardData2.CardGameObject.gameObject.SetActive(false);
			DungeonOperationMgr.Instance.StartCoroutine(base.ShowCustomEffect("忍杀释放", TargetSlot, 0.5f));
			cardData2.DeleteCardData();
			value.value = 0;
			this.CardData.CardGameObject.gameObject.SetActive(false);
			yield return base.ShowCustomEffect("忍杀释放", this.CardData.CurrentCardSlotData, 0.5f);
			yield return this.CardData.CardGameObject.JumpToSlot(TargetSlot.CardSlotGameObject, 0.2f, true);
			this.CardData.CardGameObject.gameObject.SetActive(true);
			TargetSlot = null;
		}
		yield break;
	}

	public IEnumerator TryJump(CardSlotData csd, CardSlotData target)
	{
		CardData childCardData = csd.ChildCardData;
		yield return childCardData.CardGameObject.transform.DOJump(target.CardSlotGameObject.transform.position, 0.3f, 1, 0.2f, false).WaitForCompletion();
		yield break;
	}
}
