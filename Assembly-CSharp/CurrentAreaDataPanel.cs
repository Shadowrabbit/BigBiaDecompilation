using System;
using TMPro;
using UnityEngine;

public class CurrentAreaDataPanel : MonoBehaviour
{
	public void SetCurrentAreaDataContent(string currentAreaData)
	{
		this.CurrentAreaData.text = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].ModID + "\n" + UIController.LockLevel.ToString();
	}

	private void Update()
	{
		this.CurrentAreaData.text = UIController.LockLevel.ToString();
	}

	public TMP_Text CurrentAreaData;

	public RectTransform CurrentContentPanel;
}
