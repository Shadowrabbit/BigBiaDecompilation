using System;
using System.Collections;

public class YaLingCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_杠铃");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_杠铃");
		if (this.CardData != null)
		{
			this.CardData._ATK = SYNCRandom.Range(7, 20);
		}
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_杠铃");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_杠铃");
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		base.OnBeforeHpChange(player, value, from);
		if (player == this.CardData && value.value < 0)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(this.CardData) && !DungeonOperationMgr.Instance.CheckCardDead(from))
			{
				if (this.CardData.ATK > from.ATK)
				{
					value.value = 0;
				}
				from.InBattleATK++;
			}
			yield break;
		}
		yield break;
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		yield break;
	}
}
