using System;

public class TaoQuanInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_套圈1");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_套圈2");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_套圈1");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_套圈2");
	}
}
