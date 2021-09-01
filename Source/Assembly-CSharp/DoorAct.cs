using System;
using System.Collections;

public class DoorAct : GameAct
{
	private void Start()
	{
		this.Init();
		DungeonOperationMgr.Instance.StartCoroutine(this.StartDoorAct());
	}

	private IEnumerator StartDoorAct()
	{
		if (GameController.ins.GameData.KeyNum <= 0)
		{
			YesPanel yesPanel = GameController.ins.UIController.YesPanel;
			yesPanel.MainText.text = LocalizationMgr.Instance.GetLocalizationWord("UI_门钥匙");
			yield return yesPanel.StartChoosing();
		}
		else
		{
			YesOrNoPanel yesOrNoPanel = GameController.ins.UIController.YesOrNoPanel;
			yesOrNoPanel.MainText.text = LocalizationMgr.Instance.GetLocalizationWord("UI_门钥匙");
			yield return yesOrNoPanel.StartChoosing();
			if (YesOrNoPanel.Result)
			{
				GameController.ins.GameData.KeyNum--;
				this.Source.CardData.CurrentCardSlotData.CanClick = true;
				this.Source.CardData.DeleteCardData();
				this.IsOpen = true;
			}
		}
		this.ActEnd();
		yield break;
	}

	public bool IsOpen;
}
