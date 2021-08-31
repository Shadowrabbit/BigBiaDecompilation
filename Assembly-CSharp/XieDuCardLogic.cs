using System;
using System.Collections;

public class XieDuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_麻痹");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_麻痹");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_麻痹");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_麻痹");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		mergeBy.CurrentCardSlotData.SlotType = CardSlotData.Type.Freeze;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			if (base.Layers == 1)
			{
				this.CardData.CurrentCardSlotData.SlotType = CardSlotData.Type.Normal;
				this.CardData.CardLogics.Remove(this);
				this.CardData.CardLogicClassNames.Remove("XieDuCardLogic");
				yield break;
			}
			int layers = base.Layers;
			base.Layers = layers - 1;
		}
		yield break;
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		base.Terminate(cardSlotData);
		cardSlotData.SlotType = CardSlotData.Type.Normal;
		yield break;
	}
}
