using System;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		this.DrawCurve();
	}

	private void DrawCurve()
	{
	}

	private static Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
	{
		float num = 1f - t;
		float d = t * t;
		return num * num * p0 + 2f * num * t * p1 + d * p2;
	}

	public static List<Vector3> GetBezierListAndDrawBezier(Transform startPos, Transform endPos, int count = 50, float rate = 0.75f, float radian = 5f, bool showIndicator = false)
	{
		List<Vector3> list = new List<Vector3>();
		int num = 5;
		if (showIndicator)
		{
			Bezier.ClearLine();
			for (int i = 0; i < 9; i++)
			{
				GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				gameObject.transform.localScale = Vector3.one * 0.5f;
				Bezier.TipLine.Add(gameObject.transform);
			}
		}
		for (int j = 1; j <= count; j++)
		{
			Vector3 vector = Bezier.CalculateCubicBezierPoint((float)j / (float)count, startPos.position, Bezier.GetControlPos(startPos.position, endPos.position, rate, radian), endPos.position);
			if ((j - 1) / num < Bezier.TipLine.Count)
			{
				Bezier.TipLine[(j - 1) / num].position = vector;
			}
			list.Add(vector);
		}
		return list;
	}

	public static List<Vector3> GetBezierListAndDrawBezier(Vector3 startPos, Vector3 endPos, int count = 50, float rate = 0.75f, float radian = 5f, bool showIndicator = false)
	{
		List<Vector3> list = new List<Vector3>();
		int num = 5;
		if (showIndicator)
		{
			Bezier.ClearLine();
			for (int i = 0; i < 9; i++)
			{
				GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				gameObject.transform.localScale = Vector3.one * 0.5f;
				Bezier.TipLine.Add(gameObject.transform);
			}
		}
		for (int j = 1; j <= count; j++)
		{
			Vector3 vector = Bezier.CalculateCubicBezierPoint((float)j / (float)count, startPos, Bezier.GetControlPos(startPos, endPos, rate, radian), endPos);
			if ((j - 1) / num < Bezier.TipLine.Count)
			{
				Bezier.TipLine[(j - 1) / num].position = vector;
			}
			list.Add(vector);
		}
		return list;
	}

	private static Vector3 GetControlPos(Vector3 start, Vector3 end, float rate = 0.75f, float radian = 5f)
	{
		float num = Vector3.Distance(start, end);
		Vector3 normalized = (end - start).normalized;
		Vector3 vector = start + num * rate * normalized;
		vector = new Vector3(vector.x, vector.y + radian, vector.z);
		return vector;
	}

	private float GetAngle_360(Vector3 start, Vector3 end)
	{
		float num = start.x - end.x;
		float num2 = start.y - end.y;
		float num3 = Mathf.Sqrt(Mathf.Pow(num, 2f) + Mathf.Pow(num2, 2f));
		float num4 = Mathf.Acos(num / num3);
		float num5 = 180f / (3.1415927f / num4);
		if (num2 < 0f)
		{
			num5 = -num5;
		}
		else if (num2 == 0f && num < 0f)
		{
			num5 = 180f;
		}
		return num5;
	}

	private static void ClearLine()
	{
		for (int i = Bezier.TipLine.Count - 1; i >= 0; i--)
		{
			UnityEngine.Object.Destroy(Bezier.TipLine[i].gameObject);
		}
		Bezier.TipLine = new List<Transform>();
	}

	public Transform StartPos;

	public Transform EndPos;

	private static List<Transform> TipLine = new List<Transform>();
}
