using System;
using UnityEngine;

namespace VoxelBuilder
{
	public class VoxelBuilderAction_Erase : BasicVoxelBuilderAction, IVoxcelBuilderAction
	{
		public VoxelBuilderAction_Erase(VoxelBuilderMgr mgr, Vector3 pos, int colorIndex) : base(mgr, pos, colorIndex)
		{
		}

		public void Execute()
		{
			this.mgr.RemoveCube(this.recordedPos);
			this.mgr.ShowStartIndicatorCube(true);
		}

		public void Undo()
		{
			new VoxelBuilderAction_Attach(this.mgr, this.recordedPos, this.recordedColorIndex).Execute();
		}

		public void Redo()
		{
			this.Execute();
		}
	}
}
