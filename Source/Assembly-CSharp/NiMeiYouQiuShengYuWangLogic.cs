using System;
using System.Collections;
using System.Collections.Generic;

public class NiMeiYouQiuShengYuWangLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = "你没有求生欲望";
		this.Desc = "攻击造成目标流血，并使我方同列单位愈合。(效果层数等于当前地下城层数)";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "你没有求生欲望";
		this.Desc = "攻击造成目标流血，并使我方同列单位愈合。(效果层数等于当前地下城层数)\n 当前层数：" + GameController.ins.GameData.level.ToString();
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData)
		{
			base.ShowMe();
			if (target.ChildCardData != null && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
			{
				target.ChildCardData.AddAffix(DungeonAffix.bleeding, GameController.ins.GameData.level);
			}
			using (List<CardData>.Enumerator enumerator = base.GetAllCurrentMinions().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData = enumerator.Current;
					if ((int)cardData.CurrentCardSlotData.Attrs["Col"] == (int)this.CardData.CurrentCardSlotData.Attrs["Col"])
					{
						cardData.AddAffix(DungeonAffix.heal, GameController.ins.GameData.level);
					}
				}
				yield break;
			}
		}
		yield break;
	}
}
