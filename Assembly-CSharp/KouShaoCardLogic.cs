using System;
using System.Collections;

public class KouShaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_口哨");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_口哨"), base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_口哨");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_口哨"), base.Layers * this.weight);
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (player == this.CardData)
		{
			this.flag = true;
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		if (user == this.CardData)
		{
			this.flag = true;
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		base.OnBeforeAttack(player, target);
		if (player.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(player) && this.flag)
		{
			base.ShowMe();
			yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, player);
			player.AddAffix(DungeonAffix.strength, base.Layers * this.weight);
			this.flag = false;
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnCardBeforeUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardBeforeUseSkill(user, origin);
		if (user.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(user) && this.flag)
		{
			base.ShowMe();
			yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, user);
			user.AddAffix(DungeonAffix.strength, base.Layers * this.weight);
			this.flag = false;
			yield break;
		}
		yield break;
	}

	private bool flag;

	private int weight = 2;
}
