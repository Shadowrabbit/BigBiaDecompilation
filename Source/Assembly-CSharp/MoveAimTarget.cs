using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class MoveAimTarget : MonoBehaviour
{
	private void OnValidate()
	{
		this.VerticalAxis.Validate();
		this.HorizontalAxis.Validate();
		this.AimDistance = Mathf.Max(1f, this.AimDistance);
	}

	private void Reset()
	{
		this.AimDistance = 200f;
		this.ReticleImage = null;
		this.CollideAgainst = 1;
		this.IgnoreTag = string.Empty;
		this.VerticalAxis = new AxisState(-70f, 70f, false, false, 10f, 0.1f, 0.1f, "Mouse Y", true);
		this.VerticalAxis.m_SpeedMode = AxisState.SpeedMode.InputValueGain;
		this.HorizontalAxis = new AxisState(-180f, 180f, true, false, 10f, 0.1f, 0.1f, "Mouse X", false);
		this.HorizontalAxis.m_SpeedMode = AxisState.SpeedMode.InputValueGain;
	}

	private void OnEnable()
	{
		CinemachineCore.CameraUpdatedEvent.RemoveListener(new UnityAction<CinemachineBrain>(this.PlaceReticle));
		CinemachineCore.CameraUpdatedEvent.AddListener(new UnityAction<CinemachineBrain>(this.PlaceReticle));
	}

	private void OnDisable()
	{
		CinemachineCore.CameraUpdatedEvent.RemoveListener(new UnityAction<CinemachineBrain>(this.PlaceReticle));
	}

	private void Update()
	{
		if (this.Brain == null)
		{
			return;
		}
		this.HorizontalAxis.Update(Time.deltaTime);
		this.VerticalAxis.Update(Time.deltaTime);
		this.PlaceTarget();
	}

	private void PlaceTarget()
	{
		Quaternion rotation = Quaternion.Euler(this.VerticalAxis.Value, this.HorizontalAxis.Value, 0f);
		Vector3 rawPosition = this.Brain.CurrentCameraState.RawPosition;
		base.transform.position = this.GetProjectedAimTarget(rawPosition + rotation * Vector3.forward, rawPosition);
	}

	private Vector3 GetProjectedAimTarget(Vector3 pos, Vector3 camPos)
	{
		Vector3 origin = pos;
		Vector3 normalized = (pos - camPos).normalized;
		pos += this.AimDistance * normalized;
		RaycastHit raycastHit;
		if (this.CollideAgainst != 0 && this.RaycastIgnoreTag(new Ray(origin, normalized), out raycastHit, this.AimDistance, this.CollideAgainst))
		{
			pos = raycastHit.point;
		}
		return pos;
	}

	private bool RaycastIgnoreTag(Ray ray, out RaycastHit hitInfo, float rayLength, int layerMask)
	{
		float num = 0f;
		while (Physics.Raycast(ray, out hitInfo, rayLength, layerMask, QueryTriggerInteraction.Ignore))
		{
			if (this.IgnoreTag.Length == 0 || !hitInfo.collider.CompareTag(this.IgnoreTag))
			{
				hitInfo.distance += num;
				return true;
			}
			Ray ray2 = new Ray(ray.GetPoint(rayLength), -ray.direction);
			if (!hitInfo.collider.Raycast(ray2, out hitInfo, rayLength))
			{
				break;
			}
			float num2 = rayLength - (hitInfo.distance - 0.001f);
			if (num2 < 0.001f)
			{
				break;
			}
			num += num2;
			rayLength = hitInfo.distance - 0.001f;
			if (rayLength < 0.001f)
			{
				break;
			}
			ray.origin = ray2.GetPoint(rayLength);
		}
		return false;
	}

	private void PlaceReticle(CinemachineBrain brain)
	{
		if (brain == null || brain != this.Brain || this.ReticleImage == null || brain.OutputCamera == null)
		{
			return;
		}
		this.PlaceTarget();
		CameraState currentCameraState = brain.CurrentCameraState;
		Camera outputCamera = brain.OutputCamera;
		Vector3 vector = outputCamera.WorldToScreenPoint(base.transform.position);
		Vector2 anchoredPosition = new Vector2(vector.x - (float)outputCamera.pixelWidth * 0.5f, vector.y - (float)outputCamera.pixelHeight * 0.5f);
		this.ReticleImage.anchoredPosition = anchoredPosition;
	}

	public CinemachineBrain Brain;

	public RectTransform ReticleImage;

	[Tooltip("How far to raycast to place the aim target")]
	public float AimDistance;

	[Tooltip("Objects on these layers will be detected")]
	public LayerMask CollideAgainst;

	[TagField, Tooltip("Obstacles with this tag will be ignored.  It's a good idea to set this field to the player's tag")]
	public string IgnoreTag = string.Empty;

	[Header("Axis Control"), Tooltip("The Vertical axis.  Value is -90..90. Controls the vertical orientation"), AxisStateProperty]
	public AxisState VerticalAxis;

	[Tooltip("The Horizontal axis.  Value is -180..180.  Controls the horizontal orientation"), AxisStateProperty]
	public AxisState HorizontalAxis;
}
