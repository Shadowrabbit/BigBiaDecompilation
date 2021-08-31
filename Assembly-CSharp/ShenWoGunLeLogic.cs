using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class ShenWoGunLeLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = "什！我滚了！";
		this.Desc = "每受到两次攻击，生成一个随机的方向道具。";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "什！我滚了！";
		this.Desc = "每受到两次攻击，生成一个随机的方向道具。\n 剩余：" + (2 - this.m_BeAttackCount % 2).ToString() + "次";
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		if (player == this.CardData && changedValue < 0)
		{
			this.m_BeAttackCount++;
			if (this.m_BeAttackCount % 2 == 0)
			{
				base.ShowMe();
				CardSlotData targetSlot = GameController.ins.GetEmptySlotDataByCardTag(TagMap.工具);
				CardData item;
				if (targetSlot != null)
				{
					List<string> list = new List<string>
					{
						"上",
						"下",
						"左",
						"右"
					};
					item = GameController.ins.CardDataModMap.getCardDataByModID(list[SYNCRandom.Range(0, list.Count)]);
					item = CardData.CopyCardData(item, true);
					Card.InitCard(item);
					yield return null;
					item.CardGameObject.transform.position = this.CardData.CardGameObject.transform.position;
					yield return item.CardGameObject.transform.DOJump(targetSlot.CardSlotGameObject.transform.position, 0.5f, 1, 0.2f, false).WaitForCompletion();
					item.PutInSlotData(targetSlot, true);
				}
				item = null;
				targetSlot = null;
			}
		}
		yield break;
	}

	private int m_BeAttackCount;
}
