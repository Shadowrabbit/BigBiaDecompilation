using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardsCollectionMgr : MonoBehaviour
{
	private CardsCollectionMgr()
	{
		CardsCollectionMgr.Instance = this;
	}

	public void Start()
	{
		CardsCollectionMgr.Instance = this;
		this.Init("All");
	}

	public void Init(string type = "All")
	{
		List<CardData> list = new List<CardData>();
		if (type != null)
		{
			if (!(type == "All"))
			{
				if (type == "Toy")
				{
					List<string> lockedToysModID = GlobalController.Instance.GlobalData.LockedToysModID;
					this.selectedToys = new List<CardData>();
					foreach (string modId in lockedToysModID)
					{
						list.Add(GameController.getInstance().CardDataModMap.getCardDataByModID(modId));
					}
				}
			}
			else
			{
				list = GameController.getInstance().CardDataModMap.Cards;
			}
		}
		if (!CardsCollectionMgr.isInited)
		{
			foreach (CardData cardData in list)
			{
				foreach (TagMap tagMap in CardsCollectionMgr.displayTapMaps)
				{
					if (cardData.HasTag(tagMap))
					{
						List<CardData> list2 = null;
						if (CardsCollectionMgr.tagMap2CardDatasDic.TryGetValue(tagMap, out list2))
						{
							list2.Add(cardData);
						}
						else
						{
							CardsCollectionMgr.tagMap2CardDatasDic.Add(tagMap, new List<CardData>
							{
								cardData
							});
						}
					}
				}
			}
		}
		CardsCollectionMgr.tagMap2CardDatasDic[TagMap.随从].Sort((CardData x, CardData y) => -x.Rare.CompareTo(y.Rare));
		CardsCollectionMgr.tagMap2CardDatasDic[TagMap.道具].Sort((CardData x, CardData y) => -x.Rare.CompareTo(y.Rare));
		for (int j = 0; j < this.cardSlotsRoot.childCount; j++)
		{
			this.m_SlotsTrans.Add(this.cardSlotsRoot.GetChild(j));
		}
		foreach (GameObject gameObject in this.buttonObjs)
		{
			CardsCollectionButton component = gameObject.GetComponent<CardsCollectionButton>();
			this.buttonObjsDic.Add((TagMap)((long)component.DisplayTagMap), gameObject);
		}
		this.UpdateCards(TagMap.怪物, 0);
		CardsCollectionMgr.isInited = true;
	}

	private void CreateSlots(Vector3 centerPos, Transform root)
	{
		float x = centerPos.x - 7.5f;
		float z = centerPos.x + 8f;
		Vector3 a = new Vector3(x, 0f, z);
		new Vector3(3f, -4f);
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 6; j++)
			{
				Vector3 localPosition = a + new Vector3(3f * (float)j, 0f, -4f * (float)i);
				GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
				gameObject.transform.SetParent(root);
				gameObject.transform.localPosition = localPosition;
				gameObject.transform.localScale = new Vector3(2f, 1f, 3f);
				this.m_SlotsTrans.Add(gameObject.transform);
			}
		}
	}

	private void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out raycastHit))
		{
			Collider collider = raycastHit.collider;
			if (!collider.enabled)
			{
				return;
			}
			if (collider.transform.name.Equals("Cancel"))
			{
				EffectAudioManager.Instance.PlayEffectAudio(15, null);
				SceneManager.UnloadSceneAsync("CardsCollection");
				return;
			}
			if (collider.transform.GetComponent<CardsCollectionInfo>())
			{
				CardData cardData = collider.transform.GetComponent<CardsCollectionInfo>().cardData;
				this.selectedToys.Add(cardData);
			}
		}
	}

	public void UpdateCards(TagMap displayTagMap, int pageCount)
	{
		if (CardsCollectionMgr.isInited)
		{
			GameObject gameObject = this.buttonObjsDic[CardsCollectionMgr.m_CurDisplayTagMap];
			DOTween.Kill(gameObject.transform, false);
			gameObject.transform.localScale = Vector3.one;
		}
		EffectAudioManager.Instance.PlayEffectAudio(13, null);
		this.buttonObjsDic[displayTagMap].transform.DOScale(new Vector3(1.5f, 1f, 1f), 0.25f);
		CardsCollectionMgr.m_CurDisplayTagMap = displayTagMap;
		this.m_CurPageCount = pageCount;
		List<CardData> list = CardsCollectionMgr.tagMap2CardDatasDic[displayTagMap];
		if (displayTagMap == TagMap.怪物)
		{
			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (list[i].HasTag(TagMap.衍生物) || list[i].HasTag(TagMap.BOSS) || list[i].HasTag(TagMap.特殊))
				{
					list.Remove(list[i]);
				}
			}
		}
		if (displayTagMap == TagMap.随从)
		{
			for (int j = list.Count - 1; j >= 0; j--)
			{
				if (list[j].HasTag(TagMap.衍生物) || list[j].HasTag(TagMap.特殊))
				{
					list.Remove(list[j]);
				}
			}
		}
		if (pageCount == 0)
		{
			this.leftButtonObj.SetActive(false);
		}
		else
		{
			this.leftButtonObj.SetActive(true);
		}
		if (list.Count - (pageCount + 1) * 5 * 6 > 0)
		{
			this.rightButtonObj.SetActive(true);
		}
		else
		{
			this.rightButtonObj.SetActive(false);
		}
		int num = 0;
		foreach (Transform transform in this.m_SlotsTrans)
		{
			if (transform.childCount > 0)
			{
				Transform child = transform.GetChild(0);
				child.SetParent(null);
				child.position = CardsCollectionMgr.recyclePos;
			}
			int num2 = pageCount * 30 + num;
			if (num2 < list.Count)
			{
				GameObject prefab = this.GetPrefab(list[num2]);
				prefab.transform.SetParent(transform);
				prefab.transform.localPosition = Vector3.zero;
			}
			num++;
		}
	}

	public void UpdateCards(CardsCollectionPageButton.Direction direction)
	{
		EffectAudioManager.Instance.PlayEffectAudio(13, null);
		if (direction == CardsCollectionPageButton.Direction.Left)
		{
			List<CardData> list = CardsCollectionMgr.tagMap2CardDatasDic[CardsCollectionMgr.m_CurDisplayTagMap];
			int pageCount = Mathf.Max(0, this.m_CurPageCount - 1);
			this.UpdateCards(CardsCollectionMgr.m_CurDisplayTagMap, pageCount);
			return;
		}
		List<CardData> list2 = CardsCollectionMgr.tagMap2CardDatasDic[CardsCollectionMgr.m_CurDisplayTagMap];
		int num = this.m_CurPageCount + 1;
		if (list2.Count - num * 5 * 6 > 0)
		{
			this.UpdateCards(CardsCollectionMgr.m_CurDisplayTagMap, num);
		}
	}

	private GameObject GetPrefab(CardData data)
	{
		Debug.Log("图鉴模型数据：======>  " + data.ModID + "   " + data.Model);
		GameObject gameObject = null;
		if (CardsCollectionMgr.cardPrefabsBuffer.TryGetValue(data.Model, out gameObject))
		{
			if (gameObject == null)
			{
				gameObject = Card.InitWithOutData(data, true);
				gameObject.AddComponent<CardsCollectionInfo>().cardData = data;
				gameObject.AddComponent<BoxCollider>();
				gameObject.transform.localScale = Vector3.one * 1.1f;
				CardsCollectionMgr.cardPrefabsBuffer[data.Model] = gameObject;
			}
		}
		else
		{
			gameObject = Card.InitWithOutData(data, true);
			gameObject.AddComponent<CardsCollectionInfo>().cardData = data;
			gameObject.AddComponent<BoxCollider>();
			gameObject.transform.localScale = Vector3.one * 1.1f;
			CardsCollectionMgr.cardPrefabsBuffer.Add(data.Model, gameObject);
		}
		return gameObject.gameObject;
	}

	private const int c_RowCount = 5;

	private const int c_ColumnCount = 6;

	private const float c_RowSpace = 1f;

	private const float c_ColumnSpace = 1f;

	private const float c_CardWidth = 2f;

	private const float c_CardHeight = 3f;

	private static Vector3 recyclePos = new Vector3(-999f, -999f, -999f);

	private static Dictionary<string, GameObject> cardPrefabsBuffer = new Dictionary<string, GameObject>();

	private static Dictionary<TagMap, List<CardData>> tagMap2CardDatasDic = new Dictionary<TagMap, List<CardData>>();

	private static TagMap[] displayTapMaps = new TagMap[]
	{
		TagMap.怪物,
		TagMap.装备,
		TagMap.道具,
		TagMap.随从,
		TagMap.符文
	};

	private static bool isInited;

	private static TagMap m_CurDisplayTagMap;

	public static CardsCollectionMgr Instance;

	public Transform cardSlotsRoot;

	public GameObject leftButtonObj;

	public GameObject rightButtonObj;

	public List<GameObject> buttonObjs;

	private List<Transform> m_SlotsTrans = new List<Transform>();

	private Dictionary<TagMap, GameObject> buttonObjsDic = new Dictionary<TagMap, GameObject>();

	private int m_CurPageCount;

	public List<CardData> selectedToys = new List<CardData>();
}
