using System;
using System.Collections;

public class ChongWangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_啃噬");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_啃噬");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_啃噬");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_啃噬");
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (!DungeonOperationMgr.Instance.CheckCardDead(this.CardData))
		{
			base.ShowMe();
			yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, this.CardData);
			this.CardData.MaxArmor++;
			this.CardData.Armor++;
			this.CardData.AddAffix(DungeonAffix.strength, 2);
		}
		yield break;
	}
}
