using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateCardBtnController : MonoBehaviour
{
	public void CreateCardButtons(CardData card, List<CardButton> buttons)
	{
		this.IsShow = true;
		float num = 0.017453292f * Mathf.Round((float)(360 / buttons.Count));
		float num2 = 50f * this.Radius;
		this.m_Buttons = new List<GameObject>();
		for (int i = 0; i < buttons.Count; i++)
		{
			float num3 = Mathf.Sin(num * (float)i) * num2;
			float num4 = Mathf.Cos(num * (float)i) * num2;
			Button btn = UnityEngine.Object.Instantiate<Button>(this.Btn);
			btn.transform.SetParent(this.Btn.transform.parent);
			btn.gameObject.SetActive(true);
			this.m_Buttons.Add(btn.gameObject);
			btn.GetComponentInChildren<TMP_Text>().text = buttons[i].logic.displayName;
			Vector3 vector = Camera.main.WorldToScreenPoint(card.CardGameObject.transform.position);
			Vector3 endValue = new Vector3(vector.x + num3, vector.y + num4, vector.z);
			btn.transform.position = vector;
			btn.interactable = buttons[i].IsInteractable;
			CardLogic logic = buttons[i].logic;
			UnityAction <>9__1;
			btn.transform.DOMove(endValue, 0.2f, false).SetEase(Ease.OutBack).OnComplete(delegate
			{
				UnityEvent onClick = btn.onClick;
				UnityAction call;
				if ((call = <>9__1) == null)
				{
					call = (<>9__1 = delegate()
					{
						this.OnCardButtonClick(card, logic);
					});
				}
				onClick.AddListener(call);
			});
		}
	}

	private void OnCardButtonClick(CardData card, CardLogic logic)
	{
		base.StartCoroutine(card.CardGameObject.UseSkillPross(logic));
		this.DestoryAllButtonOnCard();
		SteamController.Instance.SteamAchievementsController.SetAchievementStatus(AchievementType.NEW_ACHIEVEMENT_jiqiaodashi, 1);
	}

	public void DestoryAllButtonOnCard()
	{
		foreach (GameObject obj in this.m_Buttons)
		{
			UnityEngine.Object.DestroyImmediate(obj);
		}
		this.m_Buttons = new List<GameObject>();
		this.IsShow = false;
	}

	private void Update()
	{
		if (this.IsShow && (Input.GetMouseButtonDown(1) || (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())))
		{
			this.DestoryAllButtonOnCard();
		}
	}

	public Button Btn;

	public float Radius = 2f;

	[NonSerialized]
	public bool IsShow;

	private List<GameObject> m_Buttons = new List<GameObject>();
}
