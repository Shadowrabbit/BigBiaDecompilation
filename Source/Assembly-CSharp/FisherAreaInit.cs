using System;

public class FisherAreaInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("T_渔夫");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("T_渔夫");
	}
}
