using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneBoothController : MonoBehaviour
{
	private PhoneBoothController()
	{
		PhoneBoothController.Instance = this;
	}

	private void Start()
	{
		this.AllUnlockedPanel = new List<GameObject>();
		EventTriggerListener.Get(this.CancelBtn).onClick = new EventTriggerListener.VoidDelegate(this.OnCancelBtn);
		this.UnLockCards = new List<CardData>();
		this.m_Spacing = (this.m_Width - this.m_Column * this.m_ObjWidth) / (this.m_Column - 1f) + this.m_ObjWidth;
		this.InitAllCardList();
	}

	private void OnCancelBtn(GameObject go)
	{
		if (go == this.CancelBtn)
		{
			Cursor.SetCursor(this.CurrentCursor, Vector2.zero, CursorMode.Auto);
			EffectAudioManager.Instance.PlayEffectAudio(15, null);
			SceneManager.UnloadSceneAsync("PhoneBoothScene");
		}
	}

	private void InitAllCardList()
	{
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		foreach (CardData cardData in cards)
		{
			if (cardData.HasTag(TagMap.道具) && GlobalController.Instance.GlobalData.LockedItemsModID.Contains(cardData.ModID))
			{
				this.ToolAndWeaponList.Add(cardData);
			}
			else if (cardData.HasTag(TagMap.玩具房间) && GlobalController.Instance.GlobalData.LockedToysModID.Contains(cardData.ModID))
			{
				this.ToyList.Add(cardData);
			}
			else if (cardData.HasTag(TagMap.地点) && cardData.HasTag(TagMap.谷疏) && GlobalController.Instance.GlobalData.LockedSpacesModID.Contains(cardData.ModID))
			{
				this.SpaceList.Add(cardData);
			}
		}
		foreach (CardData cardData2 in cards)
		{
			if (cardData2.HasTag(TagMap.道具) && GlobalController.Instance.GlobalData.AllItemsID.Contains(cardData2.ModID))
			{
				this.ToolAndWeaponList.Add(cardData2);
			}
			else if (cardData2.HasTag(TagMap.玩具房间) && GlobalController.Instance.GlobalData.AllToysID.Contains(cardData2.ModID))
			{
				this.ToyList.Add(cardData2);
			}
			else if (cardData2.HasTag(TagMap.地点) && cardData2.HasTag(TagMap.谷疏))
			{
				this.SpaceList.Add(cardData2);
			}
		}
		this.ShowAllCards();
	}

	private void ShowAllCards()
	{
		this.ShowCards("toy");
		this.ShowCards("tool");
		this.ShowCards("hero");
		this.ShowCards("space");
	}

	private void ShowCards(string type)
	{
		List<CardData> list = new List<CardData>();
		if (type != null)
		{
			if (!(type == "toy"))
			{
				if (!(type == "tool"))
				{
					if (!(type == "hero"))
					{
						if (type == "space")
						{
							list = this.SpaceList;
							this.SpaceLabel.transform.position = this.m_StartPoint + new Vector3(0f, 0f, -this.m_Spacing * this.m_Row);
						}
					}
					else
					{
						list = this.HeroList;
						this.HeroLabel.transform.position = this.m_StartPoint + new Vector3(0f, 0f, -this.m_Spacing * this.m_Row);
					}
				}
				else
				{
					list = this.ToolAndWeaponList;
					this.ToolLabel.transform.position = this.m_StartPoint + new Vector3(0f, 0f, -this.m_Spacing * this.m_Row);
				}
			}
			else
			{
				list = this.ToyList;
				this.ToyLabel.transform.position = this.m_StartPoint + new Vector3(0f, 0f, -this.m_Spacing * this.m_Row);
			}
		}
		this.m_Row += 1f;
		if (list.Count > 0)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (GlobalController.Instance.GlobalData.LockedItemsModID.Contains(list[i].ModID) || GlobalController.Instance.GlobalData.LockedToysModID.Contains(list[i].ModID) || GlobalController.Instance.GlobalData.LockedSpacesModID.Contains(list[i].ModID))
				{
					UnityEngine.Object.Instantiate<GameObject>(this.BorderObj).transform.position = this.m_StartPoint + new Vector3(this.m_Spacing * (float)((int)((float)i % this.m_Column)), 0f, -this.m_Spacing * (float)((int)((float)i / this.m_Column + this.m_Row)));
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>(list[i].Model));
					gameObject.transform.position = this.m_StartPoint + new Vector3(this.m_Spacing * (float)((int)((float)i % this.m_Column)), 0f, -this.m_Spacing * (float)((int)((float)i / this.m_Column + this.m_Row)));
					PhoneCardInfo phoneCardInfo;
					if (gameObject.transform.childCount > 0)
					{
						gameObject.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
						phoneCardInfo = gameObject.transform.GetChild(0).gameObject.AddComponent<PhoneCardInfo>();
					}
					else
					{
						gameObject.transform.gameObject.AddComponent<BoxCollider>();
						phoneCardInfo = gameObject.transform.gameObject.AddComponent<PhoneCardInfo>();
					}
					phoneCardInfo.cardData = list[i];
				}
				else
				{
					UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Card/Unknown")).transform.position = this.m_StartPoint + new Vector3(this.m_Spacing * (float)((int)((float)i % this.m_Column)), 0f, -this.m_Spacing * (float)((int)((float)i / this.m_Column + this.m_Row)));
				}
			}
			this.m_Row += (float)Mathf.CeilToInt((float)list.Count / this.m_Column);
			return;
		}
		UnityEngine.Object.Instantiate<GameObject>(this.NoneObj).transform.position = this.m_StartPoint + new Vector3(0f, 0f, -this.m_Spacing * this.m_Row);
		this.m_Row += 1f;
	}

	private void FixedUpdate()
	{
		if (Input.mousePosition.y <= (float)(Screen.height / 10) && this.Camera.transform.position.z > 3f - this.m_Row)
		{
			Cursor.SetCursor(this.NextCursor, Vector2.zero, CursorMode.Auto);
			this.CheckHaveUnlockedPanel();
			this.Camera.transform.position += Vector3.back * this.moveSpeed;
			return;
		}
		if (Input.mousePosition.y >= (float)(Screen.height / 10 * 9) && this.Camera.transform.position.z < 0f)
		{
			Cursor.SetCursor(this.PreCursor, Vector2.zero, CursorMode.Auto);
			this.CheckHaveUnlockedPanel();
			this.Camera.transform.position += Vector3.forward * this.moveSpeed;
			return;
		}
		Cursor.SetCursor(this.CurrentCursor, Vector2.zero, CursorMode.Auto);
	}

	private void Update()
	{
		if (Input.GetAxis("Mouse ScrollWheel") < 0f && this.Camera.transform.position.z > 3f - this.m_Row)
		{
			Cursor.SetCursor(this.NextCursor, Vector2.zero, CursorMode.Auto);
			this.CheckHaveUnlockedPanel();
			this.Camera.transform.position += Vector3.back * this.moveSpeed * 2.5f;
			return;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0f && this.Camera.transform.position.z < 0f)
		{
			Cursor.SetCursor(this.PreCursor, Vector2.zero, CursorMode.Auto);
			this.CheckHaveUnlockedPanel();
			this.Camera.transform.position += Vector3.forward * this.moveSpeed * 2.5f;
		}
	}

	public void CheckHaveUnlockedPanel()
	{
		if (this.AllUnlockedPanel.Count > 0)
		{
			for (int i = this.AllUnlockedPanel.Count - 1; i >= 0; i--)
			{
				UnityEngine.Object.Destroy(this.AllUnlockedPanel[i]);
			}
			this.AllUnlockedPanel = new List<GameObject>();
		}
	}

	public static PhoneBoothController Instance;

	public Texture2D PreCursor;

	public Texture2D NextCursor;

	public Texture2D CurrentCursor;

	public Camera Camera;

	public GameObject HeroLabel;

	public GameObject ToolLabel;

	public GameObject ToyLabel;

	public GameObject SpaceLabel;

	public GameObject CancelBtn;

	public Transform Canvas;

	public GameObject BorderObj;

	public GameObject NoneObj;

	[NonSerialized]
	public List<CardData> UnLockCards;

	[NonSerialized]
	public List<GameObject> AllUnlockedPanel;

	private List<CardData> HeroList = new List<CardData>();

	private List<CardData> ToolAndWeaponList = new List<CardData>();

	private List<CardData> ToyList = new List<CardData>();

	private List<CardData> SpaceList = new List<CardData>();

	private float m_ObjWidth = 1f;

	private float m_Width = 12f;

	private float m_Column = 10f;

	private float m_Spacing;

	private float m_Row;

	private Vector3 m_StartPoint = new Vector3(994.5f, 0f, 1.14f);

	public float moveSpeed = 0.1f;
}
