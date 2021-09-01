using System;
using System.Collections;
using UnityEngine;

public class HomeTableAreaLogic : AreaLogic
{
	public override void OnGameLoaded()
	{
	}

	public override void BeforeEnter()
	{
		GameController.getInstance().UIController.HideBackToHomeButton();
		foreach (CardSlotData cardSlotData in base.Data.CardSlotDatas)
		{
			cardSlotData.CardSlotGameObject.transform.localPosition -= Vector3.forward * 5.07f;
			cardSlotData.CardSlotGameObject.transform.localPosition -= Vector3.up * 0.06f;
		}
	}

	public override void BeforeInit()
	{
		base.Data.CardSlotDatas = GameController.ins.GameData.SlotsOnHomeTable;
	}

	public override IEnumerator OnAlreadEnter()
	{
		GameController.ins.UIController.HideBlackMask(null, 0.5f);
		this.go = UnityEngine.Object.Instantiate<GameObject>(ResourceManager.Instance.LoadResource("UI/OKButton"));
		this.go.transform.position = new Vector3(7f, 0f, 5f);
		this.go.GetComponent<CommonOKButton>().OnClickOkButton = new Action(this.OnPointerClick);
		yield break;
	}

	public void OnPointerClick()
	{
		this.go.GetComponent<CommonOKButton>().OnClickOkButton = null;
		AreaData areaData = GameController.getInstance().GameData.AreaMap[GameController.ins.GameData.DungeonArea[0].Attrs["AreaDataID"].ToString()];
		areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
		GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
		GameController.getInstance().OnTableChange(areaData, true);
	}

	public override void OnExit()
	{
		UnityEngine.Object.Destroy(this.go);
	}

	private MinionSelectArea MinionSelectArea;

	private GameObject go;
}
