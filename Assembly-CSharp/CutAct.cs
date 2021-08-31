using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using HighlightingSystem;
using UnityEngine;
using UnityEngine.EventSystems;

public class CutAct : GameAct
{
	private void Start()
	{
		this.Init();
		if (PlayerPrefs.GetInt("伐木") == 0)
		{
			GameController.getInstance().ShowGuideCanvas(12, 12);
			PlayerPrefs.SetInt("伐木", 1);
		}
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		this.AudioSource = base.transform.GetComponent<AudioSource>();
		GlobalController.Instance.SetAudioSourceOutPutAudioGroup(this.AudioSource, AudioGroup.EFFECT);
		this.ToolsButtons.Add(this.PointDeleteButton);
		GameController.getInstance().GameEventManager.OnCardChangeSlotEvent += this.OnCardSlotChange;
		for (int i = 0; i < this.OutputCardSlots.Count; i++)
		{
			this.OutputCardSlots[i].ChildCard = null;
		}
		this.EffectMask = new Texture2D(16, 16)
		{
			anisoLevel = 0,
			filterMode = FilterMode.Point,
			wrapMode = TextureWrapMode.Clamp
		};
		for (int j = 0; j < 256; j++)
		{
			this.EffectMask.SetPixel(j % 16, j / 16, Color.clear);
			this.EffectColors[j] = new Color32(0, 0, 0, 50);
		}
		this.EffectMask.Apply();
		GameObject gameObject = new GameObject("EffectMask");
		gameObject.transform.SetParent(base.transform, false);
		gameObject.transform.localPosition = Vector3.up * 0.121f;
		gameObject.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
		SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = Sprite.Create(this.EffectMask, new Rect(0f, 0f, (float)this.EffectMask.width, (float)this.EffectMask.height), new Vector2(0.5f, 0.5f), 2f);
		spriteRenderer.sortingOrder = 99;
		base.GetComponentInChildren<OKButton>().GameAct = this;
		this.OKButton = base.GetComponentInChildren<OKButton>();
		this.AddCard(this.Source.CardData.StructTexture, 1);
		this.eventalOffset = new Vector3(0f, 6f, 4.5f);
		this.oppositeOffset = new Vector3(0f, 0f, 11.2f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
	}

	private void OnGUI()
	{
		Vector2 vector = this.lastPoint;
		this.EffectMask.SetPixels32(this.ClearColors);
		this.EffectMask.Apply();
	}

	private void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject() || (UIController.LockLevel & UIController.UILevel.PlayerSlot) != UIController.UILevel.None || (UIController.UILockStack.Count > 0 && UIController.UILockStack.Peek() != this) || this.spriteRenderers.Count == 0)
		{
			return;
		}
		RaycastHit raycastHit;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit))
		{
			Collider collider = raycastHit.collider;
			if (collider == this.MainArea)
			{
				this.lastPoint = new Vector2(base.transform.InverseTransformPoint(raycastHit.point).x * 2f + 8f, base.transform.InverseTransformPoint(raycastHit.point).z * 2f + 8f);
				switch (this.DeleteType)
				{
				case 0:
					this.EffectMask.SetPixel((int)this.lastPoint.x, (int)this.lastPoint.y, new Color(0f, 0f, 0f, 0.2f));
					break;
				case 1:
					this.EffectMask.SetPixel((int)this.lastPoint.x, (int)this.lastPoint.y, this.CurrentColor);
					break;
				case 2:
					this.EffectMask.SetPixels32(0, (int)this.lastPoint.y, 16, 1, this.EffectColors);
					break;
				case 3:
					this.EffectMask.SetPixels32((int)this.lastPoint.x, 0, 1, 16, this.EffectColors);
					break;
				}
				this.EffectMask.Apply();
			}
			if (Input.GetMouseButtonDown(0))
			{
				this.LastDeleteTypr = this.DeleteType;
			}
			if (Input.GetMouseButtonDown(0))
			{
				if (collider == this.UpButton)
				{
					List<Vector2> list = this.deltaPos;
					int index = this.currentIndex;
					list[index] += ImageTools.movePixelsInTexture(this.spriteRenderers[this.currentIndex].sprite.texture, new Vector2(0f, 1f));
					this.AudioSource.clip = this.AudioClipList[2];
					this.AudioSource.Play();
				}
				else if (collider == this.LeftButton)
				{
					List<Vector2> list = this.deltaPos;
					int index = this.currentIndex;
					list[index] += ImageTools.movePixelsInTexture(this.spriteRenderers[this.currentIndex].sprite.texture, new Vector2(-1f, 0f));
					this.AudioSource.clip = this.AudioClipList[2];
					this.AudioSource.Play();
				}
				else if (collider == this.DownButton)
				{
					List<Vector2> list = this.deltaPos;
					int index = this.currentIndex;
					list[index] += ImageTools.movePixelsInTexture(this.spriteRenderers[this.currentIndex].sprite.texture, new Vector2(0f, -1f));
					this.AudioSource.clip = this.AudioClipList[2];
					this.AudioSource.Play();
				}
				else if (collider == this.RightButton)
				{
					List<Vector2> list = this.deltaPos;
					int index = this.currentIndex;
					list[index] += ImageTools.movePixelsInTexture(this.spriteRenderers[this.currentIndex].sprite.texture, new Vector2(1f, 0f));
					this.AudioSource.clip = this.AudioClipList[2];
					this.AudioSource.Play();
				}
				else if (collider == this.RotateButton)
				{
					ImageTools.movePixelsInTexture(this.spriteRenderers[this.currentIndex].sprite.texture, -this.deltaPos[this.currentIndex]);
					ImageTools.rotateTexture(this.spriteRenderers[this.currentIndex].sprite.texture);
					this.deltaPos[this.currentIndex] = ImageTools.movePixelsInTexture(this.spriteRenderers[this.currentIndex].sprite.texture, this.deltaPos[this.currentIndex]);
					this.AudioSource.clip = this.AudioClipList[2];
					this.AudioSource.Play();
				}
				else if (!(collider == this.OkButton))
				{
					if (collider == this.PointDeleteButton)
					{
						this.DeleteType = 0;
						this.AudioSource.clip = this.AudioClipList[2];
						this.AudioSource.Play();
					}
					else if (this.SourceSlot.ChildCard != null && (collider == this.SourceSlot.GetComponent<Collider>() || collider == this.SourceSlot.ChildCard.GetComponent<Collider>()))
					{
						this.DeleteType = 1;
						this.AudioSource.clip = this.AudioClipList[2];
						this.AudioSource.Play();
					}
					else if (collider == this.HLineDeleteButton)
					{
						this.DeleteType = 2;
						this.AudioSource.clip = this.AudioClipList[2];
						this.AudioSource.Play();
					}
					else if (collider == this.VLineDeleteButton)
					{
						this.DeleteType = 3;
						this.AudioSource.clip = this.AudioClipList[2];
						this.AudioSource.Play();
					}
					else if (collider == this.MakeListButton)
					{
						GameUIController.Instance.OpenUI(typeof(ThumbnailScreen), UIPathConstant.ThumbnailCanvas, 0, null);
						this.AudioSource.clip = this.AudioClipList[3];
						this.AudioSource.Play();
					}
					else if (collider == this.MainArea)
					{
						if (GameController.getInstance().GameData.Energy < 2)
						{
							GameController.getInstance().CreateSubtitle("你没有足够的体力", 1f, 2f, 1f, 1f);
							return;
						}
						GameController.getInstance().GameData.Energy -= 2;
						switch (this.DeleteType)
						{
						case 0:
						{
							if (this.LastDeleteTypr != this.DeleteType)
							{
								return;
							}
							Color pixel = this.spriteRenderers[this.currentIndex].sprite.texture.GetPixel((int)(base.transform.InverseTransformPoint(raycastHit.point).x * 2f + 8f), (int)(base.transform.InverseTransformPoint(raycastHit.point).z * 2f + 8f));
							if (pixel.a >= 0.7f)
							{
								this.spriteRenderers[this.currentIndex].sprite.texture.SetPixel((int)(base.transform.InverseTransformPoint(raycastHit.point).x * 2f + 8f), (int)(base.transform.InverseTransformPoint(raycastHit.point).z * 2f + 8f), new Color(pixel.r, pixel.g, pixel.b, pixel.a - 0.25f));
							}
							else
							{
								if (pixel.a <= 0f)
								{
									break;
								}
								this.spriteRenderers[this.currentIndex].sprite.texture.SetPixel((int)(base.transform.InverseTransformPoint(raycastHit.point).x * 2f + 8f), (int)(base.transform.InverseTransformPoint(raycastHit.point).z * 2f + 8f), Color.clear);
							}
							this.spriteRenderers[this.currentIndex].sprite.texture.Apply();
							this.AudioSource.clip = this.AudioClipList[0];
							this.AudioSource.Play();
							base.transform.DOPunchPosition(new Vector3(-0.1f, 0f, 0f), 0.64f, 10, 1f, false);
							this.CutEffect.transform.position = new Vector3(raycastHit.point.x, 0.2f, raycastHit.point.z);
							this.CutEffect.Play();
							List<Texture2D> notOut;
							List<Texture2D> list2;
							ImageTools.SplitTextureToParts(this.spriteRenderers[this.currentIndex].sprite.texture, out notOut, out list2);
							if (list2 != null && list2.Count > 0)
							{
								base.StartCoroutine(this.MakeCards(list2, notOut));
							}
							break;
						}
						case 1:
						{
							Color pixel = this.spriteRenderers[this.currentIndex].sprite.texture.GetPixel((int)(base.transform.InverseTransformPoint(raycastHit.point).x * 2f + 8f), (int)(base.transform.InverseTransformPoint(raycastHit.point).z * 2f + 8f));
							if (this.SourceSlot != null && this.SourceSlot.ChildCard != null && this.SourceSlot.ChildCard.CardData != null && pixel != this.CurrentColor)
							{
								pixel = this.spriteRenderers[this.currentIndex].sprite.texture.GetPixel((int)(base.transform.InverseTransformPoint(raycastHit.point).x * 2f + 8f), (int)(base.transform.InverseTransformPoint(raycastHit.point).z * 2f + 8f));
								this.spriteRenderers[this.currentIndex].sprite.texture.SetPixel((int)(base.transform.InverseTransformPoint(raycastHit.point).x * 2f + 8f), (int)(base.transform.InverseTransformPoint(raycastHit.point).z * 2f + 8f), this.CurrentColor);
								this.spriteRenderers[this.currentIndex].sprite.texture.Apply();
								this.AudioSource.clip = this.AudioClipList[0];
								this.AudioSource.Play();
								this.SourceSlot.ChildCard.RefreshCountText();
								CardData cardData = this.SourceSlot.ChildCard.CardData;
								int num = cardData.Count - 1;
								cardData.Count = num;
								if (num == 0)
								{
									this.SourceSlot.ChildCard.DeleteCard();
									this.DeleteType = 0;
								}
							}
							break;
						}
						case 2:
							this.spriteRenderers[this.currentIndex].sprite.texture.SetPixels32(0, (int)this.lastPoint.y, 16, 1, this.ClearColors);
							this.spriteRenderers[this.currentIndex].sprite.texture.Apply();
							this.AudioSource.clip = this.AudioClipList[0];
							this.AudioSource.Play();
							break;
						case 3:
							this.spriteRenderers[this.currentIndex].sprite.texture.SetPixels32((int)this.lastPoint.x, 0, 1, 16, this.ClearColors);
							this.spriteRenderers[this.currentIndex].sprite.texture.Apply();
							this.AudioSource.clip = this.AudioClipList[0];
							this.AudioSource.Play();
							break;
						}
					}
				}
				for (int i = 0; i < this.OnUseCardSlots.Count; i++)
				{
					if (collider == this.OnUseCardSlots[i].GetComponent<Collider>() || collider == this.OnUseCardSlots[i].ChildCard.GetComponent<Collider>())
					{
						this.TakeSourceToTop(i);
					}
				}
			}
		}
	}

	public SpriteRenderer AddCard(Texture2D source, int style = 0)
	{
		Texture2D texture2D = ImageTools.NormalizeTo256(source, this.ClearColors, 1);
		Color32[] pixels = texture2D.GetPixels32();
		int i = 0;
		while (i < pixels.Length && (pixels[i].a <= 0 || pixels[i].a >= 255))
		{
			i++;
		}
		if (i == pixels.Length)
		{
			for (i = 0; i < pixels.Length; i++)
			{
				if (pixels[i].a > 0)
				{
					pixels[i] = new Color32(pixels[i].r, pixels[i].g, pixels[i].b, (byte)(255 - (int)((float)UnityEngine.Random.Range(0, i) / 86f) * 64));
				}
			}
		}
		texture2D.SetPixels32(pixels);
		texture2D.Apply();
		GameObject gameObject = new GameObject("CardStruct");
		gameObject.transform.SetParent(base.transform, false);
		gameObject.transform.localPosition = Vector3.up * 0.17f;
		gameObject.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
		this.spriteRenderers.Add(gameObject.AddComponent<SpriteRenderer>());
		this.deltaPos.Add(Vector2.zero);
		this.currentIndex = this.spriteRenderers.Count - 1;
		this.spriteRenderers[this.currentIndex].sortingOrder = this.currentIndex + 1;
		this.spriteRenderers[this.currentIndex].gameObject.AddComponent<Highlighter>();
		this.spriteRenderers[this.currentIndex].sprite = Sprite.Create(texture2D, new Rect(0f, 0f, 16f, 16f), new Vector2(0.5f, 0.5f), 2f);
		this.AudioSource.clip = this.AudioClipList[1];
		this.AudioSource.Play();
		return this.spriteRenderers[this.currentIndex];
	}

	private void SetCurrentSource(CardData cardData)
	{
		if (cardData.StructTexture != null)
		{
			this.DeleteType = 1;
			this.CurrentColor = cardData.StructTexture.GetPixels32()[0];
		}
	}

	public void OnCardSlotChange(CardSlot origin, CardSlot target, Card card)
	{
		if (this.SourceSlot == target && card.CardData.CardLogicClassNames != null)
		{
			List<Vector2[]> list = new List<Vector2[]>();
			card.CardData.DoAllLogic("OnUse", new object[]
			{
				list
			});
			if (list.Count == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				Texture2D texture2D = new Texture2D(16, 16)
				{
					anisoLevel = 0,
					filterMode = FilterMode.Point,
					wrapMode = TextureWrapMode.Clamp
				};
				texture2D.SetPixels32(this.ClearColors);
				foreach (Vector2 vector in list[i])
				{
					texture2D.SetPixel((int)vector.x + 7, (int)vector.y + 7, new Color(0.2f, 0f, 0f, 1f));
				}
				texture2D.Apply();
				CardData.GetCardDataByStructTexture(texture2D).Rare = 1;
				null.DisplayGameObjectOnPlayerTable.transform.localScale = new Vector3(3f, 1f, 3f);
			}
		}
	}

	private int GetEnableOutputCardSlotIndex()
	{
		for (int i = 0; i < this.OutputCardSlots.Count; i++)
		{
			if (this.OutputCardSlots[i].ChildCard == null)
			{
				return i;
			}
		}
		return -1;
	}

	private void TakeSourceToTop(int index)
	{
		for (int i = 0; i < this.spriteRenderers.Count; i++)
		{
			if (i == index)
			{
				this.OnUseCardSlots[i].Border.color = Color.green;
				this.spriteRenderers[i].gameObject.GetComponent<Highlighter>().constant = true;
				this.spriteRenderers[i].gameObject.GetComponent<Highlighter>().constantColor = new Color(0f, 0f, 0f, 1f);
				this.currentIndex = i;
				this.spriteRenderers[i].sortingOrder = this.spriteRenderers.Count + 1;
			}
			else
			{
				this.OnUseCardSlots[i].Border.color = Color.white;
				this.spriteRenderers[i].gameObject.GetComponent<Highlighter>().constant = false;
				this.spriteRenderers[i].sortingOrder = i + 1;
			}
		}
	}

	private IEnumerator MakeCards(List<Texture2D> source, List<Texture2D> notOut)
	{
		UIController.LockLevel = UIController.UILevel.All;
		for (int i = 0; i < this.spriteRenderers.Count; i++)
		{
			UnityEngine.Object.DestroyImmediate(this.spriteRenderers[i]);
			this.currentIndex = this.spriteRenderers.Count - 1;
		}
		this.spriteRenderers.Clear();
		for (int j = 0; j < source.Count; j++)
		{
			SpriteRenderer target = this.AddCard(source[j], 0);
			Sequence sequence = DOTween.Sequence();
			sequence.Append(target.DOFade(0f, 0.2f));
			sequence.Append(target.DOFade(1f, 0.2f));
			sequence.Append(target.DOFade(0f, 0.2f));
			sequence.Append(target.DOFade(1f, 0.2f));
			sequence.Append(target.DOFade(0f, 0.2f));
			sequence.Play<Sequence>();
			CardData cardData = CardData.GetCardDataByStructTexture(ImageTools.ClipBlank(source[j]));
			if (CardData.GetCardDataByStructTexture(ImageTools.ClipBlank(source[j])) != null)
			{
				base.StartCoroutine(base.EmissionEffect(cardData, this.OutputCardSlots[this.GetEnableOutputCardSlotIndex()], 30));
			}
			else
			{
				cardData = CardData.CopyCardData(new CardData
				{
					ModID = null,
					Name = "材料",
					ItemType = ItemData.ItemTypes.material,
					Rare = 1
				}, true);
				Color32[] pixels = source[j].GetPixels32();
				cardData.Struct = new string[source[j].width * source[j].height];
				for (int k = 0; k < pixels.Length; k++)
				{
					if (pixels[k].a < 255 && pixels[k].a != 0)
					{
						pixels[k] = new Color32(pixels[k].r, pixels[k].g, pixels[k].b, byte.MaxValue);
					}
					for (int l = 0; l < CommonAttribute.MaterialColors.Length; l++)
					{
						if (pixels[k].Equals(CommonAttribute.MaterialColors[l]))
						{
							cardData.Struct[k] = CommonAttribute.MaterialNames[l];
						}
					}
				}
				source[j].SetPixels32(pixels);
				source[j].Apply();
				cardData.StructWidth = source[j].width;
				cardData.StructHeight = source[j].height;
				cardData.StructTexture = ImageTools.ClipBlank(source[j]);
				base.StartCoroutine(base.EmissionEffect(cardData, this.OutputCardSlots[this.GetEnableOutputCardSlotIndex()], 30));
				this.AudioSource.clip = this.AudioClipList[4];
				this.AudioSource.Play();
			}
		}
		Texture2D texture2D = new Texture2D(16, 16);
		texture2D.SetPixels32(this.ClearColors);
		for (int m = 0; m < notOut.Count; m++)
		{
			texture2D = ImageTools.mergeTexture(texture2D, notOut[m]);
		}
		this.AddCard(texture2D, 0);
		yield return new WaitForSeconds(1f);
		yield return null;
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
	}

	public override void OnActCancelButton()
	{
		GameController.getInstance().GameEventManager.OnCardChangeSlotEvent -= this.OnCardSlotChange;
		if (this.spriteRenderers != null && this.spriteRenderers.Count > 0)
		{
			Texture2D texture = this.spriteRenderers[this.spriteRenderers.Count - 1].sprite.texture;
			this.Source.CardData.StructTexture = texture;
		}
		List<CardSlot> list = new List<CardSlot>();
		int num = 0;
		foreach (CardSlot cardSlot in GameController.getInstance().CardSlotsOnPlayerTable)
		{
			if (!(cardSlot == null) && cardSlot.ChildCard == null && !list.Contains(cardSlot))
			{
				num++;
			}
		}
		List<CardSlot> outputCardSlots = this.OutputCardSlots;
		for (int j = outputCardSlots.Count - 1; j >= 0; j--)
		{
			if (outputCardSlots[j].ChildCard == null || outputCardSlots[j].ChildCard.CardData == null || string.IsNullOrEmpty(outputCardSlots[j].ChildCard.CardData.Name))
			{
				outputCardSlots.Remove(outputCardSlots[j]);
			}
		}
		if (this.SourceSlot.ChildCard != null && this.SourceSlot.ChildCard.CardData != null)
		{
			outputCardSlots.Add(this.SourceSlot);
		}
		for (int k = 1; k < this.SourceCardSlots.Count; k++)
		{
			if (this.SourceCardSlots[k] != null && this.SourceCardSlots[k].ChildCard != null && this.SourceCardSlots[k].ChildCard.CardData != null)
			{
				outputCardSlots.Add(this.SourceCardSlots[k]);
			}
		}
		if (num < outputCardSlots.Count)
		{
			GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_2"), 1f, 2f, 1f, 1f);
			return;
		}
		base.StartCoroutine(this.ActEndIEnumerator(outputCardSlots, delegate
		{
			base.OnActCancelButton();
			if (this.CheckEmpty())
			{
				this.Source.DeleteCard();
			}
		}));
	}

	private IEnumerator ActEndIEnumerator(List<CardSlot> tempList, CutAct.ActEndCallBack call)
	{
		yield return base.StartCoroutine(this.ActGetAllAni(tempList));
		call();
		yield break;
	}

	private bool CheckEmpty()
	{
		Color32[] pixels = this.Source.CardData.StructTexture.GetPixels32();
		for (int i = 0; i < pixels.Length; i++)
		{
			if (pixels[i].a > 0)
			{
				return false;
			}
		}
		return true;
	}

	public BoxCollider UpButton;

	public BoxCollider LeftButton;

	public BoxCollider DownButton;

	public BoxCollider RightButton;

	public BoxCollider RotateButton;

	public BoxCollider MainArea;

	public BoxCollider OkButton;

	public BoxCollider PointDeleteButton;

	public BoxCollider BlockDeleteButton;

	public BoxCollider HLineDeleteButton;

	public BoxCollider VLineDeleteButton;

	public BoxCollider MakeListButton;

	public CardSlot SourceSlot;

	public ParticleSystem CutEffect;

	private Color32[] ClearColors = new Color32[256];

	private Color32[] EffectColors = new Color32[256];

	private int DeleteType;

	private Texture2D EffectMask;

	private List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();

	private List<Vector2> deltaPos = new List<Vector2>();

	private List<CardSlot> OnUseCardSlots = new List<CardSlot>();

	private Color32 CurrentColor;

	private List<BoxCollider> ToolsButtons = new List<BoxCollider>();

	public List<CardSlot> SourceCardSlots = new List<CardSlot>();

	public List<CardSlot> OutputCardSlots = new List<CardSlot>();

	private int currentIndex;

	private Vector2 lastPoint;

	private int LastDeleteTypr;

	[Header("音效列表")]
	public List<AudioClip> AudioClipList;

	[NonSerialized]
	public AudioSource AudioSource;

	private delegate void ActEndCallBack();
}
