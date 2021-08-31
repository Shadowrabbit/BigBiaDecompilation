using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	public class InvokeLua : MonoBehaviour
	{
		private void Start()
		{
			LuaEnv luaEnv = new LuaEnv();
			this.Test(luaEnv);
			luaEnv.Dispose();
		}

		private void Test(LuaEnv luaenv)
		{
			luaenv.DoString(this.script, "chunk", null);
			InvokeLua.ICalc calc = luaenv.Global.GetInPath<InvokeLua.CalcNew>("Calc.New")(10, new string[]
			{
				"hi",
				"john"
			});
			Debug.Log("sum(*10) =" + calc.Add(1, 2).ToString());
			calc.Mult = 100;
			Debug.Log("sum(*100)=" + calc.Add(1, 2).ToString());
			string str = "list[0]=";
			object obj = calc[0];
			Debug.Log(str + ((obj != null) ? obj.ToString() : null));
			string str2 = "list[1]=";
			object obj2 = calc[1];
			Debug.Log(str2 + ((obj2 != null) ? obj2.ToString() : null));
			calc.PropertyChanged += this.Notify;
			calc[1] = "dddd";
			string str3 = "list[1]=";
			object obj3 = calc[1];
			Debug.Log(str3 + ((obj3 != null) ? obj3.ToString() : null));
			calc.PropertyChanged -= this.Notify;
			calc[1] = "eeee";
			string str4 = "list[1]=";
			object obj4 = calc[1];
			Debug.Log(str4 + ((obj4 != null) ? obj4.ToString() : null));
		}

		private void Notify(object sender, PropertyChangedEventArgs e)
		{
			Debug.Log(string.Format("{0} has property changed {1}={2}", sender, e.name, e.value));
		}

		private void Update()
		{
		}

		private string script = "\r\n                local calc_mt = {\r\n                    __index = {\r\n                        Add = function(self, a, b)\r\n                            return (a + b) * self.Mult\r\n                        end,\r\n                        \r\n                        get_Item = function(self, index)\r\n                            return self.list[index + 1]\r\n                        end,\r\n\r\n                        set_Item = function(self, index, value)\r\n                            self.list[index + 1] = value\r\n                            self:notify({name = index, value = value})\r\n                        end,\r\n                        \r\n                        add_PropertyChanged = function(self, delegate)\r\n\t                        if self.notifylist == nil then\r\n\t\t                        self.notifylist = {}\r\n\t                        end\r\n\t                        table.insert(self.notifylist, delegate)\r\n                            print('add',delegate)\r\n                        end,\r\n                                                \r\n                        remove_PropertyChanged = function(self, delegate)\r\n                            for i=1, #self.notifylist do\r\n\t\t                        if CS.System.Object.Equals(self.notifylist[i], delegate) then\r\n\t\t\t                        table.remove(self.notifylist, i)\r\n\t\t\t                        break\r\n\t\t                        end\r\n\t                        end\r\n                            print('remove', delegate)\r\n                        end,\r\n\r\n                        notify = function(self, evt)\r\n\t                        if self.notifylist ~= nil then\r\n\t\t                        for i=1, #self.notifylist do\r\n\t\t\t                        self.notifylist[i](self, evt)\r\n\t\t                        end\r\n\t                        end\t\r\n                        end,\r\n                    }\r\n                }\r\n\r\n                Calc = {\r\n\t                New = function (mult, ...)\r\n                        print(...)\r\n                        return setmetatable({Mult = mult, list = {'aaaa','bbbb','cccc'}}, calc_mt)\r\n                    end\r\n                }\r\n\t        ";

		[CSharpCallLua]
		public interface ICalc
		{
			event EventHandler<PropertyChangedEventArgs> PropertyChanged;

			int Add(int a, int b);

			int Mult { get; set; }

			object this[int index]
			{
				get;
				set;
			}
		}

		[CSharpCallLua]
		public delegate InvokeLua.ICalc CalcNew(int mult, params string[] args);
	}
}
