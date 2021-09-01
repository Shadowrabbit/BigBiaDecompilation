using System;

namespace XLua
{
	[Flags]
	public enum HotfixFlag
	{
		Stateless = 0,
		[Obsolete("use xlua.util.state instead!", true)]
		Stateful = 1,
		ValueTypeBoxing = 2,
		IgnoreProperty = 4,
		IgnoreNotPublic = 8,
		Inline = 16,
		IntKey = 32,
		AdaptByDelegate = 64,
		IgnoreCompilerGenerated = 128,
		NoBaseProxy = 256
	}
}
