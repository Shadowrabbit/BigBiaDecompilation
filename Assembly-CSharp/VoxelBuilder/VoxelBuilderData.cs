using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VoxelBuilder
{
	public class VoxelBuilderData
	{
		public VoxelBuilderData(string name, VoxelBuilderType type, string modelStr, string screenShotStr)
		{
			this.Name = name;
			this.Type = type;
			this.ModelStr = modelStr;
			this.ScreenShotStr = screenShotStr;
		}

		public string Name;

		[JsonConverter(typeof(StringEnumConverter))]
		public VoxelBuilderType Type;

		public string ModelStr;

		public string ScreenShotStr;
	}
}
