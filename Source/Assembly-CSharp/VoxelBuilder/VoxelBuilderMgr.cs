using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VoxelBuilder
{
	public class VoxelBuilderMgr : MonoBehaviour
	{
		public VoxelBuilderMgr.VoxelBuilderInputType CurInputType
		{
			get
			{
				return this.curInputType;
			}
		}

		public Dictionary<string, VoxelBuilderData> DataDics
		{
			get
			{
				return VoxelBuilderMgr.dataDics;
			}
		}

		public Vector3Int EditLimit
		{
			get
			{
				return VoxelBuilderMgr.editLimit;
			}
		}

		private void Start()
		{
			VoxelBuilderMgr.Instance = this;
			BuilderMeshHelper.ClearData();
			this.Init();
		}

		private void Init()
		{
			this.curInputType = VoxelBuilderMgr.VoxelBuilderInputType.Attach;
			if (VoxelBuilderMgr.undoLst == null)
			{
				VoxelBuilderMgr.undoLst = new Stack<IVoxcelBuilderAction>();
			}
			else
			{
				VoxelBuilderMgr.undoLst.Clear();
			}
			if (VoxelBuilderMgr.redoLst == null)
			{
				VoxelBuilderMgr.redoLst = new Stack<IVoxcelBuilderAction>();
			}
			else
			{
				VoxelBuilderMgr.redoLst.Clear();
			}
			this.InitCubeRoot();
			this.InitIndicator();
		}

		private void InitCubeRoot()
		{
			if (this.cubeRoot == null)
			{
				this.cubeRoot = new GameObject("CubeRoot", new Type[]
				{
					typeof(MeshFilter),
					typeof(MeshRenderer),
					typeof(MeshCollider)
				}).transform;
				this.cubeRoot.position = Vector3.zero;
				this.cubeRoot.gameObject.layer = LayerMask.NameToLayer("VoxelEdit");
				this.cubeRootMeshFilter = this.cubeRoot.GetComponent<MeshFilter>();
				this.cubeMeshCollider = this.cubeRoot.GetComponent<MeshCollider>();
				Material material = new Material(Shader.Find(BuilderHelper.OutputToSceneShaderName));
				material.SetTexture("_MainTex", BuilderMeshHelper.CubeTexture);
				this.cubeRoot.GetComponent<MeshRenderer>().materials = new Material[]
				{
					material,
					this.cubeRootUsedWireFrameMat
				};
			}
		}

		private void InitIndicator()
		{
			GameObject original = Resources.Load<GameObject>("VoxelBuilder/VoxelBuilderIndicator_sprite");
			this.indicatorObj_sprite = UnityEngine.Object.Instantiate<GameObject>(original);
			this.HideInidcator(this.indicatorObj_sprite);
			original = Resources.Load<GameObject>("VoxelBuilder/VoxelBuilderIndicator_cube");
			this.indicatorObj_cube = UnityEngine.Object.Instantiate<GameObject>(original);
			this.HideInidcator(this.indicatorObj_cube);
			original = Resources.Load<GameObject>("VoxelBuilder/VoxelBuilderIndicator_startPoint");
			this.startPointObj = UnityEngine.Object.Instantiate<GameObject>(original);
			this.startPointObj.transform.GetChild(0).name = BuilderHelper.StartPointName;
		}

		private void Update()
		{
			if (!VoxelBuilderMgr.OnSceneEnterDone)
			{
				return;
			}
			if (VoxelBuilderMgr.IsReadMode)
			{
				this.HideInidcator(this.startPointObj);
				return;
			}
			this.UndoByShotkey();
			this.RedoByShotKey();
			this.ChangeInputTypeByHotkey();
			RaycastHit rayHitInfo = BuilderHelper.GetRayHitInfo("VoxelEdit");
			bool flag = false;
			if (rayHitInfo.collider != null && !BuilderHelper.IsHitUI())
			{
				flag = true;
			}
			if (flag)
			{
				Vector3 vector = BuilderHelper.HitPointToBuildPos(rayHitInfo);
				if (this.startPointObj.activeSelf)
				{
					this.UpdateCubeIndicatorPos(vector, rayHitInfo.normal);
				}
				else if (this.curInputType == VoxelBuilderMgr.VoxelBuilderInputType.Attach)
				{
					this.UpdateSpriteIndicatorPos(vector, rayHitInfo.normal);
				}
				else
				{
					this.UpdateCubeIndicatorPos(vector, rayHitInfo.normal);
				}
				if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.RightAlt))
				{
					IVoxcelBuilderAction voxcelBuilderAction = null;
					switch (this.curInputType)
					{
					case VoxelBuilderMgr.VoxelBuilderInputType.Attach:
					{
						Vector3 pos = (BuilderMeshHelper.FaceCount == 0) ? Vector3.zero : vector;
						if (!this.IsCardModeLimitPos(pos))
						{
							voxcelBuilderAction = new VoxelBuilderAction_Attach(this, pos, this.curSelectedColorIndex);
						}
						break;
					}
					case VoxelBuilderMgr.VoxelBuilderInputType.Erase:
						if (BuilderMeshHelper.FaceCount > 0)
						{
							voxcelBuilderAction = new VoxelBuilderAction_Erase(this, vector - rayHitInfo.normal, this.curSelectedColorIndex);
						}
						break;
					case VoxelBuilderMgr.VoxelBuilderInputType.Paint:
						if (BuilderMeshHelper.FaceCount > 0)
						{
							voxcelBuilderAction = new VoxelBuilderAction_Paint(this, vector - rayHitInfo.normal, this.curSelectedColorIndex);
						}
						break;
					}
					VoxelBuilderMgr.redoLst.Clear();
					if (voxcelBuilderAction != null)
					{
						voxcelBuilderAction.Execute();
					}
					if (voxcelBuilderAction != null)
					{
						VoxelBuilderMgr.undoLst.Push(voxcelBuilderAction);
						return;
					}
				}
			}
			else
			{
				if (this.startPointObj.activeSelf)
				{
					this.HideInidcator(this.indicatorObj_cube);
					return;
				}
				if (this.curInputType == VoxelBuilderMgr.VoxelBuilderInputType.Attach)
				{
					this.HideInidcator(this.indicatorObj_sprite);
					return;
				}
				this.HideInidcator(this.indicatorObj_cube);
			}
		}

		private void ChangeInputTypeByHotkey()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				this.ChangeInputType(VoxelBuilderMgr.VoxelBuilderInputType.Attach);
				return;
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				this.ChangeInputType(VoxelBuilderMgr.VoxelBuilderInputType.Paint);
				return;
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				this.ChangeInputType(VoxelBuilderMgr.VoxelBuilderInputType.Erase);
			}
		}

		private void UndoByShotkey()
		{
			if (Input.GetKeyDown(KeyCode.Z))
			{
				if (VoxelBuilderMgr.undoLst.Count <= 0)
				{
					return;
				}
				IVoxcelBuilderAction voxcelBuilderAction = VoxelBuilderMgr.undoLst.Pop();
				voxcelBuilderAction.Undo();
				VoxelBuilderMgr.redoLst.Push(voxcelBuilderAction);
			}
		}

		private void RedoByShotKey()
		{
			if (Input.GetKeyDown(KeyCode.X))
			{
				if (VoxelBuilderMgr.redoLst.Count <= 0)
				{
					return;
				}
				IVoxcelBuilderAction voxcelBuilderAction = VoxelBuilderMgr.redoLst.Pop();
				voxcelBuilderAction.Redo();
				VoxelBuilderMgr.undoLst.Push(voxcelBuilderAction);
			}
		}

		public void ChangeInputType(VoxelBuilderMgr.VoxelBuilderInputType type)
		{
			this.curInputType = type;
			if (type == VoxelBuilderMgr.VoxelBuilderInputType.Attach)
			{
				this.HideInidcator(this.indicatorObj_cube);
				return;
			}
			if (type - VoxelBuilderMgr.VoxelBuilderInputType.Erase > 1)
			{
				return;
			}
			this.HideInidcator(this.indicatorObj_sprite);
		}

		private void UpdateSpriteIndicatorPos(Vector3 buildPos, Vector3 hitNormal)
		{
			if (hitNormal == Vector3.forward || hitNormal == Vector3.back)
			{
				this.indicatorObj_sprite.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			}
			else if (hitNormal == Vector3.right || hitNormal == Vector3.left)
			{
				this.indicatorObj_sprite.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			}
			else if (hitNormal == Vector3.up || hitNormal == Vector3.down)
			{
				this.indicatorObj_sprite.transform.eulerAngles = new Vector3(90f, 0f, 0f);
			}
			this.indicatorObj_sprite.transform.position = buildPos - hitNormal * 0.45f;
		}

		private void UpdateCubeIndicatorPos(Vector3 buildPos, Vector3 hitNormal)
		{
			if (BuilderMeshHelper.FaceCount <= 0)
			{
				this.indicatorObj_cube.transform.position = Vector3.zero;
				return;
			}
			this.indicatorObj_cube.transform.position = buildPos - hitNormal;
		}

		private void HideInidcator(GameObject obj)
		{
			obj.transform.position = new Vector3(-999f, -999f, -999f);
		}

		public void SetCurrentColorIndex(int index)
		{
			this.curSelectedColorIndex = index;
		}

		public VoxelBuilderData Load(string guidStr)
		{
			this.Clear();
			VoxelBuilderData voxelBuilderData = VoxelBuilderMgr.dataDics[guidStr];
			this.LoadModel(voxelBuilderData.StringToMeshData());
			return voxelBuilderData;
		}

		public void LoadModel(Dictionary<Vector3, int> meshDatas)
		{
			BuilderMeshHelper.BuildCube(BuilderMeshHelper.CubeOperateOption.Add, meshDatas, ref this.cubeRootMeshFilter);
			this.cubeMeshCollider.sharedMesh = this.cubeRootMeshFilter.mesh;
			this.ShowStartIndicatorCube(false);
		}

		public KeyValuePair<string, VoxelBuilderData> Save(string fileName)
		{
			KeyValuePair<string, VoxelBuilderData> result = BuilderHelper.SaveFile(fileName, VoxelBuilderMgr.curSelectedType, BuilderMeshHelper.MeshDatas);
			VoxelBuilderMgr.dataDics.Add(result.Key, result.Value);
			GameController instance = GameController.getInstance();
			if (instance != null)
			{
				instance.StartCoroutine(VoxelBuilderMgr.OnSceneExit(result.Key));
			}
			return result;
		}

		public void Clear()
		{
			this.panel.fileNameInputFiled.text = null;
			VoxelBuilderMgr.undoLst.Clear();
			VoxelBuilderMgr.redoLst.Clear();
			BuilderMeshHelper.ClearData();
			this.cubeMeshCollider.sharedMesh = (this.cubeRootMeshFilter.mesh = null);
			this.ShowStartIndicatorCube(true);
		}

		public void ShowStartIndicatorCube(bool active)
		{
			if (!active && this.startPointObj.activeSelf && BuilderMeshHelper.FaceCount > 0)
			{
				this.startPointObj.SetActive(false);
				this.HideInidcator(this.indicatorObj_cube);
				return;
			}
			if (active && !this.startPointObj.activeSelf && BuilderMeshHelper.FaceCount <= 0)
			{
				this.startPointObj.SetActive(true);
			}
		}

		public void AddCube(Vector3 pos, int colorIndex)
		{
			BuilderMeshHelper.BuildCube(BuilderMeshHelper.CubeOperateOption.Add, pos, colorIndex, ref this.cubeRootMeshFilter);
			this.cubeMeshCollider.sharedMesh = this.cubeRootMeshFilter.mesh;
		}

		public void RemoveCube(Vector3 pos)
		{
			BuilderMeshHelper.BuildCube(BuilderMeshHelper.CubeOperateOption.Remove, pos, 0, ref this.cubeRootMeshFilter);
			this.cubeMeshCollider.sharedMesh = this.cubeRootMeshFilter.mesh;
		}

		public void ChangeColor(Vector3 pos, int colorIndex)
		{
			BuilderMeshHelper.BuildCube(BuilderMeshHelper.CubeOperateOption.ChangeColor, pos, colorIndex, ref this.cubeRootMeshFilter);
		}

		private bool IsCardModeLimitPos(Vector3 pos)
		{
			return Mathf.Abs(pos.x) > (float)((VoxelBuilderMgr.editLimit.x - 1) / 2) || Mathf.Abs(pos.z) > (float)((VoxelBuilderMgr.editLimit.z - 1) / 2) || Mathf.Abs(pos.y) < 0f || Mathf.Abs(pos.y) > (float)((VoxelBuilderMgr.editLimit.y - 1) / 2);
		}

		public bool IsCardMatch()
		{
			return VoxelBuilderMgr.curReadModeTypes.Contains(VoxelBuilderType.BigPic) || VoxelBuilderMgr.curReadModeTypes.Contains(VoxelBuilderType.SmallPic);
		}

		public static IEnumerator OnSceneExit(string fileName)
		{
			yield return SceneManager.UnloadSceneAsync("VoxelEdit");
			VoxelBuilderMgr.CallBackFunc(fileName);
			VoxelBuilderMgr.OnSceneEnterDone = false;
			yield break;
		}

		public static void LoadVoxelBuilder(Action<string> callBack)
		{
			VoxelBuilderMgr.CallBackFunc = callBack;
			SceneManager.LoadScene("VoxelEdit", LoadSceneMode.Additive);
		}

		public static IEnumerator OnSceneEnter(VoxelBuilderType type)
		{
			while (VoxelBuilderMgr.Instance == null)
			{
				yield return null;
			}
			while (VoxelBuilderMgr.Instance.panel == null)
			{
				yield return null;
			}
			VoxelBuilderMgr.curSelectedType = type;
			VoxelBuilderMgr.dataDics.Clear();
			foreach (KeyValuePair<string, VoxelBuilderData> keyValuePair in BuilderHelper.LoadAllFiles())
			{
				string key = keyValuePair.Key;
				VoxelBuilderData value = keyValuePair.Value;
				if (value.Type == VoxelBuilderMgr.curSelectedType)
				{
					VoxelBuilderMgr.dataDics.Add(key, value);
				}
			}
			VoxelBuilderMgr.editLimit = BuilderConstant.GetSize(type);
			VoxelBuilderMgr.IsReadMode = false;
			VoxelBuilderMgr.OnSceneEnterDone = true;
			yield break;
		}

		public static IEnumerator OnSceneEnterToPlayTheGame(params VoxelBuilderType[] types)
		{
			while (VoxelBuilderMgr.Instance == null)
			{
				yield return null;
			}
			while (VoxelBuilderMgr.Instance.panel == null)
			{
				yield return null;
			}
			VoxelBuilderMgr.curReadModeTypes = types;
			VoxelBuilderMgr.IsReadMode = true;
			VoxelBuilderMgr.OnSceneEnterDone = true;
			yield break;
		}

		public static VoxelBuilderMgr Instance;

		public VoxelEditPanel panel;

		public Material cubeRootUsedWireFrameMat;

		public Material glMat;

		public static bool OnSceneEnterDone = false;

		public static bool IsReadMode = false;

		private static Stack<IVoxcelBuilderAction> undoLst;

		private static Stack<IVoxcelBuilderAction> redoLst;

		private static Vector3Int editLimit;

		private static VoxelBuilderType curSelectedType;

		private GameObject indicatorObj_sprite;

		private GameObject indicatorObj_cube;

		private GameObject indicatorObj_startPoint;

		private GameObject startPointObj;

		private Transform cubeRoot;

		private MeshFilter cubeRootMeshFilter;

		private MeshCollider cubeMeshCollider;

		private VoxelBuilderMgr.VoxelBuilderInputType curInputType;

		private int curSelectedColorIndex;

		private bool isSetCardModeRange;

		private static Dictionary<string, VoxelBuilderData> dataDics = new Dictionary<string, VoxelBuilderData>();

		public static VoxelBuilderType[] curReadModeTypes;

		private AsyncOperation unLoadProcesss;

		public static Action<string> CallBackFunc;

		public enum VoxelBuilderInputType
		{
			Attach,
			Erase,
			Paint
		}
	}
}
