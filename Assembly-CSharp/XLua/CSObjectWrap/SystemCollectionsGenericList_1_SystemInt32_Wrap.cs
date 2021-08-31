using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class SystemCollectionsGenericList_1_SystemInt32_Wrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(List<int>);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 29, 2, 1, -1);
			Utils.RegisterFunc(L, -3, "Add", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_Add));
			Utils.RegisterFunc(L, -3, "AddRange", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_AddRange));
			Utils.RegisterFunc(L, -3, "AsReadOnly", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_AsReadOnly));
			Utils.RegisterFunc(L, -3, "BinarySearch", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_BinarySearch));
			Utils.RegisterFunc(L, -3, "Clear", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_Clear));
			Utils.RegisterFunc(L, -3, "Contains", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_Contains));
			Utils.RegisterFunc(L, -3, "CopyTo", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_CopyTo));
			Utils.RegisterFunc(L, -3, "Exists", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_Exists));
			Utils.RegisterFunc(L, -3, "Find", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_Find));
			Utils.RegisterFunc(L, -3, "FindAll", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_FindAll));
			Utils.RegisterFunc(L, -3, "FindIndex", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_FindIndex));
			Utils.RegisterFunc(L, -3, "FindLast", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_FindLast));
			Utils.RegisterFunc(L, -3, "FindLastIndex", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_FindLastIndex));
			Utils.RegisterFunc(L, -3, "ForEach", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_ForEach));
			Utils.RegisterFunc(L, -3, "GetEnumerator", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_GetEnumerator));
			Utils.RegisterFunc(L, -3, "GetRange", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_GetRange));
			Utils.RegisterFunc(L, -3, "IndexOf", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_IndexOf));
			Utils.RegisterFunc(L, -3, "Insert", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_Insert));
			Utils.RegisterFunc(L, -3, "InsertRange", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_InsertRange));
			Utils.RegisterFunc(L, -3, "LastIndexOf", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_LastIndexOf));
			Utils.RegisterFunc(L, -3, "Remove", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_Remove));
			Utils.RegisterFunc(L, -3, "RemoveAll", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_RemoveAll));
			Utils.RegisterFunc(L, -3, "RemoveAt", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_RemoveAt));
			Utils.RegisterFunc(L, -3, "RemoveRange", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_RemoveRange));
			Utils.RegisterFunc(L, -3, "Reverse", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_Reverse));
			Utils.RegisterFunc(L, -3, "Sort", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_Sort));
			Utils.RegisterFunc(L, -3, "ToArray", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_ToArray));
			Utils.RegisterFunc(L, -3, "TrimExcess", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_TrimExcess));
			Utils.RegisterFunc(L, -3, "TrueForAll", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._m_TrueForAll));
			Utils.RegisterFunc(L, -2, "Capacity", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._g_get_Capacity));
			Utils.RegisterFunc(L, -2, "Count", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._g_get_Count));
			Utils.RegisterFunc(L, -1, "Capacity", new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap._s_set_Capacity));
			Utils.EndObjectRegister(typeFromHandle, L, translator, new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap.__CSIndexer), new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap.__NewIndexer), null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(SystemCollectionsGenericList_1_SystemInt32_Wrap.__CreateInstance), 1, 0, 0);
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (Lua.lua_gettop(L) == 1)
				{
					List<int> o = new List<int>();
					objectTranslator.Push(L, o);
					return 1;
				}
				if (Lua.lua_gettop(L) == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					List<int> o2 = new List<int>(Lua.xlua_tointeger(L, 2));
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (Lua.lua_gettop(L) == 2 && objectTranslator.Assignable<IEnumerable<int>>(L, 2))
				{
					List<int> o3 = new List<int>((IEnumerable<int>)objectTranslator.GetObject(L, 2, typeof(IEnumerable<int>)));
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
			return Lua.luaL_error(L, "invalid arguments to System.Collections.Generic.List<int> constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int __CSIndexer(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<List<int>>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
					int index = Lua.xlua_tointeger(L, 2);
					Lua.lua_pushboolean(L, true);
					Lua.xlua_pushinteger(L, list[index]);
					return 2;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			Lua.lua_pushboolean(L, false);
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int __NewIndexer(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			try
			{
				if (objectTranslator.Assignable<List<int>>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
					int index = Lua.xlua_tointeger(L, 2);
					list[index] = Lua.xlua_tointeger(L, 3);
					Lua.lua_pushboolean(L, true);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			Lua.lua_pushboolean(L, false);
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Add(IntPtr L)
		{
			int result;
			try
			{
				List<int> list = (List<int>)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int item = Lua.xlua_tointeger(L, 2);
				list.Add(item);
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
		private static int _m_AddRange(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
				IEnumerable<int> collection = (IEnumerable<int>)objectTranslator.GetObject(L, 2, typeof(IEnumerable<int>));
				list.AddRange(collection);
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
		private static int _m_AsReadOnly(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				ReadOnlyCollection<int> o = ((List<int>)objectTranslator.FastGetCSObj(L, 1)).AsReadOnly();
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
		private static int _m_BinarySearch(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int item = Lua.xlua_tointeger(L, 2);
					int value = list.BinarySearch(item);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<IComparer<int>>(L, 3))
				{
					int item2 = Lua.xlua_tointeger(L, 2);
					IComparer<int> comparer = (IComparer<int>)objectTranslator.GetObject(L, 3, typeof(IComparer<int>));
					int value2 = list.BinarySearch(item2, comparer);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
				if (num == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && objectTranslator.Assignable<IComparer<int>>(L, 5))
				{
					int index = Lua.xlua_tointeger(L, 2);
					int count = Lua.xlua_tointeger(L, 3);
					int item3 = Lua.xlua_tointeger(L, 4);
					IComparer<int> comparer2 = (IComparer<int>)objectTranslator.GetObject(L, 5, typeof(IComparer<int>));
					int value3 = list.BinarySearch(index, count, item3, comparer2);
					Lua.xlua_pushinteger(L, value3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to System.Collections.Generic.List<int>.BinarySearch!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Clear(IntPtr L)
		{
			int result;
			try
			{
				((List<int>)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Clear();
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
		private static int _m_Contains(IntPtr L)
		{
			int result;
			try
			{
				List<int> list = (List<int>)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int item = Lua.xlua_tointeger(L, 2);
				bool value = list.Contains(item);
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
		private static int _m_CopyTo(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<int[]>(L, 2))
				{
					int[] array = (int[])objectTranslator.GetObject(L, 2, typeof(int[]));
					list.CopyTo(array);
					return 0;
				}
				if (num == 3 && objectTranslator.Assignable<int[]>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					int[] array2 = (int[])objectTranslator.GetObject(L, 2, typeof(int[]));
					int arrayIndex = Lua.xlua_tointeger(L, 3);
					list.CopyTo(array2, arrayIndex);
					return 0;
				}
				if (num == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<int[]>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					int index = Lua.xlua_tointeger(L, 2);
					int[] array3 = (int[])objectTranslator.GetObject(L, 3, typeof(int[]));
					int arrayIndex2 = Lua.xlua_tointeger(L, 4);
					int count = Lua.xlua_tointeger(L, 5);
					list.CopyTo(index, array3, arrayIndex2, count);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to System.Collections.Generic.List<int>.CopyTo!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Exists(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
				Predicate<int> @delegate = objectTranslator.GetDelegate<Predicate<int>>(L, 2);
				bool value = list.Exists(@delegate);
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
		private static int _m_Find(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
				Predicate<int> @delegate = objectTranslator.GetDelegate<Predicate<int>>(L, 2);
				int value = list.Find(@delegate);
				Lua.xlua_pushinteger(L, value);
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
		private static int _m_FindAll(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
				Predicate<int> @delegate = objectTranslator.GetDelegate<Predicate<int>>(L, 2);
				List<int> o = list.FindAll(@delegate);
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
		private static int _m_FindIndex(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Predicate<int>>(L, 2))
				{
					Predicate<int> @delegate = objectTranslator.GetDelegate<Predicate<int>>(L, 2);
					int value = list.FindIndex(@delegate);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<Predicate<int>>(L, 3))
				{
					int startIndex = Lua.xlua_tointeger(L, 2);
					Predicate<int> delegate2 = objectTranslator.GetDelegate<Predicate<int>>(L, 3);
					int value2 = list.FindIndex(startIndex, delegate2);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<Predicate<int>>(L, 4))
				{
					int startIndex2 = Lua.xlua_tointeger(L, 2);
					int count = Lua.xlua_tointeger(L, 3);
					Predicate<int> delegate3 = objectTranslator.GetDelegate<Predicate<int>>(L, 4);
					int value3 = list.FindIndex(startIndex2, count, delegate3);
					Lua.xlua_pushinteger(L, value3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to System.Collections.Generic.List<int>.FindIndex!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_FindLast(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
				Predicate<int> @delegate = objectTranslator.GetDelegate<Predicate<int>>(L, 2);
				int value = list.FindLast(@delegate);
				Lua.xlua_pushinteger(L, value);
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
		private static int _m_FindLastIndex(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Predicate<int>>(L, 2))
				{
					Predicate<int> @delegate = objectTranslator.GetDelegate<Predicate<int>>(L, 2);
					int value = list.FindLastIndex(@delegate);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<Predicate<int>>(L, 3))
				{
					int startIndex = Lua.xlua_tointeger(L, 2);
					Predicate<int> delegate2 = objectTranslator.GetDelegate<Predicate<int>>(L, 3);
					int value2 = list.FindLastIndex(startIndex, delegate2);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<Predicate<int>>(L, 4))
				{
					int startIndex2 = Lua.xlua_tointeger(L, 2);
					int count = Lua.xlua_tointeger(L, 3);
					Predicate<int> delegate3 = objectTranslator.GetDelegate<Predicate<int>>(L, 4);
					int value3 = list.FindLastIndex(startIndex2, count, delegate3);
					Lua.xlua_pushinteger(L, value3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to System.Collections.Generic.List<int>.FindLastIndex!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ForEach(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
				Action<int> @delegate = objectTranslator.GetDelegate<Action<int>>(L, 2);
				list.ForEach(@delegate);
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
		private static int _m_GetEnumerator(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int>.Enumerator enumerator = ((List<int>)objectTranslator.FastGetCSObj(L, 1)).GetEnumerator();
				objectTranslator.Push(L, enumerator);
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
		private static int _m_GetRange(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
				int index = Lua.xlua_tointeger(L, 2);
				int count = Lua.xlua_tointeger(L, 3);
				List<int> range = list.GetRange(index, count);
				objectTranslator.Push(L, range);
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
		private static int _m_IndexOf(IntPtr L)
		{
			try
			{
				List<int> list = (List<int>)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int item = Lua.xlua_tointeger(L, 2);
					int value = list.IndexOf(item);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					int item2 = Lua.xlua_tointeger(L, 2);
					int index = Lua.xlua_tointeger(L, 3);
					int value2 = list.IndexOf(item2, index);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					int item3 = Lua.xlua_tointeger(L, 2);
					int index2 = Lua.xlua_tointeger(L, 3);
					int count = Lua.xlua_tointeger(L, 4);
					int value3 = list.IndexOf(item3, index2, count);
					Lua.xlua_pushinteger(L, value3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to System.Collections.Generic.List<int>.IndexOf!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Insert(IntPtr L)
		{
			int result;
			try
			{
				List<int> list = (List<int>)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int index = Lua.xlua_tointeger(L, 2);
				int item = Lua.xlua_tointeger(L, 3);
				list.Insert(index, item);
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
		private static int _m_InsertRange(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
				int index = Lua.xlua_tointeger(L, 2);
				IEnumerable<int> collection = (IEnumerable<int>)objectTranslator.GetObject(L, 3, typeof(IEnumerable<int>));
				list.InsertRange(index, collection);
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
		private static int _m_LastIndexOf(IntPtr L)
		{
			try
			{
				List<int> list = (List<int>)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int item = Lua.xlua_tointeger(L, 2);
					int value = list.LastIndexOf(item);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					int item2 = Lua.xlua_tointeger(L, 2);
					int index = Lua.xlua_tointeger(L, 3);
					int value2 = list.LastIndexOf(item2, index);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					int item3 = Lua.xlua_tointeger(L, 2);
					int index2 = Lua.xlua_tointeger(L, 3);
					int count = Lua.xlua_tointeger(L, 4);
					int value3 = list.LastIndexOf(item3, index2, count);
					Lua.xlua_pushinteger(L, value3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to System.Collections.Generic.List<int>.LastIndexOf!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Remove(IntPtr L)
		{
			int result;
			try
			{
				List<int> list = (List<int>)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int item = Lua.xlua_tointeger(L, 2);
				bool value = list.Remove(item);
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
		private static int _m_RemoveAll(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
				Predicate<int> @delegate = objectTranslator.GetDelegate<Predicate<int>>(L, 2);
				int value = list.RemoveAll(@delegate);
				Lua.xlua_pushinteger(L, value);
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
		private static int _m_RemoveAt(IntPtr L)
		{
			int result;
			try
			{
				List<int> list = (List<int>)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int index = Lua.xlua_tointeger(L, 2);
				list.RemoveAt(index);
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
		private static int _m_RemoveRange(IntPtr L)
		{
			int result;
			try
			{
				List<int> list = (List<int>)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int index = Lua.xlua_tointeger(L, 2);
				int count = Lua.xlua_tointeger(L, 3);
				list.RemoveRange(index, count);
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
		private static int _m_Reverse(IntPtr L)
		{
			try
			{
				List<int> list = (List<int>)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					list.Reverse();
					return 0;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					int index = Lua.xlua_tointeger(L, 2);
					int count = Lua.xlua_tointeger(L, 3);
					list.Reverse(index, count);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to System.Collections.Generic.List<int>.Reverse!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Sort(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					list.Sort();
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<IComparer<int>>(L, 2))
				{
					IComparer<int> comparer = (IComparer<int>)objectTranslator.GetObject(L, 2, typeof(IComparer<int>));
					list.Sort(comparer);
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<Comparison<int>>(L, 2))
				{
					Comparison<int> @delegate = objectTranslator.GetDelegate<Comparison<int>>(L, 2);
					list.Sort(@delegate);
					return 0;
				}
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<IComparer<int>>(L, 4))
				{
					int index = Lua.xlua_tointeger(L, 2);
					int count = Lua.xlua_tointeger(L, 3);
					IComparer<int> comparer2 = (IComparer<int>)objectTranslator.GetObject(L, 4, typeof(IComparer<int>));
					list.Sort(index, count, comparer2);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to System.Collections.Generic.List<int>.Sort!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ToArray(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int[] o = ((List<int>)objectTranslator.FastGetCSObj(L, 1)).ToArray();
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
		private static int _m_TrimExcess(IntPtr L)
		{
			int result;
			try
			{
				((List<int>)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).TrimExcess();
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
		private static int _m_TrueForAll(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				List<int> list = (List<int>)objectTranslator.FastGetCSObj(L, 1);
				Predicate<int> @delegate = objectTranslator.GetDelegate<Predicate<int>>(L, 2);
				bool value = list.TrueForAll(@delegate);
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
		private static int _g_get_Capacity(IntPtr L)
		{
			try
			{
				List<int> list = (List<int>)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, list.Capacity);
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
		private static int _g_get_Count(IntPtr L)
		{
			try
			{
				List<int> list = (List<int>)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, list.Count);
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
		private static int _s_set_Capacity(IntPtr L)
		{
			try
			{
				((List<int>)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Capacity = Lua.xlua_tointeger(L, 2);
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
