using System;
using System.Collections;
using System.Collections.Generic;

public class KouQinCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_口琴");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_口琴"), base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_口琴");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_口琴"), base.Layers * this.weight);
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (player.HasTag(TagMap.随从))
		{
			this._targetId = player.ID;
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		if (user.HasTag(TagMap.随从))
		{
			this._targetId = user.ID;
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		base.OnBeforeAttack(player, target);
		if (player == this.CardData)
		{
			if (!GameController.ins.CardDataInWorldMap.ContainsKey(this._targetId))
			{
				yield break;
			}
			CardData cardData = GameController.ins.CardDataInWorldMap[this._targetId];
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				base.ShowMe();
				DungeonOperationMgr.Instance.PlayCureEffect(new List<CardData>
				{
					cardData
				});
				cardData.AddAffix(DungeonAffix.heal, base.Layers * this.weight);
				yield break;
			}
		}
		yield break;
	}

	public override IEnumerator OnCardBeforeUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardBeforeUseSkill(user, origin);
		if (user == this.CardData)
		{
			if (!GameController.ins.CardDataInWorldMap.ContainsKey(this._targetId))
			{
				yield break;
			}
			CardData cardData = GameController.ins.CardDataInWorldMap[this._targetId];
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				base.ShowMe();
				DungeonOperationMgr.Instance.PlayCureEffect(new List<CardData>
				{
					cardData
				});
				cardData.AddAffix(DungeonAffix.heal, base.Layers * this.weight);
				yield break;
			}
		}
		yield break;
	}

	public string _targetId = string.Empty;

	private int weight = 2;
}
