using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;

public class HumanToy : MonoBehaviour
{
	private void Start()
	{
		this.m_Animator = base.GetComponent<Animator>();
		this.HeadSlot.CardSlotData = new CardSlotData();
		this.HeadSlot.CardSlotData.SlotType = CardSlotData.Type.Freeze;
		this.HeadSlot.CardSlotData.IconIndex = 0;
		this.HeadSlot.CardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
		this.HeadSlot.CardSlotData.CardSlotGameObject = this.HeadSlot;
		this.InitWithCardData(CardData.CopyCardData(GameController.ins.CardDataModMap.getCardDataByModID("武道家"), true));
	}

	public void InitWithCardData(CardData cardData)
	{
		this.CardData = cardData;
		this.CardData.PutInSlotData(this.HeadSlot.CardSlotData, true);
	}

	public void ShowDialog(Subtitle sub)
	{
		DialogueDatabase defaultDatabase = DialogueManager.DatabaseManager.defaultDatabase;
		Debug.Log("进入对话");
		this.ConversationTextPanel.text = sub.formattedText.text;
	}

	public void ExecuteCommand(string Command)
	{
	}

	private void Update()
	{
	}

	private IEnumerator WaitForAnimationPlayOver(string triggerName)
	{
		this.m_isPlaying = true;
		this.m_Animator.SetTrigger(triggerName);
		Debug.Log(triggerName + "  " + this.m_Animator.GetCurrentAnimatorStateInfo(0).length.ToString() + 0.2f.ToString());
		yield return new WaitForSeconds(this.m_Animator.GetCurrentAnimatorStateInfo(0).length + 0.2f);
		this.m_isPlaying = false;
		yield break;
	}

	public CardData CardData;

	public CardSlot HeadSlot;

	public string CharacterName;

	public TextMeshProUGUI NameTextPanel;

	public TextMeshProUGUI ConversationTextPanel;

	private Animator m_Animator;

	private List<string> testTrigger = new List<string>
	{
		"zoulu",
		"chongci",
		"yizima",
		"kongfan",
		"fangun",
		"gongji",
		"feichuai",
		"maren",
		"shanbi"
	};

	private bool m_isPlaying;
}
