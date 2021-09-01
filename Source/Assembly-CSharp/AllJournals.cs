using System;
using System.Collections.Generic;

public class AllJournals
{
	public void InitAllJournalls()
	{
		AllJournals.Journals = new List<JournalsBean>();
	}

	public static List<JournalsBean> Journals;
}
