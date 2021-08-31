using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	private void Start()
	{
		this.JournalsScroll.verticalScrollbar.value = 0f;
		this.SlotLayerID = 1 << LayerMask.NameToLayer("Slot");
		UIController.UILockStack = new Stack<UnityEngine.Object>();
		this.BackToHomeButton.onClick.AddListener(new UnityAction(this.OnClickBackToHomeButton));
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out this.hit, 200f, 1 << LayerMask.NameToLayer("Card"));
			if (this.hit.collider != null && this.hit.collider.GetComponent<Card>() != null)
			{
				this.hit.collider.GetComponent<Card>().OnMouseDownHandler();
			}
			if (GameController.ins.GameData.isInDungeon)
			{
				Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out this.hit, 200f, this.SlotLayerID);
				if (this.hit.collider != null && this.hit.collider.GetComponent<CardSlot>() != null)
				{
					this.hit.collider.GetComponent<CardSlot>().OnMouseDownHandeler();
				}
			}
		}
	}

	public void OnClickBackToHomeButton()
	{
		if (UIController.LockLevel != UIController.UILevel.None)
		{
			return;
		}
		AreaData areaData = null;
		this.HideBackToHomeButton();
		AreaData areaData2;
		if (GlobalController.Instance.HomeDataController.info.PhysicsAreaData.ContainsKey(GameController.ins.GameData.CurrentAreaId))
		{
			areaData = GlobalController.Instance.HomeDataController.info.PhysicsAreaData[GameController.ins.GameData.CurrentAreaId].ParentArea;
			areaData2 = GlobalController.Instance.HomeDataController.info.PhysicsAreaData[GameController.ins.GameData.CurrentAreaId];
		}
		else
		{
			areaData = GameController.ins.GameData.AreaMap[GameController.ins.GameData.CurrentAreaId].ParentArea;
			areaData2 = GameController.ins.GameData.AreaMap[GameController.ins.GameData.CurrentAreaId];
		}
		if (areaData != null && areaData.ID != "/World")
		{
			foreach (AreaLogic areaLogic in areaData2.Logics)
			{
				if (areaLogic.GetType().GetMethod("OnExit").DeclaringType == areaLogic.GetType())
				{
					areaLogic.OnExit();
				}
			}
			GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
			GameController.getInstance().OnTableChange(areaData, true);
			return;
		}
		if (GameController.ins.GameData.CurrentAreaId.Equals("入场选择"))
		{
			base.StartCoroutine(this.ExitSelectScene());
		}
		foreach (AreaLogic areaLogic2 in areaData2.Logics)
		{
			if (areaLogic2.GetType().GetMethod("OnExit").DeclaringType == areaLogic2.GetType())
			{
				areaLogic2.OnExit();
			}
		}
		this.ShowBlackMask(null, 0.5f);
		UIController.LockLevel = UIController.UILevel.None;
		SceneManager.LoadScene("LoadingScene");
	}

	public void HideBackToHomeButton()
	{
		if (this.BackToHomeButton.interactable)
		{
			this.BackToHomeButton.interactable = false;
			this.BackToHomeButton.transform.DOMove(this.BackToHomeButton.transform.position + Vector3.left * 180f, 0.3f, false).OnComplete(delegate
			{
			});
		}
	}

	public void ShowBackToHomeButton()
	{
		if (!this.BackToHomeButton.interactable)
		{
			this.BackToHomeButton.transform.DOMove(this.BackToHomeButton.transform.position + Vector3.right * 180f, 0.3f, false).OnComplete(delegate
			{
				this.BackToHomeButton.interactable = true;
			});
		}
	}

	public void ShowCancelGameBtn()
	{
		this.CancelGameBtn.SetActive(true);
	}

	public void HideCancelGameBtn()
	{
		this.CancelGameBtn.SetActive(false);
	}

	public void ShowBlackMask(UIController.ShowBlackMaskCallBack call, float speed = 0.5f)
	{
		UIController.UILevel mLock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.All;
		this.MaskPanel.SetActive(true);
		this.MaskPanel.GetComponent<Image>().DOColor(Color.black, speed).OnComplete(delegate
		{
			UIController.LockLevel = mLock;
			UIController.ShowBlackMaskCallBack call2 = call;
			if (call2 == null)
			{
				return;
			}
			call2();
		});
	}

	public void HideBlackMask(UIController.HideBlackMaskCallBack call, float speed = 0.5f)
	{
		UIController.UILevel mLock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.All;
		this.MaskPanel.SetActive(true);
		this.MaskPanel.GetComponent<Image>().enabled = true;
		this.MaskPanel.GetComponent<Image>().DOColor(Color.clear, speed).OnComplete(delegate
		{
			UIController.LockLevel = mLock;
			this.MaskPanel.SetActive(false);
			UIController.HideBlackMaskCallBack call2 = call;
			if (call2 == null)
			{
				return;
			}
			call2();
		});
	}

	public void ShowComboPanel(int value)
	{
		if (value > 1)
		{
			Text textPanel = this.ComboPanel.transform.GetComponentInChildren<Text>();
			textPanel.transform.localScale = new Vector3(11f, 0f, 1f);
			this.ComboPanel.transform.GetComponentInChildren<Text>().text = (value.ToString() ?? "");
			this.ComboPanel.SetActive(true);
			this.ComboPanel.transform.DOScaleX(1f, 0.2f).SetEase(Ease.OutBack).OnComplete(delegate
			{
				textPanel.transform.DOScaleY(11f, 0.2f).SetEase(Ease.OutBack);
			});
			return;
		}
		this.HideComboPanel();
	}

	public void HideComboPanel()
	{
		this.ComboPanel.transform.GetComponentInChildren<Text>().text = "";
		this.ComboPanel.SetActive(false);
		this.ComboPanel.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	public void ShowMultiPlayTurnStatePanel(string content)
	{
		this.MultiPlayTurnStateTipPanel.transform.GetComponentInChildren<TMP_Text>().text = "当前回合状态：" + content;
		this.MultiPlayTurnStateTipPanel.SetActive(true);
	}

	public void HideMultiPlayTurnStatePanel()
	{
		this.MultiPlayTurnStateTipPanel.transform.GetComponentInChildren<TMP_Text>().text = "";
		this.MultiPlayTurnStateTipPanel.SetActive(false);
	}

	public void ShowGameEndTip(int f)
	{
		string text = "";
		if (f != 0)
		{
			if (f == 1)
			{
				text = "Victory";
			}
		}
		else
		{
			text = "Defeat";
		}
		this.VSGameEndTip.transform.localScale = Vector3.zero;
		this.VSGameEndTip.text = string.Concat(new string[]
		{
			text,
			"\nRank:",
			VSModeController.Instance.OldRank.ToString(),
			" -> ",
			VSModeController.Instance.Rank.ToString()
		});
		this.VSGameEndTip.gameObject.SetActive(true);
		this.VSGameEndTip.transform.DOScale(Vector3.one * 20f, 0.5f).SetEase(Ease.OutBack);
	}

	public void HideGameEndTip()
	{
		this.VSGameEndTip.gameObject.SetActive(false);
		this.VSGameEndTip.text = "";
	}

	public IEnumerator TabooUIPunchEffect()
	{
		Color temp = GameController.ins.UIController.AreaTabooDesc.transform.parent.GetComponent<Image>().color;
		yield return GameController.ins.UIController.AreaTabooDesc.transform.parent.GetComponent<Image>().DOColor(Color.red, 0.4f).WaitForCompletion();
		yield return GameController.ins.UIController.AreaTabooDesc.transform.parent.GetComponent<Image>().DOColor(temp, 0.4f).WaitForCompletion();
		yield break;
	}

	public IEnumerator AdvocateUIPunchEffect()
	{
		if (!this.isPunch)
		{
			this.isPunch = true;
			yield return GameController.ins.UIController.AreaAdvocateDesc.transform.parent.DOPunchPosition(Vector3.right * 30f, 0.4f, 10, 1f, false).WaitForCompletion();
			this.isPunch = false;
		}
		yield break;
	}

	public void ShowCardTablesButtons()
	{
		if (this.isShowCardTableBtns)
		{
			return;
		}
		this.IsCanEndTurn = false;
		this.isShowCardTableBtns = true;
		this.GlobalToysBtn.GetComponentInChildren<Button>().interactable = false;
		this.MinionTableBtn.GetComponentInChildren<Button>().interactable = false;
		this.ItemTableBtn.GetComponentInChildren<Button>().interactable = false;
		this.MagicTableBtn.GetComponentInChildren<Button>().interactable = false;
		this.SettingPanelBtn.GetComponentInChildren<Button>().interactable = false;
		base.StartCoroutine(this.ShowBtnsCorotine());
	}

	private IEnumerator ShowBtnsCorotine()
	{
		this.MagicTableBtn.DOLocalMoveY(533f, 0.5f, false).SetEase(Ease.InBack);
		yield return new WaitForSeconds(0.1f);
		this.SettingPanelBtn.DOLocalMoveY(533f, 0.5f, false).SetEase(Ease.InBack).OnComplete(delegate
		{
			this.MagicTableBtn.GetComponentInChildren<Button>().interactable = true;
			this.SettingPanelBtn.GetComponentInChildren<Button>().interactable = true;
		});
		yield break;
	}

	public void HideCardTablesButtons()
	{
		if (!this.isShowCardTableBtns)
		{
			return;
		}
		this.isShowCardTableBtns = false;
		this.GlobalToysBtn.GetComponentInChildren<Button>().interactable = false;
		this.MinionTableBtn.GetComponentInChildren<Button>().interactable = false;
		this.ItemTableBtn.GetComponentInChildren<Button>().interactable = false;
		this.MagicTableBtn.GetComponentInChildren<Button>().interactable = false;
		this.SettingPanelBtn.GetComponentInChildren<Button>().interactable = false;
		base.StartCoroutine(this.HideBtnsCorotine());
	}

	private IEnumerator HideBtnsCorotine()
	{
		this.MagicTableBtn.DOLocalMoveY(645f, 0.5f, false).SetEase(Ease.OutBack);
		yield return new WaitForSeconds(0.1f);
		this.SettingPanelBtn.DOLocalMoveY(645f, 0.5f, false).SetEase(Ease.OutBack).OnComplete(delegate
		{
			this.MagicTableBtn.GetComponentInChildren<Button>().interactable = true;
			this.SettingPanelBtn.GetComponentInChildren<Button>().interactable = true;
			this.IsCanEndTurn = true;
		});
		yield break;
	}

	private void DiaplayButtons(bool flag)
	{
		this.MinionTableBtn.GetComponentInChildren<Button>().interactable = flag;
		this.ItemTableBtn.GetComponentInChildren<Button>().interactable = flag;
		this.MagicTableBtn.GetComponentInChildren<Button>().interactable = flag;
		this.GlobalToysBtn.GetComponentInChildren<Button>().interactable = flag;
		this.SettingPanelBtn.GetComponentInChildren<Button>().interactable = flag;
	}

	public void ShowMinionTableOnMainTable()
	{
		base.StartCoroutine(this.ShowMinionTableOnMainTableCorotine());
	}

	private IEnumerator ShowMinionTableOnMainTableCorotine()
	{
		if (this.isShowCardsTable)
		{
			this.HideItemTableOnMainTable();
			this.HideMinionTableOnMainTable();
			this.HideSkillTableOnMainTable();
			this.HideToysTableOnMainTable();
			yield return new WaitForSeconds(0.7f);
		}
		this.DiaplayButtons(false);
		UIController.LockLevel = UIController.UILevel.SecondAreaTable;
		this.isShowCardsTable = true;
		Camera.main.transform.DOLocalMove(new Vector3(Camera.main.transform.localPosition.x, -4.910116f, 4.880126f), 0.2f, false);
		this.ShowMinionTable.transform.gameObject.SetActive(true);
		this.ShowMinionTable.transform.SetParent(this.ShowTableParentCamera);
		this.ShowMinionTable.CloseBtn.SetActive(true);
		this.ShowMinionTable.transform.localScale = Vector3.one * 0.4851794f;
		this.ShowMinionTable.transform.localPosition = new Vector3(0f, -6.66f, 8.02f);
		this.ShowMinionTable.transform.DOLocalMove(new Vector3(0f, -2.8f, 10.4f), 0.5f, false).SetEase(Ease.OutBack).OnComplete(delegate
		{
			this.DiaplayButtons(true);
			this.MinionTableBtn.GetComponentInChildren<Button>().interactable = false;
		});
		yield break;
	}

	public void HideMinionTableOnMainTable()
	{
		this.DiaplayButtons(false);
		this.ShowMinionTable.transform.DOLocalMove(new Vector3(0f, -6.66f, 8.02f), 0.5f, false).SetEase(Ease.InBack).OnComplete(delegate
		{
			this.ShowMinionTable.CloseBtn.SetActive(false);
			this.ShowMinionTable.gameObject.SetActive(false);
			Camera.main.transform.DOLocalMove(new Vector3(Camera.main.transform.localPosition.x, -3.6f, 2.1f), 0.2f, false).OnComplete(delegate
			{
				this.isShowCardsTable = false;
				UIController.LockLevel = UIController.UILevel.None;
				this.DiaplayButtons(true);
			});
		});
	}

	public void ShowMinionTableOnArea()
	{
		this.ShowMinionTable.transform.gameObject.SetActive(true);
		this.ShowMinionTable.transform.SetParent(this.ShowTableParent);
		this.ShowMinionTable.transform.localPosition = new Vector3(-0.06f, -0.74f, -5f);
		this.ShowMinionTable.transform.localScale = Vector3.one;
		this.ShowMinionTable.transform.DOLocalMoveZ(-0.13f, 0.5f, false);
	}

	public void HideMinionTableOnAreaTable()
	{
		this.ShowMinionTable.transform.gameObject.SetActive(false);
	}

	public void ShowItemTableOnMainTable()
	{
		base.StartCoroutine(this.ShowItemTableOnMainTableCorotine());
	}

	private IEnumerator ShowItemTableOnMainTableCorotine()
	{
		if (this.isShowCardsTable)
		{
			this.HideItemTableOnMainTable();
			this.HideMinionTableOnMainTable();
			this.HideSkillTableOnMainTable();
			this.HideToysTableOnMainTable();
			yield return new WaitForSeconds(0.7f);
		}
		this.DiaplayButtons(false);
		UIController.LockLevel = UIController.UILevel.SecondAreaTable;
		this.isShowCardsTable = true;
		Camera.main.transform.DOLocalMove(new Vector3(Camera.main.transform.localPosition.x, -4.910116f, 4.880126f), 0.2f, false);
		this.ShowItemTable.transform.gameObject.SetActive(true);
		this.ShowItemTable.transform.SetParent(this.ShowTableParentCamera);
		this.ShowItemTable.CloseBtn.SetActive(true);
		this.ShowItemTable.transform.localScale = Vector3.one * 0.4851794f;
		this.ShowItemTable.transform.localPosition = new Vector3(0f, -6.66f, 8.02f);
		this.ShowItemTable.transform.DOLocalMove(new Vector3(0f, -2.8f, 10.4f), 0.5f, false).SetEase(Ease.OutBack).OnComplete(delegate
		{
			this.DiaplayButtons(true);
			this.ItemTableBtn.GetComponentInChildren<Button>().interactable = false;
		});
		yield break;
	}

	public void HideItemTableOnMainTable()
	{
		this.DiaplayButtons(false);
		this.ShowItemTable.transform.DOLocalMove(new Vector3(0f, -6.66f, 8.02f), 0.5f, false).SetEase(Ease.InBack).OnComplete(delegate
		{
			this.ShowItemTable.CloseBtn.SetActive(false);
			this.ShowItemTable.gameObject.SetActive(false);
			Camera.main.transform.DOLocalMove(new Vector3(Camera.main.transform.localPosition.x, -3.6f, 2.1f), 0.2f, false).OnComplete(delegate
			{
				this.isShowCardsTable = false;
				UIController.LockLevel = UIController.UILevel.None;
				this.DiaplayButtons(true);
			});
		});
	}

	public void ShowItemTableOnArea()
	{
		this.ShowItemTable.transform.gameObject.SetActive(true);
		this.ShowItemTable.transform.SetParent(this.ShowTableParent);
		this.ShowItemTable.transform.localPosition = new Vector3(-0.06f, -0.74f, -5f);
		this.ShowItemTable.transform.localScale = Vector3.one;
		this.ShowItemTable.transform.DOLocalMoveZ(-0.13f, 0.5f, false);
	}

	public void HideItemTableOnAreaTable()
	{
		this.ShowItemTable.transform.gameObject.SetActive(false);
	}

	public void ShowSkillTableOnMainTable()
	{
		base.StartCoroutine(this.ShowSkillTableOnMainTableCorotine());
	}

	private IEnumerator ShowSkillTableOnMainTableCorotine()
	{
		if (this.isShowCardsTable)
		{
			this.HideItemTableOnMainTable();
			this.HideMinionTableOnMainTable();
			this.HideSkillTableOnMainTable();
			this.HideToysTableOnMainTable();
			yield return new WaitForSeconds(0.7f);
		}
		this.DiaplayButtons(false);
		UIController.LockLevel = UIController.UILevel.SecondAreaTable;
		this.isShowCardsTable = true;
		Camera.main.transform.DOLocalMove(new Vector3(Camera.main.transform.localPosition.x, -4.910116f, 4.880126f), 0.2f, false);
		this.ShowSkillTable.transform.gameObject.SetActive(true);
		this.ShowSkillTable.transform.SetParent(this.ShowTableParentCamera);
		this.ShowSkillTable.CloseBtn.SetActive(true);
		this.ShowSkillTable.transform.localScale = Vector3.one * 0.4851794f;
		this.ShowSkillTable.transform.localPosition = new Vector3(0f, -6.66f, 8.02f);
		this.ShowSkillTable.transform.DOLocalMove(new Vector3(0f, -2.8f, 10.4f), 0.5f, false).SetEase(Ease.OutBack).OnComplete(delegate
		{
			this.DiaplayButtons(true);
			this.MagicTableBtn.GetComponentInChildren<Button>().interactable = false;
		});
		yield break;
	}

	public void HideSkillTableOnMainTable()
	{
		this.DiaplayButtons(false);
		this.ShowSkillTable.transform.DOLocalMove(new Vector3(0f, -6.66f, 8.02f), 0.5f, false).SetEase(Ease.InBack).OnComplete(delegate
		{
			this.ShowSkillTable.CloseBtn.SetActive(false);
			this.ShowSkillTable.gameObject.SetActive(false);
			Camera.main.transform.DOLocalMove(new Vector3(Camera.main.transform.localPosition.x, -3.6f, 2.1f), 0.2f, false).OnComplete(delegate
			{
				this.isShowCardsTable = false;
				UIController.LockLevel = UIController.UILevel.None;
				this.DiaplayButtons(true);
			});
		});
	}

	public void ShowSkillTableOnArea()
	{
		this.ShowSkillTable.transform.gameObject.SetActive(true);
		this.ShowSkillTable.transform.SetParent(this.ShowTableParent);
		this.ShowSkillTable.transform.localPosition = new Vector3(-0.06f, -0.74f, -5f);
		this.ShowSkillTable.transform.localScale = Vector3.one;
		this.ShowSkillTable.transform.DOLocalMoveZ(-0.13f, 0.5f, false);
	}

	public void HideSkillTableOnAreaTable()
	{
		this.ShowSkillTable.transform.gameObject.SetActive(false);
	}

	public void ShowBattleTableOnArea()
	{
		GameController.ins.PlayerTable.gameObject.SetActive(true);
		GameController.ins.PlayerTable.SetParent(this.ShowTableParent);
		GameController.ins.PlayerTable.localPosition = new Vector3(0f, 0f, -2.75f);
		GameController.ins.PlayerTable.localScale = new Vector3(1.9422f, 1f, 1.9841f);
		GameController.ins.PlayerTable.DOLocalMoveZ(1.94f, 0.5f, false).SetEase(Ease.OutBack);
	}

	public void HideBattleTableOnAreaTable()
	{
		GameController.ins.PlayerTable.DOLocalMoveZ(-2.75f, 0.5f, false).SetEase(Ease.InBack).OnComplete(delegate
		{
			GameController.ins.PlayerTable.gameObject.SetActive(false);
		});
	}

	public void ResetCardTables()
	{
		this.ShowMinionTable.InitPanel(this.ShowMinionTable.ShowType, this.ShowMinionTable.Dir);
		this.ShowItemTable.InitPanel(this.ShowItemTable.ShowType, this.ShowItemTable.Dir);
		this.ShowSkillTable.InitPanel(this.ShowSkillTable.ShowType, this.ShowSkillTable.Dir);
	}

	public void ShowToytsTableOnMainTable()
	{
		base.StartCoroutine(this.ShowToysTableOnMainTableCorotine());
	}

	private IEnumerator ShowToysTableOnMainTableCorotine()
	{
		if (this.isShowCardsTable)
		{
			this.HideItemTableOnMainTable();
			this.HideMinionTableOnMainTable();
			this.HideSkillTableOnMainTable();
			this.HideToysTableOnMainTable();
			yield return new WaitForSeconds(0.7f);
		}
		this.DiaplayButtons(false);
		UIController.LockLevel = UIController.UILevel.SecondAreaTable;
		this.isShowCardsTable = true;
		Camera.main.transform.DOLocalMove(new Vector3(Camera.main.transform.localPosition.x, -4.910116f, 4.880126f), 0.2f, false);
		this.ShowToysTable.transform.gameObject.SetActive(true);
		this.ShowToysTable.transform.SetParent(this.ShowTableParentCamera);
		this.ShowToysTable.CloseBtn.SetActive(true);
		this.ShowToysTable.transform.localScale = Vector3.one * 0.4851794f;
		this.ShowToysTable.transform.localPosition = new Vector3(0f, -6.66f, 8.02f);
		this.ShowToysTable.transform.DOLocalMove(new Vector3(0f, -2.8f, 10.4f), 0.5f, false).SetEase(Ease.OutBack).OnComplete(delegate
		{
			this.DiaplayButtons(true);
			this.GlobalToysBtn.GetComponentInChildren<Button>().interactable = false;
		});
		yield break;
	}

	public void HideToysTableOnMainTable()
	{
		this.DiaplayButtons(false);
		this.ShowToysTable.transform.DOLocalMove(new Vector3(0f, -6.66f, 8.02f), 0.5f, false).SetEase(Ease.InBack).OnComplete(delegate
		{
			this.ShowToysTable.CloseBtn.SetActive(false);
			this.ShowToysTable.gameObject.SetActive(false);
			Camera.main.transform.DOLocalMove(new Vector3(Camera.main.transform.localPosition.x, -3.6f, 2.1f), 0.2f, false).OnComplete(delegate
			{
				this.isShowCardsTable = false;
				UIController.LockLevel = UIController.UILevel.None;
				this.DiaplayButtons(true);
			});
		});
	}

	public void ShowToyTableOnMainTable(List<string> modIDs)
	{
		this.HideCardTablesButtons();
		Camera.main.transform.DOLocalMove(new Vector3(Camera.main.transform.localPosition.x, -4.910116f, 4.880126f), 0.2f, false);
		this.ShowToyTable.PutToyInSlot(modIDs);
		this.ShowToyTable.gameObject.SetActive(true);
		this.ShowToyTable.transform.SetParent(this.ShowTableParentCamera);
		this.ShowToyTable.transform.localScale = Vector3.one * 0.4851794f;
		this.ShowToyTable.transform.localPosition = new Vector3(3.9f, -5.122f, 8.944f);
		this.ShowToyTable.transform.DOLocalMove(new Vector3(3.9f, -2.29f, 10.71f), 0.5f, false).SetEase(Ease.OutBack);
	}

	public void HideToyTableOnMainTable()
	{
		if (this.ShowToyTable.CheckCSDNull())
		{
			GameController.getInstance().CreateSubtitle("需将获取的新玩具放置到桌面后关闭面板！", 1f, 2f, 1f, 1f);
			return;
		}
		this.ShowToyTable.transform.DOLocalMove(new Vector3(3.9f, -5.122f, 8.944f), 0.5f, false).SetEase(Ease.InBack).OnComplete(delegate
		{
			this.ShowToyTable.gameObject.SetActive(false);
			Camera.main.transform.DOLocalMove(new Vector3(Camera.main.transform.localPosition.x, -3.6f, 2.1f), 0.2f, false).OnComplete(delegate
			{
				this.ShowCardTablesButtons();
			});
		});
	}

	public void ShowHadItemTable()
	{
		this.m_LockLevel = UIController.LockLevel;
		Camera.main.transform.DOLocalMove(new Vector3(Camera.main.transform.localPosition.x, -4.910116f, 4.880126f), 0.2f, false);
		this.ShowHadItemTableController.gameObject.SetActive(true);
		this.ShowHadItemTableController.transform.SetParent(this.ShowTableParentCamera);
		this.ShowHadItemTableController.transform.localScale = Vector3.one * 0.4851794f;
		this.ShowHadItemTableController.transform.localPosition = new Vector3(4.11f, -5.122f, 8.944f);
		this.ShowHadItemTableController.transform.DOLocalMove(new Vector3(4.11f, -2.29f, 10.71f), 0.5f, false).SetEase(Ease.OutBack);
		UIController.LockLevel = UIController.UILevel.None;
	}

	public void HideHadItemTable()
	{
		this.ShowHadItemTableController.transform.DOLocalMove(new Vector3(4.11f, -5.122f, 8.944f), 0.5f, false).SetEase(Ease.InBack).OnComplete(delegate
		{
			this.ShowHadItemTableController.gameObject.SetActive(false);
			Camera.main.transform.DOLocalMove(new Vector3(Camera.main.transform.localPosition.x, -3.6f, 2.1f), 0.2f, false).OnComplete(delegate
			{
				GameController.ins.GameData.FaithData.IsTakeItem = true;
				UIController.LockLevel = this.m_LockLevel;
			});
		});
	}

	public void ShowSettingPanel()
	{
		if ((UIController.UILevel.PlayerSlot & UIController.LockLevel) > UIController.UILevel.None)
		{
			return;
		}
		GlobalController.Instance.ShowSettingPanel();
	}

	public void ShowQuitGamePanel()
	{
		this.QuitGamePanle.SetActive(true);
	}

	public void ShowMoneyPanel()
	{
		this.MoneyText.transform.parent.gameObject.SetActive(true);
		this.TwistedEggCouponText.transform.parent.gameObject.SetActive(true);
	}

	public void HideMoneyPanel()
	{
		this.MoneyText.transform.parent.gameObject.SetActive(false);
		this.TwistedEggCouponText.transform.parent.gameObject.SetActive(false);
	}

	public void ShowJudgePanel(List<EventJudgeBean> content)
	{
		this.JudgePanel.gameObject.SetActive(true);
		this.JudgePanel.InitJudgePanel(content);
		this.JudgePanel.transform.DOLocalMoveY(390f, 0.5f, false).SetEase(Ease.OutBack);
	}

	public void UpdateJudgePanel(Vector3 target)
	{
		this.JudgePanel.UpdateJudgePanel(target);
	}

	public void HideJudgePanel()
	{
		this.JudgePanel.transform.DOLocalMoveY(694f, 0.5f, false).SetEase(Ease.InBack).OnComplete(delegate
		{
			this.JudgePanel.CloseJudgePanel();
			this.JudgePanel.gameObject.SetActive(false);
		});
	}

	private IEnumerator ExitSelectScene()
	{
		SelectAreaAllSlotsController componentInChildren = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().GetComponentInChildren<SelectAreaAllSlotsController>();
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardData> list = new List<CardData>();
		List<CardData> myItems = new List<CardData>();
		List<CardData> myMagics = new List<CardData>();
		foreach (CardSlotData cardSlotData in playerSlotSets)
		{
			if (cardSlotData.ChildCardData != null)
			{
				if (cardSlotData.ChildCardData.HasTag(TagMap.随从))
				{
					list.Add(cardSlotData.ChildCardData);
				}
				if (cardSlotData.ChildCardData.HasTag(TagMap.道具))
				{
					myItems.Add(cardSlotData.ChildCardData);
				}
				if (cardSlotData.ChildCardData.HasTag(TagMap.装备))
				{
					myMagics.Add(cardSlotData.ChildCardData);
				}
			}
		}
		List<CardSlotData> list2 = new List<CardSlotData>();
		foreach (CardSlot cardSlot in componentInChildren.AllMinionSlots)
		{
			if (cardSlot.CardSlotData.ChildCardData == null && cardSlot.CardSlotData.SlotType != CardSlotData.Type.Freeze)
			{
				list2.Add(cardSlot.CardSlotData);
			}
		}
		List<CardSlotData> curEmptyItemSlots = new List<CardSlotData>();
		foreach (CardSlot cardSlot2 in componentInChildren.AllItemSlots)
		{
			if (cardSlot2.CardSlotData.ChildCardData == null && cardSlot2.CardSlotData.SlotType != CardSlotData.Type.Freeze)
			{
				curEmptyItemSlots.Add(cardSlot2.CardSlotData);
			}
		}
		List<CardSlotData> curEmptyMagicSlots = new List<CardSlotData>();
		foreach (CardSlot cardSlot3 in componentInChildren.AllMagicSlots)
		{
			if (cardSlot3.CardSlotData.ChildCardData == null && cardSlot3.CardSlotData.SlotType != CardSlotData.Type.Freeze)
			{
				curEmptyMagicSlots.Add(cardSlot3.CardSlotData);
			}
		}
		bool isStop = false;
		if (list2.Count >= list.Count)
		{
			for (int j = 0; j < list.Count; j++)
			{
				list[j].PutInSlotData(list2[j], true);
			}
		}
		else
		{
			for (int k = 0; k < list2.Count; k++)
			{
				list[k].PutInSlotData(list2[k], true);
			}
			isStop = true;
		}
		foreach (CardSlot tarSlot in componentInChildren.AllItemSlots)
		{
			if (tarSlot.CardSlotData.ChildCardData != null && tarSlot.CardSlotData.ChildCardData.MaxCount > 1)
			{
				int num2;
				for (int i = myItems.Count - 1; i >= 0; i = num2 - 1)
				{
					if (tarSlot.CardSlotData.ChildCardData.ModID.Equals(myItems[i].ModID))
					{
						if (myItems[i].MaxCount >= tarSlot.CardSlotData.ChildCardData.Count + myItems[i].Count)
						{
							tarSlot.CardSlotData.ChildCardData.Count = tarSlot.CardSlotData.ChildCardData.Count + myItems[i].Count;
							CardData cardData = myItems[i];
							myItems.Remove(myItems[i]);
							cardData.DeleteCardData();
						}
						else
						{
							int count = myItems[i].Count;
							int num = myItems[i].MaxCount - tarSlot.CardSlotData.ChildCardData.Count;
							int lastCount = count - num;
							CardData newItem = CardData.CopyCardData(myItems[i], true);
							Card.InitCard(newItem);
							newItem.Count = num;
							newItem.CardGameObject.transform.position = myItems[i].CardGameObject.transform.position;
							newItem.CardGameObject.transform.DOJump(tarSlot.CardSlotData.ChildCardData.CardGameObject.transform.position, 1f, 1, 0.1f, false);
							yield return new WaitForSeconds(0.1f);
							tarSlot.CardSlotData.ChildCardData.Count = tarSlot.CardSlotData.ChildCardData.MaxCount;
							newItem.DeleteCardData();
							myItems[i].Count = lastCount;
							num2 = i;
							i = num2 + 1;
							newItem = null;
						}
					}
					num2 = i;
				}
				tarSlot = null;
			}
		}
		List<CardSlot>.Enumerator enumerator3 = default(List<CardSlot>.Enumerator);
		if (curEmptyItemSlots.Count >= myItems.Count)
		{
			for (int l = 0; l < myItems.Count; l++)
			{
				myItems[l].PutInSlotData(curEmptyItemSlots[l], true);
			}
		}
		else
		{
			for (int m = 0; m < curEmptyItemSlots.Count; m++)
			{
				myItems[m].PutInSlotData(curEmptyItemSlots[m], true);
			}
			isStop = true;
		}
		if (curEmptyMagicSlots.Count >= myMagics.Count)
		{
			for (int n = 0; n < myMagics.Count; n++)
			{
				myMagics[n].PutInSlotData(curEmptyMagicSlots[n], true);
			}
		}
		else
		{
			for (int num3 = 0; num3 < curEmptyMagicSlots.Count; num3++)
			{
				myMagics[num3].PutInSlotData(curEmptyMagicSlots[num3], true);
			}
			isStop = true;
		}
		if (isStop)
		{
			GameController.getInstance().UIController.ShowQuitGamePanel();
			yield break;
		}
		yield return new WaitForSeconds(1f);
		GameController.getInstance().GameData.isInDungeon = false;
		DungeonController.Instance.StartCoroutine(DungeonController.Instance.GameOver(true));
		yield break;
		yield break;
	}

	public void ShowGetCardTipPanel()
	{
		this.GetCardTipPanel.SetActive(true);
	}

	public void HideGetCardTipPanel()
	{
		this.GetCardTipPanel.SetActive(false);
	}

	public void OnShuoMingShow()
	{
		this.SettingPanelBtn.GetComponentInChildren<Button>().interactable = false;
		this.ShuoMingBtn.GetComponentInChildren<Button>().interactable = false;
		this.ShuoMingPanel.transform.GetComponent<ShuoMingUIController>().Init();
		this.ShuoMingPanel.SetActive(true);
		this.ShuoMingPanel.transform.DOScale(Vector3.one, 0.2f).OnComplete(delegate
		{
			this.ShuoMingBtn.GetComponentInChildren<Button>().interactable = true;
			this.SettingPanelBtn.GetComponentInChildren<Button>().interactable = true;
		});
	}

	public void OnCloseMingShow()
	{
		this.ShuoMingPanel.transform.DOScale(Vector3.zero, 0.2f).OnComplete(delegate
		{
			this.ShuoMingPanel.SetActive(false);
			this.ShuoMingPanel.transform.GetComponent<ShuoMingUIController>().Init();
		});
	}

	public void ShowFaithPanel()
	{
		GameController.ins.UIController.ShowBlackMask(delegate
		{
			UnityEngine.Object.Instantiate(Resources.Load("UI/Canvas/FaithCanvas"));
			GameController.ins.UIController.HideBlackMask(delegate
			{
			}, 0.5f);
		}, 0.5f);
	}

	public void ShowCheckCardLogicPanel(CardData data)
	{
		GameController.ins.CreateSubtitle("请选择你想删除的词条！", 1f, 2f, 1f, 1f);
		this.LogicCheckController.OpenPanel(data);
		this.LogicCheckController.gameObject.SetActive(true);
	}

	public void ShowUpdateCardLogicPanel(CardData data, int count = 1, int layers = 1)
	{
		GameController.ins.CreateSubtitle("请选择你想升级的词条！", 1f, 2f, 1f, 1f);
		this.LogicUpdateController.OpenPanel(data, count, 1);
		this.LogicUpdateController.gameObject.SetActive(true);
	}

	public Text HpText;

	public Text NeedEatTurnsText;

	public TMP_Text MoneyText;

	public TMP_Text TwistedEggCouponText;

	public TextMeshProUGUI FinalLabel;

	public GameObject MaskPanel;

	public Transform FinalCardListStartTransform;

	public Transform BigBoxCamerTrans;

	public Transform SettleCamerTrans;

	public GameObject BigBox;

	public Transform FullScreenCanvasTrans;

	public Light MainLight;

	public GameObject ComboPanel;

	public TextMeshProUGUI JournalsText;

	public ScrollRect JournalsScroll;

	public Button BackToHomeButton;

	public Canvas AttrCanvas;

	public GuideCanvasController GuideCanvasController;

	public YesOrNoPanel YesOrNoPanel;

	public YesPanel YesPanel;

	public NumberInputPanel NumberInputPanel;

	public CurrentAreaDataPanel CurrentAreaDataPanel;

	public GameObject MultiPlayTurnStateTipPanel;

	public Text VSGameEndTip;

	public SpotLightController SpotLightController;

	public ShowCardsByTypeController ShowMinionTable;

	public ShowCardsByTypeController ShowItemTable;

	public ShowCardsByTypeController ShowSkillTable;

	public Transform ShowTableParentCamera;

	public Transform ShowTableParent;

	public EnergyUI EnergyUI;

	public TextMeshProUGUI AreaTabooDesc;

	public TextMeshProUGUI AreaAdvocateDesc;

	public TextMeshProUGUI MinionMaxMenu;

	public LevelUpPreviewUI LevelUpPreviewUI;

	public Transform SpeedOneButton;

	public Transform SpeedTwoButton;

	public static UIController.UILevel LockLevel;

	public static Stack<UnityEngine.Object> UILockStack;

	private RaycastHit hit;

	private int SlotLayerID;

	private CardData target;

	public GameObject CancelGameBtn;

	private bool isPunch;

	public Transform MinionTableBtn;

	public Transform ItemTableBtn;

	public Transform MagicTableBtn;

	public Transform GlobalToysBtn;

	public Transform SettingPanelBtn;

	private bool isShowCardTableBtns = true;

	public bool IsCanEndTurn;

	private bool isShowCardsTable;

	public ShowGlobalToysController ShowToysTable;

	public ShowToyController ShowToyTable;

	public ShowHadItemTableController ShowHadItemTableController;

	private UIController.UILevel m_LockLevel;

	public GameObject QuitGamePanle;

	public CreateCardBtnController CreateCardBtnController;

	public JudgePanelUIController JudgePanel;

	public GameObject GetCardTipPanel;

	public GameObject ShuoMingPanel;

	public Transform ShuoMingBtn;

	public NewLogPanelInGame LogPanel;

	public LogicCheckController LogicCheckController;

	public LogicUpdateController LogicUpdateController;

	[Flags]
	public enum UILevel
	{
		None = 0,
		PlayerSlot = 1,
		AreaTable = 2,
		ActTable = 4,
		GameUI = 8,
		SystemUI = 16,
		SecondAreaTable = 32,
		All = 2147483647
	}

	public delegate void ShowBlackMaskCallBack();

	public delegate void HideBlackMaskCallBack();
}
