using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class ThemeMachineArea : MonoBehaviour
{
	private void Start()
	{
		this.GetAllSpace();
		this.GetAllBoss();
		this.StartRollTheme(this.m_AllSpace, this.ShowPoint1, 0.5f, false);
		this.StartRollTheme(this.m_AllSpace, this.ShowPoint2, 1f, false);
		this.StartRollTheme(this.m_AllSpace, this.ShowPoint3, 1.5f, false);
		this.StartRollTheme(this.m_AllBoss, this.ShowPoint4, 2f, true);
	}

	private void GetAllSpace()
	{
		this.m_AllSpace = new List<CardData>();
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if (cardData.HasTag(TagMap.地点) && !cardData.HasTag(TagMap.特殊) && cardData.Attrs.ContainsKey("Theme") && cardData.Attrs.ContainsKey("Type") && cardData.GetAttr("Type") == "Dungeon")
			{
				this.m_AllSpace.Add(cardData);
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

	private void InitRandomTheme()
	{
	}

	private void StartRollTheme(List<CardData> cards, Transform showPoint, float duration, bool isEnd = false)
	{
		base.StartCoroutine(this.RollThemeCorotine(cards, showPoint, duration, isEnd));
	}

	private IEnumerator RollThemeCorotine(List<CardData> cards, Transform showPoint, float duration, bool isEnd)
	{
		DungeonController.Instance.StartNewDungeon();
		GameController.getInstance().CreatePlayer("血条");
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
				this.ShowPoint1.GetChild(0).GetComponent<Card>().CardData.ModID,
				"  ",
				this.ShowPoint2.GetChild(0).GetComponent<Card>().CardData.ModID,
				"  ",
				this.ShowPoint3.GetChild(0).GetComponent<Card>().CardData.ModID
			}));
			GameController.ins.GameData.DungeonArea = this.m_SelectedSpace;
			yield return new WaitForSeconds(0.5f);
			DungeonController.Instance.IsSelectedMinionAndScenes = true;
			AreaData areaData = GameController.getInstance().GameData.AreaMap["入场选择"];
			areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
			GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
			GameController.getInstance().OnTableChange(areaData, true);
			UIController.LockLevel = UIController.UILevel.None;
		}
		yield break;
	}

	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit) && raycastHit.collider.gameObject == this.OkButton)
		{
			MonoBehaviour.print("Roll Theme is Started...");
		}
	}

	public ThemeMachineAreaLogic ThemeMachineAreaLogic;

	public Transform ShowPoint1;

	public Transform ShowPoint2;

	public Transform ShowPoint3;

	public Transform ShowPoint4;

	public GameObject OkButton;

	private List<CardData> m_AllSpace = new List<CardData>();

	private List<CardData> m_AllBoss = new List<CardData>();

	private List<CardData> m_SelectedSpace = new List<CardData>();
}
