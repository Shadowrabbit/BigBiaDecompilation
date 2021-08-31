using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class GameAct : MonoBehaviour
{
	public virtual void Init()
	{
		UIController.LockLevel = UIController.UILevel.AreaTable;
		GameController.getInstance().GameEventManager.CurrentActStart();
		GameController.getInstance().CurrentAct = this;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public virtual void OnActOKButton()
	{
	}

	protected virtual IEnumerator ActStartAni(Vector3 eventalOffset, Vector3 oppositeOffset, int during)
	{
		this.m_Lock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.All;
		Vector3 eventalStartPos = GameController.getInstance().Evental.transform.position;
		Vector3 eventalEndPos = GameController.getInstance().Evental.transform.position + eventalOffset;
		Vector3 oppositeStartPos = GameController.getInstance().Opposite.transform.position;
		Vector3 oppositeEndPos = GameController.getInstance().Opposite.transform.position + oppositeOffset;
		Vector3 position = GameController.getInstance().Gear.transform.position;
		GameController.getInstance().Gear.transform.position + oppositeOffset;
		int num;
		for (int i = 1; i <= 20; i = num + 1)
		{
			GameController.getInstance().Evental.transform.position = Vector3.Lerp(eventalStartPos, eventalEndPos, (float)i / 20f);
			GameController.getInstance().Opposite.transform.position = Vector3.Lerp(oppositeStartPos, oppositeEndPos, (float)i / 20f);
			yield return new WaitForSeconds(0.025f);
			num = i;
		}
		UIController.LockLevel = this.m_Lock;
		yield break;
	}

	public static IEnumerator PutCardInSlotAni(Card card, CardSlot cardSlot, float timeScale)
	{
		UIController.LockLevel = UIController.UILevel.All;
		Sequence t = GameAct.PutCardInSlotAniSequence(card, cardSlot, timeScale);
		if (cardSlot.ChildCard == null)
		{
			Vector3 position = card.transform.position;
			card.PutInSlot(cardSlot);
			card.transform.position = position;
			yield return t.Play<Sequence>().WaitForCompletion();
		}
		else
		{
			yield return t.Play<Sequence>().WaitForCompletion();
			card.AddToSlot(cardSlot);
		}
		UIController.LockLevel = UIController.UILevel.AreaTable;
		yield break;
	}

	public static IEnumerator PutCardsInSlotsAni(List<Card> cards, List<CardSlot> slots, float timeScale)
	{
		UIController.LockLevel = UIController.UILevel.All;
		Sequence sequence = DOTween.Sequence();
		for (int i = 0; i < cards.Count; i++)
		{
			Sequence t = GameAct.PutCardInSlotAniSequence(cards[i], slots[i], timeScale);
			sequence.Join(t);
		}
		yield return sequence.Play<Sequence>().WaitForCompletion();
		for (int j = 0; j < cards.Count; j++)
		{
			cards[j].PutInSlot(slots[j]);
		}
		UIController.LockLevel = UIController.UILevel.AreaTable;
		yield break;
	}

	public static Sequence PutCardInSlotAniSequence(Card card, CardSlot cardSlot, float timeScale)
	{
		Sequence sequence = DOTween.Sequence();
		Transform transform = card.transform;
		sequence.Insert(0f, card.transform.DORotateQuaternion(Quaternion.LookRotation(cardSlot.transform.position - transform.position, Vector3.up), 0.2f * timeScale).SetEase(Ease.InQuad));
		sequence.Insert(0f, card.transform.DORotateQuaternion(Quaternion.AngleAxis(1f, Vector3.right), 0.2f * timeScale).SetEase(Ease.InQuad));
		sequence.Insert(0.2f * timeScale, card.transform.DOMove(cardSlot.transform.position, 0.5f * timeScale, false).SetEase(Ease.OutQuad));
		sequence.Insert(0.2f * timeScale, card.transform.DOMoveY(1f, 0.3f * timeScale, false).SetEase(Ease.OutQuad));
		sequence.Insert(0.5f * timeScale, card.transform.DOMoveY(0f, 0.2f * timeScale, false).SetEase(Ease.OutQuad));
		sequence.Append(card.transform.DORotateQuaternion(Quaternion.AngleAxis(0f, Vector3.up), 0.3f * timeScale).SetEase(Ease.InQuad));
		return sequence;
	}

	public static IEnumerator JumpCardInSlotAni(Card card, CardSlot cardSlot, float time)
	{
		UIController.LockLevel = UIController.UILevel.All;
		Sequence t = GameAct.JumpCardInSlotAniSequence(card, cardSlot, time);
		yield return t.Play<Sequence>().WaitForCompletion();
		card.PutInSlot(cardSlot);
		UIController.LockLevel = UIController.UILevel.AreaTable;
		yield break;
	}

	public static IEnumerator JumpCardsInSlotsAni(List<Card> cards, List<CardSlot> slots, float time)
	{
		UIController.LockLevel = UIController.UILevel.All;
		Sequence sequence = DOTween.Sequence();
		for (int i = 0; i < cards.Count; i++)
		{
			Sequence t = GameAct.JumpCardInSlotAniSequence(cards[i], slots[i], time);
			sequence.Join(t);
		}
		yield return sequence.Play<Sequence>().WaitForCompletion();
		for (int j = 0; j < cards.Count; j++)
		{
			cards[j].PutInSlot(slots[j]);
		}
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
	}

	public static Sequence JumpCardInSlotAniSequence(Card card, CardSlot cardSlot, float time)
	{
		DOTween.Sequence();
		return card.transform.DOJump(cardSlot.transform.position, 0.5f, 1, time, false);
	}

	protected IEnumerator EmissionEffect(CardData cardData, CardSlot cardSlot, int during)
	{
		yield return null;
		yield break;
	}

	protected IEnumerator rotateTableCor()
	{
		UIController.LockLevel = UIController.UILevel.All;
		int num;
		for (int i = 1; i <= 10; i = num + 1)
		{
			base.transform.rotation = Quaternion.AngleAxis(Mathf.Lerp(0f, 180f, (float)i / 10f), Vector3.left);
			yield return new WaitForSeconds(0.03f);
			num = i;
		}
		UIController.LockLevel = UIController.UILevel.AreaTable;
		yield break;
	}

	public virtual void OnActCancelButton()
	{
		if (((long)UIController.LockLevel & 4L) != 0L)
		{
			return;
		}
		if (this.EventEndAudio != null)
		{
			base.GetComponent<AudioSource>().clip = this.EventEndAudio;
			base.GetComponent<AudioSource>().Play();
		}
		UIController.LockLevel = UIController.UILevel.None;
		base.StartCoroutine(this.ActEndAni(this.eventalOffset, this.oppositeOffset, this.during));
	}

	public virtual void OnActFrontCancelButton()
	{
		if (this.EventEndAudio != null)
		{
			base.GetComponent<AudioSource>().clip = this.EventEndAudio;
			base.GetComponent<AudioSource>().Play();
		}
		base.StartCoroutine(this.ActEndAni(this.eventalOffset, this.oppositeOffset, this.during));
	}

	protected IEnumerator ActEndAni(Vector3 eventalOffset, Vector3 oppositeOffset, int during)
	{
		UIController.LockLevel = UIController.UILevel.All;
		Vector3 eventalStartPos = GameController.getInstance().Evental.transform.position;
		Vector3 eventalEndPos = GameController.getInstance().Evental.transform.position - eventalOffset;
		Vector3 oppositeStartPos = GameController.getInstance().Opposite.transform.position;
		Vector3 oppositeEndPos = GameController.getInstance().Opposite.transform.position - oppositeOffset;
		Vector3 position = GameController.getInstance().Gear.transform.position;
		GameController.getInstance().Gear.transform.position - oppositeOffset;
		int num;
		for (int i = 1; i <= during; i = num + 1)
		{
			GameController.getInstance().Evental.transform.position = Vector3.Lerp(eventalStartPos, eventalEndPos, (float)i / (float)during);
			GameController.getInstance().Opposite.transform.position = Vector3.Lerp(oppositeStartPos, oppositeEndPos, (float)i / (float)during);
			yield return new WaitForSeconds(0.002f);
			num = i;
		}
		this.ActEnd();
		yield break;
	}

	public virtual void ActEnd()
	{
		GameController.getInstance().GameEventManager.CurrentActEnd();
		UnityEngine.Object.DestroyImmediate(base.gameObject);
		if (GameController.getInstance().CurrentAct == this)
		{
			GameController.getInstance().CurrentAct = null;
		}
		UIController.LockLevel = UIController.UILevel.None;
		if (this.Source != null && this.Source.CardData != null && this.Source.CardData.CardLogics != null)
		{
			foreach (CardLogic cardLogic in this.Source.CardData.CardLogics)
			{
				cardLogic.OnActEnd();
			}
		}
		foreach (AreaLogic areaLogic in GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData.Logics)
		{
			areaLogic.OnActEnd();
		}
	}

	public virtual void OnActGetAllButton()
	{
	}

	public virtual IEnumerator ActGetAllAni(List<CardSlot> getAllSlots)
	{
		UIController.LockLevel = UIController.UILevel.All;
		List<Card> cards = new List<Card>();
		foreach (CardSlot cardSlot in getAllSlots)
		{
			if (cardSlot.ChildCard != null)
			{
				foreach (CardSlot cardSlot2 in GameController.getInstance().CardSlotsOnPlayerTable)
				{
					if (!(cardSlot2 == null) && (cardSlot2.ChildCard == null || (cardSlot2.ChildCard.CardData.ModID == cardSlot.ChildCard.CardData.ModID && cardSlot2.ChildCard.CardData.Count < cardSlot2.ChildCard.CardData.MaxCount)))
					{
						cards.Add(cardSlot.ChildCard);
						yield return base.StartCoroutine(GameAct.PutCardInSlotAni(cardSlot.ChildCard, cardSlot2, 0.2f));
						break;
					}
				}
			}
		}
		List<CardSlot>.Enumerator enumerator = default(List<CardSlot>.Enumerator);
		UIController.LockLevel = UIController.UILevel.AreaTable;
		yield break;
		yield break;
	}

	protected void InitCardSlotOnActTable(Transform trans, Vector3 delta, int num, bool withChildCard = false, List<string> childCardNames = null, List<CardSlot> csl = null, CardSlotData csd = null)
	{
		if (csl == null)
		{
			csl = new List<CardSlot>();
		}
		if (csd == null)
		{
			csd = new CardSlotData();
			csd.SlotOwnerType = CardSlotData.OwnerType.Act;
		}
		for (int i = 0; i < num; i++)
		{
			CardSlotData cardSlotData = CardSlotData.CopyCardSlotData(csd);
			if (withChildCard && i < childCardNames.Count)
			{
				CardData cardData = Card.InitCardDataByID(childCardNames[i]);
				if (cardData.HasTag(TagMap.随从) && DialogueLua.GetVariable("UnlockMinionPersonName").AsString != "")
				{
					cardData.PersonName = DialogueLua.GetVariable("UnlockMinionPersonName").asString;
				}
				cardData.PutInSlotData(cardSlotData, true);
			}
			CardSlot cardSlot = CardSlot.InitCardSlot(cardSlotData, 0.111f);
			cardSlot.transform.SetParent(base.transform, false);
			cardSlot.transform.position = trans.position + delta * (float)i;
			cardSlot.transform.Rotate(trans.rotation.eulerAngles);
			csl.Add(cardSlot);
		}
	}

	protected void InitCardSlotOnActTable(Transform trans, Vector3 delta, int num, List<Card> cl = null, List<CardSlot> csl = null, CardSlotData csd = null)
	{
		if (csl == null)
		{
			csl = new List<CardSlot>();
		}
		if (csd == null)
		{
			csd = new CardSlotData();
			csd.SlotOwnerType = CardSlotData.OwnerType.Act;
		}
		for (int i = 0; i < num; i++)
		{
			CardSlot cardSlot = CardSlot.InitCardSlot(CardSlotData.CopyCardSlotData(csd), 0.111f);
			cardSlot.transform.SetParent(base.transform, false);
			cardSlot.transform.position = trans.position + delta * (float)i;
			cardSlot.transform.Rotate(trans.rotation.eulerAngles);
			if (cl != null && i < cl.Count)
			{
				cl[i].PutInSlot(cardSlot);
			}
			csl.Add(cardSlot);
		}
	}

	protected void InitCardSlotOnActTable(Transform trans, int num, List<CardSlot> csl = null, CardSlotData csd = null)
	{
		if (csl == null)
		{
			csl = new List<CardSlot>();
		}
		if (csd == null)
		{
			csd = new CardSlotData();
			csd.SlotOwnerType = CardSlotData.OwnerType.Act;
			csd.TagWhiteList = 1073741824UL;
		}
		Vector3 a = new Vector3(1.2f, 0f, 0f);
		for (int i = 0; i < num; i++)
		{
			CardSlot cardSlot = CardSlot.InitCardSlot(CardSlotData.CopyCardSlotData(csd), 0.111f);
			cardSlot.transform.SetParent(base.transform, false);
			cardSlot.transform.position = trans.position + a * (float)i;
			cardSlot.transform.Rotate(trans.rotation.eulerAngles);
			cardSlot.SetIcon(3);
			csl.Add(cardSlot);
		}
	}

	protected void SetAllButton(bool enable)
	{
		if (this.OKButton != null)
		{
			this.OKButton.Enable = enable;
		}
		if (this.CancelButton != null)
		{
			this.CancelButton.Enable = enable;
		}
		if (this.GetAllButton != null)
		{
			this.GetAllButton.Enable = enable;
		}
		if (this.FrontCancelButton != null)
		{
			this.FrontCancelButton.Enable = enable;
		}
	}

	protected void SetFrontEnable()
	{
		if (this.OKButton != null)
		{
			this.OKButton.Enable = true;
		}
		if (this.CancelButton != null)
		{
			this.CancelButton.Enable = false;
		}
		if (this.GetAllButton != null)
		{
			this.GetAllButton.Enable = false;
		}
		if (this.FrontCancelButton != null)
		{
			this.FrontCancelButton.Enable = true;
		}
	}

	protected void SetBackEnable()
	{
		if (this.OKButton != null)
		{
			this.OKButton.Enable = false;
		}
		if (this.CancelButton != null)
		{
			this.CancelButton.Enable = true;
		}
		if (this.GetAllButton != null)
		{
			this.GetAllButton.Enable = true;
		}
		if (this.FrontCancelButton != null)
		{
			this.FrontCancelButton.Enable = false;
		}
	}

	public virtual void OnRefreshButton()
	{
	}

	public virtual void OnUpgradeButton()
	{
	}

	public ActData ActData;

	public Card Source;

	public OKButton OKButton;

	public CancelButton CancelButton;

	public FrontCancelButton FrontCancelButton;

	public GetAllButton GetAllButton;

	public RefreshButton RefreshButton;

	public UpgradeButton UpgradeButton;

	public AudioClip EventEndAudio;

	protected Vector3 eventalOffset;

	protected Vector3 oppositeOffset;

	protected int during;

	private UIController.UILevel m_Lock = UIController.UILevel.All;
}
