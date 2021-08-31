using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleCanvas : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	public void AddSubTitle(string content, float openTime = 1f, float showTime = 2f, float closeTime = 1f, float fontScale = 1f)
	{
		base.StartCoroutine(this.ShowSubtitle(content, openTime, showTime, closeTime, fontScale));
	}

	private IEnumerator ShowSubtitle(string content, float openTime, float showTime, float closeTime, float fontScale)
	{
		GameObject tipImage = UnityEngine.Object.Instantiate<GameObject>(this.TipPanel);
		tipImage.transform.SetParent(this.TipPanel.transform.parent);
		tipImage.transform.localPosition = Vector3.zero;
		tipImage.SetActive(true);
		GameObject contentText = UnityEngine.Object.Instantiate<GameObject>(this.ContentText);
		contentText.transform.SetParent(this.ContentParent.transform);
		contentText.SetActive(true);
		yield return new WaitForSeconds(0.3f);
		tipImage.transform.DOScale(new Vector3(4f, 0.55f, 0f), 0.5f);
		tipImage.transform.DOMove(contentText.transform.position, 0.5f, false).OnComplete(delegate
		{
			UnityEngine.Object.Destroy(tipImage);
		});
		yield return new WaitForSeconds(0.5f);
		contentText.GetComponent<RectTransform>();
		Color bgColor = contentText.GetComponent<Image>().color;
		Color textColor = contentText.transform.GetComponentInChildren<TMP_Text>().color;
		contentText.transform.GetComponentInChildren<TMP_Text>().text = content;
		contentText.GetComponent<Image>().DOColor(new Color(bgColor.r, bgColor.g, bgColor.b, 1f), closeTime / 5f);
		contentText.transform.GetComponentInChildren<TMP_Text>().DOColor(new Color(textColor.r, textColor.g, textColor.b, 1f), closeTime / 5f);
		yield return new WaitForSeconds(showTime);
		contentText.GetComponent<Image>().DOColor(new Color(bgColor.r, bgColor.g, bgColor.b, 0f), closeTime / 5f);
		contentText.transform.GetComponentInChildren<TMP_Text>().DOColor(new Color(textColor.r, textColor.g, textColor.b, 0f), closeTime / 5f);
		yield return new WaitForSeconds(closeTime / 5f);
		UnityEngine.Object.Destroy(contentText);
		yield break;
	}

	public GameObject ContentText;

	public GameObject ContentParent;

	public GameObject TipPanel;
}
