using System;

public class ShuoMingZhanDouInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容战斗1");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容战斗2");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容战斗3");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容战斗4");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容战斗5");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容战斗1");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容战斗2");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容战斗3");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容战斗4");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容战斗5");
	}
}
