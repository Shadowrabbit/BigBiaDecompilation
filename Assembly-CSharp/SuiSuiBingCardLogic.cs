using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuiSuiBingCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(3, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_碎碎冰");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_碎碎冰"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f, base.Layers + this.buff);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_碎碎冰");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_碎碎冰"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f, base.Layers + this.buff);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		if (allCurrentMonsters.Count == 0)
		{
			yield break;
		}
		List<CardData> targets = new List<CardData>();
		Dictionary<CardData, int> dictionary = new Dictionary<CardData, int>();
		for (int i = 0; i < 3; i++)
		{
			CardData cardData = null;
			foreach (CardData cardData2 in allCurrentMonsters)
			{
				if (cardData2.CurrentCardSlotData.Attrs.ContainsKey("Col") && int.Parse(cardData2.CurrentCardSlotData.Attrs["Col"].ToString()) == i && !DungeonOperationMgr.Instance.CheckCardDead(cardData2))
				{
					cardData = cardData2;
				}
			}
			if (cardData != null)
			{
				targets.Add(cardData);
			}
		}
		if (targets.Count == 0)
		{
			yield break;
		}
		foreach (CardData key in targets)
		{
			dictionary.Add(key, -Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)));
		}
		base.ShowMe();
		yield return base.AOE(dictionary, this.CardData, false, 0, true);
		using (List<CardData>.Enumerator enumerator = targets.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardData cardData3 = enumerator.Current;
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData3))
				{
					cardData3.AddAffix(DungeonAffix.frozen, base.Layers + this.buff);
				}
			}
			yield break;
		}
		yield break;
	}

	private float baseDmg = 0.5f;

	private float increaseDmg = 1f;

	private int buff = 2;
}
