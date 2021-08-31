using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BankHouseCanvasContoller : MonoBehaviour
{
	private void Start()
	{
		UIController.LockLevel = UIController.UILevel.All;
		this.CurrentSaveMoney.text = (GlobalController.Instance.ChangeGlobalSaveMoney(0).ToString() ?? "");
		this.CurrentMoney.text = (GameController.ins.GameData.Money.ToString() ?? "");
		this.GetPanelInput.text = "0";
		this.SetPanelInput.text = "0";
		this.GetPanelInput.onValueChanged.AddListener(new UnityAction<string>(this.InputFieldValueChanged));
		this.SetPanelInput.onValueChanged.AddListener(new UnityAction<string>(this.InputFieldValueChanged));
	}

	private void InputFieldValueChanged(string arg0)
	{
		if (!string.IsNullOrEmpty(arg0) && int.Parse(arg0.Trim()) > 500)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_15"), 1f, 2f, 1f, 1f);
			this.GetPanelInput.text = "500";
			this.SetPanelInput.text = "500";
		}
	}

	public void OnCloseCanvas()
	{
		UnityEngine.Object.Destroy(base.gameObject);
		UIController.LockLevel = UIController.UILevel.None;
	}

	public void OnShowSetPanel()
	{
		this.GetPanel.SetActive(false);
		this.SetPanelInput.text = "0";
		this.SetPanel.SetActive(true);
	}

	public void OnShowGetPanel()
	{
		this.SetPanel.SetActive(false);
		this.GetPanelInput.text = "0";
		this.GetPanel.SetActive(true);
	}

	public void OnSetMoney()
	{
		if (int.Parse(this.SetPanelInput.text.Trim()) == 0)
		{
			return;
		}
		if (int.Parse(this.SetPanelInput.text.Trim()) > GameController.ins.GameData.Money)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_1"), 1f, 2f, 1f, 1f);
			return;
		}
		if (int.Parse(this.SetPanelInput.text.Trim()) < 0)
		{
			this.SetPanelInput.text = "0";
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord(LocalizationMgr.Instance.GetLocalizationWord("ZM_16")), 1f, 2f, 1f, 1f);
			return;
		}
		GlobalController.Instance.ChangeGlobalSaveMoney(int.Parse(this.SetPanelInput.text.Trim()));
		GameController.ins.GameData.Money -= int.Parse(this.SetPanelInput.text.Trim());
		SteamController.Instance.SteamAchievementsController.SetAchievementStatus(AchievementType.NEW_ACHIEVEMENT_licaigaoshou, int.Parse(this.SetPanelInput.text.Trim()));
		JournalsConversationManager.PutJournals(new JournalsBean
		{
			FormatString = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_存钱"), int.Parse(this.SetPanelInput.text.Trim()))
		});
		this.SetPanelInput.text = (0.ToString() ?? "");
		this.CurrentSaveMoney.text = (GlobalController.Instance.ChangeGlobalSaveMoney(0).ToString() ?? "");
		this.CurrentMoney.text = (GameController.ins.GameData.Money.ToString() ?? "");
		this.OnCloseCanvas();
	}

	public void OnGetMoney()
	{
		if (int.Parse(this.GetPanelInput.text.Trim()) == 0)
		{
			return;
		}
		if (int.Parse(this.GetPanelInput.text.Trim()) > GlobalController.Instance.ChangeGlobalSaveMoney(0))
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_1"), 1f, 2f, 1f, 1f);
			return;
		}
		if (int.Parse(this.GetPanelInput.text.Trim()) < 0)
		{
			this.GetPanelInput.text = "0";
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord(LocalizationMgr.Instance.GetLocalizationWord("ZM_16")), 1f, 2f, 1f, 1f);
			return;
		}
		GlobalController.Instance.ChangeGlobalSaveMoney(-int.Parse(this.GetPanelInput.text.Trim()));
		GameController.ins.GameData.Money += int.Parse(this.GetPanelInput.text.Trim());
		JournalsConversationManager.PutJournals(new JournalsBean
		{
			FormatString = string.Format(LocalizationMgr.Instance.GetLocalizationWord("T_取钱"), int.Parse(this.GetPanelInput.text.Trim()))
		});
		this.GetPanelInput.text = (0.ToString() ?? "");
		this.CurrentSaveMoney.text = (GlobalController.Instance.ChangeGlobalSaveMoney(0).ToString() ?? "");
		this.CurrentMoney.text = (GameController.ins.GameData.Money.ToString() ?? "");
		this.OnCloseCanvas();
	}

	public void OnCloseChildPanel(Transform go)
	{
		this.GetPanelInput.text = "0";
		this.SetPanelInput.text = "0";
		go.parent.gameObject.SetActive(false);
	}

	public void AddMoney1(TMP_InputField inf)
	{
		inf.text = (((int.Parse(inf.text.Trim()) + 1 > 500) ? 500 : (int.Parse(inf.text.Trim()) + 1)).ToString() ?? "");
	}

	public void AddMoney10(TMP_InputField inf)
	{
		inf.text = (((int.Parse(inf.text.Trim()) + 10 > 500) ? 500 : (int.Parse(inf.text.Trim()) + 10)).ToString() ?? "");
	}

	public void RedMoney1(TMP_InputField inf)
	{
		inf.text = (((int.Parse(inf.text.Trim()) - 1 < 0) ? 0 : (int.Parse(inf.text.Trim()) - 1)).ToString() ?? "");
	}

	public void RedMoney10(TMP_InputField inf)
	{
		inf.text = (((int.Parse(inf.text.Trim()) - 10 < 0) ? 0 : (int.Parse(inf.text.Trim()) - 10)).ToString() ?? "");
	}

	public TMP_Text CurrentSaveMoney;

	public TMP_Text CurrentMoney;

	public GameObject SetPanel;

	public GameObject GetPanel;

	public TMP_InputField SetPanelInput;

	public TMP_InputField GetPanelInput;
}
