using System;
using UnityEngine;

[Serializable]
public class GameMaterial
{
	public GameMaterial(string id, string name, Color32 color, float basePrice, float nutritiveValue, string burnProductGameMaterialID, float energyProducedInTheCombustion)
	{
		this.ID = id;
		this.Name = name;
		this.Color = color;
		this.BasePrice = basePrice;
		this.NutritiveValue = nutritiveValue;
		this.BurnProductGameMaterialID = burnProductGameMaterialID;
		this.EnergyProducedInTheCombustion = energyProducedInTheCombustion;
	}

	public string ID;

	public string Name;

	public Color32 Color;

	public float BasePrice;

	public float NutritiveValue;

	public string BurnProductGameMaterialID;

	public float EnergyProducedInTheCombustion;
}
