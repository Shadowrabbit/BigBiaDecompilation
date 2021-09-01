using System;
using System.Collections.Generic;
using UnityEngine;

public class BookDataMap
{
	[SerializeField]
	public List<BookData> Books { get; set; }

	public BookData getBookDataByModID(string modId)
	{
		foreach (BookData bookData in this.Books)
		{
			if (bookData.ModID.Equals(modId))
			{
				return bookData;
			}
		}
		return null;
	}
}
