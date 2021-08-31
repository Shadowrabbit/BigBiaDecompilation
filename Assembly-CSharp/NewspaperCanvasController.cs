using System;
using System.Collections;
using PixelCrushers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewspaperCanvasController : MonoBehaviour
{
	private void Start()
	{
		base.StartCoroutine(this.InitCorotine());
	}

	public void ShowNewspaperCanvas()
	{
		this.NewspaperCanvas.SetActive(true);
	}

	public void HideNewspaperCanvas()
	{
		this.NewspaperCanvas.SetActive(false);
	}

	private void ShowNewspaperContent(string prefabName)
	{
		NewspaperController.NewspaperID = prefabName;
		GlobalController.Instance.AddHaveReadNewspapersData(prefabName);
		base.StartCoroutine(this.LoadNewspaperScene());
	}

	private IEnumerator LoadNewspaperScene()
	{
		PlayerPrefs.SetString("SceneName", "Newspaper");
		yield return SceneManager.LoadSceneAsync("LoadingScene");
		yield break;
	}

	private IEnumerator InitCorotine()
	{
		yield return new WaitForSeconds(1f);
		if (GlobalController.Instance.GetHaveReadNewspapersData().Count < this.NewspapersContent.childCount)
		{
			this.NewspaperBtnText.text = "<color=red>New</color> " + this.NewspaperBtnText.text;
		}
		for (int i = 0; i < this.NewspapersContent.childCount; i++)
		{
			Button component = this.NewspapersContent.GetChild(i).GetComponent<Button>();
			NewspaperContent content = this.NewspapersContent.GetChild(i).GetComponent<NewspaperContent>();
			component.onClick.AddListener(delegate()
			{
				this.ShowNewspaperContent(content.PrefabName);
			});
		}
		yield break;
	}

	public UITextField NewspaperBtnText;

	public Transform NewspapersContent;

	public GameObject NewspaperCanvas;
}
