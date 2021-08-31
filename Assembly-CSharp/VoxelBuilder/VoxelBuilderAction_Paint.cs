using System;
using UnityEngine;

namespace VoxelBuilder
{
	public class VoxelBuilderAction_Paint : BasicVoxelBuilderAction, IVoxcelBuilderAction
	{
		public VoxelBuilderAction_Paint(VoxelBuilderMgr mgr, Vector3 pos, int colorIndex) : base(mgr, pos, colorIndex)
		{
		}

		public void Execute()
		{
			this.preColorIndex = BuilderMeshHelper.GetCubeColor(this.recordedPos);
			this.mgr.ChangeColor(this.recordedPos, this.recordedColorIndex);
		}

		public void Undo()
		{
			this.mgr.ChangeColor(this.recordedPos, this.preColorIndex);
		}

		public void Redo()
		{
			this.Execute();
		}

		private int preColorIndex;
	}
}
