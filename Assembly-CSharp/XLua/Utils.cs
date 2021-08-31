using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using XLua.LuaDLL;

namespace XLua
{
	public static class Utils
	{
		public static bool LoadField(IntPtr L, int idx, string field_name)
		{
			idx = ((idx > 0) ? idx : (Lua.lua_gettop(L) + idx + 1));
			Lua.xlua_pushasciistring(L, field_name);
			Lua.lua_rawget(L, idx);
			return !Lua.lua_isnil(L, -1);
		}

		public static IntPtr GetMainState(IntPtr L)
		{
			IntPtr result = 0;
			Lua.xlua_pushasciistring(L, "xlua_main_thread");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			if (Lua.lua_isthread(L, -1))
			{
				result = Lua.lua_tothread(L, -1);
			}
			Lua.lua_pop(L, 1);
			return result;
		}

		public static List<Type> GetAllTypes(bool exclude_generic_definition = true)
		{
			List<Type> list = new List<Type>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			Func<Type, bool> <>9__0;
			for (int i = 0; i < assemblies.Length; i++)
			{
				try
				{
					List<Type> list2 = list;
					IEnumerable<Type> types = assemblies[i].GetTypes();
					Func<Type, bool> predicate;
					if ((predicate = <>9__0) == null)
					{
						predicate = (<>9__0 = ((Type type) => !exclude_generic_definition || !type.IsGenericTypeDefinition()));
					}
					list2.AddRange(types.Where(predicate));
				}
				catch (Exception)
				{
				}
			}
			return list;
		}

		private static lua_CSFunction genFieldGetter(Type type, FieldInfo field)
		{
			if (field.IsStatic)
			{
				return delegate(IntPtr L)
				{
					ObjectTranslatorPool.Instance.Find(L).PushAny(L, field.GetValue(null));
					return 1;
				};
			}
			return delegate(IntPtr L)
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				object obj = objectTranslator.FastGetCSObj(L, 1);
				if (obj == null || !type.IsInstanceOfType(obj))
				{
					string[] array = new string[6];
					array[0] = "Expected type ";
					int num = 1;
					Type type2 = type;
					array[num] = ((type2 != null) ? type2.ToString() : null);
					array[2] = ", but got ";
					array[3] = ((obj == null) ? "null" : obj.GetType().ToString());
					array[4] = ", while get field ";
					int num2 = 5;
					FieldInfo field2 = field;
					array[num2] = ((field2 != null) ? field2.ToString() : null);
					return Lua.luaL_error(L, string.Concat(array));
				}
				objectTranslator.PushAny(L, field.GetValue(obj));
				return 1;
			};
		}

