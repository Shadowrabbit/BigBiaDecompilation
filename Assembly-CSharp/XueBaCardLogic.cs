using System;
using System.Collections;
using System.Collections.Generic;

public class XueBaCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_凡尔赛");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_凡尔赛");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_凡尔赛");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_凡尔赛");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			if (allCurrentMonsters.Count == 0)
			{
				yield break;
			}
			foreach (CardData cd in allCurrentMonsters)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cd))
				{
					if (base.GetLogic(cd, typeof(BanZhuRenCardLogic)) != null)
					{
						JournalsConversation journalsConversation = new JournalsConversation();
						JournalsConversationManager.role1 = this.CardData;
						JournalsConversationManager.role2 = cd;
						base.ShowMePlus(null);
						journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("T_这次成绩不太理想"), null));
						journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("T_听到没有"), null));
						yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation);
						yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, cd);
						cd._ATK += 2;
						yield break;
					}
					cd = null;
				}
			}
			List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
		}
		yield break;
		yield break;
	}
}
