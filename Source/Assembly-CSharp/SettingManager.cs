using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
	private void Start()
	{
		this.MainVolumeSlider.onValueChanged.AddListener(new UnityAction<float>(this.OnMainVolumeChange));
		this.BgVolumeSlider.onValueChanged.AddListener(new UnityAction<float>(this.OnBgVolumeChange));
		this.EffectVolumeSlider.onValueChanged.AddListener(new UnityAction<float>(this.OnEffectVolumeChange));
		this.OtherVolumeSlider.onValueChanged.AddListener(new UnityAction<float>(this.OnOtherVolumeChange));
		this.WindowDrop.value = (GlobalController.Instance.GameSettingController.info.fullScreen ? 1 : 0);
		this.QualityDrop.value = ((GlobalController.Instance.GameSettingController.info.qualityLevel > 4) ? 4 : GlobalController.Instance.GameSettingController.info.qualityLevel);
		this.ScreenDrop.value = (int)GlobalController.Instance.GameSettingController.info.screenResolution;
		this.LocalizationDrop.value = (int)GlobalController.Instance.GameSettingController.info.language;
		this.VsyncDrop.value = ((GlobalController.Instance.GameSettingController.info.Vsync > 1) ? 1 : GlobalController.Instance.GameSettingController.info.Vsync);
	}

	public void InitPanel(float mainVolume, float bgVolume, float effectVolume, float otherVolume)
	{
		this.MainVolumeSlider.value = mainVolume;
		this.BgVolumeSlider.value = bgVolume;
		this.EffectVolumeSlider.value = effectVolume;
		this.OtherVolumeSlider.value = otherVolume;
	}

	public void OnMainVolumeChange(float volume)
	{
		GlobalController.Instance.GameSettingController.ApplyAudioSetting(MixType.Mixer_Master, volume);
	}

	public void OnBgVolumeChange(float volume)
	{
		GlobalController.Instance.GameSettingController.ApplyAudioSetting(MixType.Mixer_BG, volume);
	}

	public void OnEffectVolumeChange(float volume)
	{
		GlobalController.Instance.GameSettingController.ApplyAudioSetting(MixType.Mixer_Effect, volume);
	}

	public void OnOtherVolumeChange(float volume)
	{
		GlobalController.Instance.GameSettingController.ApplyAudioSetting(MixType.Mixer_Other, volume);
	}

	public void SetScreenLow()
	{
		GlobalController.Instance.GameSettingController.ApplyResolution(ScreenResolution.Low);
	}

	public void SetScreenMedium()
	{
		GlobalController.Instance.GameSettingController.ApplyResolution(ScreenResolution.Normal);
	}

	public void SetScreenHigh()
	{
		GlobalController.Instance.GameSettingController.ApplyResolution(ScreenResolution.High);
	}

	public void OnScreenChanged()
	{
		switch (this.ScreenDrop.value)
		{
		case 0:
			this.SetScreenLow();
			return;
		case 1:
			this.SetScreenMedium();
			return;
		case 2:
			this.SetScreenHigh();
			return;
		default:
			return;
		}
	}

	public void OnQualityChanged()
	{
		switch (this.QualityDrop.value)
		{
		case 0:
			this.SetQualityVeryLow();
			return;
		case 1:
			this.SetQualityLow();
			return;
		case 2:
			this.SetQualityMedium();
			return;
		case 3:
			this.SetQualityHigh();
			return;
		case 4:
			this.SetQualityVeryHigh();
			return;
		case 5:
			this.SetQualityUltra();
			return;
		default:
			return;
		}
	}

	public void OnWindowChanged()
	{
		int value = this.WindowDrop.value;
		if (value == 0)
		{
			this.SetWindow();
			return;
		}
		if (value != 1)
		{
			return;
		}
		this.SetFullScreen();
	}

	public void OnVsyncChanged()
	{
		GlobalController.Instance.GameSettingController.ApplyVsync(this.VsyncDrop.value);
	}

	public void SetQualityVeryLow()
	{
		GlobalController.Instance.GameSettingController.ApplyQuality(0);
	}

	public void SetQualityLow()
	{
		GlobalController.Instance.GameSettingController.ApplyQuality(1);
	}

	public void SetQualityMedium()
	{
		GlobalController.Instance.GameSettingController.ApplyQuality(2);
	}

	public void SetQualityHigh()
	{
		GlobalController.Instance.GameSettingController.ApplyQuality(3);
	}

	public void SetQualityVeryHigh()
	{
		GlobalController.Instance.GameSettingController.ApplyQuality(4);
	}

	public void SetQualityUltra()
	{
		GlobalController.Instance.GameSettingController.ApplyQuality(5);
	}

	public void SetZH_CN()
	{
		GlobalController.Instance.GameSettingController.ApplyLanguage(LanguageType.ZH_CN);
		GlobalController.Instance.OnLanguageChanged(LanguageType.ZH_CN);
	}

	public void SetEN()
	{
		GlobalController.Instance.GameSettingController.ApplyLanguage(LanguageType.EN);
		GlobalController.Instance.OnLanguageChanged(LanguageType.EN);
	}

	public void OnLocalizationChanged()
	{
		int value = this.LocalizationDrop.value;
		if (value != 0)
		{
			if (value == 1)
			{
				this.SetEN();
			}
		}
		else
		{
			this.SetZH_CN();
		}
		GlobalController.Instance.SetGlobalSetting(true);
	}

	public void SetFullScreen()
	{
		GlobalController.Instance.GameSettingController.ApplyFullScreen(true);
	}

	public void SetWindow()
	{
		GlobalController.Instance.GameSettingController.ApplyFullScreen(false);
	}

	public void OnCloseBtn()
	{
		GlobalController.Instance.CloseSettingPanel();
	}

	public void QuitBtn()
	{
		this.MixerPanel.SetActive(false);
		this.QuitPanel.SetActive(true);
	}

	public void CancelQuitBtn()
	{
		this.QuitPanel.SetActive(false);
		this.MixerPanel.SetActive(true);
	}

	public void QuitGame(int flag = 0)
	{
		if (flag == 0)
		{
			Application.Quit();
			return;
		}
		if (flag != 1)
		{
			return;
		}
		SaveLoad.Save(delegate
		{
			Application.Quit();
		}, null);
	}

	public void OnSaveGame()
	{
		this.MixerPanel.SetActive(false);
		this.SavePanel.SetActive(true);
	}

	public void QuitSaveGame()
	{
		this.MixerPanel.SetActive(true);
		this.SavePanel.SetActive(false);
	}

	public void QuitMenu()
	{
		this.MixerPanel.SetActive(false);
		this.QuitMenuPanel.SetActive(true);
	}

	public void OnQuitMenuBtn()
	{
		this.QuitMenuPanel.SetActive(false);
		this.MixerPanel.SetActive(true);
		EffectAudioManager.Instance.PlayEffectAudio(6, null);
		if (SceneManager.GetActiveScene().name == "Menu")
		{
			GlobalController.Instance.CloseSettingPanel();
			return;
		}
		GlobalController.Instance.SaveGlobalData();
		UIController.LockLevel = UIController.UILevel.None;
		base.StartCoroutine(this.StartLoading());
	}

	private IEnumerator StartLoading()
	{
		UnityEngine.Object.DestroyImmediate(GlobalController.Instance.gameObject);
		PlayerPrefs.SetString("SceneName", "Menu");
		yield return SceneManager.LoadSceneAsync("LoadingScene");
		yield break;
	}

	public void OnCancelMenuBtn()
	{
		this.QuitMenuPanel.SetActive(false);
		this.MixerPanel.SetActive(true);
	}

	public void SaveGame()
	{
		if (!string.IsNullOrEmpty(this.SaveName.text))
		{
			SaveLoad.Save(delegate
			{
				this.MixerPanel.SetActive(true);
				this.SavePanel.SetActive(false);
			}, this.SaveName.text);
			return;
		}
		base.StartCoroutine("ShowTip");
	}

	private IEnumerator ShowTip()
	{
		this.TipText.text = "存档名称不能为空!";
		Color color = this.TipText.color;
		this.TipText.DOColor(new Color(color.r, color.g, color.b, 1f), 0.5f);
		this.TipText.gameObject.SetActive(true);
		yield return new WaitForSeconds(3f);
		this.TipText.DOColor(new Color(color.r, color.g, color.b, 0f), 0.5f);
		yield break;
	}

	private void Update()
	{
		if (this.SaveName.isFocused)
		{
			base.StopCoroutine("ShowTip");
			Color color = this.TipText.color;
			this.TipText.DOColor(new Color(color.r, color.g, color.b, 0f), 0.5f);
		}
	}

	public void LoadGame()
	{
	}

	public GameObject MixerPanel;

	public Slider MainVolumeSlider;

	public Slider BgVolumeSlider;

	public Slider EffectVolumeSlider;

	public Slider OtherVolumeSlider;

	public GameObject QuitPanel;

	public GameObject QuitMenuPanel;

	public GameObject SavePanel;

	public TMP_InputField SaveName;

	public TMP_Dropdown ScreenDrop;

	public TMP_Dropdown QualityDrop;

	public TMP_Dropdown WindowDrop;

	public TMP_Dropdown LocalizationDrop;

	public TMP_Dropdown VsyncDrop;

	public TMP_Text TipText;
}
