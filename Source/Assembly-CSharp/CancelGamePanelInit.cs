using System;

public class CancelGamePanelInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_返回桌面");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_28");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_29");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_返回桌面");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_28");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_29");
	}
}
