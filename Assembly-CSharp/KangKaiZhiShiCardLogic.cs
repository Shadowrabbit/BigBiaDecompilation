using System;
using System.Collections;
using System.Collections.Generic;

public class KangKaiZhiShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_悲歌");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_悲歌");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_悲歌");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_悲歌");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			if (allCurrentMonsters.Count <= 0)
			{
				yield break;
			}
			base.ShowMe();
			Dictionary<CardData, int> dictionary = new Dictionary<CardData, int>();
			foreach (CardData cardData in allCurrentMonsters)
			{
				cardData.MaxHP += 5;
				dictionary.Add(cardData, 5);
			}
			yield return base.AOE(dictionary, this.CardData, false, 0, true);
		}
		yield break;
	}
}
