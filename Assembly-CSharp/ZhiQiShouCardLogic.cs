using System;
using System.Collections;

public class ZhiQiShouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("M_N_1");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("M_D_1");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("M_N_1");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("M_D_1");
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData)
		{
			CardData cardData = null;
			int num = GameController.getInstance().PlayerSlotSets.Count / 3;
			for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i++)
			{
				if (GameController.getInstance().PlayerSlotSets[i].ChildCardData == this.CardData && i + num < GameController.getInstance().PlayerSlotSets.Count && GameController.getInstance().PlayerSlotSets[i + num].ChildCardData != null && GameController.getInstance().PlayerSlotSets[i + num].ChildCardData.HasTag(TagMap.随从))
				{
					cardData = GameController.getInstance().PlayerSlotSets[i + num].ChildCardData;
					break;
				}
			}
			if (cardData != null)
			{
				base.ShowMe();
				cardData.IsAttacked = false;
			}
		}
		yield break;
	}
}
