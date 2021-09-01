﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DG.Tweening;
using Tutorial;
using UnityEngine;
using XLua.LuaDLL;
using XLuaTest;

namespace XLua
{
	public class StaticLuaCallbacks
	{
		internal static bool __tryArrayGet(Type type, IntPtr L, ObjectTranslator translator, object obj, int index)
		{
			if (type == typeof(Vector2[]))
			{
				Vector2[] array = obj as Vector2[];
				translator.PushUnityEngineVector2(L, array[index]);
				return true;
			}
			if (type == typeof(Vector3[]))
			{
				Vector3[] array2 = obj as Vector3[];
				translator.PushUnityEngineVector3(L, array2[index]);
				return true;
			}
			if (type == typeof(Vector4[]))
			{
				Vector4[] array3 = obj as Vector4[];
				translator.PushUnityEngineVector4(L, array3[index]);
				return true;
			}
			if (type == typeof(Color[]))
			{
				Color[] array4 = obj as Color[];
				translator.PushUnityEngineColor(L, array4[index]);
				return true;
			}
			if (type == typeof(Quaternion[]))
			{
				Quaternion[] array5 = obj as Quaternion[];
				translator.PushUnityEngineQuaternion(L, array5[index]);
				return true;
			}
			if (type == typeof(Ray[]))
			{
				Ray[] array6 = obj as Ray[];
				translator.PushUnityEngineRay(L, array6[index]);
				return true;
			}
			if (type == typeof(Bounds[]))
			{
				Bounds[] array7 = obj as Bounds[];
				translator.PushUnityEngineBounds(L, array7[index]);
				return true;
			}
			if (type == typeof(Ray2D[]))
			{
				Ray2D[] array8 = obj as Ray2D[];
				translator.PushUnityEngineRay2D(L, array8[index]);
				return true;
			}
			if (type == typeof(Pedding[]))
			{
				Pedding[] array9 = obj as Pedding[];
				translator.PushXLuaTestPedding(L, array9[index]);
				return true;
			}
			if (type == typeof(MyStruct[]))
			{
				MyStruct[] array10 = obj as MyStruct[];
				translator.PushXLuaTestMyStruct(L, array10[index]);
				return true;
			}
			if (type == typeof(PushAsTableStruct[]))
			{
				PushAsTableStruct[] array11 = obj as PushAsTableStruct[];
				translator.PushXLuaTestPushAsTableStruct(L, array11[index]);
				return true;
			}
			if (type == typeof(AutoPlay[]))
			{
				AutoPlay[] array12 = obj as AutoPlay[];
				translator.PushDGTweeningAutoPlay(L, array12[index]);
				return true;
			}
			if (type == typeof(AxisConstraint[]))
			{
				AxisConstraint[] array13 = obj as AxisConstraint[];
				translator.PushDGTweeningAxisConstraint(L, array13[index]);
				return true;
			}
			if (type == typeof(Ease[]))
			{
				Ease[] array14 = obj as Ease[];
				translator.PushDGTweeningEase(L, array14[index]);
				return true;
			}
			if (type == typeof(LogBehaviour[]))
			{
				LogBehaviour[] array15 = obj as LogBehaviour[];
				translator.PushDGTweeningLogBehaviour(L, array15[index]);
				return true;
			}
			if (type == typeof(LoopType[]))
			{
				LoopType[] array16 = obj as LoopType[];
				translator.PushDGTweeningLoopType(L, array16[index]);
				return true;
			}
			if (type == typeof(PathMode[]))
			{
				PathMode[] array17 = obj as PathMode[];
				translator.PushDGTweeningPathMode(L, array17[index]);
				return true;
			}
			if (type == typeof(PathType[]))
			{
				PathType[] array18 = obj as PathType[];
				translator.PushDGTweeningPathType(L, array18[index]);
				return true;
			}
			if (type == typeof(RotateMode[]))
			{
				RotateMode[] array19 = obj as RotateMode[];
				translator.PushDGTweeningRotateMode(L, array19[index]);
				return true;
			}
			if (type == typeof(ScrambleMode[]))
			{
				ScrambleMode[] array20 = obj as ScrambleMode[];
				translator.PushDGTweeningScrambleMode(L, array20[index]);
				return true;
			}
			if (type == typeof(TweenType[]))
			{
				TweenType[] array21 = obj as TweenType[];
				translator.PushDGTweeningTweenType(L, array21[index]);
				return true;
			}
			if (type == typeof(UpdateType[]))
			{
				UpdateType[] array22 = obj as UpdateType[];
				translator.PushDGTweeningUpdateType(L, array22[index]);
				return true;
			}
			if (type == typeof(TestEnum[]))
			{
				TestEnum[] array23 = obj as TestEnum[];
				translator.PushTutorialTestEnum(L, array23[index]);
				return true;
			}
			if (type == typeof(MyEnum[]))
			{
				MyEnum[] array24 = obj as MyEnum[];
				translator.PushXLuaTestMyEnum(L, array24[index]);
				return true;
			}
			if (type == typeof(DerivedClass.TestEnumInner[]))
			{
				DerivedClass.TestEnumInner[] array25 = obj as DerivedClass.TestEnumInner[];
				translator.PushTutorialDerivedClassTestEnumInner(L, array25[index]);
				return true;
			}
			return false;
		}

