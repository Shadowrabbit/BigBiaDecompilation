using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingArea : MonoBehaviour
{
	private void Start()
	{
		if (this.m_Canvas == null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("UI/Canvas/BuildingCanvas"));
			this.m_Canvas = gameObject.transform.GetComponent<BuildingCanvas>();
			this.m_Canvas.BuildingArea = this;
			this.m_Canvas.MoneyText.text = (GlobalController.Instance.GlobalData.Money.ToString() ?? "");
			this.m_Canvas.WealthText.text = (GlobalController.Instance.GetBuildingWealth().ToString() ?? "");
		}
		this.InitCards();
		this.LoadCards(8521215115264UL, 0);
	}

	private void InitCards()
	{
		foreach (CardData cardData in GameController.ins.CardDataModMap.Cards)
		{
			if (cardData.HasTag(TagMap.玩具) || (cardData.HasTag(TagMap.随从) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.特殊)))
			{
				this.m_Cards.Add(cardData);
			}
		}
	}

	public void LoadCards(ulong type = 8521215115264UL, int page = 0)
	{
		this.ClearDatas();
		this.m_PageIndex = page;
		this.m_Type = type;
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in this.m_Cards)
		{
			if ((cardData.CardTags & type) > 0UL)
			{
				list.Add(cardData);
			}
		}
		if (list.Count == 0)
		{
			Debug.Log("当前没有可以显示的数据！数据类型：" + type.ToString());
			return;
		}
		for (int i = page * 10; i < (page + 1) * 10; i++)
		{
			if (i == list.Count)
			{
				break;
			}
			CardData building = CardData.CopyCardData(list[i], true);
			GameObject gameObject = Card.InitWithOutData(building, true);
			gameObject.transform.SetParent(this.ShowPoint);
			gameObject.transform.localPosition = new Vector3(3.42f * (float)(i % 10), 0f, 0f);
			gameObject.transform.localRotation = Quaternion.Euler(0f, 30f, 0f);
			Vector3 modelSize = this.GetModelSize(gameObject.transform);
			float d = Mathf.Min(new float[]
			{
				1f / modelSize.x,
				1f / modelSize.y,
				1f / modelSize.z
			});
			gameObject.transform.localScale = Vector3.one * d;
			this.showItems.Add(gameObject);
			this.m_Canvas.Buildings[i % 10].SetBuildingDesc(building);
			this.m_Canvas.Buildings[i % 10].BuildingBtn.onClick.AddListener(delegate()
			{
				this.OnBuildingDescClicked(building);
			});
		}
	}

	public void NextPage()
	{
		int num = 0;
		using (List<CardData>.Enumerator enumerator = this.m_Cards.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if ((enumerator.Current.CardTags & this.m_Type) > 0UL)
				{
					num++;
				}
			}
		}
		if ((this.m_PageIndex + 1) * 10 > num)
		{
			return;
		}
		this.LoadCards(this.m_Type, this.m_PageIndex + 1);
	}

	public void PrePage()
	{
		if (this.m_PageIndex == 0)
		{
			return;
		}
		this.LoadCards(this.m_Type, this.m_PageIndex - 1);
	}

	private void ClearDatas()
	{
		for (int i = this.showItems.Count - 1; i >= 0; i--)
		{
			UnityEngine.Object.DestroyImmediate(this.showItems[i]);
		}
		this.showItems = new List<GameObject>();
		for (int j = 0; j < this.m_Canvas.Buildings.Count; j++)
		{
			this.m_Canvas.Buildings[j].Data = null;
			this.m_Canvas.Buildings[j].StateGo.SetActive(false);
			this.m_Canvas.Buildings[j].DescText.text = "";
			this.m_Canvas.Buildings[j].BuildingBtn.onClick.RemoveAllListeners();
		}
	}

	private void OnBuildingDescClicked(CardData data)
	{
		CardData cardData = CardData.CopyCardData(data, true);
		this.m_IsBuilding = true;
		this.m_Target = data;
		if (this.m_TargetGo != null)
		{
			UnityEngine.Object.DestroyImmediate(this.m_TargetGo);
		}
		this.m_TargetGo = Card.InitWithOutData(cardData, true);
		this.CheckMoney();
		this.m_TargetGo.transform.position = new Vector3(999f, 999f, 999f);
		BoxCollider boxCollider = this.m_TargetGo.AddComponent<BoxCollider>();
		boxCollider.size = new Vector3((float)this.m_Target.CoveredWidth * 0.9f, 1f, (float)this.m_Target.CoveredHeight * 0.9f);
		boxCollider.center = new Vector3(0f, 0.5f, 0f);
	}

	private bool CheckMoney()
	{
		return true;
	}

	private CardSlotData GetEmptySlot()
	{
		foreach (CardSlotData cardSlotData in this.SlotDatas)
		{
			if (cardSlotData.ChildCardData == null || string.IsNullOrEmpty(cardSlotData.ChildCardData.ModID))
			{
				return cardSlotData;
			}
		}
		return null;
	}

	public void ChangeStateToBuilding()
	{
		foreach (CardSlotData cardSlotData in this.SlotDatas)
		{
			cardSlotData.SlotType = CardSlotData.Type.Freeze;
		}
		if (this.m_TargetGo != null)
		{
			UnityEngine.Object.DestroyImmediate(this.m_TargetGo);
		}
		this.m_IsBuilding = false;
		this.m_IsDestroy = false;
		this.StopAnimation();
	}

	public void ChangeStateToMove()
	{
		foreach (CardSlotData cardSlotData in this.SlotDatas)
		{
			cardSlotData.SlotType = CardSlotData.Type.Normal;
		}
		if (this.m_TargetGo != null)
		{
			UnityEngine.Object.DestroyImmediate(this.m_TargetGo);
		}
		this.m_IsBuilding = false;
		this.m_IsDestroy = false;
	}

	public void ChangeStateToDestroy()
	{
		foreach (CardSlotData cardSlotData in this.SlotDatas)
		{
			cardSlotData.SlotType = CardSlotData.Type.Freeze;
		}
		if (this.m_TargetGo != null)
		{
			UnityEngine.Object.DestroyImmediate(this.m_TargetGo);
		}
		this.m_IsBuilding = false;
		this.m_IsDestroy = true;
	}

	public void ChangeStateToBuidingElse()
	{
		foreach (CardSlotData cardSlotData in this.SlotDatas)
		{
			cardSlotData.SlotType = CardSlotData.Type.Freeze;
		}
		if (this.m_TargetGo != null)
		{
			UnityEngine.Object.DestroyImmediate(this.m_TargetGo);
		}
		this.m_IsBuilding = false;
		this.m_IsDestroy = false;
		this.PlayAnimation();
	}

	public void ExitArea()
	{
		Cursor.SetCursor(this.m_Canvas.DefaultCursor, Vector2.zero, CursorMode.Auto);
	}

	public void InitAreaDataDesc(int curBCount)
	{
		this.m_BuildingCount = curBCount;
		this.InitPersonCountCanvax(this.m_BuildingCount);
	}

	private void InitPersonCountCanvax(int val)
	{
		this.m_Canvas.PersonText.text = GlobalController.Instance.GetBuildingMinionsModID().Count.ToString() + "/" + (val / 23).ToString();
	}

	private void Update()
	{
		if (this.m_IsBuilding)
		{
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f, 1 << LayerMask.NameToLayer("Slot"));
			if (raycastHit.collider != null)
			{
				if (raycastHit.collider.GetComponent<CardSlot>().ChildCard != null)
				{
					this.m_TargetGo.transform.position = new Vector3(999f, 999f, 999f);
				}
				else
				{
					this.m_TargetGo.transform.SetParent(raycastHit.collider.transform);
					if (this.m_Target.CoveredWidth > 1 || this.m_Target.CoveredHeight > 1)
					{
						this.m_TargetGo.transform.localPosition = Vector3.zero;
						if (this.m_Target.CoveredWidth > 1)
						{
							this.m_TargetGo.transform.localPosition = new Vector3((float)(this.m_Target.CoveredWidth - 1) * 0.5f, 0f, this.m_TargetGo.transform.localPosition.z);
						}
						if (this.m_Target.CoveredHeight > 1)
						{
							this.m_TargetGo.transform.localPosition = new Vector3(this.m_TargetGo.transform.localPosition.x, 0f, (float)(-(float)(this.m_Target.CoveredHeight - 1)) * 0.5f);
						}
					}
					else
					{
						this.m_TargetGo.transform.localPosition = Vector3.zero;
					}
					if (this.IsBoxCovered())
					{
						this.m_TargetGo.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material = this.Materials[1];
					}
					else if (this.IsCovered(raycastHit.collider.GetComponent<CardSlot>().CardSlotData))
					{
						this.m_TargetGo.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material = this.Materials[0];
					}
					else
					{
						this.m_TargetGo.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material = this.Materials[1];
					}
					if (Input.GetMouseButtonDown(0))
					{
						if (this.m_Target.HasTag(TagMap.随从))
						{
							if (!EventSystem.current.IsPointerOverGameObject() && !this.IsBoxCovered() && this.IsCovered(raycastHit.collider.GetComponent<CardSlot>().CardSlotData))
							{
								if (GlobalController.Instance.GetBuildingMinionsModID().Count + 1 > this.m_BuildingCount / 23)
								{
									GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_人口"), 1f, 2f, 1f, 1f);
									return;
								}
								this.m_TargetGo.transform.position = new Vector3(999f, 999f, 999f);
								CardData.CopyCardData(this.m_Target, true).PutInSlotData(raycastHit.collider.GetComponent<CardSlot>().CardSlotData, true);
								GlobalController.Instance.AddBuildingMinionsModID(this.m_Target.ModID);
								this.m_Canvas.PersonText.text = GlobalController.Instance.GetBuildingMinionsModID().Count.ToString() + "/" + (this.m_BuildingCount / 23).ToString();
							}
						}
						else if (this.CheckMoney() && !EventSystem.current.IsPointerOverGameObject() && !this.IsBoxCovered() && this.IsCovered(raycastHit.collider.GetComponent<CardSlot>().CardSlotData))
						{
							this.m_TargetGo.transform.position = new Vector3(999f, 999f, 999f);
							CardData.CopyCardData(this.m_Target, true).PutInSlotData(raycastHit.collider.GetComponent<CardSlot>().CardSlotData, true);
							GlobalController.Instance.ChangeBuildingWealth(this.m_Target.Price);
							this.m_Canvas.WealthText.text = (GlobalController.Instance.GetBuildingWealth().ToString() ?? "");
							this.m_BuildingCount += this.m_Target.CoveredWidth * this.m_Target.CoveredHeight;
							this.m_Canvas.PersonText.text = GlobalController.Instance.GetBuildingMinionsModID().Count.ToString() + "/" + (this.m_BuildingCount / 23).ToString();
							this.CheckMoney();
						}
					}
				}
			}
		}
		if (this.m_IsDestroy && Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit2;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit2, 100f, 1 << LayerMask.NameToLayer("Slot"));
			if (raycastHit2.collider != null && raycastHit2.collider.GetComponent<CardSlot>().ChildCard != null)
			{
				CardData cardData = raycastHit2.collider.GetComponent<CardSlot>().ChildCard.CardData;
				if (cardData.HasTag(TagMap.随从))
				{
					GlobalController.Instance.RemoveBuidlingMinionModID(cardData.ModID);
					this.m_Canvas.PersonText.text = GlobalController.Instance.GetBuildingMinionsModID().Count.ToString() + "/" + (this.m_BuildingCount / 23).ToString();
				}
				else
				{
					if ((this.m_BuildingCount - 1) / 23 < GlobalController.Instance.GetBuildingMinionsModID().Count)
					{
						GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_拆除"), 1f, 2f, 1f, 1f);
						return;
					}
					GlobalController.Instance.ChangeBuildingWealth(-cardData.Price);
					this.m_Canvas.WealthText.text = (GlobalController.Instance.GetBuildingWealth().ToString() ?? "");
					this.m_BuildingCount -= cardData.CoveredWidth * cardData.CoveredHeight;
					this.m_Canvas.PersonText.text = GlobalController.Instance.GetBuildingMinionsModID().Count.ToString() + "/" + (this.m_BuildingCount / 23).ToString();
				}
				cardData.DeleteCardData();
			}
		}
		if (Input.GetMouseButtonDown(1))
		{
			if (this.m_TargetGo != null)
			{
				UnityEngine.Object.DestroyImmediate(this.m_TargetGo);
			}
			this.m_IsBuilding = false;
		}
	}

	private void PlayAnimation()
	{
		foreach (CardSlotData cardSlotData in this.SlotDatas)
		{
			if (cardSlotData.ChildCardData != null && !string.IsNullOrEmpty(cardSlotData.ChildCardData.ModID) && cardSlotData.ChildCardData.CardGameObject.transform.GetComponent<Animator>())
			{
				cardSlotData.ChildCardData.CardGameObject.transform.GetComponent<Animator>().SetTrigger("play");
			}
		}
	}

	public void ResetAnimation()
	{
		this.StopAnimation();
		this.PlayAnimation();
	}

	private void StopAnimation()
	{
		foreach (CardSlotData cardSlotData in this.SlotDatas)
		{
			if (cardSlotData.ChildCardData != null && !string.IsNullOrEmpty(cardSlotData.ChildCardData.ModID) && cardSlotData.ChildCardData.CardGameObject.transform.GetComponent<Animator>())
			{
				cardSlotData.ChildCardData.CardGameObject.transform.GetComponent<Animator>().Rebind();
			}
		}
	}

	private bool IsCovered(CardSlotData targetSlotData)
	{
		int num = this.SlotDatas.IndexOf(targetSlotData);
		int num2 = num % 20;
		int num3 = num / 20;
		int num4 = this.m_Target.CoveredWidth + num2;
		int num5 = this.m_Target.CoveredHeight + num3;
		return num4 <= 20 && num5 <= 12;
	}

	public Vector3 GetModelSize(Transform varTransform)
	{
		Vector3 position = varTransform.position;
		Quaternion rotation = varTransform.rotation;
		Vector3 localScale = varTransform.localScale;
		varTransform.position = Vector3.zero;
		varTransform.rotation = Quaternion.Euler(Vector3.zero);
		Renderer[] array = varTransform.GetComponentsInChildren<Renderer>();
		List<Renderer> list = new List<Renderer>();
		for (int i = 0; i < array.Length; i++)
		{
			if (!(array[i].transform.GetComponent<ParticleSystem>() != null))
			{
				list.Add(array[i]);
			}
		}
		array = list.ToArray();
		Vector3 vector = Vector3.zero;
		foreach (Renderer renderer in array)
		{
			vector += renderer.bounds.center;
		}
		vector /= (float)array.Length;
		Bounds bounds = new Bounds(vector, Vector3.zero);
		Renderer[] array2 = array;
		for (int j = 0; j < array2.Length; j++)
		{
			Bounds bounds2 = array2[j].bounds;
			bounds.Encapsulate(bounds2);
		}
		varTransform.position = position;
		varTransform.rotation = rotation;
		varTransform.localScale = localScale;
		return bounds.size;
	}

	private bool IsBoxCovered()
	{
		return Physics.CheckBox(this.m_TargetGo.transform.position + this.m_TargetGo.GetComponent<BoxCollider>().center, this.m_TargetGo.GetComponent<BoxCollider>().size / 2f, this.m_TargetGo.transform.rotation, 1 << LayerMask.NameToLayer("Card"));
	}

	public List<Material> Materials;

	public Transform ShowPoint;

	public List<CardSlotData> SlotDatas;

	private BuildingCanvas m_Canvas;

	private List<CardData> m_Cards = new List<CardData>();

	private int m_PageIndex;

	private ulong m_Type = 8521215115264UL;

	private List<GameObject> showItems = new List<GameObject>();

	private bool m_IsBuilding;

	private bool m_IsDestroy;

	private CardData m_Target;

	private int m_BuildingCount;

	private GameObject m_TargetGo;
}
