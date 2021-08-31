using System;
using UnityEngine;
using VoxelBuilder;

public class VoxelEditPictureMatch : GameAct
{
	private void Start()
	{
		this.Init();
		VoxelBuilderMgr.LoadVoxelBuilder(new Action<string>(this.OnDiyFinish));
		base.StartCoroutine(VoxelBuilderMgr.OnSceneEnterToPlayTheGame(new VoxelBuilderType[]
		{
			VoxelBuilderType.SmallPic,
			VoxelBuilderType.BigPic
		}));
	}

	public void OnDiyFinish(string fileName)
	{
		GameController.getInstance().GameEventManager.CurrentActEnd();
		UnityEngine.Object.DestroyImmediate(GameController.getInstance().CurrentAct.gameObject);
	}
}
