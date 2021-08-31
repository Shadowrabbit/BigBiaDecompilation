using System;
using UnityEngine;

namespace VoxelBuilder
{
	public class VoxelBuilderAction_Attach : BasicVoxelBuilderAction, IVoxcelBuilderAction
	{
		public VoxelBuilderAction_Attach(VoxelBuilderMgr mgr, Vector3 pos, int colorIndex) : base(mgr, pos, colorIndex)
		{
		}

		public void Execute()
		{
			this.mgr.AddCube(this.recordedPos, this.recordedColorIndex);
			this.mgr.ShowStartIndicatorCube(false);
		}

		public void Undo()
		{
			new VoxelBuilderAction_Erase(this.mgr, this.recordedPos, this.recordedColorIndex).Execute();
		}

		public void Redo()
		{
			this.Execute();
		}
	}
}
