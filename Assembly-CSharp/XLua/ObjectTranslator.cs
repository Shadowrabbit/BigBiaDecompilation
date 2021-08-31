using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DG.Tweening;
using Tutorial;
using UnityEngine;
using XLua.CSObjectWrap;
using XLua.LuaDLL;
using XLuaTest;

namespace XLua
{
	public class ObjectTranslator
	{
		private static ObjectTranslator.IniterAdderUnityEngineVector2 IniterAdderUnityEngineVector2_dumb_obj
		{
			get
			{
				return ObjectTranslator.s_IniterAdderUnityEngineVector2_dumb_obj;
			}
		}

		public void PushUnityEngineVector2(IntPtr L, Vector2 val)
		{
			if (this.UnityEngineVector2_TypeID == -1)
			{
				bool flag;
				this.UnityEngineVector2_TypeID = this.getTypeId(L, typeof(Vector2), out flag, ObjectTranslator.LOGLEVEL.WARN);
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 8U, this.UnityEngineVector2_TypeID), 0, val))
			{
				string str = "pack fail fail for UnityEngine.Vector2 ,value=";
				Vector2 vector = val;
				throw new Exception(str + vector.ToString());
			}
		}

		public void Get(IntPtr L, int index, out Vector2 val)
		{
			LuaTypes luaTypes = Lua.lua_type(L, index);
			if (luaTypes == LuaTypes.LUA_TUSERDATA)
			{
				if (Lua.xlua_gettypeid(L, index) != this.UnityEngineVector2_TypeID)
				{
					throw new Exception("invalid userdata for UnityEngine.Vector2");
				}
				if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out val))
				{
					throw new Exception("unpack fail for UnityEngine.Vector2");
				}
			}
			else
			{
				if (luaTypes == LuaTypes.LUA_TTABLE)
				{
					CopyByValue.UnPack(this, L, index, out val);
					return;
				}
				val = (Vector2)this.objectCasters.GetCaster(typeof(Vector2))(L, index, null);
			}
		}

		public void UpdateUnityEngineVector2(IntPtr L, int index, Vector2 val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.UnityEngineVector2_TypeID)
			{
				throw new Exception("invalid userdata for UnityEngine.Vector2");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, val))
			{
				string str = "pack fail for UnityEngine.Vector2 ,value=";
				Vector2 vector = val;
				throw new Exception(str + vector.ToString());
			}
		}

		public void PushUnityEngineVector3(IntPtr L, Vector3 val)
		{
			if (this.UnityEngineVector3_TypeID == -1)
			{
				bool flag;
				this.UnityEngineVector3_TypeID = this.getTypeId(L, typeof(Vector3), out flag, ObjectTranslator.LOGLEVEL.WARN);
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 12U, this.UnityEngineVector3_TypeID), 0, val))
			{
				string str = "pack fail fail for UnityEngine.Vector3 ,value=";
				Vector3 vector = val;
				throw new Exception(str + vector.ToString());
			}
		}

		public void Get(IntPtr L, int index, out Vector3 val)
		{
			LuaTypes luaTypes = Lua.lua_type(L, index);
			if (luaTypes == LuaTypes.LUA_TUSERDATA)
			{
				if (Lua.xlua_gettypeid(L, index) != this.UnityEngineVector3_TypeID)
				{
					throw new Exception("invalid userdata for UnityEngine.Vector3");
				}
				if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out val))
				{
					throw new Exception("unpack fail for UnityEngine.Vector3");
				}
			}
			else
			{
				if (luaTypes == LuaTypes.LUA_TTABLE)
				{
					CopyByValue.UnPack(this, L, index, out val);
					return;
				}
				val = (Vector3)this.objectCasters.GetCaster(typeof(Vector3))(L, index, null);
			}
		}

		public void UpdateUnityEngineVector3(IntPtr L, int index, Vector3 val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.UnityEngineVector3_TypeID)
			{
				throw new Exception("invalid userdata for UnityEngine.Vector3");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, val))
			{
				string str = "pack fail for UnityEngine.Vector3 ,value=";
				Vector3 vector = val;
				throw new Exception(str + vector.ToString());
			}
		}

		public void PushUnityEngineVector4(IntPtr L, Vector4 val)
		{
			if (this.UnityEngineVector4_TypeID == -1)
			{
				bool flag;
				this.UnityEngineVector4_TypeID = this.getTypeId(L, typeof(Vector4), out flag, ObjectTranslator.LOGLEVEL.WARN);
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 16U, this.UnityEngineVector4_TypeID), 0, val))
			{
				string str = "pack fail fail for UnityEngine.Vector4 ,value=";
				Vector4 vector = val;
				throw new Exception(str + vector.ToString());
			}
		}

		public void Get(IntPtr L, int index, out Vector4 val)
		{
			LuaTypes luaTypes = Lua.lua_type(L, index);
			if (luaTypes == LuaTypes.LUA_TUSERDATA)
			{
				if (Lua.xlua_gettypeid(L, index) != this.UnityEngineVector4_TypeID)
				{
					throw new Exception("invalid userdata for UnityEngine.Vector4");
				}
				if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out val))
				{
					throw new Exception("unpack fail for UnityEngine.Vector4");
				}
			}
			else
			{
				if (luaTypes == LuaTypes.LUA_TTABLE)
				{
					CopyByValue.UnPack(this, L, index, out val);
					return;
				}
				val = (Vector4)this.objectCasters.GetCaster(typeof(Vector4))(L, index, null);
			}
		}

		public void UpdateUnityEngineVector4(IntPtr L, int index, Vector4 val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.UnityEngineVector4_TypeID)
			{
				throw new Exception("invalid userdata for UnityEngine.Vector4");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, val))
			{
				string str = "pack fail for UnityEngine.Vector4 ,value=";
				Vector4 vector = val;
				throw new Exception(str + vector.ToString());
			}
		}

		public void PushUnityEngineColor(IntPtr L, Color val)
		{
			if (this.UnityEngineColor_TypeID == -1)
			{
				bool flag;
				this.UnityEngineColor_TypeID = this.getTypeId(L, typeof(Color), out flag, ObjectTranslator.LOGLEVEL.WARN);
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 16U, this.UnityEngineColor_TypeID), 0, val))
			{
				string str = "pack fail fail for UnityEngine.Color ,value=";
				Color color = val;
				throw new Exception(str + color.ToString());
			}
		}

		public void Get(IntPtr L, int index, out Color val)
		{
			LuaTypes luaTypes = Lua.lua_type(L, index);
			if (luaTypes == LuaTypes.LUA_TUSERDATA)
			{
				if (Lua.xlua_gettypeid(L, index) != this.UnityEngineColor_TypeID)
				{
					throw new Exception("invalid userdata for UnityEngine.Color");
				}
				if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out val))
				{
					throw new Exception("unpack fail for UnityEngine.Color");
				}
			}
			else
			{
				if (luaTypes == LuaTypes.LUA_TTABLE)
				{
					CopyByValue.UnPack(this, L, index, out val);
					return;
				}
				val = (Color)this.objectCasters.GetCaster(typeof(Color))(L, index, null);
			}
		}

		public void UpdateUnityEngineColor(IntPtr L, int index, Color val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.UnityEngineColor_TypeID)
			{
				throw new Exception("invalid userdata for UnityEngine.Color");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, val))
			{
				string str = "pack fail for UnityEngine.Color ,value=";
				Color color = val;
				throw new Exception(str + color.ToString());
			}
		}

		public void PushUnityEngineQuaternion(IntPtr L, Quaternion val)
		{
			if (this.UnityEngineQuaternion_TypeID == -1)
			{
				bool flag;
				this.UnityEngineQuaternion_TypeID = this.getTypeId(L, typeof(Quaternion), out flag, ObjectTranslator.LOGLEVEL.WARN);
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 16U, this.UnityEngineQuaternion_TypeID), 0, val))
			{
				string str = "pack fail fail for UnityEngine.Quaternion ,value=";
				Quaternion quaternion = val;
				throw new Exception(str + quaternion.ToString());
			}
		}

		public void Get(IntPtr L, int index, out Quaternion val)
		{
			LuaTypes luaTypes = Lua.lua_type(L, index);
			if (luaTypes == LuaTypes.LUA_TUSERDATA)
			{
				if (Lua.xlua_gettypeid(L, index) != this.UnityEngineQuaternion_TypeID)
				{
					throw new Exception("invalid userdata for UnityEngine.Quaternion");
				}
				if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out val))
				{
					throw new Exception("unpack fail for UnityEngine.Quaternion");
				}
			}
			else
			{
				if (luaTypes == LuaTypes.LUA_TTABLE)
				{
					CopyByValue.UnPack(this, L, index, out val);
					return;
				}
				val = (Quaternion)this.objectCasters.GetCaster(typeof(Quaternion))(L, index, null);
			}
		}

		public void UpdateUnityEngineQuaternion(IntPtr L, int index, Quaternion val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.UnityEngineQuaternion_TypeID)
			{
				throw new Exception("invalid userdata for UnityEngine.Quaternion");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, val))
			{
				string str = "pack fail for UnityEngine.Quaternion ,value=";
				Quaternion quaternion = val;
				throw new Exception(str + quaternion.ToString());
			}
		}

		public void PushUnityEngineRay(IntPtr L, Ray val)
		{
			if (this.UnityEngineRay_TypeID == -1)
			{
				bool flag;
				this.UnityEngineRay_TypeID = this.getTypeId(L, typeof(Ray), out flag, ObjectTranslator.LOGLEVEL.WARN);
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 24U, this.UnityEngineRay_TypeID), 0, val))
			{
				string str = "pack fail fail for UnityEngine.Ray ,value=";
				Ray ray = val;
				throw new Exception(str + ray.ToString());
			}
		}

		public void Get(IntPtr L, int index, out Ray val)
		{
			LuaTypes luaTypes = Lua.lua_type(L, index);
			if (luaTypes == LuaTypes.LUA_TUSERDATA)
			{
				if (Lua.xlua_gettypeid(L, index) != this.UnityEngineRay_TypeID)
				{
					throw new Exception("invalid userdata for UnityEngine.Ray");
				}
				if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out val))
				{
					throw new Exception("unpack fail for UnityEngine.Ray");
				}
			}
			else
			{
				if (luaTypes == LuaTypes.LUA_TTABLE)
				{
					CopyByValue.UnPack(this, L, index, out val);
					return;
				}
				val = (Ray)this.objectCasters.GetCaster(typeof(Ray))(L, index, null);
			}
		}

		public void UpdateUnityEngineRay(IntPtr L, int index, Ray val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.UnityEngineRay_TypeID)
			{
				throw new Exception("invalid userdata for UnityEngine.Ray");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, val))
			{
				string str = "pack fail for UnityEngine.Ray ,value=";
				Ray ray = val;
				throw new Exception(str + ray.ToString());
			}
		}

		public void PushUnityEngineBounds(IntPtr L, Bounds val)
		{
			if (this.UnityEngineBounds_TypeID == -1)
			{
				bool flag;
				this.UnityEngineBounds_TypeID = this.getTypeId(L, typeof(Bounds), out flag, ObjectTranslator.LOGLEVEL.WARN);
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 24U, this.UnityEngineBounds_TypeID), 0, val))
			{
				string str = "pack fail fail for UnityEngine.Bounds ,value=";
				Bounds bounds = val;
				throw new Exception(str + bounds.ToString());
			}
		}

		public void Get(IntPtr L, int index, out Bounds val)
		{
			LuaTypes luaTypes = Lua.lua_type(L, index);
			if (luaTypes == LuaTypes.LUA_TUSERDATA)
			{
				if (Lua.xlua_gettypeid(L, index) != this.UnityEngineBounds_TypeID)
				{
					throw new Exception("invalid userdata for UnityEngine.Bounds");
				}
				if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out val))
				{
					throw new Exception("unpack fail for UnityEngine.Bounds");
				}
			}
			else
			{
				if (luaTypes == LuaTypes.LUA_TTABLE)
				{
					CopyByValue.UnPack(this, L, index, out val);
					return;
				}
				val = (Bounds)this.objectCasters.GetCaster(typeof(Bounds))(L, index, null);
			}
		}

		public void UpdateUnityEngineBounds(IntPtr L, int index, Bounds val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.UnityEngineBounds_TypeID)
			{
				throw new Exception("invalid userdata for UnityEngine.Bounds");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, val))
			{
				string str = "pack fail for UnityEngine.Bounds ,value=";
				Bounds bounds = val;
				throw new Exception(str + bounds.ToString());
			}
		}

		public void PushUnityEngineRay2D(IntPtr L, Ray2D val)
		{
			if (this.UnityEngineRay2D_TypeID == -1)
			{
				bool flag;
				this.UnityEngineRay2D_TypeID = this.getTypeId(L, typeof(Ray2D), out flag, ObjectTranslator.LOGLEVEL.WARN);
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 16U, this.UnityEngineRay2D_TypeID), 0, val))
			{
				string str = "pack fail fail for UnityEngine.Ray2D ,value=";
				Ray2D ray2D = val;
				throw new Exception(str + ray2D.ToString());
			}
		}

		public void Get(IntPtr L, int index, out Ray2D val)
		{
			LuaTypes luaTypes = Lua.lua_type(L, index);
			if (luaTypes == LuaTypes.LUA_TUSERDATA)
			{
				if (Lua.xlua_gettypeid(L, index) != this.UnityEngineRay2D_TypeID)
				{
					throw new Exception("invalid userdata for UnityEngine.Ray2D");
				}
				if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out val))
				{
					throw new Exception("unpack fail for UnityEngine.Ray2D");
				}
			}
			else
			{
				if (luaTypes == LuaTypes.LUA_TTABLE)
				{
					CopyByValue.UnPack(this, L, index, out val);
					return;
				}
				val = (Ray2D)this.objectCasters.GetCaster(typeof(Ray2D))(L, index, null);
			}
		}

		public void UpdateUnityEngineRay2D(IntPtr L, int index, Ray2D val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.UnityEngineRay2D_TypeID)
			{
				throw new Exception("invalid userdata for UnityEngine.Ray2D");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, val))
			{
				string str = "pack fail for UnityEngine.Ray2D ,value=";
				Ray2D ray2D = val;
				throw new Exception(str + ray2D.ToString());
			}
		}

		public void PushXLuaTestPedding(IntPtr L, Pedding val)
		{
			if (this.XLuaTestPedding_TypeID == -1)
			{
				bool flag;
				this.XLuaTestPedding_TypeID = this.getTypeId(L, typeof(Pedding), out flag, ObjectTranslator.LOGLEVEL.WARN);
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 1U, this.XLuaTestPedding_TypeID), 0, val))
			{
				throw new Exception("pack fail fail for XLuaTest.Pedding ,value=" + val.ToString());
			}
		}

		public void Get(IntPtr L, int index, out Pedding val)
		{
			LuaTypes luaTypes = Lua.lua_type(L, index);
			if (luaTypes == LuaTypes.LUA_TUSERDATA)
			{
				if (Lua.xlua_gettypeid(L, index) != this.XLuaTestPedding_TypeID)
				{
					throw new Exception("invalid userdata for XLuaTest.Pedding");
				}
				if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out val))
				{
					throw new Exception("unpack fail for XLuaTest.Pedding");
				}
			}
			else
			{
				if (luaTypes == LuaTypes.LUA_TTABLE)
				{
					CopyByValue.UnPack(this, L, index, out val);
					return;
				}
				val = (Pedding)this.objectCasters.GetCaster(typeof(Pedding))(L, index, null);
			}
		}

		public void UpdateXLuaTestPedding(IntPtr L, int index, Pedding val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.XLuaTestPedding_TypeID)
			{
				throw new Exception("invalid userdata for XLuaTest.Pedding");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, val))
			{
				throw new Exception("pack fail for XLuaTest.Pedding ,value=" + val.ToString());
			}
		}

		public void PushXLuaTestMyStruct(IntPtr L, MyStruct val)
		{
			if (this.XLuaTestMyStruct_TypeID == -1)
			{
				bool flag;
				this.XLuaTestMyStruct_TypeID = this.getTypeId(L, typeof(MyStruct), out flag, ObjectTranslator.LOGLEVEL.WARN);
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 25U, this.XLuaTestMyStruct_TypeID), 0, val))
			{
				throw new Exception("pack fail fail for XLuaTest.MyStruct ,value=" + val.ToString());
			}
		}

		public void Get(IntPtr L, int index, out MyStruct val)
		{
			LuaTypes luaTypes = Lua.lua_type(L, index);
			if (luaTypes == LuaTypes.LUA_TUSERDATA)
			{
				if (Lua.xlua_gettypeid(L, index) != this.XLuaTestMyStruct_TypeID)
				{
					throw new Exception("invalid userdata for XLuaTest.MyStruct");
				}
				if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out val))
				{
					throw new Exception("unpack fail for XLuaTest.MyStruct");
				}
			}
			else
			{
				if (luaTypes == LuaTypes.LUA_TTABLE)
				{
					CopyByValue.UnPack(this, L, index, out val);
					return;
				}
				val = (MyStruct)this.objectCasters.GetCaster(typeof(MyStruct))(L, index, null);
			}
		}

		public void UpdateXLuaTestMyStruct(IntPtr L, int index, MyStruct val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.XLuaTestMyStruct_TypeID)
			{
				throw new Exception("invalid userdata for XLuaTest.MyStruct");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, val))
			{
				throw new Exception("pack fail for XLuaTest.MyStruct ,value=" + val.ToString());
			}
		}

		public void PushXLuaTestPushAsTableStruct(IntPtr L, PushAsTableStruct val)
		{
			if (this.XLuaTestPushAsTableStruct_TypeID == -1)
			{
				bool flag;
				this.XLuaTestPushAsTableStruct_TypeID = this.getTypeId(L, typeof(PushAsTableStruct), out flag, ObjectTranslator.LOGLEVEL.WARN);
			}
			Lua.xlua_pushcstable(L, 2U, this.XLuaTestPushAsTableStruct_TypeID);
			Lua.xlua_pushasciistring(L, "x");
			Lua.xlua_pushinteger(L, val.x);
			Lua.lua_rawset(L, -3);
			Lua.xlua_pushasciistring(L, "y");
			Lua.xlua_pushinteger(L, val.y);
			Lua.lua_rawset(L, -3);
		}

		public void Get(IntPtr L, int index, out PushAsTableStruct val)
		{
			LuaTypes luaTypes = Lua.lua_type(L, index);
			if (luaTypes == LuaTypes.LUA_TUSERDATA)
			{
				if (Lua.xlua_gettypeid(L, index) != this.XLuaTestPushAsTableStruct_TypeID)
				{
					throw new Exception("invalid userdata for XLuaTest.PushAsTableStruct");
				}
				if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out val))
				{
					throw new Exception("unpack fail for XLuaTest.PushAsTableStruct");
				}
			}
			else
			{
				if (luaTypes == LuaTypes.LUA_TTABLE)
				{
					CopyByValue.UnPack(this, L, index, out val);
					return;
				}
				val = (PushAsTableStruct)this.objectCasters.GetCaster(typeof(PushAsTableStruct))(L, index, null);
			}
		}

		public void UpdateXLuaTestPushAsTableStruct(IntPtr L, int index, PushAsTableStruct val)
		{
			if (Lua.lua_type(L, index) == LuaTypes.LUA_TTABLE)
			{
				return;
			}
			throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
		}

		public void PushDGTweeningAutoPlay(IntPtr L, AutoPlay val)
		{
			if (this.DGTweeningAutoPlay_TypeID == -1)
			{
				bool flag;
				this.DGTweeningAutoPlay_TypeID = this.getTypeId(L, typeof(AutoPlay), out flag, ObjectTranslator.LOGLEVEL.WARN);
				if (this.DGTweeningAutoPlay_EnumRef == -1)
				{
					Utils.LoadCSTable(L, typeof(AutoPlay));
					this.DGTweeningAutoPlay_EnumRef = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
			}
			if (Lua.xlua_tryget_cachedud(L, (int)val, this.DGTweeningAutoPlay_EnumRef) == 1)
			{
				return;
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 4U, this.DGTweeningAutoPlay_TypeID), 0, (int)val))
			{
				throw new Exception("pack fail fail for DG.Tweening.AutoPlay ,value=" + val.ToString());
			}
			Lua.lua_getref(L, this.DGTweeningAutoPlay_EnumRef);
			Lua.lua_pushvalue(L, -2);
			Lua.xlua_rawseti(L, -2, (long)val);
			Lua.lua_pop(L, 1);
		}

		public void Get(IntPtr L, int index, out AutoPlay val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				val = (AutoPlay)this.objectCasters.GetCaster(typeof(AutoPlay))(L, index, null);
				return;
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningAutoPlay_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.AutoPlay");
			}
			int num;
			if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out num))
			{
				throw new Exception("unpack fail for DG.Tweening.AutoPlay");
			}
			val = (AutoPlay)num;
		}

		public void UpdateDGTweeningAutoPlay(IntPtr L, int index, AutoPlay val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningAutoPlay_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.AutoPlay");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, (int)val))
			{
				throw new Exception("pack fail for DG.Tweening.AutoPlay ,value=" + val.ToString());
			}
		}

		public void PushDGTweeningAxisConstraint(IntPtr L, AxisConstraint val)
		{
			if (this.DGTweeningAxisConstraint_TypeID == -1)
			{
				bool flag;
				this.DGTweeningAxisConstraint_TypeID = this.getTypeId(L, typeof(AxisConstraint), out flag, ObjectTranslator.LOGLEVEL.WARN);
				if (this.DGTweeningAxisConstraint_EnumRef == -1)
				{
					Utils.LoadCSTable(L, typeof(AxisConstraint));
					this.DGTweeningAxisConstraint_EnumRef = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
			}
			if (Lua.xlua_tryget_cachedud(L, (int)val, this.DGTweeningAxisConstraint_EnumRef) == 1)
			{
				return;
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 4U, this.DGTweeningAxisConstraint_TypeID), 0, (int)val))
			{
				throw new Exception("pack fail fail for DG.Tweening.AxisConstraint ,value=" + val.ToString());
			}
			Lua.lua_getref(L, this.DGTweeningAxisConstraint_EnumRef);
			Lua.lua_pushvalue(L, -2);
			Lua.xlua_rawseti(L, -2, (long)val);
			Lua.lua_pop(L, 1);
		}

		public void Get(IntPtr L, int index, out AxisConstraint val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				val = (AxisConstraint)this.objectCasters.GetCaster(typeof(AxisConstraint))(L, index, null);
				return;
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningAxisConstraint_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.AxisConstraint");
			}
			int num;
			if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out num))
			{
				throw new Exception("unpack fail for DG.Tweening.AxisConstraint");
			}
			val = (AxisConstraint)num;
		}

		public void UpdateDGTweeningAxisConstraint(IntPtr L, int index, AxisConstraint val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningAxisConstraint_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.AxisConstraint");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, (int)val))
			{
				throw new Exception("pack fail for DG.Tweening.AxisConstraint ,value=" + val.ToString());
			}
		}

		public void PushDGTweeningEase(IntPtr L, Ease val)
		{
			if (this.DGTweeningEase_TypeID == -1)
			{
				bool flag;
				this.DGTweeningEase_TypeID = this.getTypeId(L, typeof(Ease), out flag, ObjectTranslator.LOGLEVEL.WARN);
				if (this.DGTweeningEase_EnumRef == -1)
				{
					Utils.LoadCSTable(L, typeof(Ease));
					this.DGTweeningEase_EnumRef = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
			}
			if (Lua.xlua_tryget_cachedud(L, (int)val, this.DGTweeningEase_EnumRef) == 1)
			{
				return;
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 4U, this.DGTweeningEase_TypeID), 0, (int)val))
			{
				throw new Exception("pack fail fail for DG.Tweening.Ease ,value=" + val.ToString());
			}
			Lua.lua_getref(L, this.DGTweeningEase_EnumRef);
			Lua.lua_pushvalue(L, -2);
			Lua.xlua_rawseti(L, -2, (long)val);
			Lua.lua_pop(L, 1);
		}

		public void Get(IntPtr L, int index, out Ease val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				val = (Ease)this.objectCasters.GetCaster(typeof(Ease))(L, index, null);
				return;
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningEase_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.Ease");
			}
			int num;
			if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out num))
			{
				throw new Exception("unpack fail for DG.Tweening.Ease");
			}
			val = (Ease)num;
		}

		public void UpdateDGTweeningEase(IntPtr L, int index, Ease val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningEase_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.Ease");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, (int)val))
			{
				throw new Exception("pack fail for DG.Tweening.Ease ,value=" + val.ToString());
			}
		}

		public void PushDGTweeningLogBehaviour(IntPtr L, LogBehaviour val)
		{
			if (this.DGTweeningLogBehaviour_TypeID == -1)
			{
				bool flag;
				this.DGTweeningLogBehaviour_TypeID = this.getTypeId(L, typeof(LogBehaviour), out flag, ObjectTranslator.LOGLEVEL.WARN);
				if (this.DGTweeningLogBehaviour_EnumRef == -1)
				{
					Utils.LoadCSTable(L, typeof(LogBehaviour));
					this.DGTweeningLogBehaviour_EnumRef = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
			}
			if (Lua.xlua_tryget_cachedud(L, (int)val, this.DGTweeningLogBehaviour_EnumRef) == 1)
			{
				return;
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 4U, this.DGTweeningLogBehaviour_TypeID), 0, (int)val))
			{
				throw new Exception("pack fail fail for DG.Tweening.LogBehaviour ,value=" + val.ToString());
			}
			Lua.lua_getref(L, this.DGTweeningLogBehaviour_EnumRef);
			Lua.lua_pushvalue(L, -2);
			Lua.xlua_rawseti(L, -2, (long)val);
			Lua.lua_pop(L, 1);
		}

		public void Get(IntPtr L, int index, out LogBehaviour val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				val = (LogBehaviour)this.objectCasters.GetCaster(typeof(LogBehaviour))(L, index, null);
				return;
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningLogBehaviour_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.LogBehaviour");
			}
			int num;
			if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out num))
			{
				throw new Exception("unpack fail for DG.Tweening.LogBehaviour");
			}
			val = (LogBehaviour)num;
		}

		public void UpdateDGTweeningLogBehaviour(IntPtr L, int index, LogBehaviour val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningLogBehaviour_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.LogBehaviour");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, (int)val))
			{
				throw new Exception("pack fail for DG.Tweening.LogBehaviour ,value=" + val.ToString());
			}
		}

		public void PushDGTweeningLoopType(IntPtr L, LoopType val)
		{
			if (this.DGTweeningLoopType_TypeID == -1)
			{
				bool flag;
				this.DGTweeningLoopType_TypeID = this.getTypeId(L, typeof(LoopType), out flag, ObjectTranslator.LOGLEVEL.WARN);
				if (this.DGTweeningLoopType_EnumRef == -1)
				{
					Utils.LoadCSTable(L, typeof(LoopType));
					this.DGTweeningLoopType_EnumRef = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
			}
			if (Lua.xlua_tryget_cachedud(L, (int)val, this.DGTweeningLoopType_EnumRef) == 1)
			{
				return;
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 4U, this.DGTweeningLoopType_TypeID), 0, (int)val))
			{
				throw new Exception("pack fail fail for DG.Tweening.LoopType ,value=" + val.ToString());
			}
			Lua.lua_getref(L, this.DGTweeningLoopType_EnumRef);
			Lua.lua_pushvalue(L, -2);
			Lua.xlua_rawseti(L, -2, (long)val);
			Lua.lua_pop(L, 1);
		}

		public void Get(IntPtr L, int index, out LoopType val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				val = (LoopType)this.objectCasters.GetCaster(typeof(LoopType))(L, index, null);
				return;
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningLoopType_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.LoopType");
			}
			int num;
			if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out num))
			{
				throw new Exception("unpack fail for DG.Tweening.LoopType");
			}
			val = (LoopType)num;
		}

		public void UpdateDGTweeningLoopType(IntPtr L, int index, LoopType val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningLoopType_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.LoopType");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, (int)val))
			{
				throw new Exception("pack fail for DG.Tweening.LoopType ,value=" + val.ToString());
			}
		}

		public void PushDGTweeningPathMode(IntPtr L, PathMode val)
		{
			if (this.DGTweeningPathMode_TypeID == -1)
			{
				bool flag;
				this.DGTweeningPathMode_TypeID = this.getTypeId(L, typeof(PathMode), out flag, ObjectTranslator.LOGLEVEL.WARN);
				if (this.DGTweeningPathMode_EnumRef == -1)
				{
					Utils.LoadCSTable(L, typeof(PathMode));
					this.DGTweeningPathMode_EnumRef = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
			}
			if (Lua.xlua_tryget_cachedud(L, (int)val, this.DGTweeningPathMode_EnumRef) == 1)
			{
				return;
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 4U, this.DGTweeningPathMode_TypeID), 0, (int)val))
			{
				throw new Exception("pack fail fail for DG.Tweening.PathMode ,value=" + val.ToString());
			}
			Lua.lua_getref(L, this.DGTweeningPathMode_EnumRef);
			Lua.lua_pushvalue(L, -2);
			Lua.xlua_rawseti(L, -2, (long)val);
			Lua.lua_pop(L, 1);
		}

		public void Get(IntPtr L, int index, out PathMode val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				val = (PathMode)this.objectCasters.GetCaster(typeof(PathMode))(L, index, null);
				return;
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningPathMode_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.PathMode");
			}
			int num;
			if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out num))
			{
				throw new Exception("unpack fail for DG.Tweening.PathMode");
			}
			val = (PathMode)num;
		}

		public void UpdateDGTweeningPathMode(IntPtr L, int index, PathMode val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningPathMode_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.PathMode");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, (int)val))
			{
				throw new Exception("pack fail for DG.Tweening.PathMode ,value=" + val.ToString());
			}
		}

		public void PushDGTweeningPathType(IntPtr L, PathType val)
		{
			if (this.DGTweeningPathType_TypeID == -1)
			{
				bool flag;
				this.DGTweeningPathType_TypeID = this.getTypeId(L, typeof(PathType), out flag, ObjectTranslator.LOGLEVEL.WARN);
				if (this.DGTweeningPathType_EnumRef == -1)
				{
					Utils.LoadCSTable(L, typeof(PathType));
					this.DGTweeningPathType_EnumRef = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
			}
			if (Lua.xlua_tryget_cachedud(L, (int)val, this.DGTweeningPathType_EnumRef) == 1)
			{
				return;
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 4U, this.DGTweeningPathType_TypeID), 0, (int)val))
			{
				throw new Exception("pack fail fail for DG.Tweening.PathType ,value=" + val.ToString());
			}
			Lua.lua_getref(L, this.DGTweeningPathType_EnumRef);
			Lua.lua_pushvalue(L, -2);
			Lua.xlua_rawseti(L, -2, (long)val);
			Lua.lua_pop(L, 1);
		}

		public void Get(IntPtr L, int index, out PathType val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				val = (PathType)this.objectCasters.GetCaster(typeof(PathType))(L, index, null);
				return;
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningPathType_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.PathType");
			}
			int num;
			if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out num))
			{
				throw new Exception("unpack fail for DG.Tweening.PathType");
			}
			val = (PathType)num;
		}

		public void UpdateDGTweeningPathType(IntPtr L, int index, PathType val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningPathType_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.PathType");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, (int)val))
			{
				throw new Exception("pack fail for DG.Tweening.PathType ,value=" + val.ToString());
			}
		}

		public void PushDGTweeningRotateMode(IntPtr L, RotateMode val)
		{
			if (this.DGTweeningRotateMode_TypeID == -1)
			{
				bool flag;
				this.DGTweeningRotateMode_TypeID = this.getTypeId(L, typeof(RotateMode), out flag, ObjectTranslator.LOGLEVEL.WARN);
				if (this.DGTweeningRotateMode_EnumRef == -1)
				{
					Utils.LoadCSTable(L, typeof(RotateMode));
					this.DGTweeningRotateMode_EnumRef = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
			}
			if (Lua.xlua_tryget_cachedud(L, (int)val, this.DGTweeningRotateMode_EnumRef) == 1)
			{
				return;
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 4U, this.DGTweeningRotateMode_TypeID), 0, (int)val))
			{
				throw new Exception("pack fail fail for DG.Tweening.RotateMode ,value=" + val.ToString());
			}
			Lua.lua_getref(L, this.DGTweeningRotateMode_EnumRef);
			Lua.lua_pushvalue(L, -2);
			Lua.xlua_rawseti(L, -2, (long)val);
			Lua.lua_pop(L, 1);
		}

		public void Get(IntPtr L, int index, out RotateMode val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				val = (RotateMode)this.objectCasters.GetCaster(typeof(RotateMode))(L, index, null);
				return;
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningRotateMode_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.RotateMode");
			}
			int num;
			if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out num))
			{
				throw new Exception("unpack fail for DG.Tweening.RotateMode");
			}
			val = (RotateMode)num;
		}

		public void UpdateDGTweeningRotateMode(IntPtr L, int index, RotateMode val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningRotateMode_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.RotateMode");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, (int)val))
			{
				throw new Exception("pack fail for DG.Tweening.RotateMode ,value=" + val.ToString());
			}
		}

		public void PushDGTweeningScrambleMode(IntPtr L, ScrambleMode val)
		{
			if (this.DGTweeningScrambleMode_TypeID == -1)
			{
				bool flag;
				this.DGTweeningScrambleMode_TypeID = this.getTypeId(L, typeof(ScrambleMode), out flag, ObjectTranslator.LOGLEVEL.WARN);
				if (this.DGTweeningScrambleMode_EnumRef == -1)
				{
					Utils.LoadCSTable(L, typeof(ScrambleMode));
					this.DGTweeningScrambleMode_EnumRef = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
			}
			if (Lua.xlua_tryget_cachedud(L, (int)val, this.DGTweeningScrambleMode_EnumRef) == 1)
			{
				return;
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 4U, this.DGTweeningScrambleMode_TypeID), 0, (int)val))
			{
				throw new Exception("pack fail fail for DG.Tweening.ScrambleMode ,value=" + val.ToString());
			}
			Lua.lua_getref(L, this.DGTweeningScrambleMode_EnumRef);
			Lua.lua_pushvalue(L, -2);
			Lua.xlua_rawseti(L, -2, (long)val);
			Lua.lua_pop(L, 1);
		}

		public void Get(IntPtr L, int index, out ScrambleMode val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				val = (ScrambleMode)this.objectCasters.GetCaster(typeof(ScrambleMode))(L, index, null);
				return;
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningScrambleMode_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.ScrambleMode");
			}
			int num;
			if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out num))
			{
				throw new Exception("unpack fail for DG.Tweening.ScrambleMode");
			}
			val = (ScrambleMode)num;
		}

		public void UpdateDGTweeningScrambleMode(IntPtr L, int index, ScrambleMode val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningScrambleMode_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.ScrambleMode");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, (int)val))
			{
				throw new Exception("pack fail for DG.Tweening.ScrambleMode ,value=" + val.ToString());
			}
		}

		public void PushDGTweeningTweenType(IntPtr L, TweenType val)
		{
			if (this.DGTweeningTweenType_TypeID == -1)
			{
				bool flag;
				this.DGTweeningTweenType_TypeID = this.getTypeId(L, typeof(TweenType), out flag, ObjectTranslator.LOGLEVEL.WARN);
				if (this.DGTweeningTweenType_EnumRef == -1)
				{
					Utils.LoadCSTable(L, typeof(TweenType));
					this.DGTweeningTweenType_EnumRef = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
			}
			if (Lua.xlua_tryget_cachedud(L, (int)val, this.DGTweeningTweenType_EnumRef) == 1)
			{
				return;
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 4U, this.DGTweeningTweenType_TypeID), 0, (int)val))
			{
				throw new Exception("pack fail fail for DG.Tweening.TweenType ,value=" + val.ToString());
			}
			Lua.lua_getref(L, this.DGTweeningTweenType_EnumRef);
			Lua.lua_pushvalue(L, -2);
			Lua.xlua_rawseti(L, -2, (long)val);
			Lua.lua_pop(L, 1);
		}

		public void Get(IntPtr L, int index, out TweenType val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				val = (TweenType)this.objectCasters.GetCaster(typeof(TweenType))(L, index, null);
				return;
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningTweenType_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.TweenType");
			}
			int num;
			if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out num))
			{
				throw new Exception("unpack fail for DG.Tweening.TweenType");
			}
			val = (TweenType)num;
		}

		public void UpdateDGTweeningTweenType(IntPtr L, int index, TweenType val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningTweenType_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.TweenType");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, (int)val))
			{
				throw new Exception("pack fail for DG.Tweening.TweenType ,value=" + val.ToString());
			}
		}

		public void PushDGTweeningUpdateType(IntPtr L, UpdateType val)
		{
			if (this.DGTweeningUpdateType_TypeID == -1)
			{
				bool flag;
				this.DGTweeningUpdateType_TypeID = this.getTypeId(L, typeof(UpdateType), out flag, ObjectTranslator.LOGLEVEL.WARN);
				if (this.DGTweeningUpdateType_EnumRef == -1)
				{
					Utils.LoadCSTable(L, typeof(UpdateType));
					this.DGTweeningUpdateType_EnumRef = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
			}
			if (Lua.xlua_tryget_cachedud(L, (int)val, this.DGTweeningUpdateType_EnumRef) == 1)
			{
				return;
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 4U, this.DGTweeningUpdateType_TypeID), 0, (int)val))
			{
				throw new Exception("pack fail fail for DG.Tweening.UpdateType ,value=" + val.ToString());
			}
			Lua.lua_getref(L, this.DGTweeningUpdateType_EnumRef);
			Lua.lua_pushvalue(L, -2);
			Lua.xlua_rawseti(L, -2, (long)val);
			Lua.lua_pop(L, 1);
		}

		public void Get(IntPtr L, int index, out UpdateType val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				val = (UpdateType)this.objectCasters.GetCaster(typeof(UpdateType))(L, index, null);
				return;
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningUpdateType_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.UpdateType");
			}
			int num;
			if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out num))
			{
				throw new Exception("unpack fail for DG.Tweening.UpdateType");
			}
			val = (UpdateType)num;
		}

		public void UpdateDGTweeningUpdateType(IntPtr L, int index, UpdateType val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.DGTweeningUpdateType_TypeID)
			{
				throw new Exception("invalid userdata for DG.Tweening.UpdateType");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, (int)val))
			{
				throw new Exception("pack fail for DG.Tweening.UpdateType ,value=" + val.ToString());
			}
		}

		public void PushTutorialTestEnum(IntPtr L, TestEnum val)
		{
			if (this.TutorialTestEnum_TypeID == -1)
			{
				bool flag;
				this.TutorialTestEnum_TypeID = this.getTypeId(L, typeof(TestEnum), out flag, ObjectTranslator.LOGLEVEL.WARN);
				if (this.TutorialTestEnum_EnumRef == -1)
				{
					Utils.LoadCSTable(L, typeof(TestEnum));
					this.TutorialTestEnum_EnumRef = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
			}
			if (Lua.xlua_tryget_cachedud(L, (int)val, this.TutorialTestEnum_EnumRef) == 1)
			{
				return;
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 4U, this.TutorialTestEnum_TypeID), 0, (int)val))
			{
				throw new Exception("pack fail fail for Tutorial.TestEnum ,value=" + val.ToString());
			}
			Lua.lua_getref(L, this.TutorialTestEnum_EnumRef);
			Lua.lua_pushvalue(L, -2);
			Lua.xlua_rawseti(L, -2, (long)val);
			Lua.lua_pop(L, 1);
		}

		public void Get(IntPtr L, int index, out TestEnum val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				val = (TestEnum)this.objectCasters.GetCaster(typeof(TestEnum))(L, index, null);
				return;
			}
			if (Lua.xlua_gettypeid(L, index) != this.TutorialTestEnum_TypeID)
			{
				throw new Exception("invalid userdata for Tutorial.TestEnum");
			}
			int num;
			if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out num))
			{
				throw new Exception("unpack fail for Tutorial.TestEnum");
			}
			val = (TestEnum)num;
		}

		public void UpdateTutorialTestEnum(IntPtr L, int index, TestEnum val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.TutorialTestEnum_TypeID)
			{
				throw new Exception("invalid userdata for Tutorial.TestEnum");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, (int)val))
			{
				throw new Exception("pack fail for Tutorial.TestEnum ,value=" + val.ToString());
			}
		}

		public void PushXLuaTestMyEnum(IntPtr L, MyEnum val)
		{
			if (this.XLuaTestMyEnum_TypeID == -1)
			{
				bool flag;
				this.XLuaTestMyEnum_TypeID = this.getTypeId(L, typeof(MyEnum), out flag, ObjectTranslator.LOGLEVEL.WARN);
				if (this.XLuaTestMyEnum_EnumRef == -1)
				{
					Utils.LoadCSTable(L, typeof(MyEnum));
					this.XLuaTestMyEnum_EnumRef = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
			}
			if (Lua.xlua_tryget_cachedud(L, (int)val, this.XLuaTestMyEnum_EnumRef) == 1)
			{
				return;
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 4U, this.XLuaTestMyEnum_TypeID), 0, (int)val))
			{
				throw new Exception("pack fail fail for XLuaTest.MyEnum ,value=" + val.ToString());
			}
			Lua.lua_getref(L, this.XLuaTestMyEnum_EnumRef);
			Lua.lua_pushvalue(L, -2);
			Lua.xlua_rawseti(L, -2, (long)val);
			Lua.lua_pop(L, 1);
		}

		public void Get(IntPtr L, int index, out MyEnum val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				val = (MyEnum)this.objectCasters.GetCaster(typeof(MyEnum))(L, index, null);
				return;
			}
			if (Lua.xlua_gettypeid(L, index) != this.XLuaTestMyEnum_TypeID)
			{
				throw new Exception("invalid userdata for XLuaTest.MyEnum");
			}
			int num;
			if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out num))
			{
				throw new Exception("unpack fail for XLuaTest.MyEnum");
			}
			val = (MyEnum)num;
		}

		public void UpdateXLuaTestMyEnum(IntPtr L, int index, MyEnum val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.XLuaTestMyEnum_TypeID)
			{
				throw new Exception("invalid userdata for XLuaTest.MyEnum");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, (int)val))
			{
				throw new Exception("pack fail for XLuaTest.MyEnum ,value=" + val.ToString());
			}
		}

		public void PushTutorialDerivedClassTestEnumInner(IntPtr L, DerivedClass.TestEnumInner val)
		{
			if (this.TutorialDerivedClassTestEnumInner_TypeID == -1)
			{
				bool flag;
				this.TutorialDerivedClassTestEnumInner_TypeID = this.getTypeId(L, typeof(DerivedClass.TestEnumInner), out flag, ObjectTranslator.LOGLEVEL.WARN);
				if (this.TutorialDerivedClassTestEnumInner_EnumRef == -1)
				{
					Utils.LoadCSTable(L, typeof(DerivedClass.TestEnumInner));
					this.TutorialDerivedClassTestEnumInner_EnumRef = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
			}
			if (Lua.xlua_tryget_cachedud(L, (int)val, this.TutorialDerivedClassTestEnumInner_EnumRef) == 1)
			{
				return;
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 4U, this.TutorialDerivedClassTestEnumInner_TypeID), 0, (int)val))
			{
				throw new Exception("pack fail fail for Tutorial.DerivedClass.TestEnumInner ,value=" + val.ToString());
			}
			Lua.lua_getref(L, this.TutorialDerivedClassTestEnumInner_EnumRef);
			Lua.lua_pushvalue(L, -2);
			Lua.xlua_rawseti(L, -2, (long)val);
			Lua.lua_pop(L, 1);
		}

		public void Get(IntPtr L, int index, out DerivedClass.TestEnumInner val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				val = (DerivedClass.TestEnumInner)this.objectCasters.GetCaster(typeof(DerivedClass.TestEnumInner))(L, index, null);
				return;
			}
			if (Lua.xlua_gettypeid(L, index) != this.TutorialDerivedClassTestEnumInner_TypeID)
			{
				throw new Exception("invalid userdata for Tutorial.DerivedClass.TestEnumInner");
			}
			int num;
			if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out num))
			{
				throw new Exception("unpack fail for Tutorial.DerivedClass.TestEnumInner");
			}
			val = (DerivedClass.TestEnumInner)num;
		}

		public void UpdateTutorialDerivedClassTestEnumInner(IntPtr L, int index, DerivedClass.TestEnumInner val)
		{
			if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
			{
				throw new Exception("try to update a data with lua type:" + Lua.lua_type(L, index).ToString());
			}
			if (Lua.xlua_gettypeid(L, index) != this.TutorialDerivedClassTestEnumInner_TypeID)
			{
				throw new Exception("invalid userdata for Tutorial.DerivedClass.TestEnumInner");
			}
			if (!CopyByValue.Pack(Lua.lua_touserdata(L, index), 0, (int)val))
			{
				throw new Exception("pack fail for Tutorial.DerivedClass.TestEnumInner ,value=" + val.ToString());
			}
		}

		private static XLua_Gen_Initer_Register__ gen_reg_dumb_obj
		{
			get
			{
				return ObjectTranslator.s_gen_reg_dumb_obj;
			}
		}

		public void DelayWrapLoader(Type type, Action<IntPtr> loader)
		{
			this.delayWrap[type] = loader;
		}

		public void AddInterfaceBridgeCreator(Type type, Func<int, LuaEnv, LuaBase> creator)
		{
			this.interfaceBridgeCreators.Add(type, creator);
		}

		public bool TryDelayWrapLoader(IntPtr L, Type type)
		{
			if (this.loaded_types.ContainsKey(type))
			{
				return true;
			}
			this.loaded_types.Add(type, true);
			Lua.luaL_newmetatable(L, type.FullName);
			Lua.lua_pop(L, 1);
			int num = Lua.lua_gettop(L);
			Action<IntPtr> action;
			if (this.delayWrap.TryGetValue(type, out action))
			{
				this.delayWrap.Remove(type);
				action(L);
			}
			else
			{
				Utils.ReflectionWrap(L, type, this.privateAccessibleFlags.Contains(type));
			}
			if (num != Lua.lua_gettop(L))
			{
				throw new Exception("top change, before:" + num.ToString() + ", after:" + Lua.lua_gettop(L).ToString());
			}
			foreach (Type type2 in type.GetNestedTypes(BindingFlags.Public))
			{
				if (!type2.IsGenericTypeDefinition())
				{
					this.GetTypeId(L, type2);
				}
			}
			return true;
		}

		public void Alias(Type type, string alias)
		{
			Type type2 = this.FindType(alias, false);
			if (type2 == null)
			{
				throw new ArgumentException("Can not find " + alias);
			}
			this.aliasCfg[type2] = type;
		}

		private void addAssemblieByName(IEnumerable<Assembly> assemblies_usorted, string name)
		{
			foreach (Assembly assembly in assemblies_usorted)
			{
				if (assembly.FullName.StartsWith(name) && !this.assemblies.Contains(assembly))
				{
					this.assemblies.Add(assembly);
					break;
				}
			}
		}

		public ObjectTranslator(LuaEnv luaenv, IntPtr L)
		{
			this.assemblies = new List<Assembly>();
			this.assemblies.Add(Assembly.GetExecutingAssembly());
			Assembly[] array = AppDomain.CurrentDomain.GetAssemblies();
			this.addAssemblieByName(array, "mscorlib,");
			this.addAssemblieByName(array, "System,");
			this.addAssemblieByName(array, "System.Core,");
			foreach (Assembly item in array)
			{
				if (!this.assemblies.Contains(item))
				{
					this.assemblies.Add(item);
				}
			}
			this.luaEnv = luaenv;
			this.objectCasters = new ObjectCasters(this);
			this.objectCheckers = new ObjectCheckers(this);
			this.methodWrapsCache = new MethodWrapsCache(this, this.objectCheckers, this.objectCasters);
			this.metaFunctions = new StaticLuaCallbacks();
			this.importTypeFunction = new lua_CSFunction(StaticLuaCallbacks.ImportType);
			this.loadAssemblyFunction = new lua_CSFunction(StaticLuaCallbacks.LoadAssembly);
			this.castFunction = new lua_CSFunction(StaticLuaCallbacks.Cast);
			Lua.lua_newtable(L);
			Lua.lua_newtable(L);
			Lua.xlua_pushasciistring(L, "__mode");
			Lua.xlua_pushasciistring(L, "v");
			Lua.lua_rawset(L, -3);
			Lua.lua_setmetatable(L, -2);
			this.cacheRef = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
			this.initCSharpCallLua();
		}

		private void initCSharpCallLua()
		{
		}

		private Func<DelegateBridgeBase, Delegate> getCreatorUsingGeneric(DelegateBridgeBase bridge, Type delegateType, MethodInfo delegateMethod)
		{
			Func<DelegateBridgeBase, Delegate> func = null;
			if (this.genericAction == null)
			{
				MethodInfo[] methods = typeof(DelegateBridge).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
				this.genericAction = (from m in methods
				where m.Name == "Action"
				orderby m.GetParameters().Length
				select m).ToArray<MethodInfo>();
				this.genericFunc = (from m in methods
				where m.Name == "Func"
				orderby m.GetParameters().Length
				select m).ToArray<MethodInfo>();
			}
			if (this.genericAction.Length != 5 || this.genericFunc.Length != 5)
			{
				return null;
			}
			ParameterInfo[] parameters = delegateMethod.GetParameters();
			if ((delegateMethod.ReturnType.IsValueType() && delegateMethod.ReturnType != typeof(void)) || parameters.Length > 4)
			{
				func = ((DelegateBridgeBase x) => null);
			}
			else
			{
				foreach (ParameterInfo parameterInfo in parameters)
				{
					if (parameterInfo.ParameterType.IsValueType() || parameterInfo.IsOut || parameterInfo.ParameterType.IsByRef)
					{
						func = ((DelegateBridgeBase x) => null);
						break;
					}
				}
				if (func == null)
				{
					IEnumerable<Type> enumerable = from pinfo in parameters
					select pinfo.ParameterType;
					MethodInfo genericMethodInfo = null;
					if (delegateMethod.ReturnType == typeof(void))
					{
						genericMethodInfo = this.genericAction[parameters.Length];
					}
					else
					{
						genericMethodInfo = this.genericFunc[parameters.Length];
						enumerable = enumerable.Concat(new Type[]
						{
							delegateMethod.ReturnType
						});
					}
					if (genericMethodInfo.IsGenericMethodDefinition)
					{
						MethodInfo methodInfo = genericMethodInfo.MakeGenericMethod(enumerable.ToArray<Type>());
						func = ((DelegateBridgeBase o) => Delegate.CreateDelegate(delegateType, o, methodInfo));
					}
					else
					{
						func = ((DelegateBridgeBase o) => Delegate.CreateDelegate(delegateType, o, genericMethodInfo));
					}
				}
			}
			return func;
		}

		private Delegate getDelegate(DelegateBridgeBase bridge, Type delegateType)
		{
			Delegate @delegate = bridge.GetDelegateByType(delegateType);
			if (@delegate != null)
			{
				return @delegate;
			}
			if (delegateType == typeof(Delegate) || delegateType == typeof(MulticastDelegate))
			{
				return null;
			}
			Func<DelegateBridgeBase, Delegate> func;
			if (!this.delegateCreatorCache.TryGetValue(delegateType, out func))
			{
				MethodInfo method = delegateType.GetMethod("Invoke");
				MethodInfo[] array = (from m in bridge.GetType().GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
				where !m.IsGenericMethodDefinition && (m.Name.StartsWith("__Gen_Delegate_Imp") || m.Name == "Action")
				select m).ToArray<MethodInfo>();
				for (int i = 0; i < array.Length; i++)
				{
					if (!array[i].IsConstructor && Utils.IsParamsMatch(method, array[i]))
					{
						MethodInfo foundMethod = array[i];
						func = ((DelegateBridgeBase o) => Delegate.CreateDelegate(delegateType, o, foundMethod));
						break;
					}
				}
				if (func == null)
				{
					func = this.getCreatorUsingGeneric(bridge, delegateType, method);
				}
				this.delegateCreatorCache.Add(delegateType, func);
			}
			@delegate = func(bridge);
			if (@delegate != null)
			{
				return @delegate;
			}
			throw new InvalidCastException("This type must add to CSharpCallLua: " + delegateType.GetFriendlyName());
		}

		public object CreateDelegateBridge(IntPtr L, Type delegateType, int idx)
		{
			Lua.lua_pushvalue(L, idx);
			Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
			if (!Lua.lua_isnil(L, -1))
			{
				int key = Lua.xlua_tointeger(L, -1);
				Lua.lua_pop(L, 1);
				if (this.delegate_bridges[key].IsAlive)
				{
					if (delegateType == null)
					{
						return this.delegate_bridges[key].Target;
					}
					DelegateBridgeBase delegateBridgeBase = this.delegate_bridges[key].Target as DelegateBridgeBase;
					Delegate @delegate;
					if (delegateBridgeBase.TryGetDelegate(delegateType, out @delegate))
					{
						return @delegate;
					}
					@delegate = this.getDelegate(delegateBridgeBase, delegateType);
					delegateBridgeBase.AddDelegate(delegateType, @delegate);
					return @delegate;
				}
			}
			else
			{
				Lua.lua_pop(L, 1);
			}
			Lua.lua_pushvalue(L, idx);
			int num = Lua.luaL_ref(L);
			Lua.lua_pushvalue(L, idx);
			Lua.lua_pushnumber(L, (double)num);
			Lua.lua_rawset(L, LuaIndexes.LUA_REGISTRYINDEX);
			DelegateBridgeBase delegateBridgeBase2;
			try
			{
				delegateBridgeBase2 = new DelegateBridge(num, this.luaEnv);
			}
			catch (Exception ex)
			{
				Lua.lua_pushvalue(L, idx);
				Lua.lua_pushnil(L);
				Lua.lua_rawset(L, LuaIndexes.LUA_REGISTRYINDEX);
				Lua.lua_pushnil(L);
				Lua.xlua_rawseti(L, LuaIndexes.LUA_REGISTRYINDEX, (long)num);
				throw ex;
			}
			if (delegateType == null)
			{
				this.delegate_bridges[num] = new WeakReference(delegateBridgeBase2);
				return delegateBridgeBase2;
			}
			object result;
			try
			{
				Delegate delegate2 = this.getDelegate(delegateBridgeBase2, delegateType);
				delegateBridgeBase2.AddDelegate(delegateType, delegate2);
				this.delegate_bridges[num] = new WeakReference(delegateBridgeBase2);
				result = delegate2;
			}
			catch (Exception ex2)
			{
				delegateBridgeBase2.Dispose();
				throw ex2;
			}
			return result;
		}

		public bool AllDelegateBridgeReleased()
		{
			foreach (KeyValuePair<int, WeakReference> keyValuePair in this.delegate_bridges)
			{
				if (keyValuePair.Value.IsAlive)
				{
					return false;
				}
			}
			return true;
		}

		public void ReleaseLuaBase(IntPtr L, int reference, bool is_delegate)
		{
			if (is_delegate)
			{
				Lua.xlua_rawgeti(L, LuaIndexes.LUA_REGISTRYINDEX, (long)reference);
				if (Lua.lua_isnil(L, -1))
				{
					Lua.lua_pop(L, 1);
				}
				else
				{
					Lua.lua_pushvalue(L, -1);
					Lua.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
					if (Lua.lua_type(L, -1) == LuaTypes.LUA_TNUMBER && Lua.xlua_tointeger(L, -1) == reference)
					{
						Lua.lua_pop(L, 1);
						Lua.lua_pushnil(L);
						Lua.lua_rawset(L, LuaIndexes.LUA_REGISTRYINDEX);
					}
					else
					{
						Lua.lua_pop(L, 2);
					}
				}
				Lua.lua_unref(L, reference);
				this.delegate_bridges.Remove(reference);
				return;
			}
			Lua.lua_unref(L, reference);
		}

		public object CreateInterfaceBridge(IntPtr L, Type interfaceType, int idx)
		{
			Func<int, LuaEnv, LuaBase> func;
			if (!this.interfaceBridgeCreators.TryGetValue(interfaceType, out func))
			{
				throw new InvalidCastException("This type must add to CSharpCallLua: " + ((interfaceType != null) ? interfaceType.ToString() : null));
			}
			Lua.lua_pushvalue(L, idx);
			return func(Lua.luaL_ref(L), this.luaEnv);
		}

		public void CreateArrayMetatable(IntPtr L)
		{
			Utils.BeginObjectRegister(null, L, this, 0, 0, 1, 0, this.common_array_meta);
			Utils.RegisterFunc(L, -2, "Length", new lua_CSFunction(StaticLuaCallbacks.ArrayLength));
			Utils.EndObjectRegister(null, L, this, null, null, typeof(Array), new lua_CSFunction(StaticLuaCallbacks.ArrayIndexer), new lua_CSFunction(StaticLuaCallbacks.ArrayNewIndexer));
		}

		public void CreateDelegateMetatable(IntPtr L)
		{
			Utils.BeginObjectRegister(null, L, this, 3, 0, 0, 0, this.common_delegate_meta);
			Utils.RegisterFunc(L, -4, "__call", new lua_CSFunction(StaticLuaCallbacks.DelegateCall));
			Utils.RegisterFunc(L, -4, "__add", new lua_CSFunction(StaticLuaCallbacks.DelegateCombine));
			Utils.RegisterFunc(L, -4, "__sub", new lua_CSFunction(StaticLuaCallbacks.DelegateRemove));
			Utils.EndObjectRegister(null, L, this, null, null, typeof(MulticastDelegate), null, null);
		}

		internal void CreateEnumerablePairs(IntPtr L)
		{
			LuaFunction luaFunction = this.luaEnv.DoString("\r\n                return function(obj)\r\n                    local isKeyValuePair\r\n                    local function lua_iter(cs_iter, k)\r\n                        if cs_iter:MoveNext() then\r\n                            local current = cs_iter.Current\r\n                            if isKeyValuePair == nil then\r\n                                if type(current) == 'userdata' then\r\n                                    local t = current:GetType()\r\n                                    isKeyValuePair = t.Name == 'KeyValuePair`2' and t.Namespace == 'System.Collections.Generic'\r\n                                 else\r\n                                    isKeyValuePair = false\r\n                                 end\r\n                                 --print(current, isKeyValuePair)\r\n                            end\r\n                            if isKeyValuePair then\r\n                                return current.Key, current.Value\r\n                            else\r\n                                return k + 1, current\r\n                            end\r\n                        end\r\n                    end\r\n                    return lua_iter, obj:GetEnumerator(), -1\r\n                end\r\n            ", "chunk", null)[0] as LuaFunction;
			luaFunction.push(L);
			this.enumerable_pairs_func = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
			luaFunction.Dispose();
		}

		public void OpenLib(IntPtr L)
		{
			if (Lua.xlua_getglobal(L, "xlua") != 0)
			{
				throw new Exception("call xlua_getglobal fail!" + Lua.lua_tostring(L, -1));
			}
			Lua.xlua_pushasciistring(L, "import_type");
			Lua.lua_pushstdcallcfunction(L, this.importTypeFunction, 0);
			Lua.lua_rawset(L, -3);
			Lua.xlua_pushasciistring(L, "import_generic_type");
			Lua.lua_pushstdcallcfunction(L, new lua_CSFunction(StaticLuaCallbacks.ImportGenericType), 0);
			Lua.lua_rawset(L, -3);
			Lua.xlua_pushasciistring(L, "cast");
			Lua.lua_pushstdcallcfunction(L, this.castFunction, 0);
			Lua.lua_rawset(L, -3);
			Lua.xlua_pushasciistring(L, "load_assembly");
			Lua.lua_pushstdcallcfunction(L, this.loadAssemblyFunction, 0);
			Lua.lua_rawset(L, -3);
			Lua.xlua_pushasciistring(L, "access");
			Lua.lua_pushstdcallcfunction(L, new lua_CSFunction(StaticLuaCallbacks.XLuaAccess), 0);
			Lua.lua_rawset(L, -3);
			Lua.xlua_pushasciistring(L, "private_accessible");
			Lua.lua_pushstdcallcfunction(L, new lua_CSFunction(StaticLuaCallbacks.XLuaPrivateAccessible), 0);
			Lua.lua_rawset(L, -3);
			Lua.xlua_pushasciistring(L, "metatable_operation");
			Lua.lua_pushstdcallcfunction(L, new lua_CSFunction(StaticLuaCallbacks.XLuaMetatableOperation), 0);
			Lua.lua_rawset(L, -3);
			Lua.xlua_pushasciistring(L, "tofunction");
			Lua.lua_pushstdcallcfunction(L, new lua_CSFunction(StaticLuaCallbacks.ToFunction), 0);
			Lua.lua_rawset(L, -3);
			Lua.xlua_pushasciistring(L, "get_generic_method");
			Lua.lua_pushstdcallcfunction(L, new lua_CSFunction(StaticLuaCallbacks.GetGenericMethod), 0);
			Lua.lua_rawset(L, -3);
			Lua.xlua_pushasciistring(L, "release");
			Lua.lua_pushstdcallcfunction(L, new lua_CSFunction(StaticLuaCallbacks.ReleaseCsObject), 0);
			Lua.lua_rawset(L, -3);
			Lua.lua_pop(L, 1);
			Lua.lua_createtable(L, 1, 4);
			this.common_array_meta = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
			Lua.lua_createtable(L, 1, 4);
			this.common_delegate_meta = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
		}

		internal void createFunctionMetatable(IntPtr L)
		{
			Lua.lua_newtable(L);
			Lua.xlua_pushasciistring(L, "__gc");
			Lua.lua_pushstdcallcfunction(L, this.metaFunctions.GcMeta, 0);
			Lua.lua_rawset(L, -3);
			Lua.lua_pushlightuserdata(L, Lua.xlua_tag());
			Lua.lua_pushnumber(L, 1.0);
			Lua.lua_rawset(L, -3);
			Lua.lua_pushvalue(L, -1);
			int num = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
			Lua.lua_pushnumber(L, (double)num);
			Lua.xlua_rawseti(L, -2, 1L);
			Lua.lua_pop(L, 1);
			this.typeIdMap.Add(typeof(lua_CSFunction), num);
		}

		internal Type FindType(string className, bool isQualifiedName = false)
		{
			foreach (Assembly assembly in this.assemblies)
			{
				Type type = assembly.GetType(className);
				if (type != null)
				{
					return type;
				}
			}
			int num = className.IndexOf('[');
			if (num > 0 && !isQualifiedName)
			{
				string text = className.Substring(0, num + 1);
				string[] array = className.Substring(num + 1, className.Length - text.Length - 1).Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					Type type2 = this.FindType(array[i].Trim(), false);
					if (type2 == null)
					{
						return null;
					}
					if (i != 0)
					{
						text += ", ";
					}
					text = text + "[" + type2.AssemblyQualifiedName + "]";
				}
				text += "]";
				return this.FindType(text, true);
			}
			return null;
		}

		private bool hasMethod(Type type, string methodName)
		{
			MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
			for (int i = 0; i < methods.Length; i++)
			{
				if (methods[i].Name == methodName)
				{
					return true;
				}
			}
			return false;
		}

		internal void collectObject(int obj_index_to_collect)
		{
			object obj;
			if (this.objects.TryGetValue(obj_index_to_collect, out obj))
			{
				this.objects.Remove(obj_index_to_collect);
				if (obj != null)
				{
					bool flag = obj.GetType().IsEnum();
					int num;
					if ((flag ? this.enumMap.TryGetValue(obj, out num) : this.reverseMap.TryGetValue(obj, out num)) && num == obj_index_to_collect)
					{
						if (flag)
						{
							this.enumMap.Remove(obj);
							return;
						}
						this.reverseMap.Remove(obj);
					}
				}
			}
		}

		private int addObject(object obj, bool is_valuetype, bool is_enum)
		{
			int num = this.objects.Add(obj);
			if (is_enum)
			{
				this.enumMap[obj] = num;
			}
			else if (!is_valuetype)
			{
				this.reverseMap[obj] = num;
			}
			return num;
		}

		internal object GetObject(IntPtr L, int index)
		{
			return this.objectCasters.GetCaster(typeof(object))(L, index, null);
		}

		public Type GetTypeOf(IntPtr L, int idx)
		{
			Type result = null;
			int num = Lua.xlua_gettypeid(L, idx);
			if (num != -1)
			{
				this.typeMap.TryGetValue(num, out result);
			}
			return result;
		}

		public bool Assignable<T>(IntPtr L, int index)
		{
			return this.Assignable(L, index, typeof(T));
		}

		public bool Assignable(IntPtr L, int index, Type type)
		{
			if (Lua.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
			{
				int num = Lua.xlua_tocsobj_safe(L, index);
				object target;
				if (num != -1 && this.objects.TryGetValue(num, out target))
				{
					RawObject rawObject = target as RawObject;
					if (rawObject != null)
					{
						target = rawObject.Target;
					}
					if (target == null)
					{
						return !type.IsValueType();
					}
					return type.IsAssignableFrom(target.GetType());
				}
				else
				{
					int num2 = Lua.xlua_gettypeid(L, index);
					Type c;
					if (num2 != -1 && this.typeMap.TryGetValue(num2, out c))
					{
						return type.IsAssignableFrom(c);
					}
				}
			}
			return this.objectCheckers.GetChecker(type)(L, index);
		}

		public object GetObject(IntPtr L, int index, Type type)
		{
			int num = Lua.xlua_tocsobj_safe(L, index);
			if (num == -1)
			{
				if (Lua.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
				{
					int num2 = Lua.xlua_gettypeid(L, index);
					if (num2 != -1 && num2 == this.decimal_type_id)
					{
						decimal num3;
						this.Get(L, index, out num3);
						return num3;
					}
					Type c;
					ObjectTranslator.GetCSObject getCSObject;
					if (num2 != -1 && this.typeMap.TryGetValue(num2, out c) && type.IsAssignableFrom(c) && this.custom_get_funcs.TryGetValue(type, out getCSObject))
					{
						return getCSObject(L, index);
					}
				}
				return this.objectCasters.GetCaster(type)(L, index, null);
			}
			object obj = this.objects.Get(num);
			RawObject rawObject = obj as RawObject;
			if (rawObject != null)
			{
				return rawObject.Target;
			}
			return obj;
		}

		public void Get<T>(IntPtr L, int index, out T v)
		{
			Func<IntPtr, int, T> func;
			if (this.tryGetGetFuncByType<Func<IntPtr, int, T>>(typeof(T), out func))
			{
				v = func(L, index);
				return;
			}
			v = (T)((object)this.GetObject(L, index, typeof(T)));
		}

		public void PushByType<T>(IntPtr L, T v)
		{
			Action<IntPtr, T> action;
			if (this.tryGetPushFuncByType<Action<IntPtr, T>>(typeof(T), out action))
			{
				action(L, v);
				return;
			}
			this.PushAny(L, v);
		}

		public T[] GetParams<T>(IntPtr L, int index)
		{
			T[] array = new T[Math.Max(Lua.lua_gettop(L) - index + 1, 0)];
			for (int i = 0; i < array.Length; i++)
			{
				this.Get<T>(L, index + i, out array[i]);
			}
			return array;
		}

		public Array GetParams(IntPtr L, int index, Type type)
		{
			Array array = Array.CreateInstance(type, Math.Max(Lua.lua_gettop(L) - index + 1, 0));
			for (int i = 0; i < array.Length; i++)
			{
				array.SetValue(this.GetObject(L, index + i, type), i);
			}
			return array;
		}

		public T GetDelegate<T>(IntPtr L, int index) where T : class
		{
			if (Lua.lua_isfunction(L, index))
			{
				return this.CreateDelegateBridge(L, typeof(T), index) as T;
			}
			if (Lua.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
			{
				return (T)((object)this.SafeGetCSObj(L, index));
			}
			return default(T);
		}

		public int GetTypeId(IntPtr L, Type type)
		{
			bool flag;
			return this.getTypeId(L, type, out flag, ObjectTranslator.LOGLEVEL.WARN);
		}

		public void PrivateAccessible(IntPtr L, Type type)
		{
			if (!this.privateAccessibleFlags.Contains(type))
			{
				this.privateAccessibleFlags.Add(type);
				if (this.typeIdMap.ContainsKey(type))
				{
					Utils.MakePrivateAccessible(L, type);
				}
			}
		}

		internal int getTypeId(IntPtr L, Type type, out bool is_first, ObjectTranslator.LOGLEVEL log_level = ObjectTranslator.LOGLEVEL.WARN)
		{
			is_first = false;
			int num;
			if (!this.typeIdMap.TryGetValue(type, out num))
			{
				if (type.IsArray)
				{
					if (this.common_array_meta == -1)
					{
						throw new Exception("Fatal Exception! Array Metatable not inited!");
					}
					return this.common_array_meta;
				}
				else if (typeof(MulticastDelegate).IsAssignableFrom(type))
				{
					if (this.common_delegate_meta == -1)
					{
						throw new Exception("Fatal Exception! Delegate Metatable not inited!");
					}
					this.TryDelayWrapLoader(L, type);
					return this.common_delegate_meta;
				}
				else
				{
					is_first = true;
					Type type2 = null;
					this.aliasCfg.TryGetValue(type, out type2);
					Lua.luaL_getmetatable(L, (type2 == null) ? type.FullName : type2.FullName);
					if (Lua.lua_isnil(L, -1))
					{
						Lua.lua_pop(L, 1);
						if (!this.TryDelayWrapLoader(L, (type2 == null) ? type : type2))
						{
							throw new Exception("Fatal: can not load metatable of type:" + ((type != null) ? type.ToString() : null));
						}
						Lua.luaL_getmetatable(L, (type2 == null) ? type.FullName : type2.FullName);
					}
					if (this.typeIdMap.TryGetValue(type, out num))
					{
						Lua.lua_pop(L, 1);
					}
					else
					{
						if (type.IsEnum())
						{
							Lua.xlua_pushasciistring(L, "__band");
							Lua.lua_pushstdcallcfunction(L, this.metaFunctions.EnumAndMeta, 0);
							Lua.lua_rawset(L, -3);
							Lua.xlua_pushasciistring(L, "__bor");
							Lua.lua_pushstdcallcfunction(L, this.metaFunctions.EnumOrMeta, 0);
							Lua.lua_rawset(L, -3);
						}
						if (typeof(IEnumerable).IsAssignableFrom(type))
						{
							Lua.xlua_pushasciistring(L, "__pairs");
							Lua.lua_getref(L, this.enumerable_pairs_func);
							Lua.lua_rawset(L, -3);
						}
						Lua.lua_pushvalue(L, -1);
						num = Lua.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
						Lua.lua_pushnumber(L, (double)num);
						Lua.xlua_rawseti(L, -2, 1L);
						Lua.lua_pop(L, 1);
						if (type.IsValueType())
						{
							this.typeMap.Add(num, type);
						}
						this.typeIdMap.Add(type, num);
					}
				}
			}
			return num;
		}

		private void pushPrimitive(IntPtr L, object o)
		{
			if (o is sbyte || o is byte || o is short || o is ushort || o is int)
			{
				int value = Convert.ToInt32(o);
				Lua.xlua_pushinteger(L, value);
				return;
			}
			if (o is uint)
			{
				Lua.xlua_pushuint(L, (uint)o);
				return;
			}
			if (o is float || o is double)
			{
				double number = Convert.ToDouble(o);
				Lua.lua_pushnumber(L, number);
				return;
			}
			if (o is IntPtr)
			{
				Lua.lua_pushlightuserdata(L, (IntPtr)o);
				return;
			}
			if (o is char)
			{
				Lua.xlua_pushinteger(L, (int)((char)o));
				return;
			}
			if (o is long)
			{
				Lua.lua_pushint64(L, Convert.ToInt64(o));
				return;
			}
			if (o is ulong)
			{
				Lua.lua_pushuint64(L, Convert.ToUInt64(o));
				return;
			}
			if (o is bool)
			{
				bool value2 = (bool)o;
				Lua.lua_pushboolean(L, value2);
				return;
			}
			string str = "No support type ";
			Type type = o.GetType();
			throw new Exception(str + ((type != null) ? type.ToString() : null));
		}

		public void PushAny(IntPtr L, object o)
		{
			if (o == null)
			{
				Lua.lua_pushnil(L);
				return;
			}
			Type type = o.GetType();
			if (type.IsPrimitive())
			{
				this.pushPrimitive(L, o);
				return;
			}
			if (o is string)
			{
				Lua.lua_pushstring(L, o as string);
				return;
			}
			if (type == typeof(byte[]))
			{
				Lua.lua_pushstring(L, o as byte[]);
				return;
			}
			if (o is decimal)
			{
				this.PushDecimal(L, (decimal)o);
				return;
			}
			if (o is LuaBase)
			{
				((LuaBase)o).push(L);
				return;
			}
			if (o is lua_CSFunction)
			{
				this.Push(L, o as lua_CSFunction);
				return;
			}
			if (!(o is ValueType))
			{
				this.Push(L, o);
				return;
			}
			ObjectTranslator.PushCSObject pushCSObject;
			if (this.custom_push_funcs.TryGetValue(o.GetType(), out pushCSObject))
			{
				pushCSObject(L, o);
				return;
			}
			this.Push(L, o);
		}

		public int TranslateToEnumToTop(IntPtr L, Type type, int idx)
		{
			LuaTypes luaTypes = Lua.lua_type(L, idx);
			object o;
			if (luaTypes == LuaTypes.LUA_TNUMBER)
			{
				int value = (int)Lua.lua_tonumber(L, idx);
				o = Enum.ToObject(type, value);
			}
			else
			{
				if (luaTypes != LuaTypes.LUA_TSTRING)
				{
					return Lua.luaL_error(L, "#1 argument must be a integer or a string");
				}
				string value2 = Lua.lua_tostring(L, idx);
				o = Enum.Parse(type, value2);
			}
			this.PushAny(L, o);
			return 1;
		}

		public void Push(IntPtr L, lua_CSFunction o)
		{
			if (Utils.IsStaticPInvokeCSFunction(o))
			{
				Lua.lua_pushstdcallcfunction(L, o, 0);
				return;
			}
			this.Push(L, o);
			Lua.lua_pushstdcallcfunction(L, this.metaFunctions.StaticCSFunctionWraper, 1);
		}

		public void Push(IntPtr L, LuaBase o)
		{
			if (o == null)
			{
				Lua.lua_pushnil(L);
				return;
			}
			o.push(L);
		}

		public void Push(IntPtr L, object o)
		{
			if (o == null)
			{
				Lua.lua_pushnil(L);
				return;
			}
			int key = -1;
			Type type = o.GetType();
			bool isEnum = type.IsEnum;
			bool isValueType = type.IsValueType;
			bool flag = !isValueType || isEnum;
			if (flag && (isEnum ? this.enumMap.TryGetValue(o, out key) : this.reverseMap.TryGetValue(o, out key)) && Lua.xlua_tryget_cachedud(L, key, this.cacheRef) == 1)
			{
				return;
			}
			bool flag2;
			int typeId = this.getTypeId(L, type, out flag2, ObjectTranslator.LOGLEVEL.WARN);
			if (flag2 && flag && (isEnum ? this.enumMap.TryGetValue(o, out key) : this.reverseMap.TryGetValue(o, out key)) && Lua.xlua_tryget_cachedud(L, key, this.cacheRef) == 1)
			{
				return;
			}
			key = this.addObject(o, isValueType, isEnum);
			Lua.xlua_pushcsobj(L, key, typeId, flag, this.cacheRef);
		}

		public void PushObject(IntPtr L, object o, int type_id)
		{
			if (o == null)
			{
				Lua.lua_pushnil(L);
				return;
			}
			int key = -1;
			if (this.reverseMap.TryGetValue(o, out key) && Lua.xlua_tryget_cachedud(L, key, this.cacheRef) == 1)
			{
				return;
			}
			key = this.addObject(o, false, false);
			Lua.xlua_pushcsobj(L, key, type_id, true, this.cacheRef);
		}

		public void Update(IntPtr L, int index, object obj)
		{
			int num = Lua.xlua_tocsobj_fast(L, index);
			if (num != -1)
			{
				this.objects.Replace(num, obj);
				return;
			}
			ObjectTranslator.UpdateCSObject updateCSObject;
			if (this.custom_update_funcs.TryGetValue(obj.GetType(), out updateCSObject))
			{
				updateCSObject(L, index, obj);
				return;
			}
			throw new Exception("can not update [" + ((obj != null) ? obj.ToString() : null) + "]");
		}

		private object getCsObj(IntPtr L, int index, int udata)
		{
			if (udata == -1)
			{
				if (Lua.lua_type(L, index) != LuaTypes.LUA_TUSERDATA)
				{
					return null;
				}
				Type typeOf = this.GetTypeOf(L, index);
				if (typeOf == typeof(decimal))
				{
					decimal num;
					this.Get(L, index, out num);
					return num;
				}
				ObjectTranslator.GetCSObject getCSObject;
				if (typeOf != null && this.custom_get_funcs.TryGetValue(typeOf, out getCSObject))
				{
					return getCSObject(L, index);
				}
				return null;
			}
			else
			{
				object result;
				if (this.objects.TryGetValue(udata, out result))
				{
					return result;
				}
				return null;
			}
		}

		internal object SafeGetCSObj(IntPtr L, int index)
		{
			return this.getCsObj(L, index, Lua.xlua_tocsobj_safe(L, index));
		}

		internal object FastGetCSObj(IntPtr L, int index)
		{
			return this.getCsObj(L, index, Lua.xlua_tocsobj_fast(L, index));
		}

		internal void ReleaseCSObj(IntPtr L, int index)
		{
			int num = Lua.xlua_tocsobj_safe(L, index);
			if (num != -1)
			{
				object obj = this.objects.Replace(num, null);
				if (obj != null && this.reverseMap.ContainsKey(obj))
				{
					this.reverseMap.Remove(obj);
				}
			}
		}

		internal lua_CSFunction GetFixCSFunction(int index)
		{
			return this.fix_cs_functions[index];
		}

		internal void PushFixCSFunction(IntPtr L, lua_CSFunction func)
		{
			if (func == null)
			{
				Lua.lua_pushnil(L);
				return;
			}
			Lua.xlua_pushinteger(L, this.fix_cs_functions.Count);
			this.fix_cs_functions.Add(func);
			Lua.lua_pushstdcallcfunction(L, this.metaFunctions.FixCSFunctionWraper, 1);
		}

		internal object[] popValues(IntPtr L, int oldTop)
		{
			int num = Lua.lua_gettop(L);
			if (oldTop == num)
			{
				return null;
			}
			ArrayList arrayList = new ArrayList();
			for (int i = oldTop + 1; i <= num; i++)
			{
				arrayList.Add(this.GetObject(L, i));
			}
			Lua.lua_settop(L, oldTop);
			return arrayList.ToArray();
		}

		internal object[] popValues(IntPtr L, int oldTop, Type[] popTypes)
		{
			int num = Lua.lua_gettop(L);
			if (oldTop == num)
			{
				return null;
			}
			ArrayList arrayList = new ArrayList();
			int num2;
			if (popTypes[0] == typeof(void))
			{
				num2 = 1;
			}
			else
			{
				num2 = 0;
			}
			for (int i = oldTop + 1; i <= num; i++)
			{
				arrayList.Add(this.GetObject(L, i, popTypes[num2]));
				num2++;
			}
			Lua.lua_settop(L, oldTop);
			return arrayList.ToArray();
		}

		private void registerCustomOp(Type type, ObjectTranslator.PushCSObject push, ObjectTranslator.GetCSObject get, ObjectTranslator.UpdateCSObject update)
		{
			if (push != null)
			{
				this.custom_push_funcs.Add(type, push);
			}
			if (get != null)
			{
				this.custom_get_funcs.Add(type, get);
			}
			if (update != null)
			{
				this.custom_update_funcs.Add(type, update);
			}
		}

		public bool HasCustomOp(Type type)
		{
			return this.custom_push_funcs.ContainsKey(type);
		}

		private bool tryGetPushFuncByType<T>(Type type, out T func) where T : class
		{
			if (this.push_func_with_type == null)
			{
				Dictionary<Type, Delegate> dictionary = new Dictionary<Type, Delegate>();
				dictionary.Add(typeof(int), new Action<IntPtr, int>(Lua.xlua_pushinteger));
				dictionary.Add(typeof(double), new Action<IntPtr, double>(Lua.lua_pushnumber));
				dictionary.Add(typeof(string), new Action<IntPtr, string>(Lua.lua_pushstring));
				dictionary.Add(typeof(byte[]), new Action<IntPtr, byte[]>(Lua.lua_pushstring));
				dictionary.Add(typeof(bool), new Action<IntPtr, bool>(Lua.lua_pushboolean));
				dictionary.Add(typeof(long), new Action<IntPtr, long>(Lua.lua_pushint64));
				dictionary.Add(typeof(ulong), new Action<IntPtr, ulong>(Lua.lua_pushuint64));
				dictionary.Add(typeof(IntPtr), new Action<IntPtr, IntPtr>(Lua.lua_pushlightuserdata));
				dictionary.Add(typeof(decimal), new Action<IntPtr, decimal>(this.PushDecimal));
				dictionary.Add(typeof(byte), new Action<IntPtr, byte>(delegate(IntPtr L, byte v)
				{
					Lua.xlua_pushinteger(L, (int)v);
				}));
				dictionary.Add(typeof(sbyte), new Action<IntPtr, sbyte>(delegate(IntPtr L, sbyte v)
				{
					Lua.xlua_pushinteger(L, (int)v);
				}));
				dictionary.Add(typeof(char), new Action<IntPtr, char>(delegate(IntPtr L, char v)
				{
					Lua.xlua_pushinteger(L, (int)v);
				}));
				dictionary.Add(typeof(short), new Action<IntPtr, short>(delegate(IntPtr L, short v)
				{
					Lua.xlua_pushinteger(L, (int)v);
				}));
				dictionary.Add(typeof(ushort), new Action<IntPtr, ushort>(delegate(IntPtr L, ushort v)
				{
					Lua.xlua_pushinteger(L, (int)v);
				}));
				dictionary.Add(typeof(uint), new Action<IntPtr, uint>(Lua.xlua_pushuint));
				dictionary.Add(typeof(float), new Action<IntPtr, float>(delegate(IntPtr L, float v)
				{
					Lua.lua_pushnumber(L, (double)v);
				}));
				this.push_func_with_type = dictionary;
			}
			Delegate @delegate;
			if (this.push_func_with_type.TryGetValue(type, out @delegate))
			{
				func = (@delegate as T);
				return true;
			}
			func = default(T);
			return false;
		}

		private bool tryGetGetFuncByType<T>(Type type, out T func) where T : class
		{
			if (this.get_func_with_type == null)
			{
				Dictionary<Type, Delegate> dictionary = new Dictionary<Type, Delegate>();
				dictionary.Add(typeof(int), new Func<IntPtr, int, int>(Lua.xlua_tointeger));
				dictionary.Add(typeof(double), new Func<IntPtr, int, double>(Lua.lua_tonumber));
				dictionary.Add(typeof(string), new Func<IntPtr, int, string>(Lua.lua_tostring));
				dictionary.Add(typeof(byte[]), new Func<IntPtr, int, byte[]>(Lua.lua_tobytes));
				dictionary.Add(typeof(bool), new Func<IntPtr, int, bool>(Lua.lua_toboolean));
				dictionary.Add(typeof(long), new Func<IntPtr, int, long>(Lua.lua_toint64));
				dictionary.Add(typeof(ulong), new Func<IntPtr, int, ulong>(Lua.lua_touint64));
				dictionary.Add(typeof(IntPtr), new Func<IntPtr, int, IntPtr>(Lua.lua_touserdata));
				dictionary.Add(typeof(decimal), new Func<IntPtr, int, decimal>(delegate(IntPtr L, int idx)
				{
					decimal result;
					this.Get(L, idx, out result);
					return result;
				}));
				dictionary.Add(typeof(byte), new Func<IntPtr, int, byte>((IntPtr L, int idx) => (byte)Lua.xlua_tointeger(L, idx)));
				dictionary.Add(typeof(sbyte), new Func<IntPtr, int, sbyte>((IntPtr L, int idx) => (sbyte)Lua.xlua_tointeger(L, idx)));
				dictionary.Add(typeof(char), new Func<IntPtr, int, char>((IntPtr L, int idx) => (char)Lua.xlua_tointeger(L, idx)));
				dictionary.Add(typeof(short), new Func<IntPtr, int, short>((IntPtr L, int idx) => (short)Lua.xlua_tointeger(L, idx)));
				dictionary.Add(typeof(ushort), new Func<IntPtr, int, ushort>((IntPtr L, int idx) => (ushort)Lua.xlua_tointeger(L, idx)));
				dictionary.Add(typeof(uint), new Func<IntPtr, int, uint>(Lua.xlua_touint));
				dictionary.Add(typeof(float), new Func<IntPtr, int, float>((IntPtr L, int idx) => (float)Lua.lua_tonumber(L, idx)));
				this.get_func_with_type = dictionary;
			}
			Delegate @delegate;
			if (this.get_func_with_type.TryGetValue(type, out @delegate))
			{
				func = (@delegate as T);
				return true;
			}
			func = default(T);
			return false;
		}

		public void RegisterPushAndGetAndUpdate<T>(Action<IntPtr, T> push, ObjectTranslator.GetFunc<T> get, Action<IntPtr, int, T> update)
		{
			Type typeFromHandle = typeof(T);
			Action<IntPtr, T> action;
			Func<IntPtr, int, T> func;
			if (this.tryGetPushFuncByType<Action<IntPtr, T>>(typeFromHandle, out action) || this.tryGetGetFuncByType<Func<IntPtr, int, T>>(typeFromHandle, out func))
			{
				string str = "push or get of ";
				Type type = typeFromHandle;
				throw new InvalidOperationException(str + ((type != null) ? type.ToString() : null) + " has register!");
			}
			this.push_func_with_type.Add(typeFromHandle, push);
			this.get_func_with_type.Add(typeFromHandle, new Func<IntPtr, int, T>(delegate(IntPtr L, int idx)
			{
				T result;
				get(L, idx, out result);
				return result;
			}));
			this.registerCustomOp(typeFromHandle, delegate(IntPtr L, object obj)
			{
				push(L, (T)((object)obj));
			}, delegate(IntPtr L, int idx)
			{
				T t;
				get(L, idx, out t);
				return t;
			}, delegate(IntPtr L, int idx, object obj)
			{
				update(L, idx, (T)((object)obj));
			});
		}

		public void RegisterCaster<T>(ObjectTranslator.GetFunc<T> get)
		{
			this.objectCasters.AddCaster(typeof(T), delegate(IntPtr L, int idx, object o)
			{
				T t;
				get(L, idx, out t);
				return t;
			});
		}

		public void PushDecimal(IntPtr L, decimal val)
		{
			if (this.decimal_type_id == -1)
			{
				bool flag;
				this.decimal_type_id = this.getTypeId(L, typeof(decimal), out flag, ObjectTranslator.LOGLEVEL.WARN);
			}
			if (!CopyByValue.Pack(Lua.xlua_pushstruct(L, 16U, this.decimal_type_id), 0, val))
			{
				throw new Exception("pack fail for decimal ,value=" + val.ToString());
			}
		}

		public bool IsDecimal(IntPtr L, int index)
		{
			return this.decimal_type_id != -1 && Lua.xlua_gettypeid(L, index) == this.decimal_type_id;
		}

		public decimal GetDecimal(IntPtr L, int index)
		{
			decimal result;
			this.Get(L, index, out result);
			return result;
		}

		public void Get(IntPtr L, int index, out decimal val)
		{
			LuaTypes luaTypes = Lua.lua_type(L, index);
			if (luaTypes == LuaTypes.LUA_TUSERDATA)
			{
				if (Lua.xlua_gettypeid(L, index) != this.decimal_type_id)
				{
					throw new Exception("invalid userdata for decimal!");
				}
				if (!CopyByValue.UnPack(Lua.lua_touserdata(L, index), 0, out val))
				{
					throw new Exception("unpack decimal fail!");
				}
				return;
			}
			else
			{
				if (luaTypes != LuaTypes.LUA_TNUMBER)
				{
					throw new Exception("invalid lua value for decimal, LuaType=" + luaTypes.ToString());
				}
				if (Lua.lua_isint64(L, index))
				{
					val = Lua.lua_toint64(L, index);
					return;
				}
				val = (decimal)Lua.lua_tonumber(L, index);
				return;
			}
		}

		private static ObjectTranslator.IniterAdderUnityEngineVector2 s_IniterAdderUnityEngineVector2_dumb_obj = new ObjectTranslator.IniterAdderUnityEngineVector2();

		private int UnityEngineVector2_TypeID = -1;

		private int UnityEngineVector3_TypeID = -1;

		private int UnityEngineVector4_TypeID = -1;

		private int UnityEngineColor_TypeID = -1;

		private int UnityEngineQuaternion_TypeID = -1;

		private int UnityEngineRay_TypeID = -1;

		private int UnityEngineBounds_TypeID = -1;

		private int UnityEngineRay2D_TypeID = -1;

		private int XLuaTestPedding_TypeID = -1;

		private int XLuaTestMyStruct_TypeID = -1;

		private int XLuaTestPushAsTableStruct_TypeID = -1;

		private int DGTweeningAutoPlay_TypeID = -1;

		private int DGTweeningAutoPlay_EnumRef = -1;

		private int DGTweeningAxisConstraint_TypeID = -1;

		private int DGTweeningAxisConstraint_EnumRef = -1;

		private int DGTweeningEase_TypeID = -1;

		private int DGTweeningEase_EnumRef = -1;

		private int DGTweeningLogBehaviour_TypeID = -1;

		private int DGTweeningLogBehaviour_EnumRef = -1;

		private int DGTweeningLoopType_TypeID = -1;

		private int DGTweeningLoopType_EnumRef = -1;

		private int DGTweeningPathMode_TypeID = -1;

		private int DGTweeningPathMode_EnumRef = -1;

		private int DGTweeningPathType_TypeID = -1;

		private int DGTweeningPathType_EnumRef = -1;

		private int DGTweeningRotateMode_TypeID = -1;

		private int DGTweeningRotateMode_EnumRef = -1;

		private int DGTweeningScrambleMode_TypeID = -1;

		private int DGTweeningScrambleMode_EnumRef = -1;

		private int DGTweeningTweenType_TypeID = -1;

		private int DGTweeningTweenType_EnumRef = -1;

		private int DGTweeningUpdateType_TypeID = -1;

		private int DGTweeningUpdateType_EnumRef = -1;

		private int TutorialTestEnum_TypeID = -1;

		private int TutorialTestEnum_EnumRef = -1;

		private int XLuaTestMyEnum_TypeID = -1;

		private int XLuaTestMyEnum_EnumRef = -1;

		private int TutorialDerivedClassTestEnumInner_TypeID = -1;

		private int TutorialDerivedClassTestEnumInner_EnumRef = -1;

		private static XLua_Gen_Initer_Register__ s_gen_reg_dumb_obj = new XLua_Gen_Initer_Register__();

		internal MethodWrapsCache methodWrapsCache;

		internal ObjectCheckers objectCheckers;

		internal ObjectCasters objectCasters;

		internal readonly ObjectPool objects = new ObjectPool();

		internal readonly Dictionary<object, int> reverseMap = new Dictionary<object, int>(new ReferenceEqualsComparer());

		internal LuaEnv luaEnv;

		internal StaticLuaCallbacks metaFunctions;

		internal List<Assembly> assemblies;

		private lua_CSFunction importTypeFunction;

		private lua_CSFunction loadAssemblyFunction;

		private lua_CSFunction castFunction;

		private readonly Dictionary<Type, Action<IntPtr>> delayWrap = new Dictionary<Type, Action<IntPtr>>();

		private readonly Dictionary<Type, Func<int, LuaEnv, LuaBase>> interfaceBridgeCreators = new Dictionary<Type, Func<int, LuaEnv, LuaBase>>();

		private readonly Dictionary<Type, Type> aliasCfg = new Dictionary<Type, Type>();

		private Dictionary<Type, bool> loaded_types = new Dictionary<Type, bool>();

		public int cacheRef;

		private MethodInfo[] genericAction;

		private MethodInfo[] genericFunc;

		private Dictionary<Type, Func<DelegateBridgeBase, Delegate>> delegateCreatorCache = new Dictionary<Type, Func<DelegateBridgeBase, Delegate>>();

		private Dictionary<int, WeakReference> delegate_bridges = new Dictionary<int, WeakReference>();

		private int common_array_meta = -1;

		private int common_delegate_meta = -1;

		private int enumerable_pairs_func = -1;

		private Dictionary<Type, int> typeIdMap = new Dictionary<Type, int>();

		private Dictionary<int, Type> typeMap = new Dictionary<int, Type>();

		private HashSet<Type> privateAccessibleFlags = new HashSet<Type>();

		private Dictionary<object, int> enumMap = new Dictionary<object, int>();

		private List<lua_CSFunction> fix_cs_functions = new List<lua_CSFunction>();

		private Dictionary<Type, ObjectTranslator.PushCSObject> custom_push_funcs = new Dictionary<Type, ObjectTranslator.PushCSObject>();

		private Dictionary<Type, ObjectTranslator.GetCSObject> custom_get_funcs = new Dictionary<Type, ObjectTranslator.GetCSObject>();

		private Dictionary<Type, ObjectTranslator.UpdateCSObject> custom_update_funcs = new Dictionary<Type, ObjectTranslator.UpdateCSObject>();

		private Dictionary<Type, Delegate> push_func_with_type;

		private Dictionary<Type, Delegate> get_func_with_type;

		private int decimal_type_id = -1;

		private class IniterAdderUnityEngineVector2
		{
			static IniterAdderUnityEngineVector2()
			{
				LuaEnv.AddIniter(new Action<LuaEnv, ObjectTranslator>(ObjectTranslator.IniterAdderUnityEngineVector2.Init));
			}

			private static void Init(LuaEnv luaenv, ObjectTranslator translator)
			{
				translator.RegisterPushAndGetAndUpdate<Vector2>(new Action<IntPtr, Vector2>(translator.PushUnityEngineVector2), new ObjectTranslator.GetFunc<Vector2>(translator.Get), new Action<IntPtr, int, Vector2>(translator.UpdateUnityEngineVector2));
				translator.RegisterPushAndGetAndUpdate<Vector3>(new Action<IntPtr, Vector3>(translator.PushUnityEngineVector3), new ObjectTranslator.GetFunc<Vector3>(translator.Get), new Action<IntPtr, int, Vector3>(translator.UpdateUnityEngineVector3));
				translator.RegisterPushAndGetAndUpdate<Vector4>(new Action<IntPtr, Vector4>(translator.PushUnityEngineVector4), new ObjectTranslator.GetFunc<Vector4>(translator.Get), new Action<IntPtr, int, Vector4>(translator.UpdateUnityEngineVector4));
				translator.RegisterPushAndGetAndUpdate<Color>(new Action<IntPtr, Color>(translator.PushUnityEngineColor), new ObjectTranslator.GetFunc<Color>(translator.Get), new Action<IntPtr, int, Color>(translator.UpdateUnityEngineColor));
				translator.RegisterPushAndGetAndUpdate<Quaternion>(new Action<IntPtr, Quaternion>(translator.PushUnityEngineQuaternion), new ObjectTranslator.GetFunc<Quaternion>(translator.Get), new Action<IntPtr, int, Quaternion>(translator.UpdateUnityEngineQuaternion));
				translator.RegisterPushAndGetAndUpdate<Ray>(new Action<IntPtr, Ray>(translator.PushUnityEngineRay), new ObjectTranslator.GetFunc<Ray>(translator.Get), new Action<IntPtr, int, Ray>(translator.UpdateUnityEngineRay));
				translator.RegisterPushAndGetAndUpdate<Bounds>(new Action<IntPtr, Bounds>(translator.PushUnityEngineBounds), new ObjectTranslator.GetFunc<Bounds>(translator.Get), new Action<IntPtr, int, Bounds>(translator.UpdateUnityEngineBounds));
				translator.RegisterPushAndGetAndUpdate<Ray2D>(new Action<IntPtr, Ray2D>(translator.PushUnityEngineRay2D), new ObjectTranslator.GetFunc<Ray2D>(translator.Get), new Action<IntPtr, int, Ray2D>(translator.UpdateUnityEngineRay2D));
				translator.RegisterPushAndGetAndUpdate<Pedding>(new Action<IntPtr, Pedding>(translator.PushXLuaTestPedding), new ObjectTranslator.GetFunc<Pedding>(translator.Get), new Action<IntPtr, int, Pedding>(translator.UpdateXLuaTestPedding));
				translator.RegisterPushAndGetAndUpdate<MyStruct>(new Action<IntPtr, MyStruct>(translator.PushXLuaTestMyStruct), new ObjectTranslator.GetFunc<MyStruct>(translator.Get), new Action<IntPtr, int, MyStruct>(translator.UpdateXLuaTestMyStruct));
				translator.RegisterPushAndGetAndUpdate<PushAsTableStruct>(new Action<IntPtr, PushAsTableStruct>(translator.PushXLuaTestPushAsTableStruct), new ObjectTranslator.GetFunc<PushAsTableStruct>(translator.Get), new Action<IntPtr, int, PushAsTableStruct>(translator.UpdateXLuaTestPushAsTableStruct));
				translator.RegisterPushAndGetAndUpdate<AutoPlay>(new Action<IntPtr, AutoPlay>(translator.PushDGTweeningAutoPlay), new ObjectTranslator.GetFunc<AutoPlay>(translator.Get), new Action<IntPtr, int, AutoPlay>(translator.UpdateDGTweeningAutoPlay));
				translator.RegisterPushAndGetAndUpdate<AxisConstraint>(new Action<IntPtr, AxisConstraint>(translator.PushDGTweeningAxisConstraint), new ObjectTranslator.GetFunc<AxisConstraint>(translator.Get), new Action<IntPtr, int, AxisConstraint>(translator.UpdateDGTweeningAxisConstraint));
				translator.RegisterPushAndGetAndUpdate<Ease>(new Action<IntPtr, Ease>(translator.PushDGTweeningEase), new ObjectTranslator.GetFunc<Ease>(translator.Get), new Action<IntPtr, int, Ease>(translator.UpdateDGTweeningEase));
				translator.RegisterPushAndGetAndUpdate<LogBehaviour>(new Action<IntPtr, LogBehaviour>(translator.PushDGTweeningLogBehaviour), new ObjectTranslator.GetFunc<LogBehaviour>(translator.Get), new Action<IntPtr, int, LogBehaviour>(translator.UpdateDGTweeningLogBehaviour));
				translator.RegisterPushAndGetAndUpdate<LoopType>(new Action<IntPtr, LoopType>(translator.PushDGTweeningLoopType), new ObjectTranslator.GetFunc<LoopType>(translator.Get), new Action<IntPtr, int, LoopType>(translator.UpdateDGTweeningLoopType));
				translator.RegisterPushAndGetAndUpdate<PathMode>(new Action<IntPtr, PathMode>(translator.PushDGTweeningPathMode), new ObjectTranslator.GetFunc<PathMode>(translator.Get), new Action<IntPtr, int, PathMode>(translator.UpdateDGTweeningPathMode));
				translator.RegisterPushAndGetAndUpdate<PathType>(new Action<IntPtr, PathType>(translator.PushDGTweeningPathType), new ObjectTranslator.GetFunc<PathType>(translator.Get), new Action<IntPtr, int, PathType>(translator.UpdateDGTweeningPathType));
				translator.RegisterPushAndGetAndUpdate<RotateMode>(new Action<IntPtr, RotateMode>(translator.PushDGTweeningRotateMode), new ObjectTranslator.GetFunc<RotateMode>(translator.Get), new Action<IntPtr, int, RotateMode>(translator.UpdateDGTweeningRotateMode));
				translator.RegisterPushAndGetAndUpdate<ScrambleMode>(new Action<IntPtr, ScrambleMode>(translator.PushDGTweeningScrambleMode), new ObjectTranslator.GetFunc<ScrambleMode>(translator.Get), new Action<IntPtr, int, ScrambleMode>(translator.UpdateDGTweeningScrambleMode));
				translator.RegisterPushAndGetAndUpdate<TweenType>(new Action<IntPtr, TweenType>(translator.PushDGTweeningTweenType), new ObjectTranslator.GetFunc<TweenType>(translator.Get), new Action<IntPtr, int, TweenType>(translator.UpdateDGTweeningTweenType));
				translator.RegisterPushAndGetAndUpdate<UpdateType>(new Action<IntPtr, UpdateType>(translator.PushDGTweeningUpdateType), new ObjectTranslator.GetFunc<UpdateType>(translator.Get), new Action<IntPtr, int, UpdateType>(translator.UpdateDGTweeningUpdateType));
				translator.RegisterPushAndGetAndUpdate<TestEnum>(new Action<IntPtr, TestEnum>(translator.PushTutorialTestEnum), new ObjectTranslator.GetFunc<TestEnum>(translator.Get), new Action<IntPtr, int, TestEnum>(translator.UpdateTutorialTestEnum));
				translator.RegisterPushAndGetAndUpdate<MyEnum>(new Action<IntPtr, MyEnum>(translator.PushXLuaTestMyEnum), new ObjectTranslator.GetFunc<MyEnum>(translator.Get), new Action<IntPtr, int, MyEnum>(translator.UpdateXLuaTestMyEnum));
				translator.RegisterPushAndGetAndUpdate<DerivedClass.TestEnumInner>(new Action<IntPtr, DerivedClass.TestEnumInner>(translator.PushTutorialDerivedClassTestEnumInner), new ObjectTranslator.GetFunc<DerivedClass.TestEnumInner>(translator.Get), new Action<IntPtr, int, DerivedClass.TestEnumInner>(translator.UpdateTutorialDerivedClassTestEnumInner));
			}
		}

		internal enum LOGLEVEL
		{
			NO,
			INFO,
			WARN,
			ERROR
		}

		public delegate void PushCSObject(IntPtr L, object obj);

		public delegate object GetCSObject(IntPtr L, int idx);

		public delegate void UpdateCSObject(IntPtr L, int idx, object obj);

		public delegate void GetFunc<T>(IntPtr L, int idx, out T val);
	}
}
