using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class UnlockMinionAct : GameAct
{
	private void Start()
	{
		this.Init();
		GameController.getInstance().DialogueController.Actor = GameController.getInstance().PlayerToy;
		GameController.getInstance().DialogueController.Conversant = this.Source;
		GameController.getInstance().DialogueController.ConversantSlot = this.Source.CurrentCardSlot;
		GameController.getInstance().GameEventManager.OpenGameUI();
		DialogueLua.SetVariable("UnlockMinionModID", this.Source.CardData.ModID);
		DialogueLua.SetVariable("UnlockMinionPersonName", this.Source.CardData.PersonName);
		DialogueManager.StartConversation("解锁随从", base.transform, this.Source.CardData.CurrentCardSlotData.CardSlotGameObject.transform);
		GameController.getInstance().GameEventManager.StartTalking();
	}

	public void OnConversationEnd(Transform actor)
	{
		this.isDone = true;
	}

	private void Update()
	{
		if (this.isDone)
		{
			this.Source.CardData.DeleteCardData();
			DungeonOperationMgr.Instance.FlipAllFlopableCards();
			this.ActEnd();
		}
	}

	public override void ActEnd()
	{
		base.ActEnd();
		DialogueLua.SetVariable("UnlockMinionModID", string.Empty);
		DialogueLua.SetVariable("UnlockMinionPersonName", string.Empty);
	}

	private bool isDone;
}
