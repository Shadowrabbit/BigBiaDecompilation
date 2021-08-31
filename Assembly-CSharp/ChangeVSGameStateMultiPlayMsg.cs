using System;

[Serializable]
public class ChangeVSGameStateMultiPlayMsg : MultiPlayMsg
{
	public VSModeController.GameStateType GameState;

	public int myState;
}
