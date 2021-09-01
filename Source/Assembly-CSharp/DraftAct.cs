using System;
using System.Collections;
using System.Collections.Generic;
using HighlightingSystem;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraftAct : GameAct
{
	private void Start()
	{
		this.Init();
		if (PlayerPrefs.GetInt("第一次打开工具桌") == 0)
		{
			GameController.getInstance().ShowGuideCanvas(6, 11);
			PlayerPrefs.SetInt("第一次打开工具桌", 1);
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
		if (this.IsBuild)
		{
			this.AreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId];
			if (this.AreaData.StructCardData != null)
			{
				this.AddCard(this.AreaData.StructCardData);
				this.SourceCardSlots.Insert(0, UnityEngine.Object.Instantiate<CardSlot>(this.SourceCardSlots[0]));
				this.OnUseCardSlots.Add(this.SourceCardSlots[0]);
				this.OnUseCardSlots[0].transform.position = new Vector3(-100f, 0f, 0f);
				this.TakeSourceToTop(0);
			}
		}
		else
		{
			CardData cardData = new CardData
			{
				ID = Guid.NewGuid().ToString()
			};
			cardData.StructTexture = new Texture2D(16, 16)
			{
				anisoLevel = 0,
				filterMode = FilterMode.Point
			};
			cardData.StructTexture.SetPixels32(this.ClearColors);
			cardData.StructTexture.Apply();
			this.AddCard(cardData);
			this.SourceCardSlots.Insert(0, UnityEngine.Object.Instantiate<CardSlot>(this.SourceCardSlots[0]));
			this.OnUseCardSlots.Add(this.SourceCardSlots[0]);
			this.OnUseCardSlots[0].transform.position = new Vector3(-100f, 0f, 0f);
			this.TakeSourceToTop(0);
		}
		base.GetComponentInChildren<OKButton>().GameAct = this;
		this.OKButton = base.GetComponentInChildren<OKButton>();
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
		this.TargetMaterilName.text = "";
		this.CurrentMaterilName.text = "";
	}

	private void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject() || (UIController.LockLevel & UIController.UILevel.PlayerSlot) != UIController.UILevel.None || (UIController.UILockStack.Count > 0 && UIController.UILockStack.Peek() != this))
		{
			return;
		}
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit);
			Collider collider = raycastHit.collider;
			if (collider == this.MakeListButton)
			{
				GameUIController.Instance.OpenUI(typeof(ThumbnailScreen), UIPathConstant.ThumbnailCanvas, 0, null);
				this.AudioSource.clip = this.AudioClipList[3];
				this.AudioSource.Play();
			}
			if (collider == this.BuildButton)
			{
				GameUIController.Instance.OpenUI(typeof(ThumbnailScreen), UIPathConstant.ThumbnailCanvas, 1, null);
				this.AudioSource.clip = this.AudioClipList[3];
				this.AudioSource.Play();
			}
		}
		RaycastHit raycastHit2;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit2))
		{
			Collider collider2 = raycastHit2.collider;
			if (collider2 == this.MainArea)
			{
				this.lastPoint = new Vector2(base.transform.InverseTransformPoint(raycastHit2.point).x * 2f + 8f, base.transform.InverseTransformPoint(raycastHit2.point).z * 2f + 8f);
				if (this.TargetStructSprite != null)
				{
					Color32 color = this.TargetStructSprite.sprite.texture.GetPixel((int)this.lastPoint.x, (int)this.lastPoint.y);
					for (int i = 0; i < CommonAttribute.MaterialColors.Length; i++)
					{
						if (color.Equals(CommonAttribute.MaterialColors[i]))
						{
							this.TargetMaterilName.text = CommonAttribute.MaterialNames[i];
							this.TargetMaterilName.color = CommonAttribute.MaterialColors[i];
						}
					}
				}
				if (this.spriteRenderers.Count == 0)
				{
					return;
				}
				for (int j = this.spriteRenderers.Count - 1; j >= 0; j--)
				{
					Color32 color2 = this.spriteRenderers[j].sprite.texture.GetPixel((int)this.lastPoint.x, (int)this.lastPoint.y);
					if (color2.a > 0)
					{
						for (int k = 0; k < CommonAttribute.MaterialColors.Length; k++)
						{
							if (color2.Equals(CommonAttribute.MaterialColors[k]))
							{
								this.CurrentMaterilName.text = CommonAttribute.MaterialNames[k];
								this.CurrentMaterilName.color = CommonAttribute.MaterialColors[k];
							}
						}
						break;
					}
				}
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
			if (this.spriteRenderers.Count == 0)
			{
				return;
			}
			if (Input.GetMouseButtonDown(0))
			{
				this.LastDeleteTypr = this.DeleteType;
			}
			if (Input.GetMouseButton(0) && collider2 == this.MainArea)
			{
				int deleteType = this.DeleteType;
				if (deleteType != 0)
				{
					if (deleteType == 1)
					{
						Color pixel = this.spriteRenderers[this.currentIndex].sprite.texture.GetPixel((int)(base.transform.InverseTransformPoint(raycastHit2.point).x * 2f + 8f), (int)(base.transform.InverseTransformPoint(raycastHit2.point).z * 2f + 8f));
						if (this.SourceSlot != null && this.SourceSlot.ChildCard != null && this.SourceSlot.ChildCard.CardData != null && pixel != this.CurrentColor)
						{
							pixel = this.spriteRenderers[this.currentIndex].sprite.texture.GetPixel((int)(base.transform.InverseTransformPoint(raycastHit2.point).x * 2f + 8f), (int)(base.transform.InverseTransformPoint(raycastHit2.point).z * 2f + 8f));
							this.spriteRenderers[this.currentIndex].sprite.texture.SetPixel((int)(base.transform.InverseTransformPoint(raycastHit2.point).x * 2f + 8f), (int)(base.transform.InverseTransformPoint(raycastHit2.point).z * 2f + 8f), this.CurrentColor);
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
					}
				}
				else
				{
					if (this.LastDeleteTypr != this.DeleteType)
					{
						return;
					}
					Color pixel = this.spriteRenderers[this.currentIndex].sprite.texture.GetPixel((int)(base.transform.InverseTransformPoint(raycastHit2.point).x * 2f + 8f), (int)(base.transform.InverseTransformPoint(raycastHit2.point).z * 2f + 8f));
					if (pixel != Color.clear && pixel.a == 1f)
					{
						this.spriteRenderers[this.currentIndex].sprite.texture.SetPixel((int)(base.transform.InverseTransformPoint(raycastHit2.point).x * 2f + 8f), (int)(base.transform.InverseTransformPoint(raycastHit2.point).z * 2f + 8f), Color.clear);
						this.spriteRenderers[this.currentIndex].sprite.texture.Apply();
						this.AudioSource.clip = this.AudioClipList[0];
						this.AudioSource.Play();
					}
				}
			}
			if (Input.GetMouseButtonDown(0))
			{
				if ((UIController.LockLevel & UIController.UILevel.ActTable) > UIController.UILevel.None)
				{
					return;
				}
				if (collider2 == this.UpButton)
				{
					List<Vector2> list = this.deltaPos;
					int deleteType = this.currentIndex;
					list[deleteType] += ImageTools.movePixelsInTexture(this.spriteRenderers[this.currentIndex].sprite.texture, new Vector2(0f, 1f));
					this.AudioSource.clip = this.AudioClipList[2];
					this.AudioSource.Play();
				}
				else if (collider2 == this.LeftButton)
				{
					List<Vector2> list = this.deltaPos;
					int deleteType = this.currentIndex;
					list[deleteType] += ImageTools.movePixelsInTexture(this.spriteRenderers[this.currentIndex].sprite.texture, new Vector2(-1f, 0f));
					this.AudioSource.clip = this.AudioClipList[2];
					this.AudioSource.Play();
				}
				else if (collider2 == this.DownButton)
				{
					List<Vector2> list = this.deltaPos;
					int deleteType = this.currentIndex;
					list[deleteType] += ImageTools.movePixelsInTexture(this.spriteRenderers[this.currentIndex].sprite.texture, new Vector2(0f, -1f));
					this.AudioSource.clip = this.AudioClipList[2];
					this.AudioSource.Play();
				}
				else if (collider2 == this.RightButton)
				{
					List<Vector2> list = this.deltaPos;
					int deleteType = this.currentIndex;
					list[deleteType] += ImageTools.movePixelsInTexture(this.spriteRenderers[this.currentIndex].sprite.texture, new Vector2(1f, 0f));
					this.AudioSource.clip = this.AudioClipList[2];
					this.AudioSource.Play();
				}
				else if (collider2 == this.RotateButton)
				{
					ImageTools.movePixelsInTexture(this.spriteRenderers[this.currentIndex].sprite.texture, -this.deltaPos[this.currentIndex]);
					ImageTools.rotateTexture(this.spriteRenderers[this.currentIndex].sprite.texture);
					this.deltaPos[this.currentIndex] = ImageTools.movePixelsInTexture(this.spriteRenderers[this.currentIndex].sprite.texture, this.deltaPos[this.currentIndex]);
					this.AudioSource.clip = this.AudioClipList[2];
					this.AudioSource.Play();
				}
				else if (collider2 == this.OkButton)
				{
					this.MakeCards();
				}
				else if (collider2 == this.PointDeleteButton)
				{
					this.DeleteType = 0;
					this.AudioSource.clip = this.AudioClipList[2];
					this.AudioSource.Play();
				}
				else if (this.SourceSlot.ChildCard != null && (collider2 == this.SourceSlot.GetComponent<Collider>() || collider2 == this.SourceSlot.ChildCard.GetComponent<Collider>()))
				{
					this.DeleteType = 1;
					this.AudioSource.clip = this.AudioClipList[2];
					this.AudioSource.Play();
				}
				else if (collider2 == this.HLineDeleteButton)
				{
					this.DeleteType = 2;
					this.AudioSource.clip = this.AudioClipList[2];
					this.AudioSource.Play();
				}
				else if (collider2 == this.VLineDeleteButton)
				{
					this.DeleteType = 3;
					this.AudioSource.clip = this.AudioClipList[2];
					this.AudioSource.Play();
				}
				else if (collider2 == this.MainArea)
				{
					int deleteType = this.DeleteType;
					if (deleteType != 2)
					{
						if (deleteType == 3)
						{
							this.spriteRenderers[this.currentIndex].sprite.texture.SetPixels32((int)this.lastPoint.x, 0, 1, 16, this.ClearColors);
							this.spriteRenderers[this.currentIndex].sprite.texture.Apply();
							this.AudioSource.clip = this.AudioClipList[0];
							this.AudioSource.Play();
						}
					}
					else
					{
						this.spriteRenderers[this.currentIndex].sprite.texture.SetPixels32(0, (int)this.lastPoint.y, 16, 1, this.ClearColors);
						this.spriteRenderers[this.currentIndex].sprite.texture.Apply();
						this.AudioSource.clip = this.AudioClipList[0];
						this.AudioSource.Play();
					}
				}
				for (int l = 0; l < this.OnUseCardSlots.Count; l++)
				{
					if (!(this.OnUseCardSlots[l].ChildCard == null) && (collider2 == this.OnUseCardSlots[l].GetComponent<Collider>() || collider2 == this.OnUseCardSlots[l].ChildCard.GetComponent<Collider>()))
					{
						this.TakeSourceToTop(l);
					}
				}
			}
		}
	}

	public void AddCard(CardData cardData)
	{
		if (cardData.StructTexture == null)
		{
			cardData.StructTexture = GameController.getInstance().CardDataModMap.getCardDataByModID(cardData.ModID).StructTexture;
		}
		if (cardData.StructTexture == null)
		{
			return;
		}
		Texture2D texture = ImageTools.NormalizeTo256(cardData.StructTexture, this.ClearColors, 0);
		GameObject gameObject = new GameObject("CardStruct");
		gameObject.transform.SetParent(base.transform, false);
		gameObject.transform.localPosition = Vector3.up * 0.121f;
		gameObject.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
		this.spriteRenderers.Add(gameObject.AddComponent<SpriteRenderer>());
		this.deltaPos.Add(Vector2.zero);
		this.currentIndex = this.spriteRenderers.Count - 1;
		this.spriteRenderers[this.currentIndex].sortingOrder = this.currentIndex + 1;
		this.spriteRenderers[this.currentIndex].gameObject.AddComponent<Highlighter>();
		this.spriteRenderers[this.currentIndex].sprite = Sprite.Create(texture, new Rect(0f, 0f, 16f, 16f), new Vector2(0.5f, 0.5f), 2f);
		this.AudioSource.clip = this.AudioClipList[1];
		this.AudioSource.Play();
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
		if (this.SourceSlot == target)
		{
			if (card.CardData.StructTexture.width + card.CardData.StructTexture.height != 2)
			{
				card.PutInSlot(origin);
				return;
			}
			this.SetCurrentSource(card.CardData);
		}
		if (this.SourceSlot == origin)
		{
			this.DeleteType = 0;
		}
		Predicate<CardSlot> <>9__0;
		for (int i = 0; i < this.SourceCardSlots.Count; i++)
		{
			if (this.SourceCardSlots[i].Border)
			{
				this.SourceCardSlots[i].Border.color = Color.white;
			}
			if (this.SourceCardSlots[i] == origin)
			{
				List<CardSlot> onUseCardSlots = this.OnUseCardSlots;
				Predicate<CardSlot> match;
				if ((match = <>9__0) == null)
				{
					match = (<>9__0 = ((CardSlot o) => o.CardSlotData == origin.CardSlotData));
				}
				int index = onUseCardSlots.FindIndex(match);
				UnityEngine.Object.DestroyImmediate(this.spriteRenderers[index]);
				this.OnUseCardSlots.RemoveAt(index);
				this.deltaPos.RemoveAt(index);
				this.spriteRenderers.RemoveAt(index);
				this.currentIndex = this.spriteRenderers.Count - 1;
				this.TakeSourceToTop(this.currentIndex);
			}
			if (this.SourceCardSlots[i] == target)
			{
				if (card.CardData.StructTexture == null)
				{
					card.PutInSlot(origin);
					return;
				}
				this.AddCard(card.CardData);
				this.OnUseCardSlots.Add(this.SourceCardSlots[i]);
				this.TakeSourceToTop(this.OnUseCardSlots.Count - 1);
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

	private void MakeCards()
	{
		if (this.GetEnableOutputCardSlotIndex() >= 0)
		{
			Texture2D texture2D = null;
			for (int i = 0; i < this.spriteRenderers.Count; i++)
			{
				if (texture2D == null)
				{
					texture2D = new Texture2D(16, 16)
					{
						anisoLevel = 0,
						filterMode = FilterMode.Point
					};
					texture2D.SetPixels32(this.spriteRenderers[i].sprite.texture.GetPixels32());
					texture2D.Apply();
				}
				else
				{
					texture2D = ImageTools.mergeTexture(this.spriteRenderers[i].sprite.texture, texture2D);
				}
			}
			if (texture2D != null)
			{
				bool flag = false;
				CardData cardData = new CardData();
				texture2D = ImageTools.ClipBlank(texture2D);
				if (this.IsBuild)
				{
					foreach (CardData cardData2 in GameController.getInstance().BuildingModMap.Cards)
					{
						if (!(cardData2.StructTexture == null))
						{
							Texture2D structTexture = cardData2.StructTexture;
							if (!(texture2D.texelSize != structTexture.texelSize))
							{
								int j;
								for (j = 0; j < structTexture.width; j++)
								{
									int num = 0;
									while (num < structTexture.height && ((texture2D.GetPixel(j, num).a <= 0.5f && structTexture.GetPixel(j, num).a <= 0.5f) || texture2D.GetPixel(j, num).Equals(structTexture.GetPixel(j, num))))
									{
										num++;
									}
									if (num != structTexture.height)
									{
										break;
									}
								}
								if (j == structTexture.width)
								{
									cardData = CardData.CopyCardData(cardData2, true);
									this.BuildingModID = cardData2.ModID;
									this.AreaData.StructCardData = cardData;
									base.OnActCancelButton();
									flag = true;
									break;
								}
							}
						}
					}
					if (!flag)
					{
						cardData.ModID = null;
						cardData.Name = "建筑材料";
						cardData.ItemType = ItemData.ItemTypes.material;
						cardData.Rare = 1;
						cardData = CardData.CopyCardData(cardData, true);
						Color32[] pixels = texture2D.GetPixels32();
						cardData.Struct = new string[texture2D.width * texture2D.height];
						for (int k = 0; k < pixels.Length; k++)
						{
							for (int l = 0; l < CommonAttribute.MaterialColors.Length; l++)
							{
								if (pixels[k].Equals(CommonAttribute.MaterialColors[l]))
								{
									cardData.Struct[k] = CommonAttribute.MaterialNames[l];
								}
							}
						}
						cardData.StructWidth = texture2D.width;
						cardData.StructHeight = texture2D.height;
						cardData.StructTexture = texture2D;
						this.AreaData.StructCardData = cardData;
						base.OnActCancelButton();
					}
				}
				else
				{
					foreach (CardData cardData3 in GameController.getInstance().CardDataModMap.Cards)
					{
						if (!(cardData3.StructTexture == null))
						{
							Texture2D structTexture2 = cardData3.StructTexture;
							if (!(texture2D.texelSize != structTexture2.texelSize))
							{
								int m;
								for (m = 0; m < structTexture2.width; m++)
								{
									int num2 = 0;
									while (num2 < structTexture2.height && ((texture2D.GetPixel(m, num2).a <= 0.5f && structTexture2.GetPixel(m, num2).a <= 0.5f) || texture2D.GetPixel(m, num2).Equals(structTexture2.GetPixel(m, num2))))
									{
										num2++;
									}
									if (num2 != structTexture2.height)
									{
										break;
									}
								}
								if (m == structTexture2.width)
								{
									cardData = CardData.CopyCardData(cardData3, true);
									base.StartCoroutine(base.EmissionEffect(CardData.CopyCardData(cardData3, true), this.OutputCardSlots[this.GetEnableOutputCardSlotIndex()], 30));
									flag = true;
									break;
								}
							}
						}
					}
					if (!flag)
					{
						cardData.ModID = null;
						cardData.Name = "材料";
						cardData.ItemType = ItemData.ItemTypes.material;
						cardData.Rare = 1;
						cardData = CardData.CopyCardData(cardData, true);
						Color32[] pixels2 = texture2D.GetPixels32();
						cardData.Struct = new string[texture2D.width * texture2D.height];
						for (int n = 0; n < pixels2.Length; n++)
						{
							for (int num3 = 0; num3 < CommonAttribute.MaterialColors.Length; num3++)
							{
								if (pixels2[n].Equals(CommonAttribute.MaterialColors[num3]))
								{
									cardData.Struct[n] = CommonAttribute.MaterialNames[num3];
								}
							}
						}
						cardData.StructWidth = texture2D.width;
						cardData.StructHeight = texture2D.height;
						cardData.StructTexture = texture2D;
						base.StartCoroutine(base.EmissionEffect(cardData, this.OutputCardSlots[this.GetEnableOutputCardSlotIndex()], 30));
					}
					new List<Card>();
					new int[CommonAttribute.MaterialColors.Length];
					new int[CommonAttribute.MaterialColors.Length];
					Dictionary<string, int> dictionary = new Dictionary<string, int>();
					for (int num4 = 0; num4 < this.OnUseCardSlots.Count; num4++)
					{
						string[] @struct = this.OnUseCardSlots[num4].ChildCard.CardData.Struct;
						if (@struct != null)
						{
							for (int num5 = 0; num5 < @struct.Length; num5++)
							{
								if (@struct[num5] != null)
								{
									if (dictionary.ContainsKey(@struct[num5]))
									{
										Dictionary<string, int> dictionary2 = dictionary;
										string key = @struct[num5];
										int num6 = dictionary2[key];
										dictionary2[key] = num6 + 1;
									}
									else
									{
										dictionary.Add(@struct[num5], 1);
									}
								}
							}
						}
					}
					foreach (string text in cardData.Struct)
					{
						if (text != null && dictionary.ContainsKey(text))
						{
							Dictionary<string, int> dictionary3 = dictionary;
							string key = text;
							int num7 = dictionary3[key];
							dictionary3[key] = num7 - 1;
						}
					}
					foreach (KeyValuePair<string, int> keyValuePair in dictionary)
					{
						if (keyValuePair.Value >= 1)
						{
							cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(CommonAttribute.MaterialModIDMap[keyValuePair.Key]), true);
							cardData.Count = keyValuePair.Value;
							base.StartCoroutine(base.EmissionEffect(cardData, this.OutputCardSlots[this.GetEnableOutputCardSlotIndex()], 30));
						}
					}
					for (int num8 = 0; num8 < this.OnUseCardSlots.Count; num8++)
					{
						this.OnUseCardSlots[num8].ChildCard.DeleteCard();
						this.OnUseCardSlots[num8].ChildCard = null;
						UnityEngine.Object.DestroyImmediate(this.spriteRenderers[num8].gameObject);
					}
					this.deltaPos.Clear();
					this.OnUseCardSlots.Clear();
					this.spriteRenderers.Clear();
				}
			}
		}
		this.AudioSource.clip = this.AudioClipList[4];
		this.AudioSource.Play();
	}

	public override void OnActCancelButton()
	{
		GameController.getInstance().GameEventManager.OnCardChangeSlotEvent -= this.OnCardSlotChange;
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
		}));
	}

	private IEnumerator ActEndIEnumerator(List<CardSlot> tempList, DraftAct.ActEndCallBack call)
	{
		yield return base.StartCoroutine(this.ActGetAllAni(tempList));
		call();
		yield break;
	}

	public override void ActEnd()
	{
		if (this.IsBuild && this.BuildingModID != null && this.BuildingModID != "")
		{
			new ChangeCurrentArea().InitArea(this.BuildingModID);
		}
		base.ActEnd();
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

	public BoxCollider BuildButton;

	public CardSlot SourceSlot;

	public bool IsBuild;

	public TextMeshProUGUI TargetMaterilName;

	public TextMeshProUGUI CurrentMaterilName;

	public SpriteRenderer TargetStructSprite;

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

	private AreaData AreaData;

	public string BuildingModID;

	private Vector2 lastPoint;

	private int LastDeleteTypr;

	[Header("音效列表")]
	public List<AudioClip> AudioClipList;

	[NonSerialized]
	public AudioSource AudioSource;

	private delegate void ActEndCallBack();
}
