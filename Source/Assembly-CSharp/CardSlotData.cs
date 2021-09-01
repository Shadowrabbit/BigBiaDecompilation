using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DeepCopyExtensions;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class CardSlotData
{
	[JsonProperty]
	public bool IsFlipped { get; private set; }

	public void MarkFlipState(bool value)
	{
		this.IsFlipped = value;
	}

	public int GetIntAttr(string name)
	{
		if (this.Attrs.ContainsKey(name))
		{
			return Convert.ToInt32(this.Attrs[name]);
		}
		return 0;
	}

	public float GetFloatAttr(string name)
	{
		if (this.Attrs.ContainsKey(name))
		{
			return Convert.ToSingle(this.Attrs[name]);
		}
		return 0f;
	}

	public bool GetBoolAttr(string name)
	{
		return this.Attrs.ContainsKey(name) && Convert.ToBoolean(this.Attrs[name]);
	}

	public string GetAttr(string name)
	{
		if (this.Attrs.ContainsKey(name))
		{
			return this.Attrs[name].ToString();
		}
		return "";
	}

	public void SetBoolAttr(string name, bool value)
	{
		if (!this.Attrs.ContainsKey(name))
		{
			this.Attrs.Add(name, value.ToString());
			return;
		}
		this.Attrs[name] = value.ToString();
	}

	public void SetAttr(string name, string value)
	{
		if (!this.Attrs.ContainsKey(name))
		{
			this.Attrs.Add(name, value);
			return;
		}
		this.Attrs[name] = value;
	}

	public bool HasAttr(string name)
	{
		return this.Attrs.ContainsKey(name);
	}

	public void ClearCardData()
	{
		this.ChildCardData = null;
		if (this.CardSlotGameObject != null)
		{
			this.CardSlotGameObject.ChildCard = null;
		}
	}

	public void Terminate()
	{
		this.CardSlotGameObject = null;
	}

	public void SetChildCardData(CardData cardData)
	{
		this.ChildCardData = cardData;
		if (this.CardSlotGameObject != null && this.ChildCardData != null && cardData.CardGameObject == null)
		{
			Card card = Card.InitCard(cardData);
			this.CardSlotGameObject.ChildCard = card;
			card.PutInSlot(this.CardSlotGameObject);
			if (this.SlotOwnerType == CardSlotData.OwnerType.SecondaryAct)
			{
				card.SwitchModelToCard();
			}
		}
	}

	public static CardSlotData CopyCardSlotData(CardSlotData cardSlotData)
	{
		return cardSlotData.DeepCopyByExpressionTree(null);
	}

	[OnDeserialized]
	public void OnDeserialized(StreamingContext context)
	{
		if (this.ChildCardData != null)
		{
			this.ChildCardData.CurrentCardSlotData = this;
		}
		if (this.Attrs.ContainsKey("Col"))
		{
			this.Attrs["Col"] = Convert.ToInt32(this.Attrs["Col"]);
		}
		if (this.LogicNames != null)
		{
			this.Logics = new List<CardSlotLogic>();
			foreach (string text in this.LogicNames)
			{
				Debug.Log("加载Logic： " + text);
				try
				{
					CardSlotLogic cardSlotLogic = Activator.CreateInstance(System.Type.GetType(text)) as CardSlotLogic;
					cardSlotLogic.Data = this;
					this.Logics.Add(cardSlotLogic);
				}
				catch
				{
					Debug.LogError("加载CardSlotLogic类时类名不匹配: " + text);
				}
			}
		}
	}

	public float DisplayPositionX;

	public float DisplayPositionZ;

	public int GridPositionX;

	public int GridPositionY;

	[NonSerialized]
	public CardSlot CardSlotGameObject;

	[NonSerialized]
	public AreaData CurrentAreaData;

	public bool OnlyAcceptOneCard;

	public bool IsFreeze;

	public int IconIndex;

	[NonSerialized]
	public bool IsInScene;

	public bool CanClick;

	public CardSlotData.Type SlotType;

	public ulong TagWhiteList;

	public CardSlotData.LineColor Color;

	public CardData ChildCardData;

	public string Model;

	public string desc;

	public CardSlotData.OwnerType SlotOwnerType;

	public CardSlotData.Forward SlotForward;

	public float SlotScale = 1f;

	public Dictionary<string, object> Attrs = new Dictionary<string, object>();

	public List<string> LogicNames;

	[NonSerialized]
	public List<CardSlotLogic> Logics = new List<CardSlotLogic>();

	public enum Type
	{
		Normal,
		Undisplay,
		Freeze,
		OnlyTake,
		OnlyPut,
		UndisplayFreeze,
		Grid
	}

	public enum OwnerType
	{
		Player,
		Area,
		Act,
		SecondaryAct,
		Trash
	}

	public enum LineColor
	{
		Yellow = 2,
		Red = 1,
		blue = 0
	}

	public enum Forward
	{
		Forward,
		Right,
		Back,
		Left,
		Up
	}
}
