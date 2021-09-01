using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace VoxelBuilder
{
	public class VoxelReadPanelSelfWorkWindowCell : MonoBehaviour
	{
		private void Start()
		{
			this.selectButton.onClick.AddListener(new UnityAction(this.OnSelectButtonClicked));
		}

		public void UpdateCell(string md5Str, VoxelBuilderData data)
		{
			this.md5Str = md5Str;
			this.data = data;
			this.nameTxt.text = data.Name;
			Texture2D texture2D = data.StringToTexture2D();
			this.screenShotImg.sprite = Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), Vector2.one * 0.5f);
		}

		private void OnSelectButtonClicked()
		{
			if (VoxelReadPanel.Instance.HasSameModel(this.md5Str))
			{
				VoxelReadPanel.Instance.TextWarningAnim("选择失败！已存在 相同像素块 结构的作品！");
				return;
			}
			VoxelReadPanel.Instance.TextWarningAnim("作品上传中......");
			VoxelReadPanel.Instance.OnSelfWorkUploaded();
			VoxelReadPanel.Instance.StartCoroutine(this.Upload());
		}

		private IEnumerator Upload()
		{
			WWWForm wwwform = new WWWForm();
			wwwform.AddField("guid", this.md5Str);
			wwwform.AddField("snapshot", this.data.ScreenShotStr);
			wwwform.AddField("pixelContent", this.data.ModelStr);
			wwwform.AddField("cardModel", "4");
			wwwform.AddField("cardMessage", BuilderHelper.ToCardDataString(this.data));
			wwwform.AddField("steamID", SteamConstant.GetUserID().ToString());
			wwwform.AddField("status", (this.data.Type == VoxelBuilderType.SmallStatue || this.data.Type == VoxelBuilderType.BigStatue).ToString());
			string uri = "http://59.110.49.146/PixelMatch/pixelAction_upload";
			using (UnityWebRequest request = UnityWebRequest.Post(uri, wwwform))
			{
				yield return request.SendWebRequest();
				VoxelReadPanel.Instance.TextWarningAnim("上传成功！");
				VoxelReadPanel.Instance.readWindow.UpdateWorksInfo();
				if (request.isNetworkError || request.isHttpError)
				{
					Debug.Log(request.error);
				}
				else
				{
					Debug.Log(request.downloadHandler.text);
				}
			}
			UnityWebRequest request = null;
			yield break;
			yield break;
		}

		public Button selectButton;

		public TMP_Text nameTxt;

		public Image screenShotImg;

		private VoxelBuilderData data;

		private string md5Str;
	}
}
