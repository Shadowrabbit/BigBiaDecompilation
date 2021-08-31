using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class DataContractJsonResolver : DefaultContractResolver
{
	public DataContractJsonResolver()
	{
		base.NamingStrategy = new CamelCaseNamingStrategy();
	}

	protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
	{
		return (from p in base.CreateProperties(type, memberSerialization)
		orderby DataContractJsonResolver.<CreateProperties>g__BaseTypesAndSelf|1_1(p.DeclaringType).Count<Type>()
		select p).ToList<JsonProperty>();
	}

	[CompilerGenerated]
	internal static IEnumerable<Type> <CreateProperties>g__BaseTypesAndSelf|1_1(Type t)
	{
		while (t != null)
		{
			yield return t;
			t = t.BaseType;
		}
		yield break;
	}
}
