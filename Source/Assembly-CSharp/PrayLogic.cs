using System;
using System.Collections;

public class PrayLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = "祈祷";
		this.Desc = "己方回合结束时，50%概率+" + (2 * base.Layers).ToString() + "充能。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			if (SYNCRandom.Range(0, 100) < 50)
			{
				base.ShowMe();
				this.CardData.MP += 2 * base.Layers;
			}
			yield break;
		}
		yield break;
	}
}
