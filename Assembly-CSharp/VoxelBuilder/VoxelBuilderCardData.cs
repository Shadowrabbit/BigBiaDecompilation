using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VoxelBuilder
{
	public class VoxelBuilderCardData
	{
		public VoxelBuilderCardData(string name, VoxelBuilderType type)
		{
			this.Name = name;
			this.Type = type;
		}

		public string Name;

		[JsonConverter(typeof(StringEnumConverter))]
		public VoxelBuilderType Type;
	}
}
