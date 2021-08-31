using System;
using System.Collections;

public class TuDunLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_145");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_145"), 2);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_145");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_145"), 2 - this.m_Round);
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		if (!this.m_IsChanged)
		{
			if ((float)this.CardData.HP < (float)this.CardData.MaxHP * 0.2f)
			{
				this.CardData._ATK = 0;
				this.CardData._AttackTimes = 0;
				this.CardData.MaxArmor = 15;
				this.CardData.Armor = 15;
				this.m_IsChanged = true;
				base.ShowMe();
			}
		}
		else
		{
			int armor = this.CardData.Armor;
		}
		yield break;
	}

	private void Die()
	{
		ActData actData = new ActData();
		actData.Type = "Act/Gift";
		actData.Model = "ActTable/Gift";
		(GameController.getInstance().GameData.PlayerCardData.CardGameObject.StartAct(actData) as GiftAct).GiftNames.Add("生菜种子");
		this.CardData.DeleteCardData();
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn && this.m_IsChanged)
		{
			this.m_Round++;
			if (this.m_Round > 2)
			{
				this.CardData.DeleteCardData();
			}
		}
		yield break;
	}

	private int m_Round;

	private bool m_IsChanged;
}
