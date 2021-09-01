using System;
using System.Collections.Generic;
using PixelGame;
using UnityEngine;

public class ModelPoolManager : MonoBehaviour
{
	public ResourceManager ResourceManager
	{
		get
		{
			return ResourceManager.Instance;
		}
	}

	private void Awake()
	{
		ModelPoolManager.Instance = this;
		this.ModelObjectPool = ObjectPoolComponent.Instance.ObjectPoolManager.CreateSingleObjectPool<DisplayModel>("CardModel");
		this.m_DispalyModelDic = new Dictionary<object, DisplayModel>();
	}

	private void Start()
	{
	}

	public DisplayModel SpawnCard()
	{
		return this.SpawnModel("Card");
	}

	public DisplayModel SpawnModel(string name)
	{
		if (name == null)
		{
			name = "";
		}
		DisplayModel displayModel = this.ModelObjectPool.Spawn(name);
		if (displayModel == null)
		{
			GameObject gameObject;
			if (GameController.ins != null && GameController.ins.PNGResourceCache != null && GameController.ins.PNGResourceCache.ContainsKey(name))
			{
				gameObject = VoxelUtil.Instance.CreateCardModelOfThreeLayers(name, name);
			}
			else
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ResourceManager.LoadResource(name));
			}
			gameObject == null;
			displayModel = new DisplayModel(name, gameObject);
			this.ModelObjectPool.Register(displayModel, true);
			this.m_DispalyModelDic.Add(gameObject, displayModel);
		}
		displayModel.OnSpawn();
		return displayModel;
	}

	public DisplayModel SpawnModel(GameObject gameObject)
	{
		DisplayModel displayModel = this.ModelObjectPool.Spawn(gameObject.name);
		if (displayModel == null)
		{
			GameObject gameObject2 = gameObject;
			if (gameObject2 == null)
			{
				gameObject2 = new GameObject("Empty Model");
				Debug.LogError("加载model失败： " + base.name);
			}
			displayModel = new DisplayModel(gameObject.name, gameObject2);
			this.ModelObjectPool.Register(displayModel, true);
			this.m_DispalyModelDic.Add(gameObject2, displayModel);
		}
		displayModel.OnSpawn();
		return displayModel;
	}

	public void UnSpawnCard(DisplayModel model)
	{
		if (model == null)
		{
			return;
		}
		Card component = model.GameObject.GetComponent<Card>();
		if (component == null)
		{
			return;
		}
		this.UnSpawnModel(component.DisplayGameObjectOnAreaTable);
		this.UnSpawnModel(component.DisplayGameObjectOnPlayerTable);
		this.UnSpawnBottom(component.BottomGameObject);
		model.SetParent(base.transform, false);
		model.OnUnSpawn();
		this.ModelObjectPool.UnSpawn(model);
	}

	public void UnSpawnModel(GameObject obj)
	{
		if (obj == null)
		{
			return;
		}
		DisplayModel displayModel;
		if (!this.m_DispalyModelDic.ContainsKey(obj))
		{
			displayModel = new DisplayModel(obj.name, obj);
			this.ModelObjectPool.Register(displayModel, true);
			this.m_DispalyModelDic.Add(obj, displayModel);
		}
		else
		{
			displayModel = this.m_DispalyModelDic[obj];
		}
		this.UnSpawnModel(displayModel);
	}

	public void UnSpawnModel(DisplayModel model)
	{
		if (model == null)
		{
			return;
		}
		model.SetParent(base.transform, false);
		model.OnUnSpawn();
		this.ModelObjectPool.UnSpawn(model);
	}

	public void UnSpawnBottom(DisplayModel model)
	{
		this.UnSpawnModel(model);
	}

	public void RemoveObject(GameObject obj)
	{
		this.m_DispalyModelDic.Remove(obj);
	}

	public const string c_CardPoolName = "CardModel";

	public const string c_Card = "Card";

	public static ModelPoolManager Instance;

	public IObjectPool<DisplayModel> ModelObjectPool;

	private Dictionary<object, DisplayModel> m_DispalyModelDic;
}
