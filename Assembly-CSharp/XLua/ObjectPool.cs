using System;
using System.Collections.Generic;

namespace XLua
{
	public class ObjectPool
	{
		public object this[int i]
		{
			get
			{
				if (i >= 0 && i < this.count)
				{
					return this.list[i].obj;
				}
				return null;
			}
		}

		public void Clear()
		{
			this.freelist = -1;
			this.count = 0;
			this.list = new ObjectPool.Slot[512];
		}

		private void extend_capacity()
		{
			ObjectPool.Slot[] array = new ObjectPool.Slot[this.list.Length * 2];
			for (int i = 0; i < this.list.Length; i++)
			{
				array[i] = this.list[i];
			}
			this.list = array;
		}

		public int Add(object obj)
		{
			int num;
			if (this.freelist != -1)
			{
				num = this.freelist;
				this.list[num].obj = obj;
				this.freelist = this.list[num].next;
				this.list[num].next = -2;
			}
			else
			{
				if (this.count == this.list.Length)
				{
					this.extend_capacity();
				}
				num = this.count;
				this.list[num] = new ObjectPool.Slot(-2, obj);
				this.count = num + 1;
			}
			return num;
		}

		public bool TryGetValue(int index, out object obj)
		{
			if (index >= 0 && index < this.count && this.list[index].next == -2)
			{
				obj = this.list[index].obj;
				return true;
			}
			obj = null;
			return false;
		}

		public object Get(int index)
		{
			if (index >= 0 && index < this.count)
			{
				return this.list[index].obj;
			}
			return null;
		}

		public object Remove(int index)
		{
			if (index >= 0 && index < this.count && this.list[index].next == -2)
			{
				object obj = this.list[index].obj;
				this.list[index].obj = null;
				this.list[index].next = this.freelist;
				this.freelist = index;
				return obj;
			}
			return null;
		}

		public object Replace(int index, object o)
		{
			if (index >= 0 && index < this.count)
			{
				object obj = this.list[index].obj;
				this.list[index].obj = o;
				return obj;
			}
			return null;
		}

		public int Check(int check_pos, int max_check, Func<object, bool> checker, Dictionary<object, int> reverse_map)
		{
			if (this.count == 0)
			{
				return 0;
			}
			for (int i = 0; i < Math.Min(max_check, this.count); i++)
			{
				check_pos %= this.count;
				if (this.list[check_pos].next == -2 && this.list[check_pos].obj != null && !checker(this.list[check_pos].obj))
				{
					object key = this.Replace(check_pos, null);
					int num;
					if (reverse_map.TryGetValue(key, out num) && num == check_pos)
					{
						reverse_map.Remove(key);
					}
				}
				check_pos++;
			}
			return check_pos %= this.count;
		}

		private const int LIST_END = -1;

		private const int ALLOCED = -2;

		private ObjectPool.Slot[] list = new ObjectPool.Slot[512];

		private int freelist = -1;

		private int count;

		private struct Slot
		{
			public Slot(int next, object obj)
			{
				this.next = next;
				this.obj = obj;
			}

			public int next;

			public object obj;
		}
	}
}
