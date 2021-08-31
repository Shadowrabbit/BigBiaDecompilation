using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	[CSharpCallLua]
	public delegate Vector3 Vector3Param(Vector3 p);
}
