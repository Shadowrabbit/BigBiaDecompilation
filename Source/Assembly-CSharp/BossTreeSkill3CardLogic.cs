using System;
using System.Collections;
using System.Collections.Generic;

public class BossTreeSkill3CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大树4");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大树4");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		CardLogic logic = base.GetLogic(this.CardData, typeof(BossTreeCardLogic));
		if (logic != null)
		{
			if (logic.Layers == 1)
			{
				this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大树4");
				this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大树4");
				return;
			}
			this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大树5");
			this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大树5");
		}
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		CardLogic logic = base.GetLogic(this.CardData, typeof(BossTreeCardLogic));
		if (logic != null && logic.Layers == 1)
		{
			base.ShowMe();
			for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
			{
				foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
				{
					attackMsg.Target.AddAffix(DungeonAffix.poisoning, 1);
				}
			}
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			yield break;
		}
		CardLogic logic = base.GetLogic(this.CardData, typeof(BossTreeCardLogic));
		if (logic != null && logic.Layers == 2)
		{
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			List<CardData> list = new List<CardData>();
			if (allCurrentMonsters.Count == 0)
			{
				yield break;
			}
			foreach (CardData cardData in allCurrentMonsters)
			{
				if (!cardData.HasTag(TagMap.BOSS) && cardData.HasTag(TagMap.怪物) && cardData.HasTag(TagMap.衍生物))
				{
					list.Add(cardData);
				}
			}
			if (list.Count == 0)
			{
				yield break;
			}
			base.ShowMe();
			using (List<CardData>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData2 = enumerator.Current;
					if (!DungeonOperationMgr.Instance.CheckCardDead(cardData2))
					{
						DungeonOperationMgr.Instance.StartCoroutine(base.PlayCureEffect(this.CardData, cardData2));
						cardData2.AddAffix(DungeonAffix.strength, 3);
						cardData2.AddAffix(DungeonAffix.heal, 3);
					}
				}
				yield break;
			}
		}
		yield break;
	}
}
