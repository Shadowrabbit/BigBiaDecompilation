using System;
using System.Reflection;

public static class ReflectionHelper
{
	public static T CreateInstance<T>(string fullName, string assemblyName)
	{
		return (T)((object)Activator.CreateInstance(Type.GetType(fullName + "," + assemblyName), true));
	}

	public static T CreateInstance<T>(string assemblyName, string nameSpace, string className)
	{
		T result;
		try
		{
			string typeName = nameSpace + "." + className;
			result = (T)((object)Assembly.Load(assemblyName).CreateInstance(typeName));
		}
		catch
		{
			result = default(T);
		}
		return result;
	}
}
