using System;

public class ChooseSceneInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_选择英雄");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约等级");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约描述");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_选择英雄");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约等级");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_契约描述");
	}
}
