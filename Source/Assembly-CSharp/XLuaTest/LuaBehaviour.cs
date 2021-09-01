using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	[LuaCallCSharp(GenFlag.No)]
	public class LuaBehaviour : MonoBehaviour
	{
		private void Awake()
		{
			this.scriptEnv = LuaBehaviour.luaEnv.NewTable();
			LuaTable luaTable = LuaBehaviour.luaEnv.NewTable();
			luaTable.Set<string, LuaTable>("__index", LuaBehaviour.luaEnv.Global);
			this.scriptEnv.SetMetaTable(luaTable);
			luaTable.Dispose();
			this.scriptEnv.Set<string, LuaBehaviour>("self", this);
			foreach (Injection injection in this.injections)
			{
				this.scriptEnv.Set<string, GameObject>(injection.name, injection.value);
			}
			LuaBehaviour.luaEnv.DoString(this.luaScript.text, "LuaTestScript", this.scriptEnv);
			Action action = this.scriptEnv.Get<Action>("awake");
			this.scriptEnv.Get<string, Action>("start", out this.luaStart);
			this.scriptEnv.Get<string, Action>("update", out this.luaUpdate);
			this.scriptEnv.Get<string, Action>("ondestroy", out this.luaOnDestroy);
			if (action != null)
			{
				action();
			}
		}

		private void Start()
		{
			if (this.luaStart != null)
			{
				this.luaStart();
			}
		}

		private void Update()
		{
			if (this.luaUpdate != null)
			{
				this.luaUpdate();
			}
			if (Time.time - LuaBehaviour.lastGCTime > 1f)
			{
				LuaBehaviour.luaEnv.Tick();
				LuaBehaviour.lastGCTime = Time.time;
			}
		}

		private void OnDestroy()
		{
			if (this.luaOnDestroy != null)
			{
				this.luaOnDestroy();
			}
			this.luaOnDestroy = null;
			this.luaUpdate = null;
			this.luaStart = null;
			this.scriptEnv.Dispose();
			this.injections = null;
		}

		public TextAsset luaScript;

		public Injection[] injections;

		internal static LuaEnv luaEnv = new LuaEnv();

		internal static float lastGCTime = 0f;

		internal const float GCInterval = 1f;

		private Action luaStart;

		private Action luaUpdate;

		private Action luaOnDestroy;

		private LuaTable scriptEnv;
	}
}
