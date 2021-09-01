using System;
using System.Text;
using UnityEngine.Events;

public class GameSettleScreen : ScreenBase
{
	public GameSettleScreen() : base(UIPathConstant.GameOver)
	{
	}

	public override void OnLoadComplete(object asset)
	{
		base.OnLoadComplete(asset);
		this.gameSettlePanel = (this.uIControlBase as GameSettlePanel);
		this.gameSettlePanel.continueButton.onClick.AddListener(new UnityAction(this.OnClickContinueButton));
		this.OnOpen();
	}

	public override void OnOpen()
	{
		base.OnOpen();
		this.ShowMessage();
	}

	public override void OnClose()
	{
		base.OnClose();
	}

	private void ShowMessage()
	{
		GameSettleData gameSettleData = DungeonController.Instance.GameSettleData;
		if (gameSettleData == null)
		{
			gameSettleData = new GameSettleData();
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("游戏时长:" + gameSettleData.totalTime.ToString());
		stringBuilder.Append("\n获取金币:" + gameSettleData.money.ToString());
		stringBuilder.Append("\n造成伤害:" + gameSettleData.totalDmg.ToString());
		this.gameSettlePanel.text.text = stringBuilder.ToString();
	}

	private void OnClickContinueButton()
	{
		GameUIController.Instance.CloseUI<GameSettleScreen>();
		GameController.getInstance().StartCoroutine(GameController.getInstance().LoadHomeScene());
	}

	public GameSettlePanel gameSettlePanel;
}
