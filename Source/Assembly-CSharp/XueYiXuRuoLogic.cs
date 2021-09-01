using System;
using System.Collections;
using UnityEngine;

public class XueYiXuRuoLogic : FaithCardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_血裔虚弱");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_血裔虚弱");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_血裔虚弱");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_血裔虚弱2"), this.m_Count);
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		if (this.CardData != null)
		{
			string name = "Effect/HealPoison";
			ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = this.CardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
			this.CardData.HP = 1;
		}
	}

	public override IEnumerator OnBattleEnd()
	{
		this.m_Count--;
		if (this.m_Count == 0)
		{
			JournalsConversationManager.role1 = this.CardData;
			JournalsConversation journalsConversation = new JournalsConversation();
			journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_吸血鬼9"), null));
			yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation);
			JournalsConversationManager.PutJournals(new JournalsBean
			{
				FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_吸血鬼6"),
				Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + "·" + this.CardData.PersonName
			});
			this.CardData.HP = ((this.CardData.HP < Mathf.CeilToInt((float)(this.CardData.MaxHP / 2))) ? Mathf.CeilToInt((float)(this.CardData.MaxHP / 2)) : this.CardData.HP);
			this.AddLogic("XueYiLogic");
			this.CardData.RemoveCardLogic(this);
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

	public int m_Count = 3;
}
