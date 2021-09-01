using System;

public class GuAoLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = "孤傲";
		this.Desc = "他的光辉往事已成传奇，每当有人提起他，就会想起那句\"跟紧我的步伐，我们送他们回家\"。";
	}
}
