using System;
using System.Collections;

public class GhostBallLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "幻影宝珠";
		this.Desc = "本回合内护甲+50";
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (this.CardData.HasTag(TagMap.随从) && !isPlayerTurn)
		{
			this.CardData.Armor -= 50;
			this.CardData.MaxArmor -= 50;
			if (this.CardData.Armor < 0)
			{
				this.CardData.Armor = 0;
			}
			base.RemoveCardLogic(this.CardData, typeof(GhostBallLogic), "GhostBallLogic");
		}
		yield break;
	}
}
