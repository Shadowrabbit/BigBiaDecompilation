using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VoxelBuilder
{
	public class VoxelReadPanelLoadWindow : MonoBehaviour
	{
		private void Start()
		{
			this.backButton.onClick.AddListener(delegate()
			{
				SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main"));
				VoxelReadPanel.Instance.oaccController.CheckOut();
				UIController.LockLevel = UIController.UILevel.None;
				VoxelBuilderMgr.OnSceneEnterDone = false;
				GameController instance = GameController.getInstance();
				if (instance == null)
				{
					return;
				}
				instance.StartCoroutine(VoxelBuilderMgr.OnSceneExit(null));
			});
			this.joinButton.onClick.AddListener(delegate()
			{
				VoxelReadPanel.Instance.selfWorksWindow.gameObject.SetActive(true);
				VoxelReadPanel.Instance.selfWorksWindow.UpdateWindow();
			});
			this.refreshButton.onClick.AddListener(new UnityAction(this.UpdateWorksInfo));
		}

		public void UpdateWorksInfo()
		{
			this.joinButton.interactable = false;
			base.StartCoroutine(this.queryAll());
		}

		public void ShowSelfWorkInfo(string name, int count, int rank)
		{
			this.joinButton.gameObject.SetActive(false);
			this.selfWorkName.gameObject.SetActive(true);
			this.selfCount.gameObject.SetActive(true);
			this.selfRank.gameObject.SetActive(true);
			this.selfWorkName.text = "参赛作品：" + name;
			this.selfCount.text = "投票数：" + count.ToString();
			this.selfRank.text = "当前排名：" + rank.ToString();
		}

		public bool HasSameModel(string md5Str)
		{
			return this.OnServerMd5s.Contains(md5Str);
		}

		private IEnumerator queryAll()
		{
			WWWForm wwwform = new WWWForm();
			wwwform.AddField("status", (!VoxelBuilderMgr.Instance.IsCardMatch()).ToString());
			wwwform.AddField("steamID", SteamConstant.GetUserID().ToString());
			string uri = "http://59.110.49.146/PixelMatch/pixelAction_queryAll";
			using (UnityWebRequest request = UnityWebRequest.Post(uri, wwwform))
			{
				this.refreshButtonTxt.text = "正在连接服务器";
				this.refreshButton.interactable = false;
				request.timeout = 5;
				yield return request.SendWebRequest();
				if (request.isNetworkError || request.isHttpError)
				{
					VoxelReadPanel.Instance.TextWarningAnim("连接超时");
					Debug.Log(request.error);
				}
				else
				{
					List<MatchItem> list = JsonConvert.DeserializeObject<List<MatchItem>>(request.downloadHandler.text);
					if (list == null)
					{
						list = new List<MatchItem>();
					}
					if (this.loadCellPrefab == null)
					{
						this.loadCellPrefab = Resources.Load<GameObject>("VoxelBuilder/VoxcelReadPanelCell");
					}
					UIPanelHelper.CellUpdatePoor<MatchItem>(list, this.cellRoot, this.loadCellPrefab, new Action<GameObject, MatchItem>(this.OnCellUpdated));
					this.joinButton.interactable = true;
				}
				this.refreshButtonTxt.text = "刷新服务器";
				this.refreshButton.interactable = true;
			}
			UnityWebRequest request = null;
			yield break;
			yield break;
		}

		private void OnCellUpdated(GameObject obj, MatchItem data)
		{
			this.OnServerMd5s.Add(data.guid);
			obj.GetComponent<VoxelReadPanelLoadWindowCell>().UpdateCell(data);
			if (data.steamID == SteamConstant.GetUserID())
			{
				this.ShowSelfWorkInfo(data.cardMessage.Name, data.voteUp, this.OnServerMd5s.IndexOf(data.guid) + 1);
			}
		}

		public TMP_Text selfWorkName;

		public TMP_Text selfCount;

		public TMP_Text selfRank;

		public TMP_Text refreshButtonTxt;

		public Button joinButton;

		public Button backButton;

		public Button refreshButton;

		public Transform cellRoot;

		private GameObject loadCellPrefab;

		private List<string> OnServerMd5s = new List<string>();
	}
}
