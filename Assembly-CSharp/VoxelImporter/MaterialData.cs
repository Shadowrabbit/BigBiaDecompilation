using System;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelImporter
{
	[Serializable]
	public class MaterialData : ISerializationCallbackReceiver
	{
		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			IntVector3 intVector = IntVector3.zero;
			for (int i = 0; i < this.materialList.Count; i++)
			{
				intVector = IntVector3.Max(intVector, this.materialList[i]);
			}
			this.indexTable = new DataTable3<int>(intVector.x + 1, intVector.y + 1, intVector.z + 1);
			for (int j = 0; j < this.materialList.Count; j++)
			{
				this.indexTable.Set(this.materialList[j], j);
			}
		}

		public MaterialData Clone()
		{
			MaterialData materialData = new MaterialData();
			materialData.materialList = new List<IntVector3>(this.materialList);
			materialData.name = this.name;
			materialData.transparent = this.transparent;
			materialData.OnAfterDeserialize();
			return materialData;
		}

		public bool IsEqual(MaterialData src)
		{
			if (this.materialList != null && src.materialList != null)
			{
				if (this.materialList.Count != src.materialList.Count)
				{
					return false;
				}
				for (int i = 0; i < this.materialList.Count; i++)
				{
					if (this.materialList[i] != src.materialList[i])
					{
						return false;
					}
				}
			}
			else
			{
				if (this.materialList != null && src.materialList == null)
				{
					return false;
				}
				if (this.materialList == null && src.materialList != null)
				{
					return false;
				}
			}
			return !(this.name != src.name) && this.transparent == src.transparent;
		}

		public void SetMaterial(IntVector3 pos)
		{
			if (!this.indexTable.Contains(pos))
			{
				this.indexTable.Set(pos, this.materialList.Count);
				this.materialList.Add(pos);
				return;
			}
			this.indexTable.Get(pos);
		}

		public void RemoveMaterial(IntVector3 pos)
		{
			if (this.indexTable.Contains(pos))
			{
				int num = this.indexTable.Get(pos);
				if (num < this.materialList.Count - 1)
				{
					this.materialList[num] = this.materialList[this.materialList.Count - 1];
					this.indexTable.Set(this.materialList[this.materialList.Count - 1], num);
					this.materialList.RemoveAt(this.materialList.Count - 1);
				}
				else
				{
					this.materialList.RemoveAt(num);
				}
				this.indexTable.Remove(pos);
			}
		}

		public bool GetMaterial(IntVector3 pos)
		{
			return this.indexTable.Contains(pos);
		}

		public void ClearMaterial()
		{
			this.indexTable.Clear();
			this.materialList.Clear();
		}

		public void AllAction(Action<IntVector3> action)
		{
			this.indexTable.AllAction(delegate(int x, int y, int z, int index)
			{
				action(new IntVector3(x, y, z));
			});
		}

		private DataTable3<int> indexTable = new DataTable3<int>(0, 0, 0);

		[SerializeField]
		private List<IntVector3> materialList = new List<IntVector3>();

		public string name;

		public bool transparent;
	}
}
