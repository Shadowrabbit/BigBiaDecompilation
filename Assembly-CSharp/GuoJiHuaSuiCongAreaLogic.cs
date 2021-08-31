using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuoJiHuaSuiCongAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
	}

	public override void BeforeInit()
	{
		this.m_CameraPos = Camera.main.transform.localPosition;
		this.m_CameraRotate = Camera.main.transform.localRotation;
		Camera.main.transform.localPosition = new Vector3(0.02f, 51.25f, 20.6f);
		Camera.main.transform.localRotation = Quaternion.Euler(-12.288f, 0f, 0f);
	}

	public override IEnumerator OnAlreadEnter()
	{
		GameController.ins.UIController.HideBlackMask(delegate
		{
			GameController.getInstance().UIController.ShowBackToHomeButton();
		}, 0.5f);
		List<CardData> cards = GameController.ins.CardDataModMap.Cards;
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in cards)
		{
			if (cardData.HasTag(TagMap.随从))
			{
				list.Add(cardData);
			}
		}
		int num = Mathf.CeilToInt((float)list.Count / 20f);
		int num2 = 20;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				CardData cardData2 = CardData.CopyCardData(list[j + i * 20], true);
				Card.InitCard(cardData2);
				cardData2.CardGameObject.transform.position = new Vector3((float)j + -9.6f, 0.016f, (float)i + 60.4f);
			}
		}
		yield break;
	}

	public override void OnExit()
	{
	}

	private Vector3 m_CameraPos;

	private Quaternion m_CameraRotate;
}
