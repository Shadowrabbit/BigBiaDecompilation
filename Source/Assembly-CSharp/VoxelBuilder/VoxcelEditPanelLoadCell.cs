using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VoxelBuilder
{
	public class VoxcelEditPanelLoadCell : MonoBehaviour
	{
		private void Start()
		{
			this.loadButton.onClick.AddListener(new UnityAction(this.OnLoadButtonClicked));
			this.deleteButton.onClick.AddListener(new UnityAction(this.OnDeleteButtonClicked));
		}

		public void UpdateCell(string guidStr, VoxelBuilderData data)
		{
			this.guidStr = guidStr;
			this.txt.text = data.Name;
			Texture2D texture2D = data.StringToTexture2D();
			this.img.sprite = Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), Vector2.one * 0.5f);
		}

		private void OnDeleteButtonClicked()
		{
			VoxelBuilderMgr.Instance.DataDics.Remove(this.guidStr);
			BuilderHelper.DeleteFile(this.guidStr);
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private void OnLoadButtonClicked()
		{
			VoxelEditPanel.Instance.OnCellLoadButtonClicked(this.guidStr);
		}

		public Button deleteButton;

		public Button loadButton;

		public Image img;

		public TextMeshProUGUI txt;

		private string guidStr;
	}
}