		internal static bool __tryArraySet(Type type, IntPtr L, ObjectTranslator translator, object obj, int array_idx, int obj_idx)
		{
			if (type == typeof(Vector2[]))
			{
				Vector2[] array = obj as Vector2[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			if (type == typeof(Vector3[]))
			{
				Vector3[] array2 = obj as Vector3[];
				translator.Get(L, obj_idx, out array2[array_idx]);
				return true;
			}
			if (type == typeof(Vector4[]))
			{
				Vector4[] array3 = obj as Vector4[];
				translator.Get(L, obj_idx, out array3[array_idx]);
				return true;
			}
			if (type == typeof(Color[]))
			{
				Color[] array4 = obj as Color[];
				translator.Get(L, obj_idx, out array4[array_idx]);
				return true;
			}
			if (type == typeof(Quaternion[]))
			{
				Quaternion[] array5 = obj as Quaternion[];
				translator.Get(L, obj_idx, out array5[array_idx]);
				return true;
			}
			if (type == typeof(Ray[]))
			{
				Ray[] array6 = obj as Ray[];
				translator.Get(L, obj_idx, out array6[array_idx]);
				return true;
			}
			if (type == typeof(Bounds[]))
			{
				Bounds[] array7 = obj as Bounds[];
				translator.Get(L, obj_idx, out array7[array_idx]);
				return true;
			}
			if (type == typeof(Ray2D[]))
			{
				Ray2D[] array8 = obj as Ray2D[];
				translator.Get(L, obj_idx, out array8[array_idx]);
				return true;
			}
			if (type == typeof(Pedding[]))
			{
				Pedding[] array9 = obj as Pedding[];
				translator.Get(L, obj_idx, out array9[array_idx]);
				return true;
			}
			if (type == typeof(MyStruct[]))
			{
				MyStruct[] array10 = obj as MyStruct[];
				translator.Get(L, obj_idx, out array10[array_idx]);
				return true;
			}
			if (type == typeof(PushAsTableStruct[]))
			{
				PushAsTableStruct[] array11 = obj as PushAsTableStruct[];
				translator.Get(L, obj_idx, out array11[array_idx]);
				return true;
			}
			if (type == typeof(AutoPlay[]))
			{
				AutoPlay[] array12 = obj as AutoPlay[];
				translator.Get(L, obj_idx, out array12[array_idx]);
				return true;
			}
			if (type == typeof(AxisConstraint[]))
			{
				AxisConstraint[] array13 = obj as AxisConstraint[];
				translator.Get(L, obj_idx, out array13[array_idx]);
				return true;
			}
			if (type == typeof(Ease[]))
			{
				Ease[] array14 = obj as Ease[];
				translator.Get(L, obj_idx, out array14[array_idx]);
				return true;
			}
			if (type == typeof(LogBehaviour[]))
			{
				LogBehaviour[] array15 = obj as LogBehaviour[];
				translator.Get(L, obj_idx, out array15[array_idx]);
				return true;
			}
			if (type == typeof(LoopType[]))
			{
				LoopType[] array16 = obj as LoopType[];
				translator.Get(L, obj_idx, out array16[array_idx]);
				return true;
			}
			if (type == typeof(PathMode[]))
			{
				PathMode[] array17 = obj as PathMode[];
				translator.Get(L, obj_idx, out array17[array_idx]);
				return true;
			}
			if (type == typeof(PathType[]))
			{
				PathType[] array18 = obj as PathType[];
				translator.Get(L, obj_idx, out array18[array_idx]);
				return true;
			}
			if (type == typeof(RotateMode[]))
			{
				RotateMode[] array19 = obj as RotateMode[];
				translator.Get(L, obj_idx, out array19[array_idx]);
				return true;
			}
			if (type == typeof(ScrambleMode[]))
			{
				ScrambleMode[] array20 = obj as ScrambleMode[];
				translator.Get(L, obj_idx, out array20[array_idx]);
				return true;
			}
			if (type == typeof(TweenType[]))
			{
				TweenType[] array21 = obj as TweenType[];
				translator.Get(L, obj_idx, out array21[array_idx]);
				return true;
			}
			if (type == typeof(UpdateType[]))
			{
				UpdateType[] array22 = obj as UpdateType[];
				translator.Get(L, obj_idx, out array22[array_idx]);
				return true;
			}
			if (type == typeof(TestEnum[]))
			{
				TestEnum[] array23 = obj as TestEnum[];
				translator.Get(L, obj_idx, out array23[array_idx]);
				return true;
			}
			if (type == typeof(MyEnum[]))
			{
				MyEnum[] array24 = obj as MyEnum[];
				translator.Get(L, obj_idx, out array24[array_idx]);
				return true;
			}
			if (type == typeof(DerivedClass.TestEnumInner[]))
			{
				DerivedClass.TestEnumInner[] array25 = obj as DerivedClass.TestEnumInner[];
				translator.Get(L, obj_idx, out array25[array_idx]);
				return true;
			}
			return false;
		}

		public StaticLuaCallbacks()
		{
			this.GcMeta = new lua_CSFunction(StaticLuaCallbacks.LuaGC);
			this.ToStringMeta = new lua_CSFunction(StaticLuaCallbacks.ToString);
			this.EnumAndMeta = new lua_CSFunction(StaticLuaCallbacks.EnumAnd);
			this.EnumOrMeta = new lua_CSFunction(StaticLuaCallbacks.EnumOr);
			this.StaticCSFunctionWraper = new lua_CSFunction(StaticLuaCallbacks.StaticCSFunction);
			this.FixCSFunctionWraper = new lua_CSFunction(StaticLuaCallbacks.FixCSFunction);
			this.DelegateCtor = new lua_CSFunction(StaticLuaCallbacks.DelegateConstructor);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int EnumAnd(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				object obj = objectTranslator.FastGetCSObj(L, 1);
				object obj2 = objectTranslator.FastGetCSObj(L, 2);
				Type type = obj.GetType();
				if (!type.IsEnum() || type != obj2.GetType())
				{
					result = Lua.luaL_error(L, "invalid argument for Enum BitwiseAnd");
				}
				else
				{
					objectTranslator.PushAny(L, Enum.ToObject(type, Convert.ToInt64(obj) & Convert.ToInt64(obj2)));
					result = 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception in Enum BitwiseAnd:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int EnumOr(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				object obj = objectTranslator.FastGetCSObj(L, 1);
				object obj2 = objectTranslator.FastGetCSObj(L, 2);
				Type type = obj.GetType();
				if (!type.IsEnum() || type != obj2.GetType())
				{
					result = Lua.luaL_error(L, "invalid argument for Enum BitwiseOr");
				}
				else
				{
					objectTranslator.PushAny(L, Enum.ToObject(type, Convert.ToInt64(obj) | Convert.ToInt64(obj2)));
					result = 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception in Enum BitwiseOr:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int StaticCSFunction(IntPtr L)
		{
			int result;
			try
			{
				result = ((lua_CSFunction)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, Lua.xlua_upvalueindex(1)))(L);
			}
			catch (Exception ex)
			{
				string str = "c# exception in StaticCSFunction:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int FixCSFunction(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int index = Lua.xlua_tointeger(L, Lua.xlua_upvalueindex(1));
				result = objectTranslator.GetFixCSFunction(index)(L);
			}
			catch (Exception ex)
			{
				string str = "c# exception in FixCSFunction:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int DelegateCall(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				object obj = objectTranslator.FastGetCSObj(L, 1);
				if (obj == null || !(obj is Delegate))
				{
					result = Lua.luaL_error(L, "trying to invoke a value that is not delegate nor callable");
				}
				else
				{
					result = objectTranslator.methodWrapsCache.GetDelegateWrap(obj.GetType())(L);
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception in DelegateCall:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int LuaGC(IntPtr L)
		{
			int result;
			try
			{
				int num = Lua.xlua_tocsobj_safe(L, 1);
				if (num != -1)
				{
					ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
					if (objectTranslator != null)
					{
						objectTranslator.collectObject(num);
					}
				}
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception in LuaGC:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int ToString(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				object obj = objectTranslator.FastGetCSObj(L, 1);
				object o;
				if (obj == null)
				{
					o = "<invalid c# object>";
				}
				else
				{
					string str = obj.ToString();
					string str2 = ": ";
					result = obj.GetHashCode();
					o = str + str2 + result.ToString();
				}
				objectTranslator.PushAny(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str3 = "c# exception in ToString:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str3 + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int DelegateCombine(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Type type = objectTranslator.FastGetCSObj(L, (Lua.lua_type(L, 1) == LuaTypes.LUA_TUSERDATA) ? 1 : 2).GetType();
				Delegate @delegate = objectTranslator.GetObject(L, 1, type) as Delegate;
				Delegate delegate2 = objectTranslator.GetObject(L, 2, type) as Delegate;
				if (@delegate == null || delegate2 == null)
				{
					result = Lua.luaL_error(L, "one parameter must be a delegate, other one must be delegate or function");
				}
				else
				{
					objectTranslator.PushAny(L, Delegate.Combine(@delegate, delegate2));
					result = 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception in DelegateCombine:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int DelegateRemove(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Delegate @delegate = objectTranslator.FastGetCSObj(L, 1) as Delegate;
				if (@delegate == null)
				{
					result = Lua.luaL_error(L, "#1 parameter must be a delegate");
				}
				else
				{
					Delegate delegate2 = objectTranslator.GetObject(L, 2, @delegate.GetType()) as Delegate;
					if (delegate2 == null)
					{
						result = Lua.luaL_error(L, "#2 parameter must be a delegate or a function ");
					}
					else
					{
						objectTranslator.PushAny(L, Delegate.Remove(@delegate, delegate2));
						result = 1;
					}
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception in DelegateRemove:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		private static bool tryPrimitiveArrayGet(Type type, IntPtr L, object obj, int index)
		{
			bool result = true;
			if (type == typeof(int[]))
			{
				int[] array = obj as int[];
				Lua.xlua_pushinteger(L, array[index]);
			}
			else if (type == typeof(float[]))
			{
				float[] array2 = obj as float[];
				Lua.lua_pushnumber(L, (double)array2[index]);
			}
			else if (type == typeof(double[]))
			{
				double[] array3 = obj as double[];
				Lua.lua_pushnumber(L, array3[index]);
			}
			else if (type == typeof(bool[]))
			{
				bool[] array4 = obj as bool[];
				Lua.lua_pushboolean(L, array4[index]);
			}
			else if (type == typeof(long[]))
			{
				long[] array5 = obj as long[];
				Lua.lua_pushint64(L, array5[index]);
			}
			else if (type == typeof(ulong[]))
			{
				ulong[] array6 = obj as ulong[];
				Lua.lua_pushuint64(L, array6[index]);
			}
			else if (type == typeof(sbyte[]))
			{
				sbyte[] array7 = obj as sbyte[];
				Lua.xlua_pushinteger(L, (int)array7[index]);
			}
			else if (type == typeof(short[]))
			{
				short[] array8 = obj as short[];
				Lua.xlua_pushinteger(L, (int)array8[index]);
			}
			else if (type == typeof(ushort[]))
			{
				ushort[] array9 = obj as ushort[];
				Lua.xlua_pushinteger(L, (int)array9[index]);
			}
			else if (type == typeof(char[]))
			{
				char[] array10 = obj as char[];
				Lua.xlua_pushinteger(L, (int)array10[index]);
			}
			else if (type == typeof(uint[]))
			{
				uint[] array11 = obj as uint[];
				Lua.xlua_pushuint(L, array11[index]);
			}
			else if (type == typeof(IntPtr[]))
			{
				IntPtr[] array12 = obj as IntPtr[];
				Lua.lua_pushlightuserdata(L, array12[index]);
			}
			else if (type == typeof(decimal[]))
			{
				decimal[] array13 = obj as decimal[];
				ObjectTranslatorPool.Instance.Find(L).PushDecimal(L, array13[index]);
			}
			else if (type == typeof(string[]))
			{
				string[] array14 = obj as string[];
				Lua.lua_pushstring(L, array14[index]);
			}
			else
			{
				result = false;
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int ArrayIndexer(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Array array = (Array)objectTranslator.FastGetCSObj(L, 1);
				if (array == null)
				{
					result = Lua.luaL_error(L, "#1 parameter is not a array!");
				}
				else
				{
					int num = Lua.xlua_tointeger(L, 2);
					if (num >= array.Length)
					{
						result = Lua.luaL_error(L, "index out of range! i =" + num.ToString() + ", array.Length=" + array.Length.ToString());
					}
					else
					{
						Type type = array.GetType();
						if (StaticLuaCallbacks.tryPrimitiveArrayGet(type, L, array, num))
						{
							result = 1;
						}
						else
						{
							if (InternalGlobals.genTryArrayGetPtr != null)
							{
								try
								{
									if (InternalGlobals.genTryArrayGetPtr(type, L, objectTranslator, array, num))
									{
										return 1;
									}
								}
								catch (Exception ex)
								{
									return Lua.luaL_error(L, "c# exception:" + ex.Message + ",stack:" + ex.StackTrace);
								}
							}
							object value = array.GetValue(num);
							objectTranslator.PushAny(L, value);
							result = 1;
						}
					}
				}
			}
			catch (Exception ex2)
			{
				string str = "c# exception in ArrayIndexer:";
				Exception ex3 = ex2;
				result = Lua.luaL_error(L, str + ((ex3 != null) ? ex3.ToString() : null));
			}
			return result;
		}

		public static bool TryPrimitiveArraySet(Type type, IntPtr L, object obj, int array_idx, int obj_idx)
		{
			bool result = true;
			LuaTypes luaTypes = Lua.lua_type(L, obj_idx);
			if (type == typeof(int[]) && luaTypes == LuaTypes.LUA_TNUMBER)
			{
				(obj as int[])[array_idx] = Lua.xlua_tointeger(L, obj_idx);
			}
			else if (type == typeof(float[]) && luaTypes == LuaTypes.LUA_TNUMBER)
			{
				(obj as float[])[array_idx] = (float)Lua.lua_tonumber(L, obj_idx);
			}
			else if (type == typeof(double[]) && luaTypes == LuaTypes.LUA_TNUMBER)
			{
				(obj as double[])[array_idx] = Lua.lua_tonumber(L, obj_idx);
			}
			else if (type == typeof(bool[]) && luaTypes == LuaTypes.LUA_TBOOLEAN)
			{
				(obj as bool[])[array_idx] = Lua.lua_toboolean(L, obj_idx);
			}
			else if (type == typeof(long[]) && Lua.lua_isint64(L, obj_idx))
			{
				(obj as long[])[array_idx] = Lua.lua_toint64(L, obj_idx);
			}
			else if (type == typeof(ulong[]) && Lua.lua_isuint64(L, obj_idx))
			{
				(obj as ulong[])[array_idx] = Lua.lua_touint64(L, obj_idx);
			}
			else if (type == typeof(sbyte[]) && luaTypes == LuaTypes.LUA_TNUMBER)
			{
				(obj as sbyte[])[array_idx] = (sbyte)Lua.xlua_tointeger(L, obj_idx);
			}
			else if (type == typeof(short[]) && luaTypes == LuaTypes.LUA_TNUMBER)
			{
				(obj as short[])[array_idx] = (short)Lua.xlua_tointeger(L, obj_idx);
			}
			else if (type == typeof(ushort[]) && luaTypes == LuaTypes.LUA_TNUMBER)
			{
				(obj as ushort[])[array_idx] = (ushort)Lua.xlua_tointeger(L, obj_idx);
			}
			else if (type == typeof(char[]) && luaTypes == LuaTypes.LUA_TNUMBER)
			{
				(obj as char[])[array_idx] = (char)Lua.xlua_tointeger(L, obj_idx);
			}
			else if (type == typeof(uint[]) && luaTypes == LuaTypes.LUA_TNUMBER)
			{
				(obj as uint[])[array_idx] = Lua.xlua_touint(L, obj_idx);
			}
			else if (type == typeof(IntPtr[]) && luaTypes == LuaTypes.LUA_TLIGHTUSERDATA)
			{
				(obj as IntPtr[])[array_idx] = Lua.lua_touserdata(L, obj_idx);
			}
			else if (type == typeof(decimal[]))
			{
				decimal[] array = obj as decimal[];
				if (luaTypes == LuaTypes.LUA_TNUMBER)
				{
					array[array_idx] = (decimal)Lua.lua_tonumber(L, obj_idx);
				}
				if (luaTypes == LuaTypes.LUA_TUSERDATA)
				{
					ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
					if (objectTranslator.IsDecimal(L, obj_idx))
					{
						objectTranslator.Get(L, obj_idx, out array[array_idx]);
					}
					else
					{
						result = false;
					}
				}
				else
				{
					result = false;
				}
			}
			else if (type == typeof(string[]) && luaTypes == LuaTypes.LUA_TSTRING)
			{
				(obj as string[])[array_idx] = Lua.lua_tostring(L, obj_idx);
			}
			else
			{
				result = false;
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int ArrayNewIndexer(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Array array = (Array)objectTranslator.FastGetCSObj(L, 1);
				if (array == null)
				{
					result = Lua.luaL_error(L, "#1 parameter is not a array!");
				}
				else
				{
					int num = Lua.xlua_tointeger(L, 2);
					if (num >= array.Length)
					{
						result = Lua.luaL_error(L, "index out of range! i =" + num.ToString() + ", array.Length=" + array.Length.ToString());
					}
					else
					{
						Type type = array.GetType();
						if (StaticLuaCallbacks.TryPrimitiveArraySet(type, L, array, num, 3))
						{
							result = 0;
						}
						else
						{
							if (InternalGlobals.genTryArraySetPtr != null)
							{
								try
								{
									if (InternalGlobals.genTryArraySetPtr(type, L, objectTranslator, array, num, 3))
									{
										return 0;
									}
								}
								catch (Exception ex)
								{
									return Lua.luaL_error(L, "c# exception:" + ex.Message + ",stack:" + ex.StackTrace);
								}
							}
							object @object = objectTranslator.GetObject(L, 3, type.GetElementType());
							array.SetValue(@object, num);
							result = 0;
						}
					}
				}
			}
			catch (Exception ex2)
			{
				string str = "c# exception in ArrayNewIndexer:";
				Exception ex3 = ex2;
				result = Lua.luaL_error(L, str + ((ex3 != null) ? ex3.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int ArrayLength(IntPtr L)
		{
			int result;
			try
			{
				Array array = (Array)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, array.Length);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception in ArrayLength:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int MetaFuncIndex(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Type type = objectTranslator.FastGetCSObj(L, 2) as Type;
				if (type == null)
				{
					result = Lua.luaL_error(L, "#2 param need a System.Type!");
				}
				else
				{
					objectTranslator.GetTypeId(L, type);
					Lua.lua_pushvalue(L, 2);
					Lua.lua_rawget(L, 1);
					result = 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception in MetaFuncIndex:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		internal static int Panic(IntPtr L)
		{
			throw new LuaException(string.Format("unprotected error in call to Lua API ({0})", Lua.lua_tostring(L, -1)));
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		internal static int Print(IntPtr L)
		{
			int result;
			try
			{
				int num = Lua.lua_gettop(L);
				string text = string.Empty;
				if (Lua.xlua_getglobal(L, "tostring") != 0)
				{
					result = Lua.luaL_error(L, "can not get tostring in print:");
				}
				else
				{
					for (int i = 1; i <= num; i++)
					{
						Lua.lua_pushvalue(L, -1);
						Lua.lua_pushvalue(L, i);
						if (Lua.lua_pcall(L, 1, 1, 0) != 0)
						{
							return Lua.lua_error(L);
						}
						text += Lua.lua_tostring(L, -1);
						if (i != num)
						{
							text += "\t";
						}
						Lua.lua_pop(L, 1);
					}
					Debug.Log("LUA: " + text);
					result = 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception in print:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		internal static int LoadSocketCore(IntPtr L)
		{
			return Lua.luaopen_socket_core(L);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		internal static int LoadCS(IntPtr L)
		{
			Lua.xlua_pushasciistring(L, "xlua_csharp_namespace");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		internal static int LoadBuiltinLib(IntPtr L)
		{
			int result;
			try
			{
				string text = Lua.lua_tostring(L, 1);
				lua_CSFunction function;
				if (ObjectTranslatorPool.Instance.Find(L).luaEnv.buildin_initer.TryGetValue(text, out function))
				{
					Lua.lua_pushstdcallcfunction(L, function, 0);
				}
				else
				{
					Lua.lua_pushstring(L, string.Format("\n\tno such builtin lib '{0}'", text));
				}
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception in LoadBuiltinLib:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		internal static int LoadFromResource(IntPtr L)
		{
			int result;
			try
			{
				string text = Lua.lua_tostring(L, 1).Replace('.', '/') + ".lua";
				TextAsset textAsset = (TextAsset)Resources.Load(text);
				if (textAsset == null)
				{
					Lua.lua_pushstring(L, string.Format("\n\tno such resource '{0}'", text));
				}
				else if (Lua.xluaL_loadbuffer(L, textAsset.bytes, textAsset.bytes.Length, "@" + text) != 0)
				{
					return Lua.luaL_error(L, string.Format("error loading module {0} from resource, {1}", Lua.lua_tostring(L, 1), Lua.lua_tostring(L, -1)));
				}
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception in LoadFromResource:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		internal static int LoadFromStreamingAssetsPath(IntPtr L)
		{
			int result;
			try
			{
				string text = Lua.lua_tostring(L, 1).Replace('.', '/') + ".lua";
				string path = Application.streamingAssetsPath + "/" + text;
				if (File.Exists(path))
				{
					byte[] array = File.ReadAllBytes(path);
					Debug.LogWarning("load lua file from StreamingAssets is obsolete, filename:" + text);
					if (Lua.xluaL_loadbuffer(L, array, array.Length, "@" + text) != 0)
					{
						return Lua.luaL_error(L, string.Format("error loading module {0} from streamingAssetsPath, {1}", Lua.lua_tostring(L, 1), Lua.lua_tostring(L, -1)));
					}
				}
				else
				{
					Lua.lua_pushstring(L, string.Format("\n\tno such file '{0}' in streamingAssetsPath!", text));
				}
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception in LoadFromStreamingAssetsPath:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		internal static int LoadFromCustomLoaders(IntPtr L)
		{
			int result;
			try
			{
				string text = Lua.lua_tostring(L, 1);
				foreach (LuaEnv.CustomLoader customLoader in ObjectTranslatorPool.Instance.Find(L).luaEnv.customLoaders)
				{
					string str = text;
					byte[] array = customLoader(ref str);
					if (array != null)
					{
						if (Lua.xluaL_loadbuffer(L, array, array.Length, "@" + str) != 0)
						{
							return Lua.luaL_error(L, string.Format("error loading module {0} from CustomLoader, {1}", Lua.lua_tostring(L, 1), Lua.lua_tostring(L, -1)));
						}
						return 1;
					}
				}
				Lua.lua_pushstring(L, string.Format("\n\tno such file '{0}' in CustomLoaders!", text));
				result = 1;
			}
			catch (Exception ex)
			{
				string str2 = "c# exception in LoadFromCustomLoaders:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str2 + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int LoadAssembly(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				string text = Lua.lua_tostring(L, 1);
				Assembly assembly = null;
				try
				{
					assembly = Assembly.Load(text);
				}
				catch (BadImageFormatException)
				{
				}
				if (assembly == null)
				{
					assembly = Assembly.Load(AssemblyName.GetAssemblyName(text));
				}
				if (assembly != null && !objectTranslator.assemblies.Contains(assembly))
				{
					objectTranslator.assemblies.Add(assembly);
				}
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception in xlua.load_assembly:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int ImportType(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				string className = Lua.lua_tostring(L, 1);
				Type type = objectTranslator.FindType(className, false);
				if (type != null)
				{
					if (objectTranslator.GetTypeId(L, type) < 0)
					{
						string str = "can not load type ";
						Type type2 = type;
						return Lua.luaL_error(L, str + ((type2 != null) ? type2.ToString() : null));
					}
					Lua.lua_pushboolean(L, true);
				}
				else
				{
					Lua.lua_pushnil(L);
				}
				result = 1;
			}
			catch (Exception ex)
			{
				string str2 = "c# exception in xlua.import_type:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str2 + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int ImportGenericType(IntPtr L)
		{
			int result;
			try
			{
				int num = Lua.lua_gettop(L);
				if (num < 2)
				{
					result = Lua.luaL_error(L, "import generic type need at lease 2 arguments");
				}
				else
				{
					ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
					string text = Lua.lua_tostring(L, 1);
					if (text.EndsWith("<>"))
					{
						text = text.Substring(0, text.Length - 2);
					}
					Type type = objectTranslator.FindType(text + "`" + (num - 1).ToString(), false);
					if (type == null || !type.IsGenericTypeDefinition())
					{
						Lua.lua_pushnil(L);
					}
					else
					{
						Type[] array = new Type[num - 1];
						for (int i = 2; i <= num; i++)
						{
							array[i - 2] = StaticLuaCallbacks.getType(L, objectTranslator, i);
							if (array[i - 2] == null)
							{
								return Lua.luaL_error(L, "param need a type");
							}
						}
						Type type2 = type.MakeGenericType(array);
						objectTranslator.GetTypeId(L, type2);
						objectTranslator.PushAny(L, type2);
					}
					result = 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception in xlua.import_type:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int Cast(IntPtr L)
		{
			int result;
			try
			{
				Type type;
				ObjectTranslatorPool.Instance.Find(L).Get<Type>(L, 2, out type);
				if (type == null)
				{
					result = Lua.luaL_error(L, "#2 param[" + Lua.lua_tostring(L, 2) + "]is not valid type indicator");
				}
				else
				{
					Lua.luaL_getmetatable(L, type.FullName);
					if (Lua.lua_isnil(L, -1))
					{
						result = Lua.luaL_error(L, "no gen code for " + Lua.lua_tostring(L, 2));
					}
					else
					{
						Lua.lua_setmetatable(L, 1);
						result = 0;
					}
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception in xlua.cast:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		private static Type getType(IntPtr L, ObjectTranslator translator, int idx)
		{
			if (Lua.lua_type(L, idx) == LuaTypes.LUA_TTABLE)
			{
				LuaTable luaTable;
				translator.Get<LuaTable>(L, idx, out luaTable);
				return luaTable.Get<Type>("UnderlyingSystemType");
			}
			if (Lua.lua_type(L, idx) == LuaTypes.LUA_TSTRING)
			{
				string className = Lua.lua_tostring(L, idx);
				return translator.FindType(className, false);
			}
			if (translator.GetObject(L, idx) is Type)
			{
				return translator.GetObject(L, idx) as Type;
			}
			return null;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int XLuaAccess(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Type type = StaticLuaCallbacks.getType(L, objectTranslator, 1);
				object obj = null;
				if (type == null && Lua.lua_type(L, 1) == LuaTypes.LUA_TUSERDATA)
				{
					obj = objectTranslator.SafeGetCSObj(L, 1);
					if (obj == null)
					{
						return Lua.luaL_error(L, "xlua.access, #1 parameter must a type/c# object/string");
					}
					type = obj.GetType();
				}
				if (type == null)
				{
					result = Lua.luaL_error(L, "xlua.access, can not find c# type");
				}
				else
				{
					string text = Lua.lua_tostring(L, 2);
					BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
					if (Lua.lua_gettop(L) > 2)
					{
						FieldInfo field = type.GetField(text, bindingAttr);
						if (field != null)
						{
							field.SetValue(obj, objectTranslator.GetObject(L, 3, field.FieldType));
							return 0;
						}
						PropertyInfo property = type.GetProperty(text, bindingAttr);
						if (property != null)
						{
							property.SetValue(obj, objectTranslator.GetObject(L, 3, property.PropertyType), null);
							return 0;
						}
					}
					else
					{
						FieldInfo field2 = type.GetField(text, bindingAttr);
						if (field2 != null)
						{
							objectTranslator.PushAny(L, field2.GetValue(obj));
							return 1;
						}
						PropertyInfo property2 = type.GetProperty(text, bindingAttr);
						if (property2 != null)
						{
							objectTranslator.PushAny(L, property2.GetValue(obj, null));
							return 1;
						}
					}
					result = Lua.luaL_error(L, "xlua.access, no field " + text);
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception in xlua.access: ";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int XLuaPrivateAccessible(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Type type = StaticLuaCallbacks.getType(L, objectTranslator, 1);
				if (type == null)
				{
					result = Lua.luaL_error(L, "xlua.private_accessible, can not find c# type");
				}
				else
				{
					while (type != null)
					{
						objectTranslator.PrivateAccessible(L, type);
						type = type.BaseType();
					}
					result = 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception in xlua.private_accessible: ";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int XLuaMetatableOperation(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Type type = StaticLuaCallbacks.getType(L, objectTranslator, 1);
				if (type == null)
				{
					result = Lua.luaL_error(L, "xlua.metatable_operation, can not find c# type");
				}
				else
				{
					bool flag = false;
					int typeId = objectTranslator.getTypeId(L, type, out flag, ObjectTranslator.LOGLEVEL.WARN);
					int num = Lua.lua_gettop(L);
					if (num == 1)
					{
						Lua.xlua_rawgeti(L, LuaIndexes.LUA_REGISTRYINDEX, (long)typeId);
						result = 1;
					}
					else if (num == 2)
					{
						if (Lua.lua_type(L, 2) != LuaTypes.LUA_TTABLE)
						{
							result = Lua.luaL_error(L, "argument #2 must be a table");
						}
						else
						{
							Lua.lua_pushnumber(L, (double)typeId);
							Lua.xlua_rawseti(L, 2, 1L);
							Lua.xlua_rawseti(L, LuaIndexes.LUA_REGISTRYINDEX, (long)typeId);
							result = 0;
						}
					}
					else
					{
						result = Lua.luaL_error(L, "invalid argument num for xlua.metatable_operation: " + num.ToString());
					}
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception in xlua.metatable_operation: ";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int DelegateConstructor(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Type type = StaticLuaCallbacks.getType(L, objectTranslator, 1);
				if (type == null || !typeof(Delegate).IsAssignableFrom(type))
				{
					result = Lua.luaL_error(L, "delegate constructor: #1 argument must be a Delegate's type");
				}
				else
				{
					objectTranslator.PushAny(L, objectTranslator.GetObject(L, 2, type));
					result = 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception in delegate constructor: ";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int ToFunction(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				MethodBase methodBase;
				objectTranslator.Get<MethodBase>(L, 1, out methodBase);
				if (methodBase == null)
				{
					result = Lua.luaL_error(L, "ToFunction: #1 argument must be a MethodBase");
				}
				else
				{
					objectTranslator.PushFixCSFunction(L, new lua_CSFunction(objectTranslator.methodWrapsCache._GenMethodWrap(methodBase.DeclaringType, methodBase.Name, new MethodBase[]
					{
						methodBase
					}, false).Call));
					result = 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception in ToFunction: ";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int GenericMethodWraper(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				MethodInfo methodInfo;
				objectTranslator.Get<MethodInfo>(L, Lua.xlua_upvalueindex(1), out methodInfo);
				int num = Lua.lua_gettop(L);
				Type[] array = new Type[num];
				for (int i = 0; i < num; i++)
				{
					Type type = StaticLuaCallbacks.getType(L, objectTranslator, i + 1);
					if (type == null)
					{
						string str = "param #";
						result = i + 1;
						return Lua.luaL_error(L, str + result.ToString() + " is not a type");
					}
					array[i] = type;
				}
				MethodInfo methodInfo2 = methodInfo.MakeGenericMethod(array);
				objectTranslator.PushFixCSFunction(L, new lua_CSFunction(objectTranslator.methodWrapsCache._GenMethodWrap(methodInfo2.DeclaringType, methodInfo2.Name, new MethodBase[]
				{
					methodInfo2
				}, false).Call));
				result = 1;
			}
			catch (Exception ex)
			{
				string str2 = "c# exception in GenericMethodWraper: ";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str2 + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int GetGenericMethod(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Type type = StaticLuaCallbacks.getType(L, objectTranslator, 1);
				if (type == null)
				{
					return Lua.luaL_error(L, "xlua.get_generic_method, can not find c# type");
				}
				string text = Lua.lua_tostring(L, 2);
				if (string.IsNullOrEmpty(text))
				{
					return Lua.luaL_error(L, "xlua.get_generic_method, #2 param need a string");
				}
				List<MethodInfo> list = new List<MethodInfo>();
				foreach (MethodInfo methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
				{
					if (methodInfo.Name == text && methodInfo.IsGenericMethodDefinition)
					{
						list.Add(methodInfo);
					}
				}
				int index = 0;
				if (list.Count == 0)
				{
					Lua.lua_pushnil(L);
				}
				else
				{
					if (Lua.lua_isinteger(L, 3))
					{
						index = Lua.xlua_tointeger(L, 3);
					}
					objectTranslator.PushAny(L, list[index]);
					Lua.lua_pushstdcallcfunction(L, new lua_CSFunction(StaticLuaCallbacks.GenericMethodWraper), 1);
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception in xlua.get_generic_method: ";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int ReleaseCsObject(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslatorPool.Instance.Find(L).ReleaseCSObj(L, 1);
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception in ReleaseCsObject: ";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		internal lua_CSFunction GcMeta;

		internal lua_CSFunction ToStringMeta;

		internal lua_CSFunction EnumAndMeta;

		internal lua_CSFunction EnumOrMeta;

		internal lua_CSFunction StaticCSFunctionWraper;

		internal lua_CSFunction FixCSFunctionWraper;

		internal lua_CSFunction DelegateCtor;
	}
}
