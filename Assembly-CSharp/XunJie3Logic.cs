using System;
using System.Collections;

public class XunJie3Logic : FaithCardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_迅捷3");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_迅捷3");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_迅捷3");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_迅捷3");
	}

	public override IEnumerator OnFinishAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData && this.m_AtkTimes > 0)
		{
			base.ShowMe();
			this.m_AtkTimes--;
			ParticlePoolManager.Instance.Spawn("Effect/FirstStrike", 3f).transform.position = this.CardData.CardGameObject.transform.position;
			this.CardData.IsAttacked = false;
		}
		yield break;
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		if (user == this.CardData && this.m_AtkTimes > 0)
		{
			base.ShowMe();
			this.m_AtkTimes--;
			ParticlePoolManager.Instance.Spawn("Effect/FirstStrike", 3f).transform.position = this.CardData.CardGameObject.transform.position;
			this.CardData.IsAttacked = false;
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			this.m_AtkTimes = 1;
		}
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		this.m_AtkTimes = 1;
		yield break;
	}

	public override IEnumerator OnBattleStart()
	{
		this.m_AtkTimes = 1;
		yield break;
	}

	private int m_AtkTimes = 1;
}
