using System;
using System.Collections;
using System.Collections.Generic;

public class MingYueZhiShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_皎月");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_皎月");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_皎月");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_皎月");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			if (allCurrentMinions.Count <= 0)
			{
				yield break;
			}
			base.ShowMe();
			using (List<CardData>.Enumerator enumerator = allCurrentMinions.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData = enumerator.Current;
					base.Show(LocalizationMgr.Instance.GetLocalizationWord("T_好诗"), cardData);
					cardData.AddAffix(DungeonAffix.weak, 2);
				}
				yield break;
			}
		}
		yield break;
	}
}
