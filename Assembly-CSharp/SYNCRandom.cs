using System;
using UnityEngine;

public class SYNCRandom : MonoBehaviour
{
	public static void Rebuild(int seed)
	{
		SYNCRandom.Random = new System.Random(seed);
		SYNCRandom.Seed = seed;
	}

	public static int GetSeed()
	{
		return SYNCRandom.Seed;
	}

	public static int Range(int min, int max)
	{
		SYNCRandom.Random = new System.Random(SYNCRandom.Seed);
		int result = SYNCRandom.Random.Next(min, max);
		SYNCRandom.Seed = SYNCRandom.Random.Next(0, int.MaxValue);
		return result;
	}

	public static float Range(float min, float max)
	{
		SYNCRandom.Random = new System.Random(SYNCRandom.Seed);
		SYNCRandom.Random.NextDouble();
		SYNCRandom.Seed = SYNCRandom.Random.Next(0, int.MaxValue);
		return (float)(SYNCRandom.Random.NextDouble() * (double)(max - min) + (double)min);
	}

	public static int Seed = DateTime.Now.Millisecond;

	public static System.Random Random = new System.Random(SYNCRandom.Seed);
}
