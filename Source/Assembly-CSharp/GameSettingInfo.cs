using System;

public class GameSettingInfo
{
	public const float c_DefaultVolume = 0f;

	public float mainVolume;

	public float bgVolume;

	public float effectVolume;

	public float otherVolume;

	public ScreenResolution screenResolution = ScreenResolution.Normal;

	public bool fullScreen = true;

	public int qualityLevel = 4;

	public LanguageType language;

	public int Vsync;
}
