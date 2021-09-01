using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class DebuggerGui : MonoBehaviour
{
	public GameController GameController
	{
		get
		{
			return GameController.getInstance();
		}
	}

	private void Update()
	{
		if (this.m_TestSub == null)
		{
			this.m_TestSub = UnityEngine.Object.FindObjectOfType<TestSub>();
		}
	}

	private void OnGUI()
	{
		if (!this.Show)
		{
			return;
		}
		if (this.m_TestSub == null)
		{
			return;
		}
		Matrix4x4 matrix = GUI.matrix;
		GUISkin guiskin = GUI.skin;
		Matrix4x4 lhs = Matrix4x4.TRS(new Vector3(this.m_LeftUpPosition.x, this.m_LeftUpPosition.y), Quaternion.identity, Vector3.one);
		GUI.matrix = lhs * Matrix4x4.Scale(new Vector3(this.m_Scale, this.m_Scale, 1f)) * lhs.inverse * matrix;
		GUI.skin = this.skin;
		GUILayout.Window(0, this.m_LeftUpPosition, new GUI.WindowFunction(this.DrawWindow), "Debugger ", Array.Empty<GUILayoutOption>());
		this.CheckDrag();
		GUI.matrix = matrix;
		GUI.skin = guiskin;
	}

	private void DrawWindow(int windowID)
	{
		GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
		bool flag = GUILayout.Toggle(this.m_IsScale, "放大一倍", new GUILayoutOption[]
		{
			GUILayout.Width(100f),
			GUILayout.Height(30f)
		});
		if (flag != this.m_IsScale)
		{
			this.m_IsScale = flag;
			this.m_Scale = (float)(this.m_IsScale ? 2 : 1);
		}
		if (GUILayout.Button("关闭", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.Show = !this.Show;
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
		this.m_SelectedTool = GUILayout.Toolbar(this.m_SelectedTool, this.toolBar, Array.Empty<GUILayoutOption>());
		GUILayout.EndHorizontal();
		if (this.m_SelectedTool == 0)
		{
			this.DrawCard();
		}
		else if (this.m_SelectedTool == 1)
		{
			this.DrawFunction();
		}
		GUI.DragWindow(new Rect(0f, 0f, 10000f, 20f));
	}

	private void DrawCard()
	{
		GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
		List<CardData> cards = this.GameController.CardDataModMap.Cards;
		int count = cards.Count;
		GUILayout.Label("名称", new GUILayoutOption[]
		{
			GUILayout.Width(50f)
		});
		this.m_SearchText = GUILayout.TextField(this.m_SearchText, new GUILayoutOption[]
		{
			GUILayout.Width(100f),
			GUILayout.Height(50f)
		});
		this.m_ScrollViewPos = GUILayout.BeginScrollView(this.m_ScrollViewPos, new GUILayoutOption[]
		{
			GUILayout.Width(150f),
			GUILayout.Height(200f)
		});
		for (int i = 0; i < cards.Count; i++)
		{
			if ((string.IsNullOrEmpty(this.m_SearchText) || cards[i].Name.Contains(this.m_SearchText)) && GUILayout.Button(cards[i].Name, Array.Empty<GUILayoutOption>()))
			{
				CardData cardData = Card.InitCardDataByID(cards[i].Name);
				cardData.Count = 1;
				Card.InitACardDataToPlayerTable(cardData);
			}
		}
		GUILayout.EndScrollView();
		GUILayout.EndHorizontal();
	}

	private void DrawFunction()
	{
		GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
		if (GUILayout.Button("绘画大赛", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.m_TestSub.PicMatch();
		}
		if (GUILayout.Button("雕塑大赛", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.m_TestSub.CarvingMatch();
		}
		if (GUILayout.Button("大型雕塑制作", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.m_TestSub.LargeCarving();
		}
		if (GUILayout.Button("中型雕塑制作", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.m_TestSub.MediumCarving();
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
		if (GUILayout.Button("绘画制作", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.m_TestSub.Pic();
		}
		if (GUILayout.Button("显示列表", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.m_TestSub.OpenList();
		}
		if (GUILayout.Button("商人贾富", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.m_TestSub.OnButtonShow("商人贾富");
		}
		if (GUILayout.Button("全部", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.m_TestSub.OnButtonShow("");
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
		if (GUILayout.Button("插入Log20", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.m_TestSub.AddLogs(20);
		}
		if (GUILayout.Button("插入log", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.m_TestSub.AddLogs(1);
		}
		if (GUILayout.Button("添加字幕", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.m_TestSub.TestSubtitle();
		}
		if (GUILayout.Button("显示引导", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.m_TestSub.TestGuide();
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
		if (!this.GameController.IsTimeStop && GUILayout.Button("暂停DeltaT", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.GameController.ChangeTimePause(!this.GameController.IsTimeStop);
		}
		if (this.GameController.IsTimeStop && GUILayout.Button("恢复DeltaT", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.GameController.ChangeTimePause(!this.GameController.IsTimeStop);
		}
		if (GUILayout.Button("2", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.GameController.ChangeTimeScale(2f);
		}
		if (GUILayout.Button("机械臂", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			CardData cardData = this.GameController.CardDataModMap.getCardDataByModID("箭头高");
			cardData = CardData.CopyCardData(cardData, true);
			cardData.Count = 3;
			CardSlot cardSlot = Card.FindPutableSlotOnPlayerTable(0UL);
			if (cardSlot != null)
			{
				cardSlot.CardSlotData.SetChildCardData(cardData);
			}
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
		GUILayout.Label("测试空间深度:", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		});
		int.TryParse(GUILayout.TextField(this.m_Depth.ToString(), new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}), out this.m_Depth);
		if (GUILayout.Button("生成测试空间", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			CardData cardData2 = Card.InitCardDataByID("空间");
			this.GameController.CurrentTable.GetComponent<OppositeTable>().GetEmptySlot().CardSlotData.SetChildCardData(cardData2);
			this.SetAreaID();
			base.StartCoroutine(this.GenerateTestSpace(this.m_Depth, cardData2));
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
		GUILayout.Label("数值:", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		});
		int.TryParse(GUILayout.TextField(this.m_Depth.ToString(), new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}), out this.m_Depth);
		if (GUILayout.Button("加血", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			DungeonController.Instance.Hero.HeroCard.AddHP += this.m_Depth;
		}
		if (GUILayout.Button("加攻", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			DungeonController.Instance.Hero.HeroCard.InBattleATK += this.m_Depth;
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
		if (GUILayout.Button("全部部署", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.ChangeState(true);
		}
		if (GUILayout.Button("取消部署", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.ChangeState(false);
		}
		Hero hero = DungeonController.Instance.Hero;
		if (hero != null && GUILayout.Button(hero.ConsumeMp ? "不耗蓝" : "耗蓝", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			hero.ConsumeMp = !hero.ConsumeMp;
		}
		GUILayout.EndHorizontal();
	}

	private IEnumerator GenerateTestSpace(int depth, CardData cardData)
	{
		AreaData areaData = GameController.getInstance().GameData.AreaMap[cardData.Attrs["AreaDataID"].ToString()];
		if (depth == 1)
		{
			foreach (CardSlotData cardSlotData in areaData.CardSlotDatas)
			{
				CardData cardData2 = Card.InitCardDataByID("空间测试");
				cardSlotData.SetChildCardData(cardData2);
				AreaData areaData2 = GameController.getInstance().GameData.AreaMap[cardData2.Attrs["AreaDataID"].ToString()];
				if (areaData2.InputCardSlotDataList != null && areaData2.InputCardSlotDataList.Count > 0)
				{
					CardData cardData3 = Card.InitCardDataByID("鲑鱼");
					cardData3.Count = 99;
					areaData2.InputCardSlotDataList[0].SetChildCardData(cardData3);
				}
				yield return null;
			}
			List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		}
		else
		{
			int count = 0;
			foreach (CardSlotData cardSlotData2 in areaData.CardSlotDatas)
			{
				int num = count;
				count = num + 1;
				CardData cardData4 = Card.InitCardDataByID("空间");
				cardSlotData2.SetChildCardData(cardData4);
				yield return base.StartCoroutine(this.GenerateTestSpace(depth - 1, cardData4));
				yield return new WaitForSeconds(2f);
				if (count > 10)
				{
					break;
				}
			}
			List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		}
		yield break;
		yield break;
	}

	private void ChangeState(bool value)
	{
		foreach (AreaData areaData in this.GameController.GameData.AreaMap.Values)
		{
			foreach (CardSlotData cardSlotData in areaData.CardSlotDatas)
			{
				if (cardSlotData.ChildCardData != null)
				{
					cardSlotData.ChildCardData.CurrentAreaID = areaData.ID;
					areaData.Name.Contains("空间测试");
				}
			}
		}
	}

	private void SetAreaID()
	{
		foreach (AreaData areaData in this.GameController.GameData.AreaMap.Values)
		{
			foreach (CardSlotData cardSlotData in areaData.CardSlotDatas)
			{
				if (cardSlotData.ChildCardData != null)
				{
					cardSlotData.ChildCardData.CurrentAreaID = areaData.ID;
				}
			}
		}
	}

	private void CheckDrag()
	{
		if (Event.current.type == EventType.MouseDown)
		{
			this.m_Offset = Event.current.mousePosition - new Vector2(this.m_LeftUpPosition.xMin, this.m_LeftUpPosition.yMin);
		}
		if (!this.CheckOffset())
		{
			return;
		}
		if (Event.current.type == EventType.MouseDrag)
		{
			this.m_LeftUpPosition.x = Event.current.mousePosition.x - this.m_Offset.x;
			this.m_LeftUpPosition.y = Event.current.mousePosition.y - this.m_Offset.y;
		}
		if (this.m_LeftUpPosition.x + this.m_LeftUpPosition.width < 0f)
		{
			this.m_LeftUpPosition.x = this.m_LeftUpPosition.x + this.m_LeftUpPosition.width;
		}
		if (this.m_LeftUpPosition.y + this.m_LeftUpPosition.height < 0f)
		{
			this.m_LeftUpPosition.y = this.m_LeftUpPosition.y + this.m_LeftUpPosition.height;
		}
		if (this.m_LeftUpPosition.x + this.m_LeftUpPosition.width > (float)Screen.width)
		{
			this.m_LeftUpPosition.x = (float)Screen.width - this.m_LeftUpPosition.width;
		}
		if (this.m_LeftUpPosition.y + this.m_LeftUpPosition.height > (float)Screen.height)
		{
			this.m_LeftUpPosition.y = (float)Screen.height - this.m_LeftUpPosition.height;
		}
	}

	private bool CheckOffset()
	{
		return this.m_Offset.x >= 0f && this.m_Offset.y >= 0f && this.m_Offset.x <= this.m_LeftUpPosition.width && this.m_Offset.y <= this.m_LeftUpPosition.height;
	}

	public static ProfilerMarker pixelTestPerfMarker = new ProfilerMarker("PixelTest");

	public bool Show;

	public GUISkin skin;

	private TestSub m_TestSub;

	private float m_Scale = 1f;

	private bool m_IsScale;

	private Vector2 m_ScrollViewPos = Vector2.zero;

	private Rect m_LeftUpPosition = new Rect(30f, 30f, 500f, 300f);

	private string m_SearchText;

	private string[] toolBar = new string[]
	{
		"卡牌",
		"功能"
	};

	private int m_SelectedTool;

	private Vector2 m_Offset;

	private int m_Depth = 1;

	private const string c_Space = "空间";

	private const string c_SpaceTest = "空间测试";

	private const string c_AreaDataID = "AreaDataID";
}
