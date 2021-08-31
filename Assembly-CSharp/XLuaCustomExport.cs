using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using XLua;

public static class XLuaCustomExport
{
	[LuaCallCSharp(GenFlag.No), ReflectionUse]
	public static List<Type> dotween_lua_call_cs_list = new List<Type>
	{
		typeof(AutoPlay),
		typeof(AxisConstraint),
		typeof(Ease),
		typeof(LogBehaviour),
		typeof(LoopType),
		typeof(PathMode),
		typeof(PathType),
		typeof(RotateMode),
		typeof(ScrambleMode),
		typeof(TweenType),
		typeof(UpdateType),
		typeof(DOTween),
		typeof(DOVirtual),
		typeof(EaseFactory),
		typeof(Tweener),
		typeof(Tween),
		typeof(Sequence),
		typeof(TweenParams),
		typeof(ABSSequentiable),
		typeof(TweenerCore<Vector3, Vector3, VectorOptions>),
		typeof(TweenCallback),
		typeof(TweenExtensions),
		typeof(TweenSettingsExtensions),
		typeof(ShortcutExtensions)
	};
}
