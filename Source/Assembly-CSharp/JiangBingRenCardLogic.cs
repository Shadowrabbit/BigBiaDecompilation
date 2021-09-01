using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiangBingRenCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_我爱曲奇");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_我爱曲奇"), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_我爱曲奇");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_我爱曲奇"), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn && !DungeonOperationMgr.Instance.CheckCardDead(this.CardData) && this.CardData.HP > 1 && !this.CardData.IsAttacked)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			if (allCurrentMinions.Count == 0)
			{
				yield break;
			}
			float num = 1f;
			List<CardData> list = new List<CardData>();
			foreach (CardData cardData in allCurrentMinions)
			{
				float num2 = (float)cardData.HP;
				float num3 = (float)cardData.MaxHP;
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					if (num2 / num3 < num)
					{
						num = num2 / num3;
						list.Clear();
						list.Add(cardData);
					}
					else if (cardData != this.CardData && num2 / num3 == num && num <= 1f)
					{
						list.Add(cardData);
					}
				}
			}
			if (list.Count == 0)
			{
				base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_没人需要治疗"));
				yield break;
			}
			CardData cardData2 = list[SYNCRandom.Range(0, list.Count)];
			int num4 = (this.CardData.HP - 1) * 2;
			int num5 = Mathf.CeilToInt((float)this.CardData.MaxHP * (this.baseDmg + this.increaseDmg * (float)base.Layers));
			int num6 = cardData2.MaxHP - cardData2.HP;
			int cureVal = 99999;
			if (num4 < cureVal)
			{
				cureVal = num4;
			}
			if (num5 < cureVal)
			{
				cureVal = num5;
			}
			if (num6 < cureVal)
			{
				cureVal = num6;
			}
			base.ShowMe();
			yield return base.Cure(this.CardData, cureVal, cardData2);
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -Mathf.RoundToInt((float)cureVal * 0.5f), this.CardData, false, 0, true, false);
		}
		yield break;
	}

	private float baseDmg = 0.2f;

	private float increaseDmg = 0.1f;
}
