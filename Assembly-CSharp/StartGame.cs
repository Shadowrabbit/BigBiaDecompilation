using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private void Start()
	{
		this.OriginWidth = base.GetComponent<RectTransform>().rect.width + 30f;
	}

	private void Update()
	{
	}

	public void StartGameBtn()
	{
		EffectAudioManager.Instance.PlayEffectAudio(5, null);
		base.StartCoroutine(this.StartLoading());
	}

	public void StartEndlessGame()
	{
		base.StartCoroutine(this.StartLoadingEndlessGame());
	}

	public void OnSettingBtnClick()
	{
		if ((UIController.UILevel.PlayerSlot & UIController.LockLevel) > UIController.UILevel.None)
		{
			return;
		}
		EffectAudioManager.Instance.PlayEffectAudio(6, null);
		GlobalController.Instance.ShowSettingPanel();
	}

	public void EndGame()
	{
		EffectAudioManager.Instance.PlayEffectAudio(6, null);
		Application.Quit();
	}

	public void ShowThanks()
	{
		EffectAudioManager.Instance.PlayEffectAudio(6, null);
		this.ThanksPanel.SetActive(true);
	}

	public void HideThanks()
	{
		EffectAudioManager.Instance.PlayEffectAudio(6, null);
		this.ThanksPanel.SetActive(false);
	}

	public void COOPGame()
	{
		EffectAudioManager.Instance.PlayEffectAudio(5, null);
		SceneManager.LoadScene("Lobby");
	}

	public void BattleGame()
	{
		EffectAudioManager.Instance.PlayEffectAudio(5, null);
		SceneManager.LoadScene("Battle");
	}

	public void Newspaper()
	{
		EffectAudioManager.Instance.PlayEffectAudio(5, null);
		base.transform.GetComponent<NewspaperCanvasController>().ShowNewspaperCanvas();
	}

	private IEnumerator StartLoading()
	{
		GameData.CurrentGameType = GameData.GameType.Normal;
		PlayerPrefs.SetString("SceneName", "Main");
		yield return SceneManager.LoadSceneAsync("LoadingScene");
		yield break;
	}

	private IEnumerator StartLoadingEndlessGame()
	{
		GameData.CurrentGameType = GameData.GameType.Endless;
		PlayerPrefs.SetString("SceneName", "Main");
		yield return SceneManager.LoadSceneAsync("LoadingScene");
		yield break;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		this.isMouseIn = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		this.isMouseIn = false;
	}

	public void OnUpdateContentBtnClick()
	{
		EffectAudioManager.Instance.PlayEffectAudio(6, null);
		UnityEngine.Object.Instantiate(Resources.Load("Newspaper/UpdateContent"));
	}

	private bool isMouseIn;

	private float OriginWidth;

	public GameObject ThanksPanel;
}
