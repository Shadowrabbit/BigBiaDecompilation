using System;

public class GameEventManager
{
	public event GameEventManager.OnDayPass OnGameStartEvent;

	public void GameStart()
	{
		GameEventManager.OnDayPass onGameStartEvent = this.OnGameStartEvent;
		if (onGameStartEvent == null)
		{
			return;
		}
		onGameStartEvent();
	}

	public event GameEventManager.OnDayPass OnSaveGameEvent;

	public void SaveGame()
	{
		GameEventManager.OnDayPass onSaveGameEvent = this.OnSaveGameEvent;
		if (onSaveGameEvent == null)
		{
			return;
		}
		onSaveGameEvent();
	}

	public event GameEventManager.OnDayPass OnTickEvent;

	public void Tick()
	{
		GameEventManager.OnDayPass onTickEvent = this.OnTickEvent;
		if (onTickEvent == null)
		{
			return;
		}
		onTickEvent();
	}

	public event GameEventManager.OnDayPass OnDayPassEvent;

	public void DayPass()
	{
		GameController.getInstance().GameData.Days++;
		GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_44"), 1f, 2f, 1f, 1f);
		GameEventManager.OnDayPass onDayPassEvent = this.OnDayPassEvent;
		if (onDayPassEvent == null)
		{
			return;
		}
		onDayPassEvent();
	}

	public event GameEventManager.OnMoneyChange OnMoneyChangeEvent;

	public void MoneyChange(int deltaMoney)
	{
		GameEventManager.OnMoneyChange onMoneyChangeEvent = this.OnMoneyChangeEvent;
		if (onMoneyChangeEvent == null)
		{
			return;
		}
		onMoneyChangeEvent(deltaMoney);
	}

	public event GameEventManager.OnCardChangeSlot OnCardChangeSlotEvent;

	public void CardChangeSlot(CardSlot oldCardSlot, CardSlot newCardSlot, Card card)
	{
		GameEventManager.OnCardChangeSlot onCardChangeSlotEvent = this.OnCardChangeSlotEvent;
		if (onCardChangeSlotEvent == null)
		{
			return;
		}
		onCardChangeSlotEvent(oldCardSlot, newCardSlot, card);
	}

	public event GameEventManager.OnCardDataChangeSlot OnCardDataChangeSlotEvent;

	public void CardDataChangeSlot(CardSlotData oldCardSlot, CardSlotData newCardSlot, CardData card)
	{
		GameEventManager.OnCardDataChangeSlot onCardDataChangeSlotEvent = this.OnCardDataChangeSlotEvent;
		if (onCardDataChangeSlotEvent == null)
		{
			return;
		}
		onCardDataChangeSlotEvent(oldCardSlot, newCardSlot, card);
	}

	public event Action<string, int> OnItemBeCollectedEvent;

	public void ItemBeCollectied(string name, int count)
	{
		Action<string, int> onItemBeCollectedEvent = this.OnItemBeCollectedEvent;
		if (onItemBeCollectedEvent == null)
		{
			return;
		}
		onItemBeCollectedEvent(name, count);
	}

	public event Action<CardData> OnRoleBeRecruitEvent;

	public void RoleBeRecruit(CardData target)
	{
		Action<CardData> onRoleBeRecruitEvent = this.OnRoleBeRecruitEvent;
		if (onRoleBeRecruitEvent == null)
		{
			return;
		}
		onRoleBeRecruitEvent(target);
	}

	public event Action<CardData, CardData> OnMerByEvent;

	public void OnMerBy(CardData target, CardData from)
	{
		Action<CardData, CardData> onMerByEvent = this.OnMerByEvent;
		if (onMerByEvent == null)
		{
			return;
		}
		onMerByEvent(target, from);
	}

	public event GameEventManager.OnCurrentActStart OnCurrentActStartEvent;

	public void CurrentActStart()
	{
		GameEventManager.OnCurrentActStart onCurrentActStartEvent = this.OnCurrentActStartEvent;
		if (onCurrentActStartEvent == null)
		{
			return;
		}
		onCurrentActStartEvent();
	}

