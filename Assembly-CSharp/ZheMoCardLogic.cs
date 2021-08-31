using System;
using System.Collections;
using System.Collections.Generic;

public class ZheMoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_克总11");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_克总11");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_克总11");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_克总11");
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		base.ShowLogic("fm'latgh");
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		if (allCurrentMinions.Count == 0)
		{
			yield break;
		}
		using (List<CardData>.Enumerator enumerator = allCurrentMinions.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardData cardData = enumerator.Current;
				int num = 0;
				if (base.GetLogic(cardData, typeof(Logic_FaFeng)) != null)
				{
					num++;
				}
				if (base.GetLogic(cardData, typeof(Logic_BuGaoXing)) != null)
				{
					num++;
				}
				if (base.GetLogic(cardData, typeof(Logic_ZiCan)) != null)
				{
					num++;
				}
				if (base.GetLogic(cardData, typeof(Logic_BuZhong)) != null)
				{
					num++;
				}
				if (num > 0)
				{
					base.Show(LocalizationMgr.Instance.GetLocalizationWord("T_呃啊"), cardData);
					cardData.AddAffix(DungeonAffix.frail, num);
					cardData.AddAffix(DungeonAffix.weak, num);
				}
			}
			yield break;
		}
		yield break;
	}
}
