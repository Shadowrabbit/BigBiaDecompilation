using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	[LuaCallCSharp(GenFlag.No)]
	public class NoGc : MonoBehaviour
	{
		public float FloatParamMethod(float p)
		{
			return p;
		}

		public Vector3 Vector3ParamMethod(Vector3 p)
		{
			return p;
		}

		public MyStruct StructParamMethod(MyStruct p)
		{
			return p;
		}

		public MyEnum EnumParamMethod(MyEnum p)
		{
			return p;
		}

		public decimal DecimalParamMethod(decimal p)
		{
			return p;
		}

		private void Start()
		{
			this.luaenv.DoString("\r\n                function id(...)\r\n                    return ...\r\n                end\r\n\r\n                function add(a, b) return a + b end\r\n            \r\n                function array_exchange(arr)\r\n                    arr[0], arr[1] = arr[1], arr[0]\r\n                end\r\n\r\n                local v3 = CS.UnityEngine.Vector3(7, 8, 9)\r\n                local vt = CS.XLuaTest.MyStruct(5, 6)\r\n\r\n                function lua_access_csharp()\r\n                    monoBehaviour:FloatParamMethod(123) --primitive\r\n                    monoBehaviour:Vector3ParamMethod(v3) --vector3\r\n                    local rnd = math.random(1, 100)\r\n                    local r = monoBehaviour:Vector3ParamMethod({x = 1, y = 2, z = rnd}) --vector3\r\n                    assert(r.x == 1 and r.y == 2 and r.z == rnd)\r\n                    monoBehaviour:StructParamMethod(vt) --custom struct\r\n                    r = monoBehaviour:StructParamMethod({a = 1, b = rnd, e = {c = rnd}})\r\n                    assert(r.b == rnd and r.e.c == rnd)\r\n                    monoBehaviour:EnumParamMethod(CS.XLuaTest.MyEnum.E2) --enum\r\n                    monoBehaviour:DecimalParamMethod(monoBehaviour.a5[0])\r\n                    monoBehaviour.a1[0], monoBehaviour.a1[1] = monoBehaviour.a1[1], monoBehaviour.a1[0] -- field\r\n                end\r\n\r\n                exchanger = {\r\n                    exchange = function(self, arr)\r\n                        array_exchange(arr)\r\n                    end\r\n                }\r\n\r\n                A = { B = { C = 789}}\r\n                GDATA = 1234;\r\n            ", "chunk", null);
			this.luaenv.Global.Set<string, NoGc>("monoBehaviour", this);
			this.luaenv.Global.Get<string, IntParam>("id", out this.f1);
			this.luaenv.Global.Get<string, Vector3Param>("id", out this.f2);
			this.luaenv.Global.Get<string, CustomValueTypeParam>("id", out this.f3);
			this.luaenv.Global.Get<string, EnumParam>("id", out this.f4);
			this.luaenv.Global.Get<string, DecimalParam>("id", out this.f5);
			this.luaenv.Global.Get<string, ArrayAccess>("array_exchange", out this.farr);
			this.luaenv.Global.Get<string, Action>("lua_access_csharp", out this.flua);
			this.luaenv.Global.Get<string, IExchanger>("exchanger", out this.ie);
			this.luaenv.Global.Get<string, LuaFunction>("add", out this.add);
			this.luaenv.Global.Set<string, int>("g_int", 123);
			this.luaenv.Global.Set<int, int>(123, 456);
			int num;
			this.luaenv.Global.Get<string, int>("g_int", out num);
			Debug.Log("g_int:" + num.ToString());
			this.luaenv.Global.Get<int, int>(123, out num);
			Debug.Log("123:" + num.ToString());
		}

		private void Update()
		{
			this.f1(1);
			this.f2(new Vector3(1f, 2f, 3f));
			MyStruct myStruct = new MyStruct(5, 6);
			this.f3(myStruct);
			this.f4(MyEnum.E1);
			decimal num = -32132143143100109.00010001010m;
			this.f5(num);
			this.add.Func<int, int, int>(34, 56);
			this.farr(this.a1);
			this.farr(this.a2);
			this.farr(this.a3);
			this.farr(this.a4);
			this.farr(this.a5);
			this.flua();
			this.ie.exchange(this.a2);
			this.luaenv.Global.Set<string, int>("g_int", 456);
			int num2;
			this.luaenv.Global.Get<string, int>("g_int", out num2);
			this.luaenv.Global.Set<double, MyStruct>(123.0001, myStruct);
			MyStruct myStruct2;
			this.luaenv.Global.Get<double, MyStruct>(123.0001, out myStruct2);
			decimal num3 = 0.0000001m;
			this.luaenv.Global.Set<byte, decimal>(12, num);
			this.luaenv.Global.Get<byte, decimal>(12, out num3);
			int num4 = this.luaenv.Global.Get<int>("GDATA");
			this.luaenv.Global.SetInPath<int>("GDATA", num4 + 1);
			int inPath = this.luaenv.Global.GetInPath<int>("A.B.C");
			this.luaenv.Global.SetInPath<int>("A.B.C", inPath + 1);
			this.luaenv.Tick();
		}

		private void OnDestroy()
		{
			this.f1 = null;
			this.f2 = null;
			this.f3 = null;
			this.f4 = null;
			this.f5 = null;
			this.farr = null;
			this.flua = null;
			this.ie = null;
			this.add = null;
			this.luaenv.Dispose();
		}

		private LuaEnv luaenv = new LuaEnv();

		private IntParam f1;

		private Vector3Param f2;

		private CustomValueTypeParam f3;

		private EnumParam f4;

		private DecimalParam f5;

		private ArrayAccess farr;

		private Action flua;

		private IExchanger ie;

		private LuaFunction add;

		[NonSerialized]
		public double[] a1 = new double[]
		{
			1.0,
			2.0
		};

		[NonSerialized]
		public Vector3[] a2 = new Vector3[]
		{
			new Vector3(1f, 2f, 3f),
			new Vector3(4f, 5f, 6f)
		};

		[NonSerialized]
		public MyStruct[] a3 = new MyStruct[]
		{
			new MyStruct(1, 2),
			new MyStruct(3, 4)
		};

		[NonSerialized]
		public MyEnum[] a4 = new MyEnum[]
		{
			MyEnum.E1,
			MyEnum.E2
		};

		[NonSerialized]
		public decimal[] a5 = new decimal[]
		{
			1.00001m,
			2.00002m
		};
	}
}
