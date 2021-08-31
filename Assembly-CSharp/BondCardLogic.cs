using System;
using System.Collections;

public class BondCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		int layers = base.Layers;
		if (layers != 100)
		{
			if (layers != 150)
			{
				if (layers == 200)
				{
					this.Count = 9;
					this.Pay = 280;
				}
			}
			else
			{
				this.Count = 7;
				this.Pay = 195;
			}
		}
		else
		{
			this.Count = 5;
			this.Pay = 120;
		}
		this.displayName = "贷款！";
		this.Desc = "移动" + this.Count.ToString() + "格后还钱！";
	}

	public override IEnumerator OnMoveOnMap()
	{
		base.OnMoveOnMap();
		this.Count--;
		if (this.Count <= 0)
		{
			GameController.getInstance().GameData.Money -= this.Pay;
			base.ShowLogic("欠债还钱！");
			this.CardData.DeleteCardData();
		}
		yield break;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "贷款！";
		this.Desc = "移动" + this.Count.ToString() + "格后还钱！";
	}

	private int Count;

	private int Pay;
}
