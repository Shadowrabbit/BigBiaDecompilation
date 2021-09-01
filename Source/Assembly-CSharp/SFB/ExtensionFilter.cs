using System;

namespace SFB
{
	public struct ExtensionFilter
	{
		public ExtensionFilter(string filterName, params string[] filterExtensions)
		{
			this.Name = filterName;
			this.Extensions = filterExtensions;
		}

		public string Name;

		public string[] Extensions;
	}
}
