using System;

public class ShuoMingDanWeiInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容单位");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容单位");
	}
}
