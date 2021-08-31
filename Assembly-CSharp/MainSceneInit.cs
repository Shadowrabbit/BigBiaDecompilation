using System;

public class MainSceneInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_7");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_8");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_9");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_10");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_11");
		this.InitComponents[5].text = LocalizationMgr.Instance.GetLocalizationWord("UI_12");
		this.InitComponents[6].text = LocalizationMgr.Instance.GetLocalizationWord("UI_13");
		this.InitComponents[7].text = LocalizationMgr.Instance.GetLocalizationWord("UI_14");
		this.InitComponents[8].text = LocalizationMgr.Instance.GetLocalizationWord("UI_15");
		this.InitComponents[9].text = LocalizationMgr.Instance.GetLocalizationWord("UI_16");
		this.InitComponents[10].text = LocalizationMgr.Instance.GetLocalizationWord("UI_冒险碑");
		this.InitComponents[11].text = LocalizationMgr.Instance.GetLocalizationWord("UI_冒险碑描述");
		this.InitComponents[12].text = LocalizationMgr.Instance.GetLocalizationWord("UI_玩具箱");
		this.InitComponents[13].text = LocalizationMgr.Instance.GetLocalizationWord("UI_玩具箱描述");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_7");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_8");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_9");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_10");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_11");
		this.InitComponents[5].text = LocalizationMgr.Instance.GetLocalizationWord("UI_12");
		this.InitComponents[6].text = LocalizationMgr.Instance.GetLocalizationWord("UI_13");
		this.InitComponents[7].text = LocalizationMgr.Instance.GetLocalizationWord("UI_14");
		this.InitComponents[8].text = LocalizationMgr.Instance.GetLocalizationWord("UI_15");
		this.InitComponents[9].text = LocalizationMgr.Instance.GetLocalizationWord("UI_16");
		this.InitComponents[10].text = LocalizationMgr.Instance.GetLocalizationWord("UI_冒险碑");
		this.InitComponents[11].text = LocalizationMgr.Instance.GetLocalizationWord("UI_冒险碑描述");
		this.InitComponents[12].text = LocalizationMgr.Instance.GetLocalizationWord("UI_玩具箱");
		this.InitComponents[13].text = LocalizationMgr.Instance.GetLocalizationWord("UI_玩具箱描述");
	}
}
