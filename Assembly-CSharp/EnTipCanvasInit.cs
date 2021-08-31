using System;

public class EnTipCanvasInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_英文版提示");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_继续");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_英文版提示");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_继续");
	}
}
