using System;
using UnityEngine;

public class MinionInnerTable : MonoBehaviour
{
	private void Start()
	{
		if (GameController.ins.NextAreaData.ID != null)
		{
			this.ShowModel(GameController.ins.GameData.InnerMinionCardData);
		}
	}

	public void ShowModel(CardData cardMod)
	{
		try
		{
			GameObject gameObject = Card.InitWithOutData(cardMod, false);
			if (gameObject != null)
			{
				gameObject.transform.SetParent(this.CardModelRoot, false);
				gameObject.transform.localPosition = Vector3.zero;
			}
		}
		catch (Exception message)
		{
			Debug.LogError(message);
			Debug.LogError("根据区域ID找不到卡片的模型");
		}
	}

	public Transform CardModelRoot;
}
