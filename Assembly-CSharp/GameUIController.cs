using System;
using System.Collections.Generic;
using System.Text;
using PixelGame;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
	public GameController GameController
	{
		get
		{
			return GameController.getInstance();
		}
	}

	public GameEventManager GameEventManager
	{
		get
		{
			return this.GameController.GameEventManager;
		}
	}

	private GameData m_GameData
	{
		get
		{
			return this.GameController.GameData;
		}
	}

	private CardData m_PlayerCardData
	{
		get
		{
			return this.m_GameData.PlayerCardData;
		}
	}

	public Camera UICamera
	{
		get
		{
			return this.m_UICamera;
		}
	}

	private void Awake()
	{
		GameUIController.Instance = this;
		this.m_UIObjectPool = ObjectPoolComponent.Instance.ObjectPoolManager.CreateSingleObjectPool<UIObjectBase>("UI Pool");
	}

	private void Start()
	{
		this.InitWordUI();
		this.tips.StructPanel.SetActive(false);
	}

	private void Init()
	{
		this.uiCameraRoot = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("UI/UICamera"));
		this.uiCameraRoot.transform.SetParent(base.transform);
		this.uiCameraRoot.transform.localPosition = Vector3.zero;
		this.m_UICamera = this.uiCameraRoot.GetComponent<Canvas>().worldCamera;
		this.backGroundCanvas.worldCamera = this.m_UICamera;
	}

	private void OnGUI()
	{
		if (!this.m_ScreenDics.ContainsKey(typeof(DropDownScreen)))
		{
			return;
		}
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			this.CloseUI(typeof(DropDownScreen));
		}
		if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
		{
			this.CloseUI(typeof(DropDownScreen));
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.BackQuote))
		{
			if (this.isCommandLineOpen)
			{
				this.CommandLine.text = "";
				this.CommandLine.gameObject.SetActive(false);
			}
			else
			{
				this.CommandLine.gameObject.SetActive(true);
				GameController.ins.IsUseCommandLine = true;
				this.CommandLine.ActivateInputField();
			}
			this.isCommandLineOpen = !this.isCommandLineOpen;
		}
		if (this.isCommandLineOpen && Input.GetKeyDown(KeyCode.Return))
		{
			string[] array = this.CommandLine.text.Split(new char[]
			{
				' '
			});
			if (array.Length > 1)
			{
				if (array[0].Equals("getcard"))
				{
					CardData cardData = null;
					CardSlotData cardSlotData = null;
					try
					{
						cardData = Card.InitCardDataByID(array[1]);
						cardSlotData = GameController.ins.GetEmptySlotDataByCardData(cardData);
					}
					catch
					{
						GameController.getInstance().CreateSubtitle("找不到这张牌，你打错了吧", 1f, 2f, 1f, 1f);
					}
					if (cardSlotData == null)
					{
						GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_2"), 1f, 2f, 1f, 1f);
						return;
					}
					if (cardData != null)
					{
						cardData.PutInSlotData(cardSlotData, true);
						return;
					}
				}
				else if (array[0].Equals("getmod"))
				{
					if (!GameController.ins.CardsFromMods.Contains(array[1]))
					{
						GameController.getInstance().CreateSubtitle("未找到mod", 1f, 2f, 1f, 1f);
						return;
					}
					CardData cardData2 = null;
					CardSlotData cardSlotData2 = null;
					try
					{
						cardData2 = Card.InitCardDataByID(array[1]);
						cardSlotData2 = GameController.ins.GetEmptySlotDataByCardData(cardData2);
					}
					catch
					{
						GameController.getInstance().CreateSubtitle("找不到这张牌，你打错了吧", 1f, 2f, 1f, 1f);
					}
					if (cardSlotData2 == null)
					{
						GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_2"), 1f, 2f, 1f, 1f);
						return;
					}
					if (cardData2 != null)
					{
						cardData2.PutInSlotData(cardSlotData2, true);
						return;
					}
				}
				else
				{
					if (array[0].Equals("goto"))
					{
						try
						{
							AreaData areaData = null;
							if (GameController.getInstance().CardDataModMap.getCardDataByModID(array[1]) != null)
							{
								areaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().CardDataModMap.getCardDataByModID(array[1]).GetAttr("AreaDataID")];
							}
							if (areaData == null)
							{
								areaData = GameController.getInstance().AreaDataModMap.getAreaDataByModID(array[1]);
							}
							areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
							GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
							GameController.getInstance().OnTableChange(areaData, true);
							return;
						}
						catch (Exception ex)
						{
							GameController.getInstance().CreateSubtitle("找不到这个Area，你打错了吧", 1f, 2f, 1f, 1f);
							Debug.LogError(ex.Message);
							Debug.LogError(ex.StackTrace);
							return;
						}
					}
					if (array[0].Equals("flipall"))
					{
						DungeonOperationMgr.Instance.FlipAll();
						return;
					}
					if (array[0].Equals("getrich"))
					{
						DungeonOperationMgr.Instance.ChangeMoney(10000);
						return;
					}
					if (array[0].Equals("getvoxel"))
					{
						GlobalController.Instance.ChangeGlobalMoney(10000);
						return;
					}
					if (array[0].Equals("gameover"))
					{
						DungeonOperationMgr.Instance.StartCoroutine(DungeonController.Instance.GameOver(false));
						return;
					}
					if (array[0].Equals("wingame"))
					{
						DungeonOperationMgr.Instance.StartCoroutine(DungeonController.Instance.GameOver(true));
						return;
					}
					if (array[0].Equals("nextarea"))
					{
						DungeonController.Instance.GenerateNextArea(false);
						return;
					}
					if (array[0].Equals("startact"))
					{
						try
						{
							using (List<CardSlotData>.Enumerator enumerator = GameController.ins.GetCurrentAreaData().CardSlotDatas.GetEnumerator())
							{
								if (enumerator.MoveNext())
								{
									CardSlotData cardSlotData3 = enumerator.Current;
									if (cardSlotData3.ChildCardData == null)
									{
										CardData cardData3 = Card.InitCardDataByID(array[1]);
										cardData3.PutInSlotData(cardSlotData3, true);
										if (cardData3 != null)
										{
											DungeonOperationMgr.Instance.StartCoroutine(DungeonController.Instance.GetAndPickTheFlipedCards(new List<CardData>
											{
												cardData3
											}, true));
										}
									}
								}
							}
							return;
						}
						catch (Exception ex2)
						{
							Debug.LogError("运行act失败");
							Debug.LogError(ex2.Message);
							Debug.LogError(ex2.StackTrace);
							return;
						}
					}
					if (array[0].Equals("event"))
					{
						using (List<CardData>.Enumerator enumerator2 = GameController.ins.CardDataModMap.Cards.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								CardData cardData4 = enumerator2.Current;
								if (cardData4.HasTag(TagMap.事件) && cardData4.HasTag(TagMap.特殊))
								{
									foreach (CardLogic cardLogic in cardData4.CardLogics)
									{
										base.StartCoroutine(cardLogic.BeforeFact());
									}
								}
							}
							return;
						}
					}
					if (array[0].Equals("cheat"))
					{
						List<CardData> list = new List<CardData>();
						List<CardData> list2 = new List<CardData>();
						List<CardData> list3 = new List<CardData>();
						List<CardData> list4 = new List<CardData>();
						List<CardData> list5 = new List<CardData>();
						foreach (CardData cardData5 in GameController.getInstance().CardDataModMap.Cards)
						{
							if (cardData5.CardTags == 128UL && !cardData5.HasTag(TagMap.特殊))
							{
								CardData cardData6 = CardData.CopyCardData(cardData5, true);
								if (cardData6 != null)
								{
									list.Add(cardData6);
								}
							}
							if (cardData5.HasTag(TagMap.食物) && !cardData5.HasTag(TagMap.特殊))
							{
								CardData cardData7 = CardData.CopyCardData(cardData5, true);
								if (cardData7 != null)
								{
									switch (cardData5.Rare)
									{
									case 1:
										list2.Add(cardData7);
										break;
									case 2:
										list3.Add(cardData7);
										break;
									case 3:
										list4.Add(cardData7);
										break;
									case 4:
										list5.Add(cardData7);
										break;
									}
								}
							}
						}
						if (list.Count == 0 || list2.Count == 0 || list3.Count == 0 || list4.Count == 0 || list5.Count == 0)
						{
							return;
						}
						for (int i = 0; i < 1; i++)
						{
							List<CardSlotData> playerBattleArea = DungeonOperationMgr.Instance.PlayerBattleArea;
							List<CardSlotData> list6 = new List<CardSlotData>();
							foreach (CardSlotData cardSlotData4 in playerBattleArea)
							{
								if (cardSlotData4.ChildCardData == null)
								{
									list6.Add(cardSlotData4);
								}
							}
							if (list6.Count == 0)
							{
								return;
							}
							CardSlotData slotData = list6[SYNCRandom.Range(0, list6.Count)];
							CardData cardData8 = Card.InitCardDataByID(list[SYNCRandom.Range(0, list.Count)].ModID);
							CardData cardData9 = list2[SYNCRandom.Range(0, list2.Count)];
							cardData8.MergeBy(cardData9, true, false);
							cardData9 = list3[SYNCRandom.Range(0, list3.Count)];
							cardData8.MergeBy(cardData9, true, false);
							cardData9 = list4[SYNCRandom.Range(0, list4.Count)];
							cardData8.MergeBy(cardData9, true, false);
							cardData9 = list5[SYNCRandom.Range(0, list5.Count)];
							cardData8.MergeBy(cardData9, true, false);
							cardData8.PutInSlotData(slotData, true);
						}
					}
				}
			}
		}
	}

	private void InitNeedBackGroundCanvasScreen()
	{
		this.m_NeedBackGroundCanvasScreen.Add(typeof(DropDownScreen));
	}

	public ScreenBase OpenUI(Type type, string name, int makeType = 0, object[] objects = null)
	{
		UIObjectBase ui = this.GetUI(name);
		this.m_UIOpenOrder++;
		this.GameEventManager.OpenGameUI();
		this.CheckNeedOpenBackGroundCanvas(type);
		if (ui != null)
		{
			ScreenBase screenBase = ui.target as ScreenBase;
			if (screenBase.uIControlBase != null && !screenBase.uIControlBase.canvas.enabled)
			{
				if (screenBase.uIControlBase.MakeType != makeType)
				{
					screenBase.uIControlBase.MakeType = makeType;
					((ThumbnailCanvasUI)screenBase.uIControlBase).ResetPanel();
				}
				screenBase.uIControlBase.canvas.enabled = true;
				screenBase.openOrder = this.m_UIOpenOrder;
				screenBase.objects = objects;
				screenBase.OnOpen();
			}
			this.m_ScreenDics.Add(type, ui);
			return screenBase;
		}
		ScreenBase screenBase2 = Activator.CreateInstance(type) as ScreenBase;
		screenBase2.openOrder = this.m_UIOpenOrder;
		screenBase2.objects = objects;
		screenBase2.MakeType = makeType;
		screenBase2.StartLoad(screenBase2.panelName);
		return screenBase2;
	}

	public UIObjectBase GetUI(string name)
	{
		UIObjectBase uiobjectBase = this.m_UIObjectPool.Spawn(name);
		if (uiobjectBase == null)
		{
			return null;
		}
		return uiobjectBase;
	}

	public void AttachUI(ScreenBase screen, object asset)
	{
		UIObjectBase uiobjectBase = new UIObjectBase(screen.panelName, screen, asset);
		if (!this.m_ScreenDics.ContainsKey(screen.GetType()))
		{
			this.m_ScreenDics.Add(screen.GetType(), uiobjectBase);
		}
		this.m_UIObjectPool.Register(uiobjectBase, true);
		screen.uiControlPanel.transform.SetParent(base.transform);
		screen.uiControlPanel.transform.position = Vector3.zero;
		screen.uiControlPanel.transform.localScale = Vector3.one;
		screen.uiControlPanel.transform.rotation = Quaternion.identity;
	}

	public bool CloseUI(Type type)
	{
		if (this.m_ScreenDics.ContainsKey(type))
		{
			UIObjectBase uiobjectBase = this.m_ScreenDics[type];
			uiobjectBase.CloseUI();
			this.m_UIObjectPool.UnSpawn(uiobjectBase);
			this.m_ScreenDics.Remove(uiobjectBase.target.GetType());
		}
		UIController.LockLevel = UIController.UILevel.None;
		this.CheckNeedCloseBackGroundCanvas(type);
		return true;
	}

	public bool CloseUI<T>() where T : ScreenBase
	{
		return this.CloseUI(typeof(T));
	}

	private void CheckNeedOpenBackGroundCanvas(Type type)
	{
		if (!this.m_NeedBackGroundCanvasScreen.Contains(type))
		{
			return;
		}
		if (this.backGourndCanvasCount == 0)
		{
			this.backGroundCanvas.gameObject.SetActive(true);
		}
		this.backGourndCanvasCount++;
	}

	private void CheckNeedCloseBackGroundCanvas(Type type)
	{
		if (!this.m_NeedBackGroundCanvasScreen.Contains(type))
		{
			return;
		}
		this.backGourndCanvasCount--;
		if (this.backGourndCanvasCount <= 0)
		{
			this.backGourndCanvasCount = 0;
			this.backGroundCanvas.gameObject.SetActive(false);
		}
	}

	private void InitWordUI()
	{
		GameEventManager gameEventManager = this.GameEventManager;
		gameEventManager.OnOpenGameUI = (Action)Delegate.Combine(gameEventManager.OnOpenGameUI, new Action(this.CloseTips));
		this.CloseTips();
	}

	public void OpenTipsByString(string str, Vector3 position)
	{
		this.tips.gameObject.SetActive(true);
		this.m_StringBuilder.Clear();
		this.m_StringBuilder.Append(str);
		this.tips.Panel.GetComponentInChildren<TextMeshProUGUI>().text = this.m_StringBuilder.ToString();
		RectTransform[] componentsInChildren = this.tips.GetComponentsInChildren<RectTransform>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(componentsInChildren[i]);
		}
	}

	public void OpenTips(CardData cardData, Vector3 position)
	{
		this.tips.NamePanel.gameObject.SetActive(true);
		this.tips.OpenTips(cardData, position);
	}

	public void OpenTips(CardData cardData, Vector3 position, Camera camera)
	{
		this.tips.NamePanel.gameObject.SetActive(false);
		this.tips.HPBar.gameObject.SetActive(false);
		this.tips.gameObject.SetActive(true);
		this.m_StringBuilder.Clear();
		this.m_StringBuilder.Append(LocalizationMgr.Instance.GetLocalizationWord(cardData.Name));
		this.m_StringBuilder.Append("\n---------------\n");
		this.m_StringBuilder.Append(LocalizationMgr.Instance.GetLocalizationWord(cardData.desc));
		this.tips.Panel.GetComponentInChildren<TextMeshProUGUI>().text = this.m_StringBuilder.ToString();
		this.tips.StructPanel.SetActive(false);
		this.tips.transform.position = camera.WorldToScreenPoint(position + new Vector3(0.5f, 0f, 0f));
		if (this.tips.transform.position.x + this.tips.GetComponent<RectTransform>().rect.width > (float)Screen.width)
		{
			this.tips.transform.position = camera.WorldToScreenPoint(position - new Vector3(0.5f, 0f, 0f)) - new Vector3(this.tips.GetComponent<RectTransform>().rect.width, 0f, 0f);
		}
		else
		{
			this.tips.transform.position = camera.WorldToScreenPoint(position + new Vector3(0.5f, 0f, 0f));
		}
		RectTransform[] componentsInChildren = this.tips.GetComponentsInChildren<RectTransform>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(componentsInChildren[i]);
		}
	}

	public void CloseTips()
	{
		this.tips.CloseTips();
	}

	private void ResetLockLevel(int val)
	{
		UIController.LockLevel = UIController.UILevel.None;
	}

	private void OnDestroy()
	{
		GameEventManager gameEventManager = this.GameEventManager;
		gameEventManager.OnOpenGameUI = (Action)Delegate.Remove(gameEventManager.OnOpenGameUI, new Action(this.CloseTips));
	}

	public GameObject uiCameraRoot;

	public static GameUIController Instance;

	public Canvas backGroundCanvas;

	public int backGourndCanvasCount;

	private Dictionary<Type, UIObjectBase> m_ScreenDics = new Dictionary<Type, UIObjectBase>();

	private HashSet<Type> m_NeedBackGroundCanvasScreen = new HashSet<Type>();

	private IObjectPool<UIObjectBase> m_UIObjectPool;

	private Camera m_UICamera;

	private Transform buffRoot;

	private GameObject buffIconPrefab;

	public TMP_InputField CommandLine;

	private int m_UIOpenOrder;

	private bool isCommandLineOpen;

	public TipsUI tips;

	private StringBuilder m_StringBuilder = new StringBuilder();
}
