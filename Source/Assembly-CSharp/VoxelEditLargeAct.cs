using System;
using UnityEngine;
using VoxelBuilder;

public class VoxelEditLargeAct : GameAct
{
	private void Start()
	{
		this.Init();
		VoxelBuilderMgr.LoadVoxelBuilder(new Action<string>(this.OnDiyFinish));
		base.StartCoroutine(VoxelBuilderMgr.OnSceneEnter(VoxelBuilderType.BigStatue));
	}

	public void OnDiyFinish(string fileName)
	{
		if (fileName != null)
		{
			CardData customCardFile = new CustomCard().GetCustomCardFile(fileName, "这是一张自定义卡牌", 0, "DefaultCustomCard");
			GameController.getInstance().CardDataModMap.Cards.Add(customCardFile);
			Card.InitACardDataToPlayerTable(customCardFile);
		}
		UIController.LockLevel = UIController.UILevel.None;
		GameController.getInstance().GameEventManager.CurrentActEnd();
		UnityEngine.Object.DestroyImmediate(GameController.getInstance().CurrentAct.gameObject);
	}
}
