using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class ICardLogicBridge : LuaBase, ICardLogic
	{
		public static LuaBase __Create(int reference, LuaEnv luaenv)
		{
			return new ICardLogicBridge(reference, luaenv);
		}

		public ICardLogicBridge(int reference, LuaEnv luaenv) : base(reference, luaenv)
		{
		}

		void ICardLogic.Init()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "Init");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function Init");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				if (Lua.lua_pcall(l, 1, 0, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_settop(l, num - 1);
			}
		}

		void ICardLogic.OnShowTips()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnShowTips");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnShowTips");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				if (Lua.lua_pcall(l, 1, 0, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_settop(l, num - 1);
			}
		}

		IEnumerator ICardLogic.Terminate(CardSlotData cardSlotData)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "Terminate");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function Terminate");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, cardSlotData);
				if (Lua.lua_pcall(l, 2, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		void ICardLogic.OnLeftClick(List<Vector2[]> res)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnLeftClick");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnLeftClick");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, res);
				if (Lua.lua_pcall(l, 2, 0, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_settop(l, num - 1);
			}
		}

		void ICardLogic.OnRightClick(List<Vector2[]> res)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnRightClick");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnRightClick");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, res);
				if (Lua.lua_pcall(l, 2, 0, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_settop(l, num - 1);
			}
		}

		void ICardLogic.OnPlayerExitArea()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnPlayerExitArea");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnPlayerExitArea");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				if (Lua.lua_pcall(l, 1, 0, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_settop(l, num - 1);
			}
		}

		void ICardLogic.OnActEnd()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnActEnd");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnActEnd");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				if (Lua.lua_pcall(l, 1, 0, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_settop(l, num - 1);
			}
		}

		IEnumerator ICardLogic.OnEndTurn(bool isPlayerTurn)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnEndTurn");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnEndTurn");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				Lua.lua_pushboolean(l, isPlayerTurn);
				if (Lua.lua_pcall(l, 2, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.CustomAttack(CardSlotData target)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "CustomAttack");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function CustomAttack");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, target);
				if (Lua.lua_pcall(l, 2, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnTurnStart()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnTurnStart");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnTurnStart");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				if (Lua.lua_pcall(l, 1, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnAttackEffect(CardData origin, CardData target)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnAttackEffect");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnAttackEffect");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, origin);
				translator.Push(l, target);
				if (Lua.lua_pcall(l, 3, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnHpChange(CardData player, int changedValue, CardData from)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnHpChange");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnHpChange");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, player);
				Lua.xlua_pushinteger(l, changedValue);
				translator.Push(l, from);
				if (Lua.lua_pcall(l, 4, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnBeforeHpChange(CardData player, RefInt value, CardData from)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnBeforeHpChange");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnBeforeHpChange");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, player);
				translator.Push(l, value);
				translator.Push(l, from);
				if (Lua.lua_pcall(l, 4, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnBeforeAttack(CardData player, CardSlotData target)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnBeforeAttack");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnBeforeAttack");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, player);
				translator.Push(l, target);
				if (Lua.lua_pcall(l, 3, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnAfterAttack(CardData player, CardSlotData target)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnAfterAttack");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnAfterAttack");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, player);
				translator.Push(l, target);
				if (Lua.lua_pcall(l, 3, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnFinishAttack(CardData player, CardSlotData target)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnFinishAttack");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnFinishAttack");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, player);
				translator.Push(l, target);
				if (Lua.lua_pcall(l, 3, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnKill(CardData target, int value, CardData from)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnKill");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnKill");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, target);
				Lua.xlua_pushinteger(l, value);
				translator.Push(l, from);
				if (Lua.lua_pcall(l, 4, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		void ICardLogic.OnMerge(CardData mergeBy)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnMerge");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnMerge");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, mergeBy);
				if (Lua.lua_pcall(l, 2, 0, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_settop(l, num - 1);
			}
		}

		IEnumerator ICardLogic.OnMoneyChanged(int value)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnMoneyChanged");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnMoneyChanged");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				Lua.xlua_pushinteger(l, value);
				if (Lua.lua_pcall(l, 2, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnAfterKill");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnAfterKill");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, cardSlot);
				translator.Push(l, originCarddata);
				if (Lua.lua_pcall(l, 3, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnBattleStart()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnBattleStart");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnBattleStart");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				if (Lua.lua_pcall(l, 1, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnBattleEnd()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnBattleEnd");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnBattleEnd");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				if (Lua.lua_pcall(l, 1, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnUseSkill()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnUseSkill");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnUseSkill");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				if (Lua.lua_pcall(l, 1, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnCardBeforeUseSkill(CardData user, CardLogic origin)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnCardBeforeUseSkill");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnCardBeforeUseSkill");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, user);
				translator.Push(l, origin);
				if (Lua.lua_pcall(l, 3, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnCardAfterUseSkill(CardData user, CardLogic origin)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnCardAfterUseSkill");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnCardAfterUseSkill");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, user);
				translator.Push(l, origin);
				if (Lua.lua_pcall(l, 3, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnEnterArea(string areaID)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnEnterArea");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnEnterArea");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				Lua.lua_pushstring(l, areaID);
				if (Lua.lua_pcall(l, 2, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.OnMoveOnMap()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "OnMoveOnMap");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function OnMoveOnMap");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				if (Lua.lua_pcall(l, 1, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		IEnumerator ICardLogic.BeforeFact()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			IEnumerator result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "BeforeFact");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function BeforeFact");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				if (Lua.lua_pcall(l, 1, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				IEnumerator enumerator = (IEnumerator)translator.GetObject(l, num + 1, typeof(IEnumerator));
				Lua.lua_settop(l, num - 1);
				result = enumerator;
			}
			return result;
		}

		CardLogic ICardLogic.myCardLogic
		{
			get
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				CardLogic result;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int oldTop = Lua.lua_gettop(l);
					ObjectTranslator translator = this.luaEnv.translator;
					Lua.lua_getref(l, this.luaReference);
					Lua.xlua_pushasciistring(l, "myCardLogic");
					if (Lua.xlua_pgettable(l, -2) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(oldTop);
					}
					CardLogic cardLogic = (CardLogic)translator.GetObject(l, -1, typeof(CardLogic));
					Lua.lua_pop(l, 2);
					result = cardLogic;
				}
				return result;
			}
			set
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int oldTop = Lua.lua_gettop(l);
					ObjectTranslator translator = this.luaEnv.translator;
					Lua.lua_getref(l, this.luaReference);
					Lua.xlua_pushasciistring(l, "myCardLogic");
					translator.Push(l, value);
					if (Lua.xlua_psettable(l, -3) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(oldTop);
					}
					Lua.lua_pop(l, 1);
				}
			}
		}

		bool ICardLogic.IsCustomAttack
		{
			get
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				bool result;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int oldTop = Lua.lua_gettop(l);
					Lua.lua_getref(l, this.luaReference);
					Lua.xlua_pushasciistring(l, "IsCustomAttack");
					if (Lua.xlua_pgettable(l, -2) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(oldTop);
					}
					bool flag2 = Lua.lua_toboolean(l, -1);
					Lua.lua_pop(l, 2);
					result = flag2;
				}
				return result;
			}
			set
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int oldTop = Lua.lua_gettop(l);
					Lua.lua_getref(l, this.luaReference);
					Lua.xlua_pushasciistring(l, "IsCustomAttack");
					Lua.lua_pushboolean(l, value);
					if (Lua.xlua_psettable(l, -3) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(oldTop);
					}
					Lua.lua_pop(l, 1);
				}
			}
		}
	}
}
