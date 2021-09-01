using System;

public class BuildingCanvasInit : SceneUIInitBase
{
	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void OnLanguageChanged(LanguageType obj)
	{
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_重置");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_编辑");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_运行");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_6");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_地形");
		this.InitComponents[5].text = LocalizationMgr.Instance.GetLocalizationWord("UI_道路");
		this.InitComponents[6].text = LocalizationMgr.Instance.GetLocalizationWord("UI_建筑");
		this.InitComponents[7].text = LocalizationMgr.Instance.GetLocalizationWord("UI_景观");
		this.InitComponents[8].text = LocalizationMgr.Instance.GetLocalizationWord("UI_特殊");
		this.InitComponents[9].text = LocalizationMgr.Instance.GetLocalizationWord("UI_35");
		this.InitComponents[10].text = LocalizationMgr.Instance.GetLocalizationWord("UI_Beta版本");
		this.InitComponents[11].text = LocalizationMgr.Instance.GetLocalizationWord("UI_继续");
	}

	public override void Start()
	{
		base.Start();
		this.InitComponents[0].text = LocalizationMgr.Instance.GetLocalizationWord("UI_重置");
		this.InitComponents[1].text = LocalizationMgr.Instance.GetLocalizationWord("UI_编辑");
		this.InitComponents[2].text = LocalizationMgr.Instance.GetLocalizationWord("UI_运行");
		this.InitComponents[3].text = LocalizationMgr.Instance.GetLocalizationWord("UI_6");
		this.InitComponents[4].text = LocalizationMgr.Instance.GetLocalizationWord("UI_地形");
		this.InitComponents[5].text = LocalizationMgr.Instance.GetLocalizationWord("UI_道路");
		this.InitComponents[6].text = LocalizationMgr.Instance.GetLocalizationWord("UI_建筑");
		this.InitComponents[7].text = LocalizationMgr.Instance.GetLocalizationWord("UI_景观");
		this.InitComponents[8].text = LocalizationMgr.Instance.GetLocalizationWord("UI_特殊");
		this.InitComponents[9].text = LocalizationMgr.Instance.GetLocalizationWord("UI_35");
		this.InitComponents[10].text = LocalizationMgr.Instance.GetLocalizationWord("UI_Beta版本");
		this.InitComponents[11].text = LocalizationMgr.Instance.GetLocalizationWord("UI_继续");
	}
}
