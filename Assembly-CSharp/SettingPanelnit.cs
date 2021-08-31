using System;

public class SettingPanelnit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_17");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_18");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_19");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_20");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_21");
		this.InitComponents[5].text = LocalizationMgr.Instance.GetLocalizationWord("UI_22");
		this.InitComponents[6].text = LocalizationMgr.Instance.GetLocalizationWord("UI_23");
		this.InitComponents[7].text = LocalizationMgr.Instance.GetLocalizationWord("UI_24");
		this.InitComponents[8].text = LocalizationMgr.Instance.GetLocalizationWord("UI_25");
		this.InitComponents[9].text = LocalizationMgr.Instance.GetLocalizationWord("UI_26");
		this.InitComponents[10].text = LocalizationMgr.Instance.GetLocalizationWord("UI_27");
		this.InitComponents[11].text = LocalizationMgr.Instance.GetLocalizationWord("UI_28");
		this.InitComponents[12].text = LocalizationMgr.Instance.GetLocalizationWord("UI_29");
		this.InitComponents[13].text = LocalizationMgr.Instance.GetLocalizationWord("UI_30");
		this.InitComponents[14].text = LocalizationMgr.Instance.GetLocalizationWord("UI_28");
		this.InitComponents[15].text = LocalizationMgr.Instance.GetLocalizationWord("UI_29");
		this.InitComponents[16].text = LocalizationMgr.Instance.GetLocalizationWord("UI_垂直同步");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_17");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_18");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_19");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_20");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_21");
		this.InitComponents[5].text = LocalizationMgr.Instance.GetLocalizationWord("UI_22");
		this.InitComponents[6].text = LocalizationMgr.Instance.GetLocalizationWord("UI_23");
		this.InitComponents[7].text = LocalizationMgr.Instance.GetLocalizationWord("UI_24");
		this.InitComponents[8].text = LocalizationMgr.Instance.GetLocalizationWord("UI_25");
		this.InitComponents[9].text = LocalizationMgr.Instance.GetLocalizationWord("UI_26");
		this.InitComponents[10].text = LocalizationMgr.Instance.GetLocalizationWord("UI_27");
		this.InitComponents[11].text = LocalizationMgr.Instance.GetLocalizationWord("UI_28");
		this.InitComponents[12].text = LocalizationMgr.Instance.GetLocalizationWord("UI_29");
		this.InitComponents[13].text = LocalizationMgr.Instance.GetLocalizationWord("UI_30");
		this.InitComponents[14].text = LocalizationMgr.Instance.GetLocalizationWord("UI_28");
		this.InitComponents[15].text = LocalizationMgr.Instance.GetLocalizationWord("UI_29");
		this.InitComponents[16].text = LocalizationMgr.Instance.GetLocalizationWord("UI_垂直同步");
	}
}
