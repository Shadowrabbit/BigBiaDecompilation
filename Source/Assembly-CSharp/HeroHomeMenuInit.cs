using System;

public class HeroHomeMenuInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_解锁");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_取消");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_解锁");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_取消");
	}
}
