using System;

public class ShuoMingDiTuInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图1");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图2");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图3");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图4");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图5");
		this.InitComponents[5].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图6");
		this.InitComponents[6].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图7");
		this.InitComponents[7].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图8");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图1");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图2");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图3");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图4");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图5");
		this.InitComponents[5].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图6");
		this.InitComponents[6].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图7");
		this.InitComponents[7].text = LocalizationMgr.Instance.GetLocalizationWord("UI_说明内容地图8");
	}
}
