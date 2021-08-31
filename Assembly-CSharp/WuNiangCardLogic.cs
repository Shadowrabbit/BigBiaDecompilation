using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WuNiangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.NeedEnergyCount = new Vector3Int(0, 1, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_红袖");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_红袖"), (float)base.Layers * this.baseDmg * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_红袖");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_红袖"), (float)base.Layers * this.baseDmg * 100f);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		this.isUsing = true;
		yield break;
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (this.isUsing && changedValue < 0)
		{
			List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
			if (player.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(player) && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) == slotsOnPlayerTable.IndexOf(player.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3)
			{
				base.ShowMe();
				yield return base.Cure(this.CardData, Mathf.CeilToInt((float)(-(float)changedValue) * ((float)base.Layers * this.baseDmg)), player);
				if (base.GetLogic(this.CardData, typeof(WuNiangSkill2CardLogic)) != null && this.CardData.Rare >= 4)
				{
					yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, this.CardData);
					base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_剑舞"));
					this.CardData.InBattleATK += Mathf.CeilToInt((float)(-(float)changedValue) * ((float)base.Layers * this.baseDmg));
				}
			}
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn && this.isUsing)
		{
			this.isUsing = false;
			yield break;
		}
		yield break;
	}

	private bool isUsing;

	private float baseDmg = 0.1f;
}
