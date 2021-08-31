using System;
using System.Collections;

public class SuoXueGuaCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_锁血挂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_锁血挂");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_锁血挂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_锁血挂");
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		base.OnBeforeHpChange(player, value, from);
		if (player == this.CardData && value.value < 0 && this.round <= 1)
		{
			base.ShowMe();
			value.value = 0;
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			this.round++;
			if (this.round > 1)
			{
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -9999, null, true, 0, true, false);
			}
			yield break;
		}
		yield break;
	}

	private int round;
}
