using System;

public class SharkInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_鲨鱼1");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_鲨鱼2");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_鲨鱼3");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_鲨鱼1");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_鲨鱼2");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("WJ_鲨鱼3");
	}
}
