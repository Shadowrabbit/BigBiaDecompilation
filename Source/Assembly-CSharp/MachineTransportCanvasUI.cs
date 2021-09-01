using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MachineTransportCanvasUI : UIControlBase
{
	public void InitThumbnail(string tag = "全部")
	{
		this.ResetPanel();
		this.ThumbnailGo.GetComponent<RectTransform>().sizeDelta = new Vector2(this.ContentPanel.rect.width, 50f);
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
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ThumbnailGo, this.ThumbnailGo.transform.parent);
				gameObject.SetActive(true);
				gameObject.transform.GetComponentInChildren<TMP_Text>().text = cardData.Name;
				gameObject.transform.GetComponentInChildren<MachineTransportItemUI>().CardData = cardData;
				gameObject.transform.GetComponentInChildren<MachineTransportItemUI>().chooseCardData = this.chooseCardData;
				gameObject.SetActive(true);
				this.m_Items.Add(gameObject);
			}
		}
	}

	public void CloseThumbnailCanvas()
	{
		GameUIController.Instance.CloseUI(typeof(MachineTransportScreen));
		GameController.getInstance().GameEventManager.CurrentActEnd();
		UnityEngine.Object.DestroyImmediate(GameController.getInstance().CurrentAct.gameObject);
	}

	public override void Init(object[] obj = null)
	{
		base.Init(obj);
		this.LoadGameData();
		if (obj != null && obj.Length != 0 && obj[0] is CardData)
		{
			this.chooseCardData = (obj[0] as CardData);
		}
		this.InitThumbnail("全部");
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

	public void ShowAllItems()
	{
		this.ResetPanel();
		this.InitThumbnail("全部");
	}

	public void ShowBuildings()
	{
		this.ResetPanel();
		this.InitThumbnail("建筑");
	}

	public void ShowBasics()
	{
		this.ResetPanel();
		this.InitThumbnail("基本");
	}

	public void ShowFurnitures()
	{
		this.ResetPanel();
		this.InitThumbnail("家具");
	}

	public void ShowTools()
	{
		this.ResetPanel();
		this.InitThumbnail("工具");
	}

	public void ShowWeapons()
	{
		this.ResetPanel();
		this.InitThumbnail("装备");
	}

	public void ShowCharacters()
	{
		this.ResetPanel();
		this.InitThumbnail("角色");
	}

	public void ShowMinions()
	{
		this.ResetPanel();
		this.InitThumbnail("随从");
	}

	public void ShowFoods()
	{
		this.ResetPanel();
		this.InitThumbnail("食物");
	}

	public void ShowFishes()
	{
		this.ResetPanel();
		this.InitThumbnail("鱼");
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

	public GameObject ThumbnailGo;

	public RectTransform ContentPanel;

	private List<GameObject> m_Items = new List<GameObject>();

	public CardData chooseCardData;

	public TMP_Text OptionName;

	[Header("选项区域")]
	public GameObject OptionsArea;

	private bool isShowOptions;

	private Dictionary<string, List<CardData>> CardsWithTag = new Dictionary<string, List<CardData>>();
}
