using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VoxelBuilder
{
	public class VoxelReadPanelSelfWorksWindow : MonoBehaviour
	{
		private void Start()
		{
			this.closeButton.onClick.AddListener(delegate()
			{
				base.gameObject.SetActive(false);
			});
		}

		public void UpdateWindow()
		{
			if (this.isUpdated)
			{
				return;
			}
			Dictionary<string, VoxelBuilderData> dictionary = BuilderHelper.LoadAllFiles(VoxelBuilderMgr.curReadModeTypes);
			if (this.cellPrefab == null)
			{
				this.cellPrefab = Resources.Load<GameObject>("VoxelBuilder/VoxcelReadPanelSelfWorksCell");
			}
			foreach (KeyValuePair<string, VoxelBuilderData> keyValuePair in dictionary)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.cellPrefab, this.cellRoot).GetComponent<VoxelReadPanelSelfWorkWindowCell>().UpdateCell(keyValuePair.Key, keyValuePair.Value);
			}
			this.isUpdated = true;
		}

		public Transform cellRoot;

		public Button closeButton;

		private GameObject cellPrefab;

		private bool isUpdated;
	}
}
