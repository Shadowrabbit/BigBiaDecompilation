using System;
using TMPro;
using UnityEngine;

public class FaithBase : MonoBehaviour
{
	public virtual void OnLevelUp()
	{
	}

	public void AddLogic(string logicName, CardData data)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		cardLogic.CardData = data;
		data.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(data);
	}

	public TMP_Text CurLevel;

	public FaithPanelController FaithPanelController;
}
