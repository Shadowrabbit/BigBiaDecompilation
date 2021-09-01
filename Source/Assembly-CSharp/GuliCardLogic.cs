using System;
using System.Collections;

public class GuliCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("M_N_2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("M_D_2");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("M_N_2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("M_D_2");
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData)
		{
			CardData cardData = null;
			int num = GameController.getInstance().PlayerSlotSets.Count / 3;
			for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i++)
			{
				if (GameController.getInstance().PlayerSlotSets[i].ChildCardData == this.CardData && i + 1 < GameController.getInstance().PlayerSlotSets.Count && GameController.getInstance().PlayerSlotSets[i + 1].ChildCardData != null && GameController.getInstance().PlayerSlotSets[i + 1].ChildCardData.HasTag(TagMap.随从))
				{
					cardData = GameController.getInstance().PlayerSlotSets[i + 1].ChildCardData;
					break;
				}
			}
			if (cardData != null)
			{
				base.ShowMe();
				cardData.wATK += cardData.ATK;
			}
		}
		yield break;
	}
}
