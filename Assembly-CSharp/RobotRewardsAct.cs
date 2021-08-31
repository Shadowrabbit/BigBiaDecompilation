using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class RobotRewardsAct : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
		this.OptionSlots = new List<CardSlot>();
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.SlotType = CardSlotData.Type.Freeze;
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Act;
		base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.2f, 0f, 0f), 8, true, this.OptionNames, this.OptionSlots, cardSlotData);
		GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_34"), 1f, 2f, 1f, 1f);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f, 1 << LayerMask.NameToLayer("Slot"));
			if (raycastHit.collider != null && raycastHit.collider.GetComponent<CardSlot>().ChildCard != null)
			{
				if (EventSystem.current.IsPointerOverGameObject())
				{
					return;
				}
				if (GameController.ins.GameData.PlayerCardData.CardGameObject.GetComponent<Hero>().IsUseDirectionSkill)
				{
					return;
				}
				if (raycastHit.collider.GetComponent<CardSlot>())
				{
					if (raycastHit.collider.GetComponent<CardSlot>().CardSlotData.SlotOwnerType == CardSlotData.OwnerType.Area)
					{
						foreach (CardLogic cardLogic in raycastHit.collider.GetComponent<CardSlot>().ChildCard.CardData.CardLogics)
						{
							cardLogic.OnLeftClick(null);
						}
						return;
					}
					if (raycastHit.collider.GetComponent<CardSlot>().CardSlotData.SlotOwnerType != CardSlotData.OwnerType.Act)
					{
						return;
					}
					GameController.getInstance().StartCoroutine(this.onCardClick(raycastHit.collider.GetComponent<CardSlot>().ChildCard));
				}
			}
		}
	}

	public IEnumerator onCardClick(Card card)
	{
		if ((UIController.LockLevel & UIController.UILevel.ActTable) > UIController.UILevel.None)
		{
			yield break;
		}
		if (this.isClicked)
		{
			yield break;
		}
		this.isClicked = true;
		CardSlotData cardSlotData = null;
		if (card != null && card.CardData != null && card.CardData.CurrentCardSlotData != null)
		{
			cardSlotData = card.CardData.CurrentCardSlotData;
		}
		if (cardSlotData != null && cardSlotData.SlotOwnerType == CardSlotData.OwnerType.Act)
		{
			List<CardSlotData> playerBattleArea = DungeonOperationMgr.Instance.PlayerBattleArea;
			CardData robot = null;
			LostMemoryRobotCardLogic lg = null;
			foreach (CardSlotData cardSlotData2 in playerBattleArea)
			{
				if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从) && cardSlotData2.ChildCardData.CardLogics.Count > 0)
				{
					foreach (CardLogic cardLogic in cardSlotData2.ChildCardData.CardLogics)
					{
						if (cardLogic.GetType() == typeof(LostMemoryRobotCardLogic))
						{
							robot = cardSlotData2.ChildCardData;
							lg = (cardLogic as LostMemoryRobotCardLogic);
						}
					}
				}
			}
			string modId = card.CardData.ModID;
			CardData hero = card.CardData;
			Vector3 oldScale = robot.CardGameObject.transform.localScale;
			yield return hero.CardGameObject.transform.DOJump(robot.CardGameObject.transform.position, 0.5f, 1, 0.2f, false);
			yield return robot.CardGameObject.transform.DOScale(oldScale + Vector3.one, 0.2f).WaitForCompletion();
			robot.MergeBy(hero, true, true);
			yield return robot.CardGameObject.transform.DOScale(oldScale, 0.2f).WaitForCompletion();
			hero.DeleteCardData();
			ModelPoolManager.Instance.UnSpawnModel(robot.CardGameObject.DisplayGameObjectOnPlayerTable);
			switch (lg.count)
			{
			case 1:
				robot.CardGameObject.DisplayGameObjectOnPlayerTable = ModelPoolManager.Instance.SpawnModel("Card/随从/头和身体");
				robot.Model = "Card/随从/头和身体";
				break;
			case 2:
				robot.CardGameObject.DisplayGameObjectOnPlayerTable = ModelPoolManager.Instance.SpawnModel("Card/随从/头和身体和手");
				robot.Model = "Card/随从/头和身体和手";
				break;
			case 3:
				robot.CardGameObject.DisplayGameObjectOnPlayerTable = ModelPoolManager.Instance.SpawnModel("Card/随从/头和身体和手和腿");
				robot.Model = "Card/随从/头和身体和手和腿";
				break;
			case 4:
				if (modId == "路障核心" && this.GetLogic(robot, typeof(LuZhangHeXinCardLogic)) == null)
				{
					robot.CardGameObject.DisplayGameObjectOnPlayerTable = ModelPoolManager.Instance.SpawnModel("Card/随从/路障核心机器人");
					robot.Model = "Card/随从/路障核心机器人";
				}
				else if (modId == "战斗核心" && this.GetLogic(robot, typeof(ZhanDouHeXinCardLogic)) == null)
				{
					robot.CardGameObject.DisplayGameObjectOnPlayerTable = ModelPoolManager.Instance.SpawnModel("Card/随从/战斗核心机器人");
					robot.Model = "Card/随从/战斗核心机器人";
				}
				else if (modId == "侦察核心" && this.GetLogic(robot, typeof(ZhenChaHeXinCardLogic)) == null)
				{
					robot.CardGameObject.DisplayGameObjectOnPlayerTable = ModelPoolManager.Instance.SpawnModel("Card/随从/侦察核心机器人");
					robot.Model = "Card/随从/侦察核心机器人";
				}
				else if (modId == "扫地核心" && this.GetLogic(robot, typeof(SaoDiHeXinCardLogic)) == null)
				{
					robot.CardGameObject.DisplayGameObjectOnPlayerTable = ModelPoolManager.Instance.SpawnModel("Card/随从/扫地核心机器人");
					robot.Model = "Card/随从/扫地核心机器人";
				}
				else
				{
					robot.CardGameObject.DisplayGameObjectOnPlayerTable = ModelPoolManager.Instance.SpawnModel("Card/随从/头和身体和手和腿");
					robot.Model = "Card/随从/头和身体和手和腿";
				}
				break;
			}
			robot.CardGameObject.DisplayGameObjectOnPlayerTable.transform.SetParent(robot.CardGameObject.transform, false);
			robot.CardGameObject.DisplayGameObjectOnPlayerTable.transform.localPosition += new Vector3(0f, 0.0625f, 0f);
			ParticlePoolManager.Instance.Spawn("Particles/SmokeExplosionWhite", 1f).gameObject.transform.position = robot.CardGameObject.transform.position;
			robot = null;
			lg = null;
			modId = null;
			hero = null;
			oldScale = default(Vector3);
		}
		UIController.LockLevel = UIController.UILevel.AreaTable;
		this.OnActCancelButton();
		yield break;
	}

	public override void OnActCancelButton()
	{
		base.OnActCancelButton();
		UIController.LockLevel = UIController.UILevel.None;
		DungeonOperationMgr.Instance.FlipAllFlopableCards();
	}

	public override void OnRefreshButton()
	{
	}

	public override void OnUpgradeButton()
	{
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

	public List<string> OptionNames;

	public List<CardSlot> OptionSlots;

	public Transform SlotsTrans;

	public Transform SellSlotTrans;

	private bool isClicked;
}
