using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VoxelBuilder
{
	public class VoxcelEditPanelColorCell : MonoBehaviour
	{
		public void Start()
		{
			this.button.onClick.AddListener(new UnityAction(this.OnCellClicked));
		}

		private void OnCellClicked()
		{
			this.panel.SetCurrentColor(base.transform.GetSiblingIndex());
		}

		public void UpdateCell(VoxelEditPanel panel)
		{
			this.panel = panel;
			this.img.color = BuilderHelper.ColorConfig[base.transform.GetSiblingIndex()];
		}

		public Image img;

		public Button button;

		private VoxelEditPanel panel;
	}
}