		private static lua_CSFunction genFieldSetter(Type type, FieldInfo field)
		{
			if (field.IsStatic)
			{
				return delegate(IntPtr L)
				{
					object @object = ObjectTranslatorPool.Instance.Find(L).GetObject(L, 1, field.FieldType);
					if (field.FieldType.IsValueType() && Nullable.GetUnderlyingType(field.FieldType) == null && @object == null)
					{
						string[] array = new string[5];
						array[0] = type.Name;
						array[1] = ".";
						array[2] = field.Name;
						array[3] = " Expected type ";
						int num = 4;
						Type fieldType = field.FieldType;
						array[num] = ((fieldType != null) ? fieldType.ToString() : null);
						return Lua.luaL_error(L, string.Concat(array));
					}
					field.SetValue(null, @object);
					return 0;
				};
			}
			return delegate(IntPtr L)
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				object obj = objectTranslator.FastGetCSObj(L, 1);
				if (obj == null || !type.IsInstanceOfType(obj))
				{
					string[] array = new string[6];
					array[0] = "Expected type ";
					int num = 1;
					Type type2 = type;
					array[num] = ((type2 != null) ? type2.ToString() : null);
					array[2] = ", but got ";
					array[3] = ((obj == null) ? "null" : obj.GetType().ToString());
					array[4] = ", while set field ";
					int num2 = 5;
					FieldInfo field2 = field;
					array[num2] = ((field2 != null) ? field2.ToString() : null);
					return Lua.luaL_error(L, string.Concat(array));
				}
				object @object = objectTranslator.GetObject(L, 2, field.FieldType);
				if (field.FieldType.IsValueType() && Nullable.GetUnderlyingType(field.FieldType) == null && @object == null)
				{
					string[] array2 = new string[5];
					array2[0] = type.Name;
					array2[1] = ".";
					array2[2] = field.Name;
					array2[3] = " Expected type ";
					int num3 = 4;
					Type fieldType = field.FieldType;
					array2[num3] = ((fieldType != null) ? fieldType.ToString() : null);
					return Lua.luaL_error(L, string.Concat(array2));
				}
				field.SetValue(obj, @object);
				if (type.IsValueType())
				{
					objectTranslator.Update(L, 1, obj);
				}
				return 0;
			};
		}

		private static lua_CSFunction genItemGetter(Type type, PropertyInfo[] props)
		{
			props = (from prop in props
			where !prop.GetIndexParameters()[0].ParameterType.IsAssignableFrom(typeof(string))
			select prop).ToArray<PropertyInfo>();
			if (props.Length == 0)
			{
				return null;
			}
			Type[] params_type = new Type[props.Length];
			for (int i = 0; i < props.Length; i++)
			{
				params_type[i] = props[i].GetIndexParameters()[0].ParameterType;
			}
			object[] arg = new object[1];
			return delegate(IntPtr L)
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				object obj = objectTranslator.FastGetCSObj(L, 1);
				if (obj == null || !type.IsInstanceOfType(obj))
				{
					string[] array = new string[6];
					array[0] = "Expected type ";
					int num = 1;
					Type type2 = type;
					array[num] = ((type2 != null) ? type2.ToString() : null);
					array[2] = ", but got ";
					array[3] = ((obj == null) ? "null" : obj.GetType().ToString());
					array[4] = ", while get prop ";
					array[5] = props[0].Name;
					return Lua.luaL_error(L, string.Concat(array));
				}
				for (int j = 0; j < props.Length; j++)
				{
					if (objectTranslator.Assignable(L, 2, params_type[j]))
					{
						PropertyInfo propertyInfo = props[j];
						try
						{
							object @object = objectTranslator.GetObject(L, 2, params_type[j]);
							arg[0] = @object;
							object value = propertyInfo.GetValue(obj, arg);
							Lua.lua_pushboolean(L, true);
							objectTranslator.PushAny(L, value);
							return 2;
						}
						catch (Exception ex)
						{
							string[] array2 = new string[8];
							array2[0] = "try to get ";
							int num2 = 1;
							Type type3 = type;
							array2[num2] = ((type3 != null) ? type3.ToString() : null);
							array2[2] = ".";
							array2[3] = propertyInfo.Name;
							array2[4] = " throw a exception:";
							int num3 = 5;
							Exception ex2 = ex;
							array2[num3] = ((ex2 != null) ? ex2.ToString() : null);
							array2[6] = ",stack:";
							array2[7] = ex.StackTrace;
							return Lua.luaL_error(L, string.Concat(array2));
						}
					}
				}
				Lua.lua_pushboolean(L, false);
				return 1;
			};
		}

		private static lua_CSFunction genItemSetter(Type type, PropertyInfo[] props)
		{
			props = (from prop in props
			where !prop.GetIndexParameters()[0].ParameterType.IsAssignableFrom(typeof(string))
			select prop).ToArray<PropertyInfo>();
			if (props.Length == 0)
			{
				return null;
			}
			Type[] params_type = new Type[props.Length];
			for (int i = 0; i < props.Length; i++)
			{
				params_type[i] = props[i].GetIndexParameters()[0].ParameterType;
			}
			object[] arg = new object[1];
			return delegate(IntPtr L)
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				object obj = objectTranslator.FastGetCSObj(L, 1);
				if (obj == null || !type.IsInstanceOfType(obj))
				{
					string[] array = new string[6];
					array[0] = "Expected type ";
					int num = 1;
					Type type2 = type;
					array[num] = ((type2 != null) ? type2.ToString() : null);
					array[2] = ", but got ";
					array[3] = ((obj == null) ? "null" : obj.GetType().ToString());
					array[4] = ", while set prop ";
					array[5] = props[0].Name;
					return Lua.luaL_error(L, string.Concat(array));
				}
				for (int j = 0; j < props.Length; j++)
				{
					if (objectTranslator.Assignable(L, 2, params_type[j]))
					{
						PropertyInfo propertyInfo = props[j];
						try
						{
							arg[0] = objectTranslator.GetObject(L, 2, params_type[j]);
							object @object = objectTranslator.GetObject(L, 3, propertyInfo.PropertyType);
							if (@object == null)
							{
								string[] array2 = new string[5];
								array2[0] = type.Name;
								array2[1] = ".";
								array2[2] = propertyInfo.Name;
								array2[3] = " Expected type ";
								int num2 = 4;
								Type propertyType = propertyInfo.PropertyType;
								array2[num2] = ((propertyType != null) ? propertyType.ToString() : null);
								return Lua.luaL_error(L, string.Concat(array2));
							}
							propertyInfo.SetValue(obj, @object, arg);
							Lua.lua_pushboolean(L, true);
							return 1;
						}
						catch (Exception ex)
						{
							string[] array3 = new string[8];
							array3[0] = "try to set ";
							int num3 = 1;
							Type type3 = type;
							array3[num3] = ((type3 != null) ? type3.ToString() : null);
							array3[2] = ".";
							array3[3] = propertyInfo.Name;
							array3[4] = " throw a exception:";
							int num4 = 5;
							Exception ex2 = ex;
							array3[num4] = ((ex2 != null) ? ex2.ToString() : null);
							array3[6] = ",stack:";
							array3[7] = ex.StackTrace;
							return Lua.luaL_error(L, string.Concat(array3));
						}
					}
				}
				Lua.lua_pushboolean(L, false);
				return 1;
			};
		}

		private static lua_CSFunction genEnumCastFrom(Type type)
		{
			return delegate(IntPtr L)
			{
				int result;
				try
				{
					result = ObjectTranslatorPool.Instance.Find(L).TranslateToEnumToTop(L, type, 1);
				}
				catch (Exception ex)
				{
					string str = "cast to ";
					Type type2 = type;
					string str2 = (type2 != null) ? type2.ToString() : null;
					string str3 = " exception:";
					Exception ex2 = ex;
					result = Lua.luaL_error(L, str + str2 + str3 + ((ex2 != null) ? ex2.ToString() : null));
				}
				return result;
			};
		}

		internal static IEnumerable<MethodInfo> GetExtensionMethodsOf(Type type_to_be_extend)
		{
			if (InternalGlobals.extensionMethodMap == null)
			{
				List<Type> list = new List<Type>();
				IEnumerator<Type> enumerator = Utils.GetAllTypes(true).GetEnumerator();
				while (enumerator.MoveNext())
				{
					Type type2 = enumerator.Current;
					if (type2.IsDefined(typeof(ExtensionAttribute), false) && type2.IsDefined(typeof(ReflectionUseAttribute), false))
					{
						list.Add(type2);
					}
					if (type2.IsAbstract() && type2.IsSealed())
					{
						foreach (FieldInfo fieldInfo in type2.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
						{
							if (fieldInfo.IsDefined(typeof(ReflectionUseAttribute), false) && typeof(IEnumerable<Type>).IsAssignableFrom(fieldInfo.FieldType))
							{
								list.AddRange(from t in fieldInfo.GetValue(null) as IEnumerable<Type>
								where t.IsDefined(typeof(ExtensionAttribute), false)
								select t);
							}
						}
						foreach (PropertyInfo propertyInfo in type2.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
						{
							if (propertyInfo.IsDefined(typeof(ReflectionUseAttribute), false) && typeof(IEnumerable<Type>).IsAssignableFrom(propertyInfo.PropertyType))
							{
								list.AddRange(from t in propertyInfo.GetValue(null, null) as IEnumerable<Type>
								where t.IsDefined(typeof(ExtensionAttribute), false)
								select t);
							}
						}
					}
				}
				enumerator.Dispose();
				InternalGlobals.extensionMethodMap = (from type in list
				from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public)
				where method.IsDefined(typeof(ExtensionAttribute), false) && Utils.IsSupportedMethod(method)
				group method by Utils.getExtendedType(method)).ToDictionary((IGrouping<Type, MethodInfo> g) => g.Key, (IGrouping<Type, MethodInfo> g) => g);
			}
			IEnumerable<MethodInfo> result = null;
			InternalGlobals.extensionMethodMap.TryGetValue(type_to_be_extend, out result);
			return result;
		}

		private static void makeReflectionWrap(IntPtr L, Type type, int cls_field, int cls_getter, int cls_setter, int obj_field, int obj_getter, int obj_setter, int obj_meta, out lua_CSFunction item_getter, out lua_CSFunction item_setter, BindingFlags access)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			BindingFlags bindingFlags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | access;
			FieldInfo[] fields = type.GetFields(bindingFlags);
			EventInfo[] events = type.GetEvents(bindingFlags | BindingFlags.Public | BindingFlags.NonPublic);
			Lua.lua_checkstack(L, 2);
			for (int i = 0; i < fields.Length; i++)
			{
				FieldInfo fieldInfo = fields[i];
				string fieldName = fieldInfo.Name;
				if (!fieldInfo.IsStatic || (!fieldInfo.Name.StartsWith("__Hotfix") && !fieldInfo.Name.StartsWith("_c__Hotfix")) || !typeof(Delegate).IsAssignableFrom(fieldInfo.FieldType))
				{
					if (events.Any((EventInfo e) => e.Name == fieldName))
					{
						fieldName = "&" + fieldName;
					}
					if (fieldInfo.IsStatic && (fieldInfo.IsInitOnly || fieldInfo.IsLiteral))
					{
						Lua.xlua_pushasciistring(L, fieldName);
						objectTranslator.PushAny(L, fieldInfo.GetValue(null));
						Lua.lua_rawset(L, cls_field);
					}
					else
					{
						Lua.xlua_pushasciistring(L, fieldName);
						objectTranslator.PushFixCSFunction(L, Utils.genFieldGetter(type, fieldInfo));
						Lua.lua_rawset(L, fieldInfo.IsStatic ? cls_getter : obj_getter);
						Lua.xlua_pushasciistring(L, fieldName);
						objectTranslator.PushFixCSFunction(L, Utils.genFieldSetter(type, fieldInfo));
						Lua.lua_rawset(L, fieldInfo.IsStatic ? cls_setter : obj_setter);
					}
				}
			}
			foreach (EventInfo eventInfo in type.GetEvents(bindingFlags))
			{
				Lua.xlua_pushasciistring(L, eventInfo.Name);
				objectTranslator.PushFixCSFunction(L, objectTranslator.methodWrapsCache.GetEventWrap(type, eventInfo.Name));
				Lua.lua_rawset(L, ((eventInfo.GetAddMethod(true) != null) ? eventInfo.GetAddMethod(true).IsStatic : eventInfo.GetRemoveMethod(true).IsStatic) ? cls_field : obj_field);
			}
			List<PropertyInfo> list = new List<PropertyInfo>();
			foreach (PropertyInfo propertyInfo in type.GetProperties(bindingFlags))
			{
				if (propertyInfo.GetIndexParameters().Length != 0)
				{
					list.Add(propertyInfo);
				}
			}
			PropertyInfo[] array = list.ToArray();
			item_getter = ((array.Length != 0) ? Utils.genItemGetter(type, array) : null);
			item_setter = ((array.Length != 0) ? Utils.genItemSetter(type, array) : null);
			MethodInfo[] array2 = type.GetMethods(bindingFlags);
			if (access == BindingFlags.NonPublic)
			{
				array2 = (from p in type.GetMethods(bindingFlags | BindingFlags.Public)
				join q in array2 on p.Name equals q.Name
				select p).ToArray<MethodInfo>();
			}
			Dictionary<Utils.MethodKey, List<MemberInfo>> dictionary = new Dictionary<Utils.MethodKey, List<MemberInfo>>();
			foreach (MethodInfo methodInfo in array2)
			{
				string name = methodInfo.Name;
				Utils.MethodKey key = new Utils.MethodKey
				{
					Name = name,
					IsStatic = methodInfo.IsStatic
				};
				List<MemberInfo> list2;
				if (dictionary.TryGetValue(key, out list2))
				{
					list2.Add(methodInfo);
				}
				else if ((!methodInfo.IsSpecialName || ((!(methodInfo.Name == "get_Item") || methodInfo.GetParameters().Length != 1) && (!(methodInfo.Name == "set_Item") || methodInfo.GetParameters().Length != 2)) || methodInfo.GetParameters()[0].ParameterType.IsAssignableFrom(typeof(string))) && ((!name.StartsWith("add_") && !name.StartsWith("remove_")) || !methodInfo.IsSpecialName))
				{
					if (name.StartsWith("op_") && methodInfo.IsSpecialName)
					{
						if (InternalGlobals.supportOp.ContainsKey(name))
						{
							if (list2 == null)
							{
								list2 = new List<MemberInfo>();
								dictionary.Add(key, list2);
							}
							list2.Add(methodInfo);
						}
					}
					else if (name.StartsWith("get_") && methodInfo.IsSpecialName && methodInfo.GetParameters().Length != 1)
					{
						string text = methodInfo.Name.Substring(4);
						Lua.xlua_pushasciistring(L, text);
						objectTranslator.PushFixCSFunction(L, new lua_CSFunction(objectTranslator.methodWrapsCache._GenMethodWrap(methodInfo.DeclaringType, text, new MethodBase[]
						{
							methodInfo
						}, false).Call));
						Lua.lua_rawset(L, methodInfo.IsStatic ? cls_getter : obj_getter);
					}
					else if (name.StartsWith("set_") && methodInfo.IsSpecialName && methodInfo.GetParameters().Length != 2)
					{
						string text2 = methodInfo.Name.Substring(4);
						Lua.xlua_pushasciistring(L, text2);
						objectTranslator.PushFixCSFunction(L, new lua_CSFunction(objectTranslator.methodWrapsCache._GenMethodWrap(methodInfo.DeclaringType, text2, new MethodBase[]
						{
							methodInfo
						}, false).Call));
						Lua.lua_rawset(L, methodInfo.IsStatic ? cls_setter : obj_setter);
					}
					else if (!(name == ".ctor") || !methodInfo.IsConstructor)
					{
						if (list2 == null)
						{
							list2 = new List<MemberInfo>();
							dictionary.Add(key, list2);
						}
						list2.Add(methodInfo);
					}
				}
			}
			IEnumerable<MethodInfo> extensionMethodsOf = Utils.GetExtensionMethodsOf(type);
			if (extensionMethodsOf != null)
			{
				foreach (MethodInfo methodInfo2 in extensionMethodsOf)
				{
					Utils.MethodKey key2 = new Utils.MethodKey
					{
						Name = methodInfo2.Name,
						IsStatic = false
					};
					List<MemberInfo> list3;
					if (dictionary.TryGetValue(key2, out list3))
					{
						list3.Add(methodInfo2);
					}
					else
					{
						list3 = new List<MemberInfo>
						{
							methodInfo2
						};
						dictionary.Add(key2, list3);
					}
				}
			}
			foreach (KeyValuePair<Utils.MethodKey, List<MemberInfo>> keyValuePair in dictionary)
			{
				if (keyValuePair.Key.Name.StartsWith("op_"))
				{
					Lua.xlua_pushasciistring(L, InternalGlobals.supportOp[keyValuePair.Key.Name]);
					objectTranslator.PushFixCSFunction(L, new lua_CSFunction(objectTranslator.methodWrapsCache._GenMethodWrap(type, keyValuePair.Key.Name, keyValuePair.Value.ToArray(), false).Call));
					Lua.lua_rawset(L, obj_meta);
				}
				else
				{
					Lua.xlua_pushasciistring(L, keyValuePair.Key.Name);
					objectTranslator.PushFixCSFunction(L, new lua_CSFunction(objectTranslator.methodWrapsCache._GenMethodWrap(type, keyValuePair.Key.Name, keyValuePair.Value.ToArray(), false).Call));
					Lua.lua_rawset(L, keyValuePair.Key.IsStatic ? cls_field : obj_field);
				}
			}
		}

		public static void loadUpvalue(IntPtr L, Type type, string metafunc, int index)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			Lua.xlua_pushasciistring(L, metafunc);
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			objectTranslator.Push(L, type);
			Lua.lua_rawget(L, -2);
			Lua.lua_remove(L, -2);
			for (int i = 1; i <= index; i++)
			{
				Lua.lua_getupvalue(L, -i, i);
				if (Lua.lua_isnil(L, -1))
				{
					Lua.lua_pop(L, 1);
					Lua.lua_newtable(L);
					Lua.lua_pushvalue(L, -1);
					Lua.lua_setupvalue(L, -i - 2, i);
				}
			}
			for (int j = 0; j < index; j++)
			{
				Lua.lua_remove(L, -2);
			}
		}

		public static void RegisterEnumType(IntPtr L, Type type)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			foreach (string text in Enum.GetNames(type))
			{
				Utils.RegisterObject(L, translator, -4, text, Enum.Parse(type, text));
			}
		}

		public static void MakePrivateAccessible(IntPtr L, Type type)
		{
			Lua.lua_checkstack(L, 20);
			int newTop = Lua.lua_gettop(L);
			Lua.luaL_getmetatable(L, type.FullName);
			if (Lua.lua_isnil(L, -1))
			{
				Lua.lua_settop(L, newTop);
				throw new Exception("can not find the metatable for " + ((type != null) ? type.ToString() : null));
			}
			int obj_meta = Lua.lua_gettop(L);
			Utils.LoadCSTable(L, type);
			if (Lua.lua_isnil(L, -1))
			{
				Lua.lua_settop(L, newTop);
				throw new Exception("can not find the class for " + ((type != null) ? type.ToString() : null));
			}
			int cls_field = Lua.lua_gettop(L);
			Utils.loadUpvalue(L, type, "LuaIndexs", 2);
			int obj_getter = Lua.lua_gettop(L);
			Utils.loadUpvalue(L, type, "LuaIndexs", 1);
			int obj_field = Lua.lua_gettop(L);
			Utils.loadUpvalue(L, type, "LuaNewIndexs", 1);
			int obj_setter = Lua.lua_gettop(L);
			Utils.loadUpvalue(L, type, "LuaClassIndexs", 1);
			int cls_getter = Lua.lua_gettop(L);
			Utils.loadUpvalue(L, type, "LuaClassNewIndexs", 1);
			int cls_setter = Lua.lua_gettop(L);
			lua_CSFunction lua_CSFunction;
			lua_CSFunction lua_CSFunction2;
			Utils.makeReflectionWrap(L, type, cls_field, cls_getter, cls_setter, obj_field, obj_getter, obj_setter, obj_meta, out lua_CSFunction, out lua_CSFunction2, BindingFlags.NonPublic);
			Lua.lua_settop(L, newTop);
			foreach (Type type2 in type.GetNestedTypes(BindingFlags.NonPublic))
			{
				if ((type2.IsAbstract() || !typeof(Delegate).IsAssignableFrom(type2)) && !type2.IsGenericTypeDefinition())
				{
					ObjectTranslatorPool.Instance.Find(L).TryDelayWrapLoader(L, type2);
					Utils.MakePrivateAccessible(L, type2);
				}
			}
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		internal static int LazyReflectionCall(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Type type;
				objectTranslator.Get<Type>(L, Lua.xlua_upvalueindex(1), out type);
				LazyMemberTypes lazyMemberTypes = (LazyMemberTypes)Lua.xlua_tointeger(L, Lua.xlua_upvalueindex(2));
				string memberName = Lua.lua_tostring(L, Lua.xlua_upvalueindex(3));
				bool flag = Lua.lua_toboolean(L, Lua.xlua_upvalueindex(4));
				lua_CSFunction lua_CSFunction;
				switch (lazyMemberTypes)
				{
				case LazyMemberTypes.Method:
				{
					MemberInfo[] member = type.GetMember(memberName);
					if (member == null || member.Length == 0)
					{
						string str = "can not find ";
						string memberName5 = memberName;
						string str2 = " for ";
						Type type2 = type;
						return Lua.luaL_error(L, str + memberName5 + str2 + ((type2 != null) ? type2.ToString() : null));
					}
					IEnumerable<MemberInfo> enumerable = member;
					if (!flag)
					{
						IEnumerable<MethodInfo> extensionMethodsOf = Utils.GetExtensionMethodsOf(type);
						if (extensionMethodsOf != null)
						{
							enumerable = enumerable.Concat((from m in extensionMethodsOf
							where m.Name == memberName
							select m).Cast<MemberInfo>());
						}
					}
					lua_CSFunction = new lua_CSFunction(objectTranslator.methodWrapsCache._GenMethodWrap(type, memberName, enumerable.ToArray<MemberInfo>(), false).Call);
					if (flag)
					{
						Utils.LoadCSTable(L, type);
					}
					else
					{
						Utils.loadUpvalue(L, type, "LuaIndexs", 1);
					}
					if (Lua.lua_isnil(L, -1))
					{
						string str3 = "can not find the meta info for ";
						Type type3 = type;
						return Lua.luaL_error(L, str3 + ((type3 != null) ? type3.ToString() : null));
					}
					break;
				}
				case LazyMemberTypes.FieldGet:
				case LazyMemberTypes.FieldSet:
				{
					FieldInfo field = type.GetField(memberName);
					if (field == null)
					{
						string str4 = "can not find ";
						string memberName2 = memberName;
						string str5 = " for ";
						Type type4 = type;
						return Lua.luaL_error(L, str4 + memberName2 + str5 + ((type4 != null) ? type4.ToString() : null));
					}
					if (flag)
					{
						if (lazyMemberTypes == LazyMemberTypes.FieldGet)
						{
							Utils.loadUpvalue(L, type, "LuaClassIndexs", 1);
						}
						else
						{
							Utils.loadUpvalue(L, type, "LuaClassNewIndexs", 1);
						}
					}
					else if (lazyMemberTypes == LazyMemberTypes.FieldGet)
					{
						Utils.loadUpvalue(L, type, "LuaIndexs", 2);
					}
					else
					{
						Utils.loadUpvalue(L, type, "LuaNewIndexs", 1);
					}
					lua_CSFunction = ((lazyMemberTypes == LazyMemberTypes.FieldGet) ? Utils.genFieldGetter(type, field) : Utils.genFieldSetter(type, field));
					break;
				}
				case LazyMemberTypes.PropertyGet:
				case LazyMemberTypes.PropertySet:
				{
					PropertyInfo property = type.GetProperty(memberName);
					if (property == null)
					{
						string str6 = "can not find ";
						string memberName3 = memberName;
						string str7 = " for ";
						Type type5 = type;
						return Lua.luaL_error(L, str6 + memberName3 + str7 + ((type5 != null) ? type5.ToString() : null));
					}
					if (flag)
					{
						if (lazyMemberTypes == LazyMemberTypes.PropertyGet)
						{
							Utils.loadUpvalue(L, type, "LuaClassIndexs", 1);
						}
						else
						{
							Utils.loadUpvalue(L, type, "LuaClassNewIndexs", 1);
						}
					}
					else if (lazyMemberTypes == LazyMemberTypes.PropertyGet)
					{
						Utils.loadUpvalue(L, type, "LuaIndexs", 2);
					}
					else
					{
						Utils.loadUpvalue(L, type, "LuaNewIndexs", 1);
					}
					if (Lua.lua_isnil(L, -1))
					{
						string str8 = "can not find the meta info for ";
						Type type6 = type;
						return Lua.luaL_error(L, str8 + ((type6 != null) ? type6.ToString() : null));
					}
					lua_CSFunction = new lua_CSFunction(objectTranslator.methodWrapsCache._GenMethodWrap(property.DeclaringType, property.Name, new MethodBase[]
					{
						(lazyMemberTypes == LazyMemberTypes.PropertyGet) ? property.GetGetMethod() : property.GetSetMethod()
					}, false).Call);
					break;
				}
				case LazyMemberTypes.Event:
				{
					EventInfo @event = type.GetEvent(memberName);
					if (@event == null)
					{
						string str9 = "can not find ";
						string memberName4 = memberName;
						string str10 = " for ";
						Type type7 = type;
						return Lua.luaL_error(L, str9 + memberName4 + str10 + ((type7 != null) ? type7.ToString() : null));
					}
					if (flag)
					{
						Utils.LoadCSTable(L, type);
					}
					else
					{
						Utils.loadUpvalue(L, type, "LuaIndexs", 1);
					}
					if (Lua.lua_isnil(L, -1))
					{
						string str11 = "can not find the meta info for ";
						Type type8 = type;
						return Lua.luaL_error(L, str11 + ((type8 != null) ? type8.ToString() : null));
					}
					lua_CSFunction = objectTranslator.methodWrapsCache.GetEventWrap(type, @event.Name);
					break;
				}
				default:
					return Lua.luaL_error(L, "unsupport member type" + lazyMemberTypes.ToString());
				}
				Lua.xlua_pushasciistring(L, memberName);
				objectTranslator.PushFixCSFunction(L, lua_CSFunction);
				Lua.lua_rawset(L, -3);
				Lua.lua_pop(L, 1);
				result = lua_CSFunction(L);
			}
			catch (Exception ex)
			{
				string str12 = "c# exception in LazyReflectionCall:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str12 + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		public static void ReflectionWrap(IntPtr L, Type type, bool privateAccessible)
		{
			Lua.lua_checkstack(L, 20);
			Lua.lua_gettop(L);
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			Lua.luaL_getmetatable(L, type.FullName);
			if (Lua.lua_isnil(L, -1))
			{
				Lua.lua_pop(L, 1);
				Lua.luaL_newmetatable(L, type.FullName);
			}
			Lua.lua_pushlightuserdata(L, Lua.xlua_tag());
			Lua.lua_pushnumber(L, 1.0);
			Lua.lua_rawset(L, -3);
			int num = Lua.lua_gettop(L);
			Lua.lua_newtable(L);
			int index = Lua.lua_gettop(L);
			Lua.lua_newtable(L);
			int num2 = Lua.lua_gettop(L);
			Lua.lua_newtable(L);
			int num3 = Lua.lua_gettop(L);
			Lua.lua_newtable(L);
			int num4 = Lua.lua_gettop(L);
			Lua.lua_newtable(L);
			int num5 = Lua.lua_gettop(L);
			Utils.SetCSTable(L, type, num5);
			Lua.lua_newtable(L);
			int num6 = Lua.lua_gettop(L);
			Lua.lua_newtable(L);
			int num7 = Lua.lua_gettop(L);
			lua_CSFunction func;
			lua_CSFunction func2;
			Utils.makeReflectionWrap(L, type, num5, num6, num7, num2, num3, num4, num, out func, out func2, privateAccessible ? (BindingFlags.Public | BindingFlags.NonPublic) : BindingFlags.Public);
			Lua.xlua_pushasciistring(L, "__gc");
			Lua.lua_pushstdcallcfunction(L, objectTranslator.metaFunctions.GcMeta, 0);
			Lua.lua_rawset(L, num);
			Lua.xlua_pushasciistring(L, "__tostring");
			Lua.lua_pushstdcallcfunction(L, objectTranslator.metaFunctions.ToStringMeta, 0);
			Lua.lua_rawset(L, num);
			Lua.xlua_pushasciistring(L, "__index");
			Lua.lua_pushvalue(L, num2);
			Lua.lua_pushvalue(L, num3);
			objectTranslator.PushFixCSFunction(L, func);
			objectTranslator.PushAny(L, type.BaseType());
			Lua.xlua_pushasciistring(L, "LuaIndexs");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			Lua.lua_pushnil(L);
			Lua.gen_obj_indexer(L);
			Lua.xlua_pushasciistring(L, "LuaIndexs");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			objectTranslator.Push(L, type);
			Lua.lua_pushvalue(L, -3);
			Lua.lua_rawset(L, -3);
			Lua.lua_pop(L, 1);
			Lua.lua_rawset(L, num);
			Lua.xlua_pushasciistring(L, "__newindex");
			Lua.lua_pushvalue(L, num4);
			objectTranslator.PushFixCSFunction(L, func2);
			objectTranslator.Push(L, type.BaseType());
			Lua.xlua_pushasciistring(L, "LuaNewIndexs");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			Lua.lua_pushnil(L);
			Lua.gen_obj_newindexer(L);
			Lua.xlua_pushasciistring(L, "LuaNewIndexs");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			objectTranslator.Push(L, type);
			Lua.lua_pushvalue(L, -3);
			Lua.lua_rawset(L, -3);
			Lua.lua_pop(L, 1);
			Lua.lua_rawset(L, num);
			Lua.xlua_pushasciistring(L, "UnderlyingSystemType");
			objectTranslator.PushAny(L, type);
			Lua.lua_rawset(L, num5);
			if (type != null && type.IsEnum())
			{
				Lua.xlua_pushasciistring(L, "__CastFrom");
				objectTranslator.PushFixCSFunction(L, Utils.genEnumCastFrom(type));
				Lua.lua_rawset(L, num5);
			}
			Lua.xlua_pushasciistring(L, "__index");
			Lua.lua_pushvalue(L, num6);
			Lua.lua_pushvalue(L, num5);
			objectTranslator.Push(L, type.BaseType());
			Lua.xlua_pushasciistring(L, "LuaClassIndexs");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			Lua.gen_cls_indexer(L);
			Lua.xlua_pushasciistring(L, "LuaClassIndexs");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			objectTranslator.Push(L, type);
			Lua.lua_pushvalue(L, -3);
			Lua.lua_rawset(L, -3);
			Lua.lua_pop(L, 1);
			Lua.lua_rawset(L, index);
			Lua.xlua_pushasciistring(L, "__newindex");
			Lua.lua_pushvalue(L, num7);
			objectTranslator.Push(L, type.BaseType());
			Lua.xlua_pushasciistring(L, "LuaClassNewIndexs");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			Lua.gen_cls_newindexer(L);
			Lua.xlua_pushasciistring(L, "LuaClassNewIndexs");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			objectTranslator.Push(L, type);
			Lua.lua_pushvalue(L, -3);
			Lua.lua_rawset(L, -3);
			Lua.lua_pop(L, 1);
			Lua.lua_rawset(L, index);
			lua_CSFunction lua_CSFunction = typeof(Delegate).IsAssignableFrom(type) ? objectTranslator.metaFunctions.DelegateCtor : objectTranslator.methodWrapsCache.GetConstructorWrap(type);
			if (lua_CSFunction == null)
			{
				lua_CSFunction = delegate(IntPtr LL)
				{
					string str = "No constructor for ";
					Type type2 = type;
					return Lua.luaL_error(LL, str + ((type2 != null) ? type2.ToString() : null));
				};
			}
			Lua.xlua_pushasciistring(L, "__call");
			objectTranslator.PushFixCSFunction(L, lua_CSFunction);
			Lua.lua_rawset(L, index);
			Lua.lua_pushvalue(L, index);
			Lua.lua_setmetatable(L, num5);
			Lua.lua_pop(L, 8);
		}

		public static void BeginObjectRegister(Type type, IntPtr L, ObjectTranslator translator, int meta_count, int method_count, int getter_count, int setter_count, int type_id = -1)
		{
			if (type == null)
			{
				if (type_id == -1)
				{
					throw new Exception("Fatal: must provide a type of type_id");
				}
				Lua.xlua_rawgeti(L, LuaIndexes.LUA_REGISTRYINDEX, (long)type_id);
			}
			else
			{
				Lua.luaL_getmetatable(L, type.FullName);
				if (Lua.lua_isnil(L, -1))
				{
					Lua.lua_pop(L, 1);
					Lua.luaL_newmetatable(L, type.FullName);
				}
			}
			Lua.lua_pushlightuserdata(L, Lua.xlua_tag());
			Lua.lua_pushnumber(L, 1.0);
			Lua.lua_rawset(L, -3);
			if ((type == null || !translator.HasCustomOp(type)) && type != typeof(decimal))
			{
				Lua.xlua_pushasciistring(L, "__gc");
				Lua.lua_pushstdcallcfunction(L, translator.metaFunctions.GcMeta, 0);
				Lua.lua_rawset(L, -3);
			}
			Lua.xlua_pushasciistring(L, "__tostring");
			Lua.lua_pushstdcallcfunction(L, translator.metaFunctions.ToStringMeta, 0);
			Lua.lua_rawset(L, -3);
			if (method_count == 0)
			{
				Lua.lua_pushnil(L);
			}
			else
			{
				Lua.lua_createtable(L, 0, method_count);
			}
			if (getter_count == 0)
			{
				Lua.lua_pushnil(L);
			}
			else
			{
				Lua.lua_createtable(L, 0, getter_count);
			}
			if (setter_count == 0)
			{
				Lua.lua_pushnil(L);
				return;
			}
			Lua.lua_createtable(L, 0, setter_count);
		}

		private static int abs_idx(int top, int idx)
		{
			if (idx <= 0)
			{
				return top + idx + 1;
			}
			return idx;
		}

		public static void EndObjectRegister(Type type, IntPtr L, ObjectTranslator translator, lua_CSFunction csIndexer, lua_CSFunction csNewIndexer, Type base_type, lua_CSFunction arrayIndexer, lua_CSFunction arrayNewIndexer)
		{
			int top = Lua.lua_gettop(L);
			int index = Utils.abs_idx(top, -4);
			int index2 = Utils.abs_idx(top, -3);
			int index3 = Utils.abs_idx(top, -2);
			int index4 = Utils.abs_idx(top, -1);
			Lua.xlua_pushasciistring(L, "__index");
			Lua.lua_pushvalue(L, index2);
			Lua.lua_pushvalue(L, index3);
			if (csIndexer == null)
			{
				Lua.lua_pushnil(L);
			}
			else
			{
				Lua.lua_pushstdcallcfunction(L, csIndexer, 0);
			}
			translator.Push(L, (type == null) ? base_type : type.BaseType());
			Lua.xlua_pushasciistring(L, "LuaIndexs");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			if (arrayIndexer == null)
			{
				Lua.lua_pushnil(L);
			}
			else
			{
				Lua.lua_pushstdcallcfunction(L, arrayIndexer, 0);
			}
			Lua.gen_obj_indexer(L);
			if (type != null)
			{
				Lua.xlua_pushasciistring(L, "LuaIndexs");
				Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
				translator.Push(L, type);
				Lua.lua_pushvalue(L, -3);
				Lua.lua_rawset(L, -3);
				Lua.lua_pop(L, 1);
			}
			Lua.lua_rawset(L, index);
			Lua.xlua_pushasciistring(L, "__newindex");
			Lua.lua_pushvalue(L, index4);
			if (csNewIndexer == null)
			{
				Lua.lua_pushnil(L);
			}
			else
			{
				Lua.lua_pushstdcallcfunction(L, csNewIndexer, 0);
			}
			translator.Push(L, (type == null) ? base_type : type.BaseType());
			Lua.xlua_pushasciistring(L, "LuaNewIndexs");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			if (arrayNewIndexer == null)
			{
				Lua.lua_pushnil(L);
			}
			else
			{
				Lua.lua_pushstdcallcfunction(L, arrayNewIndexer, 0);
			}
			Lua.gen_obj_newindexer(L);
			if (type != null)
			{
				Lua.xlua_pushasciistring(L, "LuaNewIndexs");
				Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
				translator.Push(L, type);
				Lua.lua_pushvalue(L, -3);
				Lua.lua_rawset(L, -3);
				Lua.lua_pop(L, 1);
			}
			Lua.lua_rawset(L, index);
			Lua.lua_pop(L, 4);
		}

		public static void RegisterFunc(IntPtr L, int idx, string name, lua_CSFunction func)
		{
			idx = Utils.abs_idx(Lua.lua_gettop(L), idx);
			Lua.xlua_pushasciistring(L, name);
			Lua.lua_pushstdcallcfunction(L, func, 0);
			Lua.lua_rawset(L, idx);
		}

		public static void RegisterLazyFunc(IntPtr L, int idx, string name, Type type, LazyMemberTypes memberType, bool isStatic)
		{
			idx = Utils.abs_idx(Lua.lua_gettop(L), idx);
			Lua.xlua_pushasciistring(L, name);
			ObjectTranslatorPool.Instance.Find(L).PushAny(L, type);
			Lua.xlua_pushinteger(L, (int)memberType);
			Lua.lua_pushstring(L, name);
			Lua.lua_pushboolean(L, isStatic);
			Lua.lua_pushstdcallcfunction(L, InternalGlobals.LazyReflectionWrap, 4);
			Lua.lua_rawset(L, idx);
		}

		public static void RegisterObject(IntPtr L, ObjectTranslator translator, int idx, string name, object obj)
		{
			idx = Utils.abs_idx(Lua.lua_gettop(L), idx);
			Lua.xlua_pushasciistring(L, name);
			translator.PushAny(L, obj);
			Lua.lua_rawset(L, idx);
		}

		public static void BeginClassRegister(Type type, IntPtr L, lua_CSFunction creator, int class_field_count, int static_getter_count, int static_setter_count)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			Lua.lua_createtable(L, 0, class_field_count);
			Lua.xlua_pushasciistring(L, "UnderlyingSystemType");
			objectTranslator.PushAny(L, type);
			Lua.lua_rawset(L, -3);
			int num = Lua.lua_gettop(L);
			Utils.SetCSTable(L, type, num);
			Lua.lua_createtable(L, 0, 3);
			int index = Lua.lua_gettop(L);
			if (creator != null)
			{
				Lua.xlua_pushasciistring(L, "__call");
				Lua.lua_pushstdcallcfunction(L, creator, 0);
				Lua.lua_rawset(L, -3);
			}
			if (static_getter_count == 0)
			{
				Lua.lua_pushnil(L);
			}
			else
			{
				Lua.lua_createtable(L, 0, static_getter_count);
			}
			if (static_setter_count == 0)
			{
				Lua.lua_pushnil(L);
			}
			else
			{
				Lua.lua_createtable(L, 0, static_setter_count);
			}
			Lua.lua_pushvalue(L, index);
			Lua.lua_setmetatable(L, num);
		}

		public static void EndClassRegister(Type type, IntPtr L, ObjectTranslator translator)
		{
			int top = Lua.lua_gettop(L);
			int index = Utils.abs_idx(top, -4);
			int index2 = Utils.abs_idx(top, -2);
			int index3 = Utils.abs_idx(top, -1);
			int index4 = Utils.abs_idx(top, -3);
			Lua.xlua_pushasciistring(L, "__index");
			Lua.lua_pushvalue(L, index2);
			Lua.lua_pushvalue(L, index);
			translator.Push(L, type.BaseType());
			Lua.xlua_pushasciistring(L, "LuaClassIndexs");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			Lua.gen_cls_indexer(L);
			Lua.xlua_pushasciistring(L, "LuaClassIndexs");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			translator.Push(L, type);
			Lua.lua_pushvalue(L, -3);
			Lua.lua_rawset(L, -3);
			Lua.lua_pop(L, 1);
			Lua.lua_rawset(L, index4);
			Lua.xlua_pushasciistring(L, "__newindex");
			Lua.lua_pushvalue(L, index3);
			translator.Push(L, type.BaseType());
			Lua.xlua_pushasciistring(L, "LuaClassNewIndexs");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			Lua.gen_cls_newindexer(L);
			Lua.xlua_pushasciistring(L, "LuaClassNewIndexs");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			translator.Push(L, type);
			Lua.lua_pushvalue(L, -3);
			Lua.lua_rawset(L, -3);
			Lua.lua_pop(L, 1);
			Lua.lua_rawset(L, index4);
			Lua.lua_pop(L, 4);
		}

		private static List<string> getPathOfType(Type type)
		{
			List<string> list = new List<string>();
			if (type.Namespace != null)
			{
				list.AddRange(type.Namespace.Split(new char[]
				{
					'.'
				}));
			}
			string text = type.ToString().Substring((type.Namespace == null) ? 0 : (type.Namespace.Length + 1));
			if (type.IsNested)
			{
				list.AddRange(text.Split(new char[]
				{
					'+'
				}));
			}
			else
			{
				list.Add(text);
			}
			return list;
		}

		public static void LoadCSTable(IntPtr L, Type type)
		{
			int newTop = Lua.lua_gettop(L);
			Lua.xlua_pushasciistring(L, "xlua_csharp_namespace");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			List<string> pathOfType = Utils.getPathOfType(type);
			for (int i = 0; i < pathOfType.Count; i++)
			{
				Lua.xlua_pushasciistring(L, pathOfType[i]);
				if (Lua.xlua_pgettable(L, -2) != 0)
				{
					Lua.lua_settop(L, newTop);
					Lua.lua_pushnil(L);
					return;
				}
				if (!Lua.lua_istable(L, -1) && i < pathOfType.Count - 1)
				{
					Lua.lua_settop(L, newTop);
					Lua.lua_pushnil(L);
					return;
				}
				Lua.lua_remove(L, -2);
			}
		}

		public static void SetCSTable(IntPtr L, Type type, int cls_table)
		{
			int num = Lua.lua_gettop(L);
			cls_table = Utils.abs_idx(num, cls_table);
			Lua.xlua_pushasciistring(L, "xlua_csharp_namespace");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			List<string> pathOfType = Utils.getPathOfType(type);
			for (int i = 0; i < pathOfType.Count - 1; i++)
			{
				Lua.xlua_pushasciistring(L, pathOfType[i]);
				if (Lua.xlua_pgettable(L, -2) != 0)
				{
					string str = Lua.lua_tostring(L, -1);
					Lua.lua_settop(L, num);
					throw new Exception("SetCSTable for [" + ((type != null) ? type.ToString() : null) + "] error: " + str);
				}
				if (Lua.lua_isnil(L, -1))
				{
					Lua.lua_pop(L, 1);
					Lua.lua_createtable(L, 0, 0);
					Lua.xlua_pushasciistring(L, pathOfType[i]);
					Lua.lua_pushvalue(L, -2);
					Lua.lua_rawset(L, -4);
				}
				else if (!Lua.lua_istable(L, -1))
				{
					Lua.lua_settop(L, num);
					throw new Exception("SetCSTable for [" + ((type != null) ? type.ToString() : null) + "] error: ancestors is not a table!");
				}
				Lua.lua_remove(L, -2);
			}
			Lua.xlua_pushasciistring(L, pathOfType[pathOfType.Count - 1]);
			Lua.lua_pushvalue(L, cls_table);
			Lua.lua_rawset(L, -3);
			Lua.lua_pop(L, 1);
			Lua.xlua_pushasciistring(L, "xlua_csharp_namespace");
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			ObjectTranslatorPool.Instance.Find(L).PushAny(L, type);
			Lua.lua_pushvalue(L, cls_table);
			Lua.lua_rawset(L, -3);
			Lua.lua_pop(L, 1);
		}

		public static bool IsParamsMatch(MethodInfo delegateMethod, MethodInfo bridgeMethod)
		{
			if (delegateMethod == null || bridgeMethod == null)
			{
				return false;
			}
			if (delegateMethod.ReturnType != bridgeMethod.ReturnType)
			{
				return false;
			}
			ParameterInfo[] parameters = delegateMethod.GetParameters();
			ParameterInfo[] parameters2 = bridgeMethod.GetParameters();
			if (parameters.Length != parameters2.Length)
			{
				return false;
			}
			for (int i = 0; i < parameters.Length; i++)
			{
				if (parameters[i].ParameterType != parameters2[i].ParameterType || parameters[i].IsOut != parameters2[i].IsOut)
				{
					return false;
				}
			}
			int num = parameters.Length - 1;
			return num < 0 || parameters[num].IsDefined(typeof(ParamArrayAttribute), false) == parameters2[num].IsDefined(typeof(ParamArrayAttribute), false);
		}

		public static bool IsSupportedMethod(MethodInfo method)
		{
			if (!method.ContainsGenericParameters)
			{
				return true;
			}
			ParameterInfo[] parameters = method.GetParameters();
			Type returnType = method.ReturnType;
			bool flag = false;
			bool flag2 = !returnType.IsGenericParameter;
			for (int i = 0; i < parameters.Length; i++)
			{
				Type parameterType = parameters[i].ParameterType;
				if (parameterType.IsGenericParameter)
				{
					Type[] genericParameterConstraints = parameterType.GetGenericParameterConstraints();
					if (genericParameterConstraints.Length == 0)
					{
						return false;
					}
					foreach (Type type in genericParameterConstraints)
					{
						if (!type.IsClass() || type == typeof(ValueType))
						{
							return false;
						}
					}
					flag = true;
					if (!flag2 && parameterType == returnType)
					{
						flag2 = true;
					}
				}
			}
			return flag && flag2;
		}

		public static MethodInfo MakeGenericMethodWithConstraints(MethodInfo method)
		{
			MethodInfo result;
			try
			{
				Type[] genericArguments = method.GetGenericArguments();
				Type[] array = new Type[genericArguments.Length];
				for (int i = 0; i < genericArguments.Length; i++)
				{
					Type[] genericParameterConstraints = genericArguments[i].GetGenericParameterConstraints();
					array[i] = genericParameterConstraints[0];
				}
				result = method.MakeGenericMethod(array);
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		private static Type getExtendedType(MethodInfo method)
		{
			Type parameterType = method.GetParameters()[0].ParameterType;
			if (!parameterType.IsGenericParameter)
			{
				return parameterType;
			}
			Type[] genericParameterConstraints = parameterType.GetGenericParameterConstraints();
			if (genericParameterConstraints.Length == 0)
			{
				throw new InvalidOperationException();
			}
			Type type = genericParameterConstraints[0];
			if (!type.IsClass())
			{
				throw new InvalidOperationException();
			}
			return type;
		}

		public static bool IsStaticPInvokeCSFunction(lua_CSFunction csFunction)
		{
			return csFunction.Method.IsStatic && Attribute.IsDefined(csFunction.Method, typeof(MonoPInvokeCallbackAttribute));
		}

		public static bool IsPublic(Type type)
		{
			if (type.IsNested)
			{
				return type.IsNestedPublic() && Utils.IsPublic(type.DeclaringType);
			}
			if (type.IsGenericType())
			{
				Type[] genericArguments = type.GetGenericArguments();
				for (int i = 0; i < genericArguments.Length; i++)
				{
					if (!Utils.IsPublic(genericArguments[i]))
					{
						return false;
					}
				}
			}
			return type.IsPublic();
		}

		public const int OBJ_META_IDX = -4;

		public const int METHOD_IDX = -3;

		public const int GETTER_IDX = -2;

		public const int SETTER_IDX = -1;

		public const int CLS_IDX = -4;

		public const int CLS_META_IDX = -3;

		public const int CLS_GETTER_IDX = -2;

		public const int CLS_SETTER_IDX = -1;

		public const string LuaIndexsFieldName = "LuaIndexs";

		public const string LuaNewIndexsFieldName = "LuaNewIndexs";

		public const string LuaClassIndexsFieldName = "LuaClassIndexs";

		public const string LuaClassNewIndexsFieldName = "LuaClassNewIndexs";

		private struct MethodKey
		{
			public string Name;

			public bool IsStatic;
		}
	}
}
