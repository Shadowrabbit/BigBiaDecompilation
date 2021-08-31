using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Audio;

public class GameSettingController
{
	public GlobalController GlobalController
	{
		get
		{
			return GlobalController.Instance;
		}
	}

	public void Init()
	{
		if (!File.Exists(this.settingPath))
		{
			this.CreateSettingInfo();
		}
		else
		{
			this.LoadSettingInfo();
		}
		this.ApplySetting();
	}

	public void ApplySetting()
	{
		this.ApplyAudioSetting(MixType.Mixer_All, 0f);
		this.ApplyResolution(this.info.screenResolution);
		this.ApplyQuality(this.info.qualityLevel);
		this.ApplyFullScreen(this.info.fullScreen);
		this.ApplyLanguage(this.info.language);
		this.ApplyVsync(this.info.Vsync);
	}

	public void ApplyAudioSetting(MixType type, float value)
	{
		AudioMixer audioMixer = this.GlobalController.AudioMixer;
		switch (type)
		{
		case MixType.Mixer_All:
			audioMixer.SetFloat("Mixer_Master", this.info.mainVolume);
			audioMixer.SetFloat("Mixer_BG", this.info.bgVolume);
			audioMixer.SetFloat("Mixer_Effect", this.info.effectVolume);
			audioMixer.SetFloat("Mixer_Other", this.info.otherVolume);
			this.GlobalController.SettingPanel.InitPanel(this.info.mainVolume, this.info.bgVolume, this.info.effectVolume, this.info.otherVolume);
			return;
		case MixType.Mixer_Master:
			audioMixer.SetFloat("Mixer_Master", value);
			this.info.mainVolume = value;
			return;
		case MixType.Mixer_BG:
			audioMixer.SetFloat("Mixer_BG", value);
			this.info.bgVolume = value;
			return;
		case MixType.Mixer_Effect:
			audioMixer.SetFloat("Mixer_Effect", value);
			this.info.effectVolume = value;
			return;
		case MixType.Mixer_Other:
			audioMixer.SetFloat("Mixer_Other", value);
			this.info.otherVolume = value;
			return;
		default:
			return;
		}
	}

	public void ApplyFullScreen(bool isFull)
	{
		switch (this.info.screenResolution)
		{
		case ScreenResolution.Low:
			Screen.SetResolution(1280, 720, isFull);
			break;
		case ScreenResolution.Normal:
			Screen.SetResolution(1920, 1080, isFull);
			break;
		case ScreenResolution.High:
			Screen.SetResolution(2560, 1440, isFull);
			break;
		}
		this.info.fullScreen = isFull;
	}

	public void ApplyResolution(ScreenResolution type)
	{
		switch (type)
		{
		case ScreenResolution.Low:
			Screen.SetResolution(1280, 720, this.info.fullScreen);
			break;
		case ScreenResolution.Normal:
			Screen.SetResolution(1920, 1080, this.info.fullScreen);
			break;
		case ScreenResolution.High:
			Screen.SetResolution(2560, 1440, this.info.fullScreen);
			break;
		}
		this.info.screenResolution = type;
	}

	public void ApplyQuality(int level = 0)
	{
		QualitySettings.SetQualityLevel(level, true);
		this.info.qualityLevel = ((level > 5) ? 5 : level);
	}

	public void ApplyLanguage(LanguageType type)
	{
		LocalizationMgr.Instance.GetLocalizationDic(type);
		this.info.language = type;
	}

	public void ApplyVsync(int value)
	{
		QualitySettings.vSyncCount = value;
		this.info.Vsync = value;
	}

	public void CreateSettingInfo()
	{
		this.info = new GameSettingInfo();
		this.SaveSettingInfo();
	}

	public void LoadSettingInfo()
	{
		string value = File.ReadAllText(this.settingPath);
		this.info = (JsonConvert.DeserializeObject(value, typeof(GameSettingInfo)) as GameSettingInfo);
		if (this.info == null)
		{
			this.CreateSettingInfo();
		}
	}

	public void SaveSettingInfo()
	{
		if (File.Exists(this.settingPath))
		{
			File.Delete(this.settingPath);
		}
		string contents = JsonConvert.SerializeObject(this.info);
		File.WriteAllText(this.settingPath, contents);
	}

	public GameSettingInfo info;

	public string settingPath = Path.Combine(Application.persistentDataPath, "setting.json");
}
