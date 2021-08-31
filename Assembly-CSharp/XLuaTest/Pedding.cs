using System;
using XLua;

namespace XLuaTest
{
	[GCOptimize(OptimizeFlag.Default), LuaCallCSharp(GenFlag.No)]
	public struct Pedding
	{
		public byte c;
	}
}
