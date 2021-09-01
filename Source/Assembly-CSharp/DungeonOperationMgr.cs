using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class DungeonOperationMgr : MonoBehaviour
{
	public void AddRandomJournalsProcess(IEnumerator process)
	{
		this.RandomJournalsProcessList.Add(process);
	}

	public static DungeonOperationMgr Instance
	{
		get
		{
			return DungeonOperationMgr.m_Instance;
		}
	}

	public bool IsOperationLocked { get; private set; }

	private CardData m_PlayerCardData
	{
		get
		{
			return GameController.getInstance().GameData.PlayerCardData;
		}
	}

	private void Awake()
	{
		DungeonOperationMgr.m_Instance = this;
	}

	private void Start()
	{
		this.ProccesBatchQueue = new Queue<IEnumerator>();
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Combine(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.OnCardPutInSlot));
		this.PlayerBattleArea = new List<CardSlotData>();
		int num = GameController.getInstance().PlayerSlotSets.Count / 3;
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i++)
		{
			if (i % num < 3)
			{
				this.PlayerBattleArea.Add(GameController.getInstance().PlayerSlotSets[i]);
			}
		}
		if (GlobalController.Instance.AdvanceDataController.GetShangDianDaZhe())
		{
			this.MoneyRate = 0.9f;
		}
	}

	private void Update()
	{
		if (this.ProccesBatchQueue.Count > 0 && !this.isProcces)
		{
			base.StartCoroutine(this.StartProcess());
		}
	}

	private void OnDestroy()
	{
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.OnCardPutInSlot));
	}

	private IEnumerator StartProcess()
	{
		this.isProcces = true;
		while (this.ProccesBatchQueue.Count > 0)
		{
			yield return base.StartCoroutine(this.ProccesBatchQueue.Dequeue());
		}
		this.isProcces = false;
		yield break;
	}

	public IEnumerator StartBattle(bool isEventBattle = false)
	{
		this.IsEventBattle = isEventBattle;
		this.BattleTurn = 1;
		if (this.IsEventBattle)
		{
			this.GainsYellowPointInEventBattle = 0;
			this.GainsRedPointInEventBattle = 0;
			this.GainsBluePointInEventBattle = 0;
		}
		UIController.LockLevel = UIController.UILevel.All;
		Camera.main.GetComponent<CameraEffect>().NameText.text = "战斗开始";
		Camera.main.GetComponent<CameraEffect>().DescText.text = "Battle Start";
		Camera.main.GetComponent<CameraEffect>().CameraUI.GetComponent<Animator>().SetTrigger("play");
		yield return new WaitForSeconds(0.5f);
		this.IsInBattle = true;
		int num;
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num + 1)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
				{
					CardLogic cardLogic = slotCardData.CardLogics[i2];
					if (slotCardData.DizzyLayer <= 0 && (cardLogic.Color >= CardLogicColor.white || cardLogic.Color == (CardLogicColor)cardLogic.CardData.CurrentCardSlotData.Color) && cardLogic.GetType().GetMethod("OnBattleStart").DeclaringType == cardLogic.GetType())
					{
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic.OnBattleStart());
						yield return routine.coroutine;
						try
						{
							int result = routine.Result;
						}
						catch (Exception ex)
						{
							Debug.LogError(ex.Message);
							Debug.LogError(ex.StackTrace);
						}
						routine = null;
					}
					num = i2;
				}
				slotCardData = null;
			}
			num = i;
		}
		List<CardSlotData> cardSlotDatas = GameController.ins.GameData.AreaMap[GameController.ins.GameData.CurrentAreaId].CardSlotDatas;
		foreach (CardSlotData cardSlotData in cardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.DizzyLayer <= 0)
			{
				CardData slotCardData = cardSlotData.ChildCardData;
				for (int i = slotCardData.CardLogics.Count - 1; i >= 0; i = num - 1)
				{
					if (slotCardData.CardLogics[i].GetType().GetMethod("OnBattleStart").DeclaringType == slotCardData.CardLogics[i].GetType())
					{
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(slotCardData.CardLogics[i].OnBattleStart());
						yield return routine.coroutine;
						try
						{
							int result2 = routine.Result;
						}
						catch (Exception ex2)
						{
							Debug.LogError(ex2.Message);
							Debug.LogError(ex2.StackTrace);
						}
						routine = null;
					}
					num = i;
				}
				slotCardData = null;
			}
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		foreach (CardSlotData cardSlotData2 in DungeonOperationMgr.Instance.BattleArea)
		{
			cardSlotData2.TagWhiteList = 8589934592UL;
			cardSlotData2.SlotType = CardSlotData.Type.OnlyPut;
		}
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
		yield break;
	}

	public void AddProcess(IEnumerator process)
	{
		this.ProccesBatchQueue.Enqueue(process);
	}

	public void ChangeCardExp(CardData cardData, int DeltaValue)
	{
		this.AddProcess(this.ChangeCardExpProcess(cardData, DeltaValue));
	}

	private IEnumerator ChangeCardExpProcess(CardData cardData, int DeltaValue)
	{
		yield return null;
		yield break;
	}

	public void ChangeCardHp(CardData cardData, int DeltaValue)
	{
		this.AddProcess(this.ChangeCardHpProcess(cardData, DeltaValue));
	}

	private IEnumerator ChangeCardHpProcess(CardData cardData, int DeltaValue)
	{
		yield return null;
		yield break;
	}

	public void ChangeMoney(int DeltaValue)
	{
		GameController.getInstance().StartCoroutine(this.DungeonHandler.ChangeMoney(DeltaValue));
	}

	private IEnumerator ChangeMoneyProcess(int DeltaValue)
	{
		GameController.getInstance().GameData.Money += DeltaValue;
		yield return null;
		yield break;
	}

	public void FlipAllFlopableCards()
	{
	}

	public void FlipAllFlopableCardsOnTurnEnd()
	{
	}

	public IEnumerator test(CardSlotData targetCardSlotData)
	{
		GridIndicate.Instance.HideGird();
		if (!(GameController.ins.GameData.AreaMap[GameController.ins.GameData.CurrentAreaId] is SpaceAreaData))
		{
			yield break;
		}
		List<CardData> cardDataList = new List<CardData>();
		this.CurrentPositionInMap = targetCardSlotData;
		yield return this.ChessmanJumpAndShowSlot(false, true, null);
		cardDataList.Add(DungeonOperationMgr.Instance.CurrentPositionInMap.ChildCardData);
		yield return DungeonController.Instance.GetAndPickTheFlipedCards(cardDataList, true);
		yield break;
	}

	public IEnumerator ChessmanJumpAndShowSlot(bool isBackward = false, bool callOnMoveOnMap = false, CardSlotData cardSlotData = null)
	{
		UIController.LockLevel = (UIController.UILevel.PlayerSlot | UIController.UILevel.AreaTable);
		if (callOnMoveOnMap)
		{
			yield return this.OnMoveOnMap(isBackward);
		}
		if (!DungeonController.Instance.Chessman.gameObject.activeInHierarchy)
		{
			DungeonController.Instance.Chessman.gameObject.SetActive(true);
			DungeonController.Instance.Chessman.SetParent(this.CurrentPositionInMap.CardSlotGameObject.transform.parent);
			DungeonController.Instance.Chessman.localPosition = this.CurrentPositionInMap.CardSlotGameObject.transform.localPosition;
		}
		GridIndicate.Instance.HideGird();
		if (this.CurrentPositionInMap.ChildCardData == null)
		{
			yield return DungeonController.Instance.Chessman.DOLocalJump(this.CurrentPositionInMap.CardSlotGameObject.transform.localPosition, 1f, 1, 0.5f, false).WaitForCompletion();
		}
		else
		{
			yield return DungeonController.Instance.Chessman.DOLocalJump(this.CurrentPositionInMap.CardSlotGameObject.transform.localPosition + Vector3.up * 0.2f, 1f, 1, 0.5f, false).WaitForCompletion();
		}
		GameController.ins.GetCurrentAreaData().ChessmanPosition = GameController.ins.GetCurrentAreaData().CardSlotDatas.FindIndex((CardSlotData a) => a == DungeonOperationMgr.Instance.CurrentPositionInMap);
		foreach (CardSlotData cardSlotData2 in GameController.getInstance().GameData.AreaMap[GameController.ins.GameData.CurrentAreaId].CardSlotDatas)
		{
			cardSlotData2.CanClick = false;
		}
		this.ShowGrids();
		yield return this.EndTurnProcess(true);
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
	}

	public void ShowGrids()
	{
		List<Vector3Int> list = new List<Vector3Int>();
		List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[GameController.ins.GameData.CurrentAreaId].CardSlotDatas;
		foreach (Vector2Int vector2Int in DungeonOperationMgr.Default4Coordinates)
		{
			Dictionary<string, AreaData> areaMap = GameController.getInstance().GameData.AreaMap;
			SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.ins.GameData.CurrentAreaId] as SpaceAreaData;
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(this.CurrentPositionInMap.GridPositionX, this.CurrentPositionInMap.GridPositionY, vector2Int.x, vector2Int.y, false);
			if (ralitiveCardSlotData != null)
			{
				if (ralitiveCardSlotData.ChildCardData == null && spaceAreaData.GridOpenState[cardSlotDatas.IndexOf(ralitiveCardSlotData)] > 0)
				{
					ralitiveCardSlotData.CanClick = true;
					list.Add(new Vector3Int(ralitiveCardSlotData.GridPositionX - this.CurrentPositionInMap.GridPositionX, ralitiveCardSlotData.GridPositionY - this.CurrentPositionInMap.GridPositionY, 0));
				}
				else if (ralitiveCardSlotData.ChildCardData != null && ralitiveCardSlotData.ChildCardData.HasTag(TagMap.地下城入口))
				{
					ralitiveCardSlotData.CanClick = true;
					list.Add(new Vector3Int(ralitiveCardSlotData.GridPositionX - this.CurrentPositionInMap.GridPositionX, ralitiveCardSlotData.GridPositionY - this.CurrentPositionInMap.GridPositionY, 0));
				}
				else if (ralitiveCardSlotData.ChildCardData != null && ralitiveCardSlotData.ChildCardData.ModID.Equals("门"))
				{
					ralitiveCardSlotData.CanClick = true;
					list.Add(new Vector3Int(ralitiveCardSlotData.GridPositionX - this.CurrentPositionInMap.GridPositionX, ralitiveCardSlotData.GridPositionY - this.CurrentPositionInMap.GridPositionY, 0));
				}
				else if (ralitiveCardSlotData.ChildCardData != null && this.CanFlip(ralitiveCardSlotData.ChildCardData))
				{
					list.Add(new Vector3Int(ralitiveCardSlotData.GridPositionX - this.CurrentPositionInMap.GridPositionX, ralitiveCardSlotData.GridPositionY - this.CurrentPositionInMap.GridPositionY, 0));
				}
			}
		}
		GridIndicate.Instance.ShowGird(this.CurrentPositionInMap.CardSlotGameObject.transform.position, list, 1f, false);
	}

	public IEnumerator RunJournalsConversation(JournalsConversation conversation)
	{
		foreach (JournalsConversationContent content in conversation)
		{
			CardData cardData;
			if (content.RoleNum == 1)
			{
				cardData = JournalsConversationManager.role1;
			}
			else if (content.RoleNum == 2)
			{
				cardData = JournalsConversationManager.role2;
			}
			else if (content.RoleNum == 3)
			{
				cardData = JournalsConversationManager.role3;
			}
			else
			{
				cardData = JournalsConversationManager.role4;
			}
			yield return cardData.CardLogics[0].ShowMePlus(content.Content);
			if (content.CallBackFunc != null)
			{
				yield return content.CallBackFunc;
			}
			content = null;
		}
		List<JournalsConversationContent>.Enumerator enumerator = default(List<JournalsConversationContent>.Enumerator);
		yield break;
		yield break;
	}

	public IEnumerator OnMoveOnMap(bool isBack = false)
	{
		if (GameController.ins.GameData.FaithData.RenNai < 3)
		{
			GameController.ins.GameData.TorchNum--;
			GameController.getInstance().ShowLogicChanged(DungeonController.Instance.Chessman.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_火把") + " -1", CardLogicColor.red);
		}
		List<CardSlotData>.Enumerator enumerator;
		if (GameController.ins.GameData.TorchNum < 0)
		{
			GameController.ins.GameData.TorchNum = 0;
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_30"), 1f, 3f, 1f, 1f);
			foreach (CardSlotData cardSlotData in GameController.ins.PlayerSlotSets)
			{
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
				{
					yield return this.DungeonHandler.ChangeHp(cardSlotData.ChildCardData, -Mathf.CeilToInt((float)cardSlotData.ChildCardData.MaxHP * 0.2f), null, false, 0, true, false);
				}
			}
			enumerator = default(List<CardSlotData>.Enumerator);
		}
		int num;
		foreach (CardSlotData csd in this.PlayerBattleArea)
		{
			if (csd.ChildCardData != null && csd.ChildCardData.CardLogics != null)
			{
				for (int i = csd.ChildCardData.CardLogics.Count - 1; i >= 0; i = num - 1)
				{
					if (csd.ChildCardData.CardLogics[i].ExistsRound > 0)
					{
						csd.ChildCardData.CardLogics[i].ExistsRound--;
						if (csd.ChildCardData.CardLogics[i].ExistsRound == 0)
						{
							yield return csd.ChildCardData.CardLogics[i].Terminate(csd);
							csd.ChildCardData.CardLogics.RemoveAt(i);
						}
					}
					num = i;
				}
			}
			csd = null;
		}
		enumerator = default(List<CardSlotData>.Enumerator);
		List<CardSlotData> csl = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
		int colnum = GameController.getInstance().PlayerSlotSets.Count / 3;
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num + 1)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				int myColNum = i / colnum;
				for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
				{
					CardLogic cardLogic = slotCardData.CardLogics[i2];
					if (slotCardData.DizzyLayer <= 0 && (cardLogic.Color >= CardLogicColor.white || cardLogic.Color == (CardLogicColor)myColNum))
					{
						if (slotCardData.CurrentCardSlotData == null || slotCardData.CardGameObject == null)
						{
							break;
						}
						if (cardLogic.GetType().GetMethod("OnMoveOnMap").DeclaringType == cardLogic.GetType())
						{
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic.OnMoveOnMap());
							yield return routine.coroutine;
							try
							{
								int result = routine.Result;
							}
							catch (Exception ex)
							{
								Debug.LogError(ex.Message);
								Debug.LogError(ex.StackTrace);
							}
							routine = null;
						}
					}
					num = i2;
				}
				slotCardData = null;
			}
			num = i;
		}
		foreach (CardSlotData cardSlotData2 in csl)
		{
			if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.DizzyLayer <= 0)
			{
				CardData slotCardData = cardSlotData2.ChildCardData;
				for (int i = slotCardData.CardLogics.Count - 1; i >= 0; i = num - 1)
				{
					if (slotCardData.CardLogics[i].GetType().GetMethod("OnMoveOnMap").DeclaringType == slotCardData.CardLogics[i].GetType())
					{
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(slotCardData.CardLogics[i].OnMoveOnMap());
						yield return routine.coroutine;
						try
						{
							int result2 = routine.Result;
						}
						catch (Exception ex2)
						{
							Debug.LogError(ex2.Message);
						}
						routine = null;
					}
					num = i;
				}
				slotCardData = null;
			}
		}
		enumerator = default(List<CardSlotData>.Enumerator);
		GameController.ins.GameData.EventStep++;
		GameController.ins.GameData.step++;
		GameController.ins.UIController.NeedEatTurnsText.text = "";
		List<CardData> list = new List<CardData>();
		if (GameController.ins.GameData.DungeonTheme == DungeonTheme.Arena)
		{
			yield break;
		}
		if (GameController.ins.GameData.step == 3)
		{
			foreach (CardData cardData in GameController.ins.CardDataModMap.Cards)
			{
				if (cardData.HasTag(TagMap.事件) && cardData.HasTag(TagMap.特殊))
				{
					list.Add(cardData);
				}
			}
			CardData cardData2 = list[SYNCRandom.Range(0, list.Count)];
			using (List<CardLogic>.Enumerator enumerator3 = cardData2.CardLogics.GetEnumerator())
			{
				if (enumerator3.MoveNext())
				{
					CardLogic cardLogic2 = enumerator3.Current;
					yield return cardLogic2.BeforeFact();
				}
			}
			List<CardLogic>.Enumerator enumerator3 = default(List<CardLogic>.Enumerator);
		}
		if (GameController.ins.GameData.EventStep >= GameData.MAX_EventStep)
		{
			DisplayModel wenhao = ModelPoolManager.Instance.SpawnModel("UI/问号");
			wenhao.GameObject.transform.localScale = Vector3.one;
			wenhao.GameObject.transform.position = DungeonController.Instance.Chessman.transform.position + Vector3.up;
			wenhao.GameObject.transform.rotation = Quaternion.Euler(63f, 0f, 0f);
			yield return wenhao.GameObject.transform.DOScale(Vector3.one * 5f, 0.5f).SetEase(Ease.InOutBack).WaitForCompletion();
			yield return wenhao.GameObject.transform.DOShakePosition(0.3f, 0.2f, 10, 90f, false, true).WaitForCompletion();
			yield return new WaitForSeconds(0.5f);
			yield return wenhao.GameObject.transform.DOScale(Vector3.one, 0.5f).WaitForCompletion();
			ModelPoolManager.Instance.UnSpawnModel(wenhao);
			List<CardData> allMinion = new List<CardData>();
			foreach (CardSlotData cardSlotData3 in this.PlayerBattleArea)
			{
				if (cardSlotData3.ChildCardData != null && cardSlotData3.ChildCardData.HasTag(TagMap.随从) && cardSlotData3.ChildCardData.ModID != "熊孩子")
				{
					allMinion.Add(cardSlotData3.ChildCardData);
				}
			}
			for (int j = 0; j < allMinion.Count; j++)
			{
				int index = SYNCRandom.Range(0, allMinion.Count);
				CardData value = allMinion[0];
				allMinion[0] = allMinion[index];
				allMinion[index] = value;
			}
			List<PersonEvent> allEvents = GameController.ins.AllPersonEvents;
			for (int k = 0; k < allMinion.Count; k++)
			{
				int index2 = SYNCRandom.Range(0, allEvents.Count);
				PersonEvent value2 = allEvents[0];
				allEvents[0] = allEvents[index2];
				allEvents[index2] = value2;
			}
			PersonEvent useEvent = null;
			for (int i = 0; i < allMinion.Count; i = num + 1)
			{
				int myColNum;
				for (myColNum = i + 1; myColNum < allMinion.Count; myColNum = num + 1)
				{
					int i2;
					for (i2 = 0; i2 < allEvents.Count; i2 = num + 1)
					{
						if ((allEvents[i2].Role1 & allMinion[i].CharactorTag) > (CharacterTag)0UL && (allEvents[i2].Role2 & allMinion[myColNum].CharactorTag) > (CharacterTag)0UL)
						{
							JournalsConversationManager.role1 = allMinion[i];
							JournalsConversationManager.role2 = allMinion[myColNum];
							yield return DungeonOperationMgr.Instance.RunJournalsConversation(allEvents[i2].JournalsConversations);
							if (allEvents[i2].Role1AddLogicName != null && this.CheckIsCanLove(allEvents[i2].Role1AddLogicName, allMinion[i], allMinion[myColNum].ID))
							{
								PersonCardLogic personCardLogic = Activator.CreateInstance(allEvents[i2].Role1AddLogicName) as PersonCardLogic;
								allMinion[i].CardLogics.Add(personCardLogic);
								personCardLogic.CardData = allMinion[i];
								if (personCardLogic is TwoPeopleCardLogic)
								{
									(personCardLogic as TwoPeopleCardLogic).TargetID = allMinion[myColNum].ID;
								}
								if (!string.IsNullOrEmpty(allEvents[i2].Role1Reason))
								{
									personCardLogic.Reason = allEvents[i2].Role1Reason;
								}
								personCardLogic.Init();
								personCardLogic.OnMerge(allMinion[i]);
							}
							if (allEvents[i2].Role2AddLogicName != null && this.CheckIsCanLove(allEvents[i2].Role2AddLogicName, allMinion[myColNum], allMinion[i].ID))
							{
								PersonCardLogic personCardLogic2 = Activator.CreateInstance(allEvents[i2].Role2AddLogicName) as PersonCardLogic;
								allMinion[myColNum].CardLogics.Add(personCardLogic2);
								personCardLogic2.CardData = allMinion[myColNum];
								if (personCardLogic2 is TwoPeopleCardLogic)
								{
									(personCardLogic2 as TwoPeopleCardLogic).TargetID = allMinion[i].ID;
								}
								if (!string.IsNullOrEmpty(allEvents[i2].Role2Reason))
								{
									personCardLogic2.Reason = allEvents[i2].Role2Reason;
								}
								personCardLogic2.Init();
								personCardLogic2.OnMerge(allMinion[i]);
							}
							JournalsConversationManager.PutJournals(new JournalsBean(allEvents[i2].JournalsBeanFormatString, LocalizationMgr.Instance.GetLocalizationWord(allMinion[myColNum].Name) + allMinion[myColNum].PersonName, LocalizationMgr.Instance.GetLocalizationWord(allMinion[i].Name) + allMinion[i].PersonName, null, null, null, null));
							useEvent = allEvents[i2];
							break;
						}
						num = i2;
					}
					if (i2 != allEvents.Count)
					{
						break;
					}
					num = myColNum;
				}
				if (myColNum != allMinion.Count)
				{
					break;
				}
				yield return null;
				num = i;
			}
			if (useEvent != null)
			{
				allEvents.Remove(useEvent);
			}
			GameData.MAX_EventStep = SYNCRandom.Range(4, 7);
			GameController.ins.GameData.EventStep = 0;
			wenhao = null;
			allMinion = null;
			allEvents = null;
			useEvent = null;
		}
		yield break;
		yield break;
	}

	public IEnumerator GoCamping()
	{
		foreach (CardSlotData cardSlotData in this.PlayerBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				yield return this.FindsFoodAndEat(cardSlotData.ChildCardData);
			}
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		yield return null;
		yield break;
		yield break;
	}

	public IEnumerator FindsFoodAndEat(CardData origin)
	{
		bool flag = false;
		foreach (CardSlotData csd in GameController.ins.GameData.SlotsOnPlayerTable)
		{
			if (csd.ChildCardData != null && csd.ChildCardData.HasTag(TagMap.食物) && csd.ChildCardData.Rare == origin.Rare)
			{
				if (csd.ChildCardData.Count > 1)
				{
					csd.ChildCardData.Count--;
					GameObject go = UnityEngine.Object.Instantiate<GameObject>(csd.ChildCardData.CardGameObject.DisplayGameObjectOnPlayerTable.GameObject);
					go.transform.position = csd.ChildCardData.CardGameObject.transform.position;
					yield return go.transform.DOJump(origin.CardGameObject.transform.position, 1f, 1, 0.5f, false).WaitForCompletion();
					UnityEngine.Object.DestroyImmediate(go);
					go = null;
				}
				else
				{
					yield return csd.ChildCardData.CardGameObject.transform.DOJump(origin.CardGameObject.transform.position, 1f, 1, 0.5f, false).WaitForCompletion();
					csd.ChildCardData.DeleteCardData();
				}
				flag = true;
				break;
			}
			csd = null;
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		if (flag)
		{
			GameController.getInstance().ShowLogicChanged(origin.CardGameObject.transform.position, "真香！", CardLogicColor.white);
		}
		else
		{
			origin.UnHappy += 10;
			if (origin.UnHappy > 100)
			{
				origin.UnHappy = 100;
			}
			GameController.getInstance().ShowLogicChanged(origin.CardGameObject.transform.position, "好饿啊！", CardLogicColor.white);
			yield return this.DungeonHandler.ChangeHp(origin, -Mathf.CeilToInt((float)origin.MaxHP / 10f), null, false, 0, true, false);
		}
		yield break;
		yield break;
	}

	public IEnumerator MonsterJumpToBattleArea(CardData origin, bool callEvent = true)
	{
		using (List<CardSlotData>.Enumerator enumerator = DungeonOperationMgr.Instance.BattleArea.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.ChildCardData == origin)
				{
					yield break;
				}
			}
		}
		List<int> AreaSlotData = new List<int>();
		for (int i = 0; i < this.BattleArea.Count; i++)
		{
			if (this.BattleArea[i] != null && this.BattleArea[i].ChildCardData == null)
			{
				AreaSlotData.Add(i);
			}
		}
		if (AreaSlotData.Count == 0)
		{
			origin.DizzyLayer++;
			yield break;
		}
		int idx = UnityEngine.Random.Range(0, AreaSlotData.Count);
		UnityEngine.Random.State tmp = UnityEngine.Random.state;
		yield return origin.CardGameObject.JumpToSlot(this.BattleArea[AreaSlotData[idx]].CardSlotGameObject, 0.3f, callEvent);
		UnityEngine.Random.state = tmp;
		origin.DizzyLayer = 0;
		origin.Attrs.Add("Col", AreaSlotData[idx] % 3);
		yield break;
	}

	public IEnumerator MonsterJumpToBattleAreaInWorld(CardData origin, int index, bool callEvent = true)
	{
		using (List<CardSlotData>.Enumerator enumerator = DungeonOperationMgr.Instance.BattleArea.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.ChildCardData == origin)
				{
					yield break;
				}
			}
		}
		yield return origin.CardGameObject.JumpToSlot(this.BattleArea[index].CardSlotGameObject, 0.3f, callEvent);
		origin.DizzyLayer = 0;
		origin.Attrs.Add("Col", index % 3);
		yield break;
	}

	public IEnumerator exeFlipedCardAct(List<CardData> actCard)
	{
		yield break;
	}

	public void FlipAll()
	{
		SpaceAreaData spaceAreaData = GameController.ins.GameData.AreaMap[GameController.ins.GameData.CurrentAreaId] as SpaceAreaData;
		if (spaceAreaData == null)
		{
			return;
		}
		foreach (CardSlotData cardSlotData in spaceAreaData.CardSlotDatas)
		{
			if (cardSlotData != null && cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.卡背))
			{
				this.Flip(cardSlotData.ChildCardData, false);
			}
		}
	}

	public bool CanFlip(CardData cardData)
	{
		if (cardData.CurrentAreaID == null)
		{
			return false;
		}
		if (!cardData.HasTag(TagMap.卡背))
		{
			return false;
		}
		foreach (Vector2Int vector2Int in DungeonOperationMgr.Default4Coordinates)
		{
			CardSlotData ralitiveCardSlotData = (GameController.getInstance().GameData.AreaMap[cardData.CurrentAreaID] as SpaceAreaData).GetRalitiveCardSlotData(cardData.CurrentCardSlotData.GridPositionX, cardData.CurrentCardSlotData.GridPositionY, vector2Int.x, vector2Int.y, false);
			if (ralitiveCardSlotData != null && ralitiveCardSlotData == this.CurrentPositionInMap)
			{
				return true;
			}
		}
		return false;
	}

	public void Flip(CardData backCardData, bool autoExecute = true)
	{
		if (!backCardData.HasTag(TagMap.卡背))
		{
			return;
		}
		string currentAreaID = backCardData.CurrentAreaID;
		CardSlot cardSlotGameObject = backCardData.CurrentCardSlotData.CardSlotGameObject;
		this.DisplayCardFlipAnim(cardSlotGameObject, autoExecute);
		GameController.ins.GameData.StepInDungeon++;
	}

	private void DisplayCardFlipAnim(CardSlot slot, bool autoExecute = true)
	{
		this.SetLockOperation(true);
		UIController.LockLevel = UIController.UILevel.All;
		slot.CardSlotData.MarkFlipState(true);
		Transform transform = slot.ChildCard.transform.Find("PotionIndicator");
		if (transform != null)
		{
			UnityEngine.Object.Destroy(transform.gameObject);
		}
		EffectAudioManager.Instance.PlayEffectAudio(13, null);
		base.StartCoroutine(this.FlipCardProcess(slot, autoExecute));
	}

	private IEnumerator FlipCardProcess(CardSlot slot, bool autoExecute = true)
	{
		GameController.GameSavingSyncLock = true;
		GameController.ins.SaveGame();
		yield return DOTween.Sequence().Append(slot.transform.DORotate(new Vector3(0f, 0f, 720f), 0.2f, RotateMode.FastBeyond360)).Insert(0f, slot.transform.DOMoveY(1.5f, 0.1f, false)).Insert(0.1f, slot.transform.DOMoveY(0f, 0.1f, false)).InsertCallback(0.1f, delegate
		{
			try
			{
				if (slot.CardSlotData.ChildCardData == null || !slot.CardSlotData.ChildCardData.HasAttr("CardModId"))
				{
					if (slot.CardSlotData.ChildCardData != null && !slot.CardSlotData.ChildCardData.HasAttr("CardModId"))
					{
						slot.CardSlotData.ChildCardData.DeleteCardData();
					}
					this.DeleteChainAnim(slot.CardSlotData);
				}
				else
				{
					CardData cardData = Card.InitCardDataByID(slot.CardSlotData.ChildCardData.Attrs["CardModId"].ToString());
					if (cardData.HasTag(TagMap.随从))
					{
						ActData actData = new ActData();
						actData.Name = "解锁随从";
						actData.Type = "Act/解锁随从";
						actData.Model = "ActTable/空";
						if (cardData.ActDatas == null)
						{
							cardData.ActDatas = new List<ActData>();
						}
						cardData.ActDatas.Add(actData);
					}
					slot.CardSlotData.ChildCardData.GetIntAttr("CardLevel");
					if (slot.CardSlotData.ChildCardData.Attrs.ContainsKey("Elite"))
					{
						cardData.Attrs.Add("Elite", "true");
					}
					if (!cardData.Attrs.ContainsKey("Theme"))
					{
						cardData.Attrs.Add("Theme", GameController.ins.GameData.DungeonTheme.ToString());
					}
					if (!cardData.Attrs.ContainsKey("EncounterType") && slot.CardSlotData.ChildCardData.Attrs.ContainsKey("EncounterType"))
					{
						cardData.Attrs.Add("EncounterType", slot.CardSlotData.ChildCardData.Attrs["EncounterType"]);
					}
					if (!cardData.Attrs.ContainsKey("EnemyCount") && slot.CardSlotData.ChildCardData.Attrs.ContainsKey("EnemyCount"))
					{
						cardData.Attrs.Add("EnemyCount", slot.CardSlotData.ChildCardData.Attrs["EnemyCount"]);
					}
					if (!cardData.Attrs.ContainsKey("EnemyDifficult") && slot.CardSlotData.Attrs.ContainsKey("EnemyDifficult"))
					{
						cardData.Attrs.Add("EnemyDifficult", Convert.ToInt32(slot.CardSlotData.Attrs["EnemyDifficult"]));
					}
					slot.CardSlotData.ChildCardData.DeleteCardData();
					cardData.PutInSlotData(slot.CardSlotData, true);
					if (cardData.HasTag(TagMap.怪物))
					{
						if (cardData.Attrs.ContainsKey("Elite"))
						{
							cardData.CardLogicClassNames.Add("EliteDropLogic");
							cardData.CardLogics.Add(new EliteDropLogic());
							cardData.CardLogics[cardData.CardLogics.Count - 1].Init();
						}
						cardData.DizzyLayer = 1;
					}
					else if (cardData == null)
					{
						this.DeleteChainAnim(cardData.CurrentCardSlotData);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.Message);
				Debug.LogError(ex.StackTrace);
			}
		}).OnComplete(delegate
		{
			this.SetLockOperation(false);
			if (autoExecute)
			{
				this.StartCoroutine(this.test(slot.CardSlotData));
			}
			if (slot.CardSlotData.ChildCardData != null)
			{
				slot.CardSlotData.ChildCardData.IsFlipAnimDone = true;
			}
			GameController.ins.GameEventManager.CardFlipAction(GameController.ins.GameData.AreaMap[GameController.ins.GameData.CurrentAreaId], slot.CardSlotData);
		}).WaitForCompletion();
		yield return null;
		yield break;
	}

	public CardData InitSceneMonster(CardData cd)
	{
		int num = GameController.ins.GameData.Agreenment - 1;
		int num2 = num * num;
		int atk = GameController.getInstance().CardDataModMap.getCardDataByModID(cd.ModID).ATK;
		int maxHP = GameController.getInstance().CardDataModMap.getCardDataByModID(cd.ModID).MaxHP;
		cd._ATK = Mathf.CeilToInt(((float)num2 * ((float)atk * DungeonOperationMgr.Instance.TotalDATK) + 0.1f * (float)num * (float)atk + (float)atk) * DungeonOperationMgr.Instance.TotalATK);
		cd.MaxHP = (cd.HP = Mathf.CeilToInt(((float)num2 * ((float)maxHP * DungeonOperationMgr.Instance.TotalDHp) + 0.15f * (float)num * (float)maxHP + (float)maxHP) * DungeonOperationMgr.Instance.TotalHp));
		return cd;
	}

	public CardData InitDungeonMonster(CardData cd, int enemyDifficult)
	{
		int num = enemyDifficult * enemyDifficult;
		int atk = GameController.getInstance().CardDataModMap.getCardDataByModID(cd.ModID).ATK;
		int maxHP = GameController.getInstance().CardDataModMap.getCardDataByModID(cd.ModID).MaxHP;
		float num2 = DungeonOperationMgr.Instance.TotalDHp;
		float num3 = DungeonOperationMgr.Instance.TotalDATK;
		if (GameController.ins.GameData.Agreenment >= 2)
		{
			num3 += 0.001f;
		}
		if (GameController.ins.GameData.Agreenment >= 3)
		{
			num2 += 0.002f;
		}
		if (GameController.ins.GameData.Agreenment >= 7 && cd.MaxArmor > 0 && !cd.HasTag(TagMap.BOSS))
		{
			cd.MaxArmor++;
			cd.Armor++;
		}
		if (GameController.ins.GameData.Agreenment >= 15)
		{
			num3 += 0.01f;
		}
		if (GameController.ins.GameData.Agreenment >= 16)
		{
			num3 += 0.02f;
		}
		cd._ATK = Mathf.RoundToInt(((float)num * ((float)atk * num3) + 0.03f * (float)enemyDifficult * (float)atk + (float)atk) * DungeonOperationMgr.Instance.TotalATK);
		cd.MaxHP = (cd.HP = Mathf.RoundToInt(((float)num * ((float)maxHP * num2) + 0.035f * (float)enemyDifficult * (float)maxHP + (float)maxHP) * DungeonOperationMgr.Instance.TotalHp));
		return cd;
	}

	public void SetEndlessMonster(CardData cd, int level)
	{
		int atk = GameController.getInstance().CardDataModMap.getCardDataByModID(cd.ModID).ATK;
		float datk = GameController.getInstance().CardDataModMap.getCardDataByModID(cd.ModID).DATK;
		int maxHP = GameController.getInstance().CardDataModMap.getCardDataByModID(cd.ModID).MaxHP;
		float dhp = GameController.getInstance().CardDataModMap.getCardDataByModID(cd.ModID).DHP;
		int armor = GameController.getInstance().CardDataModMap.getCardDataByModID(cd.ModID).Armor;
		float darmor = GameController.getInstance().CardDataModMap.getCardDataByModID(cd.ModID).DArmor;
		cd._ATK = Mathf.CeilToInt(((float)level * datk * this.EndlessTotalDATK * (float)(1 + level / 2) + (float)atk) * this.EndlessTotalATK);
		cd.MaxHP = (cd.HP = Mathf.CeilToInt(((float)level * dhp * this.EndlessTotalDHp * (float)(1 + level / 2) + (float)maxHP) * this.EndlessTotalHp));
		cd.MaxArmor = (cd.Armor = Mathf.CeilToInt(((float)level * darmor * this.EndlessTotalDArmor * (float)(1 + level / 2) + (float)armor) * this.EndlessTotalArmor));
	}

	public void SetMultPlayMonster(CardData monster, int enemyCount)
	{
		int num = GameController.ins.GameData.level - 1;
		int num2 = num + 1;
		int num3 = num2 * num2;
		int atk = GameController.getInstance().CardDataModMap.getCardDataByModID(monster.ModID).ATK;
		float datk = GameController.getInstance().CardDataModMap.getCardDataByModID(monster.ModID).DATK;
		int maxHP = GameController.getInstance().CardDataModMap.getCardDataByModID(monster.ModID).MaxHP;
		float dhp = GameController.getInstance().CardDataModMap.getCardDataByModID(monster.ModID).DHP;
		int armor = GameController.getInstance().CardDataModMap.getCardDataByModID(monster.ModID).Armor;
		float darmor = GameController.getInstance().CardDataModMap.getCardDataByModID(monster.ModID).DArmor;
		monster._ATK = Mathf.CeilToInt(((float)num3 * ((float)atk * DungeonOperationMgr.Instance.TotalDATK) + (float)atk * 0.15f * (float)num2 + (float)atk) * DungeonOperationMgr.Instance.TotalATK / (float)enemyCount);
		monster.MaxHP = (monster.HP = Mathf.CeilToInt(((float)num3 * ((float)maxHP * DungeonOperationMgr.Instance.TotalDHp) + (float)maxHP * 1.85f * (float)num2 + (float)maxHP) * DungeonOperationMgr.Instance.TotalHp / (float)enemyCount));
		monster.MaxArmor = (monster.Armor = ((armor > 0) ? (armor + num / 8) : 0));
		monster.Price = UnityEngine.Random.Range(Mathf.CeilToInt((float)(10 / enemyCount - 1)), Mathf.CeilToInt((float)(10 / enemyCount + 2))) * 2;
	}

	public void DeleteChainAnim(CardSlotData slotData)
	{
		foreach (Vector2Int vector2Int in DungeonOperationMgr.Default4Coordinates)
		{
			Dictionary<string, AreaData> areaMap = GameController.getInstance().GameData.AreaMap;
			SpaceAreaData spaceAreaData = slotData.CurrentAreaData as SpaceAreaData;
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(slotData.GridPositionX, slotData.GridPositionY, vector2Int.x, vector2Int.y, false);
			if (ralitiveCardSlotData != null && !ralitiveCardSlotData.IsFlipped)
			{
				CardData childCardData = ralitiveCardSlotData.ChildCardData;
				if (childCardData != null)
				{
					childCardData.CardGameObject.transform.Find("Locker");
				}
				bool flag = false;
				foreach (Vector2Int vector2Int2 in DungeonOperationMgr.Default4Coordinates)
				{
					CardSlotData ralitiveCardSlotData2 = spaceAreaData.GetRalitiveCardSlotData(ralitiveCardSlotData.GridPositionX, ralitiveCardSlotData.GridPositionY, vector2Int2.x, vector2Int2.y, false);
					if (ralitiveCardSlotData2 != null && ralitiveCardSlotData2.ChildCardData == null)
					{
						flag = true;
						break;
					}
				}
				if (flag && ralitiveCardSlotData.ChildCardData != null)
				{
					this.Flip(ralitiveCardSlotData.ChildCardData, true);
				}
			}
		}
	}

	public void AddChain(CardSlotData slotData)
	{
	}

	public void DeleteEnterNeighbourChain(CardSlotData slotData)
	{
	}

	private void HellPlayerEffectOnFliped(int hpNum, int mpNum, Transform flipedTrans, Transform playerTrans)
	{
		base.StartCoroutine(this.CallHellBallsAnim(hpNum, mpNum, flipedTrans, playerTrans));
	}

	private IEnumerator CallHellBallsAnim(int hpNum, int mpNum, Transform flipedTrans, Transform playerTrans)
	{
		int[] numArray = new int[hpNum + mpNum];
		for (int j = 0; j < hpNum + mpNum; j++)
		{
			if (j < hpNum)
			{
				numArray[j] = 0;
			}
			else
			{
				numArray[j] = 1;
			}
		}
		for (int k = 0; k < hpNum + mpNum; k++)
		{
			int num = UnityEngine.Random.Range(0, hpNum + mpNum);
			int num2 = numArray[num];
			numArray[num] = numArray[k];
			numArray[k] = num2;
		}
		int num4;
		for (int i = 0; i < hpNum + mpNum; i = num4 + 1)
		{
			int num3 = numArray[i];
			bool isLast = i == hpNum + mpNum - 1;
			this.CallHellBallAnim((num3 == 0) ? "Effect/HellHpBall" : "Effect/HellMpBall", flipedTrans, playerTrans, isLast);
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.01f, 0.02f));
			num4 = i;
		}
		yield break;
	}

	private void CallHellBallAnim(string prefabPath, Transform flipedTrans, Transform playerTrans, bool isLast = false)
	{
		List<Vector3> bezierListAndDrawBezier = Bezier.GetBezierListAndDrawBezier(flipedTrans, playerTrans, 10, 0.2f, UnityEngine.Random.Range(2f, 5f), false);
		bezierListAndDrawBezier.RemoveAt(0);
		float num = Vector3.Distance(flipedTrans.position, playerTrans.position);
		float duration = Mathf.Clamp(0.75f, num / 10f, 1.5f);
		ParticleObject particle = ParticlePoolManager.Instance.Spawn(prefabPath, float.MaxValue);
		Transform transform = particle.transform;
		transform.position = flipedTrans.position + new Vector3(UnityEngine.Random.Range(-0.2f, 0.2f), UnityEngine.Random.Range(0f, 0.2f), UnityEngine.Random.Range(-0.2f, 0.2f));
		transform.DOPath(bezierListAndDrawBezier.ToArray(), duration, PathType.CatmullRom, PathMode.Full3D, 10, null).SetEase(Ease.OutQuad).OnComplete(delegate
		{
			ParticlePoolManager.Instance.UnSpawn(particle);
			if (isLast)
			{
				this.CallSmallHellEffect(playerTrans);
				GameController.getInstance().playerTableText.PlayHpParticle();
				GameController.getInstance().playerTableText.PlayMpParticle();
			}
		});
	}

	private void CallSmallHellEffect(Transform playerTrans)
	{
		ParticlePoolManager.Instance.Spawn("Effect/SmallHell", 3f).transform.position = playerTrans.position;
	}

	public void OnLeftClicked(CardData playerCardData, CardData enemyCardData)
	{
		string currentAreaId = GameController.ins.GameData.CurrentAreaId;
		GameController.getInstance().GameEventManager.BeforeAttackAction(playerCardData, enemyCardData);
		List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[currentAreaId].CardSlotDatas;
		base.StartCoroutine(this.AttackProcess(playerCardData, enemyCardData, currentAreaId));
	}

	public IEnumerator AttackProcess(CardData originCardData, CardData targetCardData, string areaID)
	{
		List<CardSlotData> csl = GameController.getInstance().GameData.AreaMap[areaID].CardSlotDatas;
		int colnum = GameController.getInstance().PlayerSlotSets.Count / 3;
		if (this.CheckCardDead(targetCardData) || this.CheckCardDead(targetCardData))
		{
			yield break;
		}
		if (originCardData.CurrentCardSlotData != null)
		{
			originCardData.CardGameObject != null;
		}
		yield return GameController.ins.UIController.EnergyUI.AddEnergy((EnergyUI.EnergyType)originCardData.CurrentCardSlotData.Color, originCardData.CardGameObject.transform);
		CardSlotData targetSlotData = targetCardData.CurrentCardSlotData;
		this.SetLockOperation(true);
		UIController.LockLevel = UIController.UILevel.All;
		CardSlotData currentCardSlotData = targetCardData.CurrentCardSlotData;
		Coroutine<int> routine = GlobalController.Instance.StartCoroutine(this.Attack(originCardData, targetCardData, areaID));
		yield return routine.coroutine;
		try
		{
			int result = routine.Result;
		}
		catch (Exception ex)
		{
			Debug.LogError(ex.Message);
			Debug.LogError(ex.StackTrace);
		}
		try
		{
			if (!this.CheckCardDead(originCardData) && DungeonOperationMgr.Instance.IsInBattle)
			{
				originCardData.IsAttacked = true;
			}
			if (GameController.ins.PlayerToy != null)
			{
				GameController.ins.PlayerToy.DMGPanel.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f).onComplete = delegate()
				{
					GameController.ins.PlayerToy.DMGPanel.SetActive(false);
				};
			}
			GameController.ins.PlayerToy.DMGPanel.SetActive(false);
		}
		catch (Exception ex2)
		{
			Debug.LogError(ex2.Message);
			Debug.LogError(ex2.StackTrace);
		}
		int num;
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num + 1)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData carddata = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				if (carddata != null && carddata.CardGameObject != null)
				{
					carddata.CardGameObject.DMGPanel.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f).onComplete = delegate()
					{
						carddata.CardGameObject.DMGPanel.SetActive(false);
					};
				}
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				int myColNum = i / colnum;
				for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
				{
					CardLogic cardLogic = slotCardData.CardLogics[i2];
					if (slotCardData.DizzyLayer <= 0 && (cardLogic.Color >= CardLogicColor.white || cardLogic.Color == (CardLogicColor)myColNum))
					{
						if (slotCardData.CurrentCardSlotData == null || slotCardData.CardGameObject == null)
						{
							break;
						}
						if (cardLogic.GetType().GetMethod("OnFinishAttack").DeclaringType == cardLogic.GetType())
						{
							routine = GlobalController.Instance.StartCoroutine(cardLogic.OnFinishAttack(originCardData, targetSlotData));
							yield return routine.coroutine;
							try
							{
								int result2 = routine.Result;
							}
							catch (Exception ex3)
							{
								Debug.LogError(ex3.Message);
								Debug.LogError(ex3.StackTrace);
							}
						}
					}
					num = i2;
				}
				slotCardData = null;
			}
			num = i;
		}
		try
		{
			if (GameController.ins.PlayerToy != null)
			{
				GameController.ins.PlayerToy.DMGPanel.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f).onComplete = delegate()
				{
					GameController.ins.PlayerToy.DMGPanel.SetActive(false);
				};
			}
		}
		catch (Exception ex4)
		{
			Debug.LogError(ex4.Message);
			Debug.LogError(ex4.StackTrace);
		}
		using (List<CardSlotData>.Enumerator enumerator = csl.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardSlotData cs = enumerator.Current;
				if (cs.ChildCardData != null && cs.ChildCardData.CardGameObject != null)
				{
					cs.ChildCardData.CardGameObject.DMGPanel.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f).onComplete = delegate()
					{
						if (cs.ChildCardData != null && cs.ChildCardData.CardGameObject != null && cs.ChildCardData.CardGameObject.DMGPanel != null)
						{
							cs.ChildCardData.CardGameObject.DMGPanel.SetActive(false);
						}
					};
				}
				if (cs.ChildCardData != null && cs.ChildCardData.DizzyLayer <= 0)
				{
					CardData slotCardData = cs.ChildCardData;
					for (int i = slotCardData.CardLogics.Count - 1; i >= 0; i = num - 1)
					{
						if (slotCardData.CardLogics[i].GetType().GetMethod("OnFinishAttack").DeclaringType == slotCardData.CardLogics[i].GetType())
						{
							routine = GlobalController.Instance.StartCoroutine(slotCardData.CardLogics[i].OnFinishAttack(originCardData, targetSlotData));
							yield return routine.coroutine;
							try
							{
								int result3 = routine.Result;
							}
							catch (Exception ex5)
							{
								Debug.LogError(ex5.Message);
								Debug.LogError(ex5.StackTrace);
							}
						}
						num = i;
					}
					slotCardData = null;
				}
			}
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		this.SetLockOperation(false);
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
		yield break;
	}

	public bool CheckWinBattle()
	{
		if (!DungeonOperationMgr.Instance.IsInBattle)
		{
			return false;
		}
		bool flag = true;
		if (DungeonOperationMgr.Instance.BattleArea != null && DungeonOperationMgr.Instance.BattleArea.Count > 0)
		{
			foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.BattleArea)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardSlotData.ChildCardData) && cardSlotData.ChildCardData.HasTag(TagMap.怪物) && !cardSlotData.ChildCardData.HasTag(TagMap.衍生物))
				{
					flag = false;
				}
			}
			using (List<CardSlotData>.Enumerator enumerator = GameController.ins.GetCurrentAreaData().CardSlotDatas.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardSlotData cardSlotData2 = enumerator.Current;
					if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.BOSS))
					{
						flag = false;
						break;
					}
				}
				goto IL_FA;
			}
		}
		flag = false;
		IL_FA:
		if (flag)
		{
			foreach (CardSlotData cardSlotData3 in DungeonOperationMgr.Instance.BattleArea)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardSlotData3.ChildCardData))
				{
					cardSlotData3.ChildCardData.DeleteCardData();
				}
			}
			for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i++)
			{
				if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
				{
					CardData childCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
					if (childCardData.RemainTime <= 0)
					{
						childCardData.RemainTime = 0;
						childCardData.IsAttacked = false;
					}
					childCardData.HP -= childCardData.wHP;
					childCardData.Armor -= childCardData.wArmor;
					childCardData.Armor = ((childCardData.Armor < 0) ? 0 : childCardData.Armor);
					childCardData.wATK = (childCardData.wCRIT = (childCardData.wHP = (childCardData.wArmor = 0)));
					childCardData.wAttackTimes = 0;
				}
			}
			DungeonOperationMgr.Instance.IsInBattle = false;
			return !(GameController.getInstance().GameData.PlayerCardData.CardGameObject == null);
		}
		return false;
	}

	public void EndEventBattle()
	{
		foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.BattleArea)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardSlotData.ChildCardData))
			{
				cardSlotData.ChildCardData.DeleteCardData();
			}
		}
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i++)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData childCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				if (childCardData.RemainTime <= 0)
				{
					childCardData.RemainTime = 0;
					childCardData.IsAttacked = false;
				}
				childCardData.HP -= childCardData.wHP;
				childCardData.Armor -= childCardData.wArmor;
				childCardData.Armor = ((childCardData.Armor < 0) ? 0 : childCardData.Armor);
				childCardData.wATK = (childCardData.wCRIT = (childCardData.wHP = (childCardData.wArmor = 0)));
				childCardData.wAttackTimes = 0;
			}
		}
		DungeonOperationMgr.Instance.IsInBattle = false;
		if (GameController.getInstance().GameData.PlayerCardData.CardGameObject == null)
		{
			return;
		}
		if (GameController.getInstance().CurrentAct != null && (GameController.getInstance().CurrentAct.GetType() == typeof(EncounterAct) || GameController.getInstance().CurrentAct.GetType() == typeof(TutorialAct)))
		{
			GameAct currentAct = GameController.getInstance().CurrentAct;
			if (currentAct == null)
			{
				return;
			}
			currentAct.ActEnd();
		}
	}

	public void ResetAndSaveMinionsState()
	{
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i++)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData childCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				this.minionsStateDic.Add(childCardData, new object[]
				{
					childCardData.IsAttacked,
					childCardData.RemainTime
				});
				if (childCardData.RemainTime <= 0)
				{
					childCardData.RemainTime = 0;
					childCardData.IsAttacked = false;
				}
			}
		}
	}

	public void RecoveryMinionsSate()
	{
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i++)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData childCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				foreach (CardData cardData in this.minionsStateDic.Keys)
				{
					if (childCardData == cardData)
					{
						childCardData.IsAttacked = (bool)this.minionsStateDic[cardData][0];
						childCardData.RemainTime = (int)this.minionsStateDic[cardData][1];
					}
				}
			}
		}
		this.minionsStateDic.Clear();
	}

	public IEnumerator EndTurnProcess(bool isSkipEnemyProcess = false)
	{
		UIController.LockLevel = UIController.UILevel.All;
		string areaID = GameController.ins.GameData.CurrentAreaId;
		List<CardSlotData> csl = GameController.getInstance().GameData.AreaMap[areaID].CardSlotDatas;
		DungeonController.Instance.GameSettleData.TurnKills = 0;
		GameController.ins.UIController.HideComboPanel();
		int num;
		if (this.IsCoopMode)
		{
			this.IsInBattelSync = true;
			bool allDone = true;
			UnityEngine.Random.InitState((int)MultiPlayerController.Instance.CurrentLobbyID.m_SteamID + GameController.ins.GameData.level);
			Debug.LogWarning("设置种子" + ((int)MultiPlayerController.Instance.CurrentLobbyID.m_SteamID).ToString() + GameController.ins.GameData.level.ToString());
			Debug.LogWarning(string.Concat(new string[]
			{
				UnityEngine.Random.state.GetHashCode().ToString(),
				" ",
				UnityEngine.Random.seed.ToString(),
				" ",
				UnityEngine.Random.state.ToString()
			}));
			do
			{
				for (int i = GameController.getInstance().PublicArea.Count - 1; i >= 0; i = num - 1)
				{
					if (GameController.getInstance().PublicArea[i].ChildCardData != null && !GameController.getInstance().PublicArea[i].ChildCardData.IsAttacked)
					{
						for (int j = this.BattleArea.Count - 1; j >= 0; j--)
						{
							if (this.BattleArea[j].ChildCardData != null && (int)this.BattleArea[j].Attrs["Col"] == (int)GameController.getInstance().PublicArea[i].Attrs["Col"])
							{
								Debug.LogWarning(string.Concat(new string[]
								{
									UnityEngine.Random.state.GetHashCode().ToString(),
									" ",
									UnityEngine.Random.seed.ToString(),
									" ",
									UnityEngine.Random.state.ToString()
								}));
								yield return this.AttackProcess(GameController.getInstance().PublicArea[i].ChildCardData, this.BattleArea[j].ChildCardData, areaID);
								break;
							}
						}
					}
					num = i;
				}
				allDone = true;
				for (int k = GameController.getInstance().PublicArea.Count - 1; k >= 0; k--)
				{
					if (GameController.getInstance().PublicArea[k].ChildCardData != null && !GameController.getInstance().PublicArea[k].ChildCardData.IsAttacked)
					{
						for (int l = this.BattleArea.Count - 1; l >= 0; l--)
						{
							if (this.BattleArea[l].ChildCardData != null && (int)this.BattleArea[l].Attrs["Col"] == (int)GameController.getInstance().PublicArea[k].Attrs["Col"])
							{
								allDone = false;
								break;
							}
						}
					}
				}
				yield return null;
			}
			while (!allDone);
		}
		if (isSkipEnemyProcess)
		{
			try
			{
				for (int m = 0; m < GameController.getInstance().PlayerSlotSets.Count; m++)
				{
					if (GameController.getInstance().PlayerSlotSets[m].ChildCardData != null)
					{
						CardData childCardData = GameController.getInstance().PlayerSlotSets[m].ChildCardData;
						if (childCardData.RemainTime <= 0)
						{
							childCardData.RemainTime = 0;
							childCardData.IsAttacked = false;
						}
						childCardData.HP -= childCardData.wHP;
						childCardData.Armor -= childCardData.wArmor;
						childCardData.Armor = ((childCardData.Armor < 0) ? 0 : childCardData.Armor);
						childCardData.wATK = (childCardData.wCRIT = (childCardData.wHP = (childCardData.wArmor = 0)));
						childCardData.wAttackTimes = 0;
					}
				}
				GameController.getInstance().UIController.HideComboPanel();
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.Message);
				Debug.LogError(ex.StackTrace);
			}
			UIController.LockLevel = UIController.UILevel.None;
			yield break;
		}
		DungeonController.Instance.GameSettleData.Turns++;
		GameController.getInstance().UIController.HideComboPanel();
		DungeonController.Instance.GameSettleData.TurnKills = 0;
		DungeonController.Instance.GameSettleData.NowTurn = DungeonController.Instance.GameSettleData.Turns;
		UIController.LockLevel = (UIController.UILevel.PlayerSlot | UIController.UILevel.AreaTable);
		int colnum = GameController.getInstance().PlayerSlotSets.Count / 3;
		DOTween.Sequence();
		yield return new WaitForSeconds(0.05f);
		if (DungeonOperationMgr.Instance.IsInBattle)
		{
			Camera.main.transform.DOPunchRotation(new Vector3(-1f, 0f, 0f), 0.2f, 10, 1f).SetEase(Ease.OutQuad);
			Camera.main.transform.DOPunchPosition(new Vector3(0f, 0.5f, 0.5f), 0.2f, 10, 1f, false).SetEase(Ease.OutQuad);
		}
		try
		{
			for (int n = 0; n < GameController.getInstance().PlayerSlotSets.Count; n++)
			{
				if (GameController.getInstance().PlayerSlotSets[n].ChildCardData != null && GameController.getInstance().PlayerSlotSets[n].ChildCardData.HasTag(TagMap.随从) && GameController.getInstance().PlayerSlotSets[n].ChildCardData.CardGameObject != null)
				{
					Transform transform = GameController.getInstance().PlayerSlotSets[n].ChildCardData.CardGameObject.transform;
					transform.DOJump(transform.position, 0.3f, 1, 0.2f, false).SetEase(Ease.InOutQuad);
					transform.DOShakeRotation(0.2f, 20f, 10, 90f, true).SetEase(Ease.InOutQuad);
				}
			}
		}
		catch (Exception ex2)
		{
			Debug.LogError(ex2.Message);
			Debug.LogError(ex2.StackTrace);
		}
		yield return new WaitForSeconds(0.5f);
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num + 1)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				int myColNum = i / colnum;
				for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
				{
					CardLogic cardLogic = slotCardData.CardLogics[i2];
					if (slotCardData.DizzyLayer <= 0 && (cardLogic.Color >= CardLogicColor.white || cardLogic.Color == (CardLogicColor)myColNum))
					{
						if (slotCardData.CurrentCardSlotData == null || slotCardData.CardGameObject == null)
						{
							break;
						}
						if (cardLogic.GetType().GetMethod("OnEndTurn").DeclaringType == cardLogic.GetType())
						{
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic.OnEndTurn(true));
							yield return routine.coroutine;
							try
							{
								int result = routine.Result;
							}
							catch (Exception ex3)
							{
								Debug.LogError(ex3.Message);
								Debug.LogError(ex3.StackTrace);
							}
							routine = null;
						}
					}
					num = i2;
				}
				slotCardData = null;
			}
			num = i;
		}
		foreach (CardSlotData cardSlotData in csl)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.DizzyLayer <= 0)
			{
				CardData slotCardData = cardSlotData.ChildCardData;
				for (int i = slotCardData.CardLogics.Count - 1; i >= 0; i = num - 1)
				{
					if (slotCardData.CardLogics[i].GetType().GetMethod("OnEndTurn").DeclaringType == slotCardData.CardLogics[i].GetType())
					{
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(slotCardData.CardLogics[i].OnEndTurn(true));
						yield return routine.coroutine;
						try
						{
							int result2 = routine.Result;
						}
						catch (Exception ex4)
						{
							Debug.LogError(ex4.Message);
							Debug.LogError(ex4.StackTrace);
						}
						routine = null;
					}
					num = i;
				}
				slotCardData = null;
			}
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		Coroutine<int> routine2 = GlobalController.Instance.StartCoroutine(this.EnemyProcess(areaID));
		yield return routine2.coroutine;
		try
		{
			int result3 = routine2.Result;
		}
		catch (Exception ex5)
		{
			Debug.LogError(ex5.Message);
			Debug.LogError(ex5.StackTrace);
		}
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num + 1)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				int myColNum = i / colnum;
				for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
				{
					CardLogic cardLogic2 = slotCardData.CardLogics[i2];
					if (slotCardData.DizzyLayer <= 0 && (cardLogic2.Color >= CardLogicColor.white || cardLogic2.Color == (CardLogicColor)myColNum))
					{
						if (slotCardData.CurrentCardSlotData == null || slotCardData.CardGameObject == null)
						{
							break;
						}
						if (cardLogic2.GetType().GetMethod("OnEndTurn").DeclaringType == cardLogic2.GetType())
						{
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic2.OnEndTurn(false));
							yield return routine.coroutine;
							try
							{
								int result4 = routine.Result;
							}
							catch (Exception ex6)
							{
								Debug.LogError(ex6.Message);
								Debug.LogError(ex6.StackTrace);
							}
							routine = null;
						}
					}
					num = i2;
				}
				slotCardData = null;
			}
			num = i;
		}
		foreach (CardSlotData cardSlotData2 in csl)
		{
			if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.DizzyLayer <= 0)
			{
				CardData slotCardData = cardSlotData2.ChildCardData;
				for (int i = slotCardData.CardLogics.Count - 1; i >= 0; i = num - 1)
				{
					if (slotCardData.CardLogics[i].GetType().GetMethod("OnEndTurn").DeclaringType == slotCardData.CardLogics[i].GetType())
					{
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(slotCardData.CardLogics[i].OnEndTurn(false));
						yield return routine.coroutine;
						try
						{
							int result5 = routine.Result;
						}
						catch (Exception ex7)
						{
							Debug.LogError(ex7.Message);
							Debug.LogError(ex7.StackTrace);
						}
						routine = null;
					}
					num = i;
				}
				slotCardData = null;
			}
		}
		enumerator = default(List<CardSlotData>.Enumerator);
		try
		{
			for (int num2 = 0; num2 < GameController.getInstance().PlayerSlotSets.Count; num2++)
			{
				if (GameController.getInstance().PlayerSlotSets[num2].ChildCardData != null)
				{
					CardData childCardData2 = GameController.getInstance().PlayerSlotSets[num2].ChildCardData;
					int num3 = num2 / colnum;
					childCardData2.HP -= childCardData2.wHP;
					childCardData2.Armor -= childCardData2.wArmor;
					childCardData2.Armor = ((childCardData2.Armor < 0) ? 0 : childCardData2.Armor);
					childCardData2.wATK = (childCardData2.wCRIT = (childCardData2.wHP = (childCardData2.wArmor = 0)));
					childCardData2.wAttackTimes = 0;
				}
			}
			foreach (CardSlotData cardSlotData3 in csl)
			{
				if (cardSlotData3.ChildCardData != null)
				{
					CardData childCardData3 = cardSlotData3.ChildCardData;
					childCardData3.HP -= childCardData3.wHP;
					childCardData3.Armor -= childCardData3.wArmor;
					childCardData3.Armor = ((childCardData3.Armor < 0) ? 0 : childCardData3.Armor);
					childCardData3.wATK = (childCardData3.wCRIT = (childCardData3.wHP = (childCardData3.wArmor = 0)));
				}
			}
			foreach (CardSlotData cardSlotData4 in csl)
			{
				if (cardSlotData4.ChildCardData != null)
				{
					CardData childCardData4 = cardSlotData4.ChildCardData;
					if (childCardData4.DizzyLayer > 0)
					{
						childCardData4.DizzyLayer--;
						if (childCardData4.DizzyLayer == 0)
						{
							if (childCardData4.MaxArmor > 0)
							{
								childCardData4.MaxArmor--;
							}
							childCardData4.Armor = childCardData4.MaxArmor;
						}
					}
					childCardData4.RemainTime--;
					if (childCardData4.RemainTime <= 0)
					{
						childCardData4.RemainTime = 0;
						childCardData4.IsAttacked = false;
					}
				}
			}
			for (int num4 = 0; num4 < GameController.getInstance().PlayerSlotSets.Count; num4++)
			{
				if (GameController.getInstance().PlayerSlotSets[num4].ChildCardData != null)
				{
					CardData childCardData5 = GameController.getInstance().PlayerSlotSets[num4].ChildCardData;
					childCardData5.RemainTime--;
					if (childCardData5.RemainTime <= 0)
					{
						childCardData5.RemainTime = 0;
						childCardData5.IsAttacked = false;
					}
					if (childCardData5.DizzyLayer > 0)
					{
						childCardData5.DizzyLayer--;
					}
				}
			}
			this.FlipAllFlopableCardsOnTurnEnd();
			if (GameController.ins.PlayerToy != null)
			{
				GameController.ins.PlayerToy.DMGPanel.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f).onComplete = delegate()
				{
					GameController.ins.PlayerToy.DMGPanel.SetActive(false);
				};
			}
		}
		catch (Exception ex8)
		{
			Debug.LogError(ex8.Message);
			Debug.LogError(ex8.StackTrace);
		}
		if (this.IsInBattle)
		{
			for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num + 1)
			{
				CardSlotData cs = GameController.getInstance().PlayerSlotSets[i];
				if (cs.ChildCardData != null && cs.ChildCardData.CardGameObject != null)
				{
					cs.ChildCardData.CardGameObject.DMGPanel.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f).onComplete = delegate()
					{
						if (cs.ChildCardData != null && cs.ChildCardData.CardGameObject != null)
						{
							cs.ChildCardData.CardGameObject.DMGPanel.SetActive(false);
						}
					};
					Coroutine<int> routine = GlobalController.Instance.StartCoroutine(this.AffixSettlementProcees(cs.ChildCardData));
					yield return routine.coroutine;
					try
					{
						int result6 = routine.Result;
					}
					catch (Exception ex9)
					{
						Debug.LogError(ex9.Message);
						Debug.LogError(ex9.StackTrace);
					}
					routine = null;
				}
				if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
				{
					CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
					int myColNum = i / colnum;
					for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
					{
						CardLogic cardLogic3 = slotCardData.CardLogics[i2];
						if ((cardLogic3.Color >= CardLogicColor.white || cardLogic3.Color == (CardLogicColor)myColNum) && cardLogic3.GetType().GetMethod("OnTurnStart").DeclaringType == cardLogic3.GetType())
						{
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic3.OnTurnStart());
							yield return routine.coroutine;
							try
							{
								int result7 = routine.Result;
							}
							catch (Exception ex10)
							{
								Debug.LogError(ex10.Message);
								Debug.LogError(ex10.StackTrace);
							}
							routine = null;
						}
						num = i2;
					}
					slotCardData = null;
				}
				num = i;
			}
			using (List<CardSlotData>.Enumerator enumerator = csl.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardSlotData cs = enumerator.Current;
					if (cs.ChildCardData != null)
					{
						if (cs.ChildCardData != null && cs.ChildCardData.CardGameObject != null)
						{
							cs.ChildCardData.CardGameObject.DMGPanel.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f).onComplete = delegate()
							{
								if (cs.ChildCardData != null && cs.ChildCardData.CardGameObject != null && cs.ChildCardData.CardGameObject.DMGPanel != null)
								{
									cs.ChildCardData.CardGameObject.DMGPanel.SetActive(false);
								}
							};
						}
						CardData slotCardData = cs.ChildCardData;
						for (int i = 0; i < slotCardData.CardLogics.Count; i = num + 1)
						{
							CardLogic cardLogic4 = slotCardData.CardLogics[i];
							if (slotCardData.CardLogics[i].GetType().GetMethod("OnTurnStart").DeclaringType == slotCardData.CardLogics[i].GetType())
							{
								Coroutine<int> routine = GlobalController.Instance.StartCoroutine(slotCardData.CardLogics[i].OnTurnStart());
								yield return routine.coroutine;
								try
								{
									int result8 = routine.Result;
								}
								catch (Exception ex11)
								{
									Debug.LogError(ex11.Message);
									Debug.LogError(ex11.StackTrace);
								}
								routine = null;
							}
							num = i;
						}
						slotCardData = null;
					}
				}
			}
			enumerator = default(List<CardSlotData>.Enumerator);
			if (this.IsCoopMode)
			{
				bool flag = true;
				this.IsInBattelSync = true;
				for (int num5 = this.BattleArea.Count - 1; num5 >= 0; num5--)
				{
					if (this.BattleArea[num5].ChildCardData != null)
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					yield return this.EndTurnProcess(false);
					yield break;
				}
				MultiPlayerController.Instance.StateChange(MultiPlayerController.GameStateType.EndBattleSync);
				GameData gameData = GameController.ins.GameData;
				num = gameData.level;
				gameData.level = num + 1;
			}
			else if (this.IsWinCurrentFloor)
			{
				yield return new WaitForSeconds(5f);
				if (GameController.ins.GameData.DungeonTheme == DungeonTheme.Normal)
				{
					DungeonController.Instance.GenerateNextArea(true);
				}
				else
				{
					base.StartCoroutine(DungeonController.Instance.GameOver(true));
				}
				this.IsWinCurrentFloor = false;
			}
		}
		this.BattleTurn++;
		bool flag2 = false;
		foreach (CardSlotData cardSlotData5 in this.BattleArea)
		{
			if (cardSlotData5.ChildCardData != null && cardSlotData5.ChildCardData.HasTag(TagMap.BOSS))
			{
				flag2 = true;
				break;
			}
		}
		try
		{
			if (!flag2)
			{
				int num6 = 10;
				if (GameController.ins.GameData.Agreenment >= 8)
				{
					num6 -= 2;
				}
				if (this.BattleTurn == num6 - 2)
				{
					GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_31"), 1f, 2f, 1f, 1f);
				}
				if (this.BattleTurn == num6 - 1)
				{
					GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_32"), 1f, 2f, 1f, 1f);
				}
				if (this.BattleTurn > num6 && this.BattleTurn % 1 == 0)
				{
					bool flag3 = true;
					List<CardSlotData> list = new List<CardSlotData>();
					foreach (CardSlotData cardSlotData6 in this.BattleArea)
					{
						if (cardSlotData6.ChildCardData == null)
						{
							list.Add(cardSlotData6);
						}
						else if (!this.CheckCardDead(cardSlotData6.ChildCardData))
						{
							flag3 = false;
						}
					}
					if (list.Count > 0 && !flag3)
					{
						GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_33"), 1f, 2f, 1f, 1f);
						DungeonOperationMgr.Instance.InitDungeonMonster(Card.InitCardDataByID("死神"), GameController.ins.GameData.level * 8 + this.BattleTurn - 6).PutInSlotData(list[SYNCRandom.Range(0, list.Count)], true);
					}
				}
			}
		}
		catch (Exception ex12)
		{
			Debug.LogError(ex12.Message);
			Debug.LogError(ex12.StackTrace);
		}
		this.SetLockOperation(false);
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
		yield break;
	}

	public IEnumerator AffixSettlementProcees(CardData cardData)
	{
		Dictionary<DungeonAffix, int> dic = cardData.affixesDic;
		int num;
		for (int i = dic.Count - 1; i >= 0; i = num - 1)
		{
			KeyValuePair<DungeonAffix, int> keyValuePair = dic.ElementAt(i);
			DungeonAffix key = keyValuePair.Key;
			int value = keyValuePair.Value;
			if (value > 0)
			{
				if (cardData.CardGameObject != null)
				{
					GameController.ins.ShowAmountText(cardData.CardGameObject.transform.position, LocalizationMgr.Instance.GetLocalizationWord("A_N_" + DungeonOperationMgr.GetDungeonAffixInfo(key).defaultName), Color.green, i, false, false);
				}
				switch (key)
				{
				case DungeonAffix.poisoning:
					yield return cardData.CardGameObject.affixesImg[DungeonAffix.poisoning].transform.DOPunchScale(new Vector3(1f, 1f, 1f), 0.3f, 10, 1f).WaitForCompletion();
					yield return this.DungeonHandler.ChangeHp(cardData, -value, null, true, 0, false, false);
					break;
				case DungeonAffix.bleeding:
					yield return cardData.CardGameObject.affixesImg[DungeonAffix.bleeding].transform.DOPunchScale(new Vector3(1f, 1f, 1f), 0.3f, 10, 1f).WaitForCompletion();
					yield return this.DungeonHandler.ChangeHp(cardData, -value, null, true, 0, false, false);
					break;
				case DungeonAffix.heal:
					yield return cardData.CardGameObject.affixesImg[DungeonAffix.heal].transform.DOPunchScale(new Vector3(1f, 1f, 1f), 0.3f, 10, 1f).WaitForCompletion();
					yield return this.DungeonHandler.ChangeHp(cardData, value, null, false, 0, true, false);
					break;
				case DungeonAffix.dizzy:
					yield return cardData.CardGameObject.affixesImg[DungeonAffix.dizzy].transform.DOPunchScale(new Vector3(1f, 1f, 1f), 0.3f, 10, 1f).WaitForCompletion();
					cardData.DizzyLayer++;
					cardData.IsAttacked = true;
					break;
				}
				dic[key] = value - 1;
				if (dic[key] <= 0)
				{
					cardData.RemoveAffix(key);
				}
			}
			num = i;
		}
		yield return null;
		yield break;
	}

	public IEnumerator VSModeEndTurnProcess(bool isMyTurn)
	{
		UIController.LockLevel = UIController.UILevel.All;
		string areaID = GameController.ins.GameData.CurrentAreaId;
		List<CardSlotData> csl = GameController.getInstance().GameData.AreaMap[areaID].CardSlotDatas;
		this.IsInBattelSync = true;
		bool allDone = true;
		SYNCRandom.Seed = (int)VSModeController.Instance.CurrentLobbyID.m_SteamID;
		Debug.LogWarning("设置种子" + ((int)VSModeController.Instance.CurrentLobbyID.m_SteamID).ToString());
		List<CardSlotData> mySlots;
		List<CardSlotData> OPSlots;
		if (isMyTurn)
		{
			mySlots = GameController.getInstance().PlayerSlotSets;
			OPSlots = this.BattleArea;
		}
		else
		{
			int count = this.BattleArea.Count;
			int count2 = GameController.getInstance().PlayerSlotSets.Count;
			for (int k = 0; k < GameController.getInstance().PlayerSlotSets.Count; k++)
			{
				this.BattleArea.Add(GameController.getInstance().PlayerSlotSets[k]);
			}
			for (int l = 0; l < count; l++)
			{
				GameController.getInstance().PlayerSlotSets.Add(this.BattleArea[l]);
			}
			for (int m = 0; m < 9; m++)
			{
				this.BattleArea.RemoveAt(0);
			}
			for (int n = 0; n < 9; n++)
			{
				GameController.getInstance().PlayerSlotSets.RemoveAt(0);
			}
			mySlots = GameController.getInstance().PlayerSlotSets;
			OPSlots = this.BattleArea;
		}
		GameController.ins.GameData.SlotsOnPlayerTable = GameController.getInstance().PlayerSlotSets;
		(GameController.ins.GameData.AreaMap[GameController.ins.GameData.CurrentAreaId] as SpaceAreaData).CardSlotDatas = this.BattleArea;
		(GameController.ins.GameData.AreaMap[GameController.ins.GameData.CurrentAreaId] as SpaceAreaData).CardSlotGridHeight = 3;
		(GameController.ins.GameData.AreaMap[GameController.ins.GameData.CurrentAreaId] as SpaceAreaData).CardSlotGridWidth = 3;
		Debug.Log("我的卡槽长度:" + GameController.getInstance().PlayerSlotSets.Count.ToString());
		Debug.Log("Public卡槽长度:" + GameController.getInstance().PublicArea.Count.ToString());
		Debug.Log("对手的卡槽长度:" + this.BattleArea.Count.ToString());
		int num;
		for (;;)
		{
			for (int i = mySlots.Count - 1; i >= 0; i = num - 1)
			{
				if (mySlots[i].ChildCardData != null && !mySlots[i].ChildCardData.IsAttacked)
				{
					int j = OPSlots.Count - 1;
					while (j >= 0)
					{
						if (OPSlots[j].ChildCardData != null && (int)OPSlots[j].Attrs["Col"] == (int)mySlots[i].Attrs["Col"])
						{
							yield return this.AttackProcess(mySlots[i].ChildCardData, OPSlots[j].ChildCardData, areaID);
							if (VSModeController.Instance.MyBattleCore == null || VSModeController.Instance.MyBattleCore.HP <= 0)
							{
								goto IL_447;
							}
							if (VSModeController.Instance.OPBattleCore == null || VSModeController.Instance.OPBattleCore.HP <= 0)
							{
								goto IL_476;
							}
							break;
						}
						else
						{
							num = j;
							j = num - 1;
						}
					}
					if (j == -1)
					{
						yield return this.AttackProcess(mySlots[i].ChildCardData, OPSlots[1].ChildCardData, areaID);
						if (VSModeController.Instance.MyBattleCore == null || VSModeController.Instance.MyBattleCore.HP <= 0)
						{
							goto IL_51D;
						}
						if (VSModeController.Instance.OPBattleCore == null || VSModeController.Instance.OPBattleCore.HP <= 0)
						{
							goto IL_54C;
						}
					}
				}
				num = i;
			}
			allDone = true;
			for (int num2 = mySlots.Count - 1; num2 >= 0; num2--)
			{
				if (mySlots[num2].ChildCardData != null && !mySlots[num2].ChildCardData.IsAttacked)
				{
					for (int num3 = this.BattleArea.Count - 1; num3 >= 0; num3--)
					{
						if (OPSlots[num3].ChildCardData != null && (int)OPSlots[num3].Attrs["Col"] == (int)mySlots[num2].Attrs["Col"])
						{
							allDone = false;
							break;
						}
					}
				}
			}
			yield return null;
			if (allDone)
			{
				goto Block_22;
			}
		}
		IL_447:
		VSModeController.Instance.Loss();
		yield break;
		IL_476:
		VSModeController.Instance.Win();
		yield break;
		IL_51D:
		VSModeController.Instance.Loss();
		yield break;
		IL_54C:
		VSModeController.Instance.Win();
		yield break;
		Block_22:
		DungeonController.Instance.GameSettleData.Turns++;
		GameController.getInstance().UIController.HideComboPanel();
		DungeonController.Instance.GameSettleData.TurnKills = 0;
		DungeonController.Instance.GameSettleData.NowTurn = DungeonController.Instance.GameSettleData.Turns;
		UIController.LockLevel = (UIController.UILevel.PlayerSlot | UIController.UILevel.AreaTable);
		int colnum = GameController.getInstance().PlayerSlotSets.Count / 3;
		DOTween.Sequence();
		yield return new WaitForSeconds(0.05f);
		if (DungeonOperationMgr.Instance.IsInBattle)
		{
			Camera.main.transform.DOPunchRotation(new Vector3(-1f, 0f, 0f), 0.2f, 10, 1f).SetEase(Ease.OutQuad);
			Camera.main.transform.DOPunchPosition(new Vector3(0f, 0.5f, 0.5f), 0.2f, 10, 1f, false).SetEase(Ease.OutQuad);
		}
		for (int num4 = 0; num4 < GameController.getInstance().PlayerSlotSets.Count; num4++)
		{
			if (GameController.getInstance().PlayerSlotSets[num4].ChildCardData != null && GameController.getInstance().PlayerSlotSets[num4].ChildCardData.HasTag(TagMap.随从) && GameController.getInstance().PlayerSlotSets[num4].ChildCardData.CardGameObject != null)
			{
				Transform transform = GameController.getInstance().PlayerSlotSets[num4].ChildCardData.CardGameObject.transform;
				transform.DOJump(transform.position, 0.3f, 1, 0.2f, false).SetEase(Ease.InOutQuad);
				transform.DOShakeRotation(0.2f, 20f, 10, 90f, true).SetEase(Ease.InOutQuad);
			}
		}
		yield return new WaitForSeconds(0.5f);
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num + 1)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				int j = i / colnum;
				for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
				{
					CardLogic cardLogic = slotCardData.CardLogics[i2];
					if (slotCardData.DizzyLayer <= 0 && (cardLogic.Color >= CardLogicColor.white || cardLogic.Color == (CardLogicColor)j))
					{
						if (slotCardData.CurrentCardSlotData == null || slotCardData.CardGameObject == null)
						{
							break;
						}
						if (cardLogic.GetType().GetMethod("OnEndTurn").DeclaringType == cardLogic.GetType())
						{
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic.OnEndTurn(true));
							yield return routine.coroutine;
							try
							{
								int result = routine.Result;
							}
							catch (Exception ex)
							{
								Debug.LogError(ex.Message);
								Debug.LogError(ex.StackTrace);
							}
							routine = null;
						}
					}
					num = i2;
				}
				slotCardData = null;
			}
			num = i;
		}
		foreach (CardSlotData cardSlotData in csl)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.DizzyLayer <= 0)
			{
				CardData slotCardData = cardSlotData.ChildCardData;
				for (int i = slotCardData.CardLogics.Count - 1; i >= 0; i = num - 1)
				{
					if (slotCardData.CardLogics[i].GetType().GetMethod("OnEndTurn").DeclaringType == slotCardData.CardLogics[i].GetType())
					{
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(slotCardData.CardLogics[i].OnEndTurn(true));
						yield return routine.coroutine;
						try
						{
							int result2 = routine.Result;
						}
						catch (Exception ex2)
						{
							Debug.LogError(ex2.Message);
							Debug.LogError(ex2.StackTrace);
						}
						routine = null;
					}
					num = i;
				}
				slotCardData = null;
			}
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num + 1)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				int j = i / colnum;
				if (slotCardData.CardLogics.Count > 0)
				{
					for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
					{
						CardLogic cardLogic2 = slotCardData.CardLogics[i2];
						if (slotCardData.DizzyLayer <= 0 && (cardLogic2.Color >= CardLogicColor.white || cardLogic2.Color == (CardLogicColor)j))
						{
							if (slotCardData.CurrentCardSlotData == null || slotCardData.CardGameObject == null)
							{
								break;
							}
							if (cardLogic2.GetType().GetMethod("OnEndTurn").DeclaringType == cardLogic2.GetType())
							{
								Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic2.OnEndTurn(false));
								yield return routine.coroutine;
								try
								{
									int result3 = routine.Result;
								}
								catch (Exception ex3)
								{
									Debug.LogError(ex3.Message);
									Debug.LogError(ex3.StackTrace);
								}
								routine = null;
							}
						}
						num = i2;
					}
				}
				slotCardData = null;
			}
			num = i;
		}
		foreach (CardSlotData cardSlotData2 in csl)
		{
			if (cardSlotData2.ChildCardData != null)
			{
				CardData slotCardData = cardSlotData2.ChildCardData;
				if (slotCardData.DizzyLayer <= 0)
				{
					for (int i = slotCardData.CardLogics.Count - 1; i >= 0; i = num - 1)
					{
						if (slotCardData.CardLogics[i].GetType().GetMethod("OnEndTurn").DeclaringType == slotCardData.CardLogics[i].GetType())
						{
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(slotCardData.CardLogics[i].OnEndTurn(false));
							yield return routine.coroutine;
							try
							{
								int result4 = routine.Result;
							}
							catch (Exception ex4)
							{
								Debug.LogError(ex4.Message);
								Debug.LogError(ex4.StackTrace);
							}
							routine = null;
						}
						num = i;
					}
					slotCardData = null;
				}
			}
		}
		enumerator = default(List<CardSlotData>.Enumerator);
		foreach (CardSlotData cardSlotData3 in csl)
		{
			if (cardSlotData3.ChildCardData != null)
			{
				CardData childCardData = cardSlotData3.ChildCardData;
				if (childCardData.DizzyLayer > 0)
				{
					childCardData.DizzyLayer--;
					if (childCardData.DizzyLayer == 0 && childCardData.MaxArmor > 0 && childCardData.Armor == 0)
					{
						childCardData.MaxArmor--;
						childCardData.Armor = childCardData.MaxArmor;
					}
				}
				else
				{
					childCardData.DizzyLayer = 0;
				}
				childCardData.RemainTime--;
				if (childCardData.RemainTime <= 0)
				{
					childCardData.RemainTime = 0;
					childCardData.IsAttacked = false;
				}
			}
		}
		for (int num5 = 0; num5 < GameController.getInstance().PlayerSlotSets.Count; num5++)
		{
			if (GameController.getInstance().PlayerSlotSets[num5].ChildCardData != null)
			{
				CardData childCardData2 = GameController.getInstance().PlayerSlotSets[num5].ChildCardData;
				childCardData2.RemainTime--;
				if (childCardData2.RemainTime <= 0)
				{
					childCardData2.RemainTime = 0;
					childCardData2.IsAttacked = false;
				}
			}
		}
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num + 1)
		{
			CardSlotData cs = GameController.getInstance().PlayerSlotSets[i];
			if (cs.ChildCardData != null && cs.ChildCardData.CardGameObject != null)
			{
				cs.ChildCardData.CardGameObject.DMGPanel.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f).onComplete = delegate()
				{
					if (cs.ChildCardData != null && cs.ChildCardData.CardGameObject != null)
					{
						cs.ChildCardData.CardGameObject.DMGPanel.SetActive(false);
					}
				};
			}
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				int j = i / colnum;
				for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
				{
					CardLogic cardLogic3 = slotCardData.CardLogics[i2];
					if ((cardLogic3.Color >= CardLogicColor.white || cardLogic3.Color == (CardLogicColor)j) && cardLogic3.GetType().GetMethod("OnTurnStart").DeclaringType == cardLogic3.GetType())
					{
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic3.OnTurnStart());
						yield return routine.coroutine;
						try
						{
							int result5 = routine.Result;
						}
						catch (Exception ex5)
						{
							Debug.LogError(ex5.Message);
							Debug.LogError(ex5.StackTrace);
						}
						routine = null;
					}
					num = i2;
				}
				slotCardData = null;
			}
			num = i;
		}
		using (List<CardSlotData>.Enumerator enumerator = csl.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardSlotData cs = enumerator.Current;
				if (cs.ChildCardData != null)
				{
					if (cs.ChildCardData != null && cs.ChildCardData.CardGameObject != null)
					{
						cs.ChildCardData.CardGameObject.DMGPanel.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f).onComplete = delegate()
						{
							if (cs.ChildCardData != null && cs.ChildCardData.CardGameObject != null && cs.ChildCardData.CardGameObject.DMGPanel != null)
							{
								cs.ChildCardData.CardGameObject.DMGPanel.SetActive(false);
							}
						};
					}
					CardData slotCardData = cs.ChildCardData;
					for (int i = 0; i < slotCardData.CardLogics.Count; i = num + 1)
					{
						CardLogic cardLogic4 = slotCardData.CardLogics[i];
						if (slotCardData.CardLogics[i].GetType().GetMethod("OnTurnStart").DeclaringType == slotCardData.CardLogics[i].GetType())
						{
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(slotCardData.CardLogics[i].OnTurnStart());
							yield return routine.coroutine;
							try
							{
								int result6 = routine.Result;
							}
							catch (Exception ex6)
							{
								Debug.LogError(ex6.Message);
								Debug.LogError(ex6.StackTrace);
							}
							routine = null;
						}
						num = i;
					}
					slotCardData = null;
				}
			}
		}
		enumerator = default(List<CardSlotData>.Enumerator);
		if (!isMyTurn)
		{
			int count3 = this.BattleArea.Count;
			int count4 = GameController.getInstance().PlayerSlotSets.Count;
			for (int num6 = 0; num6 < GameController.getInstance().PlayerSlotSets.Count; num6++)
			{
				this.BattleArea.Add(GameController.getInstance().PlayerSlotSets[num6]);
			}
			for (int num7 = 0; num7 < count3; num7++)
			{
				GameController.getInstance().PlayerSlotSets.Add(this.BattleArea[num7]);
			}
			for (int num8 = 0; num8 < 9; num8++)
			{
				this.BattleArea.RemoveAt(0);
			}
			for (int num9 = 0; num9 < 9; num9++)
			{
				GameController.getInstance().PlayerSlotSets.RemoveAt(0);
			}
			GameController.ins.GameData.SlotsOnPlayerTable = GameController.getInstance().PlayerSlotSets;
		}
		UIController.LockLevel = UIController.UILevel.None;
		VSBattleFinishPlayMsg vsbattleFinishPlayMsg = new VSBattleFinishPlayMsg();
		vsbattleFinishPlayMsg.Identity = 0;
		VSModeController.Instance.MultiPlaySendMsgQueue.Enqueue(vsbattleFinishPlayMsg);
		VSModeController.Instance.IsInBattle = false;
		if (VSModeController.Instance.MyBattleCore == null || VSModeController.Instance.MyBattleCore.HP <= 0)
		{
			VSModeController.Instance.Loss();
		}
		if (VSModeController.Instance.OPBattleCore == null || VSModeController.Instance.OPBattleCore.HP <= 0)
		{
			VSModeController.Instance.Win();
		}
		yield break;
		yield break;
	}

	public CardData GetAim(CardData targetCardData)
	{
		List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
		CardData cardData = null;
		int num = slotsOnPlayerTable.Count / 3 * 2;
		while (num < slotsOnPlayerTable.Count && (targetCardData.AttackColor == 0 || targetCardData.AttackColor == 1))
		{
			if (slotsOnPlayerTable[num].ChildCardData != null && slotsOnPlayerTable[num].ChildCardData.HasTag(TagMap.随从))
			{
				cardData = slotsOnPlayerTable[num].ChildCardData;
				break;
			}
			num++;
		}
		if (cardData == null)
		{
			int num2 = slotsOnPlayerTable.Count / 3;
			while (num2 < slotsOnPlayerTable.Count / 3 * 2 && (targetCardData.AttackColor == 0 || targetCardData.AttackColor == 2))
			{
				if (slotsOnPlayerTable[num2].ChildCardData != null && slotsOnPlayerTable[num2].ChildCardData.HasTag(TagMap.随从))
				{
					cardData = slotsOnPlayerTable[num2].ChildCardData;
					break;
				}
				num2++;
			}
		}
		if (cardData == null)
		{
			int num3 = slotsOnPlayerTable.Count / 3;
			int num4 = 0;
			while (num4 < slotsOnPlayerTable.Count / 3 && (targetCardData.AttackColor == 0 || targetCardData.AttackColor == 3))
			{
				if (slotsOnPlayerTable[num4].ChildCardData != null && slotsOnPlayerTable[num4].ChildCardData.HasTag(TagMap.随从))
				{
					cardData = slotsOnPlayerTable[num4].ChildCardData;
					break;
				}
				num4++;
			}
		}
		return cardData;
	}

	private IEnumerator EnemyProcess(string areaID)
	{
		this.SetLockOperation(true);
		UIController.LockLevel = (UIController.UILevel.PlayerSlot | UIController.UILevel.AreaTable);
		List<CardSlotData> PlayerCardSlots = GameController.getInstance().PlayerSlotSets;
		List<CardSlotData> csl = GameController.getInstance().GameData.AreaMap[areaID].CardSlotDatas;
		int num2;
		for (int i = 0; i < csl.Count; i = num2 + 1)
		{
			CardSlotData cs = csl[i];
			CardData targetCardData = cs.ChildCardData;
			if (!this.CheckCardDead(targetCardData) && targetCardData.HasTag(TagMap.怪物))
			{
				Coroutine<int> routine = GlobalController.Instance.StartCoroutine(this.AffixSettlementProcees(targetCardData));
				yield return routine.coroutine;
				try
				{
					int result = routine.Result;
				}
				catch (Exception ex)
				{
					Debug.LogError(ex.Message);
					Debug.LogError(ex.StackTrace);
				}
				if (!this.CheckCardDead(targetCardData) && targetCardData.HasTag(TagMap.怪物))
				{
					List<CardData> list = new List<CardData>();
					if (GameController.ins.GameData.DungeonTheme == DungeonTheme.Normal || (DungeonOperationMgr.Instance.BattleArea != null && DungeonOperationMgr.Instance.BattleArea.Count != 0))
					{
						if (!cs.HasAttr("Col"))
						{
							goto IL_571;
						}
						int num = 0;
						if (MultiPlayerController.Instance != null)
						{
							num = 5;
						}
						bool flag = false;
						for (int j = PlayerCardSlots.Count - PlayerCardSlots.Count / 3 + (int)cs.Attrs["Col"] + num; j >= 0; j -= PlayerCardSlots.Count / 3)
						{
							if (PlayerCardSlots[j] != null && PlayerCardSlots[j].ChildCardData != null && (PlayerCardSlots[j].ChildCardData.HasTag(TagMap.随从) || PlayerCardSlots[j].ChildCardData.HasTag(TagMap.工具) || PlayerCardSlots[j].ChildCardData.HasTag(TagMap.装备)) && !DungeonOperationMgr.Instance.CheckCardDead(PlayerCardSlots[j].ChildCardData))
							{
								list.Add(PlayerCardSlots[j].ChildCardData);
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							CardData item = GameController.ins.GameData.PlayerCardData;
							foreach (CardSlotData cardSlotData in PlayerCardSlots)
							{
								if (cardSlotData.ChildCardData != null && (int)cardSlotData.Attrs["Col"] == (int)GameController.ins.GameData.PlayerCardData.CurrentCardSlotData.Attrs["Col"] && (cardSlotData.ChildCardData.HasTag(TagMap.随从) || cardSlotData.ChildCardData.HasTag(TagMap.工具) || cardSlotData.ChildCardData.HasTag(TagMap.装备)) && !DungeonOperationMgr.Instance.CheckCardDead(cardSlotData.ChildCardData))
								{
									item = cardSlotData.ChildCardData;
								}
							}
							list.Add(item);
						}
						foreach (CardData cardData in list)
						{
							if (targetCardData != null && cardData != null && targetCardData.DizzyLayer <= 0 && targetCardData.ATK > 0)
							{
								routine = GlobalController.Instance.StartCoroutine(this.Attack(targetCardData, cardData, areaID));
								yield return routine.coroutine;
								try
								{
									int result2 = routine.Result;
								}
								catch (Exception ex2)
								{
									Debug.LogError(ex2.Message);
									Debug.LogError(ex2.StackTrace);
								}
							}
						}
						List<CardData>.Enumerator enumerator2 = default(List<CardData>.Enumerator);
					}
					else
					{
						CardData playerCardData = GameController.ins.GameData.PlayerCardData;
						if (targetCardData == null || playerCardData == null)
						{
							goto IL_571;
						}
						if (targetCardData.DizzyLayer <= 0 && targetCardData.ATK > 0)
						{
							routine = GlobalController.Instance.StartCoroutine(this.Attack(targetCardData, playerCardData, areaID));
							yield return routine.coroutine;
							try
							{
								int result3 = routine.Result;
							}
							catch (Exception ex3)
							{
								Debug.LogError(ex3.Message);
								Debug.LogError(ex3.StackTrace);
							}
						}
					}
					cs = null;
					targetCardData = null;
					routine = null;
				}
			}
			IL_571:
			num2 = i;
		}
		yield break;
		yield break;
	}

	public IEnumerator Attack(CardData originCardData, CardData targetCardData, string areaID)
	{
		if (this.CheckCardDead(targetCardData))
		{
			yield break;
		}
		CardSlotData enemySlotData = targetCardData.CurrentCardSlotData;
		List<CardSlotData> csl = GameController.getInstance().GameData.AreaMap[areaID].CardSlotDatas;
		int colnum = GameController.getInstance().PlayerSlotSets.Count / 3;
		int originCardRow = -1;
		int num;
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num + 1)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				if (GameController.getInstance().PlayerSlotSets[i].ChildCardData == originCardData)
				{
					originCardRow = i / colnum;
				}
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				int myColNum = i / colnum;
				for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
				{
					CardLogic cardLogic = slotCardData.CardLogics[i2];
					if (slotCardData.DizzyLayer <= 0 && (cardLogic.Color >= CardLogicColor.white || cardLogic.Color == (CardLogicColor)myColNum))
					{
						if (slotCardData.CurrentCardSlotData == null || slotCardData.CardGameObject == null)
						{
							break;
						}
						if (cardLogic.GetType().GetMethod("OnBeforeAttack").DeclaringType == cardLogic.GetType())
						{
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic.OnBeforeAttack(originCardData, enemySlotData));
							yield return routine.coroutine;
							try
							{
								int result = routine.Result;
							}
							catch (Exception ex)
							{
								Debug.LogError(ex.Message);
								Debug.LogError(ex.StackTrace);
							}
							routine = null;
						}
					}
					num = i2;
				}
				slotCardData = null;
			}
			num = i;
		}
		foreach (CardSlotData cardSlotData in csl)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.DizzyLayer <= 0)
			{
				CardData slotCardData = cardSlotData.ChildCardData;
				for (int i = slotCardData.CardLogics.Count - 1; i >= 0; i = num - 1)
				{
					if (slotCardData.CardLogics[i].GetType().GetMethod("OnBeforeAttack").DeclaringType == slotCardData.CardLogics[i].GetType())
					{
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(slotCardData.CardLogics[i].OnBeforeAttack(originCardData, enemySlotData));
						yield return routine.coroutine;
						try
						{
							int result2 = routine.Result;
						}
						catch (Exception ex2)
						{
							Debug.LogError(ex2.Message);
							Debug.LogError(ex2.StackTrace);
						}
						routine = null;
					}
					num = i;
				}
				slotCardData = null;
			}
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		int AttackTimes = originCardData.AttackTimes;
		if (AttackTimes < 1)
		{
			AttackTimes = 1;
		}
		for (int i = 0; i < AttackTimes; i = num + 1)
		{
			this.CurrentAttackMsgStruct = new AttackMsgStruct();
			this.CurrentAttackMsgStruct.Targets = new List<List<AttackMsg>>();
			this.CurrentAttackMsgStruct.ShotEffects = new List<string>();
			this.CurrentAttackMsgStruct.HitEffects = new List<string>();
			this.CurrentAttackMsgStruct.TransferEffects = new List<string>();
			bool flag = false;
			for (int myColNum = 0; myColNum < originCardData.CardLogics.Count; myColNum = num + 1)
			{
				CardLogic cardLogic2 = originCardData.CardLogics[myColNum];
				if ((originCardRow < 0 || cardLogic2.Color >= CardLogicColor.white || cardLogic2.Color == (CardLogicColor)originCardRow) && cardLogic2.GetType().GetMethod("CustomAttack").DeclaringType == cardLogic2.GetType())
				{
					yield return cardLogic2.CustomAttack(enemySlotData);
					flag = true;
				}
				num = myColNum;
			}
			if (originCardData.DizzyLayer == 0 && !flag)
			{
				yield return this.DefaultAttack(originCardData, enemySlotData);
			}
			yield return this.AttackProcess(originCardData, targetCardData);
			if (!this.CheckCardDead(originCardData) && targetCardData.HasAffix(DungeonAffix.beatBack))
			{
				ParticlePoolManager.Instance.Spawn("Effect/忍杀", 0.5f).transform.position = originCardData.CurrentCardSlotData.CardSlotGameObject.transform.position;
				if (this.GetLogic(targetCardData, typeof(XiangShuiCardLogic)) != null)
				{
					XiangShuiCardLogic xiangShuiCardLogic = this.GetLogic(targetCardData, typeof(XiangShuiCardLogic)) as XiangShuiCardLogic;
					originCardData.AddAffix(DungeonAffix.frail, xiangShuiCardLogic.Layers * xiangShuiCardLogic.weight);
				}
				yield return this.DungeonHandler.ChangeHp(originCardData, -targetCardData.affixesDic[DungeonAffix.beatBack], targetCardData, false, 0, true, false);
			}
			num = i;
		}
		originCardData.NextAttackTimes = 0;
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num + 1)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				int myColNum = i / colnum;
				for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
				{
					CardLogic cardLogic3 = slotCardData.CardLogics[i2];
					if (slotCardData.DizzyLayer <= 0 && (cardLogic3.Color >= CardLogicColor.white || cardLogic3.Color == (CardLogicColor)myColNum))
					{
						if (slotCardData.CurrentCardSlotData == null || slotCardData.CardGameObject == null)
						{
							break;
						}
						if (cardLogic3.GetType().GetMethod("OnAfterAttack").DeclaringType == cardLogic3.GetType())
						{
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic3.OnAfterAttack(originCardData, enemySlotData));
							yield return routine.coroutine;
							try
							{
								int result3 = routine.Result;
							}
							catch (Exception ex3)
							{
								Debug.LogError(ex3.Message);
								Debug.LogError(ex3.StackTrace);
							}
							routine = null;
						}
					}
					num = i2;
				}
				slotCardData = null;
			}
			num = i;
		}
		foreach (CardSlotData cardSlotData2 in csl)
		{
			if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.DizzyLayer <= 0)
			{
				CardData slotCardData = cardSlotData2.ChildCardData;
				for (int i = slotCardData.CardLogics.Count - 1; i >= 0; i = num - 1)
				{
					if (slotCardData.CardLogics[i].GetType().GetMethod("OnAfterAttack").DeclaringType == slotCardData.CardLogics[i].GetType())
					{
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(slotCardData.CardLogics[i].OnAfterAttack(originCardData, enemySlotData));
						yield return routine.coroutine;
						try
						{
							int result4 = routine.Result;
						}
						catch (Exception ex4)
						{
							Debug.LogError(ex4.Message);
							Debug.LogError(ex4.StackTrace);
						}
						routine = null;
					}
					num = i;
				}
				slotCardData = null;
			}
		}
		enumerator = default(List<CardSlotData>.Enumerator);
		yield break;
		yield break;
	}

	public IEnumerator DefaultAttack(CardData originCardData, CardSlotData cardSlotData)
	{
		List<CardData> list = new List<CardData>();
		CardData childCardData = cardSlotData.ChildCardData;
		if (this.CurrentAttackMsgStruct.ShotEffects == null)
		{
			this.CurrentAttackMsgStruct.ShotEffects = new List<string>();
		}
		this.CurrentAttackMsgStruct.ShotEffects.Add(originCardData.ShotEffect);
		int attackTimes = originCardData.AttackTimes;
		List<AttackMsg> list2 = new List<AttackMsg>();
		this.CurrentAttackMsgStruct.Targets.Add(list2);
		if (this.CheckCardDead(originCardData))
		{
			yield break;
		}
		if (originCardData.AttackExtraRange != null)
		{
			SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
			if (spaceAreaData != null)
			{
				foreach (Vector3Int vector3Int in originCardData.AttackExtraRange)
				{
					CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(cardSlotData.GridPositionX, cardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
					if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物))
					{
						list.Add(ralitiveCardSlotData.ChildCardData);
					}
				}
			}
		}
		foreach (CardData cardData in list)
		{
			if (!this.CheckCardDead(cardData))
			{
				list2.Add(new AttackMsg(cardData, originCardData.ATK, false, true, 0, 0, null));
			}
		}
		if (!this.CheckCardDead(childCardData))
		{
			List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
			List<CardData> list3 = new List<CardData>();
			if (originCardData.HasTag(TagMap.怪物) && GameController.ins.GameData.DungeonTheme != DungeonTheme.Normal && (this.BattleArea == null || this.BattleArea.Count == 0))
			{
				for (int i = playerSlotSets.Count / 3 * 2; i < playerSlotSets.Count; i++)
				{
					if (playerSlotSets[i] != null && playerSlotSets[i].ChildCardData != null && playerSlotSets[i].ChildCardData.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(playerSlotSets[i].ChildCardData))
					{
						list3.Add(playerSlotSets[i].ChildCardData);
					}
					else if (playerSlotSets[i - playerSlotSets.Count / 3] != null && playerSlotSets[i - playerSlotSets.Count / 3].ChildCardData != null && playerSlotSets[i - playerSlotSets.Count / 3].ChildCardData.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(playerSlotSets[i - playerSlotSets.Count / 3].ChildCardData))
					{
						list3.Add(playerSlotSets[i - playerSlotSets.Count / 3].ChildCardData);
					}
					else if (playerSlotSets[i - playerSlotSets.Count / 3 * 2] != null && playerSlotSets[i - playerSlotSets.Count / 3 * 2].ChildCardData != null && playerSlotSets[i - playerSlotSets.Count / 3 * 2].ChildCardData.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(playerSlotSets[i - playerSlotSets.Count / 3 * 2].ChildCardData))
					{
						list3.Add(playerSlotSets[i - playerSlotSets.Count / 3 * 2].ChildCardData);
					}
				}
				using (List<CardData>.Enumerator enumerator2 = list3.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						CardData target = enumerator2.Current;
						list2.Add(new AttackMsg(target, originCardData.ATK, false, true, 0, 0, null));
					}
					yield break;
				}
			}
			list2.Add(new AttackMsg(childCardData, originCardData.ATK, false, true, 0, 0, null));
		}
		yield break;
	}

	public IEnumerator AttackProcess(CardData origin, CardData target)
	{
		int num;
		for (int i = 0; i < this.CurrentAttackMsgStruct.Targets.Count; i = num + 1)
		{
			List<AttackMsg> msgList = this.CurrentAttackMsgStruct.Targets[i];
			if (i == 0)
			{
				if (this.CurrentAttackMsgStruct.TransferEffects.Count > 0)
				{
					using (List<string>.Enumerator enumerator = this.CurrentAttackMsgStruct.TransferEffects.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							string path = enumerator.Current;
							GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>(path));
							UVChainLightning component = gameObject.GetComponent<UVChainLightning>();
							component.start = origin;
							component.target = this.CurrentAttackMsgStruct.Targets[0][0].Target;
							target = this.CurrentAttackMsgStruct.Targets[0][0].Target;
							component.gameObject.SetActive(true);
							if (target != null && target.CardGameObject != null)
							{
								if (target.CardGameObject.DMGPanel.activeInHierarchy)
								{
									target.CardGameObject.DMGText.text = (int.Parse(target.CardGameObject.DMGText.text) + this.DungeonHandler.CheckDmg(msgList[0], target.TempData)).ToString();
									target.CardGameObject.DMGPanel.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
									target.CardGameObject.DMGPanel.transform.DOScale(Vector3.one, 0.1f);
								}
								else
								{
									target.CardGameObject.DMGPanel.SetActive(true);
									target.TempData = new MinionTempData(target);
									target.CardGameObject.DMGText.text = this.DungeonHandler.CheckDmg(msgList[0], target.TempData).ToString();
									target.CardGameObject.DMGPanel.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
									target.CardGameObject.DMGPanel.transform.DOScale(Vector3.one, 0.1f);
								}
							}
							UnityEngine.Object.Destroy(gameObject, 0.2f);
						}
						goto IL_3C1;
					}
				}
				foreach (AttackMsg attackMsg in msgList)
				{
					if (this.CurrentAttackMsgStruct.ShotEffects.Count > 0)
					{
						using (List<string>.Enumerator enumerator = this.CurrentAttackMsgStruct.ShotEffects.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								string shotEffect = enumerator.Current;
								base.StartCoroutine(this.PlayerAttackEffect(origin, attackMsg.Target, 1f, shotEffect, origin.HitEffect, attackMsg));
							}
							continue;
						}
					}
					base.StartCoroutine(this.PlayerAttackEffect(origin, attackMsg.Target, 1f, origin.ShotEffect, origin.HitEffect, attackMsg));
				}
			}
			IL_3C1:
			if (i > 0)
			{
				if (this.CurrentAttackMsgStruct.TransferEffects.Count > 0)
				{
					foreach (string path2 in this.CurrentAttackMsgStruct.TransferEffects)
					{
						GameObject chainGo = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>(path2));
						UVChainLightning component2 = chainGo.GetComponent<UVChainLightning>();
						component2.start = this.CurrentAttackMsgStruct.Targets[i - 1][0].Target;
						target = this.CurrentAttackMsgStruct.Targets[i][0].Target;
						component2.target = this.CurrentAttackMsgStruct.Targets[i][0].Target;
						component2.gameObject.SetActive(true);
						if (target != null && target.CardGameObject != null)
						{
							if (target.CardGameObject.DMGPanel.activeInHierarchy)
							{
								target.CardGameObject.DMGText.text = (int.Parse(target.CardGameObject.DMGText.text) + this.DungeonHandler.CheckDmg(msgList[0], target.TempData)).ToString();
								target.CardGameObject.DMGPanel.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
								target.CardGameObject.DMGPanel.transform.DOScale(Vector3.one, 0.1f);
								yield return new WaitForSeconds(0.1f);
							}
							else
							{
								target.CardGameObject.DMGPanel.SetActive(true);
								target.TempData = new MinionTempData(target);
								target.CardGameObject.DMGText.text = this.DungeonHandler.CheckDmg(msgList[0], target.TempData).ToString();
								target.CardGameObject.DMGPanel.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
								target.CardGameObject.DMGPanel.transform.DOScale(Vector3.one, 0.1f);
								yield return new WaitForSeconds(0.1f);
							}
						}
						UnityEngine.Object.Destroy(chainGo, 0.2f);
						chainGo = null;
					}
					List<string>.Enumerator enumerator3 = default(List<string>.Enumerator);
				}
				else
				{
					foreach (AttackMsg attackMsg2 in msgList)
					{
						if (this.CurrentAttackMsgStruct.ShotEffects.Count > 0)
						{
							using (List<string>.Enumerator enumerator = this.CurrentAttackMsgStruct.ShotEffects.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									string shotEffect2 = enumerator.Current;
									base.StartCoroutine(this.PlayerAttackEffect(origin, attackMsg2.Target, 1f, shotEffect2, origin.HitEffect, attackMsg2));
								}
								continue;
							}
						}
						base.StartCoroutine(this.PlayerAttackEffect(origin, attackMsg2.Target, 1f, origin.ShotEffect, origin.HitEffect, attackMsg2));
					}
				}
			}
			yield return new WaitForSeconds(0.2f);
			msgList = null;
			num = i;
		}
		for (int i = 0; i < this.CurrentAttackMsgStruct.Targets.Count; i = num + 1)
		{
			List<AttackMsg> list = this.CurrentAttackMsgStruct.Targets[i];
			foreach (AttackMsg msg in list)
			{
				Coroutine<int> routine = GlobalController.Instance.StartCoroutine(this.DungeonHandler.ChangeHp(msg, origin));
				yield return routine.coroutine;
				try
				{
					int result = routine.Result;
				}
				catch (Exception ex)
				{
					Debug.LogError(ex.Message);
					Debug.LogError(ex.StackTrace);
				}
				routine = null;
			}
			List<AttackMsg>.Enumerator enumerator4 = default(List<AttackMsg>.Enumerator);
			num = i;
		}
		yield break;
		yield break;
	}

	public IEnumerator CustomizeAttack(CardData originCardData, CardSlotData cardSlotData, int damage, List<CardData> extraTarget = null, int attackTimes = 0, bool isRealDamage = false, int reduceArmor = 0)
	{
		extraTarget = new List<CardData>();
		CardData targetCardData = cardSlotData.ChildCardData;
		attackTimes += originCardData.AttackTimes;
		int num;
		for (int q = 0; q < attackTimes; q = num + 1)
		{
			if (this.CheckCardDead(originCardData) || this.CheckCardDead(targetCardData))
			{
				yield break;
			}
			if (originCardData.AttackExtraRange != null)
			{
				SpaceAreaData dungeonAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
				if (dungeonAreaData != null)
				{
					foreach (Vector3Int vector3Int in originCardData.AttackExtraRange)
					{
						CardSlotData checkedNeighbourSlotData = dungeonAreaData.GetRalitiveCardSlotData(targetCardData.CurrentCardSlotData.GridPositionX, targetCardData.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
						if (checkedNeighbourSlotData != null && checkedNeighbourSlotData.ChildCardData != null && checkedNeighbourSlotData.ChildCardData.HasTag(TagMap.怪物) && !extraTarget.Contains(checkedNeighbourSlotData.ChildCardData))
						{
							yield return this.PlayerAttackEffect(originCardData, checkedNeighbourSlotData.ChildCardData, 0.1f, null, null, null);
							extraTarget.Add(checkedNeighbourSlotData.ChildCardData);
							checkedNeighbourSlotData = null;
						}
					}
					List<Vector3Int>.Enumerator enumerator = default(List<Vector3Int>.Enumerator);
				}
				dungeonAreaData = null;
			}
			yield return this.PlayerAttackEffect(originCardData, targetCardData, 1f, null, null, null);
			foreach (CardData cardData in extraTarget)
			{
				if (!this.CheckCardDead(cardData))
				{
					yield return this.DungeonHandler.ChangeHp(cardData, -damage, originCardData, false, 0, true, false);
				}
			}
			List<CardData>.Enumerator enumerator2 = default(List<CardData>.Enumerator);
			if (!this.CheckCardDead(targetCardData))
			{
				yield return this.DungeonHandler.ChangeHp(targetCardData, -damage, originCardData, isRealDamage, reduceArmor, true, false);
			}
			yield return new WaitForSeconds(0.15f);
			num = q;
		}
		yield break;
		yield break;
	}

	public IEnumerator Hit(CardData originCardData, CardData targetCardData, int Damage, float speed = 0.2f, bool isRealDamage = false, int reduceArmor = 0, string shotEffect = null, string hitEffect = null)
	{
		if (this.CheckCardDead(targetCardData))
		{
			yield break;
		}
		CardSlotData currentCardSlotData = targetCardData.CurrentCardSlotData;
		AttackMsg dmg = new AttackMsg(targetCardData, Damage, isRealDamage, false, reduceArmor, 0, null);
		yield return this.PlayerAttackEffect(originCardData, targetCardData, speed, shotEffect, hitEffect, dmg);
		yield return this.DungeonHandler.ChangeHp(targetCardData, -Damage, originCardData, isRealDamage, reduceArmor, true, false);
		yield break;
	}

	public IEnumerator PlayerAttackEffect(CardData playerCardData, CardData enemyCardData, float speed = 1f, string shotEffect = null, string hitEffect = null, AttackMsg dmg = null)
	{
		if (enemyCardData == null || enemyCardData.HP <= 0)
		{
			yield break;
		}
		if (playerCardData == null || playerCardData.HP <= 0)
		{
			yield break;
		}
		if (shotEffect == null)
		{
			shotEffect = playerCardData.ShotEffect;
		}
		if (hitEffect == null)
		{
			hitEffect = playerCardData.HitEffect;
		}
		CardSlotData cardSlotData = enemyCardData.CurrentCardSlotData;
		if (string.IsNullOrEmpty(shotEffect))
		{
			Vector3 normalized;
			Vector3 localPosition;
			try
			{
				normalized = (enemyCardData.CardGameObject.transform.position - playerCardData.CardGameObject.transform.position).normalized;
				localPosition = playerCardData.CardGameObject.transform.localPosition;
				EffectAudioManager.Instance.PlayEffectAudio(27, null);
			}
			catch (Exception ex)
			{
				Debug.Log(ex.Message);
				Debug.Log(ex.StackTrace);
				yield break;
			}
			yield return DOTween.Sequence().Append(playerCardData.CardGameObject.transform.DOLocalMove(new Vector3(localPosition.x - normalized.x * 0.2f, localPosition.y + 0.3f, localPosition.z - normalized.z * 0.2f), 0.1f * speed, false)).AppendInterval(0.05f * speed).Append(playerCardData.CardGameObject.transform.DOLocalMove(new Vector3(localPosition.x + normalized.x * 0.5f, localPosition.y + 0.3f, localPosition.z + normalized.z * 0.5f), 0.1f * speed, false)).Append(playerCardData.CardGameObject.transform.DOLocalMove(Vector3.zero, 0.1f * speed, false)).WaitForCompletion();
			try
			{
				Camera.main.GetComponent<CameraShake>().StartAnimate(0.1f, 0.1f, false);
				if (dmg != null && enemyCardData != null && enemyCardData.CardGameObject != null)
				{
					if (enemyCardData.CardGameObject.DMGPanel.activeInHierarchy)
					{
						enemyCardData.CardGameObject.DMGText.text = (int.Parse(enemyCardData.CardGameObject.DMGText.text) + this.DungeonHandler.CheckDmg(dmg, enemyCardData.TempData)).ToString();
						enemyCardData.CardGameObject.DMGPanel.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
						enemyCardData.CardGameObject.DMGPanel.transform.DOScale(Vector3.one, 0.1f);
					}
					else
					{
						enemyCardData.CardGameObject.DMGPanel.SetActive(true);
						enemyCardData.TempData = new MinionTempData(enemyCardData);
						enemyCardData.CardGameObject.DMGText.text = this.DungeonHandler.CheckDmg(dmg, enemyCardData.TempData).ToString();
						enemyCardData.CardGameObject.DMGPanel.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
						enemyCardData.CardGameObject.DMGPanel.transform.DOScale(Vector3.one, 0.1f);
					}
				}
				ParticleObject particleObject = ParticlePoolManager.Instance.Spawn(hitEffect, 0.2f);
				if (this.CheckCardDead(enemyCardData))
				{
					particleObject.transform.position = cardSlotData.CardSlotGameObject.transform.position + Vector3.up + Vector3.back * 0.25f;
				}
				else
				{
					particleObject.transform.position = enemyCardData.CardGameObject.transform.position + Vector3.up + Vector3.back * 0.25f;
				}
				if (!particleObject.transform.GetComponent<AudioSource>())
				{
					EffectAudioManager.Instance.PlayEffectAudio(28, null);
				}
				goto IL_6CF;
			}
			catch (Exception ex2)
			{
				Debug.Log(ex2.Message);
				Debug.Log(ex2.StackTrace);
				yield break;
			}
		}
		ParticleObject particleObject2 = ParticlePoolManager.Instance.Spawn(shotEffect, 0.3f);
		try
		{
			particleObject2.transform.position = playerCardData.CardGameObject.transform.position;
			particleObject2.transform.forward = enemyCardData.CardGameObject.transform.position - playerCardData.CardGameObject.transform.position;
			if (!particleObject2.transform.GetComponent<AudioSource>())
			{
				EffectAudioManager.Instance.PlayEffectAudio(27, null);
			}
		}
		catch (Exception ex3)
		{
			Debug.Log(ex3.Message);
			Debug.Log(ex3.StackTrace);
			yield break;
		}
		yield return particleObject2.transform.DOMove(enemyCardData.CardGameObject.transform.position, 0.2f, false).OnComplete(delegate
		{
			Camera.main.GetComponent<CameraShake>().StartAnimate(0.1f, 0.1f, false);
			ParticleObject particleObject3 = ParticlePoolManager.Instance.Spawn(hitEffect, 0.1f);
			if (this.CheckCardDead(enemyCardData))
			{
				if (cardSlotData != null && cardSlotData.CardSlotGameObject != null)
				{
					particleObject3.transform.position = cardSlotData.CardSlotGameObject.transform.position + Vector3.up + Vector3.back * 0.25f;
				}
			}
			else
			{
				particleObject3.transform.position = enemyCardData.CardGameObject.transform.position + Vector3.up + Vector3.back * 0.25f;
			}
			if (!particleObject3.transform.GetComponent<AudioSource>())
			{
				EffectAudioManager.Instance.PlayEffectAudio(28, null);
			}
		}).SetEase(Ease.InCubic).WaitForCompletion();
		IL_6CF:
		if (enemyCardData == null || enemyCardData.HP <= 0)
		{
			yield break;
		}
		yield return DOTween.Sequence().Append(enemyCardData.CardGameObject.transform.DOShakePosition(0.1f, new Vector3(0.25f, 0f, 0.25f), 5, 0f, false, true)).Append(enemyCardData.CardGameObject.transform.DOLocalMove(Vector3.zero, 0.1f * speed, false)).WaitForCompletion();
		yield break;
	}

	public IEnumerator BossAttackEffect(CardData playerCardData, CardData enemyCardData, Vector3 originPos, float speed = 1f, string shotEffect = null, string hitEffect = null, AttackMsg dmg = null)
	{
		if (enemyCardData == null || enemyCardData.HP <= 0)
		{
			yield break;
		}
		if (playerCardData == null || playerCardData.HP <= 0)
		{
			yield break;
		}
		if (shotEffect == null)
		{
			shotEffect = playerCardData.ShotEffect;
		}
		if (hitEffect == null)
		{
			hitEffect = playerCardData.HitEffect;
		}
		CardSlotData cardSlotData = enemyCardData.CurrentCardSlotData;
		if (string.IsNullOrEmpty(shotEffect))
		{
			Vector3 normalized = (enemyCardData.CardGameObject.transform.position - playerCardData.CardGameObject.transform.position).normalized;
			Vector3 localPosition = playerCardData.CardGameObject.transform.localPosition;
			EffectAudioManager.Instance.PlayEffectAudio(27, null);
			yield return DOTween.Sequence().Append(playerCardData.CardGameObject.transform.DOLocalMove(new Vector3(localPosition.x - normalized.x * 0.2f, localPosition.y + 0.3f, localPosition.z - normalized.z * 0.2f), 0.1f * speed, false)).AppendInterval(0.05f * speed).Append(playerCardData.CardGameObject.transform.DOLocalMove(new Vector3(localPosition.x + normalized.x * 0.5f, localPosition.y + 0.3f, localPosition.z + normalized.z * 0.5f), 0.1f * speed, false)).Append(playerCardData.CardGameObject.transform.DOLocalMove(Vector3.zero, 0.1f * speed, false)).WaitForCompletion();
			Camera.main.GetComponent<CameraShake>().StartAnimate(0.1f, 0.1f, false);
			if (dmg != null && enemyCardData != null && enemyCardData.CardGameObject != null)
			{
				if (enemyCardData.CardGameObject.DMGPanel.activeInHierarchy)
				{
					enemyCardData.CardGameObject.DMGText.text = (int.Parse(enemyCardData.CardGameObject.DMGText.text) + this.DungeonHandler.CheckDmg(dmg, enemyCardData.TempData)).ToString();
					enemyCardData.CardGameObject.DMGPanel.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
					enemyCardData.CardGameObject.DMGPanel.transform.DOScale(Vector3.one, 0.1f);
				}
				else
				{
					enemyCardData.CardGameObject.DMGPanel.SetActive(true);
					enemyCardData.TempData = new MinionTempData(enemyCardData);
					enemyCardData.CardGameObject.DMGText.text = this.DungeonHandler.CheckDmg(dmg, enemyCardData.TempData).ToString();
					enemyCardData.CardGameObject.DMGPanel.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
					enemyCardData.CardGameObject.DMGPanel.transform.DOScale(Vector3.one, 0.1f);
				}
			}
			ParticleObject particleObject = ParticlePoolManager.Instance.Spawn(hitEffect, 0.2f);
			if (this.CheckCardDead(enemyCardData))
			{
				particleObject.transform.position = cardSlotData.CardSlotGameObject.transform.position + Vector3.up + Vector3.back * 0.25f;
			}
			else
			{
				particleObject.transform.position = enemyCardData.CardGameObject.transform.position + Vector3.up + Vector3.back * 0.25f;
			}
			if (!particleObject.transform.GetComponent<AudioSource>())
			{
				EffectAudioManager.Instance.PlayEffectAudio(28, null);
			}
		}
		else
		{
			ParticleObject particleObject2 = ParticlePoolManager.Instance.Spawn(shotEffect, 0.3f);
			particleObject2.transform.position = originPos;
			particleObject2.transform.forward = enemyCardData.CardGameObject.transform.position - originPos;
			if (!particleObject2.transform.GetComponent<AudioSource>())
			{
				EffectAudioManager.Instance.PlayEffectAudio(27, null);
			}
			yield return particleObject2.transform.DOMove(enemyCardData.CardGameObject.transform.position, 0.2f, false).OnComplete(delegate
			{
				Camera.main.GetComponent<CameraShake>().StartAnimate(0.1f, 0.1f, false);
				ParticleObject particleObject3 = ParticlePoolManager.Instance.Spawn(hitEffect, 0.1f);
				if (this.CheckCardDead(enemyCardData))
				{
					if (cardSlotData != null && cardSlotData.CardSlotGameObject != null)
					{
						particleObject3.transform.position = cardSlotData.CardSlotGameObject.transform.position + Vector3.up + Vector3.back * 0.25f;
					}
				}
				else
				{
					particleObject3.transform.position = enemyCardData.CardGameObject.transform.position + Vector3.up + Vector3.back * 0.25f;
				}
				if (!particleObject3.transform.GetComponent<AudioSource>())
				{
					EffectAudioManager.Instance.PlayEffectAudio(28, null);
				}
			}).SetEase(Ease.InCubic).WaitForCompletion();
		}
		if (enemyCardData == null || enemyCardData.HP <= 0)
		{
			yield break;
		}
		yield return DOTween.Sequence().Append(enemyCardData.CardGameObject.transform.DOShakePosition(0.1f, new Vector3(0.25f, 0f, 0.25f), 5, 0f, false, true)).Append(enemyCardData.CardGameObject.transform.DOLocalMove(Vector3.zero, 0.1f * speed, false)).WaitForCompletion();
		yield break;
	}

	public IEnumerator EndBattleProcess()
	{
		while (UIController.LockLevel != UIController.UILevel.None)
		{
			yield return null;
		}
		this.BattleTurn = 0;
		try
		{
			UIController.LockLevel = UIController.UILevel.All;
			Camera.main.GetComponent<CameraEffect>().NameText.text = "战斗胜利";
			Camera.main.GetComponent<CameraEffect>().DescText.text = "Victory";
			Camera.main.GetComponent<CameraEffect>().CameraUI.GetComponent<Animator>().SetTrigger("play");
		}
		catch (Exception ex)
		{
			Debug.LogError(ex.Message);
			Debug.LogError(ex.StackTrace);
		}
		yield return new WaitForSeconds(0.5f);
		List<CardSlotData> csl = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
		int colnum = GameController.getInstance().PlayerSlotSets.Count / 3;
		int i = 0;
		while (i < GameController.getInstance().PlayerSlotSets.Count)
		{
			try
			{
				if (GameController.getInstance().PlayerSlotSets[i].ChildCardData == null)
				{
					goto IL_4A4;
				}
				GameController.getInstance().PlayerSlotSets[i].ChildCardData.InBattleATK = 0;
				GameController.getInstance().PlayerSlotSets[i].ChildCardData.InBattleCRIT = 0;
				foreach (KeyValuePair<DungeonAffix, int> keyValuePair in GameController.getInstance().PlayerSlotSets[i].ChildCardData.affixesDic)
				{
					Card cardGameObject = GameController.getInstance().PlayerSlotSets[i].ChildCardData.CardGameObject;
					if (!(cardGameObject == null) && cardGameObject.affixesImg != null && cardGameObject.affixesImg.ContainsKey(keyValuePair.Key))
					{
						UnityEngine.Object.Destroy(cardGameObject.affixesImg[keyValuePair.Key]);
						cardGameObject.affixesImg.Remove(keyValuePair.Key);
					}
				}
			}
			catch (Exception ex2)
			{
				Debug.LogError(ex2.Message);
				Debug.LogError(ex2.StackTrace);
			}
			goto IL_28B;
			IL_4A4:
			int num = i;
			i = num + 1;
			continue;
			IL_28B:
			GameController.getInstance().PlayerSlotSets[i].ChildCardData.affixesDic.Clear();
			CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
			int myColNum = i / colnum;
			for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
			{
				CardLogic cardLogic = slotCardData.CardLogics[i2];
				if (slotCardData.DizzyLayer <= 0 && (cardLogic.Color >= CardLogicColor.white || cardLogic.Color == (CardLogicColor)myColNum))
				{
					if (slotCardData.CurrentCardSlotData == null || slotCardData.CardGameObject == null)
					{
						break;
					}
					if (slotCardData.CardLogics[i2].GetType().GetMethod("OnBattleEnd").DeclaringType == slotCardData.CardLogics[i2].GetType())
					{
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic.OnBattleEnd());
						yield return routine.coroutine;
						try
						{
							int result = routine.Result;
						}
						catch (Exception ex3)
						{
							Debug.LogError(ex3.Message);
							Debug.LogError(ex3.StackTrace);
						}
						routine = null;
					}
				}
				num = i2;
			}
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null && GameController.getInstance().PlayerSlotSets[i].ChildCardData.HasTag(TagMap.衍生物))
			{
				GameController.getInstance().PlayerSlotSets[i].ChildCardData.DeleteCardData();
			}
			slotCardData = null;
			goto IL_4A4;
		}
		foreach (CardSlotData cardSlotData in csl)
		{
			if (this.BattleArea != null && this.BattleArea.Contains(cardSlotData))
			{
				cardSlotData.SlotType = CardSlotData.Type.Freeze;
			}
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.DizzyLayer <= 0)
			{
				CardData slotCardData = cardSlotData.ChildCardData;
				int num;
				for (i = 0; i < slotCardData.CardLogics.Count; i = num + 1)
				{
					CardLogic cardLogic2 = slotCardData.CardLogics[i];
					if (slotCardData.CardLogics[i].GetType().GetMethod("OnBattleEnd").DeclaringType == slotCardData.CardLogics[i].GetType())
					{
						Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic2.OnBattleEnd());
						yield return routine.coroutine;
						try
						{
							int result2 = routine.Result;
						}
						catch (Exception ex4)
						{
							Debug.LogError(ex4.Message);
							Debug.LogError(ex4.StackTrace);
						}
						routine = null;
					}
					num = i;
				}
				slotCardData = null;
			}
		}
		List<CardSlotData>.Enumerator enumerator2 = default(List<CardSlotData>.Enumerator);
		if (GameController.getInstance().GameData.PlayerCardData.CardGameObject == null)
		{
			yield break;
		}
		if (GameController.getInstance().CurrentAct != null && (GameController.getInstance().CurrentAct.GetType() == typeof(EncounterAct) || GameController.getInstance().CurrentAct.GetType() == typeof(TutorialAct)))
		{
			GameAct currentAct = GameController.getInstance().CurrentAct;
			if (currentAct != null)
			{
				currentAct.ActEnd();
			}
		}
		if (GameController.ins.GameData.DungeonTheme != DungeonTheme.Tutorial && GameController.ins.GameData.DungeonTheme != DungeonTheme.Arena && GameController.ins.GameData.isInDungeon)
		{
			ActData actData = new ActData();
			actData.Type = "Act/DungeonRewards";
			actData.Model = "ActTable/营地商店";
			GameController.ins.GameData.PlayerCardData.CardGameObject.StartAct(actData);
		}
		try
		{
			if (GameData.CurrentGameType == GameData.GameType.Normal)
			{
				DungeonOperationMgr.Instance.ShowGrids();
			}
		}
		catch (Exception ex5)
		{
			Debug.LogError(ex5.Message);
			Debug.LogError(ex5.StackTrace);
		}
		Coroutine<int> routine2 = GlobalController.Instance.StartCoroutine(DungeonOperationMgr.Instance.EndTurnProcess(true));
		yield return routine2.coroutine;
		try
		{
			int result3 = routine2.Result;
		}
		catch (Exception ex6)
		{
			Debug.LogError(ex6.Message);
			Debug.LogError(ex6.StackTrace);
		}
		GameController.ins.SaveGame();
		yield break;
		yield break;
	}

	public IEnumerator ShowEnemyAtkLine()
	{
		List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
		foreach (CardSlotData cardSlotData in cardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.怪物))
			{
				Card cardGameObject = cardSlotData.ChildCardData.CardGameObject;
				if (cardGameObject != null)
				{
					CardData aim = this.GetAim(cardSlotData.ChildCardData);
					if (aim != null && aim.CardGameObject != null)
					{
						Card cardGameObject2 = aim.CardGameObject;
						base.StartCoroutine(this.showLine(cardGameObject, aim.CardGameObject.transform));
						yield return null;
					}
				}
			}
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		yield return null;
		yield break;
		yield break;
	}

	private void OnCardPutInSlot(CardSlotData csd, CardData cd)
	{
		if (!cd.HasTag(TagMap.随从))
		{
			cd.HasTag(TagMap.怪物);
		}
	}

	private IEnumerator showLine(Card card, Transform aim)
	{
		if (card.CardData.ATK <= 0)
		{
			yield break;
		}
		if (this.showLineTime == 1)
		{
			this.showLineTime = 2;
		}
		else
		{
			this.showLineTime = 1;
		}
		card.line.enabled = true;
		card.line.useWorldSpace = true;
		card.line.positionCount = 30;
		List<Vector3> bezierListAndDrawBezier = Bezier.GetBezierListAndDrawBezier(card.transform.position, aim.position, 30, 0.2f, 5f, false);
		card.line.SetPositions(bezierListAndDrawBezier.ToArray());
		Color2 startColor;
		Color2 endColor;
		switch (card.CardData.AttackColor)
		{
		case 0:
			startColor = new Color2(new Color(1f, 1f, 1f, 0f), new Color(1f, 1f, 1f, 0f));
			endColor = new Color2(new Color(1f, 1f, 1f, 0.6f), new Color(1f, 1f, 1f, 0.6f));
			break;
		case 1:
			startColor = new Color2(new Color(0f, 1f, 1f, 0f), new Color(0f, 1f, 1f, 0f));
			endColor = new Color2(new Color(0f, 1f, 1f, 0.6f), new Color(0f, 1f, 1f, 0.6f));
			break;
		case 2:
			startColor = new Color2(new Color(1f, 0f, 0f, 0f), new Color(1f, 0f, 0f, 0f));
			endColor = new Color2(new Color(1f, 0f, 0f, 0.6f), new Color(1f, 0f, 0f, 0.6f));
			break;
		case 3:
			startColor = new Color2(new Color(0f, 0f, 1f, 0f), new Color(0f, 0f, 1f, 0f));
			endColor = new Color2(new Color(0f, 0f, 1f, 0.6f), new Color(0f, 0f, 1f, 0.6f));
			break;
		default:
			startColor = new Color2(new Color(1f, 1f, 1f, 0f), new Color(1f, 1f, 1f, 0f));
			endColor = new Color2(new Color(1f, 1f, 1f, 0.6f), new Color(1f, 1f, 1f, 0.6f));
			break;
		}
		yield return card.line.DOColor(startColor, endColor, 0.2f).WaitForCompletion();
		yield return new WaitForSeconds(0.5f);
		if (this.showLineTime == 1)
		{
			yield return card.line.DOColor(endColor, startColor, 0.2f).WaitForCompletion();
		}
		else
		{
			this.showLineTime = 1;
		}
		if (this.showLineTime == 1)
		{
			this.showLineTime = 0;
			card.line.enabled = false;
		}
		yield break;
	}

	public bool CheckCardDead(CardData cardData)
	{
		return cardData == null || cardData.HP <= 0;
	}

	public List<CardData> GetCardDataNearBy(CardData origin, List<Vector3Int> dirs)
	{
		List<CardData> list = new List<CardData>();
		if (this.CheckCardDead(origin))
		{
			return list;
		}
		if (origin.HasTag(TagMap.怪物) && this.BattleArea.Contains(origin.CurrentCardSlotData))
		{
			SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
			using (List<Vector3Int>.Enumerator enumerator = dirs.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Vector3Int vector3Int = enumerator.Current;
					CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(origin.CurrentCardSlotData.GridPositionX, origin.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
					if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && ralitiveCardSlotData.ChildCardData != null)
					{
						list.Add(ralitiveCardSlotData.ChildCardData);
					}
				}
				return list;
			}
		}
		if (origin.HasTag(TagMap.随从) && this.PlayerBattleArea.Contains(origin.CurrentCardSlotData))
		{
			int num = this.PlayerBattleArea.IndexOf(origin.CurrentCardSlotData);
			foreach (Vector3Int vector3Int2 in dirs)
			{
				if (((num != 0 && num != 3 && num != 6) || vector3Int2.x >= 0) && ((num != 2 && num != 5 && num != 8) || vector3Int2.x <= 0))
				{
					int num2 = num + vector3Int2.x + vector3Int2.y * 3;
					if (num2 >= 0 && num2 < this.PlayerBattleArea.Count && this.PlayerBattleArea[num2] != null && this.PlayerBattleArea[num2].ChildCardData != null && !this.CheckCardDead(this.PlayerBattleArea[num2].ChildCardData))
					{
						list.Add(this.PlayerBattleArea[num2].ChildCardData);
					}
				}
			}
		}
		return list;
	}

	public CardLogic GetLogic(CardData cd, Type type)
	{
		foreach (CardLogic cardLogic in cd.CardLogics)
		{
			if (cardLogic.GetType() == type)
			{
				return cardLogic;
			}
		}
		return null;
	}

	public void SetLockOperation(bool value)
	{
		this.IsOperationLocked = value;
	}

	public static DungeonAffixInfoAttribute GetDungeonAffixInfo(DungeonAffix affix)
	{
		if (DungeonOperationMgr.dungeonAffixAttributesDic == null)
		{
			DungeonOperationMgr.dungeonAffixAttributesDic = new Dictionary<DungeonAffix, DungeonAffixInfoAttribute>();
			Type typeFromHandle = typeof(DungeonAffix);
			foreach (object obj in Enum.GetValues(typeFromHandle))
			{
				DungeonAffixInfoAttribute value = (DungeonAffixInfoAttribute)Attribute.GetCustomAttribute(typeFromHandle.GetMember(obj.ToString())[0], typeof(DungeonAffixInfoAttribute));
				DungeonOperationMgr.dungeonAffixAttributesDic.Add((DungeonAffix)obj, value);
			}
		}
		DungeonAffixInfoAttribute result = null;
		DungeonOperationMgr.dungeonAffixAttributesDic.TryGetValue(affix, out result);
		return result;
	}

	public IEnumerator UsageArms(CardData origin, CardData target)
	{
		int x = origin.CurrentCardSlotData.GridPositionX;
		int y = origin.CurrentCardSlotData.GridPositionY;
		foreach (CardSlotData cardSlotData in this.PlayerBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.装备))
			{
				if ((cardSlotData.ChildCardData.ArmsUsagePosition & ArmsUsagePositionType.Left) == ArmsUsagePositionType.Left && cardSlotData.GridPositionX - x == 1 && cardSlotData.GridPositionY == y)
				{
					yield return this.ArmsAttackProcess(origin, target, cardSlotData.ChildCardData);
				}
				else if ((cardSlotData.ChildCardData.ArmsUsagePosition & ArmsUsagePositionType.Right) == ArmsUsagePositionType.Right && cardSlotData.GridPositionX - x == -1 && cardSlotData.GridPositionY == y)
				{
					yield return this.ArmsAttackProcess(origin, target, cardSlotData.ChildCardData);
				}
				else if ((cardSlotData.ChildCardData.ArmsUsagePosition & ArmsUsagePositionType.Top) == ArmsUsagePositionType.Top && cardSlotData.GridPositionY - y == -1 && cardSlotData.GridPositionX == x)
				{
					yield return this.ArmsAttackProcess(origin, target, cardSlotData.ChildCardData);
				}
				else if ((cardSlotData.ChildCardData.ArmsUsagePosition & ArmsUsagePositionType.Bottom) == ArmsUsagePositionType.Bottom && cardSlotData.GridPositionY - y == 1 && cardSlotData.GridPositionX == x)
				{
					yield return this.ArmsAttackProcess(origin, target, cardSlotData.ChildCardData);
				}
			}
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		yield return null;
		yield break;
		yield break;
	}

	public IEnumerator ArmsAttackProcess(CardData origin, CardData target, CardData arms)
	{
		int i = 0;
		while (i < arms.AttackTimes && !this.CheckCardDead(target) && !this.CheckCardDead(arms))
		{
			Vector3 startPos = arms.CardGameObject.DisplayGameObjectOnPlayerTable.transform.position;
			yield return arms.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DOJump(origin.CardGameObject.transform.position + Vector3.up * 0.3f, 1f, 1, 0.2f, false).WaitForCompletion();
			arms.CardGameObject.DisplayGameObjectOnPlayerTable.transform.forward = target.CardGameObject.transform.position - origin.CardGameObject.transform.position;
			yield return arms.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DOMove(target.CardGameObject.transform.position, 0.2f, false).SetEase(Ease.InExpo).WaitForCompletion();
			bool IsOverride = false;
			int num;
			for (int j = arms.CardLogics.Count - 1; j >= 0; j = num - 1)
			{
				if (arms.CardLogics[j].GetType().GetMethod("OnUserAsArms").DeclaringType == arms.CardLogics[j].GetType())
				{
					IsOverride = true;
					Coroutine<int> routine = GlobalController.Instance.StartCoroutine(arms.CardLogics[j].OnUserAsArms(origin, target));
					yield return routine.coroutine;
					try
					{
						int result = routine.Result;
					}
					catch (Exception ex)
					{
						Debug.LogError(ex.Message);
						Debug.LogError(ex.StackTrace);
					}
					routine = null;
				}
				num = j;
			}
			if (!IsOverride)
			{
				ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/animal_scratch_1", 0.2f);
				target.CardGameObject.transform.DOShakePosition(0.2f, 1f, 10, 90f, false, true);
				if (!this.CheckCardDead(target))
				{
					particleObject.transform.position = target.CardGameObject.transform.position + Vector3.up + Vector3.back * 0.25f;
				}
				yield return this.DungeonHandler.ChangeHp(target, -arms.ATK, origin, false, 0, true, false);
			}
			yield return arms.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DOMove(startPos, 0.2f, false).SetEase(Ease.OutExpo).WaitForCompletion();
			arms.UsageTimes--;
			if (arms.UsageTimes < 0)
			{
				arms.DeleteCardData();
			}
			else
			{
				arms.IsAttacked = true;
			}
			yield return null;
			startPos = default(Vector3);
			num = i;
			i = num + 1;
		}
		yield break;
	}

	private bool CheckIsCanLove(Type type, CardData data, string targetID)
	{
		if (type != typeof(Logic_AiShangLe))
		{
			return true;
		}
		foreach (CardLogic cardLogic in data.CardLogics)
		{
			if ((cardLogic.GetType() == typeof(Logic_AiShangLe) || cardLogic.GetType() == typeof(Logic_JieHun)) && ((TwoPeopleCardLogic)cardLogic).TargetID == targetID)
			{
				return false;
			}
		}
		return true;
	}

	public void PlayLightningEffect(List<CardData> targets)
	{
		if (targets == null || targets.Count == 0)
		{
			return;
		}
		foreach (CardData cardData in targets)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				this.GetChainLighting(cardData.CardGameObject.transform.position + new Vector3(0f, 3f, 0f), cardData.CardGameObject.transform.position, 1);
			}
		}
	}

	public void PlayCureEffect(List<CardData> targets)
	{
		if (targets == null || targets.Count == 0)
		{
			return;
		}
		foreach (CardData cardData in targets)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				string name = "Effect/HealHp";
				ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = cardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
			}
		}
	}

	public void PlayVitalityEffect(List<CardData> targets)
	{
		if (targets == null || targets.Count == 0)
		{
			return;
		}
		foreach (CardData cardData in targets)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				string name = "Effect/Vitality";
				ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = cardData.CardGameObject.transform.position + new Vector3(0f, 0.3f, 0f);
			}
		}
	}

	private void GetChainLighting(Vector3 from, Vector3 to, int duration = 1)
	{
		ChainLightningByVector3 component = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Effect/ChainLightingByVector3")).GetComponent<ChainLightningByVector3>();
		component.start = from;
		component.target = to;
		component.gameObject.SetActive(true);
	}

	public IEnumerator TryToOpenDoor(CardSlotData targetCardSlotData)
	{
		UIController.LockLevel = (UIController.UILevel.PlayerSlot | UIController.UILevel.AreaTable);
		if (targetCardSlotData.ChildCardData == null || !(targetCardSlotData.ChildCardData.ModID == "门"))
		{
			yield return null;
			yield break;
		}
		GameAct act = targetCardSlotData.ChildCardData.CardGameObject.StartAct(targetCardSlotData.ChildCardData.ActDatas[0]);
		while (GameController.getInstance().CurrentAct != null)
		{
			yield return 0;
		}
		UIController.LockLevel = UIController.UILevel.None;
		if ((act as DoorAct).IsOpen)
		{
			DungeonOperationMgr.Instance.CurrentPositionInMap = targetCardSlotData;
			DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.ChessmanJumpAndShowSlot(true, true, null));
			yield break;
		}
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
	}

	public IEnumerator TryToOpenBox(CardSlotData targetCardSlotData)
	{
		UIController.LockLevel = (UIController.UILevel.PlayerSlot | UIController.UILevel.AreaTable);
		if (targetCardSlotData.ChildCardData == null || !(targetCardSlotData.ChildCardData.ModID == "宝箱"))
		{
			yield return null;
			yield break;
		}
		GameAct act = targetCardSlotData.ChildCardData.CardGameObject.StartAct(targetCardSlotData.ChildCardData.ActDatas[0]);
		while (GameController.getInstance().CurrentAct != null)
		{
			yield return 0;
		}
		UIController.LockLevel = UIController.UILevel.None;
		if ((act as ChestAct).IsOpen)
		{
			DungeonOperationMgr.Instance.CurrentPositionInMap = targetCardSlotData;
			DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.ChessmanJumpAndShowSlot(true, true, null));
			yield break;
		}
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
	}

	public static List<Vector2Int> Default4Coordinates = new List<Vector2Int>
	{
		Vector2Int.left,
		Vector2Int.right,
		Vector2Int.up,
		Vector2Int.down
	};

	public DungeonHandler DungeonHandler = new DungeonHandler();

	public bool IsWinCurrentFloor;

	public bool IsInBattle;

	private static GameObject m_ChainPrefab;

	private static DungeonOperationMgr m_Instance;

	public CardSlotData CurrentPositionInMap;

	public List<CardSlotData> BattleArea;

	public List<CardSlotData> PlayerBattleArea;

	public List<CardSlotData> MapArea;

	[NonSerialized]
	public float TotalDATK = 0.0006f;

	[NonSerialized]
	public float TotalDHp = 0.0012f;

	[NonSerialized]
	public float AgreementDATK = 0.07f;

	[NonSerialized]
	public float AgreementDHp = 0.15f;

	[NonSerialized]
	public float TotalDArmor = 0.1f;

	public float TotalATK = 1f;

	public float TotalHp = 1f;

	public float TotalArmor = 1f;

	public float EndlessTotalDATK = 0.7f;

	public float EndlessTotalDHp = 0.8f;

	public float EndlessTotalDArmor = 0.7f;

	public float EndlessTotalATK = 0.7f;

	public float EndlessTotalHp = 0.8f;

	public float EndlessTotalArmor = 0.7f;

	public List<string> CurrentRewards;

	public List<float> CurrentRewardsRadio;

	public bool IsCoopMode;

	public bool IsVSMode;

	public AttackMsgStruct CurrentAttackMsgStruct;

	public List<IEnumerator> RandomJournalsProcessList = new List<IEnumerator>();

	public int EnemyDifficult;

	private const string c_HellHpBallEffectPath = "Effect/HellHpBall";

	private const string c_HellMpBallEffectPath = "Effect/HellMpBall";

	private const string c_SmallHellEffectPath = "Effect/SmallHell";

	private const string c_DamagedEffectPath = "Effect/BeAttack";

	private const string c_SlashEffectPath = "Effect/Attack";

	public int CurrentBattleDifficult;

	private const int c_PathSegmentNum = 10;

	private const float c_HellBallSpeed = 10f;

	private const float c_MinHellBallCreateInterval = 0.01f;

	private const float c_MaxHellBallCreateInterval = 0.02f;

	private Queue<IEnumerator> ProccesBatchQueue;

	private bool isProcces;

	public AreaData CurrentAreaData;

	public float MoneyRate = 1f;

	public float MoneyAddition = 1f;

	public int BattleTurn;

	public bool IsEventBattle;

	public int GainsYellowPointInEventBattle;

	public int GainsRedPointInEventBattle;

	public int GainsBluePointInEventBattle;

	public string CurrentTerrain = "";

	public string EliteGift = "";

	private Dictionary<CardData, object[]> minionsStateDic = new Dictionary<CardData, object[]>();

	public bool IsInBattelSync;

	private const float c_TurnIntervalTime = 0.1f;

	private const float c_MonsterAttactStartTime = 0.1f;

	private const float c_MonsterAttactStartIntervalTime = 0.05f;

	private const float c_MonsterAttackToTime = 0.1f;

	private const float c_MonsterAttackBackTime = 0.1f;

	private const float c_SlashEffectSpeed = 10f;

	private const float c_SlashMaxTime = 2f;

	private const float c_MonsterDamagedTime = 0.1f;

	private const float c_MonsterShakeTime = 0.1f;

	private int showLineTime;

	public static Dictionary<DungeonAffix, DungeonAffixInfoAttribute> dungeonAffixAttributesDic;
}
