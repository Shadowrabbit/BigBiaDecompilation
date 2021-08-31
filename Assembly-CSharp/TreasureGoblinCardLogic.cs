using System;
using System.Collections;
using UnityEngine;

public class TreasureGoblinCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_钥匙地精");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_钥匙地精"), this.Disappear);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_钥匙地精");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_钥匙地精"), this.Disappear);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			this.Disappear--;
			if (this.Disappear <= 0)
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("ZM_消失"));
				this.Key = 0;
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -9999, null, true, 0, true, false);
			}
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (target == this.CardData && this.Key > 0)
		{
			Vector3 position = GameController.getInstance().playerTableText.Money.transform.position + new Vector3(1f, 0f, 0f);
			string name = "Effect/HealMoney";
			ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = position;
			GameController.ins.GameData.KeyNum++;
			yield break;
		}
		yield break;
	}

	private int Disappear = 2;

	private int Key = 1;
}
