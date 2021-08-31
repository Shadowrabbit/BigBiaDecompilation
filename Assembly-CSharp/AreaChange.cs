using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class AreaChange : MonoBehaviour
{
	private void Start()
	{
		GameController.getInstance().GameEventManager.OnCurrentActStartEvent += this.StartAct;
		GameController.getInstance().GameEventManager.OnCurrentActEndEvent += this.EndAct;
		this.StartWorldMove();
	}

	public void StartWorldMove()
	{
		this.currentActsSlots = new List<CardSlot>();
		for (int i = 0; i < this.CardCount; i++)
		{
			CardSlot cardSlot = CardSlot.InitCardSlot(new CardSlotData
			{
				SlotOwnerType = CardSlotData.OwnerType.Area,
				SlotType = CardSlotData.Type.Freeze
			}, 0.111f);
			cardSlot.transform.SetParent(base.transform.parent.transform.parent, false);
			cardSlot.transform.position = this.SlotsTrans.position + new Vector3(1.3f * (float)i, 0f, 0f);
			this.currentActsSlots.Add(cardSlot);
		}
		base.StartCoroutine(this.StartJudge());
	}

	private IEnumerator StartJudge()
	{
		yield return new WaitForSeconds(2f);
		foreach (CardSlot cs in this.currentActsSlots)
		{
			int index = UnityEngine.Random.Range(0, this.TriggerableActs.Count);
			UIController.LockLevel = UIController.UILevel.PlayerSlot;
			Debug.Log(this.TriggerableActs[index]);
			yield return base.StartCoroutine(GameController.getInstance().RotateCardAnimate(cs, this.TriggerableActs[index]));
			UIController.LockLevel = UIController.UILevel.None;
			this.currentCard = cs.ChildCard;
			this.StartConversation();
			yield return new WaitForSeconds(0.2f);
			while (!this.readyForNext)
			{
				yield return null;
			}
			cs = null;
		}
		List<CardSlot>.Enumerator enumerator = default(List<CardSlot>.Enumerator);
		GameController.getInstance().CurrentCityID = this.NextAreaDataID;
		GameController.getInstance().OnTableChange(GameController.getInstance().GameData.AreaMap[this.NextAreaDataID], true);
		yield break;
		yield break;
	}

	public void OnConversationEnd(Transform actor)
	{
		Time.timeScale = 1f;
		Debug.Log(string.Format("Ending conversation with {0}", actor.name));
		if (GameController.getInstance().CurrentAct != null)
		{
			this.readyForNext = false;
			return;
		}
		this.readyForNext = true;
	}

	private void Update()
	{
	}

	private void StartAct()
	{
	}

	private void EndAct()
	{
		if (this.currentCard.CardData.HasConversation() && this.currentCard.CardData.GetBoolAttr(Constant.CardAttributeName.ContinueConversation))
		{
			this.StartConversation();
			return;
		}
		this.readyForNext = true;
	}

	private void OnDestroy()
	{
		GameController.getInstance().GameEventManager.OnCurrentActStartEvent -= this.StartAct;
		GameController.getInstance().GameEventManager.OnCurrentActEndEvent -= this.EndAct;
	}

	public void SetNextAreaDataID(string areaDataID)
	{
		this.NextAreaDataID = areaDataID;
	}

	private void StartConversation()
	{
		Time.timeScale = 0f;
		GameController.getInstance().DialogueController.Actor = GameController.getInstance().PlayerToy;
		GameController.getInstance().DialogueController.Conversant = this.currentCard;
		GameController.getInstance().GameEventManager.OpenGameUI();
		DialogueManager.StartConversation(this.currentCard.CardData.ModID, GameController.getInstance().GetComponent<Transform>(), base.GetComponent<Transform>());
	}

	public int CardCount;

	public string NextAreaDataID;

	public Transform SlotsTrans;

	public List<string> TriggerableActs;

	private List<CardSlot> currentActsSlots;

	private Card currentCard;

	private bool readyForNext = true;
}
