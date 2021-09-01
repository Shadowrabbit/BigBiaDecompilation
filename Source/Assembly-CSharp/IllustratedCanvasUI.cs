using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IllustratedCanvasUI : UIControlBase
{
	private void LoadGameData()
	{
		this.CardsWithTag = new Dictionary<string, List<CardData>>();
		this.CardsWithTag.Add("全部", GameController.getInstance().CardDataModMap.Cards);
		this.CardsWithTag.Add("建筑", GameController.getInstance().BuildingModMap.Cards);
		this.CardsWithTag.Add("基本", new List<CardData>());
		this.CardsWithTag.Add("家具", new List<CardData>());
		this.CardsWithTag.Add("工具", new List<CardData>());
		this.CardsWithTag.Add("装备", new List<CardData>());
		this.CardsWithTag.Add("角色", new List<CardData>());
		this.CardsWithTag.Add("随从", new List<CardData>());
		this.CardsWithTag.Add("食物", new List<CardData>());
		this.CardsWithTag.Add("鱼", new List<CardData>());
		foreach (CardData cardData in this.CardsWithTag["全部"])
		{
			if (cardData.HasTag(TagMap.基本))
			{
				this.CardsWithTag["基本"].Add(cardData);
			}
			else if (cardData.HasTag(TagMap.机器))
			{
				this.CardsWithTag["家具"].Add(cardData);
			}
			else if (cardData.HasTag(TagMap.工具))
			{
				this.CardsWithTag["工具"].Add(cardData);
			}
			else if (cardData.HasTag(TagMap.装备))
			{
				this.CardsWithTag["装备"].Add(cardData);
			}
			else if (cardData.HasTag(TagMap.角色))
			{
				this.CardsWithTag["角色"].Add(cardData);
			}
			else if (cardData.HasTag(TagMap.随从))
			{
				this.CardsWithTag["随从"].Add(cardData);
			}
			else if (cardData.HasTag(TagMap.食物))
			{
				this.CardsWithTag["食物"].Add(cardData);
			}
			else if (cardData.HasTag(TagMap.肉))
			{
				this.CardsWithTag["鱼"].Add(cardData);
			}
		}
	}

	public void InitIllustrated(string tag = "全部", bool isbook = false)
	{
		this.CloseTips();
		this.IllustratedGo.GetComponent<RectTransform>().sizeDelta = new Vector2(this.ContentPanel.rect.width, 50f);
		if (isbook)
		{
			new BookDataMap();
			BookDataMap bookDataModMap = GameController.getInstance().BookDataModMap;
			this.m_Items = new List<GameObject>();
			using (List<BookData>.Enumerator enumerator = bookDataModMap.Books.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					BookData bookData = enumerator.Current;
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.IllustratedGo, this.IllustratedGo.transform.parent);
					gameObject.SetActive(true);
					gameObject.transform.GetComponentInChildren<TMP_Text>().text = bookData.Name;
					BookContentUI bookContentUI = gameObject.AddComponent<BookContentUI>();
					bookContentUI.curCanvas = this;
					bookContentUI.BookData = bookData;
					gameObject.SetActive(true);
					this.m_Items.Add(gameObject);
				}
				return;
			}
		}
		List<CardData> list = new List<CardData>();
		if (tag != null)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(tag);
			if (num <= 2669493557U)
			{
				if (num <= 1864332179U)
				{
					if (num != 1583700141U)
					{
						if (num == 1864332179U)
						{
							if (tag == "基本")
							{
								list = this.CardsWithTag["基本"];
							}
						}
					}
					else if (tag == "全部")
					{
						list = this.CardsWithTag["全部"];
					}
				}
				else if (num != 2281073925U)
				{
					if (num != 2518345232U)
					{
						if (num == 2669493557U)
						{
							if (tag == "工具")
							{
								list = this.CardsWithTag["工具"];
							}
						}
					}
					else if (tag == "随从")
					{
						list = this.CardsWithTag["随从"];
					}
				}
				else if (tag == "装备")
				{
					list = this.CardsWithTag["装备"];
				}
			}
			else if (num <= 3469542277U)
			{
				if (num != 3204040794U)
				{
					if (num == 3469542277U)
					{
						if (tag == "食物")
						{
							list = this.CardsWithTag["食物"];
						}
					}
				}
				else if (tag == "家具")
				{
					list = this.CardsWithTag["家具"];
				}
			}
			else if (num != 3640862772U)
			{
				if (num != 4162238011U)
				{
					if (num == 4185847237U)
					{
						if (tag == "角色")
						{
							list = this.CardsWithTag["角色"];
						}
					}
				}
				else if (tag == "鱼")
				{
					list = this.CardsWithTag["鱼"];
				}
			}
			else if (tag == "建筑")
			{
				list = this.CardsWithTag["建筑"];
			}
		}
		this.m_Items = new List<GameObject>();
		foreach (CardData cardData in list)
		{
			if (cardData.Struct != null)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.IllustratedGo, this.IllustratedGo.transform.parent);
				gameObject2.SetActive(true);
				gameObject2.transform.GetComponentInChildren<TMP_Text>().text = cardData.Name;
				IllustratedUI illustratedUI = gameObject2.AddComponent<IllustratedUI>();
				illustratedUI.curCanvas = this;
				illustratedUI.CardData = cardData;
				gameObject2.SetActive(true);
				this.m_Items.Add(gameObject2);
			}
		}
	}

	public void CloseIllustratedCanvas()
	{
		GameUIController.Instance.CloseUI(typeof(IllustratedScreen));
	}

	public override void Init(object[] obj = null)
	{
		base.Init(obj);
		this.LoadGameData();
		this.InitIllustrated("全部", false);
	}

	public void ResetPanel()
	{
		if (this.m_Items.Count > 0)
		{
			foreach (GameObject obj in this.m_Items)
			{
				UnityEngine.Object.Destroy(obj, 0f);
			}
		}
	}

	public void OpenTips(CardData cardData, Vector3 position)
	{
		this.tips.gameObject.SetActive(true);
		this.CurrentArea.SetActive(true);
		this.m_StringBuilder.Clear();
		this.m_StringBuilder.Append(cardData.Name);
		if (!string.IsNullOrEmpty(cardData.desc))
		{
			this.m_StringBuilder.Append("\n\n<color=#AAAAAA>" + cardData.desc + "</color>\n");
		}
		this.m_StringBuilder.Append("\n---------------   ");
		bool flag = false;
		if (cardData.HasTag(TagMap.角色) || cardData.HasTag(TagMap.随从))
		{
			flag = true;
			if (cardData.HasTag(TagMap.角色))
			{
				int intAttr = cardData.GetIntAttr(Constant.CardAttributeName.Level);
				if (intAttr > 0)
				{
					this.m_StringBuilder.Append("\n等级: " + intAttr.ToString());
					int num = cardData.GetIntAttr(Constant.CardAttributeName.EXP) - cardData.GetLevelExp(intAttr);
					int num2 = cardData.GetLevelExp(intAttr + 1) - cardData.GetLevelExp(intAttr);
					this.m_StringBuilder.Append("\n经验: " + num.ToString() + "/" + num2.ToString());
				}
				this.m_StringBuilder.Append("\n生命: " + cardData.HP.ToString() + "/" + cardData.MaxHP.ToString());
				this.m_StringBuilder.Append("\n攻击: " + cardData.ATK.ToString());
				this.m_StringBuilder.Append("\n统御力: " + cardData.GetIntAttr("Leadership").ToString());
			}
			else
			{
				this.m_StringBuilder.Append("\n生命: " + (cardData.MaxHP * cardData.Count).ToString());
				this.m_StringBuilder.Append("\n攻击: " + (cardData.ATK * cardData.Count).ToString());
				this.m_StringBuilder.Append("\n统御力: " + (cardData.GetIntAttr("Leadership") * cardData.Count).ToString());
			}
			this.m_StringBuilder.Append("\n速度: " + cardData.SPD.ToString());
			this.m_StringBuilder.Append("\n射程: " + cardData.ATKRange.ToString());
			this.m_StringBuilder.Append("\n移动: " + cardData.MoveRange.ToString());
			this.m_StringBuilder.Append("\n暴击: " + cardData.CRIT.ToString());
			if (cardData.HasAttr("Weapon") || cardData.HasAttr("Armor"))
			{
				this.m_StringBuilder.Append("\n装备: ");
				string attr = cardData.GetAttr("Weapon");
				if (!string.IsNullOrEmpty(attr))
				{
					this.m_StringBuilder.Append("<size=2.5><color=green>[" + attr + "]</color></size> ");
				}
				string attr2 = cardData.GetAttr("Armor");
				if (!string.IsNullOrEmpty(attr2))
				{
					this.m_StringBuilder.Append("<size=2.5><color=green>[" + attr2 + "]</color></size> ");
				}
			}
			int num3 = 0;
			using (List<CardLogic>.Enumerator enumerator = cardData.CardLogics.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardLogic cardLogic = enumerator.Current;
					if (!string.IsNullOrEmpty(cardLogic.displayName))
					{
						if (num3 == 0)
						{
							this.m_StringBuilder.Append("\n技能: ");
						}
						this.m_StringBuilder.Append("<size=2.5><color=green>[" + cardLogic.displayName + "]</color></size> ");
						num3++;
					}
				}
				goto IL_93D;
			}
		}
		if (cardData.HasTag(TagMap.装备))
		{
			flag = true;
			if (cardData.MaxHP != 0)
			{
				this.m_StringBuilder.Append("\n生命: " + cardData.HP.ToString());
			}
			if (cardData.ATK != 0)
			{
				this.m_StringBuilder.Append("\n攻击: " + cardData.ATK.ToString());
			}
			if (cardData.SPD != 0)
			{
				this.m_StringBuilder.Append("\n速度: " + cardData.SPD.ToString());
			}
			if (cardData.ATKRange != 0)
			{
				this.m_StringBuilder.Append("\n射程: " + cardData.ATKRange.ToString());
			}
			if (cardData.MoveRange != 0)
			{
				this.m_StringBuilder.Append("\n移动: " + cardData.MoveRange.ToString());
			}
			if (cardData.CRIT != 0)
			{
				this.m_StringBuilder.Append("\n暴击: " + cardData.CRIT.ToString());
			}
			int num4 = 0;
			using (List<CardLogic>.Enumerator enumerator = cardData.CardLogics.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardLogic cardLogic2 = enumerator.Current;
					if (num4 == 0)
					{
						this.m_StringBuilder.Append("\n技能: ");
					}
					this.m_StringBuilder.Append("<size=2.5><color=green>[" + cardLogic2.displayName + "]</color></size> ");
					num4++;
				}
				goto IL_93D;
			}
		}
		if (cardData.HasTag(TagMap.任务))
		{
			flag = true;
			if (GameController.getInstance().GameData.TaskMap.ContainsKey(cardData.Name))
			{
				TaskData taskData = GameController.getInstance().GameData.TaskMap[cardData.Name];
				if (taskData != null)
				{
					int num5 = 1;
					foreach (TaskStep taskStep in taskData.Steps)
					{
						TaskState state = taskStep.State;
						if (state != TaskState.SUCCESS)
						{
							if (state != TaskState.FAILURE)
							{
								this.m_StringBuilder.Append("<color=white>");
							}
							else
							{
								this.m_StringBuilder.Append("<color=green>");
							}
						}
						else
						{
							this.m_StringBuilder.Append("<color=green>");
						}
						switch (taskStep.Type)
						{
						case TaskStepType.DEFEAT:
						{
							TaskStepDefeat taskStepDefeat = taskStep as TaskStepDefeat;
							this.m_StringBuilder.Append(string.Concat(new string[]
							{
								"\n",
								num5.ToString(),
								". 消灭 ",
								taskStepDefeat.TargetName,
								" (",
								taskStepDefeat.Count.ToString(),
								"/",
								taskStepDefeat.MaxCount.ToString(),
								")"
							}));
							break;
						}
						case TaskStepType.ESCORT:
						{
							TaskStepEscort taskStepEscort = taskStep as TaskStepEscort;
							this.m_StringBuilder.Append(string.Concat(new string[]
							{
								"\n",
								num5.ToString(),
								". 护送 ",
								taskStepEscort.TargetName,
								" 到 ",
								taskStepEscort.Destination
							}));
							break;
						}
						case TaskStepType.TALK:
						{
							TaskStepTalk taskStepTalk = taskStep as TaskStepTalk;
							this.m_StringBuilder.Append("\n" + num5.ToString() + "." + taskStepTalk.Tip);
							break;
						}
						case TaskStepType.COLLECT:
						{
							TaskStepCollect taskStepCollect = taskStep as TaskStepCollect;
							this.m_StringBuilder.Append(string.Concat(new string[]
							{
								"\n",
								num5.ToString(),
								". 获得 ",
								taskStepCollect.TargetName,
								" (",
								taskStepCollect.Count.ToString(),
								"/",
								taskStepCollect.MaxCount.ToString(),
								")"
							}));
							break;
						}
						case TaskStepType.EXPLORE:
						{
							TaskStepExplore taskStepExplore = taskStep as TaskStepExplore;
							this.m_StringBuilder.Append("\n请前往目的地->" + taskStepExplore.Destination);
							break;
						}
						case TaskStepType.RECRUIT:
						{
							TaskStepRecruit taskStepRecruit = taskStep as TaskStepRecruit;
							this.m_StringBuilder.Append(string.Concat(new string[]
							{
								"\n请招募 ",
								taskStepRecruit.MaxCount.ToString(),
								"名",
								taskStepRecruit.TargetType,
								" (",
								taskStepRecruit.Count.ToString(),
								"/",
								taskStepRecruit.MaxCount.ToString(),
								")"
							}));
							break;
						}
						}
						this.m_StringBuilder.Append("</color>");
						this.m_StringBuilder.Append("\n");
						num5++;
					}
				}
				if (taskData.Rewards.Count > 0)
				{
					this.m_StringBuilder.Append("\n报酬: ");
					foreach (KeyValuePair<string, int> keyValuePair in taskData.Rewards)
					{
						this.m_StringBuilder.Append(keyValuePair.Key + "X" + keyValuePair.Value.ToString() + " ");
					}
				}
			}
		}
		IL_93D:
		if (cardData.Price > 0)
		{
			flag = true;
			this.m_StringBuilder.Append("\n价格: " + cardData.Price.ToString());
		}
		if (cardData.Attrs.ContainsKey("营养价值"))
		{
			flag = true;
			StringBuilder stringBuilder = this.m_StringBuilder;
			string str = "\n营养价值: ";
			object obj = cardData.Attrs["营养价值"];
			stringBuilder.Append(str + ((obj != null) ? obj.ToString() : null));
		}
		if (flag && cardData.CardTags > 0UL)
		{
			this.m_StringBuilder.Append("\n---------------\n");
		}
		for (int i = 0; i < 64; i++)
		{
			if ((cardData.CardTags & 1UL << i) != 0UL)
			{
				this.m_StringBuilder.Append("\n<color=green>[" + ((TagMap)(1L << i)).ToString() + "]</color>");
			}
		}
		this.m_StringBuilder.Append("\n" + cardData.Detail);
		this.tips.GetComponentInChildren<TextMeshProUGUI>().text = this.m_StringBuilder.ToString();
		if (cardData.StructTexture != null)
		{
			this.tips.StructPanel.SetActive(false);
			float num6 = (float)cardData.StructTexture.width;
			float num7 = (float)cardData.StructTexture.height;
			float num8 = (num6 < num7) ? num7 : num6;
			this.tips.StructMask.pixelsPerUnitMultiplier = 0.25f * num8;
			Texture2D texture2D = ImageTools.NormalizeTo256(cardData.StructTexture, new Color32[256], 0);
			this.CurrentImage.sprite = Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2(0.5f, 0.5f), 2f);
		}
		else
		{
			this.tips.StructPanel.SetActive(false);
		}
		RectTransform[] componentsInChildren = this.tips.GetComponentsInChildren<RectTransform>();
		for (int j = 0; j < componentsInChildren.Length; j++)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(componentsInChildren[j]);
		}
		this.isShowImage = true;
	}

	public void CloseTips()
	{
		this.ResetPanel();
		this.BookContentText.gameObject.SetActive(false);
		if (!this.tips.gameObject.activeInHierarchy)
		{
			return;
		}
		this.tips.gameObject.SetActive(false);
		this.tips.StructPanel.SetActive(false);
		this.CurrentArea.SetActive(false);
		this.isShowImage = false;
	}

	private new void Update()
	{
		Vector2 vector = new Vector2(Input.mousePosition.x - this.CurrentArea.GetComponent<RectTransform>().anchoredPosition.x, Input.mousePosition.y - this.CurrentArea.GetComponent<RectTransform>().anchoredPosition.y);
		if (this.isShowImage)
		{
			if (vector.x > 0f && vector.x - this.CurrentArea.GetComponent<RectTransform>().rect.width <= 0f && vector.y > 0f && vector.y - this.CurrentArea.GetComponent<RectTransform>().rect.height <= 0f)
			{
				vector /= this.CurrentArea.GetComponent<RectTransform>().rect.width / 16f;
				Color32 color = this.CurrentImage.sprite.texture.GetPixel((int)vector.x, (int)vector.y);
				for (int i = 0; i < CommonAttribute.MaterialColors.Length; i++)
				{
					if (color.Equals(CommonAttribute.MaterialColors[i]))
					{
						this.TargetMaterilName.text = CommonAttribute.MaterialNames[i];
						this.TargetMaterilName.color = CommonAttribute.MaterialColors[i];
						return;
					}
					this.TargetMaterilName.text = "";
				}
				return;
			}
			this.TargetMaterilName.text = "";
		}
	}

	public void ShowBookContent(BookData book)
	{
		this.BookContentText.gameObject.SetActive(true);
		this.BookContentText.text = book.Detail;
	}

	public void ShowAllItems()
	{
		this.CloseTips();
		this.InitIllustrated("全部", false);
	}

	public void ShowBuildings()
	{
		this.CloseTips();
		this.InitIllustrated("建筑", false);
	}

	public void ShowBasics()
	{
		this.CloseTips();
		this.InitIllustrated("基本", false);
	}

	public void ShowFurnitures()
	{
		this.CloseTips();
		this.InitIllustrated("家具", false);
	}

	public void ShowTools()
	{
		this.CloseTips();
		this.InitIllustrated("工具", false);
	}

	public void ShowWeapons()
	{
		this.CloseTips();
		this.InitIllustrated("装备", false);
	}

	public void ShowCharacters()
	{
		this.CloseTips();
		this.InitIllustrated("角色", false);
	}

	public void ShowMinions()
	{
		this.CloseTips();
		this.InitIllustrated("随从", false);
	}

	public void ShowFoods()
	{
		this.CloseTips();
		this.InitIllustrated("食物", false);
	}

	public void ShowFishes()
	{
		this.CloseTips();
		this.InitIllustrated("鱼", false);
	}

	public void ShowBooks()
	{
		this.CloseTips();
		this.InitIllustrated("全部", true);
	}

	public void OnOptionButtonClick()
	{
		this.OnSelectButtonClick(this.OptionName.text);
	}

	public void OnSelectButtonClick(string ClassName)
	{
		this.CloseOptions();
		this.OptionName.text = ClassName;
		if (ClassName != null)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(ClassName);
			if (num <= 2669493557U)
			{
				if (num <= 1864332179U)
				{
					if (num != 1583700141U)
					{
						if (num != 1864332179U)
						{
							return;
						}
						if (!(ClassName == "基本"))
						{
							return;
						}
						this.ShowBasics();
						return;
					}
					else
					{
						if (!(ClassName == "全部"))
						{
							return;
						}
						this.ShowAllItems();
						return;
					}
				}
				else if (num != 2281073925U)
				{
					if (num != 2518345232U)
					{
						if (num != 2669493557U)
						{
							return;
						}
						if (!(ClassName == "工具"))
						{
							return;
						}
						this.ShowTools();
						return;
					}
					else
					{
						if (!(ClassName == "随从"))
						{
							return;
						}
						this.ShowMinions();
						return;
					}
				}
				else
				{
					if (!(ClassName == "装备"))
					{
						return;
					}
					this.ShowWeapons();
					return;
				}
			}
			else if (num <= 3469542277U)
			{
				if (num != 3204040794U)
				{
					if (num != 3469542277U)
					{
						return;
					}
					if (!(ClassName == "食物"))
					{
						return;
					}
					this.ShowFoods();
					return;
				}
				else
				{
					if (!(ClassName == "家具"))
					{
						return;
					}
					this.ShowFurnitures();
					return;
				}
			}
			else if (num != 3640862772U)
			{
				if (num != 4162238011U)
				{
					if (num != 4185847237U)
					{
						return;
					}
					if (!(ClassName == "角色"))
					{
						return;
					}
					this.ShowCharacters();
					return;
				}
				else
				{
					if (!(ClassName == "鱼"))
					{
						return;
					}
					this.ShowFishes();
				}
			}
			else
			{
				if (!(ClassName == "建筑"))
				{
					return;
				}
				this.ShowBuildings();
				return;
			}
		}
	}

	public void ShowOptions()
	{
		this.isShowOptions = true;
		this.OptionsArea.SetActive(true);
	}

	public void CloseOptions()
	{
		this.isShowOptions = false;
		this.OptionsArea.SetActive(false);
	}

	public void OnMoreBtnClick()
	{
		if (this.isShowOptions)
		{
			this.CloseOptions();
			return;
		}
		this.ShowOptions();
	}

	public GameObject IllustratedGo;

	public RectTransform ContentPanel;

	public TMP_Text BookContentText;

	public TipsUI tips;

	public TMP_Text TargetMaterilName;

	public Image CurrentImage;

	public GameObject CurrentArea;

	private StringBuilder m_StringBuilder = new StringBuilder();

	private List<GameObject> m_Items = new List<GameObject>();

	private Dictionary<string, List<CardData>> CardsWithTag = new Dictionary<string, List<CardData>>();

	private bool isShowImage;

	public TMP_Text OptionName;

	[Header("选项区域")]
	public GameObject OptionsArea;

	private bool isShowOptions;
}
