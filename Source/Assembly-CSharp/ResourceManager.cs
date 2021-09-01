using System;
using System.Collections.Generic;
using PixelGame;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
	private void Awake()
	{
		ResourceManager.Instance = this;
		this.m_LoadResourceInfo = new LinkedList<LoadResourceInfo>();
		this.m_LoadedResourceInfo = new LoadResourceInfo[this.loadResourcePerFrame];
		this.m_AllResourceDic = new Dictionary<object, ResourceObject>();
	}

	private void Start()
	{
		this.m_ObjectPool = ObjectPoolComponent.Instance.ObjectPoolManager.CreateMultiObjectPool<ResourceObject>("Resource");
	}

	private void Update()
	{
		if (this.m_LoadResourceInfo.Count > 0 && this.m_CurrentLoadResource < this.loadResourcePerFrame)
		{
			LinkedListNode<LoadResourceInfo> linkedListNode = this.m_LoadResourceInfo.First;
			while (linkedListNode != null && this.m_CurrentLoadResource != this.loadResourcePerFrame)
			{
				if (linkedListNode.Value.request.isDone)
				{
					LoadResourceInfo[] loadedResourceInfo = this.m_LoadedResourceInfo;
					int currentLoadResource = this.m_CurrentLoadResource;
					this.m_CurrentLoadResource = currentLoadResource + 1;
					loadedResourceInfo[currentLoadResource] = linkedListNode.Value;
				}
				linkedListNode = linkedListNode.Next;
			}
			for (int i = 0; i < this.m_LoadedResourceInfo.Length; i++)
			{
				LoadResourceInfo loadResourceInfo = this.m_LoadedResourceInfo[i];
				if (loadResourceInfo != null)
				{
					this.m_LoadResourceInfo.Remove(loadResourceInfo);
					ResourceObject resourceObject = new ResourceObject(loadResourceInfo.path, loadResourceInfo.request.asset);
					this.m_ObjectPool.Register(resourceObject, true);
					Action<object> callBack = loadResourceInfo.callBack;
					if (callBack != null)
					{
						callBack(loadResourceInfo.request.asset);
					}
					if (!this.m_AllResourceDic.ContainsKey(resourceObject.target))
					{
						this.m_AllResourceDic.Add(resourceObject.target, resourceObject);
					}
				}
				this.m_LoadedResourceInfo[i] = null;
			}
		}
		this.m_CurrentLoadResource = 0;
	}

	public void LoadResource(string path, Action<object> callBack)
	{
		ResourceObject resourceObject = this.m_ObjectPool.Spawn(path);
		if (resourceObject != null)
		{
			if (callBack != null)
			{
				callBack(resourceObject.target);
			}
			return;
		}
		ResourceRequest request = Resources.LoadAsync<GameObject>(path);
		LoadResourceInfo loadResourceInfo = new LoadResourceInfo();
		loadResourceInfo.path = path;
		loadResourceInfo.request = request;
		loadResourceInfo.callBack = callBack;
		this.m_LoadResourceInfo.AddLast(loadResourceInfo);
	}

	public GameObject LoadResource(string path)
	{
		return Resources.Load<GameObject>(path);
	}

	public void UnLoadResource(object obj)
	{
		if (!this.m_AllResourceDic.ContainsKey(obj))
		{
			throw new Exception("要释放的对象不存在" + obj.ToString());
		}
		this.m_ObjectPool.UnSpawn(this.m_AllResourceDic[obj]);
	}

	public void RemoveResource(ResourceObject obj)
	{
		if (!this.m_AllResourceDic.ContainsKey(obj.target))
		{
			throw new Exception("要移除的对象不存在" + obj.Name);
		}
		this.m_AllResourceDic.Remove(obj.target);
	}

	public static ResourceManager Instance;

	public int loadResourcePerFrame = 1;

	private IObjectPool<ResourceObject> m_ObjectPool;

	private Dictionary<object, ResourceObject> m_AllResourceDic;

	private LinkedList<LoadResourceInfo> m_LoadResourceInfo;

	private LoadResourceInfo[] m_LoadedResourceInfo;

	private int m_CurrentLoadResource;
}
