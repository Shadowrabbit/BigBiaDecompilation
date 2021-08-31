using System;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class XuRuoLogic : FaithCardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_虚弱");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_虚弱");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_虚弱");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_虚弱2") + this.m_Count.ToString();
	}

	public override IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
	{
		if (originCarddata == this.CardData)
		{
			this.m_Count--;
			yield return base.Cure(this.CardData, Mathf.CeilToInt((float)(this.CardData.MaxHP / 3)), this.CardData);
			this.CardData._ATK += 2;
			string name = "Effect/HealATK";
			ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = this.CardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_吸血鬼1"));
			if (this.m_Count == 0)
			{
				JournalsConversationManager.PutJournals(new JournalsBean
				{
					FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_吸血鬼3"),
					Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + "·" + this.CardData.PersonName
				});
				JournalsConversationManager.role1 = this.CardData;
				JournalsConversation journalsConversation = new JournalsConversation();
				journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_吸血鬼7"), SpecialEventController.instance.StartConversation("吸血鬼的请求")));
				yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation);
				int asInt = DialogueLua.GetVariable("XiXueGui").asInt;
				if (asInt != 0)
				{
					if (asInt == 1)
					{
						JournalsConversationManager.PutJournals(new JournalsBean
						{
							FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_吸血鬼5"),
							Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + "·" + this.CardData.PersonName
						});
						this.AddLogic("XiXueGuiLogic");
						this.CardData.RemoveCardLogic(this);
					}
				}
				else
				{
					JournalsConversationManager.PutJournals(new JournalsBean
					{
						FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_吸血鬼4"),
						Origin = LocalizationMgr.Instance.GetLocalizationWord(this.CardData.Name) + "·" + this.CardData.PersonName
					});
					journalsConversation = new JournalsConversation();
					journalsConversation.Add(new JournalsConversationContent(1, LocalizationMgr.Instance.GetLocalizationWord("DH_吸血鬼8"), null));
					yield return DungeonOperationMgr.Instance.RunJournalsConversation(journalsConversation);
					this.CardData.DeleteCardData();
				}
			}
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
