using System;

namespace PixelGame
{
	public interface IObjectPool<T>
	{
		string Name { get; }

		string FullName { get; }

		Type ObjectType { get; }

		int Capacity { get; set; }

		int Count { get; }

		float ExpireTime { get; }

		float AutoReleaseInterval { get; }

		bool AllowMultiSpawn { get; set; }

		void Register(T target, bool used);

		T Spawn(string name);

		void UnSpawn(T target);

		void UnSpawn(object obj);

		void Release();

		void Release(int count);
	}
}
