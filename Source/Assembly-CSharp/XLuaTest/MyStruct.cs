using System;
using XLua;

namespace XLuaTest
{
	[GCOptimize(OptimizeFlag.Default), LuaCallCSharp(GenFlag.No)]
	public struct MyStruct
	{
		public MyStruct(int p1, int p2)
		{
			this.a = p1;
			this.b = p2;
			this.c = p2;
			this.e.c = (byte)p1;
		}

		public int a;

		public int b;

		public decimal c;

		public Pedding e;
	}
}
