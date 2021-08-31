using System;
using System.Collections.Generic;

namespace PixelGame
{
	public class ObjectPoolManager : IObjectPoolManager
	{
		public int Count
		{
			get
			{
				return this.m_ObjectPools.Count;
			}
		}

		public ObjectPoolManager()
		{
			this.m_ObjectPools = new Dictionary<string, ObjectPoolBase>();
		}

		public ObjectPoolManager(int capa, int expire, int auto) : this()
		{
			this.DefaultCapacity = capa;
			this.DefaultExpireTime = (float)expire;
			this.DefaultAutoReleaseTime = (float)auto;
		}

		public void Update(float time)
		{
			foreach (ObjectPoolBase objectPoolBase in this.m_ObjectPools.Values)
			{
				objectPoolBase.Update(time);
			}
		}

		public IObjectPool<T> GetObjectPool<T>(string name) where T : ObjectBase
		{
			return (IObjectPool<T>)this.GetObjectPool(name);
		}

		public ObjectPoolBase GetObjectPool(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new Exception("name is invalid");
			}
			ObjectPoolBase result = null;
			if (this.m_ObjectPools.TryGetValue(name, out result))
			{
				return result;
			}
			return null;
		}

		public ObjectPoolBase[] GetAllObjectPool()
		{
			List<ObjectPoolBase> list = new List<ObjectPoolBase>();
			list.AddRange(this.m_ObjectPools.Values);
			return list.ToArray();
		}

		public bool HasObjectPool(string name)
		{
			return this.m_ObjectPools.ContainsKey(name);
		}

		public IObjectPool<T> CreateSingleObjectPool<T>(string name)
		{
			return (IObjectPool<T>)this.InternalCreateObjectPool(typeof(T), name, this.DefaultCapacity, this.DefaultExpireTime, this.DefaultAutoReleaseTime, false);
		}

		public IObjectPool<T> CreateMultiObjectPool<T>(string name)
		{
			return (IObjectPool<T>)this.InternalCreateObjectPool(typeof(T), name, this.DefaultCapacity, this.DefaultExpireTime, this.DefaultAutoReleaseTime, true);
		}

		private ObjectPoolBase InternalCreateObjectPool(Type type, string name, int capacity, float expireTime, float releaseInterval, bool allowMulti)
		{
			if (type == null)
			{
				throw new Exception("Object type is invalid");
			}
			if (this.HasObjectPool(name))
			{
				throw new Exception("Object pool exist : " + name);
			}
			ObjectPoolBase objectPoolBase = (ObjectPoolBase)Activator.CreateInstance(typeof(ObjectPoolManager.ObjectPool<>).MakeGenericType(new Type[]
			{
				type
			}), new object[]
			{
				name,
				capacity,
				expireTime,
				releaseInterval,
				allowMulti
			});
			this.m_ObjectPools.Add(name, objectPoolBase);
			return objectPoolBase;
		}

		private Dictionary<string, ObjectPoolBase> m_ObjectPools;

		private readonly int DefaultCapacity = int.MaxValue;

		private readonly float DefaultExpireTime = 60f;

		private readonly float DefaultAutoReleaseTime = 60f;

		private class Object<T> where T : ObjectBase
		{
			public bool IsUsed
			{
				get
				{
					return this.m_SpawnCount > 0;
				}
			}

			public int SpawnCount
			{
				get
				{
					return this.m_SpawnCount;
				}
			}

			public Object(T obj, bool used)
			{
				this.m_Obj = obj;
				this.m_SpawnCount = (used ? 1 : 0);
			}

			public T Spawn()
			{
				this.m_SpawnCount++;
				this.m_Obj.LastUseTime = DateTime.UtcNow;
				return this.m_Obj;
			}

			public T Peek()
			{
				return this.m_Obj;
			}

			public void UnSpawn()
			{
				this.m_SpawnCount--;
			}

			public void Release()
			{
				this.m_Obj.Release();
			}

			private T m_Obj;

			private int m_SpawnCount;
		}

		public class ObjectPool<T> : ObjectPoolBase, IObjectPool<T> where T : ObjectBase
		{
			public override int Capacity
			{
				get
				{
					return this.m_Capacity;
				}
				set
				{
					if (value <= 0)
					{
						throw new Exception("Capacity can not lower than 0");
					}
					this.m_Capacity = value;
					this.Release();
				}
			}

			public override Type ObjectType
			{
				get
				{
					return typeof(T);
				}
			}

			public override float ExpireTime
			{
				get
				{
					return this.m_ExpireTime;
				}
			}

			public override int Count
			{
				get
				{
					return this.m_ObjectMap.Count;
				}
			}

			public override int CanReleaseCount
			{
				get
				{
					this.GetCanReleaseObject();
					return this.m_CacheCanReleaseObject.Count;
				}
			}

			public override float AutoReleaseInterval
			{
				get
				{
					return this.m_AutoReleaseInterval;
				}
			}

			public override bool AllowMultiSpawn { get; set; }

			public ObjectPool()
			{
			}

			public ObjectPool(string name, int capacity, float expireTime, float autoReleaseInterval, bool allowMultiSpawn) : base(name)
			{
				this.m_ObjectDic = new Dictionary<string, List<ObjectPoolManager.Object<T>>>();
				this.m_ObjectMap = new Dictionary<object, ObjectPoolManager.Object<T>>();
				this.m_CacheCanReleaseObject = new List<T>();
				this.m_ToReleaseObject = new List<T>();
				this.m_Capacity = capacity;
				this.m_ExpireTime = expireTime;
				this.m_AutoReleaseInterval = autoReleaseInterval;
				this.AllowMultiSpawn = allowMultiSpawn;
			}

