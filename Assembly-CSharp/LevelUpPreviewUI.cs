using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPreviewUI : MonoBehaviour
{
	private void Start()
	{
		this.isShow = false;
		this.Panel1.gameObject.SetActive(false);
		this.Panel2.gameObject.SetActive(false);
		this.Text1.gameObject.SetActive(false);
		this.Text2.gameObject.SetActive(false);
	}

	private void LateUpdate()
	{
		this.isShow = false;
	}

	private void Update()
	{
		if (!this.isAlreadyShow && this.isShow)
		{
			base.StartCoroutine(this.ShowProcess(this.currentCardData, this.otherCardData));
			this.isAlreadyShow = true;
		}
		if (this.isAlreadyShow && !this.isShow)
		{
			base.GetComponent<Image>().DOKill(false);
			base.StopAllCoroutines();
			this.currentCardData = null;
			this.lastCardData = null;
			this.Panel1.gameObject.SetActive(false);
			this.Panel2.gameObject.SetActive(false);
			this.Text1.gameObject.SetActive(false);
			this.Text2.gameObject.SetActive(false);
			this.isAlreadyShow = false;
			base.gameObject.SetActive(false);
			Color color = base.GetComponent<Image>().color;
			color.a = 0f;
			base.GetComponent<Image>().color = color;
		}
	}

	public IEnumerator ShowProcess(CardData cd1, CardData cd2)
	{
		base.transform.position = Camera.main.WorldToScreenPoint(cd1.CardGameObject.transform.position) + Vector3.up * 100f;
		yield return base.GetComponent<Image>().DOFade(0.8f, 0.5f).WaitForCompletion();
		this.Panel1.gameObject.SetActive(true);
		this.Panel2.gameObject.SetActive(true);
		this.Text1.gameObject.SetActive(true);
		this.Text2.gameObject.SetActive(true);
		this.Text1.text = "<size=22>LV " + cd1.Rare.ToString();
		foreach (CardLogic cardLogic in cd1.CardLogics)
		{
			if (!(cardLogic is MinionLogic))
			{
				TextMeshProUGUI textMeshProUGUI = this.Text1;
				textMeshProUGUI.text = string.Concat(new string[]
				{
					textMeshProUGUI.text,
					"</size>\n",
					cardLogic.displayName,
					" ",
					(cardLogic.Layers > 0) ? cardLogic.Layers.ToString() : ""
				});
			}
		}
		CardData cardData = CardData.CopyCardData(cd1, true);
		cardData.MergeBy(cd2, true, false);
		this.Text2.text = "<size=22>LV " + cardData.Rare.ToString();
		using (List<CardLogic>.Enumerator enumerator = cardData.CardLogics.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardLogic cardLogic2 = enumerator.Current;
				if (!(cardLogic2 is MinionLogic))
				{
					bool flag = false;
					foreach (CardLogic cardLogic3 in cd1.CardLogics)
					{
						if (cardLogic2.displayName == cardLogic3.displayName && cardLogic2.Layers == cardLogic3.Layers)
						{
							flag = true;
						}
					}
					if (flag)
					{
						TextMeshProUGUI textMeshProUGUI = this.Text2;
						textMeshProUGUI.text = string.Concat(new string[]
						{
							textMeshProUGUI.text,
							"</size>\n<color=white>",
							cardLogic2.displayName,
							" ",
							(cardLogic2.Layers > 0) ? cardLogic2.Layers.ToString() : "",
							"</color>"
						});
					}
					else
					{
						TextMeshProUGUI textMeshProUGUI = this.Text2;
						textMeshProUGUI.text = string.Concat(new string[]
						{
							textMeshProUGUI.text,
							"</size>\n",
							cardLogic2.displayName,
							" ",
							(cardLogic2.Layers > 0) ? cardLogic2.Layers.ToString() : ""
						});
					}
				}
			}
			yield break;
		}
		yield break;
	}

	public void show(CardData cd, CardData cd2)
	{
		this.currentCardData = cd;
		if (this.currentCardData != this.lastCardData)
		{
			this.lastCardData = this.currentCardData;
			this.otherCardData = cd2;
			return;
		}
		this.isShow = true;
	}

	public Image Panel1;

	public Image Panel2;

	public TextMeshProUGUI Text1;

	public TextMeshProUGUI Text2;

	private bool isShow;

	private bool isAlreadyShow;

	private CardData currentCardData;

	private CardData lastCardData;

	private CardData otherCardData;
}
