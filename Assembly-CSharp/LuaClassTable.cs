using System;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public static class LuaClassTable
{
	[LuaCallCSharp(GenFlag.No)]
	public static List<Type> mymodule_lua_call_cs_list = new List<Type>
	{
		typeof(GameObject),
		typeof(GameController),
		typeof(CardSlotData),
		typeof(CardData)
	};
}