			public void Register(T target, bool used)
			{
				if (target == null)
				{
					throw new Exception("Try to add null to objectpool");
				}
				List<ObjectPoolManager.Object<T>> list = this.GetObjects(target.Name);
				if (list == null)
				{
					list = new List<ObjectPoolManager.Object<T>>();
					this.m_ObjectDic.Add(target.Name, list);
				}
				ObjectPoolManager.Object<T> @object = new ObjectPoolManager.Object<T>(target, used);
				list.Add(@object);
				if (!this.m_ObjectMap.ContainsKey(target.target))
				{
					this.m_ObjectMap.Add(target.target, @object);
				}
				if (this.Count > this.Capacity)
				{
					this.Release();
				}
			}

			public T Spawn(string name)
			{
				List<ObjectPoolManager.Object<T>> objects = this.GetObjects(name);
				if (objects == null)
				{
					return default(T);
				}
				ObjectPoolManager.Object<T> @object = null;
				foreach (ObjectPoolManager.Object<T> object2 in objects)
				{
					if (this.AllowMultiSpawn || !object2.IsUsed)
					{
						@object = object2;
						break;
					}
				}
				if (@object != null)
				{
					return @object.Spawn();
				}
				return default(T);
			}

			public void UnSpawn(T target)
			{
				if (target == null)
				{
					return;
				}
				this.UnSpawn(target.target);
			}

			public void UnSpawn(object obj)
			{
				ObjectPoolManager.Object<T> @object = this.GetObject(obj);
				if (obj != null)
				{
					@object.UnSpawn();
					return;
				}
				throw new Exception("Can't find obj in objectpool" + obj.ToString());
			}

			public void Release()
			{
				this.Release(this.Count - this.m_Capacity);
			}

			public void Release(int count)
			{
				if (count < 0)
				{
					count = 0;
				}
				DateTime expire = DateTime.MinValue;
				if (this.m_ExpireTime < 3.4028235E+38f)
				{
					expire = DateTime.Now.AddSeconds((double)(-(double)this.m_ExpireTime));
				}
				this.m_CurrentInterval = 0f;
				this.GetCanReleaseObject();
				List<T> toReleaseObject = this.GetToReleaseObject(this.m_CacheCanReleaseObject, count, expire);
				if (toReleaseObject == null || toReleaseObject.Count == 0)
				{
					return;
				}
				foreach (T obj in toReleaseObject)
				{
					this.ReleaseObject(obj);
				}
			}

			internal override void Update(float deltaTime)
			{
				this.m_CurrentInterval += deltaTime;
				if (this.m_CurrentInterval > this.m_AutoReleaseInterval)
				{
					this.Release();
				}
			}

			private List<ObjectPoolManager.Object<T>> GetObjects(string name)
			{
				List<ObjectPoolManager.Object<T>> result = null;
				if (this.m_ObjectDic.TryGetValue(name, out result))
				{
					return result;
				}
				return null;
			}

			private ObjectPoolManager.Object<T> GetObject(object key)
			{
				ObjectPoolManager.Object<T> result = null;
				if (this.m_ObjectMap.TryGetValue(key, out result))
				{
					return result;
				}
				return null;
			}

			private List<T> GetCanReleaseObject()
			{
				this.m_CacheCanReleaseObject.Clear();
				foreach (ObjectPoolManager.Object<T> @object in this.m_ObjectMap.Values)
				{
					if (!@object.IsUsed)
					{
						this.m_CacheCanReleaseObject.Add(@object.Peek());
					}
				}
				return this.m_CacheCanReleaseObject;
			}

			private List<T> GetToReleaseObject(List<T> canReleaseObject, int count, DateTime expire)
			{
				if (canReleaseObject == null || canReleaseObject.Count == 0)
				{
					return null;
				}
				this.m_ToReleaseObject.Clear();
				for (int i = canReleaseObject.Count - 1; i >= 0; i--)
				{
					if (canReleaseObject[i].LastUseTime < expire)
					{
						this.m_ToReleaseObject.Add(canReleaseObject[i]);
						canReleaseObject.RemoveAt(i);
					}
				}
				int num = 0;
				while (num < canReleaseObject.Count && count > 0)
				{
					this.m_ToReleaseObject.Add(canReleaseObject[num]);
					count--;
					num++;
				}
				return this.m_ToReleaseObject;
			}

			private void ReleaseObject(T obj)
			{
				if (obj == null)
				{
					throw new Exception("obj is invalid");
				}
				List<ObjectPoolManager.Object<T>> objects = this.GetObjects(obj.Name);
				ObjectPoolManager.Object<T> @object = this.GetObject(obj.target);
				if (objects != null && @object != null)
				{
					objects.Remove(@object);
					this.m_ObjectMap.Remove(@object.Peek().target);
					if (objects.Count == 0)
					{
						this.m_ObjectDic.Remove(obj.Name);
					}
					obj.Release();
					return;
				}
			}

			private Dictionary<string, List<ObjectPoolManager.Object<T>>> m_ObjectDic;

			private Dictionary<object, ObjectPoolManager.Object<T>> m_ObjectMap;

			private List<T> m_CacheCanReleaseObject;

			private List<T> m_ToReleaseObject;

			private int m_Capacity;

			private float m_AutoReleaseInterval;

			private float m_CurrentInterval;

			private float m_ExpireTime;
		}
	}
}
