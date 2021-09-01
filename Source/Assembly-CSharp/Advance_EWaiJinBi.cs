using System;
using System.Collections.Generic;
using System.Linq;

public class Advance_EWaiJinBi : AdvanceUIBase
{
	private void Start()
	{
		this.InitDic();
		if (GlobalController.Instance.AdvanceDataController.GetEWaiJinBi() < 5)
		{
			if (GlobalController.Instance.AdvanceDataController.GetEWaiJinBi() == 4)
			{
				this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetEWaiJinBi() - 1).Key;
				this.ContentText.text = this.Content;
				this.PriceText.text = "";
				this.ButtonImage.sprite = this.Images[1];
				this.BuyButton.interactable = false;
				return;
			}
			this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetEWaiJinBi()).Key;
			this.Price = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetEWaiJinBi()).Value;
			this.ContentText.text = this.Content;
			this.PriceText.text = (this.Price.ToString() ?? "");
		}
	}

	private void InitDic()
	{
		this.m_ContentAndPrice.Add(LocalizationMgr.Instance.GetLocalizationWord("UI_45"), 50);
		this.m_ContentAndPrice.Add(LocalizationMgr.Instance.GetLocalizationWord("UI_46"), 100);
		this.m_ContentAndPrice.Add(LocalizationMgr.Instance.GetLocalizationWord("UI_47"), 150);
		this.m_ContentAndPrice.Add(LocalizationMgr.Instance.GetLocalizationWord("UI_48"), 200);
	}

	public override void OnButtonClick()
	{
		if (GlobalController.Instance.GlobalData.Money >= this.Price)
		{
			GlobalController.Instance.ChangeGlobalMoney(-this.Price);
			SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_zhufu);
			if (GlobalController.Instance.AdvanceDataController.GetEWaiJinBi() + 1 < 5)
			{
				GlobalController.Instance.AdvanceDataController.SetEWaiJinBi(GlobalController.Instance.AdvanceDataController.GetEWaiJinBi() + 1);
				if (GlobalController.Instance.AdvanceDataController.GetEWaiJinBi() == 4)
				{
					this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetEWaiJinBi() - 1).Key;
					this.ContentText.text = this.Content;
					this.PriceText.text = "";
					this.ButtonImage.sprite = this.Images[1];
					this.BuyButton.interactable = false;
					return;
				}
				this.Content = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetEWaiJinBi()).Key;
				this.Price = this.m_ContentAndPrice.ElementAt(GlobalController.Instance.AdvanceDataController.GetEWaiJinBi()).Value;
				this.ContentText.text = this.Content;
				this.PriceText.text = (this.Price.ToString() ?? "");
				return;
			}
		}
		else
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_1"), 1f, 2f, 1f, 1f);
		}
	}

	private Dictionary<string, int> m_ContentAndPrice = new Dictionary<string, int>();
}
