using System;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	public static class CoroutineConfig
	{
		[LuaCallCSharp(GenFlag.No)]
		public static List<Type> LuaCallCSharp
		{
			get
			{
				return new List<Type>
				{
					typeof(WaitForSeconds),
					typeof(WWW)
				};
			}
		}
	}
}
