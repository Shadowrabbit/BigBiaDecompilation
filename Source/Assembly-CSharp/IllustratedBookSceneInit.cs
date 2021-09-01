using System;

public class IllustratedBookSceneInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_31");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_32");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_33");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_34");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_35");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_31");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_32");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_33");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_34");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_35");
	}
}
