using System;
using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
	private void Start()
	{
		if (this.flash != null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.flash, base.transform.position, Quaternion.identity);
			gameObject.transform.forward = base.gameObject.transform.forward;
			ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
			if (component == null)
			{
				UnityEngine.Object.Destroy(gameObject, component.main.duration);
				return;
			}
			ParticleSystem component2 = gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
			UnityEngine.Object.Destroy(gameObject, component2.main.duration);
		}
	}

	private void FixedUpdate()
	{
		if (this.speed != 0f)
		{
			base.transform.position += base.transform.forward * (this.speed * Time.deltaTime);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		this.speed = 0f;
		ContactPoint contactPoint = collision.contacts[0];
		Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
		Vector3 position = contactPoint.point + contactPoint.normal * this.hitOffset;
		if (this.hit != null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.hit, position, rotation);
			if (this.UseFirePointRotation)
			{
				gameObject.transform.rotation = base.gameObject.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
			}
			else
			{
				gameObject.transform.LookAt(contactPoint.point + contactPoint.normal);
			}
			ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
			if (component == null)
			{
				UnityEngine.Object.Destroy(gameObject, component.main.duration);
			}
			else
			{
				ParticleSystem component2 = gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
				UnityEngine.Object.Destroy(gameObject, component2.main.duration);
			}
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public float speed = 15f;

	public float hitOffset;

	public bool UseFirePointRotation;

	public GameObject hit;

	public GameObject flash;
}
