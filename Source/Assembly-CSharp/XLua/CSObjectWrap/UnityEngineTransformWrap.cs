using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineTransformWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Transform);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 54, 19, 13, -1);
			Utils.RegisterFunc(L, -3, "SetParent", new lua_CSFunction(UnityEngineTransformWrap._m_SetParent));
			Utils.RegisterFunc(L, -3, "SetPositionAndRotation", new lua_CSFunction(UnityEngineTransformWrap._m_SetPositionAndRotation));
			Utils.RegisterFunc(L, -3, "Translate", new lua_CSFunction(UnityEngineTransformWrap._m_Translate));
			Utils.RegisterFunc(L, -3, "Rotate", new lua_CSFunction(UnityEngineTransformWrap._m_Rotate));
			Utils.RegisterFunc(L, -3, "RotateAround", new lua_CSFunction(UnityEngineTransformWrap._m_RotateAround));
			Utils.RegisterFunc(L, -3, "LookAt", new lua_CSFunction(UnityEngineTransformWrap._m_LookAt));
			Utils.RegisterFunc(L, -3, "TransformDirection", new lua_CSFunction(UnityEngineTransformWrap._m_TransformDirection));
			Utils.RegisterFunc(L, -3, "InverseTransformDirection", new lua_CSFunction(UnityEngineTransformWrap._m_InverseTransformDirection));
			Utils.RegisterFunc(L, -3, "TransformVector", new lua_CSFunction(UnityEngineTransformWrap._m_TransformVector));
			Utils.RegisterFunc(L, -3, "InverseTransformVector", new lua_CSFunction(UnityEngineTransformWrap._m_InverseTransformVector));
			Utils.RegisterFunc(L, -3, "TransformPoint", new lua_CSFunction(UnityEngineTransformWrap._m_TransformPoint));
			Utils.RegisterFunc(L, -3, "InverseTransformPoint", new lua_CSFunction(UnityEngineTransformWrap._m_InverseTransformPoint));
			Utils.RegisterFunc(L, -3, "DetachChildren", new lua_CSFunction(UnityEngineTransformWrap._m_DetachChildren));
			Utils.RegisterFunc(L, -3, "SetAsFirstSibling", new lua_CSFunction(UnityEngineTransformWrap._m_SetAsFirstSibling));
			Utils.RegisterFunc(L, -3, "SetAsLastSibling", new lua_CSFunction(UnityEngineTransformWrap._m_SetAsLastSibling));
			Utils.RegisterFunc(L, -3, "SetSiblingIndex", new lua_CSFunction(UnityEngineTransformWrap._m_SetSiblingIndex));
			Utils.RegisterFunc(L, -3, "GetSiblingIndex", new lua_CSFunction(UnityEngineTransformWrap._m_GetSiblingIndex));
			Utils.RegisterFunc(L, -3, "Find", new lua_CSFunction(UnityEngineTransformWrap._m_Find));
			Utils.RegisterFunc(L, -3, "IsChildOf", new lua_CSFunction(UnityEngineTransformWrap._m_IsChildOf));
			Utils.RegisterFunc(L, -3, "GetEnumerator", new lua_CSFunction(UnityEngineTransformWrap._m_GetEnumerator));
			Utils.RegisterFunc(L, -3, "GetChild", new lua_CSFunction(UnityEngineTransformWrap._m_GetChild));
			Utils.RegisterFunc(L, -3, "DOMove", new lua_CSFunction(UnityEngineTransformWrap._m_DOMove));
			Utils.RegisterFunc(L, -3, "DOMoveX", new lua_CSFunction(UnityEngineTransformWrap._m_DOMoveX));
			Utils.RegisterFunc(L, -3, "DOMoveY", new lua_CSFunction(UnityEngineTransformWrap._m_DOMoveY));
			Utils.RegisterFunc(L, -3, "DOMoveZ", new lua_CSFunction(UnityEngineTransformWrap._m_DOMoveZ));
			Utils.RegisterFunc(L, -3, "DOLocalMove", new lua_CSFunction(UnityEngineTransformWrap._m_DOLocalMove));
			Utils.RegisterFunc(L, -3, "DOLocalMoveX", new lua_CSFunction(UnityEngineTransformWrap._m_DOLocalMoveX));
			Utils.RegisterFunc(L, -3, "DOLocalMoveY", new lua_CSFunction(UnityEngineTransformWrap._m_DOLocalMoveY));
			Utils.RegisterFunc(L, -3, "DOLocalMoveZ", new lua_CSFunction(UnityEngineTransformWrap._m_DOLocalMoveZ));
			Utils.RegisterFunc(L, -3, "DORotate", new lua_CSFunction(UnityEngineTransformWrap._m_DORotate));
			Utils.RegisterFunc(L, -3, "DORotateQuaternion", new lua_CSFunction(UnityEngineTransformWrap._m_DORotateQuaternion));
			Utils.RegisterFunc(L, -3, "DOLocalRotate", new lua_CSFunction(UnityEngineTransformWrap._m_DOLocalRotate));
			Utils.RegisterFunc(L, -3, "DOLocalRotateQuaternion", new lua_CSFunction(UnityEngineTransformWrap._m_DOLocalRotateQuaternion));
			Utils.RegisterFunc(L, -3, "DOScale", new lua_CSFunction(UnityEngineTransformWrap._m_DOScale));
			Utils.RegisterFunc(L, -3, "DOScaleX", new lua_CSFunction(UnityEngineTransformWrap._m_DOScaleX));
			Utils.RegisterFunc(L, -3, "DOScaleY", new lua_CSFunction(UnityEngineTransformWrap._m_DOScaleY));
			Utils.RegisterFunc(L, -3, "DOScaleZ", new lua_CSFunction(UnityEngineTransformWrap._m_DOScaleZ));
			Utils.RegisterFunc(L, -3, "DOLookAt", new lua_CSFunction(UnityEngineTransformWrap._m_DOLookAt));
			Utils.RegisterFunc(L, -3, "DOPunchPosition", new lua_CSFunction(UnityEngineTransformWrap._m_DOPunchPosition));
			Utils.RegisterFunc(L, -3, "DOPunchScale", new lua_CSFunction(UnityEngineTransformWrap._m_DOPunchScale));
			Utils.RegisterFunc(L, -3, "DOPunchRotation", new lua_CSFunction(UnityEngineTransformWrap._m_DOPunchRotation));
			Utils.RegisterFunc(L, -3, "DOShakePosition", new lua_CSFunction(UnityEngineTransformWrap._m_DOShakePosition));
			Utils.RegisterFunc(L, -3, "DOShakeRotation", new lua_CSFunction(UnityEngineTransformWrap._m_DOShakeRotation));
			Utils.RegisterFunc(L, -3, "DOShakeScale", new lua_CSFunction(UnityEngineTransformWrap._m_DOShakeScale));
			Utils.RegisterFunc(L, -3, "DOJump", new lua_CSFunction(UnityEngineTransformWrap._m_DOJump));
			Utils.RegisterFunc(L, -3, "DOLocalJump", new lua_CSFunction(UnityEngineTransformWrap._m_DOLocalJump));
			Utils.RegisterFunc(L, -3, "DOPath", new lua_CSFunction(UnityEngineTransformWrap._m_DOPath));
			Utils.RegisterFunc(L, -3, "DOLocalPath", new lua_CSFunction(UnityEngineTransformWrap._m_DOLocalPath));
			Utils.RegisterFunc(L, -3, "DOBlendableMoveBy", new lua_CSFunction(UnityEngineTransformWrap._m_DOBlendableMoveBy));
			Utils.RegisterFunc(L, -3, "DOBlendableLocalMoveBy", new lua_CSFunction(UnityEngineTransformWrap._m_DOBlendableLocalMoveBy));
			Utils.RegisterFunc(L, -3, "DOBlendableRotateBy", new lua_CSFunction(UnityEngineTransformWrap._m_DOBlendableRotateBy));
			Utils.RegisterFunc(L, -3, "DOBlendableLocalRotateBy", new lua_CSFunction(UnityEngineTransformWrap._m_DOBlendableLocalRotateBy));
			Utils.RegisterFunc(L, -3, "DOBlendablePunchRotation", new lua_CSFunction(UnityEngineTransformWrap._m_DOBlendablePunchRotation));
			Utils.RegisterFunc(L, -3, "DOBlendableScaleBy", new lua_CSFunction(UnityEngineTransformWrap._m_DOBlendableScaleBy));
			Utils.RegisterFunc(L, -2, "position", new lua_CSFunction(UnityEngineTransformWrap._g_get_position));
			Utils.RegisterFunc(L, -2, "localPosition", new lua_CSFunction(UnityEngineTransformWrap._g_get_localPosition));
			Utils.RegisterFunc(L, -2, "eulerAngles", new lua_CSFunction(UnityEngineTransformWrap._g_get_eulerAngles));
			Utils.RegisterFunc(L, -2, "localEulerAngles", new lua_CSFunction(UnityEngineTransformWrap._g_get_localEulerAngles));
			Utils.RegisterFunc(L, -2, "right", new lua_CSFunction(UnityEngineTransformWrap._g_get_right));
			Utils.RegisterFunc(L, -2, "up", new lua_CSFunction(UnityEngineTransformWrap._g_get_up));
			Utils.RegisterFunc(L, -2, "forward", new lua_CSFunction(UnityEngineTransformWrap._g_get_forward));
			Utils.RegisterFunc(L, -2, "rotation", new lua_CSFunction(UnityEngineTransformWrap._g_get_rotation));
			Utils.RegisterFunc(L, -2, "localRotation", new lua_CSFunction(UnityEngineTransformWrap._g_get_localRotation));
			Utils.RegisterFunc(L, -2, "localScale", new lua_CSFunction(UnityEngineTransformWrap._g_get_localScale));
			Utils.RegisterFunc(L, -2, "parent", new lua_CSFunction(UnityEngineTransformWrap._g_get_parent));
			Utils.RegisterFunc(L, -2, "worldToLocalMatrix", new lua_CSFunction(UnityEngineTransformWrap._g_get_worldToLocalMatrix));
			Utils.RegisterFunc(L, -2, "localToWorldMatrix", new lua_CSFunction(UnityEngineTransformWrap._g_get_localToWorldMatrix));
			Utils.RegisterFunc(L, -2, "root", new lua_CSFunction(UnityEngineTransformWrap._g_get_root));
			Utils.RegisterFunc(L, -2, "childCount", new lua_CSFunction(UnityEngineTransformWrap._g_get_childCount));
			Utils.RegisterFunc(L, -2, "lossyScale", new lua_CSFunction(UnityEngineTransformWrap._g_get_lossyScale));
			Utils.RegisterFunc(L, -2, "hasChanged", new lua_CSFunction(UnityEngineTransformWrap._g_get_hasChanged));
			Utils.RegisterFunc(L, -2, "hierarchyCapacity", new lua_CSFunction(UnityEngineTransformWrap._g_get_hierarchyCapacity));
			Utils.RegisterFunc(L, -2, "hierarchyCount", new lua_CSFunction(UnityEngineTransformWrap._g_get_hierarchyCount));
			Utils.RegisterFunc(L, -1, "position", new lua_CSFunction(UnityEngineTransformWrap._s_set_position));
			Utils.RegisterFunc(L, -1, "localPosition", new lua_CSFunction(UnityEngineTransformWrap._s_set_localPosition));
			Utils.RegisterFunc(L, -1, "eulerAngles", new lua_CSFunction(UnityEngineTransformWrap._s_set_eulerAngles));
			Utils.RegisterFunc(L, -1, "localEulerAngles", new lua_CSFunction(UnityEngineTransformWrap._s_set_localEulerAngles));
			Utils.RegisterFunc(L, -1, "right", new lua_CSFunction(UnityEngineTransformWrap._s_set_right));
			Utils.RegisterFunc(L, -1, "up", new lua_CSFunction(UnityEngineTransformWrap._s_set_up));
			Utils.RegisterFunc(L, -1, "forward", new lua_CSFunction(UnityEngineTransformWrap._s_set_forward));
			Utils.RegisterFunc(L, -1, "rotation", new lua_CSFunction(UnityEngineTransformWrap._s_set_rotation));
			Utils.RegisterFunc(L, -1, "localRotation", new lua_CSFunction(UnityEngineTransformWrap._s_set_localRotation));
			Utils.RegisterFunc(L, -1, "localScale", new lua_CSFunction(UnityEngineTransformWrap._s_set_localScale));
			Utils.RegisterFunc(L, -1, "parent", new lua_CSFunction(UnityEngineTransformWrap._s_set_parent));
			Utils.RegisterFunc(L, -1, "hasChanged", new lua_CSFunction(UnityEngineTransformWrap._s_set_hasChanged));
			Utils.RegisterFunc(L, -1, "hierarchyCapacity", new lua_CSFunction(UnityEngineTransformWrap._s_set_hierarchyCapacity));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineTransformWrap.__CreateInstance), 1, 0, 0);
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			return Lua.luaL_error(L, "UnityEngine.Transform does not have a constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetParent(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Transform>(L, 2))
				{
					Transform parent = (Transform)objectTranslator.GetObject(L, 2, typeof(Transform));
					transform.SetParent(parent);
					return 0;
				}
				if (num == 3 && objectTranslator.Assignable<Transform>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					Transform parent2 = (Transform)objectTranslator.GetObject(L, 2, typeof(Transform));
					bool worldPositionStays = Lua.lua_toboolean(L, 3);
					transform.SetParent(parent2, worldPositionStays);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.SetParent!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetPositionAndRotation(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Vector3 position;
				objectTranslator.Get(L, 2, out position);
				Quaternion rotation;
				objectTranslator.Get(L, 3, out rotation);
				transform.SetPositionAndRotation(position, rotation);
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Translate(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float x = (float)Lua.lua_tonumber(L, 2);
					float y = (float)Lua.lua_tonumber(L, 3);
					float z = (float)Lua.lua_tonumber(L, 4);
					transform.Translate(x, y, z);
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 translation;
					objectTranslator.Get(L, 2, out translation);
					transform.Translate(translation);
					return 0;
				}
				if (num == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && objectTranslator.Assignable<Space>(L, 5))
				{
					float x2 = (float)Lua.lua_tonumber(L, 2);
					float y2 = (float)Lua.lua_tonumber(L, 3);
					float z2 = (float)Lua.lua_tonumber(L, 4);
					Space relativeTo;
					objectTranslator.Get<Space>(L, 5, out relativeTo);
					transform.Translate(x2, y2, z2, relativeTo);
					return 0;
				}
				if (num == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && objectTranslator.Assignable<Transform>(L, 5))
				{
					float x3 = (float)Lua.lua_tonumber(L, 2);
					float y3 = (float)Lua.lua_tonumber(L, 3);
					float z3 = (float)Lua.lua_tonumber(L, 4);
					Transform relativeTo2 = (Transform)objectTranslator.GetObject(L, 5, typeof(Transform));
					transform.Translate(x3, y3, z3, relativeTo2);
					return 0;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Space>(L, 3))
				{
					Vector3 translation2;
					objectTranslator.Get(L, 2, out translation2);
					Space relativeTo3;
					objectTranslator.Get<Space>(L, 3, out relativeTo3);
					transform.Translate(translation2, relativeTo3);
					return 0;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Transform>(L, 3))
				{
					Vector3 translation3;
					objectTranslator.Get(L, 2, out translation3);
					Transform relativeTo4 = (Transform)objectTranslator.GetObject(L, 3, typeof(Transform));
					transform.Translate(translation3, relativeTo4);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.Translate!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Rotate(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float xAngle = (float)Lua.lua_tonumber(L, 2);
					float yAngle = (float)Lua.lua_tonumber(L, 3);
					float zAngle = (float)Lua.lua_tonumber(L, 4);
					transform.Rotate(xAngle, yAngle, zAngle);
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 eulers;
					objectTranslator.Get(L, 2, out eulers);
					transform.Rotate(eulers);
					return 0;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 axis;
					objectTranslator.Get(L, 2, out axis);
					float angle = (float)Lua.lua_tonumber(L, 3);
					transform.Rotate(axis, angle);
					return 0;
				}
				if (num == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && objectTranslator.Assignable<Space>(L, 5))
				{
					float xAngle2 = (float)Lua.lua_tonumber(L, 2);
					float yAngle2 = (float)Lua.lua_tonumber(L, 3);
					float zAngle2 = (float)Lua.lua_tonumber(L, 4);
					Space relativeTo;
					objectTranslator.Get<Space>(L, 5, out relativeTo);
					transform.Rotate(xAngle2, yAngle2, zAngle2, relativeTo);
					return 0;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Space>(L, 3))
				{
					Vector3 eulers2;
					objectTranslator.Get(L, 2, out eulers2);
					Space relativeTo2;
					objectTranslator.Get<Space>(L, 3, out relativeTo2);
					transform.Rotate(eulers2, relativeTo2);
					return 0;
				}
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<Space>(L, 4))
				{
					Vector3 axis2;
					objectTranslator.Get(L, 2, out axis2);
					float angle2 = (float)Lua.lua_tonumber(L, 3);
					Space relativeTo3;
					objectTranslator.Get<Space>(L, 4, out relativeTo3);
					transform.Rotate(axis2, angle2, relativeTo3);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.Rotate!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_RotateAround(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Vector3 point;
				objectTranslator.Get(L, 2, out point);
				Vector3 axis;
				objectTranslator.Get(L, 3, out axis);
				float angle = (float)Lua.lua_tonumber(L, 4);
				transform.RotateAround(point, axis, angle);
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_LookAt(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Transform>(L, 2))
				{
					Transform target = (Transform)objectTranslator.GetObject(L, 2, typeof(Transform));
					transform.LookAt(target);
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 worldPosition;
					objectTranslator.Get(L, 2, out worldPosition);
					transform.LookAt(worldPosition);
					return 0;
				}
				if (num == 3 && objectTranslator.Assignable<Transform>(L, 2) && objectTranslator.Assignable<Vector3>(L, 3))
				{
					Transform target2 = (Transform)objectTranslator.GetObject(L, 2, typeof(Transform));
					Vector3 worldUp;
					objectTranslator.Get(L, 3, out worldUp);
					transform.LookAt(target2, worldUp);
					return 0;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Vector3>(L, 3))
				{
					Vector3 worldPosition2;
					objectTranslator.Get(L, 2, out worldPosition2);
					Vector3 worldUp2;
					objectTranslator.Get(L, 3, out worldUp2);
					transform.LookAt(worldPosition2, worldUp2);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.LookAt!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_TransformDirection(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float x = (float)Lua.lua_tonumber(L, 2);
					float y = (float)Lua.lua_tonumber(L, 3);
					float z = (float)Lua.lua_tonumber(L, 4);
					Vector3 val = transform.TransformDirection(x, y, z);
					objectTranslator.PushUnityEngineVector3(L, val);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 direction;
					objectTranslator.Get(L, 2, out direction);
					Vector3 val2 = transform.TransformDirection(direction);
					objectTranslator.PushUnityEngineVector3(L, val2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.TransformDirection!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_InverseTransformDirection(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float x = (float)Lua.lua_tonumber(L, 2);
					float y = (float)Lua.lua_tonumber(L, 3);
					float z = (float)Lua.lua_tonumber(L, 4);
					Vector3 val = transform.InverseTransformDirection(x, y, z);
					objectTranslator.PushUnityEngineVector3(L, val);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 direction;
					objectTranslator.Get(L, 2, out direction);
					Vector3 val2 = transform.InverseTransformDirection(direction);
					objectTranslator.PushUnityEngineVector3(L, val2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.InverseTransformDirection!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_TransformVector(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float x = (float)Lua.lua_tonumber(L, 2);
					float y = (float)Lua.lua_tonumber(L, 3);
					float z = (float)Lua.lua_tonumber(L, 4);
					Vector3 val = transform.TransformVector(x, y, z);
					objectTranslator.PushUnityEngineVector3(L, val);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 vector;
					objectTranslator.Get(L, 2, out vector);
					Vector3 val2 = transform.TransformVector(vector);
					objectTranslator.PushUnityEngineVector3(L, val2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.TransformVector!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_InverseTransformVector(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float x = (float)Lua.lua_tonumber(L, 2);
					float y = (float)Lua.lua_tonumber(L, 3);
					float z = (float)Lua.lua_tonumber(L, 4);
					Vector3 val = transform.InverseTransformVector(x, y, z);
					objectTranslator.PushUnityEngineVector3(L, val);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 vector;
					objectTranslator.Get(L, 2, out vector);
					Vector3 val2 = transform.InverseTransformVector(vector);
					objectTranslator.PushUnityEngineVector3(L, val2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.InverseTransformVector!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_TransformPoint(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float x = (float)Lua.lua_tonumber(L, 2);
					float y = (float)Lua.lua_tonumber(L, 3);
					float z = (float)Lua.lua_tonumber(L, 4);
					Vector3 val = transform.TransformPoint(x, y, z);
					objectTranslator.PushUnityEngineVector3(L, val);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 position;
					objectTranslator.Get(L, 2, out position);
					Vector3 val2 = transform.TransformPoint(position);
					objectTranslator.PushUnityEngineVector3(L, val2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.TransformPoint!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_InverseTransformPoint(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float x = (float)Lua.lua_tonumber(L, 2);
					float y = (float)Lua.lua_tonumber(L, 3);
					float z = (float)Lua.lua_tonumber(L, 4);
					Vector3 val = transform.InverseTransformPoint(x, y, z);
					objectTranslator.PushUnityEngineVector3(L, val);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 position;
					objectTranslator.Get(L, 2, out position);
					Vector3 val2 = transform.InverseTransformPoint(position);
					objectTranslator.PushUnityEngineVector3(L, val2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.InverseTransformPoint!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DetachChildren(IntPtr L)
		{
			int result;
			try
			{
				((Transform)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DetachChildren();
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetAsFirstSibling(IntPtr L)
		{
			int result;
			try
			{
				((Transform)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).SetAsFirstSibling();
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetAsLastSibling(IntPtr L)
		{
			int result;
			try
			{
				((Transform)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).SetAsLastSibling();
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetSiblingIndex(IntPtr L)
		{
			int result;
			try
			{
				Transform transform = (Transform)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int siblingIndex = Lua.xlua_tointeger(L, 2);
				transform.SetSiblingIndex(siblingIndex);
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetSiblingIndex(IntPtr L)
		{
			int result;
			try
			{
				int siblingIndex = ((Transform)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).GetSiblingIndex();
				Lua.xlua_pushinteger(L, siblingIndex);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Find(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				string n = Lua.lua_tostring(L, 2);
				Transform o = transform.Find(n);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_IsChildOf(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Transform parent = (Transform)objectTranslator.GetObject(L, 2, typeof(Transform));
				bool value = transform.IsChildOf(parent);
				Lua.lua_pushboolean(L, value);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetEnumerator(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				IEnumerator enumerator = ((Transform)objectTranslator.FastGetCSObj(L, 1)).GetEnumerator();
				objectTranslator.PushAny(L, enumerator);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetChild(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int index = Lua.xlua_tointeger(L, 2);
				Transform child = transform.GetChild(index);
				objectTranslator.Push(L, child);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOMove(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 4))
				{
					Vector3 endValue;
					objectTranslator.Get(L, 2, out endValue);
					float duration = (float)Lua.lua_tonumber(L, 3);
					bool snapping = Lua.lua_toboolean(L, 4);
					TweenerCore<Vector3, Vector3, VectorOptions> o = target.DOMove(endValue, duration, snapping);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 endValue2;
					objectTranslator.Get(L, 2, out endValue2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Vector3, VectorOptions> o2 = target.DOMove(endValue2, duration2, false);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOMove!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOMoveX(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 4))
				{
					float endValue = (float)Lua.lua_tonumber(L, 2);
					float duration = (float)Lua.lua_tonumber(L, 3);
					bool snapping = Lua.lua_toboolean(L, 4);
					TweenerCore<Vector3, Vector3, VectorOptions> o = target.DOMoveX(endValue, duration, snapping);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float endValue2 = (float)Lua.lua_tonumber(L, 2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Vector3, VectorOptions> o2 = target.DOMoveX(endValue2, duration2, false);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOMoveX!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOMoveY(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 4))
				{
					float endValue = (float)Lua.lua_tonumber(L, 2);
					float duration = (float)Lua.lua_tonumber(L, 3);
					bool snapping = Lua.lua_toboolean(L, 4);
					TweenerCore<Vector3, Vector3, VectorOptions> o = target.DOMoveY(endValue, duration, snapping);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float endValue2 = (float)Lua.lua_tonumber(L, 2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Vector3, VectorOptions> o2 = target.DOMoveY(endValue2, duration2, false);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOMoveY!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOMoveZ(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 4))
				{
					float endValue = (float)Lua.lua_tonumber(L, 2);
					float duration = (float)Lua.lua_tonumber(L, 3);
					bool snapping = Lua.lua_toboolean(L, 4);
					TweenerCore<Vector3, Vector3, VectorOptions> o = target.DOMoveZ(endValue, duration, snapping);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float endValue2 = (float)Lua.lua_tonumber(L, 2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Vector3, VectorOptions> o2 = target.DOMoveZ(endValue2, duration2, false);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOMoveZ!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOLocalMove(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 4))
				{
					Vector3 endValue;
					objectTranslator.Get(L, 2, out endValue);
					float duration = (float)Lua.lua_tonumber(L, 3);
					bool snapping = Lua.lua_toboolean(L, 4);
					TweenerCore<Vector3, Vector3, VectorOptions> o = target.DOLocalMove(endValue, duration, snapping);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 endValue2;
					objectTranslator.Get(L, 2, out endValue2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Vector3, VectorOptions> o2 = target.DOLocalMove(endValue2, duration2, false);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOLocalMove!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOLocalMoveX(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 4))
				{
					float endValue = (float)Lua.lua_tonumber(L, 2);
					float duration = (float)Lua.lua_tonumber(L, 3);
					bool snapping = Lua.lua_toboolean(L, 4);
					TweenerCore<Vector3, Vector3, VectorOptions> o = target.DOLocalMoveX(endValue, duration, snapping);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float endValue2 = (float)Lua.lua_tonumber(L, 2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Vector3, VectorOptions> o2 = target.DOLocalMoveX(endValue2, duration2, false);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOLocalMoveX!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOLocalMoveY(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 4))
				{
					float endValue = (float)Lua.lua_tonumber(L, 2);
					float duration = (float)Lua.lua_tonumber(L, 3);
					bool snapping = Lua.lua_toboolean(L, 4);
					TweenerCore<Vector3, Vector3, VectorOptions> o = target.DOLocalMoveY(endValue, duration, snapping);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float endValue2 = (float)Lua.lua_tonumber(L, 2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Vector3, VectorOptions> o2 = target.DOLocalMoveY(endValue2, duration2, false);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOLocalMoveY!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOLocalMoveZ(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 4))
				{
					float endValue = (float)Lua.lua_tonumber(L, 2);
					float duration = (float)Lua.lua_tonumber(L, 3);
					bool snapping = Lua.lua_toboolean(L, 4);
					TweenerCore<Vector3, Vector3, VectorOptions> o = target.DOLocalMoveZ(endValue, duration, snapping);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float endValue2 = (float)Lua.lua_tonumber(L, 2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Vector3, VectorOptions> o2 = target.DOLocalMoveZ(endValue2, duration2, false);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOLocalMoveZ!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DORotate(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<RotateMode>(L, 4))
				{
					Vector3 endValue;
					objectTranslator.Get(L, 2, out endValue);
					float duration = (float)Lua.lua_tonumber(L, 3);
					RotateMode mode;
					objectTranslator.Get(L, 4, out mode);
					TweenerCore<Quaternion, Vector3, QuaternionOptions> o = target.DORotate(endValue, duration, mode);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 endValue2;
					objectTranslator.Get(L, 2, out endValue2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Quaternion, Vector3, QuaternionOptions> o2 = target.DORotate(endValue2, duration2, RotateMode.Fast);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DORotate!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DORotateQuaternion(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Quaternion endValue;
				objectTranslator.Get(L, 2, out endValue);
				float duration = (float)Lua.lua_tonumber(L, 3);
				TweenerCore<Quaternion, Quaternion, NoOptions> o = target.DORotateQuaternion(endValue, duration);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOLocalRotate(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<RotateMode>(L, 4))
				{
					Vector3 endValue;
					objectTranslator.Get(L, 2, out endValue);
					float duration = (float)Lua.lua_tonumber(L, 3);
					RotateMode mode;
					objectTranslator.Get(L, 4, out mode);
					TweenerCore<Quaternion, Vector3, QuaternionOptions> o = target.DOLocalRotate(endValue, duration, mode);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 endValue2;
					objectTranslator.Get(L, 2, out endValue2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Quaternion, Vector3, QuaternionOptions> o2 = target.DOLocalRotate(endValue2, duration2, RotateMode.Fast);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOLocalRotate!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOLocalRotateQuaternion(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Quaternion endValue;
				objectTranslator.Get(L, 2, out endValue);
				float duration = (float)Lua.lua_tonumber(L, 3);
				TweenerCore<Quaternion, Quaternion, NoOptions> o = target.DOLocalRotateQuaternion(endValue, duration);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOScale(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float endValue = (float)Lua.lua_tonumber(L, 2);
					float duration = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Vector3, VectorOptions> o = target.DOScale(endValue, duration);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 endValue2;
					objectTranslator.Get(L, 2, out endValue2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Vector3, VectorOptions> o2 = target.DOScale(endValue2, duration2);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOScale!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOScaleX(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				float endValue = (float)Lua.lua_tonumber(L, 2);
				float duration = (float)Lua.lua_tonumber(L, 3);
				TweenerCore<Vector3, Vector3, VectorOptions> o = target.DOScaleX(endValue, duration);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOScaleY(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				float endValue = (float)Lua.lua_tonumber(L, 2);
				float duration = (float)Lua.lua_tonumber(L, 3);
				TweenerCore<Vector3, Vector3, VectorOptions> o = target.DOScaleY(endValue, duration);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOScaleZ(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				float endValue = (float)Lua.lua_tonumber(L, 2);
				float duration = (float)Lua.lua_tonumber(L, 3);
				TweenerCore<Vector3, Vector3, VectorOptions> o = target.DOScaleZ(endValue, duration);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOLookAt(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 5 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<AxisConstraint>(L, 4) && objectTranslator.Assignable<Vector3?>(L, 5))
				{
					Vector3 towards;
					objectTranslator.Get(L, 2, out towards);
					float duration = (float)Lua.lua_tonumber(L, 3);
					AxisConstraint axisConstraint;
					objectTranslator.Get(L, 4, out axisConstraint);
					Vector3? up;
					objectTranslator.Get<Vector3?>(L, 5, out up);
					Tweener o = target.DOLookAt(towards, duration, axisConstraint, up);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<AxisConstraint>(L, 4))
				{
					Vector3 towards2;
					objectTranslator.Get(L, 2, out towards2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					AxisConstraint axisConstraint2;
					objectTranslator.Get(L, 4, out axisConstraint2);
					Tweener o2 = target.DOLookAt(towards2, duration2, axisConstraint2, null);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 towards3;
					objectTranslator.Get(L, 2, out towards3);
					float duration3 = (float)Lua.lua_tonumber(L, 3);
					Tweener o3 = target.DOLookAt(towards3, duration3, AxisConstraint.None, null);
					objectTranslator.Push(L, o3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOLookAt!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOPunchPosition(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 6 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 6))
				{
					Vector3 punch;
					objectTranslator.Get(L, 2, out punch);
					float duration = (float)Lua.lua_tonumber(L, 3);
					int vibrato = Lua.xlua_tointeger(L, 4);
					float elasticity = (float)Lua.lua_tonumber(L, 5);
					bool snapping = Lua.lua_toboolean(L, 6);
					Tweener o = target.DOPunchPosition(punch, duration, vibrato, elasticity, snapping);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 5 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					Vector3 punch2;
					objectTranslator.Get(L, 2, out punch2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					int vibrato2 = Lua.xlua_tointeger(L, 4);
					float elasticity2 = (float)Lua.lua_tonumber(L, 5);
					Tweener o2 = target.DOPunchPosition(punch2, duration2, vibrato2, elasticity2, false);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					Vector3 punch3;
					objectTranslator.Get(L, 2, out punch3);
					float duration3 = (float)Lua.lua_tonumber(L, 3);
					int vibrato3 = Lua.xlua_tointeger(L, 4);
					Tweener o3 = target.DOPunchPosition(punch3, duration3, vibrato3, 1f, false);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 punch4;
					objectTranslator.Get(L, 2, out punch4);
					float duration4 = (float)Lua.lua_tonumber(L, 3);
					Tweener o4 = target.DOPunchPosition(punch4, duration4, 10, 1f, false);
					objectTranslator.Push(L, o4);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOPunchPosition!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOPunchScale(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 5 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					Vector3 punch;
					objectTranslator.Get(L, 2, out punch);
					float duration = (float)Lua.lua_tonumber(L, 3);
					int vibrato = Lua.xlua_tointeger(L, 4);
					float elasticity = (float)Lua.lua_tonumber(L, 5);
					Tweener o = target.DOPunchScale(punch, duration, vibrato, elasticity);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					Vector3 punch2;
					objectTranslator.Get(L, 2, out punch2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					int vibrato2 = Lua.xlua_tointeger(L, 4);
					Tweener o2 = target.DOPunchScale(punch2, duration2, vibrato2, 1f);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 punch3;
					objectTranslator.Get(L, 2, out punch3);
					float duration3 = (float)Lua.lua_tonumber(L, 3);
					Tweener o3 = target.DOPunchScale(punch3, duration3, 10, 1f);
					objectTranslator.Push(L, o3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOPunchScale!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOPunchRotation(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 5 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					Vector3 punch;
					objectTranslator.Get(L, 2, out punch);
					float duration = (float)Lua.lua_tonumber(L, 3);
					int vibrato = Lua.xlua_tointeger(L, 4);
					float elasticity = (float)Lua.lua_tonumber(L, 5);
					Tweener o = target.DOPunchRotation(punch, duration, vibrato, elasticity);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					Vector3 punch2;
					objectTranslator.Get(L, 2, out punch2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					int vibrato2 = Lua.xlua_tointeger(L, 4);
					Tweener o2 = target.DOPunchRotation(punch2, duration2, vibrato2, 1f);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 punch3;
					objectTranslator.Get(L, 2, out punch3);
					float duration3 = (float)Lua.lua_tonumber(L, 3);
					Tweener o3 = target.DOPunchRotation(punch3, duration3, 10, 1f);
					objectTranslator.Push(L, o3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOPunchRotation!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOShakePosition(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 7 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 6) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 7))
				{
					float duration = (float)Lua.lua_tonumber(L, 2);
					float strength = (float)Lua.lua_tonumber(L, 3);
					int vibrato = Lua.xlua_tointeger(L, 4);
					float randomness = (float)Lua.lua_tonumber(L, 5);
					bool snapping = Lua.lua_toboolean(L, 6);
					bool fadeOut = Lua.lua_toboolean(L, 7);
					Tweener o = target.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeOut);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 6 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 6))
				{
					float duration2 = (float)Lua.lua_tonumber(L, 2);
					float strength2 = (float)Lua.lua_tonumber(L, 3);
					int vibrato2 = Lua.xlua_tointeger(L, 4);
					float randomness2 = (float)Lua.lua_tonumber(L, 5);
					bool snapping2 = Lua.lua_toboolean(L, 6);
					Tweener o2 = target.DOShakePosition(duration2, strength2, vibrato2, randomness2, snapping2, true);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					float duration3 = (float)Lua.lua_tonumber(L, 2);
					float strength3 = (float)Lua.lua_tonumber(L, 3);
					int vibrato3 = Lua.xlua_tointeger(L, 4);
					float randomness3 = (float)Lua.lua_tonumber(L, 5);
					Tweener o3 = target.DOShakePosition(duration3, strength3, vibrato3, randomness3, false, true);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float duration4 = (float)Lua.lua_tonumber(L, 2);
					float strength4 = (float)Lua.lua_tonumber(L, 3);
					int vibrato4 = Lua.xlua_tointeger(L, 4);
					Tweener o4 = target.DOShakePosition(duration4, strength4, vibrato4, 90f, false, true);
					objectTranslator.Push(L, o4);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float duration5 = (float)Lua.lua_tonumber(L, 2);
					float strength5 = (float)Lua.lua_tonumber(L, 3);
					Tweener o5 = target.DOShakePosition(duration5, strength5, 10, 90f, false, true);
					objectTranslator.Push(L, o5);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					float duration6 = (float)Lua.lua_tonumber(L, 2);
					Tweener o6 = target.DOShakePosition(duration6, 1f, 10, 90f, false, true);
					objectTranslator.Push(L, o6);
					return 1;
				}
				if (num == 7 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 6) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 7))
				{
					float duration7 = (float)Lua.lua_tonumber(L, 2);
					Vector3 strength6;
					objectTranslator.Get(L, 3, out strength6);
					int vibrato5 = Lua.xlua_tointeger(L, 4);
					float randomness4 = (float)Lua.lua_tonumber(L, 5);
					bool snapping3 = Lua.lua_toboolean(L, 6);
					bool fadeOut2 = Lua.lua_toboolean(L, 7);
					Tweener o7 = target.DOShakePosition(duration7, strength6, vibrato5, randomness4, snapping3, fadeOut2);
					objectTranslator.Push(L, o7);
					return 1;
				}
				if (num == 6 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 6))
				{
					float duration8 = (float)Lua.lua_tonumber(L, 2);
					Vector3 strength7;
					objectTranslator.Get(L, 3, out strength7);
					int vibrato6 = Lua.xlua_tointeger(L, 4);
					float randomness5 = (float)Lua.lua_tonumber(L, 5);
					bool snapping4 = Lua.lua_toboolean(L, 6);
					Tweener o8 = target.DOShakePosition(duration8, strength7, vibrato6, randomness5, snapping4, true);
					objectTranslator.Push(L, o8);
					return 1;
				}
				if (num == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					float duration9 = (float)Lua.lua_tonumber(L, 2);
					Vector3 strength8;
					objectTranslator.Get(L, 3, out strength8);
					int vibrato7 = Lua.xlua_tointeger(L, 4);
					float randomness6 = (float)Lua.lua_tonumber(L, 5);
					Tweener o9 = target.DOShakePosition(duration9, strength8, vibrato7, randomness6, false, true);
					objectTranslator.Push(L, o9);
					return 1;
				}
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float duration10 = (float)Lua.lua_tonumber(L, 2);
					Vector3 strength9;
					objectTranslator.Get(L, 3, out strength9);
					int vibrato8 = Lua.xlua_tointeger(L, 4);
					Tweener o10 = target.DOShakePosition(duration10, strength9, vibrato8, 90f, false, true);
					objectTranslator.Push(L, o10);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<Vector3>(L, 3))
				{
					float duration11 = (float)Lua.lua_tonumber(L, 2);
					Vector3 strength10;
					objectTranslator.Get(L, 3, out strength10);
					Tweener o11 = target.DOShakePosition(duration11, strength10, 10, 90f, false, true);
					objectTranslator.Push(L, o11);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOShakePosition!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOShakeRotation(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 6 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 6))
				{
					float duration = (float)Lua.lua_tonumber(L, 2);
					float strength = (float)Lua.lua_tonumber(L, 3);
					int vibrato = Lua.xlua_tointeger(L, 4);
					float randomness = (float)Lua.lua_tonumber(L, 5);
					bool fadeOut = Lua.lua_toboolean(L, 6);
					Tweener o = target.DOShakeRotation(duration, strength, vibrato, randomness, fadeOut);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					float duration2 = (float)Lua.lua_tonumber(L, 2);
					float strength2 = (float)Lua.lua_tonumber(L, 3);
					int vibrato2 = Lua.xlua_tointeger(L, 4);
					float randomness2 = (float)Lua.lua_tonumber(L, 5);
					Tweener o2 = target.DOShakeRotation(duration2, strength2, vibrato2, randomness2, true);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float duration3 = (float)Lua.lua_tonumber(L, 2);
					float strength3 = (float)Lua.lua_tonumber(L, 3);
					int vibrato3 = Lua.xlua_tointeger(L, 4);
					Tweener o3 = target.DOShakeRotation(duration3, strength3, vibrato3, 90f, true);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float duration4 = (float)Lua.lua_tonumber(L, 2);
					float strength4 = (float)Lua.lua_tonumber(L, 3);
					Tweener o4 = target.DOShakeRotation(duration4, strength4, 10, 90f, true);
					objectTranslator.Push(L, o4);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					float duration5 = (float)Lua.lua_tonumber(L, 2);
					Tweener o5 = target.DOShakeRotation(duration5, 90f, 10, 90f, true);
					objectTranslator.Push(L, o5);
					return 1;
				}
				if (num == 6 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 6))
				{
					float duration6 = (float)Lua.lua_tonumber(L, 2);
					Vector3 strength5;
					objectTranslator.Get(L, 3, out strength5);
					int vibrato4 = Lua.xlua_tointeger(L, 4);
					float randomness3 = (float)Lua.lua_tonumber(L, 5);
					bool fadeOut2 = Lua.lua_toboolean(L, 6);
					Tweener o6 = target.DOShakeRotation(duration6, strength5, vibrato4, randomness3, fadeOut2);
					objectTranslator.Push(L, o6);
					return 1;
				}
				if (num == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					float duration7 = (float)Lua.lua_tonumber(L, 2);
					Vector3 strength6;
					objectTranslator.Get(L, 3, out strength6);
					int vibrato5 = Lua.xlua_tointeger(L, 4);
					float randomness4 = (float)Lua.lua_tonumber(L, 5);
					Tweener o7 = target.DOShakeRotation(duration7, strength6, vibrato5, randomness4, true);
					objectTranslator.Push(L, o7);
					return 1;
				}
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float duration8 = (float)Lua.lua_tonumber(L, 2);
					Vector3 strength7;
					objectTranslator.Get(L, 3, out strength7);
					int vibrato6 = Lua.xlua_tointeger(L, 4);
					Tweener o8 = target.DOShakeRotation(duration8, strength7, vibrato6, 90f, true);
					objectTranslator.Push(L, o8);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<Vector3>(L, 3))
				{
					float duration9 = (float)Lua.lua_tonumber(L, 2);
					Vector3 strength8;
					objectTranslator.Get(L, 3, out strength8);
					Tweener o9 = target.DOShakeRotation(duration9, strength8, 10, 90f, true);
					objectTranslator.Push(L, o9);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOShakeRotation!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOShakeScale(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 6 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 6))
				{
					float duration = (float)Lua.lua_tonumber(L, 2);
					float strength = (float)Lua.lua_tonumber(L, 3);
					int vibrato = Lua.xlua_tointeger(L, 4);
					float randomness = (float)Lua.lua_tonumber(L, 5);
					bool fadeOut = Lua.lua_toboolean(L, 6);
					Tweener o = target.DOShakeScale(duration, strength, vibrato, randomness, fadeOut);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					float duration2 = (float)Lua.lua_tonumber(L, 2);
					float strength2 = (float)Lua.lua_tonumber(L, 3);
					int vibrato2 = Lua.xlua_tointeger(L, 4);
					float randomness2 = (float)Lua.lua_tonumber(L, 5);
					Tweener o2 = target.DOShakeScale(duration2, strength2, vibrato2, randomness2, true);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float duration3 = (float)Lua.lua_tonumber(L, 2);
					float strength3 = (float)Lua.lua_tonumber(L, 3);
					int vibrato3 = Lua.xlua_tointeger(L, 4);
					Tweener o3 = target.DOShakeScale(duration3, strength3, vibrato3, 90f, true);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float duration4 = (float)Lua.lua_tonumber(L, 2);
					float strength4 = (float)Lua.lua_tonumber(L, 3);
					Tweener o4 = target.DOShakeScale(duration4, strength4, 10, 90f, true);
					objectTranslator.Push(L, o4);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					float duration5 = (float)Lua.lua_tonumber(L, 2);
					Tweener o5 = target.DOShakeScale(duration5, 1f, 10, 90f, true);
					objectTranslator.Push(L, o5);
					return 1;
				}
				if (num == 6 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 6))
				{
					float duration6 = (float)Lua.lua_tonumber(L, 2);
					Vector3 strength5;
					objectTranslator.Get(L, 3, out strength5);
					int vibrato4 = Lua.xlua_tointeger(L, 4);
					float randomness3 = (float)Lua.lua_tonumber(L, 5);
					bool fadeOut2 = Lua.lua_toboolean(L, 6);
					Tweener o6 = target.DOShakeScale(duration6, strength5, vibrato4, randomness3, fadeOut2);
					objectTranslator.Push(L, o6);
					return 1;
				}
				if (num == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					float duration7 = (float)Lua.lua_tonumber(L, 2);
					Vector3 strength6;
					objectTranslator.Get(L, 3, out strength6);
					int vibrato5 = Lua.xlua_tointeger(L, 4);
					float randomness4 = (float)Lua.lua_tonumber(L, 5);
					Tweener o7 = target.DOShakeScale(duration7, strength6, vibrato5, randomness4, true);
					objectTranslator.Push(L, o7);
					return 1;
				}
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float duration8 = (float)Lua.lua_tonumber(L, 2);
					Vector3 strength7;
					objectTranslator.Get(L, 3, out strength7);
					int vibrato6 = Lua.xlua_tointeger(L, 4);
					Tweener o8 = target.DOShakeScale(duration8, strength7, vibrato6, 90f, true);
					objectTranslator.Push(L, o8);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<Vector3>(L, 3))
				{
					float duration9 = (float)Lua.lua_tonumber(L, 2);
					Vector3 strength8;
					objectTranslator.Get(L, 3, out strength8);
					Tweener o9 = target.DOShakeScale(duration9, strength8, 10, 90f, true);
					objectTranslator.Push(L, o9);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOShakeScale!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOJump(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 6 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 6))
				{
					Vector3 endValue;
					objectTranslator.Get(L, 2, out endValue);
					float jumpPower = (float)Lua.lua_tonumber(L, 3);
					int numJumps = Lua.xlua_tointeger(L, 4);
					float duration = (float)Lua.lua_tonumber(L, 5);
					bool snapping = Lua.lua_toboolean(L, 6);
					Sequence o = target.DOJump(endValue, jumpPower, numJumps, duration, snapping);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 5 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					Vector3 endValue2;
					objectTranslator.Get(L, 2, out endValue2);
					float jumpPower2 = (float)Lua.lua_tonumber(L, 3);
					int numJumps2 = Lua.xlua_tointeger(L, 4);
					float duration2 = (float)Lua.lua_tonumber(L, 5);
					Sequence o2 = target.DOJump(endValue2, jumpPower2, numJumps2, duration2, false);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOJump!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOLocalJump(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 6 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 6))
				{
					Vector3 endValue;
					objectTranslator.Get(L, 2, out endValue);
					float jumpPower = (float)Lua.lua_tonumber(L, 3);
					int numJumps = Lua.xlua_tointeger(L, 4);
					float duration = (float)Lua.lua_tonumber(L, 5);
					bool snapping = Lua.lua_toboolean(L, 6);
					Sequence o = target.DOLocalJump(endValue, jumpPower, numJumps, duration, snapping);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 5 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					Vector3 endValue2;
					objectTranslator.Get(L, 2, out endValue2);
					float jumpPower2 = (float)Lua.lua_tonumber(L, 3);
					int numJumps2 = Lua.xlua_tointeger(L, 4);
					float duration2 = (float)Lua.lua_tonumber(L, 5);
					Sequence o2 = target.DOLocalJump(endValue2, jumpPower2, numJumps2, duration2, false);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOLocalJump!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOPath(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && objectTranslator.Assignable<Path>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<PathMode>(L, 4))
				{
					Path path = (Path)objectTranslator.GetObject(L, 2, typeof(Path));
					float duration = (float)Lua.lua_tonumber(L, 3);
					PathMode pathMode;
					objectTranslator.Get(L, 4, out pathMode);
					TweenerCore<Vector3, Path, PathOptions> o = target.DOPath(path, duration, pathMode);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Path>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Path path2 = (Path)objectTranslator.GetObject(L, 2, typeof(Path));
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Path, PathOptions> o2 = target.DOPath(path2, duration2, PathMode.Full3D);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 7 && objectTranslator.Assignable<Vector3[]>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<PathType>(L, 4) && objectTranslator.Assignable<PathMode>(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6) && objectTranslator.Assignable<Color?>(L, 7))
				{
					Vector3[] path3 = (Vector3[])objectTranslator.GetObject(L, 2, typeof(Vector3[]));
					float duration3 = (float)Lua.lua_tonumber(L, 3);
					PathType pathType;
					objectTranslator.Get(L, 4, out pathType);
					PathMode pathMode2;
					objectTranslator.Get(L, 5, out pathMode2);
					int resolution = Lua.xlua_tointeger(L, 6);
					Color? gizmoColor;
					objectTranslator.Get<Color?>(L, 7, out gizmoColor);
					TweenerCore<Vector3, Path, PathOptions> o3 = target.DOPath(path3, duration3, pathType, pathMode2, resolution, gizmoColor);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 6 && objectTranslator.Assignable<Vector3[]>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<PathType>(L, 4) && objectTranslator.Assignable<PathMode>(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6))
				{
					Vector3[] path4 = (Vector3[])objectTranslator.GetObject(L, 2, typeof(Vector3[]));
					float duration4 = (float)Lua.lua_tonumber(L, 3);
					PathType pathType2;
					objectTranslator.Get(L, 4, out pathType2);
					PathMode pathMode3;
					objectTranslator.Get(L, 5, out pathMode3);
					int resolution2 = Lua.xlua_tointeger(L, 6);
					TweenerCore<Vector3, Path, PathOptions> o4 = target.DOPath(path4, duration4, pathType2, pathMode3, resolution2, null);
					objectTranslator.Push(L, o4);
					return 1;
				}
				if (num == 5 && objectTranslator.Assignable<Vector3[]>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<PathType>(L, 4) && objectTranslator.Assignable<PathMode>(L, 5))
				{
					Vector3[] path5 = (Vector3[])objectTranslator.GetObject(L, 2, typeof(Vector3[]));
					float duration5 = (float)Lua.lua_tonumber(L, 3);
					PathType pathType3;
					objectTranslator.Get(L, 4, out pathType3);
					PathMode pathMode4;
					objectTranslator.Get(L, 5, out pathMode4);
					TweenerCore<Vector3, Path, PathOptions> o5 = target.DOPath(path5, duration5, pathType3, pathMode4, 10, null);
					objectTranslator.Push(L, o5);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<Vector3[]>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<PathType>(L, 4))
				{
					Vector3[] path6 = (Vector3[])objectTranslator.GetObject(L, 2, typeof(Vector3[]));
					float duration6 = (float)Lua.lua_tonumber(L, 3);
					PathType pathType4;
					objectTranslator.Get(L, 4, out pathType4);
					TweenerCore<Vector3, Path, PathOptions> o6 = target.DOPath(path6, duration6, pathType4, PathMode.Full3D, 10, null);
					objectTranslator.Push(L, o6);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3[]>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3[] path7 = (Vector3[])objectTranslator.GetObject(L, 2, typeof(Vector3[]));
					float duration7 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Path, PathOptions> o7 = target.DOPath(path7, duration7, PathType.Linear, PathMode.Full3D, 10, null);
					objectTranslator.Push(L, o7);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOPath!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOLocalPath(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && objectTranslator.Assignable<Path>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<PathMode>(L, 4))
				{
					Path path = (Path)objectTranslator.GetObject(L, 2, typeof(Path));
					float duration = (float)Lua.lua_tonumber(L, 3);
					PathMode pathMode;
					objectTranslator.Get(L, 4, out pathMode);
					TweenerCore<Vector3, Path, PathOptions> o = target.DOLocalPath(path, duration, pathMode);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Path>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Path path2 = (Path)objectTranslator.GetObject(L, 2, typeof(Path));
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Path, PathOptions> o2 = target.DOLocalPath(path2, duration2, PathMode.Full3D);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 7 && objectTranslator.Assignable<Vector3[]>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<PathType>(L, 4) && objectTranslator.Assignable<PathMode>(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6) && objectTranslator.Assignable<Color?>(L, 7))
				{
					Vector3[] path3 = (Vector3[])objectTranslator.GetObject(L, 2, typeof(Vector3[]));
					float duration3 = (float)Lua.lua_tonumber(L, 3);
					PathType pathType;
					objectTranslator.Get(L, 4, out pathType);
					PathMode pathMode2;
					objectTranslator.Get(L, 5, out pathMode2);
					int resolution = Lua.xlua_tointeger(L, 6);
					Color? gizmoColor;
					objectTranslator.Get<Color?>(L, 7, out gizmoColor);
					TweenerCore<Vector3, Path, PathOptions> o3 = target.DOLocalPath(path3, duration3, pathType, pathMode2, resolution, gizmoColor);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 6 && objectTranslator.Assignable<Vector3[]>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<PathType>(L, 4) && objectTranslator.Assignable<PathMode>(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6))
				{
					Vector3[] path4 = (Vector3[])objectTranslator.GetObject(L, 2, typeof(Vector3[]));
					float duration4 = (float)Lua.lua_tonumber(L, 3);
					PathType pathType2;
					objectTranslator.Get(L, 4, out pathType2);
					PathMode pathMode3;
					objectTranslator.Get(L, 5, out pathMode3);
					int resolution2 = Lua.xlua_tointeger(L, 6);
					TweenerCore<Vector3, Path, PathOptions> o4 = target.DOLocalPath(path4, duration4, pathType2, pathMode3, resolution2, null);
					objectTranslator.Push(L, o4);
					return 1;
				}
				if (num == 5 && objectTranslator.Assignable<Vector3[]>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<PathType>(L, 4) && objectTranslator.Assignable<PathMode>(L, 5))
				{
					Vector3[] path5 = (Vector3[])objectTranslator.GetObject(L, 2, typeof(Vector3[]));
					float duration5 = (float)Lua.lua_tonumber(L, 3);
					PathType pathType3;
					objectTranslator.Get(L, 4, out pathType3);
					PathMode pathMode4;
					objectTranslator.Get(L, 5, out pathMode4);
					TweenerCore<Vector3, Path, PathOptions> o5 = target.DOLocalPath(path5, duration5, pathType3, pathMode4, 10, null);
					objectTranslator.Push(L, o5);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<Vector3[]>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<PathType>(L, 4))
				{
					Vector3[] path6 = (Vector3[])objectTranslator.GetObject(L, 2, typeof(Vector3[]));
					float duration6 = (float)Lua.lua_tonumber(L, 3);
					PathType pathType4;
					objectTranslator.Get(L, 4, out pathType4);
					TweenerCore<Vector3, Path, PathOptions> o6 = target.DOLocalPath(path6, duration6, pathType4, PathMode.Full3D, 10, null);
					objectTranslator.Push(L, o6);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3[]>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3[] path7 = (Vector3[])objectTranslator.GetObject(L, 2, typeof(Vector3[]));
					float duration7 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Path, PathOptions> o7 = target.DOLocalPath(path7, duration7, PathType.Linear, PathMode.Full3D, 10, null);
					objectTranslator.Push(L, o7);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOLocalPath!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOBlendableMoveBy(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 4))
				{
					Vector3 byValue;
					objectTranslator.Get(L, 2, out byValue);
					float duration = (float)Lua.lua_tonumber(L, 3);
					bool snapping = Lua.lua_toboolean(L, 4);
					Tweener o = target.DOBlendableMoveBy(byValue, duration, snapping);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 byValue2;
					objectTranslator.Get(L, 2, out byValue2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					Tweener o2 = target.DOBlendableMoveBy(byValue2, duration2, false);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOBlendableMoveBy!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOBlendableLocalMoveBy(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 4))
				{
					Vector3 byValue;
					objectTranslator.Get(L, 2, out byValue);
					float duration = (float)Lua.lua_tonumber(L, 3);
					bool snapping = Lua.lua_toboolean(L, 4);
					Tweener o = target.DOBlendableLocalMoveBy(byValue, duration, snapping);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 byValue2;
					objectTranslator.Get(L, 2, out byValue2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					Tweener o2 = target.DOBlendableLocalMoveBy(byValue2, duration2, false);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOBlendableLocalMoveBy!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOBlendableRotateBy(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<RotateMode>(L, 4))
				{
					Vector3 byValue;
					objectTranslator.Get(L, 2, out byValue);
					float duration = (float)Lua.lua_tonumber(L, 3);
					RotateMode mode;
					objectTranslator.Get(L, 4, out mode);
					Tweener o = target.DOBlendableRotateBy(byValue, duration, mode);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 byValue2;
					objectTranslator.Get(L, 2, out byValue2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					Tweener o2 = target.DOBlendableRotateBy(byValue2, duration2, RotateMode.Fast);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOBlendableRotateBy!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOBlendableLocalRotateBy(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<RotateMode>(L, 4))
				{
					Vector3 byValue;
					objectTranslator.Get(L, 2, out byValue);
					float duration = (float)Lua.lua_tonumber(L, 3);
					RotateMode mode;
					objectTranslator.Get(L, 4, out mode);
					Tweener o = target.DOBlendableLocalRotateBy(byValue, duration, mode);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 byValue2;
					objectTranslator.Get(L, 2, out byValue2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					Tweener o2 = target.DOBlendableLocalRotateBy(byValue2, duration2, RotateMode.Fast);
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOBlendableLocalRotateBy!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOBlendablePunchRotation(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 5 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					Vector3 punch;
					objectTranslator.Get(L, 2, out punch);
					float duration = (float)Lua.lua_tonumber(L, 3);
					int vibrato = Lua.xlua_tointeger(L, 4);
					float elasticity = (float)Lua.lua_tonumber(L, 5);
					Tweener o = target.DOBlendablePunchRotation(punch, duration, vibrato, elasticity);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					Vector3 punch2;
					objectTranslator.Get(L, 2, out punch2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					int vibrato2 = Lua.xlua_tointeger(L, 4);
					Tweener o2 = target.DOBlendablePunchRotation(punch2, duration2, vibrato2, 1f);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 punch3;
					objectTranslator.Get(L, 2, out punch3);
					float duration3 = (float)Lua.lua_tonumber(L, 3);
					Tweener o3 = target.DOBlendablePunchRotation(punch3, duration3, 10, 1f);
					objectTranslator.Push(L, o3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Transform.DOBlendablePunchRotation!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOBlendableScaleBy(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform target = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Vector3 byValue;
				objectTranslator.Get(L, 2, out byValue);
				float duration = (float)Lua.lua_tonumber(L, 3);
				Tweener o = target.DOBlendableScaleBy(byValue, duration);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_position(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushUnityEngineVector3(L, transform.position);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_localPosition(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushUnityEngineVector3(L, transform.localPosition);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_eulerAngles(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushUnityEngineVector3(L, transform.eulerAngles);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_localEulerAngles(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushUnityEngineVector3(L, transform.localEulerAngles);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_right(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushUnityEngineVector3(L, transform.right);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_up(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushUnityEngineVector3(L, transform.up);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_forward(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushUnityEngineVector3(L, transform.forward);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_rotation(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushUnityEngineQuaternion(L, transform.rotation);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_localRotation(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushUnityEngineQuaternion(L, transform.localRotation);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_localScale(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushUnityEngineVector3(L, transform.localScale);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_parent(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, transform.parent);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_worldToLocalMatrix(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, transform.worldToLocalMatrix);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_localToWorldMatrix(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, transform.localToWorldMatrix);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_root(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, transform.root);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_childCount(IntPtr L)
		{
			try
			{
				Transform transform = (Transform)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, transform.childCount);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_lossyScale(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushUnityEngineVector3(L, transform.lossyScale);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_hasChanged(IntPtr L)
		{
			try
			{
				Transform transform = (Transform)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, transform.hasChanged);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_hierarchyCapacity(IntPtr L)
		{
			try
			{
				Transform transform = (Transform)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, transform.hierarchyCapacity);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_hierarchyCount(IntPtr L)
		{
			try
			{
				Transform transform = (Transform)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, transform.hierarchyCount);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_position(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Vector3 position;
				objectTranslator.Get(L, 2, out position);
				transform.position = position;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_localPosition(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Vector3 localPosition;
				objectTranslator.Get(L, 2, out localPosition);
				transform.localPosition = localPosition;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_eulerAngles(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Vector3 eulerAngles;
				objectTranslator.Get(L, 2, out eulerAngles);
				transform.eulerAngles = eulerAngles;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_localEulerAngles(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Vector3 localEulerAngles;
				objectTranslator.Get(L, 2, out localEulerAngles);
				transform.localEulerAngles = localEulerAngles;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_right(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Vector3 right;
				objectTranslator.Get(L, 2, out right);
				transform.right = right;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_up(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Vector3 up;
				objectTranslator.Get(L, 2, out up);
				transform.up = up;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_forward(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Vector3 forward;
				objectTranslator.Get(L, 2, out forward);
				transform.forward = forward;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_rotation(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Quaternion rotation;
				objectTranslator.Get(L, 2, out rotation);
				transform.rotation = rotation;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_localRotation(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Quaternion localRotation;
				objectTranslator.Get(L, 2, out localRotation);
				transform.localRotation = localRotation;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_localScale(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Transform transform = (Transform)objectTranslator.FastGetCSObj(L, 1);
				Vector3 localScale;
				objectTranslator.Get(L, 2, out localScale);
				transform.localScale = localScale;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_parent(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((Transform)objectTranslator.FastGetCSObj(L, 1)).parent = (Transform)objectTranslator.GetObject(L, 2, typeof(Transform));
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_hasChanged(IntPtr L)
		{
			try
			{
				((Transform)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).hasChanged = Lua.lua_toboolean(L, 2);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_hierarchyCapacity(IntPtr L)
		{
			try
			{
				((Transform)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).hierarchyCapacity = Lua.xlua_tointeger(L, 2);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}
	}
}
