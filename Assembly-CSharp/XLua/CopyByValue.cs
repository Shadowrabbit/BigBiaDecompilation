using System;
using UnityEngine;
using XLua.LuaDLL;
using XLuaTest;

namespace XLua
{
	public static class CopyByValue
	{
		public static void UnPack(ObjectTranslator translator, IntPtr L, int idx, out Vector2 val)
		{
			val = default(Vector2);
			int num = Lua.lua_gettop(L);
			if (Utils.LoadField(L, idx, "x"))
			{
				translator.Get<float>(L, num + 1, out val.x);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "y"))
			{
				translator.Get<float>(L, num + 1, out val.y);
			}
			Lua.lua_pop(L, 1);
		}

		public static bool Pack(IntPtr buff, int offset, Vector2 field)
		{
			return Lua.xlua_pack_float2(buff, offset, field.x, field.y);
		}

		public static bool UnPack(IntPtr buff, int offset, out Vector2 field)
		{
			field = default(Vector2);
			float x = 0f;
			float y = 0f;
			if (!Lua.xlua_unpack_float2(buff, offset, out x, out y))
			{
				return false;
			}
			field.x = x;
			field.y = y;
			return true;
		}

		public static void UnPack(ObjectTranslator translator, IntPtr L, int idx, out Vector3 val)
		{
			val = default(Vector3);
			int num = Lua.lua_gettop(L);
			if (Utils.LoadField(L, idx, "x"))
			{
				translator.Get<float>(L, num + 1, out val.x);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "y"))
			{
				translator.Get<float>(L, num + 1, out val.y);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "z"))
			{
				translator.Get<float>(L, num + 1, out val.z);
			}
			Lua.lua_pop(L, 1);
		}

		public static bool Pack(IntPtr buff, int offset, Vector3 field)
		{
			return Lua.xlua_pack_float3(buff, offset, field.x, field.y, field.z);
		}

		public static bool UnPack(IntPtr buff, int offset, out Vector3 field)
		{
			field = default(Vector3);
			float x = 0f;
			float y = 0f;
			float z = 0f;
			if (!Lua.xlua_unpack_float3(buff, offset, out x, out y, out z))
			{
				return false;
			}
			field.x = x;
			field.y = y;
			field.z = z;
			return true;
		}

		public static void UnPack(ObjectTranslator translator, IntPtr L, int idx, out Vector4 val)
		{
			val = default(Vector4);
			int num = Lua.lua_gettop(L);
			if (Utils.LoadField(L, idx, "x"))
			{
				translator.Get<float>(L, num + 1, out val.x);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "y"))
			{
				translator.Get<float>(L, num + 1, out val.y);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "z"))
			{
				translator.Get<float>(L, num + 1, out val.z);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "w"))
			{
				translator.Get<float>(L, num + 1, out val.w);
			}
			Lua.lua_pop(L, 1);
		}

		public static bool Pack(IntPtr buff, int offset, Vector4 field)
		{
			return Lua.xlua_pack_float4(buff, offset, field.x, field.y, field.z, field.w);
		}

		public static bool UnPack(IntPtr buff, int offset, out Vector4 field)
		{
			field = default(Vector4);
			float x = 0f;
			float y = 0f;
			float z = 0f;
			float w = 0f;
			if (!Lua.xlua_unpack_float4(buff, offset, out x, out y, out z, out w))
			{
				return false;
			}
			field.x = x;
			field.y = y;
			field.z = z;
			field.w = w;
			return true;
		}

		public static void UnPack(ObjectTranslator translator, IntPtr L, int idx, out Color val)
		{
			val = default(Color);
			int num = Lua.lua_gettop(L);
			if (Utils.LoadField(L, idx, "r"))
			{
				translator.Get<float>(L, num + 1, out val.r);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "g"))
			{
				translator.Get<float>(L, num + 1, out val.g);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "b"))
			{
				translator.Get<float>(L, num + 1, out val.b);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "a"))
			{
				translator.Get<float>(L, num + 1, out val.a);
			}
			Lua.lua_pop(L, 1);
		}

		public static bool Pack(IntPtr buff, int offset, Color field)
		{
			return Lua.xlua_pack_float4(buff, offset, field.r, field.g, field.b, field.a);
		}

		public static bool UnPack(IntPtr buff, int offset, out Color field)
		{
			field = default(Color);
			float r = 0f;
			float g = 0f;
			float b = 0f;
			float a = 0f;
			if (!Lua.xlua_unpack_float4(buff, offset, out r, out g, out b, out a))
			{
				return false;
			}
			field.r = r;
			field.g = g;
			field.b = b;
			field.a = a;
			return true;
		}

		public static void UnPack(ObjectTranslator translator, IntPtr L, int idx, out Quaternion val)
		{
			val = default(Quaternion);
			int num = Lua.lua_gettop(L);
			if (Utils.LoadField(L, idx, "x"))
			{
				translator.Get<float>(L, num + 1, out val.x);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "y"))
			{
				translator.Get<float>(L, num + 1, out val.y);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "z"))
			{
				translator.Get<float>(L, num + 1, out val.z);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "w"))
			{
				translator.Get<float>(L, num + 1, out val.w);
			}
			Lua.lua_pop(L, 1);
		}

		public static bool Pack(IntPtr buff, int offset, Quaternion field)
		{
			return Lua.xlua_pack_float4(buff, offset, field.x, field.y, field.z, field.w);
		}

		public static bool UnPack(IntPtr buff, int offset, out Quaternion field)
		{
			field = default(Quaternion);
			float x = 0f;
			float y = 0f;
			float z = 0f;
			float w = 0f;
			if (!Lua.xlua_unpack_float4(buff, offset, out x, out y, out z, out w))
			{
				return false;
			}
			field.x = x;
			field.y = y;
			field.z = z;
			field.w = w;
			return true;
		}

		public static void UnPack(ObjectTranslator translator, IntPtr L, int idx, out Ray val)
		{
			val = default(Ray);
			int num = Lua.lua_gettop(L);
			if (Utils.LoadField(L, idx, "origin"))
			{
				Vector3 origin = val.origin;
				translator.Get(L, num + 1, out origin);
				val.origin = origin;
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "direction"))
			{
				Vector3 direction = val.direction;
				translator.Get(L, num + 1, out direction);
				val.direction = direction;
			}
			Lua.lua_pop(L, 1);
		}

		public static bool Pack(IntPtr buff, int offset, Ray field)
		{
			return CopyByValue.Pack(buff, offset, field.origin) && CopyByValue.Pack(buff, offset + 12, field.direction);
		}

		public static bool UnPack(IntPtr buff, int offset, out Ray field)
		{
			field = default(Ray);
			Vector3 origin = field.origin;
			if (!CopyByValue.UnPack(buff, offset, out origin))
			{
				return false;
			}
			field.origin = origin;
			Vector3 direction = field.direction;
			if (!CopyByValue.UnPack(buff, offset + 12, out direction))
			{
				return false;
			}
			field.direction = direction;
			return true;
		}

		public static void UnPack(ObjectTranslator translator, IntPtr L, int idx, out Bounds val)
		{
			val = default(Bounds);
			int num = Lua.lua_gettop(L);
			if (Utils.LoadField(L, idx, "center"))
			{
				Vector3 center = val.center;
				translator.Get(L, num + 1, out center);
				val.center = center;
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "extents"))
			{
				Vector3 extents = val.extents;
				translator.Get(L, num + 1, out extents);
				val.extents = extents;
			}
			Lua.lua_pop(L, 1);
		}

		public static bool Pack(IntPtr buff, int offset, Bounds field)
		{
			return CopyByValue.Pack(buff, offset, field.center) && CopyByValue.Pack(buff, offset + 12, field.extents);
		}

		public static bool UnPack(IntPtr buff, int offset, out Bounds field)
		{
			field = default(Bounds);
			Vector3 center = field.center;
			if (!CopyByValue.UnPack(buff, offset, out center))
			{
				return false;
			}
			field.center = center;
			Vector3 extents = field.extents;
			if (!CopyByValue.UnPack(buff, offset + 12, out extents))
			{
				return false;
			}
			field.extents = extents;
			return true;
		}

		public static void UnPack(ObjectTranslator translator, IntPtr L, int idx, out Ray2D val)
		{
			val = default(Ray2D);
			int num = Lua.lua_gettop(L);
			if (Utils.LoadField(L, idx, "origin"))
			{
				Vector2 origin = val.origin;
				translator.Get(L, num + 1, out origin);
				val.origin = origin;
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "direction"))
			{
				Vector2 direction = val.direction;
				translator.Get(L, num + 1, out direction);
				val.direction = direction;
			}
			Lua.lua_pop(L, 1);
		}

		public static bool Pack(IntPtr buff, int offset, Ray2D field)
		{
			return CopyByValue.Pack(buff, offset, field.origin) && CopyByValue.Pack(buff, offset + 8, field.direction);
		}

		public static bool UnPack(IntPtr buff, int offset, out Ray2D field)
		{
			field = default(Ray2D);
			Vector2 origin = field.origin;
			if (!CopyByValue.UnPack(buff, offset, out origin))
			{
				return false;
			}
			field.origin = origin;
			Vector2 direction = field.direction;
			if (!CopyByValue.UnPack(buff, offset + 8, out direction))
			{
				return false;
			}
			field.direction = direction;
			return true;
		}

		public static void UnPack(ObjectTranslator translator, IntPtr L, int idx, out Pedding val)
		{
			val = default(Pedding);
			int num = Lua.lua_gettop(L);
			if (Utils.LoadField(L, idx, "c"))
			{
				translator.Get<byte>(L, num + 1, out val.c);
			}
			Lua.lua_pop(L, 1);
		}

		public static bool Pack(IntPtr buff, int offset, Pedding field)
		{
			return CopyByValue.Pack(buff, offset, field.c);
		}

		public static bool UnPack(IntPtr buff, int offset, out Pedding field)
		{
			field = default(Pedding);
			return CopyByValue.UnPack(buff, offset, out field.c);
		}

		public static void UnPack(ObjectTranslator translator, IntPtr L, int idx, out MyStruct val)
		{
			val = default(MyStruct);
			int num = Lua.lua_gettop(L);
			if (Utils.LoadField(L, idx, "a"))
			{
				translator.Get<int>(L, num + 1, out val.a);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "b"))
			{
				translator.Get<int>(L, num + 1, out val.b);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "c"))
			{
				translator.Get(L, num + 1, out val.c);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "e"))
			{
				translator.Get(L, num + 1, out val.e);
			}
			Lua.lua_pop(L, 1);
		}

		public static bool Pack(IntPtr buff, int offset, MyStruct field)
		{
			return CopyByValue.Pack(buff, offset, field.a) && CopyByValue.Pack(buff, offset + 4, field.b) && CopyByValue.Pack(buff, offset + 8, field.c) && CopyByValue.Pack(buff, offset + 24, field.e);
		}

		public static bool UnPack(IntPtr buff, int offset, out MyStruct field)
		{
			field = default(MyStruct);
			return CopyByValue.UnPack(buff, offset, out field.a) && CopyByValue.UnPack(buff, offset + 4, out field.b) && CopyByValue.UnPack(buff, offset + 8, out field.c) && CopyByValue.UnPack(buff, offset + 24, out field.e);
		}

		public static void UnPack(ObjectTranslator translator, IntPtr L, int idx, out PushAsTableStruct val)
		{
			val = default(PushAsTableStruct);
			int num = Lua.lua_gettop(L);
			if (Utils.LoadField(L, idx, "x"))
			{
				translator.Get<int>(L, num + 1, out val.x);
			}
			Lua.lua_pop(L, 1);
			if (Utils.LoadField(L, idx, "y"))
			{
				translator.Get<int>(L, num + 1, out val.y);
			}
			Lua.lua_pop(L, 1);
		}

		public static bool Pack(IntPtr buff, int offset, PushAsTableStruct field)
		{
			return CopyByValue.Pack(buff, offset, field.x) && CopyByValue.Pack(buff, offset + 4, field.y);
		}

		public static bool UnPack(IntPtr buff, int offset, out PushAsTableStruct field)
		{
			field = default(PushAsTableStruct);
			return CopyByValue.UnPack(buff, offset, out field.x) && CopyByValue.UnPack(buff, offset + 4, out field.y);
		}

		public static bool Pack(IntPtr buff, int offset, byte field)
		{
			return Lua.xlua_pack_int8_t(buff, offset, field);
		}

		public static bool UnPack(IntPtr buff, int offset, out byte field)
		{
			return Lua.xlua_unpack_int8_t(buff, offset, out field);
		}

		public static bool Pack(IntPtr buff, int offset, sbyte field)
		{
			return Lua.xlua_pack_int8_t(buff, offset, (byte)field);
		}

		public static bool UnPack(IntPtr buff, int offset, out sbyte field)
		{
			byte b;
			bool result = Lua.xlua_unpack_int8_t(buff, offset, out b);
			field = (sbyte)b;
			return result;
		}

		public static bool Pack(IntPtr buff, int offset, short field)
		{
			return Lua.xlua_pack_int16_t(buff, offset, field);
		}

		public static bool UnPack(IntPtr buff, int offset, out short field)
		{
			return Lua.xlua_unpack_int16_t(buff, offset, out field);
		}

		public static bool Pack(IntPtr buff, int offset, ushort field)
		{
			return Lua.xlua_pack_int16_t(buff, offset, (short)field);
		}

		public static bool UnPack(IntPtr buff, int offset, out ushort field)
		{
			short num;
			bool result = Lua.xlua_unpack_int16_t(buff, offset, out num);
			field = (ushort)num;
			return result;
		}

		public static bool Pack(IntPtr buff, int offset, int field)
		{
			return Lua.xlua_pack_int32_t(buff, offset, field);
		}

		public static bool UnPack(IntPtr buff, int offset, out int field)
		{
			return Lua.xlua_unpack_int32_t(buff, offset, out field);
		}

		public static bool Pack(IntPtr buff, int offset, uint field)
		{
			return Lua.xlua_pack_int32_t(buff, offset, (int)field);
		}

		public static bool UnPack(IntPtr buff, int offset, out uint field)
		{
			int num;
			bool result = Lua.xlua_unpack_int32_t(buff, offset, out num);
			field = (uint)num;
			return result;
		}

		public static bool Pack(IntPtr buff, int offset, long field)
		{
			return Lua.xlua_pack_int64_t(buff, offset, field);
		}

		public static bool UnPack(IntPtr buff, int offset, out long field)
		{
			return Lua.xlua_unpack_int64_t(buff, offset, out field);
		}

		public static bool Pack(IntPtr buff, int offset, ulong field)
		{
			return Lua.xlua_pack_int64_t(buff, offset, (long)field);
		}

		public static bool UnPack(IntPtr buff, int offset, out ulong field)
		{
			long num;
			bool result = Lua.xlua_unpack_int64_t(buff, offset, out num);
			field = (ulong)num;
			return result;
		}

		public static bool Pack(IntPtr buff, int offset, float field)
		{
			return Lua.xlua_pack_float(buff, offset, field);
		}

		public static bool UnPack(IntPtr buff, int offset, out float field)
		{
			return Lua.xlua_unpack_float(buff, offset, out field);
		}

		public static bool Pack(IntPtr buff, int offset, double field)
		{
			return Lua.xlua_pack_double(buff, offset, field);
		}

		public static bool UnPack(IntPtr buff, int offset, out double field)
		{
			return Lua.xlua_unpack_double(buff, offset, out field);
		}

		public static bool Pack(IntPtr buff, int offset, decimal field)
		{
			return Lua.xlua_pack_decimal(buff, offset, ref field);
		}

		public static bool UnPack(IntPtr buff, int offset, out decimal field)
		{
			byte scale;
			byte b;
			int hi;
			ulong num;
			if (!Lua.xlua_unpack_decimal(buff, offset, out scale, out b, out hi, out num))
			{
				field = 0m;
				return false;
			}
			field = new decimal((int)(num & (ulong)-1), (int)(num >> 32), hi, (b & 128) > 0, scale);
			return true;
		}

		public static bool IsStruct(Type type)
		{
			return type.IsValueType() && !type.IsEnum() && !type.IsPrimitive();
		}
	}
}
