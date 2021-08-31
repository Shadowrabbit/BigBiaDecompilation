using System;
using UnityEngine;

namespace VoxelBuilder
{
	public abstract class BasicVoxelBuilderAction
	{
		public BasicVoxelBuilderAction(VoxelBuilderMgr mgr, Vector3 pos, int colorIndex)
		{
			this.recordedColorIndex = colorIndex;
			this.recordedPos = pos;
			this.mgr = mgr;
		}

		protected Vector3 recordedPos;

		protected int recordedColorIndex;

		protected VoxelBuilderMgr mgr;
	}
}
