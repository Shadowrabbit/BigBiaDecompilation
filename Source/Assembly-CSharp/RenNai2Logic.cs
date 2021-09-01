using System;
using System.Collections;

public class RenNai2Logic : FaithCardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_坚毅2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_坚毅2");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_坚毅2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_坚毅2");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			base.ShowMe();
			this.CardData.HP = ((this.CardData.HP + 3 > this.CardData.MaxHP) ? this.CardData.MaxHP : (this.CardData.HP + 3));
			ParticlePoolManager.Instance.Spawn("Effect/HealHp", 3f).transform.position = this.CardData.CardGameObject.transform.position;
		}
		yield break;
	}
}
