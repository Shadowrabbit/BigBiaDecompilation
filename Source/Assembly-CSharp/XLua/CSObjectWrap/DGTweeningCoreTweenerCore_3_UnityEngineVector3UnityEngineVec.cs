using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(TweenerCore<Vector3, Vector3, VectorOptions>);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 28, 6, 6, -1);
			Utils.RegisterFunc(L, -3, "ChangeStartValue", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_ChangeStartValue));
			Utils.RegisterFunc(L, -3, "ChangeEndValue", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_ChangeEndValue));
			Utils.RegisterFunc(L, -3, "ChangeValues", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_ChangeValues));
			Utils.RegisterFunc(L, -3, "Pause", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_Pause));
			Utils.RegisterFunc(L, -3, "Play", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_Play));
			Utils.RegisterFunc(L, -3, "SetAutoKill", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_SetAutoKill));
			Utils.RegisterFunc(L, -3, "SetId", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_SetId));
			Utils.RegisterFunc(L, -3, "SetLink", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_SetLink));
			Utils.RegisterFunc(L, -3, "SetTarget", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_SetTarget));
			Utils.RegisterFunc(L, -3, "SetLoops", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_SetLoops));
			Utils.RegisterFunc(L, -3, "SetEase", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_SetEase));
			Utils.RegisterFunc(L, -3, "SetRecyclable", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_SetRecyclable));
			Utils.RegisterFunc(L, -3, "SetUpdate", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_SetUpdate));
			Utils.RegisterFunc(L, -3, "OnStart", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_OnStart));
			Utils.RegisterFunc(L, -3, "OnPlay", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_OnPlay));
			Utils.RegisterFunc(L, -3, "OnPause", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_OnPause));
			Utils.RegisterFunc(L, -3, "OnRewind", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_OnRewind));
			Utils.RegisterFunc(L, -3, "OnUpdate", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_OnUpdate));
			Utils.RegisterFunc(L, -3, "OnStepComplete", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_OnStepComplete));
			Utils.RegisterFunc(L, -3, "OnComplete", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_OnComplete));
			Utils.RegisterFunc(L, -3, "OnKill", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_OnKill));
			Utils.RegisterFunc(L, -3, "OnWaypointChange", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_OnWaypointChange));
			Utils.RegisterFunc(L, -3, "SetAs", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_SetAs));
			Utils.RegisterFunc(L, -3, "From", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_From));
			Utils.RegisterFunc(L, -3, "SetDelay", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_SetDelay));
			Utils.RegisterFunc(L, -3, "SetRelative", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_SetRelative));
			Utils.RegisterFunc(L, -3, "SetSpeedBased", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_SetSpeedBased));
			Utils.RegisterFunc(L, -3, "SetOptions", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._m_SetOptions));
			Utils.RegisterFunc(L, -2, "startValue", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._g_get_startValue));
			Utils.RegisterFunc(L, -2, "endValue", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._g_get_endValue));
			Utils.RegisterFunc(L, -2, "changeValue", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._g_get_changeValue));
			Utils.RegisterFunc(L, -2, "plugOptions", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._g_get_plugOptions));
			Utils.RegisterFunc(L, -2, "getter", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._g_get_getter));
			Utils.RegisterFunc(L, -2, "setter", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._g_get_setter));
			Utils.RegisterFunc(L, -1, "startValue", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._s_set_startValue));
			Utils.RegisterFunc(L, -1, "endValue", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._s_set_endValue));
			Utils.RegisterFunc(L, -1, "changeValue", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._s_set_changeValue));
			Utils.RegisterFunc(L, -1, "plugOptions", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._s_set_plugOptions));
			Utils.RegisterFunc(L, -1, "getter", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._s_set_getter));
			Utils.RegisterFunc(L, -1, "setter", new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap._s_set_setter));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap.__CreateInstance), 1, 0, 0);
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			return Lua.luaL_error(L, "DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> does not have a constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ChangeStartValue(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 3 && objectTranslator.Assignable<object>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					object @object = objectTranslator.GetObject(L, 2, typeof(object));
					float newDuration = (float)Lua.lua_tonumber(L, 3);
					Tweener o = tweenerCore.ChangeStartValue(@object, newDuration);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 2))
				{
					object object2 = objectTranslator.GetObject(L, 2, typeof(object));
					Tweener o2 = tweenerCore.ChangeStartValue(object2, -1f);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 newStartValue;
					objectTranslator.Get(L, 2, out newStartValue);
					float newDuration2 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Vector3, VectorOptions> o3 = tweenerCore.ChangeStartValue(newStartValue, newDuration2);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 newStartValue2;
					objectTranslator.Get(L, 2, out newStartValue2);
					TweenerCore<Vector3, Vector3, VectorOptions> o4 = tweenerCore.ChangeStartValue(newStartValue2, -1f);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.ChangeStartValue!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ChangeEndValue(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 3 && objectTranslator.Assignable<object>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					object @object = objectTranslator.GetObject(L, 2, typeof(object));
					bool snapStartValue = Lua.lua_toboolean(L, 3);
					Tweener o = tweenerCore.ChangeEndValue(@object, snapStartValue);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					Vector3 newEndValue;
					objectTranslator.Get(L, 2, out newEndValue);
					bool snapStartValue2 = Lua.lua_toboolean(L, 3);
					TweenerCore<Vector3, Vector3, VectorOptions> o2 = tweenerCore.ChangeEndValue(newEndValue, snapStartValue2);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<object>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 4))
				{
					object object2 = objectTranslator.GetObject(L, 2, typeof(object));
					float newDuration = (float)Lua.lua_tonumber(L, 3);
					bool snapStartValue3 = Lua.lua_toboolean(L, 4);
					Tweener o3 = tweenerCore.ChangeEndValue(object2, newDuration, snapStartValue3);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<object>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					object object3 = objectTranslator.GetObject(L, 2, typeof(object));
					float newDuration2 = (float)Lua.lua_tonumber(L, 3);
					Tweener o4 = tweenerCore.ChangeEndValue(object3, newDuration2, false);
					objectTranslator.Push(L, o4);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 2))
				{
					object object4 = objectTranslator.GetObject(L, 2, typeof(object));
					Tweener o5 = tweenerCore.ChangeEndValue(object4, -1f, false);
					objectTranslator.Push(L, o5);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 4))
				{
					Vector3 newEndValue2;
					objectTranslator.Get(L, 2, out newEndValue2);
					float newDuration3 = (float)Lua.lua_tonumber(L, 3);
					bool snapStartValue4 = Lua.lua_toboolean(L, 4);
					TweenerCore<Vector3, Vector3, VectorOptions> o6 = tweenerCore.ChangeEndValue(newEndValue2, newDuration3, snapStartValue4);
					objectTranslator.Push(L, o6);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 newEndValue3;
					objectTranslator.Get(L, 2, out newEndValue3);
					float newDuration4 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Vector3, VectorOptions> o7 = tweenerCore.ChangeEndValue(newEndValue3, newDuration4, false);
					objectTranslator.Push(L, o7);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 newEndValue4;
					objectTranslator.Get(L, 2, out newEndValue4);
					TweenerCore<Vector3, Vector3, VectorOptions> o8 = tweenerCore.ChangeEndValue(newEndValue4, -1f, false);
					objectTranslator.Push(L, o8);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.ChangeEndValue!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ChangeValues(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && objectTranslator.Assignable<object>(L, 2) && objectTranslator.Assignable<object>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					object @object = objectTranslator.GetObject(L, 2, typeof(object));
					object object2 = objectTranslator.GetObject(L, 3, typeof(object));
					float newDuration = (float)Lua.lua_tonumber(L, 4);
					Tweener o = tweenerCore.ChangeValues(@object, object2, newDuration);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<object>(L, 2) && objectTranslator.Assignable<object>(L, 3))
				{
					object object3 = objectTranslator.GetObject(L, 2, typeof(object));
					object object4 = objectTranslator.GetObject(L, 3, typeof(object));
					Tweener o2 = tweenerCore.ChangeValues(object3, object4, -1f);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					Vector3 newStartValue;
					objectTranslator.Get(L, 2, out newStartValue);
					Vector3 newEndValue;
					objectTranslator.Get(L, 3, out newEndValue);
					float newDuration2 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<Vector3, Vector3, VectorOptions> o3 = tweenerCore.ChangeValues(newStartValue, newEndValue, newDuration2);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Vector3>(L, 3))
				{
					Vector3 newStartValue2;
					objectTranslator.Get(L, 2, out newStartValue2);
					Vector3 newEndValue2;
					objectTranslator.Get(L, 3, out newEndValue2);
					TweenerCore<Vector3, Vector3, VectorOptions> o4 = tweenerCore.ChangeValues(newStartValue2, newEndValue2, -1f);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.ChangeValues!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Pause(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween o = ((TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1)).Pause<TweenerCore<Vector3, Vector3, VectorOptions>>();
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
		private static int _m_Play(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween o = ((TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1)).Play<TweenerCore<Vector3, Vector3, VectorOptions>>();
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
		private static int _m_SetAutoKill(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					Tween o = tweenerCore.SetAutoKill<TweenerCore<Vector3, Vector3, VectorOptions>>();
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool autoKillOnCompletion = Lua.lua_toboolean(L, 2);
					Tween o2 = tweenerCore.SetAutoKill(autoKillOnCompletion);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetAutoKill!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetId(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int intId = Lua.xlua_tointeger(L, 2);
					Tween o = t.SetId(intId);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 2, typeof(object));
					Tween o2 = t.SetId(@object);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string stringId = Lua.lua_tostring(L, 2);
					Tween o3 = t.SetId(stringId);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetId!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetLink(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<GameObject>(L, 2))
				{
					GameObject gameObject = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
					Tween o = t.SetLink(gameObject);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<GameObject>(L, 2) && objectTranslator.Assignable<LinkBehaviour>(L, 3))
				{
					GameObject gameObject2 = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
					LinkBehaviour behaviour;
					objectTranslator.Get<LinkBehaviour>(L, 3, out behaviour);
					Tween o2 = t.SetLink(gameObject2, behaviour);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetLink!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetTarget(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				object @object = objectTranslator.GetObject(L, 2, typeof(object));
				Tween o = t.SetTarget(@object);
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
		private static int _m_SetLoops(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int loops = Lua.xlua_tointeger(L, 2);
					Tween o = t.SetLoops(loops);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<LoopType>(L, 3))
				{
					int loops2 = Lua.xlua_tointeger(L, 2);
					LoopType loopType;
					objectTranslator.Get(L, 3, out loopType);
					Tween o2 = t.SetLoops(loops2, loopType);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetLoops!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetEase(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Ease>(L, 2))
				{
					Ease ease;
					objectTranslator.Get(L, 2, out ease);
					Tween o = t.SetEase(ease);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<AnimationCurve>(L, 2))
				{
					AnimationCurve animCurve = (AnimationCurve)objectTranslator.GetObject(L, 2, typeof(AnimationCurve));
					Tween o2 = t.SetEase(animCurve);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<EaseFunction>(L, 2))
				{
					EaseFunction @delegate = objectTranslator.GetDelegate<EaseFunction>(L, 2);
					Tween o3 = t.SetEase(@delegate);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Ease>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Ease ease2;
					objectTranslator.Get(L, 2, out ease2);
					float overshoot = (float)Lua.lua_tonumber(L, 3);
					Tween o4 = t.SetEase(ease2, overshoot);
					objectTranslator.Push(L, o4);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<Ease>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					Ease ease3;
					objectTranslator.Get(L, 2, out ease3);
					float amplitude = (float)Lua.lua_tonumber(L, 3);
					float period = (float)Lua.lua_tonumber(L, 4);
					Tween o5 = t.SetEase(ease3, amplitude, period);
					objectTranslator.Push(L, o5);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetEase!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetRecyclable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					Tween o = tweenerCore.SetRecyclable<TweenerCore<Vector3, Vector3, VectorOptions>>();
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool recyclable = Lua.lua_toboolean(L, 2);
					Tween o2 = tweenerCore.SetRecyclable(recyclable);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetRecyclable!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetUpdate(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool isIndependentUpdate = Lua.lua_toboolean(L, 2);
					Tween o = t.SetUpdate(isIndependentUpdate);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<UpdateType>(L, 2))
				{
					UpdateType updateType;
					objectTranslator.Get(L, 2, out updateType);
					Tween o2 = t.SetUpdate(updateType);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<UpdateType>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					UpdateType updateType2;
					objectTranslator.Get(L, 2, out updateType2);
					bool isIndependentUpdate2 = Lua.lua_toboolean(L, 3);
					Tween o3 = t.SetUpdate(updateType2, isIndependentUpdate2);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetUpdate!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_OnStart(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnStart(@delegate);
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
		private static int _m_OnPlay(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnPlay(@delegate);
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
		private static int _m_OnPause(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnPause(@delegate);
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
		private static int _m_OnRewind(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnRewind(@delegate);
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
		private static int _m_OnUpdate(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnUpdate(@delegate);
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
		private static int _m_OnStepComplete(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnStepComplete(@delegate);
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
		private static int _m_OnComplete(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnComplete(@delegate);
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
		private static int _m_OnKill(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnKill(@delegate);
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
		private static int _m_OnWaypointChange(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback<int> @delegate = objectTranslator.GetDelegate<TweenCallback<int>>(L, 2);
				Tween o = t.OnWaypointChange(@delegate);
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
		private static int _m_SetAs(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Tween>(L, 2))
				{
					Tween asTween = (Tween)objectTranslator.GetObject(L, 2, typeof(Tween));
					Tween o = t.SetAs(asTween);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<TweenParams>(L, 2))
				{
					TweenParams tweenParams = (TweenParams)objectTranslator.GetObject(L, 2, typeof(TweenParams));
					Tween o2 = t.SetAs(tweenParams);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetAs!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_From(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					Tweener o = t.From<TweenerCore<Vector3, Vector3, VectorOptions>>();
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool isRelative = Lua.lua_toboolean(L, 2);
					Tweener o2 = t.From(isRelative);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					float fromValue = (float)Lua.lua_tonumber(L, 2);
					bool setImmediately = Lua.lua_toboolean(L, 3);
					TweenerCore<Vector3, Vector3, VectorOptions> o3 = t.From(fromValue, setImmediately);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					float fromValue2 = (float)Lua.lua_tonumber(L, 2);
					TweenerCore<Vector3, Vector3, VectorOptions> o4 = t.From(fromValue2, true);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.From!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetDelay(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				float delay = (float)Lua.lua_tonumber(L, 2);
				Tween o = t.SetDelay(delay);
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
		private static int _m_SetRelative(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					Tween o = tweenerCore.SetRelative<TweenerCore<Vector3, Vector3, VectorOptions>>();
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool isRelative = Lua.lua_toboolean(L, 2);
					Tween o2 = tweenerCore.SetRelative(isRelative);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetRelative!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetSpeedBased(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					Tween o = tweenerCore.SetSpeedBased<TweenerCore<Vector3, Vector3, VectorOptions>>();
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool isSpeedBased = Lua.lua_toboolean(L, 2);
					Tween o2 = tweenerCore.SetSpeedBased(isSpeedBased);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetSpeedBased!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetOptions(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> t = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool snapping = Lua.lua_toboolean(L, 2);
					Tweener o = t.SetOptions(snapping);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<AxisConstraint>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					AxisConstraint axisConstraint;
					objectTranslator.Get(L, 2, out axisConstraint);
					bool snapping2 = Lua.lua_toboolean(L, 3);
					Tweener o2 = t.SetOptions(axisConstraint, snapping2);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<AxisConstraint>(L, 2))
				{
					AxisConstraint axisConstraint2;
					objectTranslator.Get(L, 2, out axisConstraint2);
					Tweener o3 = t.SetOptions(axisConstraint2, false);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>.SetOptions!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_startValue(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushUnityEngineVector3(L, tweenerCore.startValue);
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
		private static int _g_get_endValue(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushUnityEngineVector3(L, tweenerCore.endValue);
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
		private static int _g_get_changeValue(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushUnityEngineVector3(L, tweenerCore.changeValue);
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
		private static int _g_get_plugOptions(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, tweenerCore.plugOptions);
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
		private static int _g_get_getter(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, tweenerCore.getter);
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
		private static int _g_get_setter(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, tweenerCore.setter);
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
		private static int _s_set_startValue(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				Vector3 startValue;
				objectTranslator.Get(L, 2, out startValue);
				tweenerCore.startValue = startValue;
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
		private static int _s_set_endValue(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				Vector3 endValue;
				objectTranslator.Get(L, 2, out endValue);
				tweenerCore.endValue = endValue;
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
		private static int _s_set_changeValue(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				Vector3 changeValue;
				objectTranslator.Get(L, 2, out changeValue);
				tweenerCore.changeValue = changeValue;
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
		private static int _s_set_plugOptions(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1);
				VectorOptions plugOptions;
				objectTranslator.Get<VectorOptions>(L, 2, out plugOptions);
				tweenerCore.plugOptions = plugOptions;
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
		private static int _s_set_getter(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1)).getter = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 2);
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
		private static int _s_set_setter(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((TweenerCore<Vector3, Vector3, VectorOptions>)objectTranslator.FastGetCSObj(L, 1)).setter = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
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
