using System;

public class TouLanInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_投篮4");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_投篮3");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_投篮4");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_投篮3");
	}
}