	public event GameEventManager.OnCurrentActEnd OnCurrentActEndEvent;

	public void CurrentActEnd()
	{
		GameEventManager.OnCurrentActEnd onCurrentActEndEvent = this.OnCurrentActEndEvent;
		if (onCurrentActEndEvent == null)
		{
			return;
		}
		onCurrentActEndEvent();
	}

	public event GameEventManager.OnClickCardHandler OnClickACardEvent;

	public void OnClickCard(Card target)
	{
		GameEventManager.OnClickCardHandler onClickACardEvent = this.OnClickACardEvent;
		if (onClickACardEvent == null)
		{
			return;
		}
		onClickACardEvent(target);
	}

	public event GameEventManager.OnWorldMove OnWorldMoveEvent;

	public void WorldMove(string ob)
	{
		GameEventManager.OnWorldMove onWorldMoveEvent = this.OnWorldMoveEvent;
		if (onWorldMoveEvent == null)
		{
			return;
		}
		onWorldMoveEvent(ob);
	}

	public event Action<string> OnEnterAreaEvent;

	public void EnterArea(string areaId)
	{
		Action<string> onEnterAreaEvent = this.OnEnterAreaEvent;
		if (onEnterAreaEvent == null)
		{
			return;
		}
		onEnterAreaEvent(areaId);
	}

	public event Action<string> OnPreExitAreaEvent;

	public void ExitArea(string areaId)
	{
		Action<string> onPreExitAreaEvent = this.OnPreExitAreaEvent;
		if (onPreExitAreaEvent == null)
		{
			return;
		}
		onPreExitAreaEvent(areaId);
	}

	public event GameEventManager.OnLogUpdate OnLogUpdateEvent;

	public void LogUpdate(LogBean log)
	{
		GameEventManager.OnLogUpdate onLogUpdateEvent = this.OnLogUpdateEvent;
		if (onLogUpdateEvent == null)
		{
			return;
		}
		onLogUpdateEvent(log);
	}

	public event Action<string> OnNewLogUpDate;

	public void NewLogUpdate(string content)
	{
		Action<string> onNewLogUpDate = this.OnNewLogUpDate;
		if (onNewLogUpDate == null)
		{
			return;
		}
		onNewLogUpDate(content);
	}

	public void OpenGameUI()
	{
		Action onOpenGameUI = this.OnOpenGameUI;
		if (onOpenGameUI == null)
		{
			return;
		}
		onOpenGameUI();
	}

	public event Action<string> OnTaskStateChangedEvent;

	public void TaskStateChanged(string taskName)
	{
		Action<string> onTaskStateChangedEvent = this.OnTaskStateChangedEvent;
		if (onTaskStateChangedEvent == null)
		{
			return;
		}
		onTaskStateChangedEvent(taskName);
	}

	public event Action<string, int> OnTaskStepStateChangedEvent;

	public void TaskStepStateChanged(string taskName, int index)
	{
		Action<string, int> onTaskStepStateChangedEvent = this.OnTaskStepStateChangedEvent;
		if (onTaskStepStateChangedEvent == null)
		{
			return;
		}
		onTaskStepStateChangedEvent(taskName, index);
	}

	public event Action<string> OnTaskSettleEvent;

	public void TaskSettle(string taskName)
	{
		Action<string> onTaskSettleEvent = this.OnTaskSettleEvent;
		if (onTaskSettleEvent == null)
		{
			return;
		}
		onTaskSettleEvent(taskName);
	}

	public event Action<string, int> OnBattleRecordDamageDealtEvent;

	public void BattleRecordDamageDealt(string name, int amount)
	{
		Action<string, int> onBattleRecordDamageDealtEvent = this.OnBattleRecordDamageDealtEvent;
		if (onBattleRecordDamageDealtEvent == null)
		{
			return;
		}
		onBattleRecordDamageDealtEvent(name, amount);
	}

	public event GameEventManager.OnMakeListButtonClick OnMakeListButtonClickEvent;

