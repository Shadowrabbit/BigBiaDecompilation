using System;
using System.Collections.Generic;
using Steamworks;

public class WorkShopItem
{
	public string Title = string.Empty;

	public string Description = string.Empty;

	public string MetaData = string.Empty;

	public ERemoteStoragePublishedFileVisibility Visibility;

	public string Content;

	public string PreviewFile;

	public List<string> TagList = new List<string>();
}
