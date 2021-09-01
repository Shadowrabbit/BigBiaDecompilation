using System;

public class ShuoMingPanelInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明基本");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明地图");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明单位");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明战斗");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明主动");
		this.InitComponents[5].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明合成");
		this.InitComponents[6].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明工具");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明基本");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明地图");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明单位");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明战斗");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明主动");
		this.InitComponents[5].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明合成");
		this.InitComponents[6].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明工具");
	}
}
