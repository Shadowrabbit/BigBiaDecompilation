using System;

namespace XLua
{
	public static class HotfixDelegateBridge
	{
		public static bool xlua_get_hotfix_flag(int idx)
		{
			return idx < DelegateBridge.DelegateBridgeList.Length && DelegateBridge.DelegateBridgeList[idx] != null;
		}

		public static DelegateBridge Get(int idx)
		{
			return DelegateBridge.DelegateBridgeList[idx];
		}

		public static void Set(int idx, DelegateBridge val)
		{
			if (idx >= DelegateBridge.DelegateBridgeList.Length)
			{
				DelegateBridge[] array = new DelegateBridge[idx + 1];
				for (int i = 0; i < DelegateBridge.DelegateBridgeList.Length; i++)
				{
					array[i] = DelegateBridge.DelegateBridgeList[i];
				}
				DelegateBridge.DelegateBridgeList = array;
			}
			DelegateBridge.DelegateBridgeList[idx] = val;
		}
	}
}
