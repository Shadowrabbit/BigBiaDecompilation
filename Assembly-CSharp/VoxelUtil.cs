using System;
using System.IO;
using UnityEngine;
using VoxelImporter;

public class VoxelUtil : MonoBehaviour
{
	private void Awake()
	{
		VoxelUtil.Instance = this;
		this.baseCore = new MyVoxelObjectCore(null);
	}

	private void Start()
	{
	}

	public GameObject CreatePngVoxel(byte[] pngData, string name = "Voxel")
	{
		if (pngData == null || pngData.Length == 0)
		{
			return new GameObject(name);
		}
		GameObject gameObject = new GameObject(name);
		gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();
		VoxelObject voxelObject = gameObject.AddComponent<VoxelObject>();
		int num = (int)pngData[18] * 256 + (int)pngData[19];
		int num2 = (int)pngData[22] * 256 + (int)pngData[23];
		float d;
		if (num >= num2)
		{
			d = 16f / (float)num;
		}
		else
		{
			d = 16f / (float)num2;
		}
		voxelObject.importScale = this.defaultScale * d;
		this.baseCore.voxelObject = voxelObject;
		this.baseCore.voxelBase = voxelObject;
		this.baseCore.Create(pngData);
		gameObject.transform.position = Vector3.zero;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = Vector3.one;
		return gameObject;
	}

	public GameObject CreateCardModelOfThreeLayers(string name, string pngName)
	{
		GameObject gameObject = new GameObject(name);
		if (GameController.ins.PNGResourceCache.ContainsKey(pngName) && GameController.ins.PNGResourceCache[pngName] != null)
		{
			GameObject gameObject2 = this.CreatePngVoxel(GameController.ins.PNGResourceCache[pngName], "Voxel");
			gameObject2.transform.Translate(new Vector3(0f, 0.0625f, 0f));
			gameObject2.transform.SetParent(gameObject.transform);
		}
		string key = pngName + "_1";
		if (GameController.ins.PNGResourceCache.ContainsKey(key))
		{
			byte[] array = GameController.ins.PNGResourceCache[key];
			if (array != null)
			{
				GameObject gameObject3 = this.CreatePngVoxel(array, "Voxel");
				gameObject3.transform.Translate(new Vector3(0f, 0.125f, 0f));
				gameObject3.transform.SetParent(gameObject.transform);
			}
		}
		string key2 = pngName + "_2";
		if (GameController.ins.PNGResourceCache.ContainsKey(key2))
		{
			byte[] array2 = GameController.ins.PNGResourceCache[key2];
			if (array2 != null)
			{
				GameObject gameObject4 = this.CreatePngVoxel(array2, "Voxel");
				gameObject4.transform.Translate(new Vector3(0f, 0.1875f, 0f));
				gameObject4.transform.SetParent(gameObject.transform);
			}
		}
		return gameObject;
	}

	private void Update()
	{
	}

	private byte[] LoadTextureByIO(string path)
	{
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		fileStream.Seek(0L, SeekOrigin.Begin);
		byte[] array = new byte[fileStream.Length];
		try
		{
			fileStream.Read(array, 0, array.Length);
		}
		catch (Exception message)
		{
			Debug.Log(message);
		}
		fileStream.Close();
		return array;
	}

	public static VoxelUtil Instance;

	public Vector3 defaultScale = new Vector3(0.06f, 0.06f, 0.06f);

	public Vector3 defaultRotation = new Vector3(90f, 0f, 0f);

	private MyVoxelObjectCore baseCore;
}
