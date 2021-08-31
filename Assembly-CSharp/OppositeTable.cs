using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositeTable : MonoBehaviour
{
	public void Init(AreaData data, float loadTime = 0f)
	{
		this.areaData = data;
		this.areaSlots = new List<CardSlot>();
		this.childrenArea = new List<Area>();
		foreach (AreaLogic areaLogic in this.areaData.Logics)
		{
			areaLogic.BeforeInit();
		}
		this.initPref = "Area";
		if (this.templateArea.name == "World")
		{
			this.initPref = "WorldArea";
		}
		else if (this.templateArea.name == "")
		{
			base.transform.SetParent(this.templateArea.transform, false);
			return;
		}
		if (this.areaData.DisplayType == AreaData.AreaDisplayType.Secondary)
		{
			if (this.areaData.ChildrenAreaIDs != null && this.areaData.ChildrenAreaIDs.Count != 0)
			{
				Vector2[] array = new Vector2[]
				{
					new Vector2(0f, 0f),
					new Vector2(1f, 0f),
					new Vector2(-1f, 0f),
					new Vector2(0f, 1f),
					new Vector2(0f, -1f),
					new Vector2(2f, 0f),
					new Vector2(-2f, 0f),
					new Vector2(1f, 1f),
					new Vector2(-1f, -1f),
					new Vector2(-1f, 1f),
					new Vector2(1f, -1f),
					new Vector2(-2f, 1f),
					new Vector2(2f, -1f),
					new Vector2(2f, 1f),
					new Vector2(-2f, -1f),
					new Vector2(3f, 0f),
					new Vector2(-3f, 0f),
					new Vector2(3f, -1f),
					new Vector2(-3f, -1f),
					new Vector2(3f, 1f),
					new Vector2(-3f, 1f)
				};
				for (int i = 0; i < this.areaData.ChildrenAreaIDs.Count; i++)
				{
					AreaData areaData = GameController.getInstance().GameData.AreaMap[this.areaData.ChildrenAreaIDs[i]];
					GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load(this.initPref));
					((GameObject)UnityEngine.Object.Instantiate(Resources.Load(areaData.Model))).transform.SetParent(gameObject.transform, false);
					this.childrenArea.Add(gameObject.GetComponent<Area>());
					gameObject.GetComponent<Area>().Init(areaData);
					gameObject.transform.position = new Vector3(array[i].x * 2.3f, gameObject.transform.position.y, array[i].y * 2.3f - 6.15f);
					gameObject.GetComponent<Area>().AreaData.ParentArea = this.areaData;
					gameObject.transform.SetParent(this.templateArea.transform, false);
				}
			}
		}
		else
		{
			if (this.areaData.DisplayType == AreaData.AreaDisplayType.Normal)
			{
				this.InitAreaButton(data);
				GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("UI/日志"));
				gameObject2.transform.position = new Vector3(13.21f, 0f, -6f);
				gameObject2.transform.SetParent(this.templateArea.transform, false);
				if (AreaDataUtil.IsPlayerArea(this.areaData))
				{
					GameObject gameObject3 = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("UI/建造"));
					gameObject3.transform.position = new Vector3(13.21f, 0f, -9f);
					gameObject3.transform.SetParent(this.templateArea.transform, false);
					GameObject gameObject4 = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("UI/配送"));
					gameObject4.GetComponent<DeliveryButton>().SourceAreaData = this.areaData;
					gameObject4.transform.position = new Vector3(13.21f, 0f, -7f);
					gameObject4.transform.SetParent(this.templateArea.transform, false);
				}
				else
				{
					GameObject gameObject5 = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("UI/建造不可用"));
					gameObject5.transform.position = new Vector3(13.21f, 0f, -9f);
					gameObject5.transform.SetParent(this.templateArea.transform, false);
				}
			}
			if (this.areaData.DisplayType != AreaData.AreaDisplayType.OnlyThis && this.areaData.ChildrenAreaIDs != null && this.areaData.ChildrenAreaIDs.Count != 0)
			{
				this.InitChildrenArea();
			}
			if (this.areaData.Toys != null)
			{
				this.InitToys();
			}
			if (this.areaData.CardSlotDatas != null)
			{
				base.StartCoroutine(this.InitCardSlots(loadTime));
			}
		}
		try
		{
			if (GameController.getInstance().Effect.transform.childCount == 0)
			{
				((GameObject)UnityEngine.Object.Instantiate(Resources.Load("Effect/" + this.areaData.Name))).transform.SetParent(GameController.getInstance().Effect.transform);
			}
		}
		catch
		{
		}
		base.transform.SetParent(this.templateArea.transform, false);
	}

	public void Terminate()
	{
		foreach (CardSlot cardSlot in this.areaSlots)
		{
			cardSlot.Terminate();
		}
		if (this.inputSlots != null)
		{
			foreach (CardSlot cardSlot2 in this.inputSlots)
			{
				cardSlot2.Terminate();
			}
		}
		if (this.outputSlots != null)
		{
			foreach (CardSlot cardSlot3 in this.outputSlots)
			{
				cardSlot3.Terminate();
			}
		}
	}

	public void Exit()
	{
		if (this.areaData.CardSlotDatas != null)
		{
			for (int i = this.areaData.CardSlotDatas.Count - 1; i >= 0; i--)
			{
				CardSlotData cardSlotData = this.areaData.CardSlotDatas[i];
				if (cardSlotData.ChildCardData != null)
				{
					foreach (CardLogic cardLogic in cardSlotData.ChildCardData.CardLogics)
					{
						cardLogic.OnPlayerExitArea();
					}
				}
			}
		}
		foreach (AreaLogic areaLogic in this.areaData.Logics)
		{
			areaLogic.OnExit();
		}
	}

	public void BeforeEnter()
	{
		foreach (AreaLogic areaLogic in this.areaData.Logics)
		{
			areaLogic.BeforeEnter();
		}
	}

	public IEnumerator OnAlreadEnter()
	{
		foreach (AreaLogic areaLogic in this.areaData.Logics)
		{
			yield return areaLogic.OnAlreadEnter();
		}
		List<AreaLogic>.Enumerator enumerator = default(List<AreaLogic>.Enumerator);
		yield break;
		yield break;
	}

	public void InitToys()
	{
		foreach (CardData cardData in this.areaData.Toys)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("Toy"));
			Toy component = gameObject.GetComponent<Toy>();
			component.Init(cardData);
			if ((cardData.CardTags & 16UL) > 0UL)
			{
				component.DisplayGameObjectOnPlayerTable.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
			}
			component.DisplayGameObjectOnAreaTable.SetActive(true);
			component.DisplayGameObjectOnPlayerTable.SetActive(false);
			gameObject.transform.SetParent(this.templateArea.transform, false);
			gameObject.GetComponent<Toy>().ParentArea = this.areaData;
		}
	}

	public void InitChildrenArea()
	{
		foreach (string key in this.areaData.ChildrenAreaIDs)
		{
			AreaData areaData = GameController.getInstance().GameData.AreaMap[key];
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load(this.initPref));
			((GameObject)UnityEngine.Object.Instantiate(Resources.Load(areaData.Model))).transform.SetParent(gameObject.transform, false);
			gameObject.GetComponent<Area>().Init(areaData);
			gameObject.GetComponent<Area>().AreaData.ParentArea = this.areaData;
			gameObject.transform.SetParent(this.templateArea.transform, false);
		}
	}

	public IEnumerator InitCardSlots(float loadTime)
	{
		int count = this.areaData.CardSlotDatas.Count;
		int loadCountPerFrame = count;
		if (loadTime != 0f)
		{
			int num = (int)(loadTime / Time.fixedDeltaTime);
			loadCountPerFrame = (count + num) / num;
		}
		int num2 = 0;
		foreach (CardSlotData cardSlotData in this.areaData.CardSlotDatas)
		{
			cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
			CardSlot cardSlot = CardSlot.InitCardSlot(cardSlotData, 0.24f);
			cardSlot.transform.SetParent(this.templateArea.transform, false);
			this.areaSlots.Add(cardSlot);
			num2++;
			if (num2 > loadCountPerFrame)
			{
				yield return null;
				num2 = 0;
			}
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		this.BeforeEnter();
		yield break;
		yield break;
	}

	public void InitInputOutputCardSlots()
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("AreaTable/输入输出条"));
		gameObject.transform.position = new Vector3(-11f, 0f, -5.15f);
		gameObject.transform.SetParent(this.templateArea.transform, false);
		if (this.areaData.InputCardSlotDataList != null)
		{
			this.inputSlots = new List<CardSlot>();
			int num = 0;
			foreach (CardSlotData cardSlotData in this.areaData.InputCardSlotDataList)
			{
				cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
				cardSlotData.SlotType = CardSlotData.Type.Undisplay;
				cardSlotData.DisplayPositionZ = 1.96f - (float)num;
				num++;
				CardSlot cardSlot = CardSlot.InitCardSlot(cardSlotData, 0.24f);
				cardSlot.transform.SetParent(gameObject.transform, false);
				this.inputSlots.Add(cardSlot);
			}
		}
		gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("AreaTable/输入输出条"));
		gameObject.transform.position = new Vector3(11f, 0f, -5.15f);
		gameObject.transform.SetParent(this.templateArea.transform, false);
		if (this.areaData.OutputCardSlotDataList != null)
		{
			this.outputSlots = new List<CardSlot>();
			int num2 = 0;
			foreach (CardSlotData cardSlotData2 in this.areaData.OutputCardSlotDataList)
			{
				cardSlotData2.SlotOwnerType = CardSlotData.OwnerType.Area;
				cardSlotData2.SlotType = CardSlotData.Type.Undisplay;
				cardSlotData2.DisplayPositionZ = 1.96f - (float)num2;
				num2++;
				CardSlot cardSlot2 = CardSlot.InitCardSlot(cardSlotData2, 0.24f);
				cardSlot2.transform.SetParent(gameObject.transform, false);
				this.outputSlots.Add(cardSlot2);
			}
		}
	}

	public void InitParentArea()
	{
		AreaData data = this.areaData.ParentArea;
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("UI/返回"));
		this.parentArea = gameObject.AddComponent<Area>();
		this.parentArea.Init(data);
		gameObject.transform.position = new Vector3(12.783f, 0f, 10f);
		gameObject.transform.SetParent(this.templateArea.transform, true);
		gameObject.AddComponent<BoxCollider>();
		gameObject.GetComponent<BoxCollider>().size = new Vector3(2f, 0.0625f, 2f);
		if (this.areaData.GetBoolAttr("IsLocked"))
		{
			this.HideParentArea();
		}
	}

	public void HideParentArea()
	{
		this.parentArea.gameObject.SetActive(false);
	}

	public void ShowParentArea()
	{
		this.parentArea.gameObject.SetActive(true);
	}

	public CardSlot GetEmptySlot()
	{
		if (this.areaSlots != null)
		{
			foreach (CardSlot cardSlot in this.areaSlots)
			{
				if (cardSlot.ChildCard == null)
				{
					return cardSlot;
				}
			}
		}
		return null;
	}

	private void InitAreaButton(AreaData data)
	{
		if (this.areaData.DisplayType == AreaData.AreaDisplayType.World)
		{
			return;
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("UI/AreaShopButton"));
		gameObject.transform.position = new Vector3(13.21f, 0f, -8f);
		gameObject.transform.SetParent(this.templateArea.transform, false);
		gameObject.GetComponent<ChooseAreaButton>().SetAreaMessage(data.ID, AreaDataUtil.IsPlayerArea(data));
	}

	private void OnDestroy()
	{
	}

	public AreaData areaData;

	public GameObject templateArea;

	private string initPref;

	private string parent;

	private List<CardSlot> areaSlots;

	private List<CardSlot> inputSlots;

	private List<CardSlot> outputSlots;

	private List<Area> childrenArea;

	private Area parentArea;
}
