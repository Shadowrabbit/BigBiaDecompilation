using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinionSelectArea : MonoBehaviour
{
	private void Start()
	{
		if (GameData.CurrentGameType == GameData.GameType.Endless)
		{
			this.NextHeroButton.SetActive(false);
			this.prevHeroButton.SetActive(false);
			this.HeroLevelText.gameObject.SetActive(false);
			this.AgreetmentDESC.text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约无尽");
		}
		this.GetAllSpace();
		this.GetAllBoss();
	}

	private void OnCardPutInSlot(CardSlotData arg1, CardData arg2)
	{
	}

	private void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject() || (UIController.LockLevel & UIController.UILevel.PlayerSlot) != UIController.UILevel.None || (UIController.UILockStack.Count > 0 && UIController.UILockStack.Peek() != this))
		{
			return;
		}
		if (!Input.GetMouseButtonDown(0))
		{
			return;
		}
		RaycastHit raycastHit;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit))
		{
			Collider collider = raycastHit.collider;
			if (collider.gameObject == this.OkButton)
			{
				if (GameData.CurrentGameType == GameData.GameType.Endless)
				{
					GameController.getInstance().CreatePlayer(this.SelectedHero.ModID);
					GameController.getInstance().GameData.StartHeroModID = this.SelectedHero.ModID;
					base.transform.parent.parent.gameObject.SetActive(true);
					AreaData areaData = GameController.getInstance().GameData.AreaMap["Infinity"];
					areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
					GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
					GameController.getInstance().OnTableChange(areaData, true);
					DungeonController.Instance.StartNewDungeon();
					return;
				}
				GameController.ins.GameData.Agreenment = this.currentLevel;
				DungeonController.Instance.StartNewDungeon();
				GameController.ins.GameData.DungeonArea.Clear();
				GameController.ins.GameData.DungeonArea.Add(Card.InitCardDataByID("颓废街头"));
				GameController.getInstance().CreatePlayer(this.SelectedHero.ModID);
				GameController.getInstance().GameData.StartHeroModID = this.SelectedHero.ModID;
				base.transform.parent.parent.gameObject.SetActive(true);
				AreaData areaData2 = GameController.getInstance().GameData.AreaMap[(string)GameController.ins.GameData.DungeonArea[0].Attrs["AreaDataID"]];
				areaData2.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
				GameController.getInstance().GameEventManager.EnterArea(areaData2.Name);
				GameController.getInstance().OnTableChange(areaData2, true);
				List<CardSlotData> playerBattleArea = DungeonOperationMgr.Instance.PlayerBattleArea;
				if (playerBattleArea.Count > 0 && GameController.ins.GameData.Agreenment >= 9)
				{
					List<CardSlotData> list = new List<CardSlotData>();
					foreach (CardSlotData cardSlotData in playerBattleArea)
					{
						if (cardSlotData != null && cardSlotData.ChildCardData == null)
						{
							list.Add(cardSlotData);
						}
					}
					if (playerBattleArea.Count > 1 && playerBattleArea[1].ChildCardData == null)
					{
						CardData.CopyCardData(Card.InitCardDataByID("地雷"), true).PutInSlotData(playerBattleArea[1], true);
					}
					else
					{
						CardData.CopyCardData(Card.InitCardDataByID("地雷"), true).PutInSlotData(list[SYNCRandom.Range(0, list.Count)], true);
					}
				}
				UIController.LockLevel = UIController.UILevel.None;
			}
			if (collider.gameObject.GetComponent<Card>() != null && collider.gameObject.GetComponent<Card>().CardData.HasTag(TagMap.英雄))
			{
				this.SelectedHero = collider.gameObject.GetComponent<Card>().CardData;
				this.FocusSprite.position = collider.gameObject.transform.position + Vector3.up * 0.1f;
				this.maxLevel = GlobalController.Instance.GetContractLevelByHeroModID(this.SelectedHero.ModID);
				if (this.maxLevel > 11)
				{
					this.maxLevel = 11;
				}
				this.currentLevel = this.maxLevel;
				this.HeroLevelText.text = this.currentLevel.ToString() + "/" + this.maxLevel.ToString();
				this.showAgreementDESC(this.currentLevel);
			}
			if (collider.gameObject == this.NextHeroButton && this.currentLevel < this.maxLevel && this.currentLevel < 11)
			{
				this.currentLevel++;
				this.HeroLevelText.text = this.currentLevel.ToString() + "/" + this.maxLevel.ToString();
				this.showAgreementDESC(this.currentLevel);
			}
			if (collider.gameObject == this.prevHeroButton && this.currentLevel > 1)
			{
				this.currentLevel--;
				this.HeroLevelText.text = this.currentLevel.ToString() + "/" + this.maxLevel.ToString();
				this.showAgreementDESC(this.currentLevel);
			}
		}
	}

	public void showAgreementDESC(int agreement)
	{
		if (GameData.CurrentGameType == GameData.GameType.Endless)
		{
			return;
		}
		switch (agreement)
		{
		case 1:
			this.AgreetmentDESC.text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约1");
			return;
		case 2:
			this.AgreetmentDESC.text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约2");
			return;
		case 3:
			this.AgreetmentDESC.text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约3");
			return;
		case 4:
			this.AgreetmentDESC.text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约4");
			return;
		case 5:
			this.AgreetmentDESC.text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约5");
			return;
		case 6:
			this.AgreetmentDESC.text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约6");
			return;
		case 7:
			this.AgreetmentDESC.text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约7");
			return;
		case 8:
			this.AgreetmentDESC.text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约8");
			return;
		case 9:
			this.AgreetmentDESC.text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约9");
			return;
		case 10:
			this.AgreetmentDESC.text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约10");
			return;
		case 11:
			this.AgreetmentDESC.text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约11");
			return;
		default:
			return;
		}
	}

	private void GetAllSpace()
	{
		this.m_AllLevel1Space = new List<CardData>();
		this.m_AllLevel2Space = new List<CardData>();
		this.m_AllLevel3Space = new List<CardData>();
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if (cardData.HasTag(TagMap.地下城入口) && cardData.HasTag(TagMap.地点) && !cardData.HasTag(TagMap.特殊) && !cardData.HasTag(TagMap.BOSS) && cardData.Attrs.ContainsKey("Theme"))
			{
				switch (cardData.Level)
				{
				case 1:
					this.m_AllLevel1Space.Add(cardData);
					break;
				case 2:
					this.m_AllLevel2Space.Add(cardData);
					break;
				case 3:
					this.m_AllLevel3Space.Add(cardData);
					break;
				default:
					this.m_AllLevel1Space.Add(cardData);
					break;
				}
			}
		}
	}

	private void GetAllBoss()
	{
		this.m_AllBoss = new List<CardData>();
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if (cardData.HasTag(TagMap.地点) && cardData.HasTag(TagMap.BOSS))
			{
				this.m_AllBoss.Add(cardData);
			}
		}
	}

	private void StartRollTheme(List<CardData> cards, Transform showPoint, float duration, bool isEnd = false)
	{
		base.StartCoroutine(this.RollThemeCorotine(cards, showPoint, duration, isEnd));
	}

	private IEnumerator RollThemeCorotine(List<CardData> cards, Transform showPoint, float duration, bool isEnd)
	{
		DungeonController.Instance.StartNewDungeon();
		yield return new WaitForSeconds(duration);
		CardData cardData = cards[SYNCRandom.Range(0, cards.Count)];
		while (this.m_SelectedSpace.Contains(cardData))
		{
			cardData = cards[SYNCRandom.Range(0, cards.Count)];
		}
		Card card = Card.InitCard(CardData.CopyCardData(cardData, true));
		card.transform.SetParent(showPoint);
		card.transform.localPosition = Vector3.zero + Vector3.forward * 1.1f;
		card.transform.localScale = Vector3.one;
		card.transform.localRotation = Quaternion.Euler(Vector3.zero);
		card.transform.DOLocalMoveZ(0f, 0.5f, false).SetEase(Ease.OutBack);
		if (card != null)
		{
			this.m_SelectedSpace.Add(cardData);
			CardData cardData2;
			if (GameController.ins.GameData.CurrentDungeonType == GameData.DungeonType.Dungeon)
			{
				cardData2 = Card.InitCardDataByID("地下城营地");
			}
			else
			{
				cardData2 = Card.InitCardDataByID("营地");
			}
			this.m_SelectedSpace.Add(CardData.CopyCardData(cardData2, true));
		}
		if (isEnd)
		{
			yield return new WaitForSeconds(1f);
			MonoBehaviour.print(string.Concat(new string[]
			{
				this.ShowPoints[0].GetChild(0).GetComponent<Card>().CardData.ModID,
				"  ",
				this.ShowPoints[1].GetChild(0).GetComponent<Card>().CardData.ModID,
				"  ",
				this.ShowPoints[2].GetChild(0).GetComponent<Card>().CardData.ModID
			}));
			GameController.ins.GameData.DungeonArea = this.m_SelectedSpace;
			yield return new WaitForSeconds(0.5f);
			GameController.getInstance().CreatePlayer(this.SelectedHero.ModID);
			base.transform.parent.parent.gameObject.SetActive(true);
			AreaData areaData = GameController.getInstance().GameData.AreaMap[(string)GameController.ins.GameData.DungeonArea[0].Attrs["AreaDataID"]];
			areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
			GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
			GameController.getInstance().OnTableChange(areaData, true);
			UIController.LockLevel = UIController.UILevel.None;
		}
		yield break;
	}

	public CardData SelectedHero;

	public HeroHome1AreaLogic logic;

	public Transform FocusSprite;

	public GameObject OkButton;

	public GameObject NextHeroButton;

	public GameObject prevHeroButton;

	public TextMeshProUGUI MinionNumText;

	public TextMeshProUGUI VoxelNumText;

	public TextMeshProUGUI LineUnlockNumText;

	public TextMeshProUGUI HeroLevelText;

	public Transform RollThemeTransform;

	public List<Transform> ShowPoints;

	public TextMeshProUGUI AgreetmentDESC;

	public int maxLevel;

	public int currentLevel;

	private MinionSelectArea.State ProcessState;

	private bool isClicked;

	private List<CardData> m_AllLevel1Space = new List<CardData>();

	private List<CardData> m_AllLevel2Space = new List<CardData>();

	private List<CardData> m_AllLevel3Space = new List<CardData>();

	private List<CardData> m_AllBoss = new List<CardData>();

	private List<CardData> m_SelectedSpace = new List<CardData>();

	public enum State
	{
		SelectMinion,
		SelectItem
	}
}
