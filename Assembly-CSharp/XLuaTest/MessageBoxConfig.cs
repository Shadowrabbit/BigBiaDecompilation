﻿using System;
using System.Collections.Generic;
using UnityEngine.Events;
using XLua;

namespace XLuaTest
{
	public static class MessageBoxConfig
	{
		[CSharpCallLua]
		public static List<Type> CSharpCallLua = new List<Type>
		{
			typeof(Action),
			typeof(Action<bool>),
			typeof(UnityAction)
		};
	}
}
