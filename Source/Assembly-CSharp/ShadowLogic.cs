using System;
using System.Collections;
using System.Collections.Generic;

public class ShadowLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = "浮影";
		this.Desc = "自身击杀敌人时，在目标处召唤一个1/1的影子衍生物。";
	}

	public override IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
	{
		if (originCarddata != null && originCarddata == this.CardData)
		{
			using (List<CardLogic>.Enumerator enumerator = this.CardData.CardLogics.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GetType() == typeof(RealShadowLogic))
					{
						CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("真实之影"), true);
						yield break;
					}
				}
			}
			CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("虚无之影"), true).PutInSlotData(cardSlot, true);
		}
		yield break;
	}
}
