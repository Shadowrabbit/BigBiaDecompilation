using System;

public class MainMenuInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_菜单");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_菜单");
	}
}
