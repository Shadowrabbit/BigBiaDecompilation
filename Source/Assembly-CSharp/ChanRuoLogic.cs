using System;
using System.Collections;
using System.Collections.Generic;

public class ChanRuoLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "孱弱";
		this.Desc = "该单位只想躲在别人后面输出，否则只能造成一半的伤害。";
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.AddLogic("BiaoZhunLogic");
		this.CardData.CardLogics.Remove(this);
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
		if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) < slotsOnPlayerTable.Count / 3 * 2)
		{
			CardSlotData cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3];
			if (cardSlotData.ChildCardData == null || !cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
				{
					foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
					{
						base.ShowMe();
						attackMsg.Dmg = this.CardData.ATK / 2;
					}
				}
			}
		}
		else
		{
			for (int j = 0; j < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; j++)
			{
				foreach (AttackMsg attackMsg2 in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[j])
				{
					base.ShowMe();
					attackMsg2.Dmg = this.CardData.ATK / 2;
				}
			}
		}
		yield break;
	}

	private void AddLogic(string logicName)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		this.CardData.Name = "标准战士";
		cardLogic.CardData = this.CardData;
		this.CardData.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(this.CardData);
	}
}
