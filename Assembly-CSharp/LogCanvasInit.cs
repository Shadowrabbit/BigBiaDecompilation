using System;

public class LogCanvasInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_无显示");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_旅程日志");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_无显示");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_旅程日志");
	}
}
