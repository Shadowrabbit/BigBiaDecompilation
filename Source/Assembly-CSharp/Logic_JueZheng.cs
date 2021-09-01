using System;
using System.Collections;

public class Logic_JueZheng : PersonCardLogic
{
	public override void Init()
	{
		this.IsDebuff = true;
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_160");
		this.Desc = this.m_round.ToString() + LocalizationMgr.Instance.GetLocalizationWord("CT_D_160");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			this.m_round--;
			if (this.m_round <= 0)
			{
				yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_49"));
				yield return DungeonOperationMgr.Instance.DungeonHandler.Die(this.CardData, this.CardData.HP, this.CardData);
			}
		}
		yield break;
	}

	private int m_round = 3;
}
