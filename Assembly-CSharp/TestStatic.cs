using System;

public static class TestStatic
{
	public static void ShowContent(this TestThisBase target)
	{
		target.ShowNumb();
	}
}
