using System;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelBuilder
{
	public static class BuilderConstant
	{
		public static Vector3Int GetSize(VoxelBuilderType type)
		{
			if (!BuilderConstant.sizeDic.ContainsKey(type))
			{
				throw new Exception("不存在这个枚举值！检查sizeDic！");
			}
			return BuilderConstant.sizeDic[type];
		}

		public static readonly Dictionary<VoxelBuilderType, Vector3Int> sizeDic = new Dictionary<VoxelBuilderType, Vector3Int>
		{
			{
				VoxelBuilderType.SmallPic,
				new Vector3Int(16, 1, 16)
			},
			{
				VoxelBuilderType.BigPic,
				new Vector3Int(32, 1, 32)
			},
			{
				VoxelBuilderType.SmallStatue,
				new Vector3Int(32, 32, 32)
			},
			{
				VoxelBuilderType.BigStatue,
				new Vector3Int(32, 64, 32)
			}
		};
	}
}
