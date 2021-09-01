using System;
using System.Collections.Generic;
using UnityEngine;

public class AreaDataMap
{
	[SerializeField]
	public List<AreaData> Areas { get; set; }

	public AreaData getAreaDataByModID(string modId)
	{
		foreach (AreaData areaData in this.Areas)
		{
			if (areaData.ModID.Equals(modId))
			{
				return areaData;
			}
		}
		return null;
	}
}
