using System;
using UnityEngine;

public static class CameraUtils
{
	public static Camera MainCamera
	{
		get
		{
			if (CameraUtils.m_MainCamera == null)
			{
				CameraUtils.m_MainCamera = Camera.main;
			}
			return CameraUtils.m_MainCamera;
		}
	}

	public static Vector3 MyScreenPointToWorldPoint(Vector3 ScreenPoint, Transform target)
	{
		Vector3 vector = Vector3.Project(target.position - CameraUtils.MainCamera.transform.position, CameraUtils.MainCamera.transform.forward);
		return CameraUtils.MainCamera.ViewportToWorldPoint(new Vector3(ScreenPoint.x / (float)Screen.width, ScreenPoint.y / (float)Screen.height, vector.magnitude));
	}

	private static Camera m_MainCamera;
}
