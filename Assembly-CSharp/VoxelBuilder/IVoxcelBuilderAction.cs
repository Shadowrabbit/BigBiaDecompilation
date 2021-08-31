using System;

namespace VoxelBuilder
{
	public interface IVoxcelBuilderAction
	{
		void Execute();

		void Undo();

		void Redo();
	}
}
