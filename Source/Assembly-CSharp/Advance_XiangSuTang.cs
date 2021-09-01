using System;

public class Advance_XiangSuTang : AdvanceUIBase
{
	private void Start()
	{
		this.ContentText.text = LocalizationMgr.Instance.GetLocalizationWord(this.Content);
		this.PriceText.text = (this.Price.ToString() ?? "");
		if (GlobalController.Instance.AdvanceDataController.GetXiangSuTang())
		{
			this.ButtonImage.sprite = this.Images[1];
			this.BuyButton.interactable = false;
		}
	}

	public override void OnButtonClick()
	{
		if (GlobalController.Instance.GlobalData.Money >= this.Price)
		{
			GlobalController.Instance.ChangeGlobalMoney(-this.Price);
			GlobalController.Instance.AdvanceDataController.SetXiangSuTang(true);
			this.ButtonImage.sprite = this.Images[1];
			this.BuyButton.interactable = false;
			return;
		}
		GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_1"), 1f, 2f, 1f, 1f);
	}
}
