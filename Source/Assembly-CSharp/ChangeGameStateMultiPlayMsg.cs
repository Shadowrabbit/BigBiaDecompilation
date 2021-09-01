using System;

[Serializable]
public class ChangeGameStateMultiPlayMsg : MultiPlayMsg
{
	public MultiPlayerController.GameStateType GameState;

	public int myState;
}
