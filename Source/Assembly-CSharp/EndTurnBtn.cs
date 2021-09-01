using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using PixelCrushers.DialogueSystem;
using Steamworks;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndTurnBtn : MonoBehaviour
{
	private void Start()
	{
	}

	private void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		if (!DungeonOperationMgr.Instance.IsInBattle && GameData.CurrentGameType == GameData.GameType.Normal)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_40"), 1f, 2f, 1f, 1f);
			return;
		}
		if (this.isClick)
		{
			return;
		}
		if (GameController.ins.GameData.CurrentAreaId == "入场选择")
		{
			if (!GameController.ins.UIController.IsCanEndTurn)
			{
				return;
			}
			if (DungeonController.Instance.IsSelectedMinionAndScenes)
			{
				DungeonController.Instance.IsSelectedMinionAndScenes = false;
				AreaData areaData = GameController.getInstance().GameData.AreaMap[GameController.ins.GameData.DungeonArea[0].Attrs["AreaDataID"].ToString()];
				areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
				GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
				GameController.getInstance().OnTableChange(areaData, true);
				return;
			}
			if (GameController.getInstance().GameData.isInDungeon)
			{
				this.isClick = true;
				base.StartCoroutine(this.GameVictoryInDungeonBattle());
				return;
			}
			bool flag = false;
			foreach (CardSlotData cardSlotData in GameController.ins.PlayerSlotSets)
			{
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				DungeonController.Instance.StartNewDungeon();
				AreaData areaData2 = GameController.getInstance().GameData.AreaMap[GameController.ins.GameData.DungeonArea[0].Attrs["AreaDataID"].ToString()];
				areaData2.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
				GameController.getInstance().GameEventManager.EnterArea(areaData2.Name);
				GameController.getInstance().OnTableChange(areaData2, true);
				return;
			}
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_41"), 1f, 2f, 1f, 1f);
			return;
		}
		else
		{
			if (MultiPlayerController.Instance != null)
			{
				CSteamID currentLobbyID = MultiPlayerController.Instance.CurrentLobbyID;
				if (MultiPlayerController.Instance.GameState == MultiPlayerController.GameStateType.P1Turn && MultiPlayerController.Instance.MyIdentity == MultiPlayerController.Identity.Host)
				{
					MultiPlayerController.Instance.StateChange(MultiPlayerController.GameStateType.P2Turn);
					base.StartCoroutine(this.endTurn(false));
				}
				else if (MultiPlayerController.Instance.GameState == MultiPlayerController.GameStateType.P2Turn && MultiPlayerController.Instance.MyIdentity == MultiPlayerController.Identity.Client)
				{
					MultiPlayerController.Instance.StateChange(MultiPlayerController.GameStateType.StartBattleSync);
					base.StartCoroutine(this.endTurn(false));
				}
				if (MultiPlayerController.Instance.GameState != MultiPlayerController.GameStateType.StartBattleSync || MultiPlayerController.Instance.MyIdentity != MultiPlayerController.Identity.Client)
				{
					base.StartCoroutine(this.FadeCoroutine());
				}
				return;
			}
			if (VSModeController.Instance != null)
			{
				CSteamID currentLobbyID2 = VSModeController.Instance.CurrentLobbyID;
				if (VSModeController.Instance.GameState == VSModeController.GameStateType.P1Turn && VSModeController.Instance.MyIdentity == VSModeController.Identity.Host)
				{
					VSModeController.Instance.StateChange(VSModeController.GameStateType.P1BattleTurn);
					VSModeController.Instance.IsInBattle = true;
					VSModeController.Instance.IsOPInBattle = true;
					base.StartCoroutine(DungeonOperationMgr.Instance.VSModeEndTurnProcess(true));
					return;
				}
				if (VSModeController.Instance.GameState == VSModeController.GameStateType.P2Turn && VSModeController.Instance.MyIdentity == VSModeController.Identity.Client)
				{
					VSModeController.Instance.StateChange(VSModeController.GameStateType.P2BattleTurn);
					VSModeController.Instance.IsInBattle = true;
					VSModeController.Instance.IsOPInBattle = true;
					base.StartCoroutine(DungeonOperationMgr.Instance.VSModeEndTurnProcess(true));
					return;
				}
				base.StartCoroutine(this.FadeCoroutine());
				return;
			}
			else
			{
				if (UIController.LockLevel == UIController.UILevel.None && ((DungeonOperationMgr.Instance.BattleArea != null && DungeonOperationMgr.Instance.IsInBattle) || DungeonOperationMgr.Instance.BattleArea == null) && !GameController.getInstance().CurrentArea.name.Equals("营地"))
				{
					base.StartCoroutine(this.endTurn(true));
					return;
				}
				if (GameData.CurrentGameType == GameData.GameType.Endless && !DungeonOperationMgr.Instance.IsInBattle)
				{
					base.StartCoroutine(this.MoveInEndlessMode());
					return;
				}
				base.StartCoroutine(this.FadeCoroutine());
				return;
			}
		}
	}

	private IEnumerator endTurn(bool doEndTurnProcess = true)
	{
		if (this.isClick)
		{
			yield break;
		}
		this.isClick = true;
		base.GetComponent<Animator>().SetTrigger("play");
		EffectAudioManager.Instance.PlayEffectAudio(21, null);
		if (DungeonOperationMgr.Instance.IsEventBattle)
		{
			DungeonOperationMgr.Instance.EndEventBattle();
			Sequencer.Message("JudgeEnd");
			UIController.LockLevel = UIController.UILevel.AreaTable;
		}
		if (doEndTurnProcess)
		{
			yield return DungeonOperationMgr.Instance.EndTurnProcess(false);
		}
		this.isClick = false;
		yield break;
	}

	private IEnumerator FadeCoroutine()
	{
		GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_42"), 1f, 2f, 1f, 1f);
		GameObject copyGo = UnityEngine.Object.Instantiate<GameObject>(base.gameObject);
		copyGo.transform.SetParent(base.transform.parent);
		copyGo.transform.localPosition = base.transform.localPosition;
		copyGo.transform.localScale = base.transform.localScale;
		UnityEngine.Object.Destroy(copyGo.GetComponent<EndTurnBtn>());
		new FadeModel(copyGo, 0.5f).HideModel();
		copyGo.transform.DOScale(Vector3.one * 3f, 0.5f).OnComplete(delegate
		{
			UnityEngine.Object.Destroy(copyGo);
		});
		yield break;
	}

	private IEnumerator GameVictoryInDungeonBattle()
	{
		SelectAreaAllSlotsController allSlotsCtrl = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().GetComponentInChildren<SelectAreaAllSlotsController>();
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardData> myMinions = new List<CardData>();
		List<CardData> myItems = new List<CardData>();
		List<CardData> myMagics = new List<CardData>();
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null)
			{
				if (cardSlotData.ChildCardData.HasTag(TagMap.随从))
				{
					myMinions.Add(cardSlotData.ChildCardData);
				}
				if (cardSlotData.ChildCardData.HasTag(TagMap.道具))
				{
					myItems.Add(cardSlotData.ChildCardData);
				}
				if (cardSlotData.ChildCardData.HasTag(TagMap.装备))
				{
					myMagics.Add(cardSlotData.ChildCardData);
				}
			}
		}
		List<CardSlotData> curEmptyMinionSlots = new List<CardSlotData>();
		foreach (CardSlot cardSlot in allSlotsCtrl.AllMinionSlots)
		{
			if (cardSlot.CardSlotData.ChildCardData == null && cardSlot.CardSlotData.SlotType != CardSlotData.Type.Freeze)
			{
				curEmptyMinionSlots.Add(cardSlot.CardSlotData);
			}
		}
		List<CardSlotData> curEmptyItemSlots = new List<CardSlotData>();
		foreach (CardSlot cardSlot2 in allSlotsCtrl.AllItemSlots)
		{
			if (cardSlot2.CardSlotData.ChildCardData == null && cardSlot2.CardSlotData.SlotType != CardSlotData.Type.Freeze)
			{
				curEmptyItemSlots.Add(cardSlot2.CardSlotData);
			}
		}
		List<CardSlotData> curEmptyMagicSlots = new List<CardSlotData>();
		foreach (CardSlot cardSlot3 in allSlotsCtrl.AllMagicSlots)
		{
			if (cardSlot3.CardSlotData.ChildCardData == null && cardSlot3.CardSlotData.SlotType != CardSlotData.Type.Freeze)
			{
				curEmptyMagicSlots.Add(cardSlot3.CardSlotData);
			}
		}
		bool isStop = false;
		if (curEmptyMinionSlots.Count >= myMinions.Count)
		{
			int num;
			for (int i = 0; i < myMinions.Count; i = num + 1)
			{
				yield return myMinions[i].CardGameObject.JumpToSlot(curEmptyMinionSlots[i].CardSlotGameObject, 0.1f, true);
				num = i;
			}
		}
		else
		{
			int num;
			for (int i = 0; i < curEmptyMinionSlots.Count; i = num + 1)
			{
				yield return myMinions[i].CardGameObject.JumpToSlot(curEmptyMinionSlots[i].CardSlotGameObject, 0.1f, true);
				num = i;
			}
			isStop = true;
		}
		foreach (CardSlot tarSlot in allSlotsCtrl.AllItemSlots)
		{
			if (tarSlot.CardSlotData.ChildCardData != null && tarSlot.CardSlotData.ChildCardData.MaxCount > 1)
			{
				int num;
				for (int i = myItems.Count - 1; i >= 0; i = num - 1)
				{
					if (tarSlot.CardSlotData.ChildCardData.ModID.Equals(myItems[i].ModID))
					{
						if (myItems[i].MaxCount >= tarSlot.CardSlotData.ChildCardData.Count + myItems[i].Count)
						{
							myItems[i].CardGameObject.transform.DOJump(tarSlot.CardSlotData.ChildCardData.CardGameObject.transform.position, 1f, 1, 0.1f, false);
							yield return new WaitForSeconds(0.1f);
							tarSlot.CardSlotData.ChildCardData.Count = tarSlot.CardSlotData.ChildCardData.Count + myItems[i].Count;
							CardData cardData = myItems[i];
							myItems.Remove(myItems[i]);
							cardData.DeleteCardData();
						}
						else
						{
							int count = myItems[i].Count;
							int num2 = myItems[i].MaxCount - tarSlot.CardSlotData.ChildCardData.Count;
							int lastCount = count - num2;
							CardData newItem = CardData.CopyCardData(myItems[i], true);
							Card.InitCard(newItem);
							newItem.Count = num2;
							newItem.CardGameObject.transform.position = myItems[i].CardGameObject.transform.position;
							newItem.CardGameObject.transform.DOJump(tarSlot.CardSlotData.ChildCardData.CardGameObject.transform.position, 1f, 1, 0.1f, false);
							yield return new WaitForSeconds(0.1f);
							tarSlot.CardSlotData.ChildCardData.Count = tarSlot.CardSlotData.ChildCardData.MaxCount;
							newItem.DeleteCardData();
							myItems[i].Count = lastCount;
							num = i;
							i = num + 1;
							newItem = null;
						}
					}
					num = i;
				}
				tarSlot = null;
			}
		}
		List<CardSlot>.Enumerator enumerator3 = default(List<CardSlot>.Enumerator);
		if (curEmptyItemSlots.Count >= myItems.Count)
		{
			int num;
			for (int i = 0; i < myItems.Count; i = num + 1)
			{
				yield return myItems[i].CardGameObject.JumpToSlot(curEmptyItemSlots[i].CardSlotGameObject, 0.1f, true);
				num = i;
			}
		}
		else
		{
			int num;
			for (int i = 0; i < curEmptyItemSlots.Count; i = num + 1)
			{
				yield return myItems[i].CardGameObject.JumpToSlot(curEmptyItemSlots[i].CardSlotGameObject, 0.1f, true);
				num = i;
			}
			isStop = true;
		}
		if (curEmptyMagicSlots.Count >= myMagics.Count)
		{
			int num;
			for (int i = 0; i < myMagics.Count; i = num + 1)
			{
				yield return myMagics[i].CardGameObject.JumpToSlot(curEmptyMagicSlots[i].CardSlotGameObject, 0.1f, true);
				num = i;
			}
		}
		else
		{
			int num;
			for (int i = 0; i < curEmptyMagicSlots.Count; i = num + 1)
			{
				yield return myMagics[i].CardGameObject.JumpToSlot(curEmptyMagicSlots[i].CardSlotGameObject, 0.1f, true);
				num = i;
			}
			isStop = true;
		}
		if (isStop)
		{
			GameController.getInstance().UIController.ShowQuitGamePanel();
			this.isClick = false;
			yield break;
		}
		GameController.ins.UIController.HideGetCardTipPanel();
		yield return new WaitForSeconds(1f);
		GameController.getInstance().GameData.isInDungeon = false;
		DungeonController.Instance.StartCoroutine(DungeonController.Instance.GameOver(true));
		yield break;
		yield break;
	}

	private IEnumerator MoveInEndlessMode()
	{
		if (this.isClickOnMap)
		{
			yield break;
		}
		GameController.GameSavingSyncLock = true;
		GameController.ins.SaveGame();
		this.isClickOnMap = true;
		base.GetComponent<Animator>().SetTrigger("play");
		EffectAudioManager.Instance.PlayEffectAudio(21, null);
		UIController.LockLevel = UIController.UILevel.All;
		int num;
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num + 1)
		{
			if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
			{
				CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
				for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
				{
					CardLogic cardLogic = slotCardData.CardLogics[i2];
					if (slotCardData.DizzyLayer <= 0 && (cardLogic.Color >= CardLogicColor.white || cardLogic.Color == (CardLogicColor)GameController.getInstance().PlayerSlotSets[i].Color) && cardLogic.GetType().GetMethod("OnMoveOnMap").DeclaringType == cardLogic.GetType())
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
					num = i2;
				}
				slotCardData = null;
			}
			num = i;
		}
		List<CardSlotData> cardSlotDatas = GameController.ins.GetCurrentAreaData().CardSlotDatas;
		foreach (CardSlotData cardSlotData in cardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.DizzyLayer <= 0)
			{
				CardData slotCardData = cardSlotData.ChildCardData;
				if (slotCardData != null)
				{
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
								Debug.LogError(ex2.StackTrace);
							}
							routine = null;
						}
						num = i;
					}
					slotCardData = null;
				}
			}
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		UIController.LockLevel = UIController.UILevel.None;
		this.isClickOnMap = false;
		yield break;
		yield break;
	}

	private bool isClick;

	private bool isClickOnMap;
}