	public void MakeListButtonClick(CardData data)
	{
		GameEventManager.OnMakeListButtonClick onMakeListButtonClickEvent = this.OnMakeListButtonClickEvent;
		if (onMakeListButtonClickEvent == null)
		{
			return;
		}
		onMakeListButtonClickEvent(data);
	}

	public event Action<TaskData> OnEarlyProcessTaskEvent;

	public void EarlyProcessTask(TaskData task)
	{
		Action<TaskData> onEarlyProcessTaskEvent = this.OnEarlyProcessTaskEvent;
		if (onEarlyProcessTaskEvent == null)
		{
			return;
		}
		onEarlyProcessTaskEvent(task);
	}

	public event Action<float> OnDeltaTimeScaleChange;

	public void ChangeDeltaTime(float value)
	{
		Action<float> onDeltaTimeScaleChange = this.OnDeltaTimeScaleChange;
		if (onDeltaTimeScaleChange == null)
		{
			return;
		}
		onDeltaTimeScaleChange(value);
	}

	public void CardPutInSlot(CardSlotData sourceSlot, CardData cardData)
	{
		Action<CardSlotData, CardData> onCardPutInSlot = this.OnCardPutInSlot;
		if (onCardPutInSlot == null)
		{
			return;
		}
		onCardPutInSlot(sourceSlot, cardData);
	}

	public void CardFlipAction(AreaData ad, CardSlotData csd)
	{
		Action<AreaData, CardSlotData> onCardFliped = this.OnCardFliped;
		if (onCardFliped == null)
		{
			return;
		}
		onCardFliped(ad, csd);
	}

	public void BeforeAttackAction(CardData origin, CardData target)
	{
		Action<CardData, CardData> onBeforeAttack = this.OnBeforeAttack;
		if (onBeforeAttack == null)
		{
			return;
		}
		onBeforeAttack(origin, target);
	}

	public void AfterAttackAction(CardData origin, CardData target)
	{
		Action<CardData, CardData> onAfterAttack = this.OnAfterAttack;
		if (onAfterAttack == null)
		{
			return;
		}
		onAfterAttack(origin, target);
	}

	public void StartTalking()
	{
		Action onStartTalkingEvent = this.OnStartTalkingEvent;
		if (onStartTalkingEvent == null)
		{
			return;
		}
		onStartTalkingEvent();
	}

	public void EnterAllShopAndTavern()
	{
		Action onEnterAllShopAndTavernEvent = this.OnEnterAllShopAndTavernEvent;
		if (onEnterAllShopAndTavernEvent == null)
		{
			return;
		}
		onEnterAllShopAndTavernEvent();
	}

	public void EnterCamp()
	{
		Action onEnterCampEvent = this.OnEnterCampEvent;
		if (onEnterCampEvent == null)
		{
			return;
		}
		onEnterCampEvent();
	}

	public Action OnOpenGameUI;

	public Action<CardSlotData, CardData> OnCardPutInSlot;

	public Action<AreaData, CardSlotData> OnCardFliped;

	public Action<CardData, CardData> OnBeforeAttack;

	public Action<CardData, CardData> OnAfterAttack;

	public Action OnStartTalkingEvent;

	public Action OnEnterAllShopAndTavernEvent;

	public Action OnEnterCampEvent;

	public delegate void OnGameStart();

	public delegate void OnSaveGame();

	public delegate void OnTick();

	public delegate void OnDayPass();

	public delegate void OnMoneyChange(int deltaMoney);

	public delegate void OnCardChangeSlot(CardSlot oldCardSlot, CardSlot newCardSlot, Card card);

	public delegate void OnCardDataChangeSlot(CardSlotData oldCardSlot, CardSlotData newCardSlot, CardData card);

	public delegate void OnAreaArrived(string name);

	public delegate void OnCurrentActStart();

	public delegate void OnCurrentActEnd();

	public delegate void OnClickCardHandler(Card target);

	public delegate void OnWorldMove(string ob);

	public delegate void OnLogUpdate(LogBean log);

	public delegate void OnMakeListButtonClick(CardData data);
}
