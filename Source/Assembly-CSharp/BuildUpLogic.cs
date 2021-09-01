using System;
using System.Collections;

public class BuildUpLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "蓄能";
		this.Desc = "回合开始时获得1层充能。消耗4层充能使本回合+" + this.CardData.ATK.ToString() + "[100%攻击力]点攻击力。";
	}

	public override IEnumerator OnTurnStart()
	{
		base.ShowMe();
		base.Layers++;
		if (base.Layers >= 4)
		{
			this.CardData.wATK += this.CardData.ATK;
		}
		yield break;
	}
}
