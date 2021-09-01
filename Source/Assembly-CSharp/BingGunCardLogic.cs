using System;
using System.Collections;
using UnityEngine;

public class BingGunCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_冰棍");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_冰棍"), base.Layers + this.buff);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_冰棍");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_冰棍"), base.Layers + this.buff);
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player == this.CardData && changedValue < 0 && !DungeonOperationMgr.Instance.CheckCardDead(from))
		{
			base.ShowMe();
			ParticlePoolManager.Instance.Spawn(this.particleName, 1f).transform.position = from.CardGameObject.transform.position + new Vector3(0f, 0.2f, 0f);
			ParticlePoolManager.Instance.Spawn(this.particleName1, 2f).transform.position = this.CardData.CardGameObject.transform.position + new Vector3(0f, 2.5f, 0f);
			from.AddAffix(DungeonAffix.frozen, base.Layers + this.buff);
		}
		yield break;
	}

	private int buff = 2;

	public string particleName = "Effect/snowball";

	public string particleName1 = "Effect/snowball_hero";
}
