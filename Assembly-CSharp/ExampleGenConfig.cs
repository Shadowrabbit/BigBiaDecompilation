using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;

public static class ExampleGenConfig
{
	[LuaCallCSharp(GenFlag.No)]
	public static List<Type> LuaCallCSharp = new List<Type>
	{
		typeof(object),
		typeof(UnityEngine.Object),
		typeof(Vector2),
		typeof(Vector3),
		typeof(Vector4),
		typeof(Quaternion),
		typeof(Color),
		typeof(Ray),
		typeof(Bounds),
		typeof(Ray2D),
		typeof(Time),
		typeof(GameObject),
		typeof(Component),
		typeof(Behaviour),
		typeof(Transform),
		typeof(Resources),
		typeof(TextAsset),
		typeof(Keyframe),
		typeof(AnimationCurve),
		typeof(AnimationClip),
		typeof(MonoBehaviour),
		typeof(ParticleSystem),
		typeof(SkinnedMeshRenderer),
		typeof(Renderer),
		typeof(WWW),
		typeof(Mathf),
		typeof(List<int>),
		typeof(Action<string>),
		typeof(Debug)
	};

	[CSharpCallLua]
	public static List<Type> CSharpCallLua = new List<Type>
	{
		typeof(Action),
		typeof(Func<double, double, double>),
		typeof(Action<string>),
		typeof(Action<double>),
		typeof(UnityAction),
		typeof(IEnumerator)
	};

	[BlackList]
	public static List<List<string>> BlackList = new List<List<string>>
	{
		new List<string>
		{
			"System.Xml.XmlNodeList",
			"ItemOf"
		},
		new List<string>
		{
			"UnityEngine.WWW",
			"movie"
		},
		new List<string>
		{
			"UnityEngine.Texture2D",
			"alphaIsTransparency"
		},
		new List<string>
		{
			"UnityEngine.Security",
			"GetChainOfTrustValue"
		},
		new List<string>
		{
			"UnityEngine.CanvasRenderer",
			"onRequestRebuild"
		},
		new List<string>
		{
			"UnityEngine.Light",
			"areaSize"
		},
		new List<string>
		{
			"UnityEngine.Light",
			"lightmapBakeType"
		},
		new List<string>
		{
			"UnityEngine.WWW",
			"MovieTexture"
		},
		new List<string>
		{
			"UnityEngine.WWW",
			"GetMovieTexture"
		},
		new List<string>
		{
			"UnityEngine.AnimatorOverrideController",
			"PerformOverrideClipListCleanup"
		},
		new List<string>
		{
			"UnityEngine.Application",
			"ExternalEval"
		},
		new List<string>
		{
			"UnityEngine.GameObject",
			"networkView"
		},
		new List<string>
		{
			"UnityEngine.Component",
			"networkView"
		},
		new List<string>
		{
			"System.IO.FileInfo",
			"GetAccessControl",
			"System.Security.AccessControl.AccessControlSections"
		},
		new List<string>
		{
			"System.IO.FileInfo",
			"SetAccessControl",
			"System.Security.AccessControl.FileSecurity"
		},
		new List<string>
		{
			"System.IO.DirectoryInfo",
			"GetAccessControl",
			"System.Security.AccessControl.AccessControlSections"
		},
		new List<string>
		{
			"System.IO.DirectoryInfo",
			"SetAccessControl",
			"System.Security.AccessControl.DirectorySecurity"
		},
		new List<string>
		{
			"System.IO.DirectoryInfo",
			"CreateSubdirectory",
			"System.String",
			"System.Security.AccessControl.DirectorySecurity"
		},
		new List<string>
		{
			"System.IO.DirectoryInfo",
			"Create",
			"System.Security.AccessControl.DirectorySecurity"
		},
		new List<string>
		{
			"UnityEngine.MonoBehaviour",
			"runInEditMode"
		}
	};
}
