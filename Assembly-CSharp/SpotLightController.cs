using System;
using System.Collections;
using UnityEngine;
using VLB;

public class SpotLightController : MonoBehaviour
{
	public void ShowSpotLight(Vector3 pos)
	{
		if (this.m_IsShow)
		{
			return;
		}
		base.transform.position = new Vector3(pos.x, 0f, pos.z);
		base.StartCoroutine(this.ShowSpotCorotine());
	}

	public void HideSpotLight()
	{
		if (!this.m_IsShow)
		{
			return;
		}
		base.StartCoroutine(this.HideSpotCorotine());
	}

	private IEnumerator ShowSpotCorotine()
	{
		this.m_IsShow = true;
		float i = 0f;
		float step = 0.5f / Time.fixedDeltaTime;
		while (i < this.Duration)
		{
			this.Spot.range += 25f / step;
			this.Spot.spotAngle += 8f / step;
			this.SpotBeam.spotAngle += 8f / step;
			this.SpotBeam.fadeEnd += 40f / step;
			yield return new WaitForSeconds(Time.fixedDeltaTime);
			i += Time.fixedDeltaTime;
		}
		yield break;
	}

	private IEnumerator HideSpotCorotine()
	{
		float i = 0f;
		float step = 0.5f / Time.fixedDeltaTime;
		while (i < this.Duration)
		{
			this.Spot.range -= 25f / step;
			this.Spot.spotAngle -= 8f / step;
			this.SpotBeam.spotAngle -= 8f / step;
			this.SpotBeam.fadeEnd -= 40f / step;
			yield return new WaitForSeconds(Time.fixedDeltaTime);
			i += Time.fixedDeltaTime;
		}
		this.m_IsShow = false;
		yield break;
	}

	public Light Spot;

	public VolumetricLightBeam SpotBeam;

	public float Duration = 0.5f;

	private bool m_IsShow;
}
