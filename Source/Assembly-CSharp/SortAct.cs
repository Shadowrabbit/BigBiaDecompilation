using System;

public class SortAct : GameAct
{
	private void Start()
	{
		this.Init();
		GameUIController.Instance.OpenUI(typeof(MachineTransportScreen), UIPathConstant.MachineTransportCanvas, 0, new object[]
		{
			this.Source.CardData
		});
	}

	private void Update()
	{
	}
}
