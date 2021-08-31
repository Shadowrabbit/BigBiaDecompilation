using System;
using System.Collections;

public class JieJianLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "结茧";
		this.Desc = "回合结束后若本单位生命值低于50%，则化为幼虫并结茧。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn && (float)this.CardData.HP <= (float)this.CardData.MaxHP * 0.5f)
		{
			base.ShowMe();
			CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("幼虫"), true).PutInSlotData(this.CardData.CurrentCardSlotData, true);
			this.CardData.DeleteCardData();
		}
		yield break;
	}
}
