using System;
using UnityEngine;

[ExecuteInEditMode]
public class CameraMagnetProperty : MonoBehaviour
{
	private void Start()
	{
		this.myTransform = base.transform;
	}

	private void Update()
	{
		if (this.ProximityVisualization != null)
		{
			this.ProximityVisualization.localScale = new Vector3(this.Proximity * 2f, this.Proximity * 2f, 1f);
		}
	}

	[Range(0.1f, 50f)]
	public float MagnetStrength = 5f;

	[Range(0.1f, 50f)]
	public float Proximity = 5f;

	public Transform ProximityVisualization;

	[HideInInspector]
	public Transform myTransform;
}
