using System;
using System.Collections;
using System.Collections.Generic;

public class RenLianShiBieCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_人脸识别");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_人脸识别");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_人脸识别");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_人脸识别");
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.ShowMe();
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		using (List<CardSlotData>.Enumerator enumerator = DungeonOperationMgr.Instance.BattleArea.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardSlotData cardSlotData = enumerator.Current;
				if (DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
				{
					yield break;
				}
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardSlotData.ChildCardData) && cardSlotData.ChildCardData != null && target.ChildCardData.ModID.Equals(cardSlotData.ChildCardData.ModID) && cardSlotData.ChildCardData != target.ChildCardData)
				{
					DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Add(new List<AttackMsg>
					{
						new AttackMsg(cardSlotData.ChildCardData, this.CardData.ATK, false, true, 0, 0, null)
					});
				}
			}
			yield break;
		}
		yield break;
	}
}
