using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Logic_JieHun : TwoPeopleCardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_结婚");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_结婚");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_结婚");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_结婚");
	}

	public override IEnumerator OnMoveOnMap()
	{
		CardData target = base.GetCardByID(this.TargetID);
		if (this.CardData.ModID.Equals("流浪狗") || this.CardData == target)
		{
			yield break;
		}
		if (target != null)
		{
			this.m_Round--;
			if (this.m_Round <= 0 && !this.m_isHuaiYun)
			{
				bool flag = false;
				using (List<CardLogic>.Enumerator enumerator = target.CardLogics.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current is Logic_HuaiYun)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					foreach (CardLogic cardLogic in target.CardLogics)
					{
						if (cardLogic is Logic_JieHun)
						{
							((Logic_JieHun)cardLogic).m_isHuaiYun = true;
							break;
						}
					}
					JournalsConversationManager.role1 = this.CardData;
					JournalsConversationManager.role2 = target;
					JournalsConversation journalsConversation = new JournalsConversation();
					journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_结婚1"), null));
					journalsConversation.Add(new JournalsConversationContent(2, LocalizationMgr.Instance.GetLocalizationWord("DH_结婚2"), null));
					journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_结婚3"), null));
					yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation);
					Logic_HuaiYun logic_HuaiYun = new Logic_HuaiYun();
					logic_HuaiYun.TargetID = target.ID;
					logic_HuaiYun.Reason = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_爱的结晶"), LocalizationMgr.Instance.GetLocalizationWord(target.Name), target.PersonName);
					this.CardData.AddPersonLogic(logic_HuaiYun);
					this.m_isHuaiYun = true;
					JournalsConversationManager.PutJournals(new JournalsBean
					{
						FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_关系结婚2"),
						Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + "·" + this.CardData.PersonName,
						Target = LocalizationMgr.Instance.GetLocalizationWord(target.Name) + "·" + target.PersonName
					});
				}
			}
		}
		else
		{
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_丧偶"));
			Logic_BuGaoXing logic_BuGaoXing = new Logic_BuGaoXing();
			logic_BuGaoXing.ExistsRound = 3;
			logic_BuGaoXing.Reason = LocalizationMgr.Instance.GetLocalizationWord("T_失去结婚对象");
			this.CardData.AddPersonLogic(logic_BuGaoXing);
			JournalsConversationManager.PutJournals(new JournalsBean
			{
				FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_关系结婚1"),
				Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + "·" + this.CardData.PersonName,
				Target = ""
			});
			this.CardData.RemoveCardLogic(this);
		}
		yield break;
	}

	public override IEnumerator OnBattleEnd()
	{
		CardData target = base.GetCardByID(this.TargetID);
		if (target != null)
		{
			if (target == this.CardData)
			{
				yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_结婚1"));
				this.CardData.RemoveCardLogic(this);
				yield break;
			}
			ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/HellHpBall", 0.3f);
			particleObject.transform.position = target.CardGameObject.transform.position;
			yield return particleObject.transform.DOMove(this.CardData.CardGameObject.transform.position, 0.3f, false).WaitForCompletion();
			string name = "Effect/HealHp";
			ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = this.CardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, 3, target, false, 0, true, false);
		}
		yield break;
	}

	private void AddLogic(string logicName)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		cardLogic.CardData = this.CardData;
		this.CardData.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(this.CardData);
	}

	private int m_Round = 3;

	public bool m_isHuaiYun;
}
