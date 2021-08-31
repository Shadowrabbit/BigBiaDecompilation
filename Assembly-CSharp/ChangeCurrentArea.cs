using System;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCurrentArea
{
	public void InitArea(string areaID)
	{
		Dictionary<string, AreaData> areaMap = GameController.getInstance().GameData.AreaMap;
		string currentAreaId = GameController.getInstance().GameData.CurrentAreaId;
		AreaData oldArea = areaMap[currentAreaId];
		AreaData areaData = AreaData.CopyAreaData(GameController.getInstance().AreaDataModMap.getAreaDataByModID(areaID));
		string text = currentAreaId.Substring(0, currentAreaId.LastIndexOf('/'));
		AreaData areaData2 = areaMap[text];
		string text2 = AreaDataUtil.CombineAreaID(new string[]
		{
			text,
			areaID
		});
		int num = 2;
		while (areaMap.ContainsKey(text2))
		{
			text2 += num.ToString();
			num++;
		}
		for (int i = 0; i < areaData2.ChildrenAreaIDs.Count; i++)
		{
			if (areaData2.ChildrenAreaIDs[i].Equals(currentAreaId))
			{
				areaData2.ChildrenAreaIDs[i] = text2;
			}
		}
		areaMap.Remove(currentAreaId);
		areaMap.Add(text2, areaData);
		Debug.Log(text2);
		areaData.ID = text2;
		this.CopyData(oldArea, areaData);
		if (areaData.Attrs.ContainsKey("Owner"))
		{
			areaData.Attrs["Owner"] = "Player";
		}
		else
		{
			areaData.Attrs.Add("Owner", "Player");
		}
		GameController.getInstance().OnTableChange(areaData, true);
	}

	public void CopyData(AreaData oldArea, AreaData newArea)
	{
		newArea.Attrs = oldArea.Attrs;
		newArea.DisplayPositionX = oldArea.DisplayPositionX;
		newArea.DisplayPositionY = oldArea.DisplayPositionY;
	}
}
