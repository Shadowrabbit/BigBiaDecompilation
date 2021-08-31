using System;

namespace PixelGame
{
	public interface IObjectPoolManager
	{
		int Count { get; }

		IObjectPool<T> GetObjectPool<T>(string name) where T : ObjectBase;

		ObjectPoolBase GetObjectPool(string name);

		ObjectPoolBase[] GetAllObjectPool();

		bool HasObjectPool(string name);

		IObjectPool<T> CreateSingleObjectPool<T>(string name);

		IObjectPool<T> CreateMultiObjectPool<T>(string name);

		void Update(float time);
	}
}
