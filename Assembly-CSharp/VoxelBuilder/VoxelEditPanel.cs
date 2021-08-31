using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VoxelBuilder
{
	public class VoxelEditPanel : MonoBehaviour
	{
		private void Start()
		{
			VoxelEditPanel.Instance = this;
			base.StartCoroutine(this.WaitMgrInit());
		}

		private IEnumerator WaitMgrInit()
		{
			while (!VoxelBuilderMgr.OnSceneEnterDone)
			{
				yield return null;
			}
			if (VoxelBuilderMgr.IsReadMode)
			{
				base.gameObject.SetActive(false);
				yield break;
			}
			this.loadCellPrefab = Resources.Load<GameObject>("VoxelBuilder/VoxcelEdtiPanelLoadCell");
			this.colorCellPrefab = Resources.Load<GameObject>("VoxelBuilder/VoxcelEditPanelColorCell");
			this.InitButtons();
			this.InitLoadWindow(VoxelBuilderMgr.Instance.DataDics);
			this.InitColorPalette();
			yield break;
		}

		private void InitButtons()
		{
			this.attachButton.onClick.AddListener(delegate()
			{
				this.mgr.ChangeInputType(VoxelBuilderMgr.VoxelBuilderInputType.Attach);
			});
			this.eraseButton.onClick.AddListener(delegate()
			{
				this.mgr.ChangeInputType(VoxelBuilderMgr.VoxelBuilderInputType.Erase);
			});
			this.paintButton.onClick.AddListener(delegate()
			{
				this.mgr.ChangeInputType(VoxelBuilderMgr.VoxelBuilderInputType.Paint);
			});
			this.menuButton.onClick.AddListener(delegate()
			{
			});
			this.saveButton.onClick.AddListener(new UnityAction(this.OnSaveButtonClicked));
			this.loadMenuButton.onClick.AddListener(delegate()
			{
				this.loadMenuWindow.SetActive(true);
			});
			this.loadWindowCloseButton.onClick.AddListener(delegate()
			{
				this.loadMenuWindow.SetActive(false);
			});
			this.clearButton.onClick.AddListener(delegate()
			{
				this.mgr.Clear();
			});
			this.sameFileWarningCancelButton.onClick.AddListener(delegate()
			{
				this.sameFileWarningWindow.SetActive(false);
			});
			this.sameFileWarningConfirmButton.onClick.AddListener(delegate()
			{
				KeyValuePair<string, VoxelBuilderData> keyValuePair = VoxelBuilderMgr.Instance.Save(this.fileNameInputFiled.text);
				this.AddMenuObj(keyValuePair.Key, keyValuePair.Value);
				this.sameFileWarningWindow.SetActive(false);
			});
			this.backButton.onClick.AddListener(new UnityAction(this.OnBackButtonClicked));
			this.backWarningConfirmButton.onClick.AddListener(new UnityAction(this.OnBackConfirmButtonClicked));
			this.backWarningCancelButton.onClick.AddListener(delegate()
			{
				this.backWarningWindow.SetActive(false);
			});
			UIPanelHelper.AddTriggerListener(this.helpTip_foldIn, EventTriggerType.PointerClick, new CustomEventTrriger.TriggerAction(this.OnHelpTipsClicked));
			UIPanelHelper.AddTriggerListener(this.helpTip_foldOut, EventTriggerType.PointerClick, new CustomEventTrriger.TriggerAction(this.OnHelpTipsClicked));
		}

		private void InitLoadWindow(Dictionary<string, VoxelBuilderData> datas)
		{
			foreach (KeyValuePair<string, VoxelBuilderData> keyValuePair in datas)
			{
				this.AddMenuObj(keyValuePair.Key, keyValuePair.Value);
			}
		}

		private void InitColorPalette()
		{
			for (int i = 0; i < BuilderHelper.ColorConfig.Count; i++)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.colorCellPrefab, this.colorPaletteRoot).GetComponent<VoxcelEditPanelColorCell>().UpdateCell(this);
			}
			this.SetCurrentColor(0);
		}

		private void Update()
		{
			this.attachButton.image.color = this.editToolUnActiveColor;
			this.eraseButton.image.color = this.editToolUnActiveColor;
			this.paintButton.image.color = this.editToolUnActiveColor;
			switch (this.mgr.CurInputType)
			{
			case VoxelBuilderMgr.VoxelBuilderInputType.Attach:
				this.attachButton.image.color = this.editToolActiveColor;
				return;
			case VoxelBuilderMgr.VoxelBuilderInputType.Erase:
				this.eraseButton.image.color = this.editToolActiveColor;
				return;
			case VoxelBuilderMgr.VoxelBuilderInputType.Paint:
				this.paintButton.image.color = this.editToolActiveColor;
				return;
			default:
				return;
			}
		}

		public void AddMenuObj(string guidStr, VoxelBuilderData data)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.loadCellPrefab, this.loadCellRoot).GetComponent<VoxcelEditPanelLoadCell>().UpdateCell(guidStr, data);
		}

		public void SetCurrentColor(int index)
		{
			this.mgr.SetCurrentColorIndex(index);
			this.currentSelectColorImg.color = BuilderHelper.ColorConfig[index];
		}

		private void OnSaveButtonClicked()
		{
			if (BuilderMeshHelper.FaceCount <= 0)
			{
				this.TextWarningAnim("保存失败：未创造任何像素块！");
				return;
			}
			if (BuilderHelper.HasCurrentModelFile())
			{
				this.TextWarningAnim("保存失败：已存在一模一样的像素块模型！");
				return;
			}
			if (string.IsNullOrEmpty(this.fileNameInputFiled.text))
			{
				this.InputFiledWarningAnim();
				return;
			}
			KeyValuePair<string, VoxelBuilderData> keyValuePair = VoxelBuilderMgr.Instance.Save(this.fileNameInputFiled.text);
			this.AddMenuObj(keyValuePair.Key, keyValuePair.Value);
		}

		public void OnCellLoadButtonClicked(string guidStr)
		{
			VoxelBuilderData voxelBuilderData = this.mgr.Load(guidStr);
			this.loadMenuWindow.SetActive(false);
			this.fileNameInputFiled.text = voxelBuilderData.Name;
		}

		private void OnBackButtonClicked()
		{
			if (BuilderMeshHelper.FaceCount > 0)
			{
				this.backWarningWindow.SetActive(true);
				return;
			}
			this.OnBackConfirmButtonClicked();
		}

		private void OnBackConfirmButtonClicked()
		{
			UIController.LockLevel = UIController.UILevel.None;
			VoxelBuilderMgr.OnSceneEnterDone = false;
			GameController instance = GameController.getInstance();
			if (instance == null)
			{
				return;
			}
			instance.StartCoroutine(VoxelBuilderMgr.OnSceneExit(null));
		}

		private void OnHelpTipsClicked(PointerEventData eventData)
		{
			this.helpTip_foldIn.SetActive(!this.helpTip_foldIn.activeSelf);
			this.helpTip_foldOut.SetActive(!this.helpTip_foldOut.activeSelf);
		}

		private void InputFiledWarningAnim()
		{
			if (this.inputFiledWarningAnimSequence != null)
			{
				this.inputFiledWarningAnimSequence.Kill(true);
			}
			Vector2 size = this.inputFiledWarningFrameImg.rectTransform.rect.size;
			this.inputFiledWarningFrameImg.rectTransform.sizeDelta = size * 3f;
			this.inputFiledWarningFrameImg.color = new Color(1f, 0f, 0f, 1f);
			this.inputFiledWarningAnimSequence = DOTween.Sequence().Append(this.inputFiledWarningFrameImg.rectTransform.DOSizeDelta(size, 0.5f, false)).Join(this.inputFiledWarningFrameImg.DOFade(0f, 1.5f));
		}

		private void TextWarningAnim(string content)
		{
			if (this.textWarningAnimSequence != null)
			{
				this.textWarningAnimSequence.Kill(true);
			}
			this.warningText.color = Color.white;
			this.warningText.text = content;
			this.textWarningAnimSequence = DOTween.Sequence().Append(this.warningText.DOFade(1f, 0.5f)).Append(this.warningText.DOFade(0f, 1.5f));
		}

		public static VoxelEditPanel Instance;

		public VoxelBuilderMgr mgr;

		public Button menuButton;

		public Button saveButton;

		public Button backButton;

		public Button loadMenuButton;

		public Button clearButton;

		public Button attachButton;

		public Button eraseButton;

		public Button paintButton;

		public Button sameFileWarningConfirmButton;

		public Button sameFileWarningCancelButton;

		public Button loadWindowCloseButton;

		public Button backWarningConfirmButton;

		public Button backWarningCancelButton;

		public Toggle cardModeToggle;

		public TMP_InputField fileNameInputFiled;

		public TMP_Text warningText;

		public Image inputFiledWarningFrameImg;

		public Image currentSelectColorImg;

		public GameObject sameFileWarningWindow;

		public GameObject backWarningWindow;

		public GameObject loadMenuWindow;

		public GameObject helpTip_foldIn;

		public GameObject helpTip_foldOut;

		public Transform loadCellRoot;

		public Transform colorPaletteRoot;

		public Color editToolActiveColor;

		public Color editToolUnActiveColor;

		private Sequence inputFiledWarningAnimSequence;

		private Sequence textWarningAnimSequence;

		private GameObject loadCellPrefab;

		private GameObject colorCellPrefab;
	}
}
