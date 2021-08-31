using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiLingFaShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_死灵掌控");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_死灵掌控"), 100f * (this.baseDmg + this.increaseDmg * (float)base.Layers));
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_死灵掌控");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_死灵掌控"), 100f * (this.baseDmg + this.increaseDmg * (float)base.Layers));
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (target.ModID == "骷髅")
		{
			this.deadPerson = null;
		}
		else
		{
			this.deadPerson = target;
		}
		yield break;
	}

	public override IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
	{
		base.OnAfterKill(cardSlot, originCarddata);
		if (this.deadPerson == null)
		{
			yield break;
		}
		List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
		if (allEmptySlotsInMyBattleArea.Count == 0)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_空间不够了"));
			yield break;
		}
		CardData cardData = Card.InitCardDataByID(LocalizationMgr.Instance.GetLocalizationWord("骷髅"));
		cardData._ATK = Mathf.CeilToInt((float)this.deadPerson._ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers));
		if (this.deadPerson.HasTag(TagMap.随从) && this.deadPerson.CardLogics.Count > 0)
		{
			foreach (CardLogic cardLogic in this.deadPerson.CardLogics)
			{
				if (!(cardLogic is MinionLogic) && !(cardLogic is FaithCardLogic))
				{
					cardData.AddLogic(cardLogic.GetType().Name, cardLogic.Layers);
				}
			}
		}
		base.ShowMe();
		CardSlotData cardSlotData = allEmptySlotsInMyBattleArea[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea.Count)];
		ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = cardSlotData.CardSlotGameObject.transform.position;
		this.minions.Add(cardData);
		cardData.PutInSlotData(cardSlotData, true);
		yield break;
	}

	public List<CardData> getMinions()
	{
		return this.minions;
	}

	private CardData deadPerson;

	private List<CardData> minions = new List<CardData>();

	private float baseDmg = 0.5f;

	private float increaseDmg = 0.5f;
}
