using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class AreaData : ItemData
{
	public static AreaData CopyAreaData(AreaData areaData)
	{
		return JsonConvert.DeserializeObject<AreaData>(JsonConvert.SerializeObject(areaData, CommonAttribute.jsonSerializerSettings), CommonAttribute.jsonSerializerSettings);
	}

	public void Lock()
	{
		base.SetBoolAttr("IsLocked", true);
	}

	public void Unlock()
	{
		base.SetBoolAttr("IsLocked", false);
	}

	[OnDeserialized]
	public void OnDeserialized(StreamingContext context)
	{
		if (this.LogicNames != null)
		{
			this.Logics = new List<AreaLogic>();
			foreach (string text in this.LogicNames)
			{
				try
				{
					AreaLogic areaLogic = Activator.CreateInstance(Type.GetType(text)) as AreaLogic;
					areaLogic.Data = this;
					this.Logics.Add(areaLogic);
				}
				catch (Exception ex)
				{
					Debug.LogError(string.Concat(new string[]
					{
						"加载AreaLogic类时类名不匹配: ",
						text,
						"文件名: ",
						this.Name,
						"内容: ",
						context.ToString()
					}));
					Debug.LogError(ex.StackTrace);
				}
			}
		}
	}

	[JsonIgnore, NonSerialized]
	public CardData SourceCard;

	public string TableModel;

	public List<CardData> Toys;

	public string CardBack;

	public List<CardSlotData> CardSlotDatas = new List<CardSlotData>();

	public int ChessmanPosition = -1;

	public List<string> ChildrenAreaIDs;

	public TableType TableType;

	public List<CardSlotData> InputCardSlotDataList;

	public List<CardSlotData> OutputCardSlotDataList;

	public AreaData.AreaDisplayType DisplayType;

	public int XInMap;

	public int YInMap;

	public string TabooName;

	public string TabooDESC;

	public string AdvocateName;

	public string AdvocateDESC;

	public int AreaType;

	public bool IsPhysicsData;

	[XmlIgnore, NonSerialized]
	public AreaData ParentArea;

	public List<string> LogicNames;

	[NonSerialized]
	public List<AreaLogic> Logics = new List<AreaLogic>();

	[XmlIgnore, NonSerialized]
	public Area Area;

	[XmlIgnore, NonSerialized]
	public CardData StructCardData;

	public string DungeonPath;

	public int MaxLevel;

	public int CurrLevel;

	public int MinMonsterNumber;

	public int MaxMonsterNumber;

	public enum AreaDisplayType
	{
		Normal,
		Secondary,
		World,
		OnlyThis,
		Dungeon
	}
}
