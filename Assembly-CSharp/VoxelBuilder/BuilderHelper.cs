using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VoxelBuilder
{
	public static class BuilderHelper
	{
		public static List<Color> ColorConfig
		{
			get
			{
				if (BuilderHelper.colorConfig == null)
				{
					BuilderHelper.colorConfig = new List<Color>();
					BuilderHelper.LoadColorPaletteConfig();
				}
				return BuilderHelper.colorConfig;
			}
		}

		public static RaycastHit GetRayHitInfo(string maskName)
		{
			if (BuilderHelper.mainCamera == null)
			{
				BuilderHelper.mainCamera = Camera.main;
			}
			RaycastHit result;
			Physics.Raycast(BuilderHelper.mainCamera.ScreenPointToRay(Input.mousePosition), out result, float.PositiveInfinity, 1 << LayerMask.NameToLayer(maskName));
			return result;
		}

		public static Vector3 HitPointToBuildPos(RaycastHit hitInfo)
		{
			Vector3 normalized = hitInfo.normal.normalized;
			Vector3 point = hitInfo.point;
			Vector3 vector = normalized * 0.5f + point;
			int num = Mathf.FloorToInt(vector.x + 0.5f);
			int num2 = Mathf.FloorToInt(vector.y + 0.5f);
			int num3 = Mathf.FloorToInt(vector.z + 0.5f);
			return new Vector3((float)num, (float)num2, (float)num3);
		}

		public static bool IsHitUI()
		{
			return BuilderHelper.UIRayCastFrom("UI").Count > 0;
		}

		private static List<RaycastResult> UIRayCastFrom(string maskName)
		{
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.position = Input.mousePosition;
			List<RaycastResult> list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData, list);
			return list;
		}

		public static void LoadColorPaletteConfig()
		{
			if (!File.Exists(BuilderHelper.ColorPaletteConfigPath))
			{
				throw new Exception(BuilderHelper.ColorPaletteConfigPath + "文件丢失！");
			}
			FileStream fileStream = new FileStream(BuilderHelper.ColorPaletteConfigPath, FileMode.Open, FileAccess.Read);
			StreamReader streamReader = new StreamReader(fileStream);
			string text = streamReader.ReadLine();
			while (!string.IsNullOrEmpty(text))
			{
				string[] array = text.Split(new char[]
				{
					','
				});
				BuilderHelper.colorConfig.Add(new Color((float)int.Parse(array[0]) / 255f, (float)int.Parse(array[1]) / 255f, (float)int.Parse(array[2]) / 255f));
				text = streamReader.ReadLine();
			}
			streamReader.Close();
			fileStream.Close();
			streamReader.Dispose();
			fileStream.Dispose();
		}

		private static void InitDirector()
		{
			if (!Directory.Exists(BuilderHelper.DirectoryPath))
			{
				Directory.CreateDirectory(BuilderHelper.DirectoryPath);
			}
		}

		public static bool HasCurrentModelFile()
		{
			return BuilderHelper.HasFile(BuilderHelper.MeshDataStringToMd5(BuilderHelper.MeshDataToTxt(BuilderMeshHelper.MeshDatas)));
		}

		public static bool HasFile(string guidStr)
		{
			BuilderHelper.InitDirector();
			return File.Exists(BuilderHelper.GetJsonFilePath(guidStr));
		}

		public static KeyValuePair<string, VoxelBuilderData> SaveFile(string fileName, VoxelBuilderType type, Dictionary<Vector3, int> meshDatas)
		{
			string text = BuilderHelper.MeshDataToTxt(meshDatas);
			string text2 = BuilderHelper.MeshDataStringToMd5(text);
			if (BuilderHelper.HasFile(text2))
			{
				throw new Exception("Has Same File! GUID:" + text2);
			}
			string screenShotStr = BuilderHelper.CameraCapture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height)).ToBase64StringByPng();
			VoxelBuilderData value = new VoxelBuilderData(fileName, type, text, screenShotStr);
			using (FileStream fileStream = new FileStream(BuilderHelper.GetJsonFilePath(text2), FileMode.OpenOrCreate, FileAccess.Write))
			{
				using (StreamWriter streamWriter = new StreamWriter(fileStream))
				{
					JsonSerializer jsonSerializer = new JsonSerializer();
					jsonSerializer.NullValueHandling = NullValueHandling.Include;
					JsonWriter jsonWriter = new JsonTextWriter(streamWriter)
					{
						Formatting = Formatting.Indented,
						Indentation = 4,
						IndentChar = ' '
					};
					jsonSerializer.Serialize(jsonWriter, value);
					jsonWriter.Close();
					streamWriter.Close();
				}
				fileStream.Close();
			}
			return new KeyValuePair<string, VoxelBuilderData>(text2, value);
		}

		public static void SaveFile(string fileName, VoxelBuilderType type, string modelStr, string screenShotStr)
		{
			string guidStr = BuilderHelper.MeshDataStringToMd5(modelStr);
			if (BuilderHelper.HasFile(guidStr))
			{
				Debug.Log("Has Same File! Do not need to create new file");
				return;
			}
			VoxelBuilderData value = new VoxelBuilderData(fileName, type, modelStr, screenShotStr);
			using (FileStream fileStream = new FileStream(BuilderHelper.GetJsonFilePath(guidStr), FileMode.OpenOrCreate, FileAccess.Write))
			{
				using (StreamWriter streamWriter = new StreamWriter(fileStream))
				{
					JsonSerializer jsonSerializer = new JsonSerializer();
					jsonSerializer.NullValueHandling = NullValueHandling.Include;
					JsonWriter jsonWriter = new JsonTextWriter(streamWriter)
					{
						Formatting = Formatting.Indented,
						Indentation = 4,
						IndentChar = ' '
					};
					jsonSerializer.Serialize(jsonWriter, value);
					jsonWriter.Close();
					streamWriter.Close();
				}
				fileStream.Close();
			}
		}

		public static VoxelBuilderData LoadFile(string guidStr)
		{
			if (!BuilderHelper.HasFile(guidStr))
			{
				throw new Exception("Can not find file! GUID:" + guidStr);
			}
			VoxelBuilderData result;
			using (FileStream fileStream = new FileStream(BuilderHelper.GetJsonFilePath(guidStr), FileMode.Open, FileAccess.Read))
			{
				using (StreamReader streamReader = new StreamReader(fileStream))
				{
					string value = streamReader.ReadToEnd();
					streamReader.Close();
					fileStream.Close();
					result = JsonConvert.DeserializeObject<VoxelBuilderData>(value);
				}
			}
			return result;
		}

		public static Dictionary<string, VoxelBuilderData> LoadAllFiles()
		{
			Dictionary<string, VoxelBuilderData> dictionary = new Dictionary<string, VoxelBuilderData>();
			BuilderHelper.InitDirector();
			foreach (FileInfo fileInfo in new DirectoryInfo(BuilderHelper.DirectoryPath).GetFiles("*.json"))
			{
				using (StreamReader streamReader = fileInfo.OpenText())
				{
					string value = streamReader.ReadToEnd();
					dictionary.Add(fileInfo.JustName(), JsonConvert.DeserializeObject<VoxelBuilderData>(value));
					streamReader.Close();
				}
			}
			return dictionary;
		}

		public static Dictionary<string, VoxelBuilderData> LoadAllFiles(params VoxelBuilderType[] types)
		{
			Dictionary<string, VoxelBuilderData> dictionary = new Dictionary<string, VoxelBuilderData>();
			BuilderHelper.InitDirector();
			foreach (FileInfo fileInfo in new DirectoryInfo(BuilderHelper.DirectoryPath).GetFiles("*.json"))
			{
				using (StreamReader streamReader = fileInfo.OpenText())
				{
					string value = streamReader.ReadToEnd();
					VoxelBuilderData voxelBuilderData = JsonConvert.DeserializeObject<VoxelBuilderData>(value);
					if (types.Contains(voxelBuilderData.Type))
					{
						dictionary.Add(fileInfo.JustName(), JsonConvert.DeserializeObject<VoxelBuilderData>(value));
					}
					streamReader.Close();
				}
			}
			return dictionary;
		}

		public static void DeleteFile(string guidStr)
		{
			File.Delete(BuilderHelper.GetJsonFilePath(guidStr));
		}

		private static string GetJsonFilePath(string guidStr)
		{
			return BuilderHelper.DirectoryPath + "/" + guidStr + ".Json";
		}

		private static Texture2D CameraCapture(Rect rect)
		{
			VoxelBuilderCamera.isShowLines = false;
			if (BuilderHelper.mainCamera == null)
			{
				BuilderHelper.mainCamera = Camera.main;
			}
			RenderTexture renderTexture = new RenderTexture((int)rect.height, (int)rect.height, 0);
			BuilderHelper.mainCamera.targetTexture = renderTexture;
			BuilderHelper.mainCamera.Render();
			RenderTexture.active = renderTexture;
			Texture2D texture2D = new Texture2D((int)rect.height, (int)rect.height, TextureFormat.RGB24, false);
			texture2D.ReadPixels(rect, 0, 0);
			texture2D.Apply();
			Texture2D result = TextureScaler.Bilinear(texture2D, 128, 128, false, false);
			BuilderHelper.mainCamera.targetTexture = null;
			RenderTexture.active = null;
			UnityEngine.Object.Destroy(renderTexture);
			VoxelBuilderCamera.isShowLines = true;
			return result;
		}

		public static GameObject LoadThenConvertToGameObject(string fileName)
		{
			VoxelBuilderData voxelBuilderData = BuilderHelper.LoadFile(fileName);
			BuilderMeshHelper.ClearData();
			GameObject gameObject = new GameObject("CustomModel_" + voxelBuilderData.Name);
			MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
			Renderer renderer = gameObject.AddComponent<MeshRenderer>();
			BuilderMeshHelper.BuildCube(BuilderMeshHelper.CubeOperateOption.Add, voxelBuilderData.StringToMeshData(), ref meshFilter);
			Material material = new Material(Shader.Find(BuilderHelper.OutputToSceneShaderName));
			material.SetTexture("_MainTex", BuilderMeshHelper.CubeTexture);
			renderer.material = material;
			gameObject.AddComponent<BoxCollider>();
			return gameObject;
		}

		private static string MeshDataToTxt(Dictionary<Vector3, int> datas)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<Vector3, int> keyValuePair in datas)
			{
				stringBuilder.Append(BuilderHelper.MeshDataToString(keyValuePair.Key.V3ToIntV3(), keyValuePair.Value));
				stringBuilder.Append("$");
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			return stringBuilder.ToString();
		}

		private static string MeshDataToString(Vector3Int pos, int colorIndex)
		{
			return string.Format("{0}:{1}_{2}_{3}", new object[]
			{
				colorIndex,
				pos.x,
				pos.y,
				pos.z
			});
		}

		public static VoxelBuilderCardData StringToCardData(string cardMessage)
		{
			return JsonConvert.DeserializeObject<VoxelBuilderCardData>(cardMessage);
		}

		public static string ToCardDataString(VoxelBuilderData data)
		{
			return JsonConvert.SerializeObject(new VoxelBuilderCardData(data.Name, data.Type));
		}

		public static Dictionary<Vector3, int> StringToMeshData(this VoxelBuilderData data)
		{
			return BuilderHelper.StringToMeshData(data.ModelStr);
		}

		public static Dictionary<Vector3, int> StringToMeshData(string modelStr)
		{
			Dictionary<Vector3, int> dictionary = new Dictionary<Vector3, int>();
			string[] array = modelStr.Split(new char[]
			{
				'$'
			});
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					':'
				});
				dictionary.Add(BuilderHelper.PosStringToV3(array2[1]), int.Parse(array2[0]));
			}
			return dictionary;
		}

		public static Texture2D StringToTexture2D(this VoxelBuilderData data)
		{
			return BuilderHelper.Base64StringToTexture2D(data.ScreenShotStr);
		}

		public static Texture2D Base64StringToTexture2D(string base64Str)
		{
			byte[] data = Convert.FromBase64String(base64Str);
			Texture2D texture2D = new Texture2D(128, 128);
			texture2D.LoadImage(data);
			return texture2D;
		}

		private static Vector3 PosStringToV3(string value)
		{
			string[] array = value.Split(new char[]
			{
				'_'
			});
			return new Vector3((float)int.Parse(array[0]), (float)int.Parse(array[1]), (float)int.Parse(array[2]));
		}

		private static string ToBase64StringByPng(this Texture2D texture)
		{
			return Convert.ToBase64String(texture.EncodeToPNG());
		}

		private static string MeshDataStringToMd5(string meshDataStr)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				byte[] bytes = Encoding.Default.GetBytes(meshDataStr);
				byte[] array = md.ComputeHash(bytes);
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.Append(array[i].ToString("x2"));
				}
				result = stringBuilder.ToString();
			}
			return result;
		}

		public static Vector3Int V3ToIntV3(this Vector3 value)
		{
			return new Vector3Int(Mathf.RoundToInt(value.x), Mathf.RoundToInt(value.y), Mathf.RoundToInt(value.z));
		}

		public static List<Transform> GetChilds(this Transform value)
		{
			List<Transform> list = new List<Transform>();
			foreach (object obj in value)
			{
				Transform item = (Transform)obj;
				list.Add(item);
			}
			return list;
		}

		public static string JustName(this FileInfo info)
		{
			return info.Name.Remove(info.Name.LastIndexOf('.'));
		}

		private static readonly string DataPicturePostfix = ".png";

		private static readonly string DataFilePostfix = ".txt";

		private static readonly string DirectoryPath = Application.streamingAssetsPath + "/VoxcelEditFiles";

		private static readonly string ColorPaletteConfigPath = Application.streamingAssetsPath + "/Init/VoxcelBuilder/nesColor.txt";

		public static readonly string OutputToSceneShaderName = "Toony Colors Pro 2/Standard PBS";

		public static readonly string StartPointName = "StartPoint";

		private static Camera mainCamera;

		private static List<Color> colorConfig;
	}
}
