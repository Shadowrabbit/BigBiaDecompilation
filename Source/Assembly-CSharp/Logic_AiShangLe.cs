using System;
using System.Collections;
using System.Collections.Generic;

public class Logic_AiShangLe : TwoPeopleCardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_152");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_152");
	}

	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_152");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_152");
	}

	public override IEnumerator OnBattleEnd()
	{
		CardData target = base.GetCardByID(this.TargetID);
		if (target != null)
		{
			if (target == this.CardData)
			{
				yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_爱上1"));
				this.CardData.RemoveCardLogic(this);
				yield break;
			}
			bool flag = false;
			using (List<CardLogic>.Enumerator enumerator = this.CardData.CardLogics.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current is Logic_JieHun)
					{
						flag = true;
						break;
					}
				}
			}
			bool flag2 = false;
			using (List<CardLogic>.Enumerator enumerator = target.CardLogics.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current is Logic_JieHun)
					{
						flag2 = true;
						break;
					}
				}
			}
			if (this.CardData != target && !target.ModID.Equals("流浪狗") && !this.CardData.ModID.Equals("流浪狗") && !target.ModID.Equals("熊孩子") && !this.CardData.ModID.Equals("熊孩子") && !flag && !flag2)
			{
				foreach (CardLogic cardLogic in target.CardLogics)
				{
					if (cardLogic is Logic_AiShangLe || cardLogic is Logic_AnLian)
					{
						Logic_AiShangLe logic = (Logic_AiShangLe)cardLogic;
						if (logic.TargetID == this.CardData.ID)
						{
							JournalsConversationManager.role1 = this.CardData;
							JournalsConversationManager.role2 = target;
							JournalsConversation journalsConversation = new JournalsConversation();
							int num = SYNCRandom.Range(0, 2);
							if (num != 0)
							{
								if (num == 1)
								{
									journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_爱上了4"), null));
									journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_爱上了5"), null));
								}
							}
							else
							{
								journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_爱上了1"), null));
								journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_爱上了2"), null));
								journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_爱上了3"), null));
							}
							yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation);
							this.CardData.RemoveLogic(this);
							target.RemoveLogic(logic);
							Logic_JieHun logic_JieHun = new Logic_JieHun();
							logic_JieHun.TargetID = target.ID;
							logic_JieHun.Reason = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_情意相投"), LocalizationMgr.Instance.GetLocalizationWord(target.Name), target.PersonName);
							this.CardData.AddPersonLogic(logic_JieHun);
							target.AddPersonLogic(new Logic_JieHun
							{
								TargetID = this.CardData.ID,
								Reason = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_情意相投"), LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name), this.CardData.PersonName)
							});
							JournalsConversationManager.PutJournals(new JournalsBean
							{
								FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_爱上了"),
								Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + "·" + this.CardData.PersonName,
								Target = LocalizationMgr.Instance.GetLocalizationWord(target.Name) + "·" + target.PersonName
							});
							yield break;
						}
						logic = null;
					}
				}
				List<CardLogic>.Enumerator enumerator2 = default(List<CardLogic>.Enumerator);
			}
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_41"));
			this.CardData._ATK++;
		}
		else
		{
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_爱上2"));
			this.CardData.RemoveCardLogic(this);
		}
		yield break;
		yield break;
	}
}
