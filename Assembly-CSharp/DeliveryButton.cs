using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryButton : MonoBehaviour
{
	private void Start()
	{
		foreach (KeyValuePair<string, AreaData> keyValuePair in GameController.getInstance().GameData.AreaMap)
		{
			if (AreaDataUtil.IsPlayerArea(keyValuePair.Value))
			{
				this.options.Add(new Dropdown.OptionData(keyValuePair.Key));
			}
		}
	}

	private void OnMouseDown()
	{
	}

	private void Deliver(string s)
	{
		if (this.SourceAreaData.Attrs.ContainsKey("SupplyBy"))
		{
			this.SourceAreaData.Attrs["SupplyBy"] = s;
			return;
		}
		this.SourceAreaData.Attrs.Add("SupplyBy", s);
	}

	private List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

	public AreaData SourceAreaData;
}
