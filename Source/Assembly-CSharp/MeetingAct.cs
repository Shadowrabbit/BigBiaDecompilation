using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetingAct : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<OKButton>().GameAct = this;
		this.OKButton = base.GetComponentInChildren<OKButton>();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		this.Missions = new List<Card>();
		this.personPoint = new List<int>();
		this.ParticipantOriginSlots = new List<CardSlot>();
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Act;
		cardSlotData.SlotType = CardSlotData.Type.Freeze;
		cardSlotData.SlotForward = CardSlotData.Forward.Back;
		CardSlotData data = CardSlotData.CopyCardSlotData(cardSlotData);
		this.PresidentSlot = CardSlot.InitCardSlot(data, 0.111f);
		this.PresidentSlot.transform.SetParent(base.transform, false);
		this.PresidentSlot.transform.position = this.PresidentSlotTrans.position;
		this.PresidentSlot.transform.Rotate(this.PresidentSlotTrans.rotation.eulerAngles);
		cardSlotData.SlotForward = CardSlotData.Forward.Right;
		base.InitCardSlotOnActTable(this.SlotTrans1, new Vector3(0f, 0f, -1.3f), 7, false, null, this.ParticipantSlots, cardSlotData);
		this.SlotTrans1.position += new Vector3(1.3f, 0f, 0f);
		base.InitCardSlotOnActTable(this.SlotTrans1, new Vector3(0f, 0f, -1.3f), 7, false, null, this.JudgeSlots, cardSlotData);
		cardSlotData.SlotForward = CardSlotData.Forward.Left;
		base.InitCardSlotOnActTable(this.SlotTrans2, new Vector3(0f, 0f, -1.3f), 7, false, null, this.ParticipantSlots, cardSlotData);
		this.SlotTrans2.position += new Vector3(-1.3f, 0f, 0f);
		base.InitCardSlotOnActTable(this.SlotTrans2, new Vector3(0f, 0f, -1.3f), 7, false, null, this.JudgeSlots, cardSlotData);
		this.MissionNames = new List<string>();
		this.MissionNames.Add("任务");
		this.MissionNames.Add("任务");
		this.MissionNames.Add("任务");
		base.InitCardSlotOnActTable(this.MissionSlotTrans, new Vector3(1.3f, 0f, 0f), 7, true, this.MissionNames, this.MissionSlots, null);
		foreach (CardSlot cardSlot in this.MissionSlots)
		{
			if (cardSlot.ChildCard != null)
			{
				this.Missions.Add(cardSlot.ChildCard);
			}
		}
		this.eventalOffset = new Vector3(0f, 6f, 4.5f);
		this.oppositeOffset = new Vector3(0f, 0f, 11.2f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
	}

	protected override IEnumerator ActStartAni(Vector3 eventalOffset, Vector3 oppositeOffset, int during)
	{
		yield return base.ActStartAni(eventalOffset, oppositeOffset, during);
		UIController.LockLevel = UIController.UILevel.All;
		this.PresidentOriginSlot = this.Source.CurrentCardSlot;
		base.StartCoroutine(GameAct.PutCardInSlotAni(this.Source, this.PresidentSlot, 1f));
		Party curParty = new Party();
		foreach (Party party in GameController.getInstance().GameData.Partys)
		{
			if (party.LeaderID == this.Source.CardData.ID)
			{
				curParty = party;
				break;
			}
		}
		Debug.Log("当前商会:" + curParty.Name);
		base.StartCoroutine(GameAct.PutCardInSlotAni(GameController.getInstance().PlayerToy, this.ParticipantSlots[0], 1f));
		if (GameController.getInstance().PlayerToy.CardData.Attrs.ContainsKey(CardAttrConstant.ReputationInPartys.Name))
		{
			this.personPoint.Add(Convert.ToInt32(GameController.getInstance().PlayerToy.CardData.Attrs[CardAttrConstant.ReputationInPartys.Name]));
		}
		else
		{
			this.personPoint.Add(0);
		}
		int i = 0;
		int num;
		while (i < this.ParticipantSlots.Count - 1 && i < curParty.PeopleIDs.Count)
		{
			if (GameController.getInstance().CardDataInWorldMap.ContainsKey(curParty.PeopleIDs[i]) && GameController.getInstance().CardDataInWorldMap[curParty.PeopleIDs[i]].CardGameObject != null)
			{
				Card cardGameObject = GameController.getInstance().CardDataInWorldMap[curParty.PeopleIDs[i]].CardGameObject;
				this.ParticipantOriginSlots.Add(cardGameObject.CurrentCardSlot);
				if (cardGameObject.CardData.Attrs.ContainsKey(CardAttrConstant.ReputationInPartys.Name))
				{
					this.personPoint.Add(Convert.ToInt32(cardGameObject.CardData.Attrs[CardAttrConstant.ReputationInPartys.Name]));
				}
				else
				{
					this.personPoint.Add(0);
				}
				yield return base.StartCoroutine(GameAct.PutCardInSlotAni(cardGameObject, this.ParticipantSlots[i + 1], 0.5f));
			}
			num = i;
			i = num + 1;
		}
		yield return base.StartCoroutine(GameController.getInstance().CameraMove(30f, this.CameraTrans.position, this.CameraTrans.rotation.eulerAngles, 1f));
		for (i = 0; i < this.Missions.Count; i = num + 1)
		{
			int num2 = -1;
			int num3 = 0;
			for (int j = 0; j < this.personPoint.Count; j++)
			{
				if (this.personPoint[j] > num2)
				{
					num2 = this.personPoint[j];
					num3 = j;
				}
			}
			if (this.ParticipantSlots[num3].ChildCard == null || num3 == 0)
			{
				break;
			}
			Debug.Log("该" + this.ParticipantSlots[num3].ChildCard.CardData.Name + "了");
			this.personPoint[num3] = -1;
			int index = UnityEngine.Random.Range(0, this.Missions.Count);
			yield return base.StartCoroutine(GameAct.PutCardInSlotAni(this.Missions[index], this.JudgeSlots[num3], 0.5f));
			num = i;
		}
		foreach (CardSlot cardSlot in this.MissionSlots)
		{
			cardSlot.CardSlotData.SlotType = CardSlotData.Type.Normal;
		}
		this.JudgeSlots[0].CardSlotData.SlotType = CardSlotData.Type.Normal;
		UIController.LockLevel = UIController.UILevel.AreaTable;
		Debug.Log("该你了");
		yield break;
	}

	public override void OnActOKButton()
	{
		base.OnActOKButton();
		base.StartCoroutine(this.ContinueAcceptMission());
	}

	private IEnumerator ContinueAcceptMission()
	{
		UIController.LockLevel = UIController.UILevel.All;
		this.personPoint[0] = -1;
		foreach (CardSlot cardSlot in this.MissionSlots)
		{
			cardSlot.CardSlotData.SlotType = CardSlotData.Type.Freeze;
		}
		this.JudgeSlots[0].CardSlotData.SlotType = CardSlotData.Type.Freeze;
		this.Missions = new List<Card>();
		foreach (CardSlot cardSlot2 in this.MissionSlots)
		{
			if (cardSlot2.ChildCard != null)
			{
				this.Missions.Add(cardSlot2.ChildCard);
			}
		}
		int num3;
		for (int i = 0; i < this.Missions.Count; i = num3 + 1)
		{
			int num = -1;
			int num2 = 0;
			for (int j = 0; j < this.personPoint.Count; j++)
			{
				if (this.personPoint[j] > num)
				{
					num = this.personPoint[j];
					num2 = j;
				}
			}
			if (this.ParticipantSlots[num2].ChildCard == null || num2 == 0)
			{
				break;
			}
			Debug.Log("该" + this.ParticipantSlots[num2].ChildCard.CardData.Name + "了");
			this.personPoint[num2] = -1;
			int index = UnityEngine.Random.Range(0, this.Missions.Count);
			yield return base.StartCoroutine(GameAct.PutCardInSlotAni(this.Missions[index], this.JudgeSlots[num2], 0.5f));
			num3 = i;
		}
		UIController.LockLevel = UIController.UILevel.AreaTable;
		yield break;
	}

	public override void OnActCancelButton()
	{
		base.StartCoroutine(this.ResetCards());
	}

	private IEnumerator ResetCards()
	{
		yield return base.StartCoroutine(GameController.getInstance().CameraMove(30f, GameController.getInstance().CameraTrans.position, GameController.getInstance().CameraTrans.rotation.eulerAngles, 2f));
		yield return base.StartCoroutine(GameAct.PutCardInSlotAni(GameController.getInstance().PlayerToy, GameController.getInstance().PlayerCardSlot, 1f));
		yield return base.StartCoroutine(GameAct.PutCardInSlotAni(this.Source, this.PresidentOriginSlot, 1f));
		int j;
		for (int i = 1; i < this.ParticipantSlots.Count; i = j + 1)
		{
			if (this.ParticipantSlots[i].ChildCard != null)
			{
				yield return base.StartCoroutine(GameAct.PutCardInSlotAni(this.ParticipantSlots[i].ChildCard, this.ParticipantOriginSlots[i - 1], 1f));
			}
			j = i;
		}
		if (this.JudgeSlots[0].ChildCard != null)
		{
			foreach (CardSlot cardSlot in GameController.getInstance().CardSlotsOnPlayerTable)
			{
				if (!(cardSlot == null) && cardSlot.ChildCard == null)
				{
					yield return base.StartCoroutine(GameAct.PutCardInSlotAni(this.JudgeSlots[0].ChildCard, cardSlot, 1f));
					break;
				}
			}
		}
		base.OnActCancelButton();
		yield break;
	}

	public Transform SlotTrans1;

	public Transform SlotTrans2;

	public Transform PresidentSlotTrans;

	public Transform MissionSlotTrans;

	public List<CardSlot> ParticipantSlots;

	public List<CardSlot> JudgeSlots;

	public CardSlot PresidentSlot;

	public List<CardSlot> MissionSlots;

	public List<string> MissionNames;

	public Transform CameraTrans;

	private List<Card> Missions;

	private List<int> personPoint;

	private CardSlot PresidentOriginSlot;

	private List<CardSlot> ParticipantOriginSlots;
}
