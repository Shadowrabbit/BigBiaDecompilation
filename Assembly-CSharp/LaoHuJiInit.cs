using System;

public class LaoHuJiInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_老虎机1");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_老虎机2");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_老虎机3");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_老虎机1");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_老虎机2");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_老虎机3");
	}
}
