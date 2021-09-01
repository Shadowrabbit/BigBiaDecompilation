using System;
using System.Collections;
using UnityEngine;

public class ZheShanCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_折扇");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_折扇"), base.Layers + this.buff);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_折扇");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_折扇"), base.Layers + this.buff);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			CardData defaultTarget = base.GetDefaultTarget();
			if (DungeonOperationMgr.Instance.CheckCardDead(defaultTarget))
			{
				yield break;
			}
			base.ShowMe();
			ParticlePoolManager.Instance.Spawn(this.particleName, 1f).transform.position = defaultTarget.CardGameObject.transform.position + new Vector3(0f, 0.2f, 0f);
			ParticlePoolManager.Instance.Spawn(this.particleName1, 2f).transform.position = this.CardData.CardGameObject.transform.position + new Vector3(0f, 2.5f, 0f);
			defaultTarget.AddAffix(DungeonAffix.frozen, base.Layers + this.buff);
		}
		yield break;
	}

	public string particleName = "Effect/snowball";

	public string particleName1 = "Effect/snowball_hero";

	private int buff = 2;
}
